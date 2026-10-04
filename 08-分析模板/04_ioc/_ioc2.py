# -*- coding: utf-8 -*-
import re

pe = r"C:\malware_work\NJRAT\njrat_decrypted.exe"
with open(pe, "rb") as f:
    data = f.read()

IMAGE_BASE = 0x400000
def va2off(va):
    rva = va - IMAGE_BASE
    secs = [(0x1000, 0x7F6C, 0x400), (0x9000, 0x213B0, 0x0), (0x2B000, 0x33D0, 0x8400), (0x2F000, 0xEA4, 0xB800), (0x30000, 0x1000, 0xCA00), (0x31000, 0x1200, 0xCC00)]
    for va_, vs, raw in secs:
        if va_ <= rva < va_ + max(vs, 1):
            return raw + (rva - va_)
    return None

print("=" * 70)
print("NJRAT IOC 清单")
print("=" * 70)

# C2
print("\n[1] C2 服务器:")
urls = []
for va in range(0x42B094, 0x42B450, 4):
    off = va2off(va)
    if off is None: continue
    end = data.find(b"\x00", off)
    if end < 0 or end - off > 200: continue
    try:
        s = data[off:end].decode("ascii")
        if s.startswith("http://") or s.startswith("https://"):
            urls.append((va, s))
    except: pass
for va, s in urls:
    print(f"  0x{va:x}  {s}")

# 持久化
print("\n[2] 持久化位置:")
for p in [b"ShellServiceObjectDelayLoad", b"Internet Settings", b"Zones", b"IE Setup"]:
    if p in data:
        print("  " + p.decode())

# 文件名
print("\n[3] 落地文件名:")
for f in [b"kk32.dll", b"kk32.vxd", b"dnkk.dll", b"surf.dat", b"cmd.pif",
          b"command.pif", b"cmd.exe", b"command.com", b"Iexplore.exe", b"Rtdx1"]:
    if f in data:
        print("  " + f.decode())

# 互斥/标识
print("\n[4] 互斥/标识:")
for m in [b"79FEACFF-FFCE-815E-A900-316290B5B738", b"ofs_kk", b"vvpupkin",
          b"crutop", b"KingKarton", b"KingKarton_10", b"blind_user",
          b"X-okRecv11", b"IEFrame", b"MicroSoft-Corp", b"Web Event Logger",
          b"DocObject", b"Explorer", b"frm2"]:
    if m in data:
        print("  " + m.decode())

# 银行钓鱼
print("\n[5] 银行钓鱼关键词:")
for b in [b".paypal.com", b"signin.ebay.", b".yahoo.com", b"webmail.juno.com",
          b"my.juno.com", b".juno.com", b".earthlink.", b"Sign in",
          b"Log In", b"Sign In", b"ATM PIN", b"CVV2", b"Visa", b"MasterCard"]:
    if b in data:
        print("  " + b.decode())

print("\n[6] 关键行为函数地址:")
for k, v in {
    "初始化": "0x40129c",
    "主窗体/键盘钩子": "0x401bf5",
    "屏幕监控": "0x40544c",
    "网页注入": "0x404828",
    "持久化 KingKarton_10": "0x407947",
    "银行钓鱼窗口": "0x407edc",
    "进程注入 ntdll": "0x402a82",
    "C2 通信": "0x4073f8",
    "Web 注入模板": "0x405a48",
}.items():
    print(f"  {v}  {k}")
