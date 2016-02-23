using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.PrivsStructure;

namespace Web.CustomerManage
{
    /// <summary>
    /// 注册客户管理
    /// </summary>
    public partial class ZhuCeKeHu : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 每页显示条数
        /// </summary>
        protected int pageSize = 20;
        /// <summary>
        /// 当前页数
        /// </summary>
        protected int pageIndex = 0;
        /// <summary>
        /// 总记录条数
        /// </summary>
        public int recordCount = 0;        
        /// <summary>
        /// 注册客户删除权限
        /// </summary>
        public bool Privs_ZhuCeKeHuShanChu;
        /// <summary>
        /// 审核权限
        /// </summary>
        bool Privs_ShenHe = false;
        /// <summary>
        /// 注册客户修改权限 
        /// </summary>
        bool Privs_ZhuCeKeHuXiuGai = false;        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            #region ajax request
            switch (Utils.GetQueryStringValue("doType"))
            {
                case "delete": Delete(); break;
                case "shenhe": ShenHe(); break;
                default: break;
            }
            #endregion

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            var chaXun = GetChaXunInfo();
            var items = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomers(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);
            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpt.DataSource = items;
                rpt.DataBind();

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 获取查询信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MCustomerSeachInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.MCustomerSeachInfo();
            var pid = new int[1];
            var cid = new int[1];
            pid[0] = Utils.GetInt(Utils.GetQueryStringValue("ddlProvice"));
            cid[0] = Utils.GetInt(Utils.GetQueryStringValue("ddlCity"));

            info.CustomerName = Utils.GetQueryStringValue("txtKeHuName");
            info.ProvinceIds = pid.Contains(0) ? null : pid;
            info.CityIdList = cid.Contains(0) ? null : cid;
            info.ContactName = Utils.GetQueryStringValue("txtLxrName");
            info.OrderByType = 1;
            info.KeHuLeiXing = (EyouSoft.Model.EnumType.CompanyStructure.CustomerType?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.CustomerType), Utils.GetQueryStringValue("txtKeHuLeiXing"));
            info.LaiYuan = EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan.平台注册;

            info.ShenHeStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus), Utils.GetQueryStringValue("txtShenHeStatus"));
            info.ZhuCeShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtZhuCeShiJian1"));
            info.ZhuCeShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtZhuCeShiJian2"));

            return info;
        }

        /// <summary>
        /// 删除
        /// </summary>
        void Delete()
        {
            if (!Privs_ZhuCeKeHuShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string keHuId = Utils.GetFormValue("txtKeHuId");
            if (string.IsNullOrEmpty(keHuId)) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));

            var bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().DeleteKeHu(CurrentUserCompanyID, CurrentZxsId, keHuId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：该客户有交易信息，不可删除"));
            else if (bllRetCode == -96) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：该客户联系人有分配账号，不可删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// 权限初始化
        /// </summary>
        void InitPrivs()
        {
            if (!this.CheckGrant(Privs3.客户管理_注册客户管理_栏目))
            {
                Utils.ResponseNoPermit(Privs3.客户管理_注册客户管理_栏目, false);
                return;
            }
            Privs_ZhuCeKeHuShanChu = CheckGrant(Privs3.客户管理_注册客户管理_注册客户删除);
            Privs_ShenHe = CheckGrant(Privs3.客户管理_注册客户管理_注册客户审核);
            Privs_ZhuCeKeHuXiuGai = CheckGrant(Privs3.客户管理_注册客户管理_注册客户修改);
        }

        /// <summary>
        /// shen he
        /// </summary>
        void ShenHe()
        {
            if (!Privs_ShenHe) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string keHuId = Utils.GetFormValue("txtKeHuId");
            if (string.IsNullOrEmpty(keHuId)) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().ZhuCeKeHuShenHe(CurrentUserCompanyID, keHuId, SiteUserInfo.UserId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuoHtml(object shenHeStatus)
        {
            string s = string.Empty;
            var _shenHeStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus)shenHeStatus;

            if (!Privs_ZhuCeKeHuXiuGai)
            {
                s += "<a class=\"chakan\" href=\"javascript:void(0)\" data-ischakan=\"1\">查看</a> ";
            }
            else
            {
                s += "<a class=\"chakan\" href=\"javascript:void(0)\">修改</a> ";
            }

            if (Privs_ZhuCeKeHuShanChu && _shenHeStatus == EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.未审核)
            {
                s += "<a class=\"shanchu\" href=\"javascript:void(0)\">删除</a> ";
            }

            if (Privs_ShenHe && _shenHeStatus== EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.未审核)
            {
                s += "<a class=\"shenhe\" href=\"javascript:void(0)\">审核</a> ";
            }

            s += "<a href=\"javascript:void(0)\" class=\"yonghuguanli\">账号</a>";

            return s;
        }

        /// <summary>
        /// get shenhe status
        /// </summary>
        /// <param name="shenHeStatus"></param>
        /// <returns></returns>
        protected string GetShenHeStatus(object shenHeStatus)
        {
            var _shenHeStatus = (EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus)shenHeStatus;

            if (_shenHeStatus == EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.已审核) return "已审核";

            return "<span style='color:#ff0000'>未审核</span>";
        }
        #endregion
    }
}
