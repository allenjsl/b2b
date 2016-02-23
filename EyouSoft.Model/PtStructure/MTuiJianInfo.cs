using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 平台推荐信息业务实体
    /// <summary>
    /// 平台推荐信息业务实体
    /// </summary>
    public class MTuiJianInfo
    {
        /// <summary>
        /// 推荐编号
        /// </summary>
        public string TuiJianId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 推荐标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 推荐内容
        /// </summary>
        public string NeiRong { get; set; }
        /// <summary>
        /// 推荐封面
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
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 简要介绍
        /// </summary>
        public string JianYaoJieShao { get; set; }
        /// <summary>
        /// 推荐状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.TuiJianStatus Status { get; set; }

        /// <summary>
        /// 详情页URL
        /// </summary>
        public string XXUrl
        {
            get
            {
                return "/tuijian/tuijianxx.aspx?tuijianid=" + this.TuiJianId;
            }
        }
    }
    #endregion


    #region 平台推荐信息查询实体
    /// <summary>
    /// 平台推荐信息查询实体
    /// </summary>
    public class MTuiJianChaXunInfo
    {
        /// <summary>
        /// 推荐标题
        /// </summary>
        public string BiaoTi { get; set; }
        /// <summary>
        /// 发布时间-起
        /// </summary>
        public DateTime? ShiJian1 { get; set; }
        /// <summary>
        /// 发布时间-止
        /// </summary>
        public DateTime? ShiJian2 { get; set; }
        /// <summary>
        /// 推荐状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.TuiJianStatus? Status { get; set; }
    }
    #endregion
}
