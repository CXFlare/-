# Cybersight Malware Samples - 全家族逆向分析报告

## 执行摘要

基于 reverse-skill v2 工作流，对 Cybersight Security Malware-Samples 仓库的 79 个恶意软件家族进行系统化逆向分析。

**分析范围**：79 家族 / 92 样本 / 44 编译与壳识别 / 8 深度逆向 / 28 条 Evidence

## 一、编译器和壳分布

| 编译器/壳 | 家族 |
|---|---|
| MSVC (VS2002-2017) | 20+ |
| .NET CLR | 12 |
| Delphi | 4 (DarkComet, Pony, FakeAV, Neshta) |
| UPX | 8+ (Vidar, XMRig, Azorult, WarzoneRAT) |
| NSIS | 5 (GULoader, Quasar, WarzoneRAT, 888RAT, GULoader) |
| AutoIt EA06 | 2 (888RAT, HawkEye) |
| VMProtect | 2 (TrickBot, LockBit) |
| MEW | 2 (Vidar, Quasar) |
| pkr_ce1a | 2 (StealC, Lumma) |
| ELF | 2 (Mirai, Gafgyt) |
| SmartAssembly | 1 (AgentTesla 内层) |

## 二、NJRAT 完整逆向

- MD5: b54802ccdd1ae31f129f6caabdb92f45
- 脱壳成功：从 1 个函数恢复到 188 函数
- 加密：两把 4 字节 XOR key (.text / .data 分别加密)
- key1 = 0x4F1E597C (.text, 0x401000-0x408F6C)
- key2 = 0x29C73795 (.data, 0x42B000-0x42E3D0)
- Builder 指纹：KingKarton_10
- C2 服务器：30 个 (crutop.nu / crutop.ru / mazafaka.ru 等)
- 关键能力：键盘记录 / 屏幕监控 / 网页注入 / 银行钓鱼 / 进程注入 / 持久化
- ATT&CK: T1059, T1071, T1095, T1105, T1112, T1129, T1547.001

## 三、AgentTesla 双阶段加载器

### 外层 (伪装)

- MD5: ef5c6625bdf2a53a6a4ca841cc5868df
- 伪装成 Panda Cafe 咖啡/蛋糕订餐 GUI
- 4 个 WinForms 界面：Cakes / Coffee / Sandwich / Form1

### 内层加载逻辑

- 从资源读取 ZH 加密载荷
- 22 字节 XOR key：548BHE35Z8SH7888GSBYD9
- 解密算法：out[i] = ((in[i] ^ key[i%22]) - in[(i+1)%n] + 256) & 0xFF
- Assembly.Load 反射加载
- GetTypes()[9] + Activator.CreateInstance 执行

### 内层 payload

- MD5: 53106229a87e970b8befe76d9118f647
- 保护器：SmartAssembly 7.3.0.3296
- 方法：254 (107 bodyless)
- 字符串加密：每字符串 XOR (32 位魔数分 4 通道)
- 嵌入资源 GUID：{07eefa3e-4bba-4508-ab41-20404168e31b}

## 四、其他深度分析

### DarkComet
- Delphi 编写 / DCMUTEX 互斥体
- 12 类远控命令 (TIVEREMOTESHELL / TLOGSHISTORY / TMONITORS)

### Pony
- C2：http://don.service-master.eu/gate.php
- 下载源：http://don.service-master.eu/shit.exe
- FTP/SMTP/IMAP/POP3 凭据窃取

### Akira 勒索
- ChaCha20 加密 (expand 32-byte k)
- Tor 面板：akiral2iz6a7qgd3ayp3l6yub7xx2uep76idk3u2kollpj5z3z636bad.onion
- 加密扩展名：.akira

### MonsterV2 勒索
- Delphi 编写 / Tor 面板：monste3rxfp2f7g3i.onion/gGj

### Mirai IoT 僵尸网络
- ELF 二进制 / C2：198.211.113.55
- 特征：POST /ctrlt/DeviceUpgrade_1 HTTP/1.1

### Gafgyt IoT 僵尸网络
- ELF / C2：185.244.25.211, 8.8.8.8

### BlackMoon (XiaoBa 挖矿 + 银行木马)
- CoinHive 挖矿：yuNWeGn9GWL72dONBX9WNEj1aVHxg49E
- 内嵌 PE @ 0x35828 + XOR 字符串解码 + API 哈希解析

