//兑换订单 汪奇志 2014-09-11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 兑换订单
    /// </summary>
    public partial class JiFenDingDan : HuiYuanYeMian
    {
        #region attbiutes
        protected int pageSize = 20;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitDingDan();
        }

        #region private members
        /// <summary>
        /// init dingdan
        /// </summary>
        void InitDingDan()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            var items = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDans(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptDingDan.DataSource = items;
                rptDingDan.DataBind();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo();

            info.JiaoYiHao = Utils.GetQueryStringValue("txtJiaoYiHao");
            info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus), Utils.GetQueryStringValue("txtDingDanStatus"));
            info.XiaDanShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanShiJian1"));
            info.XiaDanShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanShiJian2"));
            info.XiaDanRenId = YongHuInfo.YongHuId;

            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuo(object dingDanId,object dingDanStatus)
        {
            string chaKan = "<a class=\"caozuo-btn\" href=\"jifendingdanxx.aspx?dingdanid={0}\">查看</a>&nbsp;";
            string quXiao = "<a class=\"caozuo-btn\" href=\"jifendingdanxx.aspx?dingdanid={0}\">取消</a>&nbsp;";
            string s = string.Empty;

            var _dingDanStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus)dingDanStatus;

            switch (_dingDanStatus)
            {
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认:
                    s = string.Format(chaKan, dingDanId) + string.Format(quXiao, dingDanId);
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货:
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已取消:
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已确认:
                    s = string.Format(chaKan, dingDanId);
                    break;
                default: break;
            }

            return s;
        }

        /// <summary>
        /// get jifen dingdan status
        /// </summary>
        /// <param name="dingDanStatus"></param>
        /// <returns></returns>
        protected string GetJiFenDingDanStatus(object dingDanStatus)
        {
            string s = "<b style=\"color:{0}\">" + dingDanStatus + "</b>";
            var _dingDanStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus)dingDanStatus;

            switch (_dingDanStatus)
            {
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认:
                    s = "未确认";
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货:
                    s = string.Format(s, "#2f2f2f");
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已取消:
                    s = string.Format(s, "#999");
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已确认:
                    s = string.Format(s, "#2f2f2f");
                    break;
            }

            return s;
        }
        #endregion
    }
}
