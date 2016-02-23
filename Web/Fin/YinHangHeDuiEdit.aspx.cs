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
    /// 财务管理-银行核对新增、修改
    /// </summary>
    public partial class YinHangHeDuiEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 核对编号
        /// </summary>
        string HeDuiId = string.Empty;
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
            HeDuiId = Utils.GetQueryStringValue("heduiid");
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
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_登记);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行核对表_修改);
        }

        /// <summary>
        /// 初始化银行核对信息
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(HeDuiId))
            {
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有新增银行核对信息权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有修改银行核对信息权限";
            }

            var info = new EyouSoft.BLL.FinStructure.BYinHangHeDui().GetInfo(HeDuiId, CurrentUserCompanyID);
            if (info == null)
            {
                rpts.DataSource = GetYinHangHeDuiZhangHus();
                rpts.DataBind();
                return;
            } 

            rpts.DataSource = info.ZhangHus;
            rpts.DataBind();

            txtYeWuRiQi.Value = info.YeWuRiQi.ToString("yyyy-MM-dd");
            txtLiuShuiZongE.Value = info.LiuShuiZongE.ToString("F2");

            switch (info.Status)
            {
                case YinHangHeDuiStatus.未确认:                    
                    break;
                case YinHangHeDuiStatus.已确认:
                    ltrOperatorHtml.Text = "银行核对信息已确认";
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(HeDuiId) && !Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            if (!string.IsNullOrEmpty(HeDuiId) && !Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.HeDuiId = HeDuiId;
            int bllRetCode = 4;
            if (string.IsNullOrEmpty(HeDuiId))
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BYinHangHeDui().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BYinHangHeDui().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经存在相同的业务日期"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MYinHangHeDuiInfo GetFormInfo()
        {
            var info = new MYinHangHeDuiInfo();

            info.CompanyId = CurrentUserCompanyID;
            info.LiuShuiZongE = Utils.GetDecimal(Utils.GetFormValue("txtLiuShuiZongE"));
            info.OperatorId = SiteUserInfo.UserId;
            info.YeWuRiQi = Utils.GetDateTime(Utils.GetFormValue("txtYeWuRiQi"));
            info.ZhangHus = new List<MYinHangHeDuiZhangHuInfo>();

            string[] txtZhangHuId = Utils.GetFormValues("txtZhangHuId[]");
            string[] txtYuE = Utils.GetFormValues("txtYuE[]");
            string[] txtDaiFangJinE = Utils.GetFormValues("txtDaiFangJinE[]");
            string[] txtJieFangJinE = Utils.GetFormValues("txtJieFangJinE[]");

            if (txtZhangHuId.Length == 0
                || txtYuE.Length == 0
                || txtDaiFangJinE.Length == 0
                || txtJieFangJinE.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));
            if (txtZhangHuId.Length != txtYuE.Length) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));
            if (txtZhangHuId.Length != txtDaiFangJinE.Length) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));
            if (txtZhangHuId.Length != txtDaiFangJinE.Length) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));

            for (int i = 0; i < txtYuE.Length; i++)
            {
                var item = new MYinHangHeDuiZhangHuInfo();

                item.ZhangHuId = txtZhangHuId[i];
                item.YuE = Utils.GetDecimal(txtYuE[i]);
                item.JieFangJinE = Utils.GetDecimal(txtJieFangJinE[i]);
                item.DaiFangJinE = Utils.GetDecimal(txtDaiFangJinE[i]);

                info.ZhangHus.Add(item);
            }

            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 获取银行核对账户信息
        /// </summary>
        /// <returns></returns>
        IList<MYinHangHeDuiZhangHuInfo> GetYinHangHeDuiZhangHus()
        {
            IList<MYinHangHeDuiZhangHuInfo> items = new List<MYinHangHeDuiZhangHuInfo>();

            var _items = new EyouSoft.BLL.FinStructure.BYinHangZhangHu().GetZhangHus(CurrentUserCompanyID, CurrentZxsId, YinHangZhangHuLeiXing.收付款账户);

            if (_items != null && _items.Count > 0)
            {
                foreach (var _item in _items)
                {
                    if (_item.AccountState == EyouSoft.Model.EnumType.CompanyStructure.AccountState.未审批) continue;

                    var item = new MYinHangHeDuiZhangHuInfo();

                    item.ZhangHuId = _item.Id;
                    item.ZhangHuName = _item.AccountName;
                    item.YinHangName = _item.BankName;
                    item.ZhangHao = _item.BankNo;

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取金额
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetJinE(object obj)
        {
            if (obj == null) return string.Empty;

            decimal jinE = Utils.GetDecimal(obj.ToString());

            if (jinE == 0) return string.Empty;

            return jinE.ToString("F2");
        }
        #endregion
    }
}
