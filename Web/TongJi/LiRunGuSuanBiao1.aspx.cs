using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.TongJi
{
    /// <summary>
    /// 统计分析-利润估算表一
    /// </summary>
    public partial class LiRunGuSuanBiao1 : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        int CX_Year1 = 0;
        int CX_Year2 = 0;
        int CX_Month1 = 0;
        int CX_Month2 = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            InitYear();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_利润估算表一_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            var time1 = new DateTime(CX_Year1, CX_Month1, 1);
            var time2 = new DateTime(CX_Year2, CX_Month2, 1).AddMonths(1).AddDays(-1);

            if (CX_Year2 - CX_Year1 > 3)
            {
                ltrBiaoTi.Text = "一次最多只能统计48个月的利润估算信息，请重新选择查询条件。";
                phTongJiBiao.Visible = false;
                return;
            }

            var items = new EyouSoft.BLL.TongJiStructure.BLiRun().GetLiRunGuSuanBiao1s(CurrentUserCompanyID, CurrentZxsId, time1, time2);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                phEmpty.Visible = false;
                phHeJi.Visible = true;

                decimal jieSuanShouRuJinEHeJi = 0;
                decimal jieSuanZhiChuJinEHeJi = 0;
                decimal yingYeWaiShouRuJinEHeJi = 0;
                decimal baoXiaoJinJinEHeJi = 0;
                decimal gongZiJinEJinEHeJi = 0;
                decimal jieSuanMaoLiJinEHeJi = 0;
                decimal liRunHeJi = 0;

                foreach (var item in items)
                {
                    jieSuanShouRuJinEHeJi += item.JieSuanShouRuJinE;
                    jieSuanZhiChuJinEHeJi += item.JieSuanZhiChuJinE;
                    yingYeWaiShouRuJinEHeJi += item.YingYeWaiShouRuJinE;
                    baoXiaoJinJinEHeJi += item.BaoXiaoJinE;
                    gongZiJinEJinEHeJi += item.GongZiJinE;

                    jieSuanMaoLiJinEHeJi += item.JieSuanMaoLiJinE;
                    liRunHeJi += item.LiRun;
                }

                ltrJieSuanShouRuJinEHeJi.Text = jieSuanShouRuJinEHeJi.ToString("F2");
                ltrJieSuanZhiChuJinEHeJi.Text = jieSuanZhiChuJinEHeJi.ToString("F2");
                ltrJieSuanMaoLiJinEHeJi.Text = jieSuanMaoLiJinEHeJi.ToString("F2");
                ltrYingYeWaiShouRuJinEHeJi.Text = yingYeWaiShouRuJinEHeJi.ToString("F2");
                ltrBaoXiaoJinEHeJi.Text = baoXiaoJinJinEHeJi.ToString("F2");
                ltrGongZiJinEHeJi.Text = gongZiJinEJinEHeJi.ToString("F2");
                ltrLiRunHeJi.Text = liRunHeJi.ToString("F2");

            }
            else
            {
                phEmpty.Visible = true;
                phHeJi.Visible = false;
            }
        }

        /// <summary>
        /// init year
        /// </summary>
        void InitYear()
        {
            CX_Year1 = Utils.GetInt(Utils.GetQueryStringValue("txtYear1"));
            CX_Year2 = Utils.GetInt(Utils.GetQueryStringValue("txtYear2"));
            CX_Month1 = Utils.GetInt(Utils.GetQueryStringValue("txtMonth1"));
            CX_Month2 = Utils.GetInt(Utils.GetQueryStringValue("txtMonth2"));


            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();
            StringBuilder s3 = new StringBuilder();
            StringBuilder s4 = new StringBuilder();

            int _year = DateTime.Now.Year;

            if (CX_Year1 <= 2000 || CX_Year1 > _year + 3) CX_Year1 = _year;
            if (CX_Year2 <= 2000 || CX_Year2 > _year + 3) CX_Year2 = _year;
            if (CX_Year2 < CX_Year1) CX_Year2 = CX_Year1;
            if (CX_Month1 <= 0 || CX_Month1 > 12) CX_Month1 = 1;
            if (CX_Month2 <= 0 || CX_Month2 > 12) CX_Month2 = 12;


            for (int i = 2012; i < _year + 3; i++)
            {
                if (i == CX_Year1)
                {
                    s1.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}年</option>", i);
                }
                else
                {
                    s1.AppendFormat("<option value=\"{0}\">{0}年</option>", i);
                }

                if (i == CX_Year2)
                {
                    s2.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}年</option>", i);
                }
                else
                {
                    s2.AppendFormat("<option value=\"{0}\">{0}年</option>", i);
                }
            }

            for (int i = 1; i <= 12; i++)
            {
                if (i == CX_Month1)
                {
                    s3.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}月</option>", i);
                }
                else
                {
                    s3.AppendFormat("<option value=\"{0}\">{0}月</option>", i);
                }

                if (i == CX_Month2)
                {
                    s4.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}月</option>", i);
                }
                else
                {
                    s4.AppendFormat("<option value=\"{0}\">{0}月</option>", i);
                }
            }

            ltrYearOption1.Text = s1.ToString();
            ltrYearOption2.Text = s2.ToString();
            ltrMonthOption1.Text = s3.ToString();
            ltrMonthOption2.Text = s4.ToString();

            ltrBiaoTi.Text = string.Format("{0}年{1}月至{2}年{3}月利润估算表", CX_Year1, CX_Month1, CX_Year2, CX_Month2);
        }
        #endregion

    }
}
