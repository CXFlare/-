# -*- coding: utf-8 -*-
"""AgentTesla payload - 全部方法的签名和主要操作"""
import re

p = r"C:\malware_work\AgentTesla\payload_decompiled\hidden_payload_full.native.cs"
with open(p, "r", encoding="utf-8", errors="replace") as f:
    content = f.read()

lines = content.split("\n")
print(f"总行数: {len(lines)}")

# 提取所有类名
classes = set()
for line in lines:
    m = re.match(r"\s*(?:public|private|internal|protected)?\s*(?:abstract|sealed)?\s*(?:class|struct|interface)\s+([A-Za-z_][\w]*)", line)
    if m: classes.add(m.group(1))

print(f"\n类 ({len(classes)})")
for c in sorted(classes): print(f"  {c}")

# 提取所有方法名
methods = set()
for line in lines:
    m = re.match(r"\s*(?:public|private|internal|protected|static|virtual|override|sealed)?[\s\w<>\[\],\.]*\([^)]*\)\s*\{", line)
    if m:
        name = m.group(0).split("(")[0].strip()
        methods.add(name)

print(f"\n方法数: {len(methods)}")

# 找敏感关键词
print()
print("[敏感调用/字符串]")
kws = ["Send", "Mail", "Smtp", "Http", "Web", "Ftp", "Download",
       "Upload", "GetAsyncKeyState", "Clipboard", "Screen", "Capture",
       "Webcam", "Camera", "Password", "Browser", "Chrome", "Firefox",
       "Outlook", "Registry", "Process", "Assembly.Load",
       "Activator.CreateInstance", "Compile", "Eval"]
for kw in kws:
    cnt = content.count(kw)
    if cnt > 0:
        print(f"  {kw}: x{cnt}")

# 找所有字符串字面量
literals = re.findall(r'"([^"\\]*(?:\\.[^"\\]*)*)"', content)
print(f"\n字符串字面量: {len(literals)}")
seen = set()
for lit in literals:
    if lit and len(lit) >= 5 and lit not in seen:
        seen.add(lit)
        if any(k in lit.lower() for k in ["http", "smtp", "ftp", "telegram",
                                             "bot", "password", "chrome",
                                             "firefox", "outlook", "keylog",
                                             "agent", "tesla", "stealer"]):
            print(f"  {lit[:150]}")

# 打印所有方法的原始签名
print()
print("[所有方法签名（前 60）]")
seen_sig = set()
for i, line in enumerate(lines):
    m = re.match(r"\s*(?:public|private|internal|protected|static|virtual|override|sealed|abstract)?[\s\w<>\[\],\.]*\([^)]*\)\s*(?:\{|;)$", line.rstrip())
    if m:
        sig = line.strip()
        if sig not in seen_sig:
            seen_sig.add(sig)
            print(f"  L{i+1}: {sig[:150]}")
            if len(seen_sig) > 60: break
