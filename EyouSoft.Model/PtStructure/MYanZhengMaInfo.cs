//汪奇志 2014-09-15 平台验证码相关
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 验证码信息业务实体
    /// <summary>
    /// 验证码信息业务实体
    /// </summary>
    public class MYanZhengMaInfo
    {
        /// <summary>
        /// 验证码编号
        /// </summary>
        public string YanZhengMaId { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string YanZhengMa { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing LeiXing { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus Status { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 状态(OUTPUT)，已做时间判断
        /// </summary>
        public EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus Status1
        {
            get
            {
                if (Status == EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.有效)
                {
                    if (this.IssueTime.AddMinutes(30) < DateTime.Now) return EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.已过期;

                    return Status;
                }

                return Status;
            }
        }
    }
    #endregion
}
