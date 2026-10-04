# -*- coding: utf-8 -*-
import os, hashlib, csv

root = r"C:\malware_work"
rows = []

for name in sorted(os.listdir(root)):
    d = os.path.join(root, name)
    if not os.path.isdir(d): continue
    if name in ["_proxy"]: continue
    for f in os.listdir(d):
        fp = os.path.join(d, f)
        if not os.path.isfile(fp): continue
        try:
            sz = os.path.getsize(fp)
            if sz < 100: continue
            with open(fp, "rb") as fh:
                h = hashlib.sha256()
                while True:
                    blk = fh.read(65536)
                    if not blk: break
                    h.update(blk)
            rows.append({
                "family": name,
                "filename": f,
                "size": sz,
                "sha256": h.hexdigest(),
            })
        except: pass

out = r"C:\malware_work\ALL_SAMPLES_HASHES.csv"
with open(out, "w", newline="", encoding="utf-8") as f:
    w = csv.DictWriter(f, fieldnames=["family", "filename", "size", "sha256"])
    w.writeheader()
    for r in rows:
        w.writerow(r)

print(f"共 {len(rows)} 个样本哈希写入 {out}")
print()
for r in rows[:20]:
    print(f"  {r['family']:<20} {r['sha256'][:24]}... {r['size']}")

# 统计
from collections import Counter
c = Counter(r["family"] for r in rows)
print()
print(f"共 {len(c)} 个家族")
