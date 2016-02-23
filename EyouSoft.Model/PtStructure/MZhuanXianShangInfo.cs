using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 专线商信息业务实体
    /// <summary>
    /// 专线商信息业务实体
    /// </summary>
    public class MZhuanXianShangInfo
    {
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string ZhuCeHao { get; set; }
        /// <summary>
        /// 税务号
        /// </summary>
        public string ShuiWuHao { get; set; }
        /// <summary>
        /// 许可证号
        /// </summary>
        public string XuKeZhengHao { get; set; }
        /// <summary>
        /// 公司法人
        /// </summary>
        public string FaRenName { get; set; }
        /// <summary>
        /// 联系人
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
        /// 联系人QQ
        /// </summary>
        public string LxrQQ { get; set; }
        /// <summary>
        /// 专线商公司传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string DiZhi { get; set; }
        /// <summary>
        /// 公司logo
        /// </summary>
        public string Logo { get; set; }        
        /// <summary>
        /// 联系方式
        /// </summary>
        public string LianXiFangShi { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string YinHangZhangHao { get; set; }
        /// <summary>
        /// 公司介绍
        /// </summary>
        public string JieShao { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus Status { get; set; }
        /// <summary>
        /// 积分发放状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus JiFenStatus { get; set; }
        /// <summary>
        /// 一级栏目
        /// </summary>
        public string Privs1 { get; set; }
        /// <summary>
        /// 二样栏目
        /// </summary>
        public string Privs2 { get; set; }
        /// <summary>
        /// 明细权限
        /// </summary>
        public string Privs3 { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 站点、专线类别信息集合
        /// </summary>
        public IList<MZhuanXianShangZhanDianInfo> ZhanDians { get; set; }
        /// <summary>
        /// QQ集合
        /// </summary>
        public IList<MZhuanXianShangQQInfo> QQs { get; set; }
        /// <summary>
        /// T1
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZxsT1 T1 { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string GuanLiYuanUsername { get; set; }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public EyouSoft.Model.CompanyStructure.PassWord GuanLiYuanPassword { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// zxs t2
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZxsT2 T2 { get; set; }
    }
    #endregion

    #region 专线商站点、专线类别信息业务实体
    /// <summary>
    /// 专线商站点、专线类别信息业务实体
    /// </summary>
    public class MZhuanXianShangZhanDianInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
    }
    #endregion

    #region 专线商QQ信息
    /// <summary>
    /// 专线商QQ信息
    /// </summary>
    public class MZhuanXianShangQQInfo
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string MiaoShu { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
    }
    #endregion

    #region 专线商积分结算信息业务实体
    /// <summary>
    /// 专线商积分结算信息业务实体
    /// </summary>
    public class MFinJiFenJieSuanInfo
    {
        /// <summary>
        /// 结算编号
        /// </summary>
        public string JieSuanId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime JieSuanRiQi { get; set; }
        /// <summary>
        /// 结算人姓名
        /// </summary>
        public string JieSuanRenName { get; set; }
        /// <summary>
        /// 结算积分
        /// </summary>
        public int JiFen { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 收款方式
        /// </summary>
        public EnumType.FinStructure.ShouFuKuanFangShi JieSuanFangShi { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        public string JieSuanZhangHao { get; set; }
        /// <summary>
        /// 结算备注
        /// </summary>
        public string JieSuanBeiZhu { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public EnumType.FinStructure.KuanXiangStatus Status { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 审批人编号
        /// </summary>
        public int? ShenPiRenId { get; set; }
        /// <summary>
        /// 审批备注
        /// </summary>
        public string ShenPiBeiZhu { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime? ShenPiShiJian { get; set; }
    }
    #endregion

    #region 专线商信息业务实体
    /// <summary>
    /// 专线商信息业务实体
    /// </summary>
    public class MZxsInfo
    {
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string MingCheng { get; set; }
    }
    #endregion


    #region 专线商查询实体
    /// <summary>
    /// 专线商查询实体
    /// </summary>
    public class MZhuanXianShangChaXunInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int? ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int? ZxlbId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 专线商状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus? ZxsStatus { get; set; }
        /// <summary>
        /// zxs t2
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZxsT2? T2 { get; set; }
    }
    #endregion

    #region AJAX自动完成专线商信息业务实体
    /// <summary>
    /// AJAX自动完成专线商信息业务实体
    /// </summary>
    public class MAjaxAutocompleteZxsInfo
    {
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
    }
    #endregion

    #region 专线商Autocomplete查询实体
    /// <summary>
    /// AJAX自动完成专线商信息查询业务实体
    /// </summary>
    public class MAjaxAutocompleteZxsChaXunInfo
    {
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }

        int _TopExpression = 15;
        /// <summary>
        /// top expression
        /// </summary>
        public int TopExpression
        {
            get { return _TopExpression; }
            set { _TopExpression = value; }
        }
    }
    #endregion
}
