//供应商主体信息相关业务实体 汪奇志 2015-05-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.GysStructure
{
    #region 供应商主体信息业务实体
    /// <summary>
    /// 供应商主体信息业务实体
    /// </summary>
    public class MGysZhuTiInfo
    {
        /// <summary>
        /// 供应商主体编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.SupplierType LeiXing { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 主专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 供应商主体名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int ChengShiId { get; set; }
        /// <summary>
        /// 供应商介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int CaoZuoRenId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LxrShouJi { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string DiZhi { get; set; }
        /// <summary>
        /// 联系传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 供应商关系集合
        /// </summary>
        public IList<MGysZhuTiGuanXiInfo> GuanXis { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ShengFenName { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string ChengShiName { get; set; }
    }
    #endregion

    #region 供应商主体信息查询业务实体
    /// <summary>
    /// 供应商主体信息查询业务实体
    /// </summary>
    public class MGysZhuTiChaXunInfo
    {
        /// <summary>
        /// 供应商主体名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int? ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int? ChengShiId { get; set; }
        /// <summary>
        /// 主体类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.SupplierType? LeiXing { get; set; }
    }
    #endregion

    #region 供应商主体联系人信息业务实体
    /// <summary>
    /// 供应商主体联系人信息业务实体
    /// </summary>
    public class MGysZhuTiLxrInfo
    {
        /// <summary>
        /// 联系人编号
        /// </summary>
        public int LxrId { get; set; }
        /// <summary>
        /// 供应商主体编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LxrShouJi { get; set; }
        /// <summary>
        /// 联系人传真
        /// </summary>
        public string LxrFax { get; set; }
        /// <summary>
        /// 联系人部门
        /// </summary>
        public string LxrBuMen { get; set; }
        /// <summary>
        /// 联系人职务
        /// </summary>
        public string LxrZhiWu { get; set; }
        /// <summary>
        /// 联系人QQ
        /// </summary>
        public string LxrQQ { get; set; }
        /// <summary>
        /// 联系人微信
        /// </summary>
        public string LxrWeiXin { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int CaoZuoRenId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 明文密码
        /// </summary>
        public string MiMa { get; set; }
        /// <summary>
        /// MD5密码
        /// </summary>
        public string Md5MiMa { get; set; }

        /// <summary>
        /// 供应商主体名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 账号状态
        /// </summary>
        public EnumType.CompanyStructure.UserStatus Status { get; set; }
    }
    #endregion

    #region 供应商主体关系信息业务实体
    /// <summary>
    /// 供应商主体关系信息业务实体
    /// </summary>
    public class MGysZhuTiGuanXiInfo
    {
        /// <summary>
        /// 供应商（资源）编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商（资源）名称
        /// </summary>
        public string GysName { get; set; }
    }
    #endregion

    #region 选用供应商信息业务实体
    /// <summary>
    /// 选用供应商信息业务实体
    /// </summary>
    public class MXuanYongGysInfo
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.SupplierType LeiXing { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int ChengShiId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LxrShouJi { get; set; }
        /// <summary>
        /// 联系传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ShengFenName { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string ChengShiName { get; set; }
        /// <summary>
        /// 供应商主体编号（已被该供应商主体关联）
        /// </summary>
        public string GysZhuTiId { get; set; }
    }
    #endregion

    #region 选用供应商信息查询业务实体
    /// <summary>
    /// 选用供应商信息查询业务实体
    /// </summary>
    public class MXuanYongGysChaXunInfo
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int? ShengFenId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int? ChengShiId { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.SupplierType? LeiXing { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region 供应商主体导游信息业务实体
    /// <summary>
    /// 供应商主体导游信息业务实体
    /// </summary>
    public class MGysZhuTiDaoYouInfo
    {
        /// <summary>
        /// 导游姓名
        /// </summary>
        public string DaoYouName { get; set; }
    }
    #endregion 

    #region 供应商主体导游信息查询业务实体
    /// <summary>
    /// 供应商主体导游信息查询业务实体
    /// </summary>
    public class MGysZhuTiDaoYouChaXunInfo
    {
        /// <summary>
        /// 供应商主体编号(地接社平台使用，专线商平台使用时赋string.Empty)
        /// </summary>
        public string GysZhuTiId { get; set; }
        /// <summary>
        /// 导游姓名
        /// </summary>
        public string DaoYouName { get; set; }
        /// <summary>
        /// 供应商编号（专线商平台使用，地接社平台使用时赋string.Empty）
        /// </summary>
        public string GysId { get; set; }
    }
    #endregion 
}
