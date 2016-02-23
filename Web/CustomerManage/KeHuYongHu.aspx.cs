using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.CustomerManage
{
    public partial class KeHuYongHu : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        /// <summary>
        /// 管理权限
        /// </summary>
        bool Privs_GuanLi = false;
        protected int pageIndex = 0;
        protected int pageSize = 20;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "shezhiyonghustatus") SheZhiYongHuStatus();

            InitYongHu();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户账号管理_栏目);
            Privs_GuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户账号管理_账号管理);

            if (!Privs_LanMu) Utils.RCWE(UtilsCommons.AjaxReturnJson("-1000", "没有权限"));
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo();
            info.KeHuName = Utils.GetQueryStringValue("txtKeHuname");
            info.YongHuMing = Utils.GetQueryStringValue("txtYongHuMing");
            info.YongHuXingMing = Utils.GetQueryStringValue("txtYongHuXingMing");
            info.YongHuStatus = (EyouSoft.Model.EnumType.CompanyStructure.UserStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.UserStatus), Utils.GetQueryStringValue("txtYongHuStatus"));
            return info;
        }

        /// <summary>
        /// init yonghu
        /// </summary>
        void InitYongHu()
        {
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();

            var items = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetKeHuYongHus(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptYongHu.DataSource = items;
                rptYongHu.DataBind();

                FenYe.intPageSize = pageSize;
                FenYe.CurrencyPage = pageIndex;
                FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// shezhi yonghu status
        /// </summary>
        void SheZhiYongHuStatus()
        {
            if (!Privs_GuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string txtFS = Utils.GetFormValue("txtFS");
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));

            var yongHuStatus = EyouSoft.Model.EnumType.CompanyStructure.UserStatus.正常;
            if (txtFS == "jinyong") yongHuStatus = EyouSoft.Model.EnumType.CompanyStructure.UserStatus.已停用;

            var bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().SetEnable(txtYongHuId, yongHuStatus);
            if (bllRetCode) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetCaoZuo(object status)
        {
            var _status = (EyouSoft.Model.EnumType.CompanyStructure.UserStatus)status;

            if (_status == EyouSoft.Model.EnumType.CompanyStructure.UserStatus.正常)
            {
                return "<a href=\"javascript:void(0)\" data-fs=\"jinyong\" class=\"shezhistatus\">禁用</a>";
            }

            return "<a href=\"javascript:void(0)\" data-fs=\"qiyong\" class=\"shezhistatus\">启用</a>";
        }
        #endregion
    }
}
