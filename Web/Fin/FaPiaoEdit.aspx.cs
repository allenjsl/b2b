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
    /// 财务管理-发票新增、修改
    /// </summary>
    public partial class FaPiaoEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 发票编号
        /// </summary>
        string FaPiaoId = string.Empty;
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
            FaPiaoId = Utils.GetQueryStringValue("fapiaoid");
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
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_登记);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_发票管理_修改);

            if (string.IsNullOrEmpty(FaPiaoId))
            {
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有发票登记权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有发票修改权限";
            }
        }

        /// <summary>
        /// 初始化发票信息
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.FinStructure.BFaPiao().GetInfo(FaPiaoId);
            if (info == null) return;

            txtShenQingRiQi.Value = info.ShenQingRiQi.ToString("yyyy-MM-dd");
            txtKeHu.KeHuId = info.KeHuId;
            txtKeHu.KeHuMingCheng = info.KeHuName;

            if (info.Mxs != null && info.Mxs.Count > 0)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(info.Mxs);
                string script = string.Format("var faPiaoMxs={0};", json);

                RegisterScript(script);
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(FaPiaoId)&&!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            if (!string.IsNullOrEmpty(FaPiaoId) && !Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.FaPiaoId = FaPiaoId;

            if (info.Mxs == null || info.Mxs.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：至少要填写一个开票信息。"));

            int bllRetCode = 4;

            if (string.IsNullOrEmpty(FaPiaoId))bllRetCode = new EyouSoft.BLL.FinStructure.BFaPiao().Insert(info);
            else bllRetCode = new EyouSoft.BLL.FinStructure.BFaPiao().Update(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：选择的订单不是该客户单位下的订单"));
            if (bllRetCode == -97) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：选择的订单已经开票"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MFaPiaoInfo GetFormInfo()
        {
            var info = new MFaPiaoInfo();

            info.CompanyId = CurrentUserCompanyID;
            info.FaPiaoHao = string.Empty;
            info.IssueTime = DateTime.Now;
            info.KeHuId = Utils.GetFormValue(txtKeHu.KeHuIdClientName);
            info.Mxs = new List<MFaPiaoMXInfo>();
            info.OperatorId = SiteUserInfo.UserId;
            info.ShenQingRiQi = Utils.GetDateTime(Utils.GetFormValue(txtShenQingRiQi.UniqueID));
            info.TaiTou = string.Empty;
            info.XiangMuMingXi = string.Empty;
            info.KaiJuDanWeiName = string.Empty;

            string[] txt_mx_id = Utils.GetFormValues("txt_mx_id");
            string[] txt_mx_mingxiid = Utils.GetFormValues("txt_mx_mingxiid");
            string[] txt_mx_dingdanid = Utils.GetFormValues("txt_mx_dingdanid");
            string[] txt_mx_dingdanhao = Utils.GetFormValues("txt_mx_dingdanhao");
            string[] txt_mx_qudate = Utils.GetFormValues("txt_mx_qudate");
            string[] txt_mx_jine = Utils.GetFormValues("txt_mx_jine");
            string[] txt_mx_taitou = Utils.GetFormValues("txt_mx_taitou");
            string[] txt_mx_kaipiaodanwei = Utils.GetFormValues("txt_mx_kaipiaodanwei");
            string[] txt_mx_fapiaohao = Utils.GetFormValues("txt_mx_fapiaohao");
            string[] txt_mx_mingxi = Utils.GetFormValues("txt_mx_mingxi");

            int length = txt_mx_id.Length;

            if (length == 0
                || txt_mx_dingdanid.Length != length
                || txt_mx_dingdanhao.Length != length
                || txt_mx_qudate.Length != length
                || txt_mx_jine.Length != length
                || txt_mx_taitou.Length != length
                || txt_mx_kaipiaodanwei.Length != length
                || txt_mx_fapiaohao.Length != length
                || txt_mx_mingxi.Length != length)
                RCWE(UtilsCommons.AjaxReturnJson("-999", "操作失败：请求异常"));

            for (int i = 0; i < length; i++)
            {
                if (string.IsNullOrEmpty(txt_mx_qudate[i])
                    && string.IsNullOrEmpty(txt_mx_dingdanhao[i])
                    && string.IsNullOrEmpty(txt_mx_dingdanid[i])
                    && string.IsNullOrEmpty(txt_mx_fapiaohao[i])
                    && string.IsNullOrEmpty(txt_mx_jine[i])
                    && string.IsNullOrEmpty(txt_mx_kaipiaodanwei[i])
                    && string.IsNullOrEmpty(txt_mx_mingxi[i])
                    //&& string.IsNullOrEmpty(txt_mx_mingxiid[i])
                    //&& string.IsNullOrEmpty(txt_mx_id[i])
                    && string.IsNullOrEmpty(txt_mx_taitou[i])) continue;

                var item = new MFaPiaoMXInfo();

                item.ChuTuanRiQi = Utils.GetDateTime(txt_mx_qudate[i],DateTime.Today);
                item.CompanyId = CurrentUserCompanyID;
                item.DingDanHao = txt_mx_dingdanhao[i];
                item.DingDanId = txt_mx_dingdanid[i];
                item.FaPiaoHao = txt_mx_fapiaohao[i];
                item.JinE = Utils.GetDecimal(txt_mx_jine[i]);
                item.KaiPiaoDanWei = txt_mx_kaipiaodanwei[i];
                item.MingXi = txt_mx_mingxi[i];
                item.MingXiId = txt_mx_mingxiid[i];
                item.MXId = Utils.GetInt(txt_mx_id[i]);
                item.TaiTou = txt_mx_taitou[i];
                item.ZxsId = CurrentZxsId;

                info.Mxs.Add(item);
            }

            info.ZxsId = CurrentZxsId;

            return info;
        }
        #endregion
    }
}
