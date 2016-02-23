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
    /// 财务管理-资产负债表新增、修改
    /// </summary>
    public partial class ZiChanFuZhaiBiaoEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 资产负债编号
        /// </summary>
        string ZiChanFuZhaiId = string.Empty;
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
            ZiChanFuZhaiId = Utils.GetQueryStringValue("zichanfuzhaiid");

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
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_修改);
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(ZiChanFuZhaiId))
            {
                phHistory.Visible = false;

                if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有资产负债表操作权限";
            }
            else
            {
                if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有资产负债表操作权限";
            }


            ltrYearOptions.Text = GetYearOptions(string.Empty);
            ltrMonthOptions.Text = GetMonthOptions(string.Empty);

            if (string.IsNullOrEmpty(ZiChanFuZhaiId)) return;
            var info = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().GetInfo(ZiChanFuZhaiId);
            if (info == null) return;

            ltrYearOptions.Text = GetYearOptions(info.Year.ToString());
            ltrMonthOptions.Text = GetMonthOptions(info.Month.ToString());
            txtHuoBiZiJin.Value = info.HuoBiZiJin.ToString("F2");
            txtYingShouZhangKuan.Value = info.YingShouZhangKuan.ToString("F2");
            txtQiTaYingShouKuan.Value = info.QiTaYingShouKuan.ToString("F2");
            txtYuFuZhangKuan.Value = info.YuFuZhangKuan.ToString("F2");
            txtQiTaYuFu.Value = info.QiTaYuFu.ToString("F2");

            txtYingFuZhangKuan.Value = info.YingFuZhangKuan.ToString("F2");
            txtQiTaYingFuKuan.Value = info.QiTaYingFuKuan.ToString("F2");
            txtYuShouZhangKuan.Value = info.YuShouZhangKuan.ToString("F2");
            txtQiTaYuShou.Value = info.QiTaYuShou.ToString("F2");
            txtShiShouGuBen.Value = info.ShiShouGuBen.ToString("F2");
            txtWeiFenPeiLiRun.Value = info.WeiFenPeiLiRun.ToString("F2");
            txtChaE.Value = info.ChaE.ToString("F2");

            txtYingShouTuanKuan.Value = info.YingShouTuanKuan.ToString("F2");
            txtYingShouYaJinTuiKuan.Value = info.YingShouYaJinTuiKuan.ToString("F2");
            txtYingShouJiuDianTuiKuan.Value = info.YingShouJiuDianTuiKuan.ToString("F2");
            txtYingShouTuiPiaoKuan.Value = info.YingShouTuiPiaoKuan.ToString("F2");
            txtYingShouQiTa.Value = info.YingShouQiTa.ToString("F2");
            txtZhiLiangBaoZhengJin.Value = info.ZhiLiangBaoZhengJin.ToString("F2");
            txtGeRenJieKuan.Value = info.GeRenJieKuan.ToString("F2");
            txtGongYingShangYaJin.Value = info.GongYingShangYaJin.ToString("F2");
            txtJiuDianYaJin.Value = info.JiuDianYaJin.ToString("F2");
            txtZuTuanSheYaJin.Value = info.ZuTuanSheYaJin.ToString("F2");
            txtQTYSQiTa.Value = info.QTYSQiTa.ToString("F2");
            txtYuFuDiJieKuan.Value = info.YuFuDiJieKuan.ToString("F2");
            txtYuFuJiPiaoKuan.Value = info.YuFuJiPiaoKuan.ToString("F2");
            txtYuFuJiaoTongYaJinKuan.Value = info.YuFuJiaoTongYaJinKuan.ToString("F2");
            txtYuFuJiuDianKuan.Value = info.YuFuJiuDianKuan.ToString("F2");
            txtYingFuDiJieKuan.Value = info.YingFuDiJieKuan.ToString("F2");
            txtYingFuJiPiaoKuan.Value = info.YingFuJiPiaoKuan.ToString("F2");
            txtYingFuJiuDianKuan.Value = info.YingFuJiuDianKuan.ToString("F2");
            txtYuShouTuanKuan.Value = info.YuShouTuanKuan.ToString("F2");
            txtYuShouTuiPiaoKuan.Value = info.YuShouTuiPiaoKuan.ToString("F2");
            txtZanShiJieKuan.Value = info.ZanShiJieKuan.ToString("F2");
            txtLeiJiWeiFenPeiLiRun.Value = info.LeiJiWeiFenPeiLiRun.ToString("F2");
            txtBenYueWeiFenPeiLiRun.Value = info.BenYueWeiFenPeiLiRun.ToString("F2");
            txtYingShouZhangKuanBeiZhu.Value = info.YingShouZhangKuanBeiZhu;
            txtQiTaYingShouKuanBeiZhu.Value = info.QiTaYingShouKuanBeiZhu;
            txtYuFuZhangKuanBeiZhu.Value = info.YuFuZhangKuanBeiZhu;
            txtYingFuZhangKuanBeiZhu.Value = info.YingFuZhangKuanBeiZhu;
            txtYuShouZhangKuanBeiZhu.Value = info.YuShouZhangKuanBeiZhu;
            txtShiShouGuBenBeiZhu.Value = info.ShiShouGuBenBeiZhu;

            txtBeiZhu.Value = info.BeiZhu;

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
        MZiChanFuZhaiInfo GetFormInfo()
        {
            MZiChanFuZhaiInfo info = new MZiChanFuZhaiInfo();
           
            info.BeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.CompanyId = CurrentUserCompanyID;
            info.Id = ZiChanFuZhaiId;
            info.IssueTime = DateTime.Now;
            info.Month = Utils.GetInt(Utils.GetFormValue("txtMonth"));
            info.OperatorId = SiteUserInfo.UserId;
            info.Year = Utils.GetInt(Utils.GetFormValue("txtYear"));
            info.HuoBiZiJin = Utils.GetDecimal(Utils.GetFormValue("txtHuoBiZiJin"));
            info.YingShouZhangKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingShouZhangKuan"));
            info.QiTaYingShouKuan = Utils.GetDecimal(Utils.GetFormValue("txtQiTaYingShouKuan"));
            info.YuFuZhangKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuFuZhangKuan"));
            info.QiTaYuFu = Utils.GetDecimal(Utils.GetFormValue("txtQiTaYuFu"));
            info.YingFuZhangKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingFuZhangKuan"));
            info.QiTaYingFuKuan = Utils.GetDecimal(Utils.GetFormValue("txtQiTaYingFuKuan"));
            info.YuShouZhangKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuShouZhangKuan"));
            info.QiTaYuShou = Utils.GetDecimal(Utils.GetFormValue("txtQiTaYuShou"));
            info.ShiShouGuBen = Utils.GetDecimal(Utils.GetFormValue("txtShiShouGuBen"));
            info.WeiFenPeiLiRun = Utils.GetDecimal(Utils.GetFormValue("txtWeiFenPeiLiRun"));
            info.ChaE = Utils.GetDecimal(Utils.GetFormValue("txtChaE"));

            info.YingShouTuanKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingShouTuanKuan"));
            info.YingShouYaJinTuiKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingShouYaJinTuiKuan"));
            info.YingShouJiuDianTuiKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingShouJiuDianTuiKuan"));
            info.YingShouTuiPiaoKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingShouTuiPiaoKuan"));
            info.YingShouQiTa = Utils.GetDecimal(Utils.GetFormValue("txtYingShouQiTa"));
            info.ZhiLiangBaoZhengJin = Utils.GetDecimal(Utils.GetFormValue("txtZhiLiangBaoZhengJin"));
            info.GeRenJieKuan = Utils.GetDecimal(Utils.GetFormValue("txtGeRenJieKuan"));
            info.GongYingShangYaJin = Utils.GetDecimal(Utils.GetFormValue("txtGongYingShangYaJin"));
            info.JiuDianYaJin = Utils.GetDecimal(Utils.GetFormValue("txtJiuDianYaJin"));
            info.ZuTuanSheYaJin = Utils.GetDecimal(Utils.GetFormValue("txtZuTuanSheYaJin"));
            info.QTYSQiTa = Utils.GetDecimal(Utils.GetFormValue("txtQTYSQiTa"));
            info.YuFuDiJieKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuFuDiJieKuan"));
            info.YuFuJiPiaoKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuFuJiPiaoKuan"));
            info.YuFuJiaoTongYaJinKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuFuJiaoTongYaJinKuan"));
            info.YuFuJiuDianKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuFuJiuDianKuan"));
            info.YingFuDiJieKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingFuDiJieKuan"));
            info.YingFuJiPiaoKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingFuJiPiaoKuan"));
            info.YingFuJiuDianKuan = Utils.GetDecimal(Utils.GetFormValue("txtYingFuJiuDianKuan"));
            info.YuShouTuanKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuShouTuanKuan"));
            info.YuShouTuiPiaoKuan = Utils.GetDecimal(Utils.GetFormValue("txtYuShouTuiPiaoKuan"));
            info.ZanShiJieKuan = Utils.GetDecimal(Utils.GetFormValue("txtZanShiJieKuan"));
            info.LeiJiWeiFenPeiLiRun = Utils.GetDecimal(Utils.GetFormValue("txtLeiJiWeiFenPeiLiRun"));
            info.BenYueWeiFenPeiLiRun = Utils.GetDecimal(Utils.GetFormValue("txtBenYueWeiFenPeiLiRun"));
            info.YingShouZhangKuanBeiZhu =Utils.GetFormValue("txtYingShouZhangKuanBeiZhu");
            info.QiTaYingShouKuanBeiZhu =Utils.GetFormValue("txtQiTaYingShouKuanBeiZhu");
            info.YuFuZhangKuanBeiZhu =Utils.GetFormValue("txtYuFuZhangKuanBeiZhu");
            info.YingFuZhangKuanBeiZhu =Utils.GetFormValue("txtYingFuZhangKuanBeiZhu");
            info.YuShouZhangKuanBeiZhu =Utils.GetFormValue("txtYuShouZhangKuanBeiZhu");
            info.ShiShouGuBenBeiZhu =Utils.GetFormValue("txtShiShouGuBenBeiZhu");

            info.Historys = new List<MZiChanFuZhaiHistoryInfo>();

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

                    var item = new MZiChanFuZhaiHistoryInfo();
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
            info.Id = ZiChanFuZhaiId;
            int bllRetCode = 4;
            if (string.IsNullOrEmpty(ZiChanFuZhaiId))
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                bllRetCode = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().Insert(info);
            }
            else
            {
                if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

                info.PageUri = EyouSoft.Toolkit.Utils.GetRequestUrlReferrer();
                bllRetCode = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已经存在相同的资产负债年月份信息。"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
