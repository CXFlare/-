# 样本分析模板包

按阶段组织，可直接复用。

## 目录结构
```
01_triage/     # 分流：批量哈希 + IOC 提取
02_unpack/     # 脱壳：XOR / UPX / .NET / AutoIt
03_static/     # 静态：导入表、API、字符串、方法
04_ioc/        # IOC：URL / IP / 域名 / 加密货币 / 注册表
05_report/     # 报告：YARA / Sigma / STIX / MISP / 综合
99_custom/     # 一次性任务
```

## 用法
1. 把样本放到 `samples/` 目录
2. 依次运行阶段脚本
3. 产物写入 `output/`

## 依赖
- Python 3.12
- disrobe 0.10.6
- 7za 23.01
- UPX 4.2.4
