# -*- coding: utf-8 -*-
import re, os

pe = r"C:\malware_work\NJRAT\njrat_decrypted.exe"
with open(pe, "rb") as f:
    data = f.read()

print("=" * 70)
print("NJRAT 解密后 PE 全量字符串提取")
print("=" * 70)

# ASCII
ascii_str = re.findall(rb"[\x20-\x7e]{5,}", data)
# UTF-16LE
utf16_str = re.findall(rb"(?:[\x20-\x7e]\x00){4,}", data)

print(f"\n[ASCII] {len(ascii_str)} 条")
print("[UTF-16LE] " + str(len(utf16_str)) + " 条")

# 关键分类
keywords = {
    "C2/URL": ["http://", "https://", ".ru/", ".php", ".htm"],
    "注册表": ["SOFTWARE\\", "CurrentVersion", "Run\\", "Policies"],
    "文件系统": ["\\Temp\\", "%s\\", "AppData", "ProgramData", "System32"],
    "进程/服务": ["cmd.exe", "svchost", "taskkill", "schtasks", "net user", "reg add"],
    "远程控制": ["Keylog", "Screen", "Webcam", "Chat", "Remote", "Microphone"],
    "网络 API": ["InternetOpen", "HttpSend", "WinHttp", "WSA", "socket", "connect"],
    "进程注入": ["VirtualAlloc", "WriteProcessMemory", "CreateRemoteThread", "NtUnmap", "NtMap"],
    "加密": ["RC4", "AES", "Crypt", "RC4", "base64", "XOR"],
    "反调试": ["IsDebuggerPresent", "CheckRemoteDebugger", "NtQuery", "PEB"],
    "持久化": ["CreateService", "RegSetValue", "ShellExecute", "startup", "Startup"],
}

ascii_decoded = [s.decode("ascii", "replace") for s in ascii_str]
all_text = "\n".join(ascii_decoded)

for cat, kws in keywords.items():
    hits = []
    for k in kws:
        for line in ascii_decoded:
            if k.lower() in line.lower() and line not in hits:
                hits.append(line)
                if len(hits) >= 30: break
        if len(hits) >= 30: break
    print(f"\n[{cat}] {len(hits)} 条:")
    for h in hits[:25]:
        print(f"    {h[:150]}")

# 保存完整字符串表
with open(r"C:\malware_work\NJRAT\strings_full.txt", "w", encoding="utf-8") as f:
    f.write("### ASCII ###\n")
    for s in ascii_decoded:
        f.write(s + "\n")
    f.write("\n### UTF-16LE ###\n")
    for s in utf16_str:
        try:
            f.write(s.decode("utf-16le", "replace") + "\n")
        except: pass
print("\n已保存: strings_full.txt")
