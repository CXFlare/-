# -*- coding: utf-8 -*-
"""XMRig + Azorult 脱壳后深度分析"""
import re, hashlib, os

samples = [
    ("XMRig_unpacked", r"C:\malware_work\XMRig\unpacked_upx\unpacked.exe"),
    ("Azorult_unpacked", r"C:\malware_work\Azorult\unpacked_upx\unpacked.exe"),
]

for name, path in samples:
    print("=" * 70)
    print(name)
    print("=" * 70)
    if not os.path.exists(path):
        print("[!] 不存在:", path)
        continue
    with open(path, "rb") as f:
        data = f.read()
    print(f"大小: {len(data)}  MD5: {hashlib.md5(data).hexdigest()}")
    print(f"头部: {data[:16].hex()}")

    # XMRig 关键特征
    print("[特征]")
    for kw in [b"xmrig", b"XMRig", b"stratum", b"tcp://", b"nicehash",
               b"donate", b"pool.", b"monero", b"cpu", b"miner",
               b"azure", b"Azorult", b"azorult", b"stealer",
               b"clipboard", b"keylog", b"browser", b"password",
               b"ftp", b"smtp", b"telegram", b"discord", b"bot",
               b"gate.php", b"panel", b"http://", b"https://"]:
        c = data.count(kw)
        if c > 0:
            print(f"  {kw.decode('ascii','replace'):<20} x{c}")

    # URL
    print()
    print("[URLs]")
    urls = set()
    for m in re.finditer(rb"https?://[\w\.\-:/?=&%_@#+~]{6,200}", data):
        u = m.group().decode("ascii", "replace")
        if any(x in u.lower() for x in ["microsoft", "digicert", "sectigo",
                                          "verisign", "usertrust", "comodo",
                                          "globalsign", "symantec", "schemas.",
                                          "w3.org", "adobe", "entrust",
                                          "thawte", "wosign", "cybertrust"]):
            continue
        urls.add(u)
    for u in sorted(urls)[:30]:
        print(f"  {u[:180]}")

    # IP
    print()
    print("[IPs]")
    ips = set()
    for m in re.finditer(rb"\b(?:\d{1,3}\.){3}\d{1,3}\b", data):
        t = m.group().decode("ascii")
        parts = t.split(".")
        if all(0 <= int(p) <= 255 for p in parts) and t not in ["0.0.0.0","6.0.0.0","1.0.0.0","127.0.0.1"]:
            ips.add(t)
    for ip in sorted(ips)[:20]:
        print(f"  {ip}")

    # XMR 钱包
    print()
    print("[XMR / 加密货币钱包]")
    for m in re.finditer(rb"\b4[0-9AB][1-9A-HJ-NP-Za-km-z]{93}\b", data):
        print(f"  XMR: {m.group().decode()}")
    for m in re.finditer(rb"\b(?:bc1|[13])[a-zA-HJ-NP-Z0-9]{25,62}\b", data):
        w = m.group().decode()
        if len(w) >= 26:
            print(f"  BTC: {w}")

    print()
