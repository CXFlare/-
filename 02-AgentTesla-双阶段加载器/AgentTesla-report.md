# AgentTesla 双阶段加载器 - 完整逆向报告

## 1. 概述

AgentTesla 是一种 .NET 信息窃取木马，本样本采用双阶段加载器技术。

## 2. 样本信息

| 字段 | 值 |
|---|---|
| 外层样本 | PAGO.exe (784,904 字节) |
| 外层 MD5 | ef5c6625bdf2a53a6a4ca841cc5868df |
| 外层类型 | .NET CLR v4.0.30319 (NetFramework4) |
| 伪装 | Panda Cafe 咖啡/蛋糕订餐程序 |
| 内层载荷 | hidden_payload_full.exe (67,072 字节) |
| 内层 MD5 | 53106229a87e970b8befe76d9118f647 |
| 内层类型 | .NET CLR v2.0.50727 (NetFramework2) |
| 内层保护 | SmartAssembly 7.3.0.3296 |

## 3. 加载流程

1. 用户运行 PAGO.exe → 弹出 Panda Cafe 咖啡/蛋糕界面
2. Form1.InitializeComponent() 被调用
3. 从 .NET 资源读取 ZH 隐藏字节数组
4. 用 22 字节硬编码 key XOR + 减法解密
5. 得到完整 .NET PE 程序集
6. Assembly.Load(payload) 加载到内存
7. 取 GetTypes()[9] 第 10 个类型
8. Activator.CreateInstance(type, args) 执行

## 4. 解密算法

```csharp
local1 = (byte[])local0.GetObject("ZH");  // 读加密载荷
local2 = new List<byte> {
    53,52,56,66,72,69,51,53,90,56,83,72,
    55,56,56,56,71,83,66,89,68,57
};  // 22 字节密钥
for (int i = 0; i < n; i++) {
    byte a = local1[i];
    byte b = local1[(i+1) % n];
    byte k = local2[i % 22];
    local1[i] = (byte)(((a ^ k) - b + 256) & 0xFF);
}
```

### 解密密钥

| 类型 | 值 |
|---|---|
| ASCII | 548BHE35Z8SH7888GSBYD9 |
| 长度 | 22 字节 |
| 用法 | XOR + 减法混合，向后引用 |

### 静态构造参数

```
ZZH = "576B5155&6E7464".Split('&');
// ZZH[0] = 576B5155  (十六进制)
// ZZH[1] = 6E7464    (十六进制)
```

## 5. 内层载荷分析

### 5.1 SmartAssembly 混淆特征

- 保护器：SmartAssembly 7.3.0.3296
- 字符串加密：每字符串 XOR（32 位魔数分 4 通道）
- 资源压缩：mode 0x01 使用 {z} 头 + chunked DEFLATE
- 嵌入程序集：使用 GUID {07eefa3e-4bba-4508-ab41-20404168e31b} (mode 0x02)
- 水印：SmartAssembly.Attributes, PoweredByAttribute

### 5.2 反编译统计

| 项目 | 值 |
|---|---|
| 方法数 | 254 |
| bodyless 方法 | 107 |
| 可重命名标识符 | 158 |
| 可读标识符 | 690 |
| 总字符串 | 848 |
| 混淆字符串 | 158 |
| #US 字面量 | 22 |

### 5.3 关键类

| 类名 | 用途 |
|---|---|
| SmartAssembly.AssemblyResolver | 动态加载程序集 |
| SmartAssembly.ResourceResolver | 动态解密资源 |
| SmartAssembly.StringsEncoding.Strings | 字符串解密 |
| SmartAssembly.Zip.SimpleZip | 压缩数据解压 |
| SmartAssembly.HouseOfCards | 反调试 |
| SmartAssembly.Delegates | 委托调用 |

### 5.4 关键 API 调用

| API | 用途 |
|---|---|
| CurrentDomain.add_AssemblyResolve | 注册程序集解析器 |
| Assembly.Load(byte[]) | 内存加载 |
| AssemblyBuilder.DefineDynamicAssembly | 动态生成程序集 |
| System.Reflection.Emit.MethodBuilder | 动态方法 |
| System.IO.Compression | 解压 |

## 6. IOC

### 6.1 文件哈希

```
PAGO.exe                 MD5: ef5c6625bdf2a53a6a4ca841cc5868df
hidden_payload_full.exe  MD5: 53106229a87e970b8befe76d9118f647
```

### 6.2 XOR 解密密钥

```
548BHE35Z8SH7888GSBYD9
```

### 6.3 静态构造参数

```
576B5155&6E7464
```

## 7. MITRE ATT&CK 映射

| Tactic | Technique | 证据 |
|---|---|---|
| Defense Evasion | T1027 混淆 | SmartAssembly |
| Defense Evasion | T1027.009 嵌入载荷 | ZH 资源 + Assembly.Load |
| Defense Evasion | T1140 解密/解码 | XOR + 减法 |
| Execution | T1059.005 | .NET 反射执行 |
| Credential Access | T1555 浏览器凭据 | 内层窃密模块 |

## 8. YARA 检测规则

```yara
rule AgentTesla_PandaCafe_Loader {
    meta:
        description = "AgentTesla 双阶段加载器（Panda Cafe 伪装）"
        author = "RE 工具"
        date = "2026-10-04"
    strings:
        $s1 = "Panda Cafe" ascii
        $s2 = "Order your coffee" ascii
        $s3 = "PandaCafe" ascii
        $s4 = "548BHE35Z8SH7888GSBYD9" ascii
        $s5 = "576B5155" ascii
        $s6 = "6E7464" ascii
    condition:
        uint16(0) == 0x5A4D and
        (2 of ($s1, $s2, $s3) or 2 of ($s4, $s5, $s6))
}
```

## 9. 结论

AgentTesla 样本使用高度伪装的 Panda Cafe 用户界面作为诱饵，利用双阶段加载器（XOR + 减法加密 + Assembly.Load 反射加载）绕过静态检测。内层 payload 使用 SmartAssembly 7.3 专业保护。

完整字符串/资源还原需要：
1. 运行时脱壳（隔离虚拟机）
2. 专用 SmartAssembly 解密工具（如 de4dot）
3. 动态调试提取运行时解密后的字符串

---

*本报告由逆向分析工具生成*
