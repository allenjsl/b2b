//供应商联系人账号管理  汪奇志 2015-05-12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.ResourceManage
{
    /// <summary>
    /// 供应商联系人账号管理
    /// </summary>
    public partial class GysLxrYongHuEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 供应商编号
        /// </summary>
        string GysId = string.Empty;
        /// <summary>
        /// 账号-添加
        /// </summary>
        bool Privs_YongHu_TianJia = false;
        /// <summary>
        /// 账号-修改
        /// </summary>
        bool Privs_YongHu_XiuGai = false;
        /// <summary>
        /// 账号-删除
        /// </summary>
        bool Privs_YongHu_ShanChu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.RCWE("此功能已不可用");

            GysId = Utils.GetQueryStringValue("gysid");
            if (string.IsNullOrEmpty(GysId)) RCWE("异常请求");
            InitPrivs();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "baocun": BaoCun(); break;
                case "shanchu": ShanChu(); break;
                default: break;
            }

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_YongHu_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_账号新增);
            Privs_YongHu_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_账号修改);
            Privs_YongHu_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_账号删除);
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var info = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GetInfo(GysId);
            if (info == null) RCWE("异常请求");

            var items = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GetSupplierContactById(GysId);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            int txtLxrId = Utils.GetInt(Utils.GetFormValue("txtLxrId"));
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));

            if (txtYongHuId == 0)
            {
                if (!Privs_YongHu_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            if (txtYongHuId > 0)
            {
                if (!Privs_YongHu_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            string txtYongHuMing = Utils.GetFormValue("txtYongHuMing");
            string txtMiMa = Utils.GetFormValue("txtMiMa");
            string md5MiMa = string.Empty;

            if (!string.IsNullOrEmpty(txtMiMa))
            {
                var pwd = new EyouSoft.Model.CompanyStructure.PassWord();
                pwd.NoEncryptPassword = txtMiMa;
                md5MiMa = pwd.MD5Password;
            }

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GysLxrYongHu_CU(GysId, txtLxrId, txtYongHuId,SiteUserInfo.UserId, txtYongHuMing, txtMiMa, md5MiMa);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-97", "操作失败：已经存在的用户名"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// shanchu
        /// </summary>
        void ShanChu()
        {
            if (!Privs_YongHu_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int txtLxrId = Utils.GetInt(Utils.GetFormValue("txtLxrId"));
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanySupplier().GysLxrYonHu_D(GysId, txtLxrId, txtYongHuId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：已经存在相关交易信息，不可删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }
        #endregion

        #region private members
        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuoHtml(object yongHuId)
        {
            int _yongHuId = Utils.GetInt(yongHuId.ToString());
            string s = string.Empty;

            if (_yongHuId == 0 && Privs_YongHu_TianJia)
                s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
            if (_yongHuId > 0 && Privs_YongHu_XiuGai)
                s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
            if (Privs_YongHu_ShanChu)
                s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            return s;
        }
        #endregion
    }
}
