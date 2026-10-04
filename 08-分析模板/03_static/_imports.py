# -*- coding: utf-8 -*-
import struct

pe = r"C:\malware_work\NJRAT\njrat_decrypted.exe"
with open(pe, "rb") as f:
    data = f.read()

IMAGE_BASE = 0x400000

# 节表
sections = [
    (".text",  0x1000, 0x7F6C, 0x400, 0x7F6C),
    (".bss",   0x9000, 0x213B0, 0x0, 0x0),
    (".data",  0x2B000, 0x33D0, 0x8400, 0x33D0),
    (".idata", 0x2F000, 0xEA4, 0xB800, 0xEA4),
    (".fldo",  0x30000, 0x1000, 0xCA00, 0x200),
    (".l1",    0x31000, 0x1200, 0xCC00, 0x1200),
]

def rva_to_off(rva):
    for name, va, vs, raw, rs in sections:
        if va <= rva < va + max(vs, rs):
            return raw + (rva - va)
    return None

# PE 头
pe_off = struct.unpack("<I", data[0x3C:0x40])[0]
opt_off = pe_off + 24
magic = struct.unpack("<H", data[opt_off:opt_off+2])[0]
# PE32: 数据目录从 opt_off + 96 开始
dd_off = opt_off + (96 if magic == 0x10B else 112)

# 导入表（第 2 项，index 1）
imp_rva = struct.unpack("<I", data[dd_off+1*8:dd_off+1*8+4])[0]
imp_size = struct.unpack("<I", data[dd_off+1*8+4:dd_off+1*8+8])[0]
print(f"导入表 RVA=0x{imp_rva:X} 大小=0x{imp_size:X}")
print(f"文件偏移 = 0x{rva_to_off(imp_rva):X}")
print()

# 遍历导入描述符（每个 20 字节）
import_desc_off = rva_to_off(imp_rva)
i = 0
total_apis = 0
imports_by_dll = {}

while True:
    desc = import_desc_off + i * 20
    if desc + 20 > len(data): break
    original_first_thunk = struct.unpack("<I", data[desc:desc+4])[0]
    time_date = struct.unpack("<I", data[desc+4:desc+8])[0]
    forwarder = struct.unpack("<I", data[desc+8:desc+12])[0]
    name_rva = struct.unpack("<I", data[desc+12:desc+16])[0]
    first_thunk = struct.unpack("<I", data[desc+16:desc+20])[0]

    if original_first_thunk == 0 and first_thunk == 0 and name_rva == 0:
        break

    # DLL 名
    dll_off = rva_to_off(name_rva)
    if dll_off is None: break
    dll_end = data.find(b"\x00", dll_off)
    dll = data[dll_off:dll_end].decode("ascii", "replace")

    # 遍历 thunk
    thunk_rva = original_first_thunk if original_first_thunk else first_thunk
    thunk_off = rva_to_off(thunk_rva)
    apis = []
    j = 0
    while thunk_off is not None:
        t = thunk_off + j * 4
        if t + 4 > len(data): break
        val = struct.unpack("<I", data[t:t+4])[0]
        if val == 0: break
        if val & 0x80000000:
            apis.append(f"#{val & 0x7FFFFFFF}")
        else:
            hint_off = rva_to_off(val)
            if hint_off:
                end = data.find(b"\x00", hint_off + 2)
                apis.append(data[hint_off+2:end].decode("ascii", "replace"))
        j += 1

    imports_by_dll[dll] = apis
    total_apis += len(apis)
    i += 1

print(f"共 {len(imports_by_dll)} 个 DLL，{total_apis} 个 API")
print()
print("=" * 70)
for dll, apis in sorted(imports_by_dll.items()):
    print(f"\n### {dll} ({len(apis)}) ###")
    for a in sorted(apis):
        print(f"  {a}")
