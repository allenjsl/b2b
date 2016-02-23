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
    /// 财务管理-出纳日记账新增
    /// </summary>
    public partial class RiJiZhangEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 日记账编号
        /// </summary>
        string RiJiZhangId = string.Empty;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            RiJiZhangId = Utils.GetQueryStringValue("rijizhangid");

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳日记账_登记);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_出纳日记账_修改);
        }

        /// <summary>
        /// 初始化日记账信息
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(RiJiZhangId))
            {
                txtDengJiRiQi.Value=DateTime.Now.ToString();
                ltrXiangMuOptionHtml.Text = GetXiangMuOptionHtml("");
                ltrZhangHuOptionHtml.Text = GetZhangHuOptionHtml("");
                ltrKeHuTypeHtml.Text = GetKeHuTypeOptions("");
                decimal yuE = new EyouSoft.BLL.FinStructure.BRiJiZhang().GetYuE(CurrentUserCompanyID);
                txtYuE1.Value = yuE.ToString();
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有新增日记账权限";
            }
            else
            {
                var info = new EyouSoft.BLL.FinStructure.BRiJiZhang().GetInfo(RiJiZhangId);
                if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请求异常。"));

                txtDengJiRiQi.Value = info.DengJiRiQi.ToString();
                ltrXiangMuOptionHtml.Text = GetXiangMuOptionHtml(((int)info.XiangMu).ToString());
                txtYeWuRiQi.Value = info.YeWuRiQi;
                txtPingZhengHao.Value = info.PingZhengHao;
                ltrZhangHuOptionHtml.Text = GetZhangHuOptionHtml(info.ZhangHuId);
                ltrKeHuTypeHtml.Text = GetKeHuTypeOptions(((int)info.WangLaiDanWeiLeiXing).ToString());
                switch (info.WangLaiDanWeiLeiXing)
                {
                    case RiJiZhangDanWeiType.供应商:
                        txtGys.HideID = info.WangLaiDanWeiId;
                        txtGys.Name = info.WangLaiDanWei;
                        break;
                    case RiJiZhangDanWeiType.客户单位:
                        txtKeHu.KeHuId = info.WangLaiDanWeiId;
                        txtKeHu.KeHuMingCheng = info.WangLaiDanWei;
                        break;
                    case RiJiZhangDanWeiType.员工:
                        txtYuanGong.SellsID = info.WangLaiDanWeiId;
                        txtYuanGong.SellsName = info.WangLaiDanWei;                        
                        break;
                    default: break;
                }
                txtMingXi.Value = info.MingXi;
                txtJieFangJinE.Value = info.JieFangJinE.ToString("F2");
                txtDaiFangJinE.Value = info.DaiFangJinE.ToString("F2");
                txtYuE1.Value = txtYuE.Value = info.YuE.ToString("F2");

                txtJieFangJinE.Attributes.Add("disabled", "disabled");
                txtDaiFangJinE.Attributes.Add("disabled", "disabled");

                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">修改</a>";
                else ltrOperatorHtml.Text = "你没有修改日记账权限";
            }

            
        }

        /// <summary>
        /// 获取项目下拉菜单项
        /// </summary>
        /// <param name="selectValue">选中的值</param>
        /// <returns></returns>
        protected string GetXiangMuOptionHtml(string selectValue)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EnumObj.GetList(typeof(RiJiZhangXiangMu));

            s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                if ((selectValue == item.Value))
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

        /// <summary>
        /// 获取银行账户下拉菜单项
        /// </summary>
        /// <param name="selectValue">要选中的值</param>
        /// <returns></returns>
        protected string GetZhangHuOptionHtml(string selectValue)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing.收付款账户);

            s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                if (item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 || item.Id == selectValue)
                {
                    if (item.Id ==selectValue)
                    {
                        s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Id, item.BankName + "-" + item.AccountName + "-" + item.BankNo);
                    }
                    else
                    {
                        s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Id, item.BankName + "-" + item.AccountName + "-" + item.BankNo);
                    }
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(RiJiZhangId) && !Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            if (!string.IsNullOrEmpty(RiJiZhangId) && !Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.RiJiId = RiJiZhangId;
            int bllRetCode = 4;

            if (string.IsNullOrEmpty(info.RiJiId))
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BRiJiZhang().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BRiJiZhang().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MRiJiZhangInfo GetFormInfo()
        {
            var info = new MRiJiZhangInfo();
            info.CompanyId = CurrentUserCompanyID;
            info.OperatorId = SiteUserInfo.UserId;
            info.DengJiRiQi  = DateTime.Now;

            info.DaiFangJinE = Utils.GetDecimal(Utils.GetFormValue("txtDaiFangJinE"));
            info.JieFangJinE = Utils.GetDecimal(Utils.GetFormValue("txtJieFangJinE"));
            info.MingXi = Utils.GetFormValue("txtMingXi");
            info.PingZhengHao = Utils.GetFormValue("txtPingZhengHao");
            info.WangLaiDanWei = Utils.GetFormValue("txtWangLaiDanWeiName");
            info.XiangMu = Utils.GetEnumValue<RiJiZhangXiangMu>(Utils.GetFormValue("txtXiangMu"), RiJiZhangXiangMu.其它);
            info.YeWuRiQi1 = Utils.GetDateTime(Utils.GetFormValue("txtYeWuRiQi"), DateTime.Now);
            info.ZhangHuId = Utils.GetFormValue("txtZhangHuId");
            info.WangLaiDanWeiId = Utils.GetFormValue("txtWangLaiDanWeiId");
            info.WangLaiDanWeiLeiXing = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.RiJiZhangDanWeiType>(Utils.GetFormValue("txtWangLaiDanWeiLeiXing"), RiJiZhangDanWeiType.客户单位);
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 获取单位类型Options
        /// </summary>
        /// <param name="selectValue">要选中的值</param>
        /// <returns></returns>
        string GetKeHuTypeOptions(string selectValue)
        {
            if (string.IsNullOrEmpty(selectValue)) selectValue = "0";
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.RiJiZhangDanWeiType));

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
