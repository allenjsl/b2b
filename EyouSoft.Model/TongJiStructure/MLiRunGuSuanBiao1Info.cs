//利润估算表一信息业务实体 汪奇志 2014-10-27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TongJiStructure
{
    /// <summary>
    /// 利润估算表一信息业务实体
    /// </summary>
    public class MLiRunGuSuanBiao1Info
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 结算收入金额
        /// </summary>
        public decimal JieSuanShouRuJinE { get; set; }
        /// <summary>
        /// 结算支出金额
        /// </summary>
        public decimal JieSuanZhiChuJinE { get; set; }
        /// <summary>
        /// 营业外收入金额
        /// </summary>
        public decimal YingYeWaiShouRuJinE { get; set; }
        /// <summary>
        /// 报销金额
        /// </summary>
        public decimal BaoXiaoJinE { get; set; }
        /// <summary>
        /// 工资金额
        /// </summary>
        public decimal GongZiJinE { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public decimal LiRun
        {
            get
            {
                return JieSuanShouRuJinE - JieSuanZhiChuJinE + YingYeWaiShouRuJinE - BaoXiaoJinE - GongZiJinE;
            }
        }

        /// <summary>
        /// 结算毛利金额
        /// </summary>
        public decimal JieSuanMaoLiJinE
        {
            get { return JieSuanShouRuJinE - JieSuanZhiChuJinE; }
        }
    }
}
