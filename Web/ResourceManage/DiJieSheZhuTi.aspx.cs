//地接社主体管理  汪奇志 2015-05-15
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
    /// 地接社主体管理
    /// </summary>
    public partial class DiJieSheZhuTi : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        /// <summary>
        /// 添加权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai= false;
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_ShanChu = false;
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

        protected int pageIndex = 0;
        protected int pageSize = 20;
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
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_栏目);
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_删除);
            Privs_ZhangHaoTianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_账号新增);
            Privs_ZhangHaoXiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_账号修改);
            Privs_ZhangHaoShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_账号删除);

            if (!Privs_LanMu) Utils.RCWE(UtilsCommons.AjaxReturnJson("-1000", "没有权限"));

            phTianJia.Visible = Privs_TianJia;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.GysStructure.MGysZhuTiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.GysStructure.MGysZhuTiChaXunInfo();

            info.GysName = Utils.GetQueryStringValue("txtGysName");
            info.ChengShiId = Utils.GetIntNull(Utils.GetQueryStringValue("txtChengShi"));
            info.LxrName = Utils.GetQueryStringValue("txtLxrName");
            info.ShengFenId = Utils.GetIntNull(Utils.GetQueryStringValue("txtShengFen"));
            info.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.地接;

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();

            var items = new EyouSoft.BLL.GysStructure.BGysZhuTi().GetGysZhuTis(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

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
        /// shanchu
        /// </summary>
        void ShanChu()
        {
            var txtGysZhuTiId = Utils.GetFormValue("txtGysZhuTiId");

            if (!Privs_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("0", "没有操作权限"));
            if (string.IsNullOrEmpty(txtGysZhuTiId)) RCWE(UtilsCommons.AjaxReturnJson("0", "异常操作"));

            int bllRetCode = new EyouSoft.BLL.GysStructure.BGysZhuTi().GysZhuTi_D(SiteUserInfo.CompanyId, txtGysZhuTiId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：该主体下分配有用户账号，不能删除。"));
            else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuo()
        {
            string s = string.Empty;

            if (Privs_XiuGai)
            {
                s += "<a href=\"javascript:void(0)\" class=\"xiugai\">修改</a>&nbsp;";
            }
            else
            {
                s += "<a href=\"javascript:void(0)\" class=\"chakan\">查看</a>&nbsp;";
            }

            if (Privs_ShanChu)
            {
                s += "<a href=\"javascript:void(0)\" class=\"shanchu\">删除</a>&nbsp;";
            }

            s += "<a href=\"javascript:void(0)\" class=\"zhanghao\">账号</a>&nbsp;";

            return s;
        }
        #endregion
    }
}
