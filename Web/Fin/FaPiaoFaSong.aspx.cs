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
    /// 财务管理-设置发票发送状态
    /// </summary>
    public partial class FaPiaoFaSong : BackPage
    {
        #region attributes
        /// <summary>
        /// 发票编号
        /// </summary>
        string FaPiaoId = string.Empty;
        /// <summary>
        /// 设置发票发送状态权限
        /// </summary>
        bool Privs_SetStatus = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            FaPiaoId = Utils.GetQueryStringValue("fapiaoid");

            if (string.IsNullOrEmpty(FaPiaoId)) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：请求异常。"));

            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "setstatus") SetStatus();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_SetStatus = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_发送);

            if (Privs_SetStatus) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有操作权限";
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.FinStructure.BFaPiao().GetInfo(FaPiaoId);

            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-10000", "操作失败：请求异常。"));

            rpts.DataSource = info.Mxs;
            rpts.DataBind();
        }

        /// <summary>
        /// 设置发送状态
        /// </summary>
        void SetStatus()
        {
            if (!Privs_SetStatus) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var mxs = GetFormInfo();
            int bllRetCode = 4;
            bllRetCode = new EyouSoft.BLL.FinStructure.BFaPiao().UpdateMingXis(FaPiaoId, mxs);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        IList<MFaPiaoMXInfo> GetFormInfo()
        {
            IList<MFaPiaoMXInfo> items = new List<MFaPiaoMXInfo>();

            string[] txtMxId = Utils.GetFormValues("txtMxId[]");
            string[] txtStatus = Utils.GetFormValues("txtStatus[]");
            string[] txtFaSongTime = Utils.GetFormValues("txtFaSongTime[]");
            string[] txtFaSongFangShi = Utils.GetFormValues("txtFaSongFangShi[]");
            string[] txtYouJiGongSiName = Utils.GetFormValues("txtYouJiGongSiName[]");
            string[] txtYouJiDanHao = Utils.GetFormValues("txtYouJiDanHao[]");
            string[] txtQianShouRenName = Utils.GetFormValues("txtQianShouRenName[]");
            string[] txtQianShouTime = Utils.GetFormValues("txtQianShouTime[]");


            if (txtMxId.Length == 0 || txtStatus.Length == 0 || txtFaSongTime.Length == 0
                || txtFaSongFangShi.Length == 0 || txtYouJiGongSiName.Length == 0 || txtYouJiDanHao.Length == 0
                || txtQianShouRenName.Length == 0 || txtQianShouTime.Length == 0) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));

            if (txtStatus.Length != txtMxId.Length || txtFaSongTime.Length != txtMxId.Length
                || txtFaSongFangShi.Length != txtMxId.Length || txtYouJiGongSiName.Length != txtMxId.Length || txtYouJiDanHao.Length != txtMxId.Length
                || txtQianShouRenName.Length != txtMxId.Length || txtQianShouTime.Length != txtMxId.Length) RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));

            for (int i = 0; i < txtMxId.Length; i++)
            {
                var item = new MFaPiaoMXInfo();

                item.MXId = Utils.GetInt(txtMxId[i]);
                item.FaSongFangShi = txtFaSongFangShi[i];
                item.FaSongTime = Utils.GetDateTimeNullable(txtFaSongTime[i]);
                item.QianShouRenName = txtQianShouRenName[i];
                item.QianShouTime = Utils.GetDateTimeNullable(txtQianShouTime[i]);
                item.Status = Utils.GetEnumValue<FaPiaoFaSongStatus>(txtStatus[i], FaPiaoFaSongStatus.未送出);
                item.YouJiDanHao = txtYouJiDanHao[i];
                item.YouJiGongSiName = txtYouJiGongSiName[i];
                item.ChuTuanRiQi = DateTime.Now;

                items.Add(item);
            }

            return items;
        }        
        #endregion

        #region protected members
        /// <summary>
        /// 获取发送状态下拉菜单
        /// </summary>
        /// <returns></returns>
        protected string GetStatusOptionHtml(object obj)
        {
            int _status = (int)FaPiaoFaSongStatus.未送出;
            if (obj != null) _status = (int)(FaPiaoFaSongStatus)obj;


            System.Text.StringBuilder s = new System.Text.StringBuilder();
            var items = EnumObj.GetList(typeof(FaPiaoFaSongStatus));

            //s.Append("<option value=\"\">请选择</option>");

            if (items == null || items.Count == 0) return s.ToString();

            foreach (var item in items)
            {
                if ((_status.ToString() == item.Value))
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
