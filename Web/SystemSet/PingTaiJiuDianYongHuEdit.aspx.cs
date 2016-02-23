using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.SystemSet
{
    public partial class PingTaiJiuDianYongHuEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 用户编号
        /// </summary>
        protected int EditId = 0;
        /// <summary>
        /// 添加权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;

        protected string XingBie = string.Empty;

        EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing YHLX = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetInt(Utils.GetQueryStringValue("editid"));
            string yhlx = Utils.GetQueryStringValue("yhlx");

            if (yhlx == "3") YHLX = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户;

            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (YHLX == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户)
            {
                Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台酒店用户管理栏目);
                Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台酒店用户管理栏目);
            }

            if (YHLX == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)
            {
                Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台景点用户管理栏目);
                Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_平台景点用户管理栏目);
            }

            if (EditId==0)
            {
                if (Privs_TianJia) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
            else
            {
                if (Privs_XiuGai) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            var bll = new EyouSoft.BLL.CompanyStructure.CompanyUser();
            if (bll.IsExists(info.ID, info.UserName, CurrentUserCompanyID))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已经存在的用户名。"));
            }

            if (!string.IsNullOrEmpty(info.PersonInfo.ContactEmail) && bll.IsExistsEmail(info.PersonInfo.ContactEmail, info.ID, CurrentUserCompanyID))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已经存在的邮箱。"));
            }

            bool bllRetCode = false;
            if (info.ID == 0)
            {
                bllRetCode = bll.Add(info);
            }
            else
            {
                bllRetCode = bll.Update(info);
            }

            string[] _privs = new string[] { ((int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_栏目).ToString(), ((int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_修改).ToString(), ((int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_房型管理).ToString() };

            if (YHLX == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)
            {
                _privs = new string[] { ((int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_栏目).ToString(), ((int)EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_景点管理_修改).ToString() };
            }

            bll.SetPermission(info.ID, 0, _privs);

            if (bllRetCode) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CompanyUser GetFormInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.CompanyUser();
            info.BuMenName = string.Empty;
            info.CompanyId = CurrentUserCompanyID;
            info.DanJuTaiTouDiZhi = string.Empty;
            info.DanJuTaiTouMingCheng = string.Empty;
            info.DepartId = 0;
            info.DepartName = string.Empty;
            info.DongJieJiFen = 0;
            info.ID = EditId;
            info.IsAdmin = false;
            info.IsDeleted = false;
            info.IssueTime = DateTime.Now;
            info.KeHuId = string.Empty;
            info.KeHuLxrId = 0;
            info.KeHuLxrStatus = EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改可删除;
            info.KeYongJiFen = 0;
            info.LastLoginIP = string.Empty;
            info.LastLoginTime = DateTime.Now;
            info.LeiXing = YHLX;
            info.MiMa = string.Empty;
            info.MiMaMd5 = string.Empty;
            info.OperatorId = SiteUserInfo.UserId;
            info.PassWordInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            string miMa = Utils.GetFormValue(txtMiMa.UniqueID);
            if (!string.IsNullOrEmpty(miMa))
            {
                info.PassWordInfo.NoEncryptPassword = miMa;
            }
            info.PermissionList = string.Empty;
            info.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();
            info.PersonInfo.ContactEmail = Utils.GetFormValue(txtYouXing.UniqueID);
            info.PersonInfo.ContactFax = Utils.GetFormValue(txtFax.UniqueID);
            info.PersonInfo.ContactMobile = Utils.GetFormValue(txtShouJi.UniqueID);
            info.PersonInfo.ContactName = Utils.GetFormValue(txtXingMing.UniqueID);
            info.PersonInfo.ContactSex = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(Utils.GetFormValue("txtXingBie"), EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
            info.PersonInfo.ContactTel = Utils.GetFormValue(txtDianHua.UniqueID);
            info.PersonInfo.JobName = string.Empty;
            info.PersonInfo.MSN = string.Empty;
            info.PersonInfo.PeopProfile = Utils.GetFormValue(txtJianJie.UniqueID);
            info.PersonInfo.QQ = Utils.GetFormValue(txtQQ.UniqueID);
            info.PersonInfo.Remark = Utils.GetFormValue(txtBeiZhu.UniqueID);
            info.RoleID = 0;
            info.SuperviseDepartId = 0;
            info.SuperviseDepartName = string.Empty;
            info.UserBank = null;
            info.UserName = Utils.GetFormValue(txtYongHuMing.UniqueID);
            info.UserStatus = EyouSoft.Model.EnumType.CompanyStructure.UserStatus.正常;
            info.WeiXinHao = Utils.GetFormValue(txtWeiXinHao.UniqueID);
            info.YuanMiMaMd5 = string.Empty;
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (EditId==0) return;

            var info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(EditId);
            if (info == null
                || (info.LeiXing != EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户 && info.LeiXing != EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)) RCWE("异常请求");

            txtYongHuMing.Value = info.UserName;
            txtXingMing.Value = info.PersonInfo.ContactName;
            XingBie = ((int)info.PersonInfo.ContactSex).ToString();
            txtDianHua.Value = info.PersonInfo.ContactTel;
            txtFax.Value = info.PersonInfo.ContactFax;
            txtShouJi.Value = info.PersonInfo.ContactMobile;
            txtYouXing.Value = info.PersonInfo.ContactEmail;
            txtQQ.Value = info.PersonInfo.QQ;
            txtWeiXinHao.Value = info.WeiXinHao;
            txtJianJie.Value = info.PersonInfo.PeopProfile;
            txtBeiZhu.Value = info.PersonInfo.Remark;
        }
        #endregion
    }
}
