# M-06：YARA 规则自动化生成

## 步骤

### 1. 每个家族提取 5-8 个稳定特征
优先级：
1. 家族名本身
2. 互斥体名
3. C2 域名
4. 硬编码 URL 路径
5. 注册表键
6. 独特类名 / 方法名
7. 加密 key

### 2. 模板化生成
```
rule {family}_Family {
    meta:
        family = '{family}'
        sample_md5 = '{md5}'
    strings:
        $s0 = '{sig0}' ascii wide
    condition:
        uint16(0) == 0x5A4D and 2 of them
}
```

### 3. ELF 单独处理
ELF 用 `uint32(0) == 0x464C457F` 判断

### 4. 验证规则
用 yara 命令扫描样本目录，每规则至少命中 1 个

## 本次实例
- 49 条 YARA 覆盖 49 家族
- 输出：03-YARA-Sigma规则/yara-full-79-families.yar

## 常见坑
1. 条件太严会漏变种（用 2 of them 更稳）
2. ascii wide 都用
3. 转义反斜杠
4. 单家族不超 10 条特征