### XMRig (挖矿)
- UPX 脱壳：1.5MB → 2.4MB
- 矿池：donate.v2.xmrig.com

### Azorult
- UPX 脱壳：7.6MB → 8.2MB

### Nanocore
- .NET CLR v2.0.50727 / 401 方法 (63 bodyless)
- 关键方法：AddHostEntry / RebuildHostCache / SendToServer / DisableProtection
- 使用 Socket / Rijndael / MD5

### Redline
- 内存 dump / 520KB / Chrome 浏览器凭据窃取

### WSHRAT
- 1.2MB 混淆 JS / 13978 条字符串数组
- 通过 PowerShell 下载后续载荷

### SnakeKeyLogger
- 伪装成 DVLD_Buisness (驾照管理系统)
- .NET CLR v4.0.30319 / 529 方法
- SQL 相关字符串 (Applications / DetainedLicenses / Drivers)

### GoldenEye
- JS 下载器 (374KB) + PE 载荷 (260KB)
- JS: ActiveXObject + Scripting.FileSystemObject

### BadRabbit
- VM 检测 (CPUID 0x40000000) + XOR 字符串解码

### FakeAV
- Delphi + UPX 壳
- URL：universal101.com/upd.sc / upd02.app / gomyron.com

### NotPetya
- BTC：1Mz7153HMuxXTuR2R1t78mGSdzaAtNbBWX
- 邮箱：wowsmith123456@posteo.net

### CobaltStrike
- C2：s3.us-east-2.amazonaws.com/cumulodirifiuti/pieghevole.zip
- IP：3.120.209.58

### Ploutus (ATM 恶意软件)
- .NET 编写 / ATM 相关 API 引用 29 次

### 888RAT
- AutoIt EA06 加密脚本 + NSIS 3.09 打包 / 40MB
- EA06 标记：0xd341c / 0x26626b7
- 非标准 LZMA，需专用工具 (myAut2Exe)

### Quasar
- NSIS + MEW 壳 / 19MB
- C# RAT / 提取出 19MB .NET payload

### PrivateLoader
- 13MB / MSVC VS2017
- C2：pdf-suite.com 系列 (14 URLs)
- BTC：3FKjC4EVzSSJzomNYA5w3fCoQzxz50MHw3

### WarzoneRAT
- 双层壳：UPX + ASPack

## 五、IOC 汇总

### 5.1 C2 / 服务器
```
NJRAT (30):  crutop.nu / crutop.ru / mazafaka.ru / color-bank.ru / asechka.ru
             trojan.ru / fuck.ru / goldensand.ru / filesearch.ru / devx.nm.ru
             ros-neftbank.ru / lovingod.host.sk / cvv.ru / hackers.lv / fethard.biz
             ldark.nm.ru / gaz-prom.ru / promo.ru / potleaf.chat.ru / kadet.ru
             xware.cjb.net / konfiskat.org / parex-bank.ru / kidos-bank.ru / kavkaz.ru
Pony:          don.service-master.eu
Imminent:      195.22.127.105
Mirai:         198.211.113.55
Gafgyt:        185.244.25.211
BlackMoon:     124.40.51.17 / 58.17.236.92 / 60.210.176.251
CobaltStrike:  3.120.209.58 / cumulodirifiuti/pieghevole.zip
Upatre:        94.23.247.202
FakeAV:        universal101.com / gomyron.com
PrivateLoader: pdf-suite.com (14 URLs)
```

### 5.2 加密货币钱包
```
NotPetya BTC:       1Mz7153HMuxXTuR2R1t78mGSdzaAtNbBWX
PrivateLoader BTC:  3FKjC4EVzSSJzomNYA5w3fCoQzxz50MHw3
BlackMoon CoinHive: yuNWeGn9GWL72dONBX9WNEj1aVHxg49E
```

### 5.3 注册表持久化
```
NJRAT:       ShellServiceObjectDelayLoad
             IE Setup/Setup -> Path
             .DEFAULT/.../Explorer/BrowseNewProcess
             Internet Settings/Zones/%u
DarkComet:   MSConfig/startupreg
             Windows NT/CurrentVersion/Winlogon
             CurrentVersion/Run
```

## 六、MITRE ATT&CK 映射

