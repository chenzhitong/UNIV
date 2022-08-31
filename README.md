# university

北美校园行发行的NFT相关智能合约

## 使用说明：

* 部署合约
  
  `deploy UNIV.nef`

* 在每一站开始前，管理员初始化这所大学的NFT

  调用方法
  `initialize(string university)`

* 学生现场下载OneGate进入到指定的页面（开发中）

  调用方法
  `mintUniv(string university) `

  合约会自动创建一个NFT，发送给合约调用者，编号递增（1~100)

* 查询每所学校NFT领取数量

  调用合约
  `totalMint(string university)`

## NFT 属性

| 名称      | 说明 | 示例 |
| ----------- | ----------- | ----------- |
| name      | 名称       | Tsinghua University #1       |
| owner   | 所有者        | NSuyiLqEfEQZsLJawCbmXW154StRUwdWoM        |
| numbwr   | 编号        | 1        |
| image   | 图片        | https://neo.org/Tsinghua University.png        |

## 常见错误

> mintUniv 时报错 The argument "university" is invalid.

用户填写了一个不存在的大学，可能是随便写的，也可能是在管理员进行初始化之前mintUniv

> mintUniv 时报错 The school's NFTs have all been claimed.

每所学校NFT限量100个，领完为止，先到先得


