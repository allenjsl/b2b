//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-订单回访
    /// </summary>
    public partial class DingDanHuiFang : BackPage
    {
        #region attributes
        /// <summary>
        /// 订单编号
        /// </summary>
        protected string OrderId = string.Empty;
        /// <summary>
        /// 回访编号
        /// </summary>
        string HuiFangId = string.Empty;
        /// <summary>
        /// 回访操作权限
        /// </summary>
        bool Privs_HuiFang = false;
        /// <summary>
        /// 权限-添加
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 权限-修改
        /// </summary>
        bool Privs_XiuGai = false;
        /// <summary>
        /// 权限-删除
        /// </summary>
        bool Privs_ShanChu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            OrderId = Utils.GetQueryStringValue("orderid");
            HuiFangId = Utils.GetQueryStringValue("huifangid");
            if (string.IsNullOrEmpty(OrderId)) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "save": Save(); break;
                case "delete": Delete(); break;
                default: break;
            }

            var info = InitRpts();

            InitInfo(info);
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_订单管理))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_订单管理, true);
                }
            }

            Privs_HuiFang = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_订单管理);

            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_回访登记);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_回访修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_回访删除);

            if (string.IsNullOrEmpty(HuiFangId))
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
        /// init repeater
        /// </summary>
        MHuiFangInfo InitRpts()
        {
            MHuiFangInfo info=null;
            var items = new EyouSoft.BLL.FinStructure.BHuiFang().GetHuiFangs(OrderId);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                if (!string.IsNullOrEmpty(HuiFangId))
                {
                    foreach (var item in items)
                    {
                        if (item.HuiFangId == HuiFangId) info = item;
                    }
                }

                phEmpty.Visible = false;
            }
            else
            {
                phEmpty.Visible = true;
            }

            return info;
        }

        /// <summary>
        /// 初始化回访信息
        /// </summary>
        void InitInfo(MHuiFangInfo info)
        {
            if (info == null) return;

            txtHuiFangTime.Value = info.Time.ToString("yyyy-MM-dd");
            txtShenFen.Value = info.ShenFen;
            txtXingMing.Value = info.XingMing;
            txtTelephone.Value = info.Telephone;
            txtJieGuo.Value = info.JieGuo;
        }

        MHuiFangInfo GetFormInfo()
        {
            var info = new MHuiFangInfo();
            
            info.IssueTime = DateTime.Now;
            info.JieGuo = Utils.GetFormValue("txtJieGuo");
            info.OperatorId = SiteUserInfo.UserId;
            info.OrderId = OrderId;
            info.ShenFen = Utils.GetFormValue("txtShenFen");
            info.Telephone = Utils.GetFormValue("txtTelephone");
            info.Time = Utils.GetDateTime(Utils.GetFormValue("txtHuiFangTime"), DateTime.Now);
            info.XingMing = Utils.GetFormValue("txtXingMing");

            return info;
        }

        /// <summary>
        /// 新增、修改
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(HuiFangId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            var info = GetFormInfo();
            info.HuiFangId = HuiFangId;

            int bllRetCode = 4;

            if (string.IsNullOrEmpty(HuiFangId)) bllRetCode = new EyouSoft.BLL.FinStructure.BHuiFang().Insert(info);
            else bllRetCode = new EyouSoft.BLL.FinStructure.BHuiFang().Update(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 删除
        /// </summary>
        void Delete()
        {
            if (!Privs_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string _huiFangId = Utils.GetFormValue("txtHuiFangId");

            int bllRetCode = new EyouSoft.BLL.FinStructure.BHuiFang().Delete(_huiFangId);
            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
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
                s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a>";
            }
            else
            {
                s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">查看</a>";
            }

            if (Privs_ShanChu)
            {
                s+="<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a>";
            }

            return s;
        }
        #endregion
    }
}
