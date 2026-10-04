# -*- coding: utf-8 -*-
import re
from collections import defaultdict

asm = r"C:\malware_work\NJRAT\njrat_decrypted.asm"
with open(asm, "r", encoding="utf-8", errors="replace") as f:
    content = f.read()
    lines = content.splitlines()

# 找所有函数定义和它们内部调用的 API
funcs = {}
current_func = None
for line in lines:
    m = re.match(r"^sub_([0-9a-f]+) @ (0x[0-9a-f]+)", line)
    if m:
        current_func = m.group(2)
        funcs[current_func] = []
    else:
        if current_func:
            # 记录 call 目标
            c = re.search(r"call 0040([0-9A-Fa-f]+)h", line)
            if c:
                funcs[current_func].append("0x40" + c.group(1).lower())

# 找 API 调用（通过 call 到 0x42xxxx 的跳转表间接）
# 从反汇编看，很多 call 00408xxx 是 wrapper（jmp [42Fxxx]），这是 IAT 调用
# 我们直接找关键 API 字符串及其所在函数

# 关键 API 关键词
key_apis = {
    "InternetOpen": ["InternetOpen", "InternetConnect", "HttpOpenRequest", "HttpSendRequest", "InternetReadFile"],
    "Winsock": ["WSASocket", "connect", "send", "recv", "WSAStartup", "socket", "bind", "listen", "accept"],
    "进程注入": ["VirtualAllocEx", "WriteProcessMemory", "CreateRemoteThread", "NtUnmapViewOfSection", "NtMapViewOfSection", "ResumeThread", "SetThreadContext", "GetThreadContext"],
    "键盘记录": ["SetWindowsHookEx", "GetAsyncKeyState", "GetKeyState", "GetForegroundWindow", "GetWindowText"],
    "屏幕/摄像头": ["BitBlt", "GetDC", "CreateCompatibleDC", "capCreateCaptureWindow", "CreateDIBSection"],
    "注册表": ["RegCreateKeyEx", "RegSetValueEx", "RegOpenKeyEx", "RegQueryValueEx"],
    "进程创建": ["CreateProcess", "WinExec", "ShellExecute", "CreateProcessAsUser"],
    "持久化": ["CreateService", "ShellServiceObjectDelayLoad", "RegisterServiceProcess"],
    "反调试": ["IsDebuggerPresent", "CheckRemoteDebuggerPresent", "NtQueryInformationProcess", "OutputDebugString"],
    "加密": ["CryptEncrypt", "CryptDecrypt", "CryptGenKey", "MD5", "SHA"],
    "远程 Shell": ["CreatePipe", "PeekNamedPipe", "ReadFile", "WriteFile"],
}

# 找 IAT 表里 key API 对应的 wrapper 地址
# 通过反汇编里 jmp dword [42Fxxx] 的形式
# 先解析字符串附近的 IAT 引用
with open(r"C:\malware_work\NJRAT\njrat_decrypted.exe", "rb") as f:
    data = f.read()

def addr_to_off(addr):
    rva = addr - 0x400000
    sections = [
        (0x1000, 0x400, 0x7F6C),
        (0x9000, 0x0, 0x213B0),
        (0x2B000, 0x8400, 0x33D0),
        (0x2F000, 0xB800, 0xEA4),
        (0x30000, 0xCA00, 0x200),
        (0x31000, 0xCC00, 0x1200),
    ]
    for va, raw, vs in sections:
        if va <= rva < va + vs:
            return raw + (rva - va)
    return None

def read_str(addr, maxlen=80):
    off = addr_to_off(addr)
    if off is None: return None
    end = data.find(b"\x00", off)
    if end < 0 or end - off > maxlen: return None
    try: return data[off:end].decode("ascii")
    except: return None

# 提取 .idata 里的导入表
# .idata VA=0x2F000, RAW=0xB800, SIZE=0xEA4
idata_off = 0xB800
# 通过解析导入表找每个 API 的名字和 IAT 地址
# 简化：直接找 .idata 里的 API 名字和对应 thunk
api_map = {}  # iat_addr -> api_name

# 手动解析导入表
import struct
# 导入描述符从 .idata 开始
desc_off = idata_off
while True:
    if desc_off + 20 > len(data): break
    original_first_thunk = struct.unpack("<I", data[desc_off:desc_off+4])[0]
    time_date = struct.unpack("<I", data[desc_off+4:desc_off+8])[0]
    forwarder_chain = struct.unpack("<I", data[desc_off+8:desc_off+12])[0]
    name_rva = struct.unpack("<I", data[desc_off+12:desc_off+16])[0]
    first_thunk = struct.unpack("<I", data[desc_off+16:desc_off+20])[0]
    if name_rva == 0 and first_thunk == 0:
        break
    # 解 dll 名
    dll_off = addr_to_off(name_rva + 0x400000)
    if dll_off:
        dll_end = data.find(b"\x00", dll_off)
        dll_name = data[dll_off:dll_end].decode("ascii", "replace")
    else:
        dll_name = "?"
    # 解 thunk
    thunk_rva = original_first_thunk or first_thunk
    thunk_off = addr_to_off(thunk_rva + 0x400000)
    iat_rva = first_thunk
    i = 0
    while True:
        if thunk_off is None: break
        thunk_val = struct.unpack("<I", data[thunk_off:thunk_off+4])[0]
        if thunk_val == 0: break
        if thunk_val & 0x80000000:
            # ordinal
            api_map[iat_rva + i*4] = f"{dll_name}#ord{thunk_val & 0x7FFFFFFF}"
        else:
            hint_off = addr_to_off(thunk_val + 0x400000)
            if hint_off:
                name_end = data.find(b"\x00", hint_off + 2)
                api_name = data[hint_off+2:name_end].decode("ascii", "replace")
                api_map[iat_rva + i*4] = f"{dll_name}!{api_name}"
        thunk_off += 4
        i += 1
    desc_off += 20

print(f"IAT 表解析完成，共 {len(api_map)} 个 API")
print()

# 找反汇编里 jmp dword [42Fxxx] 的 wrapper
# 这些 wrapper 调用的就是 IAT 里的 API
wrapper_to_api = {}
for line in lines:
    m = re.match(r"^sub_([0-9a-f]+) @ 0x([0-9a-f]+)", line)
    if m:
        wrapper_addr = int(m.group(2), 16)
        continue
    j = re.search(r"jmp dword \[42F([0-9A-Fa-f]{3})h\]", line)
    if j and wrapper_addr:
        iat_addr = 0x42F000 + int(j.group(1), 16)
        if iat_addr in api_map:
            wrapper_to_api[wrapper_addr] = api_map[iat_addr]
        wrapper_addr = None

print(f"找到 {len(wrapper_to_api)} 个 API wrapper")
print()

# 对每个关键 API，找调用它的函数
print("=" * 80)
print("关键 API 调用点")
print("=" * 80)
for cat, kws in key_apis.items():
    print(f"\n### {cat} ###")
    found = []
    for waddr, api in wrapper_to_api.items():
        if any(k.lower() in api.lower() for k in kws):
            # 找调用这个 wrapper 的函数
            calls_to = []
            for faddr, calls in funcs.items():
                if f"0x{waddr:x}" in calls:
                    calls_to.append(faddr)
            found.append((api, faddr if False else hex(waddr), calls_to))
    for api, waddr, calls_to in found:
        print(f"  {api}")
        print(f"    wrapper @ {waddr}")
        if calls_to:
            print(f"    被调用自: {', '.join(calls_to[:5])}")
