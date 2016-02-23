using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Web.UserControl;

namespace Web.PingTai
{
    /// <summary>
    /// 积分兑换订单-发货
    /// </summary>
    public partial class JiFenDingDanFaHuoEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 积分兑换订单编号
        /// </summary>
        string DingDanId = string.Empty;
        /// <summary>
        /// 订单管理权限
        /// </summary>
        bool Privs_DingDanGuanLi = false;

        protected string FuKuanFangShi = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("dingdanid");
            if (string.IsNullOrEmpty(DingDanId)) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "baocun": BaoCun(); break;
                case "quxiaofahuo": QuXiaoFaHuo(); break;
                default: break;
            }

            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_DingDanGuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换订单管理_订单管理);

            if (Privs_DingDanGuanLi) ltrOperatorHtml.Text = "<td width=\"100\" align=\"center\" class=\"tjbtn02\" ><a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a></td>";
            else ltrOperatorHtml.Text = "你没有操作权限";
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(DingDanId)) return;

            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            if (info.Status == EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货)
            {
                txtKuaiDi.Value = info.KuaiDi;
                txtFuKuanShiJian.Value = info.FuKuanShiJian.Value.ToString("yyyy-MM-dd");
                txtFuKuanJinE.Value = info.FuKuanJinE.ToString("F2");
                FuKuanFangShi = ((int)info.FuKuanFangShi).ToString();
                txtFuKuanZhangHao.Value = info.FuKuanZhangHao;
                txtDuiFangDanWei.Value = info.FuKuanDuiFangDanWei;
                txtFuKuanBeiZhu.Value = info.FuKuanBeiZhu;

                if (Privs_DingDanGuanLi) ltrOperatorHtml.Text = "<td width=\"100\" align=\"center\" class=\"tjbtn02\" ><a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a></td><td width=\"100\" align=\"center\" class=\"tjbtn02\" ><a href=\"javascript:void(0)\" id=\"i_a_quxiaofahuo\">取消发货</a></td>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }

            if (info.FuKuanStatus != EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批)
            {
                var zhiFuRenInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(info.FuKuanZhiFuRenId.Value);
                string zhiFuRenName = string.Empty;

                if (zhiFuRenInfo != null && zhiFuRenInfo.PersonInfo != null) zhiFuRenName = zhiFuRenInfo.PersonInfo.ContactName;

                ltrOperatorHtml.Text = "该兑换订单商品已支付，支付人：" + zhiFuRenName + "，支付时间：" + info.FuKuanZhiFuShiJian.Value.ToString("yyyy-MM-dd")+"。";
            }
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiFenDingDanInfo GetFormInfo()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);

            info.KuaiDi = Utils.GetFormValue(txtKuaiDi.UniqueID);
            info.FuKuanShiJian = Utils.GetDateTimeNullable(Utils.GetFormValue(txtFuKuanShiJian.UniqueID));
            info.FuKuanJinE = Utils.GetDecimal(Utils.GetFormValue(txtFuKuanJinE.UniqueID));
            info.FuKuanFangShi = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi>(Utils.GetFormValue("txtFuKuanFangShi"), EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi.财务现付);
            info.FuKuanZhangHao = Utils.GetFormValue(txtFuKuanZhangHao.UniqueID);
            info.FuKuanDuiFangDanWei = Utils.GetFormValue(txtDuiFangDanWei.UniqueID);
            info.FuKuanBeiZhu = Utils.GetFormValue(txtFuKuanBeiZhu.UniqueID);

            info.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货;
            info.LatestTime = DateTime.Now;
            info.LatestOperatorId = SiteUserInfo.UserId;

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            if (!Privs_DingDanGuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = GetFormInfo();

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanStatus(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消发货
        /// </summary>
        void QuXiaoFaHuo()
        {
            if (!Privs_DingDanGuanLi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            var info = GetFormInfo();
            info.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已确认;

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanStatus(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：该兑换订单付款金额已支付，不能取消发货"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
