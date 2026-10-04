# -*- coding: utf-8 -*-
"""AgentTesla - 完成 payload 提取（去掉 emoji）"""
import struct, re

p = r"C:\malware_work\AgentTesla\extracted\PAGO.exe"
with open(p, "rb") as f:
    data = f.read()

key = bytes([53, 52, 56, 66, 72, 69, 51, 53, 90, 56, 83, 72, 55, 56, 56, 56, 71, 83, 66, 89, 68, 57])

def decrypt_v2(original, key):
    n = len(original)
    if n < 2: return b""
    out = bytearray(n)
    orig = bytes(original)
    for i in range(n):
        local8 = orig[i]
        local10 = orig[(i+1) % n]
        local11 = key[i % len(key)]
        out[i] = ((local8 ^ local11) - local10 + 256) & 255
    return bytes(out)

# 从 0x3d6e 开始解密
start = 0x3d6e

# 关键：解密算法是循环依赖的（用 local3 = local1 循环内的）不能简单按块
# 需要一次性解密整个 ZH 数组
# 但我们不知道 ZH 总长度
# 观察：MZ + DOS stub 后面应该是 PE 头
# 从解密后前 0x40 字节看：
# 0x00: 4d5a9000 0300 0000 0400 0000 ffff0000
# 0x10: b8000000 00000000 40000000 00000000
# 0x20: ...
# 0x3C: PE 头偏移

# 我尝试从不同长度解出完整 PE

for length in [0x4000, 0x8000, 0x10000, 0x20000, 0x40000, 0x80000, 0x100000, 0x200000]:
    chunk = data[start:start+length]
    if len(chunk) < length: 
        print(f"length={length} 数据不足")
        break
    dec = decrypt_v2(chunk, key)
    if dec[:2] != b"MZ":
        print(f"length={length}: 首字节非 MZ")
        continue
    pe_off = struct.unpack("<I", dec[0x3C:0x40])[0]
    if not (0x40 <= pe_off <= 0x200):
        print(f"length={length}: PE 偏移异常 0x{pe_off:x}")
        continue
    if dec[pe_off:pe_off+4] != b"PE\x00\x00":
        print(f"length={length}: PE 签名不匹配 0x{pe_off:x} => {dec[pe_off:pe_off+4].hex()}")
        continue
    
    machine = struct.unpack("<H", dec[pe_off+4:pe_off+6])[0]
    nsec = struct.unpack("<H", dec[pe_off+6:pe_off+8])[0]
    ts = struct.unpack("<I", dec[pe_off+8:pe_off+12])[0]
    print(f"length={length} (0x{length:x}): 有效 PE! machine=0x{machine:04x} 节数={nsec} ts=0x{ts:08x}")
    
    # 提取完整 PE
    opt_off = pe_off + 24
    opt_size = struct.unpack("<H", dec[pe_off+20:pe_off+22])[0]
    sec_off = pe_off + 24 + opt_size
    max_end = pe_off
    for i in range(nsec):
        s = sec_off + i*40
        raw_off = struct.unpack("<I", dec[s+20:s+24])[0]
        rsize = struct.unpack("<I", dec[s+16:s+20])[0]
        end = raw_off + rsize
        if end > max_end: max_end = end
    print(f"  估算 PE 大小: 0x{max_end:x}")
    
    # 保存
    out_path = rf"C:\malware_work\AgentTesla\hidden_payload.bin"
    with open(out_path, "wb") as f:
        f.write(dec[:max_end])
    print(f"  已保存: {out_path} ({max_end} 字节)")
    
    # 内部字符串
    print(f"  [关键字符串]")
    seen = set()
    cnt = 0
    for m in re.finditer(rb"[\x20-\x7e]{8,150}", dec[:max_end]):
        t = m.group().decode("ascii", "replace")
        if t in seen: continue
        seen.add(t)
        tl = t.lower()
        if any(k in tl for k in ["smtp.", "telegram", "http://", "https://",
                                  "bot", "chat_id", "password", "chrome",
                                  "firefox", "outlook", "keylog", "agent",
                                  "tesla", "stealer", "ftp.", "gate"]):
            if not any(x in tl for x in ["microsoft", "digicert", "schemas"]):
                print(f"    {t[:160]}")
                cnt += 1
                if cnt >= 20: break
    break
else:
    print("未找到有效 PE")
