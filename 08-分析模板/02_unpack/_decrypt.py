# -*- coding: utf-8 -*-
import struct, re

path = r"C:\malware_work\NJRAT\b54802ccdd1ae31f129f6caabdb92f45_NeikiAnalytics.exe"
with open(path, "rb") as f:
    data = bytearray(f.read())

IMAGE_BASE = 0x400000

def addr_to_off(addr, inclusive_end=False):
    rva = addr - IMAGE_BASE
    sections = [
        (0x1000, 0x400, 0x7F6C),
        (0x9000, 0x0, 0x213B0),
        (0x2B000, 0x8400, 0x33D0),
        (0x2F000, 0xB800, 0xEA4),
        (0x30000, 0xCA00, 0x200),
        (0x31000, 0xCC00, 0x1200),
    ]
    for va, raw, vs in sections:
        if inclusive_end:
            ok = va <= rva <= va + vs
        else:
            ok = va <= rva < va + vs
        if ok:
            return raw + (rva - va)
    # 若越界，看看离哪个节最近
    print(f"    [警告] addr=0x{addr:X} (rva=0x{rva:X}) 不在任何节内")
    return None

def xor_decrypt(addr_s, addr_e, key, step=4):
    off_s = addr_to_off(addr_s)
    off_e = addr_to_off(addr_e, inclusive_end=True)
    if off_s is None:
        return b""
    if off_e is None:
        off_e = len(data)
    key_bytes = struct.pack("<I", key)
    result = bytearray()
    i = off_s
    while i < off_e:
        for k in range(step):
            if i + k < len(data) and i + k < off_e:
                result.append(data[i+k] ^ key_bytes[k])
        i += step
    return bytes(result)

print("=" * 70)
print("NJRAT XOR 解密（修正边界）")
print("=" * 70)

for label, (s, e, k) in {
    "段1": (0x401000, 0x408F6C, 0x4F1E597C),
    "段2": (0x42B000, 0x42E3D0, 0x29C73795),
}.items():
    print(f"\n[{label}] addr 0x{s:X} - 0x{e:X}, key=0x{k:08X}")
    off_s = addr_to_off(s)
    off_e = addr_to_off(e, inclusive_end=True)
    print(f"  文件偏移: 0x{off_s if off_s is not None else 0:X} - 0x{off_e if off_e is not None else 0:X}")
    seg = xor_decrypt(s, e, k)
    print(f"  解密 {len(seg)} 字节")
    strings = re.findall(rb"[\x20-\x7e]{5,}", seg)
    print(f"  字符串 {len(strings)} 条")
    for st in strings[:50]:
        try: print(f"    {st.decode('ascii')[:140]}")
        except: pass
    with open(f"C:\\malware_work\\NJRAT\\decrypted_{label}.bin", "wb") as f:
        f.write(seg)
    print(f"  已保存 decrypted_{label}.bin")
