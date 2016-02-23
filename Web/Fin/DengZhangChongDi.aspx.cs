//汪奇志 2013-02-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.FinStructure;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-出纳登账-冲抵
    /// </summary>
    public partial class DengZhangChongDi : BackPage
    {
        #region attributes
        /// <summary>
        /// 冲抵权限
        /// </summary>
        bool Privs_ChongDi = false;
        /// <summary>
        /// 登账编号
        /// </summary>
        string DengZhangId = string.Empty;
        /// <summary>
        /// 可冲抵金额
        /// </summary>
        protected decimal KeChongDiJinE = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            DengZhangId = Utils.GetQueryStringValue("dengzhangid");
            if (string.IsNullOrEmpty(DengZhangId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));

            string doType = Utils.GetQueryStringValue("doType");

            if (doType == "chongdi") ChongDi();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_ChongDi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳登账_冲抵);

            if (Privs_ChongDi) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_chongdi\">冲抵</a>";
            else ltrOperatorHtml.Text = "你没有冲抵操作权限";
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        void InitInfo()
        {
            ltrOperatorName.Text = SiteUserInfo.Name;
            ltrIssueTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ltrKeHuTypeHtml.Text = GetKeHuTypeHtml("");
            ltrXiangMuIdOptions.Text = GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目, string.Empty);

            var info = new EyouSoft.BLL.FinStructure.BDengZhang().GetChuNaDengZhang(DengZhangId);

            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "请求异常：错误的请求。"));
            KeChongDiJinE = info.DaoKuanJinE - info.UnCheckMoney;
            ltrKeChongDiJinE.Text = ToMoneyString(KeChongDiJinE);
        }

        /// <summary>
        /// 冲抵
        /// </summary>
        void ChongDi()
        {
            if (!Privs_ChongDi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();

            int bllRetCode = new EyouSoft.BLL.FinStructure.BDengZhang().ChongDi(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -2) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：冲抵金额不能大于可冲抵金额！" ));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MChongDiInfo GetFormInfo()
        {
            var info = new MChongDiInfo();

            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.ChongDiId = string.Empty;
            info.CompanyId = CurrentUserCompanyID;
            info.DengZhangId = DengZhangId;
            info.IssueTime = DateTime.Now;
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.OperatorId = SiteUserInfo.UserId;

            info.XiangMuId = Utils.GetInt(Utils.GetFormValue("txtXiangMuId"));
            info.DanWeiType = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiKeHuType>(Utils.GetFormValue("txtKeHuType"), EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiKeHuType.客户单位);
            info.DanWeiId = Utils.GetFormValue("txtKeHuId");
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <param name="jiChuXinXiType">基础信息类型</param>
        /// <param name="_v">选中的值</param>
        /// <returns></returns>
        string GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType jiChuXinXiType, string _v)
        {
            StringBuilder s = new StringBuilder();
            var t1 = EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支;

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType, t1, CurrentZxsId);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Id.ToString() == _v)
                    {
                        s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</options>", item.Id, item.Name);
                    }
                    else
                    {
                        s.AppendFormat("<option value=\"{0}\">{1}</options>", item.Id, item.Name);
                    }
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取单位类型HTML
        /// </summary>
        /// <param name="selectValue">要选中的值</param>
        /// <returns></returns>
        string GetKeHuTypeHtml(string selectValue)
        {
            if (string.IsNullOrEmpty(selectValue)) selectValue = "0";
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiKeHuType));

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Value == selectValue) s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                    else s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Value, item.Text);
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
