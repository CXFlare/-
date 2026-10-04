# -*- coding: utf-8 -*-
"""批量深挖 - Redline / WarzoneRAT / Nanocore / WSHRAT / Amadey / Sodinokibi"""
import hashlib, re, os

samples = [
    ("Redline", r"C:\malware_work\Redline\4900-2-0x0000000000AB0000-0x0000000000B2EFAE-memory.dmp"),
    ("WarzoneRAT", r"C:\malware_work\WarzoneRAT\0fe23bfe4a1aff6b6e079d8a0c942d5b_JaffaCakes118"),
    ("Nanocore", r"C:\malware_work\Nanocore\DiscordNSR.exe"),
    ("WSHRAT", r"C:\malware_work\WSHRAT\test.JS"),
    ("Amadey", r"C:\malware_work\Amadey\662119ffeb5cc0951c36e30f2f2f9c537349292775ef4a4b26a6ec219ea9db95"),
    ("Sodinokibi", r"C:\malware_work\Sodinokibi\0f8ee1ed415794ec053dca928a409436_JaffaCakes118"),
    ("SmokeLoader", r"C:\malware_work\SmokeLoader\f9be6fbe073f8e75344c62adff1a729494acafa18ea7c778cd0b3177a77de0f3"),
    ("SnakeKeyLogger", r"C:\malware_work\SnakeKeyLogger\FATURA VE BELGELER..exe"),
]

for name, path in samples:
    print("=" * 70)
    print(name)
    print("=" * 70)
    if not os.path.exists(path):
        print("[!] 不存在")
        continue
    try:
        with open(path, "rb") as f:
            data = f.read()
    except Exception as e:
        print(f"[!] 读取失败: {e}")
        continue
    print(f"大小: {len(data)}  MD5: {hashlib.md5(data).hexdigest()}")

    # 通用特征
    feats = []
    for kw in [b".NET", b"mscorlib", b"Delphi", b"UPX", b"NSIS", b"AutoIt",
               b"MSVBVM60", b"SmartAssembly", b"ConfuserEx", b"VMProtect",
               b"System.", b"cmd.exe", b"keylog", b"stealer", b"browser",
               b"clipboard", b"Chrome", b"Firefox", b"Outlook",
               b"wallet", b"password", b"XMR", b"stratum",
               b"ransom", b"encrypt", b"decrypt", b"readme",
               b"telegram", b"discord", b"gate", b"c2"]:
        c = data.count(kw)
        if c > 0: feats.append(f"{kw.decode('ascii','replace')}x{c}")
    if feats: print("[特征] " + " ".join(feats[:15]))

    # 关键 URL
    urls = set()
    for m in re.finditer(rb"https?://[\w\.\-:/?=&%_@#+~]{8,200}", data):
        u = m.group().decode("ascii", "replace")
        if any(x in u.lower() for x in ["microsoft", "digicert", "sectigo",
                                          "verisign", "usertrust", "comodo",
                                          "globalsign", "symantec", "schemas",
                                          "w3.org", "adobe", "entrust",
                                          "thawte", "wosign", "cybertrust",
                                          "startssl", "crl", "ocsp"]):
            continue
        urls.add(u)
    if urls:
        print("[URLs]")
        for u in sorted(urls)[:8]:
            print(f"  {u[:180]}")

    # IP
    ips = set()
    for m in re.finditer(rb"\b(?:\d{1,3}\.){3}\d{1,3}\b", data):
        t = m.group().decode("ascii")
        parts = t.split(".")
        if all(0 <= int(p) <= 255 for p in parts) and t not in ["0.0.0.0","6.0.0.0","1.0.0.0","127.0.0.1","255.255.255.255"]:
            ips.add(t)
    if ips and len(ips) < 20:
        print(f"[IPs] {', '.join(sorted(ips)[:10])}")

    # TG Bot
    for m in re.finditer(rb"\d{8,12}:[A-Za-z0-9_\-]{30,45}", data):
        print(f"  TG: {m.group().decode()}")
        break

    print()
