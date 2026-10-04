# -*- coding: utf-8 -*-
"""888RAT AutoIt EA06 脚本解密尝试"""
import struct, os

pe = r"C:\malware_work\888RAT\888RAT 1.1.1 cracked.exe"
with open(pe, "rb") as f:
    data = f.read()

# EA06 标记位于 0xd341c
marker = data.find(b"AU3!EA06M")
print(f"EA06M 标记: 0x{marker:x}")

# 结构：AU3!EA06 + [2字节标志] + [4字节大小] + [4字节key?] + 数据
# 有的版本是：
# - "AU3!EA06" (8 字节)
# - 4 字节：未压缩大小 (小端)
# - 4 字节：压缩后大小
# - 4 字节：CRC
# - 压缩数据（LZMA）

ctx = data[marker:marker+40]
print(f"标记后 32 字节: {ctx[:32].hex()}")
print(f"标记后 ASCII:  {ctx[:32]}")

# 尝试寻找 LZMA 头 (5D 00 00)
# 从 marker 往后扫 2000 字节
print()
print("[marker 后扫 LZMA 头]")
for offset in range(marker, marker+2000):
    if data[offset:offset+3] == b"\x5D\x00\x00":
        print(f"  可能 LZMA 头 @ 0x{offset:x}")
        # 检查字典大小
        if offset + 13 <= len(data):
            dict_size = struct.unpack("<I", data[offset+1:offset+5])[0]
            print(f"    dict_size = 0x{dict_size:x}")

# EA06 通常是 LZMA 压缩的 AU3 脚本
# 尝试：从 marker+12 后开始尝试各种偏移，用 lzma 解压
print()
print("[尝试 LZMA 解压]")
import lzma

for offset in [marker+12, marker+16, marker+24, marker+28, marker+32, marker+36]:
    for skip in range(0, 8):
        o = offset + skip
        blob = data[o:o+2_000_000]
        try:
            # LZMA 头通常是 13 字节
            # 尝试 FORMAT_ALONE
            decomp = lzma.LZMADecompressor()
            result = decomp.decompress(blob[:200_000])
            if b"Func " in result[:10000] or b"#include" in result[:10000] or b"MsgBox" in result[:10000]:
                print(f"  成功！@ 0x{o:x}, 解密 {len(result)} 字节")
                out_path = r"C:\malware_work\888RAT\decrypted.au3"
                with open(out_path, "wb") as f:
                    f.write(result)
                print(f"  已保存: {out_path}")
                # 打印部分内容
                try:
                    print(f"  前 500 字节: {result[:500].decode('utf-8', 'replace')}")
                except: pass
                break
        except Exception as e:
            pass
