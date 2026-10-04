# -*- coding: utf-8 -*-
"""生成 Sigma 行为检测规则 + 整理产物到 work case"""
import os, shutil

sigma_rules = """title: NJRAT Registry Persistence via ShellServiceObjectDelayLoad
id: 4a1b2c3d-1111-2222-3333-aaaa11112222
status: experimental
description: 检测 NJRAT 通过 ShellServiceObjectDelayLoad 建立持久化
references:
    - https://github.com/cybersight/malware-samples
author: RE 工具
date: 2026/10/04
tags:
    - attack.persistence
    - attack.t1547.001
    - attack.t1112
logsource:
    category: registry_set
    product: windows
detection:
    selection:
        TargetObject|endswith:
            - '\\ShellServiceObjectDelayLoad\\'
            - '\\ShellServiceObjectDelayLoad'
        Details|re: '\{[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}\}'
    condition: selection
falsepositives:
    - 合法 Shell 扩展（罕见）
level: high

---

title: NJRAT IE Zone Registry Tampering
id: 4a1b2c3d-1111-2222-3333-aaaa11113333
status: experimental
description: 检测 NJRAT 篡改 IE 安全区域设置
logsource:
    category: registry_set
    product: windows
detection:
    selection:
        TargetObject|contains: '\\Internet Settings\\Zones\\'
        Details: '1601'
    condition: selection
level: medium

---

title: DarkComet MSConfig Startupreg Persistence
id: 4a1b2c3d-1111-2222-3333-bbbb11112222
status: experimental
description: 检测 DarkComet 通过 MSConfig startupreg 建立持久化
references:
    - https://github.com/cybersight/malware-samples
tags:
    - attack.persistence
    - attack.t1547.001
logsource:
    category: registry_set
    product: windows
detection:
    selection:
        TargetObject|contains:
            - '\\Microsoft\\Shared Tools\\MSConfig\\startupreg\\'
            - '\\Microsoft\\Shared Tools\\MSConfig\\startupfolder\\'
    condition: selection
level: high

---

title: Malware Sample Execution with -pinfected Archive Password
id: 4a1b2c3d-1111-2222-3333-cccc11112222
status: experimental
description: 检测通过 7za 解压 infected 密码保护的恶意软件样本
logsource:
    category: process_creation
    product: windows
detection:
    selection:
        CommandLine|contains:
            - '-pinfected'
            - '--password=infected'
    condition: selection
falsepositives:
    - 安全研究环境（预期）
level: informational

---

title: NJRAT C2 Communication via crutop.nu Cluster
id: 4a1b2c3d-1111-2222-3333-dddd11112222
status: experimental
description: 检测 NJRAT 与 crutop.nu 系 C2 通信
references:
    - https://github.com/cybersight/malware-samples
tags:
    - attack.command_and_control
    - attack.t1071
logsource:
    category: proxy
detection:
    selection:
        c-uri|endswith:
            - '/index.php'
            - '/index.htm'
        c-uri-host|contains:
            - 'crutop.nu'
            - 'crutop.ru'
            - 'mazafaka.ru'
            - 'color-bank.ru'
            - 'asechka.ru'
            - 'goldensand.ru'
            - 'filesearch.ru'
            - 'cvv.ru'
            - 'hackers.lv'
            - 'fethard.biz'
    condition: selection
level: critical

---

title: Pony Gate.php Beacon
id: 4a1b2c3d-1111-2222-3333-eeee11112222
status: experimental
description: 检测 Pony 银行木马 C2 通信
logsource:
    category: proxy
detection:
    selection:
        c-uri|contains:
            - 'don.service-master.eu/gate.php'
            - 'don.service-master.eu/shit.exe'
    condition: selection
level: critical

---

title: Akira Ransomware Note Drop
id: 4a1b2c3d-1111-2222-3333-ffff11112222
status: experimental
description: 检测 Akira 勒索软件投递勒索信
references:
    - https://github.com/cybersight/malware-samples
tags:
    - attack.impact
    - attack.t1486
logsource:
    category: file_event
    product: windows
detection:
    selection:
        TargetFilename|endswith: 'akira_readme.txt'
    condition: selection
level: critical

---

title: MonsterV2 Ransomware Onion Beacon
id: 4a1b2c3d-1111-2222-3333-aaaa44442222
status: experimental
description: 检测 MonsterV2 勒索软件连接 Tor 面板
logsource:
    category: proxy
detection:
    selection:
        c-uri-host|endswith: 'monste3rxfp2f7g3i.onion'
    condition: selection
level: critical

---

title: CoinHive Miner Execution via Browser Script
id: 4a1b2c3d-1111-2222-3333-bbbb44442222
status: experimental
description: 检测页面加载 CoinHive 挖矿脚本
logsource:
    category: proxy
detection:
    selection:
        c-uri|contains: 'coinhive.min.js'
    condition: selection
level: high

---

title: Mirai IoT Exploit Chain
id: 4a1b2c3d-1111-2222-3333-cccc44442222
status: experimental
description: 检测 Mirai 通过 ctrlt 接口利用 IoT 设备
logsource:
    category: webserver
detection:
    selection:
        cs-method: 'POST'
        cs-uri-stem|startswith: '/ctrlt/'
        cs-uri-stem|contains: 'DeviceUpgrade'
    condition: selection
level: critical

---

title: FakeAV Universal101 Download
id: 4a1b2c3d-1111-2222-3333-dddd44442222
status: experimental
description: 检测 FakeAV 通过 universal101.com 下载载荷
logsource:
    category: proxy
detection:
    selection:
        c-uri|contains:
            - 'universal101.com/upd.sc'
            - 'universal101.com/upd02.app'
            - 'gomyron.com'
    condition: selection
level: high

---

title: CobaltStrike S3 C2 Communication
id: 4a1b2c3d-1111-2222-3333-eeee44442222
status: experimental
description: 检测 CobaltStrike 通过 AWS S3 通信
logsource:
    category: proxy
detection:
    selection:
        c-uri-host|endswith: 's3.us-east-2.amazonaws.com'
        c-uri|contains: 'cumulodirifiuti'
    condition: selection
level: critical
"""

# 写到分析目录
dst = r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\iocs\malware-samples.sigma.yml"
with open(dst, "w", encoding="utf-8") as f:
    f.write(sigma_rules)
print(f"已写入 Sigma 规则: {dst}")
print(f"规则数: {sigma_rules.count('title:')} 条")

# 整理所有 IOC 相关文件到 work case 的 report 目录
work_report = r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\work\malware-samples-analysis\report"
os.makedirs(work_report, exist_ok=True)

copies = [
    (r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\REVERSE_REPORT.md", "REVERSE_REPORT.md"),
    (r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\iocs\NJRAT-iocs.md", "NJRAT-iocs.md"),
    (r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\iocs\malware-samples.yara", "malware-samples.yara"),
    (r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\iocs\malware-samples.sigma.yml", "malware-samples.sigma.yml"),
    (r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\ALL_SAMPLES_HASHES.csv", "ALL_SAMPLES_HASHES.csv"),
    (r"C:\Users\洛天依\Desktop\新建文件夹\逆向\恶俗样本\分析\zip-contents.csv", "zip-contents.csv"),
]

for src, name in copies:
    if os.path.exists(src):
        shutil.copy(src, os.path.join(work_report, name))
        print(f"复制: {name}")

print()
print("work case 产物:")
for f in os.listdir(work_report):
    print(f"  {f}")
