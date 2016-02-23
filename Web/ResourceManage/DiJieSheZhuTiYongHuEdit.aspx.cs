//地接社主体账号管理  汪奇志 2015-05-17
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
    /// 地接社主体账号管理
    /// </summary>
    public partial class DiJieSheZhuTiYongHuEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 账号添加权限
        /// </summary>
        bool Privs_ZhangHaoTianJia = false;
        /// <summary>
        /// 账号修改权限
        /// </summary>
        bool Privs_ZhangHaoXiuGai = false;
        /// <summary>
        /// 账号删除权限
        /// </summary>
        bool Privs_ZhangHaoShanChu = false;

        string GysId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            GysId = Utils.GetQueryStringValue("gysid");
            if (string.IsNullOrEmpty(GysId)) Utils.RCWE_AJAX("0", "异常请求");

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
            Privs_ZhangHaoTianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_账号新增);
            Privs_ZhangHaoXiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_账号修改);
            Privs_ZhangHaoShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_账号删除);
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var items = new EyouSoft.BLL.GysStructure.BGysZhuTi().GetGysLxrs(GysId);
            if (items == null || items.Count == 0)
            {
                items = new List<EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo>();
            }

            items.Add(new EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo() { });

            rpt.DataSource = items;
            rpt.DataBind();
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo();
            info.CaoZuoRenId = SiteUserInfo.UserId;
            info.GysId = GysId;
            info.IssueTime = DateTime.Now;
            info.LxrBuMen = string.Empty;
            info.LxrDianHua = Utils.GetFormValue("txtLxrDianHua");
            info.LxrFax = string.Empty;
            info.LxrId = Utils.GetInt(Utils.GetFormValue("txtLxrId"));
            info.LxrName = Utils.GetFormValue("txtLxrName");
            info.LxrQQ = Utils.GetFormValue("txtLxrQQ");
            info.LxrShouJi = Utils.GetFormValue("txtLxrShouJi");
            info.LxrWeiXin = string.Empty;
            info.LxrZhiWu = string.Empty;
            info.Md5MiMa = string.Empty;
            info.MiMa = string.Empty;
            info.YongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));
            info.YongHuMing = Utils.GetFormValue("txtYongHuMing");

            string txtMiMa = Utils.GetFormValue("txtMiMa");
            string md5MiMa = string.Empty;

            if (!string.IsNullOrEmpty(txtMiMa))
            {
                var pwd = new EyouSoft.Model.CompanyStructure.PassWord();
                pwd.NoEncryptPassword = txtMiMa;
                md5MiMa = pwd.MD5Password;
            }

            info.MiMa = txtMiMa;
            info.Md5MiMa = md5MiMa;

            if (string.IsNullOrEmpty(info.YongHuMing)) Utils.RCWE_AJAX("0", "请输入用户名");
            if (string.IsNullOrEmpty(info.LxrName)) Utils.RCWE_AJAX("0", "请输入姓名");

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            if (info.LxrId > 0)
            {
                if (!Privs_ZhangHaoXiuGai) Utils.RCWE_AJAX("0", "没有操作权限");
            }
            else
            {
                if (!Privs_ZhangHaoTianJia) Utils.RCWE_AJAX("0", "没有操作权限");
            }

            int bllRetCode = 0;
            if (info.LxrId==0)
            {
                bllRetCode = new EyouSoft.BLL.GysStructure.BGysZhuTi().GysZhuTi_Lxr_C(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.GysStructure.BGysZhuTi().GysZhuTi_Lxr_U(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson("-97", "操作失败：已经存在的用户名"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// 删除
        /// </summary>
        void ShanChu()
        {
            if (!Privs_ZhangHaoShanChu) Utils.RCWE_AJAX("0", "没有操作权限");

            int txtLxrId = Utils.GetInt(Utils.GetFormValue("txtLxrId"));
            int txtYongHuId = Utils.GetInt(Utils.GetFormValue("txtYongHuId"));

            int bllRetCode = new EyouSoft.BLL.GysStructure.BGysZhuTi().GysZhuTi_lxr_D(GysId, txtLxrId, txtYongHuId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo
        /// </summary>
        /// <param name="lxrId"></param>
        /// <param name="yongHuId"></param>
        /// <returns></returns>
        protected string GetCaoZuo(object lxrId, object yongHuId)
        {
            string s = string.Empty;
            var _lxrId = (int)lxrId;
            var _yongHuId = (int)yongHuId;

            if (_lxrId == 0)
            {
                if (Privs_ZhangHaoTianJia)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"baocun\">保存</a>&nbsp;&nbsp;";
                }
            }
            else
            {
                if (Privs_ZhangHaoXiuGai)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"baocun\">保存</a>&nbsp;&nbsp;";
                }
                if (Privs_ZhangHaoShanChu)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"shanchu\">删除</a>&nbsp;&nbsp;";
                }
            }

            if (string.IsNullOrEmpty(s))
            {
                s = "无权限";
            }

            return s.ToString();
        }
        #endregion
    }
}
