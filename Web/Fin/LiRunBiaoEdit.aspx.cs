//汪奇志 2013-02-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-利润表新增、修改
    /// </summary>
    public partial class LiRunBiaoEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 利润编号
        /// </summary>
        string LiRunId = string.Empty;
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
            LiRunId = Utils.GetQueryStringValue("lirunid");

            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();

            if (Utils.GetQueryStringValue("chakan") == "1") ltrOperatorHtml.Visible = false;
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_利润表_修改);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(LiRunId))
            {
                phHistory.Visible = false;
                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有利润表操作权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有利润表操作权限";
            }

            ltrYearOptions.Text = GetYearOptions(string.Empty);
            ltrMonthOptions.Text = GetMonthOptions(string.Empty);

            if (string.IsNullOrEmpty(LiRunId)) return;
            var info = new EyouSoft.BLL.FinStructure.BLiRun().GetInfo(LiRunId);
            if (info == null) return;

            ltrYearOptions.Text = GetYearOptions(info.Year.ToString());
            ltrMonthOptions.Text = GetMonthOptions(info.Month.ToString());
            txtTuanDuiJieSuanMaoLi.Value = info.TuanDuiJieSuanMaoLi.ToString("F2");
            txtBaoXiaoFeiYong.Value = info.BaoXiaoFeiYong.ToString("F2");
            txtYingYeWaiShouRu.Value = info.YingYeWaiShouRu.ToString("F2");
            txtYingYeWaiZhiChu.Value = info.YingYeWaiZhiChu.ToString("F2");
            txtChunLiRun.Value = info.ChunLiRun.ToString("F2");
            txtBeiZhu.Value = info.BeiZhu;

            txtZhuYingYeWuShouRu.Value = info.ZhuYingYeWuShouRu.ToString("F2");
            txtZhuYingYeWuZhiChu.Value = info.ZhuYingYeWuZhiChu.ToString("F2");
            txtDanFangYingShouKuan.Value=info.DanFangYingShouKuan.ToString("F2");
            txtDanDingPiaoYingShouKuan.Value=info.DanDingPiaoYingShouKuan.ToString("F2");
            txtPiaoWuJiuDianYingShouKuan.Value = info.PiaoWuJiuDianYingShouKuan.ToString("F2");
            txtChangGuiLvYouYingShouKuan.Value = info.ChangGuiLvYouYingShouKuan.ToString("F2");
            txtTeShuLvYouYingShouKuan.Value = info.TeShuLvYouYingShouKuan.ToString("F2");
            txtTuiPiaoShouRu.Value = info.TuiPiaoShouRu.ToString("F2");
            txtQiTaZhuYingYeWuShouRu.Value = info.QiTaZhuYingYeWuShouRu.ToString("F2");
            txtDiJieKuan.Value = info.DiJieKuan.ToString("F2");
            txtJiPiaoKuan.Value = info.JiPiaoKuan.ToString("F2");
            txtJiaoTongYaJin.Value = info.JiaoTongYaJin.ToString("F2");
            txtJiuDianKuan.Value = info.JiuDianKuan.ToString("F2");
            txtQiTaZhuYingYeWuZhiChu.Value = info.QiTaZhuYingYeWuZhiChu.ToString("F2");
            txtYingHangLiXiShouRu.Value = info.YingHangLiXiShouRu.ToString("F2");
            txtFangZuShouRu.Value = info.FangZuShouRu.ToString("F2");
            txtGongYingShangFanYong.Value = info.GongYingShangFanYong.ToString("F2");
            txtHaiKouGongSiFanYong.Value = info.HaiKouGongSiFanYong.ToString("F2");
            txtQiTaYingYeWaiShouRu.Value = info.QiTaYingYeWaiShouRu.ToString("F2");
            txtQiTaSunShi.Value = info.QiTaSunShi.ToString("F2");
            txtZhuYingYeWuShouRuBeiZhu.Value = info.ZhuYingYeWuShouRuBeiZhu;
            txtZhuYingYeWuZhiChuBeiZhu.Value = info.ZhuYingYeWuZhiChuBeiZhu;
            txtYingYeWaiShouRuBeiZhu.Value = info.YingYeWaiShouRuBeiZhu;
            txtYingYeWaiZhiChuBeiZhu.Value = info.YingYeWaiZhiChuBeiZhu;
            txtQiTaSunShiBeiZhu.Value = info.QiTaSunShiBeiZhu;

            if (info.Historys != null && info.Historys.Count > 0)
            {
                phEmptyHistory.Visible = false;
                rptHistorys.DataSource = info.Historys;
                rptHistorys.DataBind();
            }
            else
            {
                phEmptyHistory.Visible = true;
            }
        }

        /// <summary>
        /// 获取年份下拉菜单项
        /// </summary>
        /// <param name="v">选中项的值</param>
        /// <returns></returns>
        string GetYearOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 2012;
            int e = DateTime.Now.Year;

            if (string.IsNullOrEmpty(v)) v = e.ToString();

            for (; i <= e; i++)
            {
                if (i.ToString() == v)
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</option>", i);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取月份下拉菜单项
        /// </summary>
        /// <param name="v">选中项的值</param>
        /// <returns></returns>
        string GetMonthOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 1;

            if (string.IsNullOrEmpty(v)) v = DateTime.Now.Month.ToString();

            for (; i <= 12; i++)
            {
                if (i.ToString() == v)
                {
                    s.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i);
                }
                else
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</option>", i);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        MLiRunInfo GetFormInfo()
        {
            MLiRunInfo info = new MLiRunInfo();

            info.BaoXiaoFeiYong = Utils.GetDecimal(Utils.GetFormValue("txtBaoXiaoFeiYong"));
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.ChunLiRun = Utils.GetDecimal(Utils.GetFormValue("txtChunLiRun"));
            info.CompanyId = CurrentUserCompanyID;
            info.Id = LiRunId;
            info.IssueTime = DateTime.Now;
            info.Month = Utils.GetInt(Utils.GetFormValue("txtMonth"));
            info.OperatorId = SiteUserInfo.UserId;
            info.TuanDuiJieSuanMaoLi = Utils.GetDecimal(Utils.GetFormValue("txtTuanDuiJieSuanMaoLi"));
            info.Year = Utils.GetInt(Utils.GetFormValue("txtYear"));
            info.YingYeWaiShouRu = Utils.GetDecimal(Utils.GetFormValue("txtYingYeWaiShouRu"));
            info.YingYeWaiZhiChu = Utils.GetDecimal(Utils.GetFormValue("txtYingYeWaiZhiChu"));

            info.ZhuYingYeWuShouRu = Utils.GetDecimal(Utils.GetFormValue("txtZhuYingYeWuShouRu"));
            info.ZhuYingYeWuZhiChu = Utils.GetDecimal(Utils.GetFormValue("txtZhuYingYeWuZhiChu"));
            info.DanFangYingShouKuan = Utils.GetDecimal(Utils.GetFormValue("txtDanFangYingShouKuan"));
            info.DanDingPiaoYingShouKuan = Utils.GetDecimal(Utils.GetFormValue("txtDanDingPiaoYingShouKuan"));
            info.PiaoWuJiuDianYingShouKuan = Utils.GetDecimal(Utils.GetFormValue("txtPiaoWuJiuDianYingShouKuan"));
            info.ChangGuiLvYouYingShouKuan = Utils.GetDecimal(Utils.GetFormValue("txtChangGuiLvYouYingShouKuan"));
            info.TeShuLvYouYingShouKuan=Utils.GetDecimal(Utils.GetFormValue("txtTeShuLvYouYingShouKuan"));
            info.TuiPiaoShouRu=Utils.GetDecimal(Utils.GetFormValue("txtTuiPiaoShouRu"));
            info.QiTaZhuYingYeWuShouRu=Utils.GetDecimal(Utils.GetFormValue("txtQiTaZhuYingYeWuShouRu"));
            info.DiJieKuan=Utils.GetDecimal(Utils.GetFormValue("txtDiJieKuan"));
            info.JiPiaoKuan=Utils.GetDecimal(Utils.GetFormValue("txtJiPiaoKuan"));
            info.JiaoTongYaJin=Utils.GetDecimal(Utils.GetFormValue("txtJiaoTongYaJin"));
            info.JiuDianKuan=Utils.GetDecimal(Utils.GetFormValue("txtJiuDianKuan"));
            info.QiTaZhuYingYeWuZhiChu=Utils.GetDecimal(Utils.GetFormValue("txtQiTaZhuYingYeWuZhiChu"));
            info.YingHangLiXiShouRu=Utils.GetDecimal(Utils.GetFormValue("txtYingHangLiXiShouRu"));
            info.FangZuShouRu=Utils.GetDecimal(Utils.GetFormValue("txtFangZuShouRu"));
            info.GongYingShangFanYong=Utils.GetDecimal(Utils.GetFormValue("txtGongYingShangFanYong"));
            info.HaiKouGongSiFanYong=Utils.GetDecimal(Utils.GetFormValue("txtHaiKouGongSiFanYong"));
            info.QiTaYingYeWaiShouRu=Utils.GetDecimal(Utils.GetFormValue("txtQiTaYingYeWaiShouRu"));
            info.QiTaSunShi=Utils.GetDecimal(Utils.GetFormValue("txtQiTaSunShi"));
            info.ZhuYingYeWuShouRuBeiZhu=Utils.GetFormValue("txtZhuYingYeWuShouRuBeiZhu");
            info.ZhuYingYeWuZhiChuBeiZhu=Utils.GetFormValue("txtZhuYingYeWuZhiChuBeiZhu");
            info.YingYeWaiShouRuBeiZhu=Utils.GetFormValue("txtYingYeWaiShouRuBeiZhu");
            info.YingYeWaiZhiChuBeiZhu = Utils.GetFormValue("txtYingYeWaiZhiChuBeiZhu");
            info.QiTaSunShiBeiZhu = Utils.GetFormValue("txtQiTaSunShiBeiZhu");

            info.Historys = new List<MLiRunHistoryInfo>();

            string[] txtHTime = Utils.GetFormValues("txtHTime[]");
            string[] txtHXiangMu = Utils.GetFormValues("txtHXiangMu[]");
            string[] txtHNeiRong = Utils.GetFormValues("txtHNeiRong[]");

            int hLength = txtHTime.Length;
            if (txtHXiangMu.Length == hLength && txtHNeiRong.Length == hLength)
            {
                for (int i = 0; i < hLength; i++)
                {
                    if (string.IsNullOrEmpty(txtHNeiRong[i]) 
                        && string.IsNullOrEmpty(txtHXiangMu[i]) 
                        && string.IsNullOrEmpty(txtHTime[i]))
                        continue;

                    var item = new MLiRunHistoryInfo();
                    item.NeiRong = txtHNeiRong[i];
                    item.XiangMu = txtHXiangMu[i];
                    item.Time = Utils.GetDateTime(txtHTime[i], DateTime.Now);
                    item.OperatorId = SiteUserInfo.UserId;

                    info.Historys.Add(item);
                }
            }
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            var info = GetFormInfo();
            info.Id = LiRunId;
            int bllRetCode = 4;
            if (string.IsNullOrEmpty(LiRunId))
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                bllRetCode = new EyouSoft.BLL.FinStructure.BLiRun().Insert(info);
            }
            else
            {
                if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

                info.PageUri = EyouSoft.Toolkit.Utils.GetRequestUrlReferrer();
                bllRetCode = new EyouSoft.BLL.FinStructure.BLiRun().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已经存在相同的利润年月份信息。"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
