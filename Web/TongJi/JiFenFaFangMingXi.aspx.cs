using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.TongJi
{
    /// <summary>
    /// 统计分析-积分发放明细表
    /// </summary>
    public partial class JiFenFaFangMingXi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        protected string KeHuLxrId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分发放明细表_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiChaXunInfo();

            info.JiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenStatus), Utils.GetQueryStringValue("txtJiFenStatus"));
            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.ZxsId = CurrentZxsId;

            info.JiFenShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtJiFenShiJian1"));
            info.JiFenShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtJiFenShiJian2"));


            info.KeHuId=txtKeHu.KeHuId = Utils.GetQueryStringValue(txtKeHu.KeHuIdClientName);
            info.KeHuName=txtKeHu.KeHuMingCheng = Utils.GetQueryStringValue(txtKeHu.KeHuMingChengClientName);

            KeHuLxrId = Utils.GetQueryStringValue("txtKeHuLxrId");
            info.KeHuLxrId = Utils.GetIntNull(KeHuLxrId);

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            object[] heJi;
            var items = new EyouSoft.BLL.TongJiStructure.BJiFen().GetJiFenFaFangMingXis(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun,out heJi);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                ltrJiFenHeJi.Text = heJi[0].ToString();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
                phHeJi.Visible = false;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get routename
        /// </summary>
        /// <param name="routeName"></param>
        /// <param name="yeWuLeiXing"></param>
        /// <returns></returns>
        protected string GetRouteName(object routeName, object yeWuLeiXing)
        {
            if (routeName == null && yeWuLeiXing == null) return string.Empty;

            if (routeName == null) return yeWuLeiXing.ToString();

            string _routeName = routeName.ToString();

            if (!string.IsNullOrEmpty(_routeName)) return _routeName;

            return yeWuLeiXing.ToString();
        }

        /// <summary>
        /// get jifen status
        /// </summary>
        /// <param name="jiFenStatus"></param>
        /// <returns></returns>
        protected string GetJiFenStatus(object jiFenStatus)
        {
            var _jiFenStatus = (EyouSoft.Model.EnumType.PtStructure.JiFenStatus)jiFenStatus;

            string s = "<b style=\"color:{0}\">" + jiFenStatus + "</b>";

            switch (_jiFenStatus)
            {
                case EyouSoft.Model.EnumType.PtStructure.JiFenStatus.冻结:
                    s = string.Format(s, "#ff0000");
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenStatus.取消:
                    s = string.Format(s, "#999");
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenStatus.有效:
                    s = string.Format(s, "#2f2f2f");
                    break;
                default:
                    s = string.Empty;
                    break;
            }

            return s;
        }
        #endregion
    }
}