| Tactic | Technique | 样本 |
|---|---|---|
| Execution | T1059 命令行 | NJRAT / DarkComet / GoldenEye |
| Execution | T1106 原生 API | NJRAT / BadRabbit |
| Persistence | T1547.001 注册表 Run | NJRAT / DarkComet |
| Persistence | T1112 修改注册表 | NJRAT / DarkComet / BlackMoon |
| Defense Evasion | T1027 混淆文件 | NJRAT / BadRabbit / BlackMoon / AgentTesla |
| Defense Evasion | T1027.007 API 哈希 | BlackMoon |
| Defense Evasion | T1027.009 嵌入载荷 | NJRAT / BlackMoon / AgentTesla |
| Defense Evasion | T1055 进程注入 | NJRAT |
| Defense Evasion | T1497.001 VM 检测 | BadRabbit |
| Defense Evasion | T1497.002 反调试 | NJRAT / BlackMoon / FakeAV |
| Credential Access | T1056.001 键盘记录 | NJRAT / DarkComet / BlackMoon |
| Credential Access | T1555 浏览器凭据 | Pony / Redline / PrivateLoader |
| Collection | T1185 浏览器会话劫持 | NJRAT |
| Collection | T1113 屏幕捕获 | NJRAT / DarkComet |
| C2 | T1071 应用层协议 | 全部 RAT |
| C2 | T1573 加密信道 | Akira / CobaltStrike |
| Impact | T1486 数据加密 | Akira / MonsterV2 / LockBit / NotPetya / AvosLocker |
| Impact | T1496 资源劫持 | XMRig / BlackMoon |

## 七、Evidence 索引

| ID | 标题 |
|---|---|
| E-001 | NJRAT XOR 解密还原 188 函数 |
| E-002 | NJRAT .data 段提取 30 个 C2 |
| E-003 | 生成 15 YARA + 12 Sigma 规则 |
| E-004 | XMRig UPX 脱壳 (1.5MB->2.4MB) |
| E-005 | Azorult UPX 脱壳 (7.6MB->8.2MB) |
| E-006 | 888RAT NSIS+AutoIt EA06 识别 |
| E-007 | Mirai ELF C2 (198.211.113.55) |
| E-008 | Gafgyt ELF C2 (185.244.25.211) |
| E-009 | 888RAT AutoIt EA06 结构确认 |
| E-010 | Quasar NSIS+MEW 分析 |
| E-011 | XMRig donate.v2.xmrig.com 配置 |
| E-012 | PrivateLoader 13MB pdf-suite.com C2 |
| E-013 | Vidar memory dump 分析 |
| E-014 | Lumma/Raccoon/StealC pkr_ce1a 壳 |
| E-015 | WarzoneRAT UPX+ASPack 双层壳 |
| E-016 | Quasar NSIS 提取 19MB .NET payload |
| E-017 | AgentTesla PAGO.exe .NET CLR 确认 |
| E-018 | 888RAT EA06 非标准 LZMA |
| E-019 | Vidar 22K 字符串分析 |
| E-020 | AgentTesla 双阶段加载器反向 |
| E-021 | 提取 AgentTesla 隐藏 PE (67072 字节) |
| E-022 | AgentTesla XOR key 548BHE35Z8SH7888GSBYD9 |
| E-023 | AgentTesla 内层 SmartAssembly 7.3 |
| E-024 | AgentTesla payload 字符串 XOR + DEFLATE |
| E-025 | AgentTesla 嵌入资源 GUID |
| E-026 | Nanocore 401 方法反编译 |
| E-027 | SnakeKeyLogger 529 方法反编译 (伪装 DVLD) |
| E-028 | WSHRAT 1.2MB 混淆 / 13978 字符串数组 |

## 八、未完成事项

1. 888RAT EA06 脚本解密 (非标准 LZMA)
2. Quasar MEW 壳脱壳
3. TrickBot / LockBit VMProtect devirt
4. WarzoneRAT 双层壳 (UPX + ASPack)
5. AgentTesla SmartAssembly 字符串解密
6. PrivateLoader 13MB 深度拆分
7. Vidar / Lumma / Raccoon pkr_ce1a 壳

---

*本报告由 reverse-skill v2 工作流 + disrobe 0.10.6 生成*
*分析日期：2026-10-04*
