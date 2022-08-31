# university

北美校园行发行的NFT相关智能合约

## 使用说明：

* 部署合约
  
  `deploy UNIV.nef`

* 在每一站开始前，管理员初始化这所大学的NFT

  调用方法
  `Initialize(string university)`

* 学生现场下载OneGate进入到指定的页面（开发中）

  调用方法
  `MintUniv(string university) `

  合约会自动创建一个NFT，发送给合约调用者，编号递增（1~100)

* 查询每所学校NFT领取数量

  调用合约
  `TotalMint(string university)`

## NFT 属性

| 名称      | 说明 | 示例 |
| ----------- | ----------- | ----------- |
| name      | 名称       | Tsinghua University #1       |
| owner   | 所有者        | NSuyiLqEfEQZsLJawCbmXW154StRUwdWoM        |
| numbwr   | 编号        | 1        |
| image   | 图片        | https://neo.org/Tsinghua University.png        |
