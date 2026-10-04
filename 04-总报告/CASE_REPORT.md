# Case Report — malware-samples-analysis

## 案件信息

| 字段 | 值 |
|---|---|
| Case ID | malware-samples-analysis |
| 创建时间 | 2026-10-04T17:24:33 |
| 完成时间 | 2026-10-04T18:00:00 |
| PRIMARY skill | malware-analysis/SKILL.md (R9) |
| auth.status | granted |
| network_profile.mode | offline |
| 分析工具 | disrobe 0.10.6 / Python 3.12.9 / 7za 23.01 / UPX 4.2.4 |

## 一、案件目标

分析 Cybersight Security Malware-Samples 仓库中的 111 个恶意软件样本（79 个家族），提取 IOC、识别壳与编译器、深度逆向重点样本，生成 YARA/Sigma 规则。

## 二、分析结果汇总

### 2.1 样本总体

- 已解压家族：79
- 已哈希样本文件：92
- 已识别编译/壳：44
- 完全深度逆向：3（NJRAT, DarkComet, Pony）
- 部分深度分析：35+

### 2.2 编译器和壳分布

| 壳/编译器 | 家族数 | 代表样本 |
|---|---|---|
| MSVC VS2008-2017 | 20+ | Sodinokibi, Amadey, PrivateLoader, ZGRat |
| .NET CLR | 10+ | XWorm, AgentTesla, Redline, Nanocore, Ploutus, AvosLocker |
| Delphi | 4 | DarkComet, Pony, FakeAV, Neshta |
| UPX | 8+ | Vidar, XMRig, Azorult, WarzoneRAT |
| NSIS | 5 | GULoader, Quasar, WarzoneRAT, 888RAT |
| AutoIt EA06 | 2 | 888RAT, HawkEye |
| VMProtect | 2 | TrickBot, LockBit |
| MEW | 2 | Vidar, Quasar |
| pkr_ce1a | 2 | StealC, Lumma |
| ELF | 2 | Mirai, Gafgyt |

### 2.3 重点样本深度逆向

#### NJRAT（完全逆向）
- 运行时 XOR 自解密（2 把 key）
- 188 函数完整反汇编
- 30 个 C2 URL
- KingKarton_10 builder 指纹
- 银行钓鱼 + 网页注入 + 进程注入

#### DarkComet
- Delphi 编写
- DCMUTEX 互斥体
- 12 类远控命令

#### Pony
- C2: don.service-master.eu/gate.php
- FTP/SMTP/IMAP/POP3 凭据窃取

#### XMRig
- UPX 脱壳成功（1.5MB → 2.4MB）
- 含矿池配置

#### Azorult
- UPX 脱壳成功（7.6MB → 8.2MB）

## 三、IOC 汇总

### 3.1 C2 / 服务器（30+ 个）

NJRAT 集群（crutop.nu / crutop.ru / mazafaka.ru 等 30 个）+
Pony: don.service-master.eu +
Imminent: 195.22.127.105 +
Mirai: 198.211.113.55 +
Gafgyt: 185.244.25.211 +
BlackMoon: 124.40.51.17, 58.17.236.92, 60.210.176.251 +
CobaltStrike: 3.120.209.58 / cumulodirifiuti/pieghevole.zip +
Upatre: 94.23.247.202 +
FakeAV: universal101.com, gomyron.com

### 3.2 加密货币

- NotPetya BTC: 1Mz7153HMuxXTuR2R1t78mGSdzaAtNbBWX
- PrivateLoader BTC: 3FKjC4EVzSSJzomNYA5w3fCoQzxz50MHw3
- BlackMoon CoinHive: yuNWeGn9GWL72dONBX9WNEj1aVHxg49E

### 3.3 落地文件

- NJRAT: kk32.dll, kk32.vxd, dnkk.dll, surf.dat, cmd.pif, command.pif
- DarkComet: DCMUTEX

## 四、Evidence 列表

| ID | 标题 |
|---|---|
| E-001 | NJRAT XOR 解密还原 188 函数 |
| E-002 | NJRAT .data 段提取 30 个 C2 URL |
| E-003 | 生成 15 YARA + 12 Sigma 规则 |
| E-004 | XMRig UPX 脱壳（1.5MB → 2.4MB）|
| E-005 | Azorult UPX 脱壳（7.6MB → 8.2MB）|
| E-006 | 888RAT NSIS+AutoIt EA06 识别（key seed 0x73ffa84d）|
| E-007 | Mirai ELF C2（198.211.113.55）|
| E-008 | Gafgyt ELF C2（185.244.25.211）|

## 五、产物清单

```
work/malware-samples-analysis/
├── scope.md
├── timeline.md
├── workitems.md
├── README.md
├── evidence/
│   ├── E-001.md
│   ├── E-002.md
│   ├── E-003.md
│   ├── E-004.md
│   ├── E-005.md
│   ├── E-006.md
│   ├── E-007.md
│   └── E-008.md
└── report/
    ├── REVERSE_REPORT.md
    ├── malware-samples.yara
    ├── malware-samples.sigma.yml
    ├── ALL_SAMPLES_HASHES.csv
    └── zip-contents.csv
```

## 六、未完成事项

1. 888RAT EA06 脚本解密（需 myAut2Exe 或定制算法）
2. Quasar MEW 壳脱壳
3. TrickBot / LockBit VMProtect devirt
4. WarzoneRAT 双层壳（UPX + ASPack）
5. PrivateLoader 13MB 深度分析
6. Vidar / Lumma 定制壳

## 七、安全声明

- 所有分析均在离线静态环境进行
- 样本未连接任何真实 C2
- 样本仅在副本上操作
- 未在宿主机执行样本

---

*本报告由 reverse-skill 工作流生成*