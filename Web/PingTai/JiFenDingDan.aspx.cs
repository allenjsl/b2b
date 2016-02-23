using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    /// <summary>
    /// 积分兑换订单管理
    /// </summary>
    public partial class JiFenDingDan : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        /// <summary>
        /// 订单管理权限
        /// </summary>
        bool Privs_DingDanGuanLi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "shanchu") ShanChu();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_DingDanGuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换订单管理_订单管理);
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiFenDingDanChaXunInfo();

            info.JiaoYiHao = Utils.GetQueryStringValue("txtDingDanHao");
            info.ShangPinBianMa = Utils.GetQueryStringValue("txtShangPinBianMa");
            info.ShangPinLeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing), Utils.GetQueryStringValue("txtLeiXing"));
            info.ShangPinMingCheng = Utils.GetQueryStringValue("txtShangPinMingCheng");
            info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus), Utils.GetQueryStringValue("txtDingDanStatus"));
            info.XiaDanShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanShiJian1"));
            info.XiaDanShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanShiJian2"));
            info.FuKuanStatus = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus), Utils.GetQueryStringValue("txtFuKuanStatus"));
            
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
            var items = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDans(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

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
        /// shan chu
        /// </summary>
        void ShanChu()
        {
            /*
            if (!Privs_DingDanGuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string dingDanId = Utils.GetFormValue("txtDingDanId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().DeleteDingDan(CurrentUserCompanyID, dingDanId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));*/
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            string s = string.Empty;

            if (Privs_DingDanGuanLi) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">管理</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            //if (Privs_DingDanGuanLi) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";
            return s.ToString();
        }

        /// <summary>
        /// get fukuan status
        /// </summary>
        /// <param name="fuKuanStatus"></param>
        /// <returns></returns>
        protected string GetFuKuanStatus(object fuKuanStatus)
        {
            var _fuKuanStatus = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)fuKuanStatus;
            if (_fuKuanStatus == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批) return "未支付";
            return "已支付";
        }
        #endregion
    }
}