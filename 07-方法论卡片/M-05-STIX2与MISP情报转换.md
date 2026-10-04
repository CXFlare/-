# M-05：STIX 2.1 与 MISP 情报格式转换

## 触发条件
逆向分析得到 IOC 列表，需要输出为标准化情报格式给 TIP / SIEM。

## STIX 2.1 核心对象
| 对象 | 用途 |
|---|---|
| identity | 分析者身份 |
| malware | 恶意软件家族 |
| file | 样本（含哈希）|
| indicator | 单个 IOC（含 pattern）|
| relationship | indicator → indicates → malware |

## 步骤（STIX）

### 1. ID 生成（确定性）
```python
def sid(s):
    return str(uuid.uuid5(uuid.NAMESPACE_DNS, 'malware-analysis-' + s))
```

### 2-5. 构造对象 + Bundle 打包
```json
{
  "type": "bundle",
  "id": "bundle--<uuid>",
  "spec_version": "2.1",
  "objects": [...]
}
```

## MISP 格式
```json
{
  "Event": {
    "info": "Malware Family: NJRAT",
    "Attribute": [
      {"type": "url", "value": "...", "category": "Network activity", "to_ids": true}
    ]
  }
}
```

## 本次产物
- 03-YARA-Sigma规则/malware-samples.stix2.json（1143 个对象）
- 03-YARA-Sigma规则/malware-samples.misp.json（38 events / 609 attributes）

## 常见坑
1. pattern 里的引号要转义
2. ID 必须稳定（用 UUID5）
3. MISP 分类要对（Network activity / Payload delivery）
4. STIX 2.1 必须包含 spec_version