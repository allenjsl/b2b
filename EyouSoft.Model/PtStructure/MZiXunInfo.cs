using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 平台资讯信息业务实体
    /// <summary>
    /// 平台资讯信息业务实体
    /// </summary>
    public class MZiXunInfo
    {
        /// <summary>
        /// 资讯编号
        /// </summary>
        public string ZiXunId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 资讯类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing LeiXing { get; set; }
        /// <summary>
        /// 资讯标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 资讯内容
        /// </summary>
        public string NeiRong { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 操作员姓名（OUTPUT）
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 简要介绍
        /// </summary>
        public string JianYaoJieShao { get; set; }
        /// <summary>
        /// 资讯封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 站点名称（OUTPUT）
        /// </summary>
        public string ZhanDianName { get; set; }
        /// <summary>
        /// 资讯状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZiXunStatus Status { get; set; }

        /// <summary>
        /// 详情页URL
        /// </summary>
        public string XXUrl
        {
            get
            {
                return "/zixun/zixunxx.aspx?zixunid=" + this.ZiXunId;
            }
        }
    }
    #endregion


    #region 平台资讯信息查询实体
    /// <summary>
    /// 平台资讯信息查询实体
    /// </summary>
    public class MZiXunChaXunInfo
    {
        /// <summary>
        /// 发布时间-起
        /// </summary>
        public DateTime? ShiJian1 { get; set; }
        /// <summary>
        /// 发布时间-止
        /// </summary>
        public DateTime? ShiJian2 { get; set; }
        /// <summary>
        /// 资讯标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 资讯类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing? LeiXing { get; set; }
        /// <summary>
        /// 资讯状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.ZiXunStatus? Status { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int? ZhanDianId { get; set; }
    }
    #endregion
}
