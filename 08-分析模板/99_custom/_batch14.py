# -*- coding: utf-8 -*-
"""批量分析刚解压的样本"""
import re, hashlib, os

samples = [
    ("GoldenEye.exe", r"C:\malware_work\GoldenEye\GoldenEye.exe"),
    ("Akira", r"C:\malware_work\Akira\9fd1338920e1e43932073399d021ef0cebfeb140100dd6f13b9143b37093131d.bin.sample"),
    ("BadRabbit", r"C:\malware_work\BadRabbit\BadRabbit.exe"),
    ("Mirai(ELF)", r"C:\malware_work\Mirai\1075519b2d23eb91d403fc61768c82bf_JaffaCakes118"),
]

for name, path in samples:
    print("=" * 70)
    print(name)
    print("=" * 70)
    if not os.path.exists(path):
        print("[!] 不存在")
        continue
    with open(path, "rb") as f:
        data = f.read()
    print(f"大小: {len(data)}  MD5: {hashlib.md5(data).hexdigest()}")
    print(f"头部: {data[:16].hex()}")
    if data[:2] == b"MZ": print("PE")
    if data[:4] == b"\x7fELF": print("ELF")

    # 特征
    feats = []
    for kw in [b".NET", b"mscorlib", b"Delphi", b"UPX", b"NSIS", b"AutoIt",
               b"System.", b"Akira", b"BadRabbit", b"ransom", b"encrypt", b"decrypt",
               b"bitcoin", b"wallet", b".onion", b"Tor", b"tor", b"Mirai", b"bot",
               b"scan", b"telnet", b"ssh", b"cmd", b"shell"]:
        c = data.count(kw)
        if c > 0: feats.append(f"{kw.decode('ascii','replace')}x{c}")
    if feats: print("[特征] " + " ".join(feats))

    # URLs
    urls = set()
    for m in re.finditer(rb"https?://[\w\.\-:/?=&%_@#+~]{6,200}", data):
        u = m.group().decode("ascii", "replace")
        if any(x in u.lower() for x in ["microsoft", "digicert", "sectigo", "verisign",
                                          "usertrust", "comodo", "globalsign", "symantec",
                                          "schemas.", "w3.org", "adobe", "ibsensoftware"]):
            continue
        urls.add(u)
    if urls:
        print(f"[URLs]")
        for u in sorted(urls)[:10]: print(f"  {u[:180]}")

    # IPs
    ips = set()
    for m in re.finditer(rb"\b(?:\d{1,3}\.){3}\d{1,3}\b", data):
        t = m.group().decode("ascii")
        parts = t.split(".")
        if all(0 <= int(p) <= 255 for p in parts) and t not in ["0.0.0.0","6.0.0.0","1.0.0.0","127.0.0.1"]:
            ips.add(t)
    if ips and len(ips) < 30:
        print(f"[IPs] {', '.join(sorted(ips)[:15])}")

    # 关键字符串
    print("[关键字符串]")
    seen = set()
    cnt = 0
    for m in re.finditer(rb"[\x20-\x7e]{10,200}", data):
        t = m.group().decode("ascii", "replace")
        if t in seen: continue
        seen.add(t)
        tl = t.lower()
        if any(k in tl for k in ["onion", "ransom", "decrypt", "bitcoin", "wallet",
                                  "akira", "badrabbit", "mirai", "bot ", "c2", "exploit",
                                  "http", ".php", "readme", "recover"]):
            if 10 < len(t) < 200:
                print(f"  {t[:180]}")
                cnt += 1
                if cnt >= 15: break
    print()
