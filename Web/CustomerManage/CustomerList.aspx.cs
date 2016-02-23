using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;

namespace Web.CustomerManage
{
    using EyouSoft.Model.CompanyStructure;
    using EyouSoft.Common;
    using EyouSoft.Model.EnumType.PrivsStructure;
    using EyouSoft.Model.EnumType.CompanyStructure;

    /// <summary>
    /// 客户资料列表
    /// 郑知远 2012-11-22
    /// </summary>
    public partial class CustomerList : BackPage
    {
        #region 分页参数
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
        /// 新增权限
        /// </summary>
        public bool Privs_Insert;
        /// <summary>
        /// 修改权限
        /// </summary>
        public bool Privs_Update;
        /// <summary>
        /// 删除权限
        /// </summary>
        public bool Privs_Delete;
        /// <summary>
        /// 注册客户修改权限 
        /// </summary>
        bool Privs_ZhuCeKeHuXiuGai = false;
        /// <summary>
        /// 注册客户删除权限
        /// </summary>
        bool Privs_ZhuCeKeHuShanChu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            #region ajax request
            switch (Utils.GetQueryStringValue("doType"))
            {
                case "delete":  Delete(); break;
                default: break;
            }
            #endregion

            //页面初始化
            InitRpt();
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitRpt()
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            var items = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomers(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, GetSearchInfo());
            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rptLst.DataSource = items;
                rptLst.DataBind();
            }

            BindPage();

        }

        /// <summary>
        /// 搜索实体
        /// </summary>
        /// <returns></returns>
        MCustomerSeachInfo GetSearchInfo()
        {
            var info = new MCustomerSeachInfo();
            var pid = new int[1];
            var cid = new int[1];
            pid[0] = Utils.GetInt(Utils.GetQueryStringValue("ddlProvice"));
            cid[0] = Utils.GetInt(Utils.GetQueryStringValue("ddlCity"));

            info.CustomerName = Utils.GetQueryStringValue("txtUnitName");
            info.ProvinceIds = pid.Contains(0) ? null : pid;
            info.CityIdList = cid.Contains(0) ? null : cid;
            info.SellerName = Utils.GetQueryStringValue("txtSeller");
            info.ContactName = Utils.GetQueryStringValue("txtContactName");
            info.OrderByType = 2;
            info.KeHuLeiXing = (CustomerType?)Utils.GetEnumValueNull(typeof(CustomerType), Utils.GetQueryStringValue("txtKeHuLeiXing"));
            info.ShenHeStatus = EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus.已审核;

            return info;
        }

        /// <summary>
        /// 绑定分页
        /// </summary>
        private void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;

            if (this.ExporPageInfoSelect1.intRecordCount == 0)
            {
                this.ExporPageInfoSelect1.Visible = false;
                this.phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        void Delete()
        {
            var laiYuan = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan>(Utils.GetFormValue("txtLaiYuan"), KeHuLaiYuan.系统添加);
            string zxsId = Utils.GetFormValue("txtZxsId");

            if (laiYuan == KeHuLaiYuan.系统添加)
            {
                if (!Privs_Delete && zxsId == CurrentZxsId) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            if (laiYuan == KeHuLaiYuan.平台注册)
            {
                if (!Privs_ZhuCeKeHuShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

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
            if (!this.CheckGrant(Privs3.客户管理_客户管理_栏目))
            {
                Utils.ResponseNoPermit(Privs3.客户管理_客户管理_栏目, false);
                return;
            }

            //操作权限
            Privs_Insert = CheckGrant(Privs3.客户管理_客户管理_新增);
            Privs_Update = CheckGrant(Privs3.客户管理_客户管理_修改);
            Privs_Delete = CheckGrant(Privs3.客户管理_客户管理_删除);

            Privs_ZhuCeKeHuXiuGai = CheckGrant(Privs3.客户管理_注册客户管理_注册客户修改);
            Privs_ZhuCeKeHuShanChu = CheckGrant(Privs3.客户管理_注册客户管理_注册客户删除);
        }

        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <returns></returns>
        protected string GetCaoZuoHtml(object zxsId,object laiYuan)
        {
            string s = string.Empty;
            string _zxsId = zxsId.ToString();
            var _laiYuan = (EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan)laiYuan;

            if (_zxsId == CurrentZxsId 
                || (_laiYuan == KeHuLaiYuan.系统添加 && SiteUserInfo.ZxsT1 == EyouSoft.Model.EnumType.PtStructure.ZxsT1.主专线商))
            {
                if (Privs_Update)
                {
                    s += "<a class=\"tool_update\" href=\"javascript:void(0)\">修改</a> ";
                }
                else
                {
                    s += "<a class=\"tool_update\" href=\"javascript:void(0)\" data-ischakan=\"1\">查看</a> ";
                }

                if (Privs_Delete)
                {
                    s += "<a class=\"tool_delete\" href=\"javascript:void(0)\">删除</a> ";
                }
            }
            else
            {
                if (_laiYuan == KeHuLaiYuan.系统添加)
                {
                    s += "<a class=\"tool_update\" href=\"javascript:void(0)\" data-ischakan=\"1\">查看</a> ";
                }

                if (_laiYuan == KeHuLaiYuan.平台注册)
                {
                    if (Privs_ZhuCeKeHuXiuGai)
                    {
                        s += "<a class=\"tool_update\" href=\"javascript:void(0)\">修改</a> ";
                    }
                    else
                    {
                        s += "<a class=\"tool_update\" href=\"javascript:void(0)\" data-ischakan=\"1\">查看</a> ";
                    }

                    if (Privs_ZhuCeKeHuShanChu)
                    {
                        s += "<a class=\"tool_delete\" href=\"javascript:void(0)\">删除</a> ";
                    }
                }
            }

            s += "<a href=\"javascript:void(0)\" class=\"yonghuguanli\">账号</a> ";
            s += "<a href=\"javascript:void(0)\" class=\"lianxiren\">联系人</a> ";

            return s;
        }
    }
}
