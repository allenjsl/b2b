//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.CompanyStructure;
using Web.UserControl;
using EyouSoft.Common.Page;
using EyouSoft.Model.EnumType.FinStructure;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-其它收入新增、修改
    /// </summary>
    public partial class QiTaShouRuEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 其它收入编号
        /// </summary>
        string ShouRuId = string.Empty;
        /// <summary>
        /// 其它收入操作权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 收入时间/操作时间
        /// </summary>
        protected string StrShiJian = "收入时间";
        /// <summary>
        /// 控位编号
        /// </summary>
        string KongWeiId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitWuc();

            ShouRuId = Utils.GetQueryStringValue("shouruid");
            KongWeiId = Utils.GetQueryStringValue("KongWeiId");

            InitPrivs();

            if (!string.IsNullOrEmpty(KongWeiId)) StrShiJian = "操作时间";

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// int web user control
        /// </summary>
        void InitWuc()
        {
            
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_项目管理);
        }

        /// <summary>
        /// 初始化其它收入信息
        /// </summary>
        void InitInfo()
        {
            if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有其它收入操作权限";
            ltrKeHuTypeHtml.Text = GetKeHuTypeHtml("");
            ltrXiangMuIdOptions.Text = GetJiChuXinXiOptions(JiChuXinXiType.其它收入项目, string.Empty);

            var info = new EyouSoft.BLL.FinStructure.BQiTaShouRu().GetInfo(ShouRuId);
            if (info == null) return;

            ltrKeHuTypeHtml.Text = GetKeHuTypeHtml(((int)info.KeHuType).ToString());
            txtShiJian.Value = info.ShiJian.ToString("yyyy-MM-dd");
            txtXiangMu.Value = info.XiangMu;
            txtJinE.Value = info.JinE.ToString("F2");
            txtBeiZhu.Value = info.BeiZhu;
            ltrXiangMuIdOptions.Text = GetJiChuXinXiOptions(JiChuXinXiType.其它收入项目, info.XiangMuId.ToString());

            if (info.KeHuType == QiTaShouZhiKeHuType.供应商)
            {
                txtGys.HideID = info.KeHuId;
                txtGys.Name = info.KeHuName;
            }
            else
            {
                txtKeHu.KeHuId = info.KeHuId;
                txtKeHu.KeHuMingCheng = info.KeHuName;
            }

            if (info.IsChongDi)
            {
                ltrOperatorHtml.Text = "该收入项目通过出纳登账冲抵自动登记，无法操作。";
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.ShouRuId = ShouRuId;
            int bllRetCode = 4;

            if (string.IsNullOrEmpty(ShouRuId)) bllRetCode = new EyouSoft.BLL.FinStructure.BQiTaShouRu().Insert(info);
            else bllRetCode = new EyouSoft.BLL.FinStructure.BQiTaShouRu().Update(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：收入金额不能小于已登记的收款金额"));
            else if (bllRetCode == -19) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：控位已核算结束"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MQiTaShouRuInfo GetFormInfo()
        {
            var info = new MQiTaShouRuInfo();

            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.CompanyId = CurrentUserCompanyID;
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.KeHuId = Utils.GetFormValue("txtKeHuId");
            info.KeHuType = Utils.GetEnumValue<QiTaShouZhiKeHuType>(Utils.GetFormValue("txtKeHuType"), QiTaShouZhiKeHuType.客户单位);
            info.KongWeiId = KongWeiId;
            info.OperatorId = SiteUserInfo.UserId;
            info.ShiJian = Utils.GetDateTime(Utils.GetFormValue("txtShiJian"));
            info.XiangMu = Utils.GetFormValue("txtXiangMu");
            info.XiangMuId = Utils.GetInt(Utils.GetFormValue("txtXiangMuId"));
            info.ZxsId = CurrentZxsId;

            return info;
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

        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <param name="jiChuXinXiType">基础信息类型</param>
        /// <param name="_v">选中的值</param>
        /// <returns></returns>
        string GetJiChuXinXiOptions(JiChuXinXiType jiChuXinXiType, string _v)
        {
            StringBuilder s = new StringBuilder();
            var t1 = EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支;
            if (!string.IsNullOrEmpty(KongWeiId)) t1 = QiTaShouZhiT1.团队结算;

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType, t1,CurrentZxsId);

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
        #endregion
    }
}
