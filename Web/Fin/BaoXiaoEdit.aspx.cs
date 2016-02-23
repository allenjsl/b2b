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
    /// 财务管理-报销登记
    /// </summary>
    public partial class BaoXiaoEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 报销登记编号
        /// </summary>
        string BaoXiaoId = string.Empty;
        /// <summary>
        /// 报销操作权限
        /// </summary>
        bool Privs_Insert = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BaoXiaoId = Utils.GetQueryStringValue("baoxiaoid");
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_报销登记表_报销登记);
        }

        /// <summary>
        /// 初始化借款信息
        /// </summary>
        void InitInfo()
        {
            txtRiQi.Value = DateTime.Now.ToString("yyyy-MM-dd");
            phEmpty.Visible = true;
            if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有报销操作权限";            

            var info = new EyouSoft.BLL.FinStructure.BBaoXiao().GetInfo(BaoXiaoId);
            if (info == null) return;

            phEmpty.Visible = false;
            txtRiQi.Value = info.BaoXiaoRiQi.ToString("yyyy-MM-dd");
            txtBaoXiaoRen.SellsID = info.BaoXiaoRenId.ToString();
            txtBaoXiaoRen.SellsName = info.BaoXiaoRenName;
            rpts.DataSource = info.XiaoFeis;
            rpts.DataBind();

            switch (info.Status)
            {
                case BaoXiaoStatus.未审批:
                    if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                    else ltrOperatorHtml.Text = "你没有报销操作权限";
                    break;
                case BaoXiaoStatus.未通过:
                    ltrOperatorHtml.Text = "报销信息审批未通过";
                    break;
                case BaoXiaoStatus.未支付:
                    ltrOperatorHtml.Text = "报销信息审批已通过，等待支付";
                    break;
                case BaoXiaoStatus.已支付:
                    ltrOperatorHtml.Text = "报销已支付";
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.BaoXiaoId = BaoXiaoId;
            int bllRetCode = 4;
            if (string.IsNullOrEmpty(BaoXiaoId))
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BBaoXiao().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BBaoXiao().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MBaoXiaoInfo GetFormInfo()
        {
            MBaoXiaoInfo info = new MBaoXiaoInfo();

            info.BaoXiaoRiQi = Utils.GetDateTime(Utils.GetFormValue("txtRiQi"));
            info.BaoXiaoRenId = Utils.GetInt(Utils.GetFormValue("txtBaoXiaoRen"));
            info.CompanyId = CurrentUserCompanyID;
            info.OperatorId = SiteUserInfo.UserId;

            info.XiaoFeis = new List<MBaoXiaoXiaoFeiInfo>();

            string[] txtXiaoFeiRiQi = Utils.GetFormValues("txtXiaoFeiRiQi[]");
            string[] txtXiaoFeiJinE = Utils.GetFormValues("txtXiaoFeiJinE[]");
            string[] txtXiaoFeiType = Utils.GetFormValues("txtXiaoFeiType[]");
            string[] txtXiaoFeiBeiZhu = Utils.GetFormValues("txtXiaoFeiBeiZhu[]");

            for (int i = 0; i < txtXiaoFeiRiQi.Length; i++)
            {
                var item = new MBaoXiaoXiaoFeiInfo();
                item.JinE = Utils.GetDecimal(txtXiaoFeiJinE[i]);
                item.XiaoFeiBeiZhu = txtXiaoFeiBeiZhu[i];
                item.XiaoFeiRiQi = Utils.GetDateTime(txtXiaoFeiRiQi[i]);
                item.XiaoFeiType = Utils.GetEnumValue<BaoXiaoXiaoFeiType>(txtXiaoFeiType[i], BaoXiaoXiaoFeiType.其它);

                info.XiaoFeis.Add(item);
            }

            info.ZxsId = CurrentZxsId;

            return info;
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取报销类型下拉菜单项
        /// </summary>
        /// <param name="obj">选中的值</param>
        /// <returns></returns>
        protected string GetBaoXiaoTypeOptionHtml(object obj)
        {
            int _type = (int)BaoXiaoXiaoFeiType.交通费;
            if (obj != null) _type = (int)(BaoXiaoXiaoFeiType)obj;


            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EnumObj.GetList(typeof(BaoXiaoXiaoFeiType));

            //s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                if ((_type.ToString() == item.Value))
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Value, item.Text);
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
