# M-04：UPX 脱壳通用流程

## 触发条件
样本识别为 packer=UPX。

## 步骤

### 1. 确认
```
upx.exe -t sample.exe
```

### 2. 直接脱壳
```
upx.exe -d sample.exe -o unpacked.exe
```

### 3. UPX 失败时
- 可能是修改版 UPX（改了 magic）
- 用 disrobe native unpack
```
disrobe native unpack <sample>
```

### 4. 双层壳
- UPX 里套 ASPack / NSIS
- disrobe native unpack 分层处理
- 或手工 dump 内存

## 本次实例
- XMRig：UPX 4.2.4 直接脱，1.5MB → 2.4MB
- Azorult：UPX 脱壳，7.6MB → 8.2MB
- WarzoneRAT：UPX + ASPack 双层，UPX 失败

## 常见坑
1. UPX 版本不匹配
2. 修改过的 UPX（magic 被改）
3. ASPacK + UPX 双层
4. VMProtect 伪装成 UPX