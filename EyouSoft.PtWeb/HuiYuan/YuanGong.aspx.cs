//员工管理 汪奇志 2014-09-04
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
    /// 员工管理
    /// </summary>
    public partial class YuanGong : HuiYuanYeMian
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "shanchu") ShanChu();

            InitYuanGong();
        }

        #region private members
        /// <summary>
        /// init yuangong
        /// </summary>
        void InitYuanGong()
        {
            int recordCount=0;
            pageIndex = UtilsCommons.GetPagingIndex();
            var chaXun = new EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo();
            var items = new EyouSoft.BLL.CompanyStructure.CompanyUser().PT_GetYuanGongs(SysCompanyId, YongHuInfo.KeHuId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptYuanGong.DataSource = items;
                rptYuanGong.DataBind();
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
            string txtKeHuId = Utils.GetFormValue("txtKeHuId");
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));
            int txtKeHuLxrId = Utils.GetInt(Utils.GetFormValue("txtKeHuLxrId"));

            if (txtKeHuId != YongHuInfo.KeHuId) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));

            if (txtYongHuId == YongHuInfo.YongHuId) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：不能删除自己的账号"));

            int bllRetCode = 0;
            bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().PT_YuanGong_D(SysCompanyId, YongHuInfo.KeHuId, txtYongHuId, txtKeHuLxrId);

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：您不能删除该员工信息")); 
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo
        /// </summary>
        /// <param name="keHuLxrStatus"></param>
        /// <returns></returns>
        protected string GetCaoZuo(object keHuLxrStatus)
        {
            string s = string.Empty;
            var _keHuLxrStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus)keHuLxrStatus;

            switch (_keHuLxrStatus)
            {
                case EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除:
                    s = "<a href=\"javascript:void(0)\" class=\"xiugai\" data-chakan=\"1\">查看</a>";
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改不可删除:
                    s = "<a href=\"javascript:void(0)\" class=\"xiugai\">修改</a>";
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改可删除:
                    s = "<a href=\"javascript:void(0)\" class=\"xiugai\">修改</a>&nbsp;<a href=\"javascript:void(0)\" class=\"shanchu\">删除</a>";
                    break;
            }

            return s;
        }
        #endregion
    }
}
