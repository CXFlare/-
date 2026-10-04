# -*- coding: utf-8 -*-
import struct, re, os

path = r"C:\malware_work\NJRAT\b54802ccdd1ae31f129f6caabdb92f45_NeikiAnalytics.exe"
with open(path, "rb") as f:
    raw = bytearray(f.read())

IMAGE_BASE = 0x400000

# 节表: (name, VA, VS, RAW_off, RS)
sections = [
    (".text", 0x1000, 0x7F6C, 0x400, 0x7F6C),
    (".bss",  0x9000, 0x213B0, 0x0, 0x0),
    (".data", 0x2B000, 0x33D0, 0x8400, 0x33D0),
    (".idata",0x2F000, 0xEA4, 0xB800, 0xEA4),
    (".fldo", 0x30000, 0x1000, 0xCA00, 0x200),
    (".l1",   0x31000, 0x1200, 0xCC00, 0x1200),
]

def addr_to_off(addr, end=False):
    rva = addr - IMAGE_BASE
    for name, va, vs, raw_off, rs in sections:
        span = max(vs, rs)
        if end:
            if va <= rva <= va + span:
                return raw_off + (rva - va)
        else:
            if va <= rva < va + span:
                return raw_off + (rva - va)
    print(f"  [!] 地址 {hex(addr)} 无法映射 (rva={hex(rva)})")
    return None

def xor_block(addr_s, addr_e, key, step=4):
    off_s = addr_to_off(addr_s)
    off_e = addr_to_off(addr_e, end=True)
    if off_s is None or off_e is None:
        return None, None
    key_bytes = struct.pack("<I", key)
    n = off_e - off_s
    result = bytearray(raw[off_s:off_e])
    for i in range(0, n, step):
        for k in range(step):
            if i + k < n:
                result[i+k] ^= key_bytes[k]
    return bytes(result), off_s

print("=" * 70)
print("NJRAT 全量 XOR 解密")
print("=" * 70)

# 段1
print("\n[段1 .text] 0x401000 - 0x408F6C, key=0x4F1E597C")
seg1, off1 = xor_block(0x401000, 0x408F6C, 0x4F1E597C)
if seg1:
    print(f"  OK: {len(seg1)} 字节, off=0x{off1:X}")
    with open(r"C:\malware_work\NJRAT\seg1_decrypted.bin", "wb") as f:
        f.write(seg1)
    # 特征：解密后应该是 x86 代码
    # 看开头是否像代码
    print(f"  前 32 字节: {seg1[:32].hex()}")
    # 找可读字符串
    strings = re.findall(rb"[\x20-\x7e]{6,}", seg1)
    print(f"  字符串 {len(strings)} 条（前 30）:")
    for s in strings[:30]:
        try: print(f"    {s.decode('ascii')[:120]}")
        except: pass

# 段2
print("\n[段2 .data] 0x42B000 - 0x42E3D0, key=0x29C73795")
seg2, off2 = xor_block(0x42B000, 0x42E3D0, 0x29C73795)
if seg2:
    print(f"  OK: {len(seg2)} 字节, off=0x{off2:X}")
    with open(r"C:\malware_work\NJRAT\seg2_decrypted.bin", "wb") as f:
        f.write(seg2)
    strings2 = re.findall(rb"[\x20-\x7e]{5,}", seg2)
    print(f"  字符串 {len(strings2)} 条")

# 关键：构造"解密后的 PE"——把 seg1 和 seg2 写回原文件对应位置
patched = bytearray(raw)
if seg1 and off1 is not None:
    patched[off1:off1+len(seg1)] = seg1
if seg2 and off2 is not None:
    patched[off2:off2+len(seg2)] = seg2
out_pe = r"C:\malware_work\NJRAT\njrat_decrypted.exe"
with open(out_pe, "wb") as f:
    f.write(patched)
print(f"\n[产物] 解密后的 PE: {out_pe}")
print(f"  大小: {len(patched)} 字节")
