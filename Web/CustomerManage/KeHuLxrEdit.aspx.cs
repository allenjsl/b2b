//客户联系人管理 汪奇志 2014-10-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.CustomerManage
{
    /// <summary>
    /// 客户联系人管理
    /// </summary>
    public partial class KeHuLxrEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 客户编号
        /// </summary>
        string KeHuId = string.Empty;
        /// <summary>
        /// 联系人-添加
        /// </summary>
        bool Privs_Lxr_TianJia = false;
        /// <summary>
        /// 联系人-修改
        /// </summary>
        bool Privs_Lxr_XiuGai = false;
        /// <summary>
        /// 联系人-删除
        /// </summary>
        bool Privs_Lxr_ShanChu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            KeHuId = Utils.GetQueryStringValue("kehuid");
            if (string.IsNullOrEmpty(KeHuId)) RCWE("异常请求");
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
            Privs_Lxr_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户管理_联系人新增);
            Privs_Lxr_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户管理_联系人修改);
            Privs_Lxr_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户管理_联系人删除);
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(KeHuId);
            if (info == null) RCWE("异常请求");

            if (info.CustomerContact != null && info.CustomerContact.Count > 0)
            {
                rpt.DataSource = info.CustomerContact;
                rpt.DataBind();
            }
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CustomerContactInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.CustomerContactInfo();

            info.BirthDay = null;
            info.CompanyId = CurrentUserCompanyID;
            info.ContactId = Utils.GetInt(Utils.GetFormValue("txt_lxr_id"));
            info.CustomerId = KeHuId;
            info.DepartId = Utils.GetFormValue("txt_lxr_bumen");
            info.Email = string.Empty;
            info.Fax = Utils.GetFormValue("txt_lxr_fax");
            info.Hobby = string.Empty;
            info.Job = Utils.GetFormValue("txt_lxr_zhiwu");
            info.Mobile = Utils.GetFormValue("txt_lxr_shouji");
            info.Name = Utils.GetFormValue("txt_lxr_name");
            info.qq = Utils.GetFormValue("txt_lxr_qq"); 
            info.Remark = string.Empty;
            info.Sex = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(Utils.GetFormValue("txt_lxr_xingbie"), EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
            info.Spetialty = string.Empty;
            info.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus>(Utils.GetFormValue("txt_lxr_status"), EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除);
            info.Tel = Utils.GetFormValue("txt_lxr_dianhua");
            info.WeiXinHao = Utils.GetFormValue("txt_lxr_weixin"); 
            info.YongHuId = 0;
            
            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();
            if (info.ContactId > 0)
            {
                if (!Privs_Lxr_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_Lxr_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            if (string.IsNullOrEmpty(info.Name))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：联系人姓名不能为空。"));
            }

            var bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().KeHuLxr_CU(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// shanchu
        /// </summary>
        void ShanChu()
        {
            int txt_lxr_id = Utils.GetInt(Utils.GetFormValue("txt_lxr_id"));
            if (!Privs_Lxr_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().KeHuLxr_D(CurrentUserCompanyID, CurrentZxsId, SiteUserInfo.UserId, KeHuId, txt_lxr_id);


            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-97", "操作失败：已经分配用户账号的联系人不能删除"));
            if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson("-96", "操作失败：该联系人已与系统业务关联不能删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
            
        }
        #endregion

        #region private members
        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuoHtml()
        {
            string s = string.Empty;

            if (Privs_Lxr_XiuGai)
                s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
            if (Privs_Lxr_ShanChu)
                s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            return s;
        }
        #endregion
    }
}
