//汪奇志 2014-08-22 平台促销信息相关业务实体
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 平台促销信息业务实体
    /// <summary>
    /// 平台促销信息业务实体
    /// </summary>
    public class MCuXiaoInfo
    {
        /// <summary>
        /// 促销编号
        /// </summary>
        public string CuXiaoId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 促销标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 促销内容
        /// </summary>
        public string NeiRong { get; set; }
        /// <summary>
        /// 促销封面
        /// </summary>
        public string FengMian { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime ShiJian1 { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime ShiJian2 { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 简要介绍
        /// </summary>
        public string JianYaoJieShao { get; set; }
        /// <summary>
        /// 促销状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus Status { get; set; }

        /// <summary>
        /// 详情页URL
        /// </summary>
        public string XXUrl
        {
            get
            {
                return "/cuxiao/cuxiaoxx.aspx?cuxiaoid=" + this.CuXiaoId;
            }
        }
    }
    #endregion

    #region 平台促销信息查询业务实体
    /// <summary>
    /// 平台促销信息查询业务实体
    /// </summary>
    public class MCuXiaoChaXunInfo
    {
        /// <summary>
        /// 促销标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 发布日期-起
        /// </summary>
        public DateTime? ShiJian1 { get; set; }
        /// <summary>
        /// 发布日期-止
        /// </summary>
        public DateTime? ShiJian2 { get; set; }
        /// <summary>
        /// 促销状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus? Status { get; set; }
    }
    #endregion
}
