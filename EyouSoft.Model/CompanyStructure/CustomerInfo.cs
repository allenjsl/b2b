using System;
using System.Collections.Generic;
namespace EyouSoft.Model.CompanyStructure
{
    #region 客户资料信息业务实体
    /// <summary>
    /// 客户资料
    /// </summary>
    [Serializable]
    public class CustomerInfo
    {
        private bool _isEnable = true;

        /// <summary>
        /// 客户编号
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ProviceId { set; get; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { set; get; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { set; get; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { set; get; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public EnumType.CompanyStructure.CustomerType Type { set; get; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 许可证
        /// </summary>
        public string Licence { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Adress { set; get; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostalCode { set; get; }

        /// <summary>
        /// 合作协议附件
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 责任销售编号
        /// </summary>
        public int SaleId { set; get; }
        /// <summary>
        /// 责任销售
        /// </summary>
        public string Saler { set; get; }
        /// <summary>
        /// 所属公司
        /// </summary>
        public int CompanyId { set; get; }
        /// <summary>
        /// 是否启用 1:启用  0:停用
        /// </summary>
        public bool IsEnable { set { this._isEnable = value; } get { return this._isEnable; } }
        /// <summary>
        /// 主要联系人姓名
        /// </summary>
        public string ContactName { set; get; }
        /// <summary>
        /// 主要联系人电话
        /// </summary>
        public string Phone { set; get; }
        /// <summary>
        /// 主要联系人手机
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 主要联系人传真
        /// </summary>
        public string Fax { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 添加人
        /// </summary>
        public int OperatorId { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { set; get; }
        /// <summary>
        /// 联系人
        /// </summary>
        public IList<CustomerContactInfo> CustomerContact { set; get; }
        /// <summary>
        /// 客户银行账户信息
        /// </summary>
        public IList<CustomerBank> CustomerBank { get; set; }
        /// <summary>
        /// 附件信息集合
        /// </summary>
        public IList<CompanyFile> Annexs { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan LaiYuan { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus ShenHeStatus { get; set; }
        /// <summary>
        /// 审核人编号
        /// </summary>
        public int ShenHeOperatorId { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime ShenHeTime { get; set; }
        /// <summary>
        /// 营业执照号
        /// </summary>
        public string YingYeZhiZhaoHao { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public string FaRenName { get; set; }
        /// <summary>
        /// 主要联系人QQ
        /// </summary>
        public string LxrQQ { get; set; }
        /// <summary>
        /// 主要联系人邮箱
        /// </summary>
        public string LxrEmail { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string GongSiDianHua { get; set; }
        /// <summary>
        /// 公司传真
        /// </summary>
        public string GongSiFax { get; set; }
        /// <summary>
        /// 简码
        /// </summary>
        public string JianMa { get; set; }
        /// <summary>
        /// 公司logo
        /// </summary>
        public string LogoFilepath { get; set; }
        /// <summary>
        /// 公司介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 单据打印模板
        /// </summary>
        public string DanJuDaYinMoBan { get; set; }
    }

    #endregion

    #region  客户联系人
    /// <summary>
    /// 客户联系人
    /// </summary>
    [Serializable]
    public class CustomerContactInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartId { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public EnumType.CompanyStructure.Sex Sex { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 联系人QQ
        /// </summary>
        public string qq { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        public string Spetialty { get; set; }
        /// <summary>
        /// 爱好
        /// </summary>
        public string Hobby { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 联系人状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus Status { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 用户名(OUTPUT)
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiXinHao { get; set; }
    }

    #endregion

    #region 客户银行账户实体

    /// <summary>
    /// 客户银行账户实体
    /// </summary>
    public class CustomerBank : CompanyAccountBase
    {
        /// <summary>
        /// 客户账户编号
        /// </summary>
        public string CustomerId { get; set; }
    }

    #endregion

    #region 客户资料查询信息业务实体
    /// <summary>
    /// 客户资料查询信息业务实体
    /// </summary>
    /// Author:汪奇志 2011-04-18
    public class MCustomerSeachInfo
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTelephone { get; set; }
        /// <summary>
        /// 联系手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 城市编号集合
        /// </summary>
        public int[] CityIdList { get; set; }

        /// <summary>
        /// 省份编号集合
        /// </summary>
        public int[] ProvinceIds { get; set; }

        /// <summary>
        /// 责任销售姓名
        /// </summary>
        public string SellerName { get; set; }
        /// <summary>
        /// 责任销售编号集合
        /// </summary>
        public int[] SellerIds { get; set; }
        /// <summary>
        /// 排序方式 0/1 添加时间升/降序 2:客户名称升序 3:客户名称降序
        /// </summary>
        public int OrderByType { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.CustomerType? KeHuLeiXing { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan? LaiYuan { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus? ShenHeStatus { get; set; }
        /// <summary>
        /// 注册时间-起
        /// </summary>
        public DateTime? ZhuCeShiJian1 { get; set; }
        /// <summary>
        /// 注册时间-止
        /// </summary>
        public DateTime? ZhuCeShiJian2 { get; set; }
    }

    #endregion

    #region 客户注册信息业务实体
    /// <summary>
    /// 客户注册信息业务实体
    /// </summary>
    public class MKeHuZhuCeInfo
    {
        /// <summary>
        /// 系统公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 客户所在省份编号
        /// </summary>
        public int KeHuShengFenId { get; set; }
        /// <summary>
        /// 客户所在城市编号
        /// </summary>
        public int KeHuChengShiId { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string KeHuDiZhi { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string KeHuDianHua { get; set; }
        /// <summary>
        /// 客户传真
        /// </summary>
        public string KeHuFax { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string YongHuYouXiang { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string YongHuXingMing { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string YongHuDianHua { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        public string YongHuShouJi { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string YongHuMiMa { get; set; }
        /// <summary>
        /// 用户密码MD5
        /// </summary>
        public string YongHuMiMaMd5 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus ShenHeStatus { get { return EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.未审核; } }
        /// <summary>
        /// 客户来源
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan LaiYuan { get { return EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.平台注册; } }
        /// <summary>
        /// 客户类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.CustomerType LeiXing { get { return EyouSoft.Model.EnumType.CompanyStructure.CustomerType.同行客户; } }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime ZhuCeShiJian { get; set; }
        /// <summary>
        /// 联系人状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus KeHuLxrStatus { get { return EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除; } }
    }
    #endregion
}


