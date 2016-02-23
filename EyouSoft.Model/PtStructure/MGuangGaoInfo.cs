using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 广告信息业务实体
    /// <summary>
    /// 广告信息业务实体
    /// </summary>
    public class MGuangGaoInfo
    {
        /// <summary>
        /// 广告编号
        /// </summary>
        public string GuangGaoId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi WeiZhi { get; set; }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 广告图片(封面)
        /// </summary>
        public string Filepath { get; set; }
        /// <summary>
        /// 广告链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 广告内容
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
        /// 排序编号
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        public IList<MFuJianInfo> FuJians { get; set; }
        /// <summary>
        /// 广告状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus Status { get; set; }

        /// <summary>
        /// 详情页URL
        /// </summary>
        public string XXUrl
        {
            get
            {
                if (string.IsNullOrEmpty(Url))
                {
                    return "/xinxi/xinxixx.aspx?xinxiid=" + GuangGaoId;
                }

                return Url;
            }
        }
    }
    #endregion


    #region 广告信息查询实体
    /// <summary>
    /// 广告信息查询实体
    /// </summary>
    public class MGuangGaoChaXunInfo
    {
        /// <summary>
        /// 广告名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi? WeiZhi { get; set; }
        /// <summary>
        /// 广告状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus? Status { get; set; }
    }
    #endregion
}
