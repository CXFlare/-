# M-02：XOR 解密通用方法

## 触发条件
样本用 XOR 加密了 .text / .data 段或内嵌载荷。

## 识别特征
- 段熵值 > 7.0
- 反汇编只识别出 1 个函数或明显很少
- 入口点在非标准段（如 .fldo / .l1）
- 有 pusha / popa 加密 stub

## 步骤

### 1. 定位解密 stub
```asm
pusha                    ; 保存寄存器
mov eax, <起始地址>
push <步长>
pop edi
mov ebx, <结束地址>
mov esi, <key>           ; 4 字节 key 硬编码
xor [eax], esi           ; 循环 XOR
add eax, edi
loop ...
popa
jmp <解密后入口>
```

### 2. 提取 key
看 `mov esi, [立即数]` → 得到 key
有时有多把 key，按段分别处理

### 3. 解密脚本
```python
def xor_decrypt(data, rva_start, rva_end, key, step=4):
    key_bytes = struct.pack('<I', key)
    result = bytearray()
    for i in range(rva_start, rva_end, step):
        for k in range(step):
            result.append(data[i+k] ^ key_bytes[k])
    return bytes(result)
```

### 4. 写回 PE
```python
patched = bytearray(orig_data)
patched[off_start:off_start+len(decrypted)] = decrypted
with open('decrypted.exe', 'wb') as f:
    f.write(patched)
```

### 5. 验证 + 重新反汇编
- 检查解密后是否 MZ + PE 头
- 用 disrobe disasm 重新反汇编
- 正常函数数量从 1 → 100+

## 本次实例：NJRAT
- key1 = 0x4F1E597C（.text）
- key2 = 0x29C73795（.data）
- 解密后：1 函数 → 188 函数

## 常见坑
1. 步长不是 4
2. key 是 4 字节循环
3. 地址是 VA 不是 RVA，需要减 ImageBase
4. 多把 key 混合