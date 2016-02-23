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
    /// 客户联系账号管理
    /// </summary>
    public partial class KeHuLxrYongHuEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 客户编号
        /// </summary>
        string KeHuId = string.Empty;
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

        /// <summary>
        /// 客户专线商编号
        /// </summary>
        protected string KeHuZxsId = string.Empty;
        /// <summary>
        /// 注册客户-账号-添加
        /// </summary>
        bool Privs_ZhuCeKeHu_YongHu_TianJia = false;
        /// <summary>
        /// 注册客户-账号-修改
        /// </summary>
        bool Privs_ZhuCeKeHu_YongHu_XiuGai = false;
        /// <summary>
        /// 注册客户-账号-删除
        /// </summary>
        bool Privs_ZhuCeKeHu_YongHu_ShanChu = false;

        /// <summary>
        /// 客户来源
        /// </summary>
        protected EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan LaiYuan = EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.系统添加;
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
            Privs_YongHu_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户管理_账号新增);
            Privs_YongHu_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户管理_账号修改);
            Privs_YongHu_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户管理_账号删除);

            Privs_ZhuCeKeHu_YongHu_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_注册客户管理_注册客户账号新增);
            Privs_ZhuCeKeHu_YongHu_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_注册客户管理_注册客户账号修改);
            Privs_ZhuCeKeHu_YongHu_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_注册客户管理_注册客户账号删除);
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(KeHuId);
            if (info == null) RCWE("异常请求");

            KeHuZxsId = info.ZxsId;
            LaiYuan = info.LaiYuan;

            if (info.CustomerContact != null && info.CustomerContact.Count > 0)
            {
                rpt.DataSource = info.CustomerContact;
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
            string txtKeHuZxsId = Utils.GetFormValue("txtKeHuZxsId");
            int txtLxrId = Utils.GetInt(Utils.GetFormValue("txtLxrId"));
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));

            var laiYuan = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan>(Utils.GetFormValue("txtKeHuLaiYuan"), EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.系统添加);

            if (laiYuan == EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.系统添加)
            {
                if (txtYongHuId == 0)
                {
                    if (!Privs_YongHu_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }

                if (txtYongHuId > 0)
                {
                    if (SiteUserInfo.ZxsT1 == EyouSoft.Model.EnumType.PtStructure.ZxsT1.其它专线商)
                    {
                        if (txtKeHuZxsId != CurrentZxsId) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                    }

                    if (!Privs_YongHu_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
            }

            if (laiYuan == EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.平台注册)
            {
                if (txtYongHuId == 0)
                {
                    if (!Privs_ZhuCeKeHu_YongHu_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }

                if (txtYongHuId > 0)
                {
                    if (!Privs_ZhuCeKeHu_YongHu_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
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
            string txtYouXiang = Utils.GetFormValue("txtYouXiang");

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().KeHuLxrYongHu_CU(KeHuId, txtLxrId, txtYongHuId, txtYongHuMing, txtMiMa, md5MiMa, txtYouXiang);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson("-97", "操作失败：已经存在的用户名"));
            if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson("-97", "操作失败：已经存在的邮箱"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// shanchu
        /// </summary>
        void ShanChu()
        {
            string txtKeHuZxsId = Utils.GetFormValue("txtKeHuZxsId");
            var laiYuan = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan>(Utils.GetFormValue("txtKeHuLaiYuan"), EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.系统添加);

            if (laiYuan == EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.系统添加)
            {
                if (!Privs_YongHu_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

                if (SiteUserInfo.ZxsT1 == EyouSoft.Model.EnumType.PtStructure.ZxsT1.其它专线商)
                {
                    if (txtKeHuZxsId != CurrentZxsId) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
            }

            if (laiYuan == EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.平台注册)
            {
                if (!Privs_ZhuCeKeHu_YongHu_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int txtLxrId = Utils.GetInt(Utils.GetFormValue("txtLxrId"));
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().KeHulxrYonHu_D(KeHuId, txtLxrId, txtYongHuId);

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

            if (LaiYuan == EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.系统添加)
            {
                if (KeHuZxsId == CurrentZxsId)
                {
                    if (_yongHuId == 0 && Privs_YongHu_TianJia)
                        s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                    if (_yongHuId > 0 && Privs_YongHu_XiuGai)
                        s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                    if (Privs_YongHu_ShanChu)
                        s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";
                }
                else
                {
                    if (SiteUserInfo.ZxsT1 == EyouSoft.Model.EnumType.PtStructure.ZxsT1.主专线商)
                    {
                        if (_yongHuId == 0 && Privs_YongHu_TianJia)
                            s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                        if (_yongHuId > 0 && Privs_YongHu_XiuGai)
                            s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                        if (Privs_YongHu_ShanChu)
                            s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";
                    }

                    if (SiteUserInfo.ZxsT1 == EyouSoft.Model.EnumType.PtStructure.ZxsT1.其它专线商)
                    {
                        if (_yongHuId == 0 && Privs_YongHu_TianJia)
                            s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                    }
                }
            }

            if (LaiYuan == EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.平台注册)
            {
                if (_yongHuId == 0 && Privs_ZhuCeKeHu_YongHu_TianJia)
                    s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                if (_yongHuId > 0 && Privs_ZhuCeKeHu_YongHu_XiuGai)
                    s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">保存</a> ";
                if (Privs_ZhuCeKeHu_YongHu_ShanChu)
                    s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";
            }

            return s;
        }
        #endregion
    }
}
