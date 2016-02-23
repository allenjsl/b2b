using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.FinStructure;
using System.Text;

namespace Web.Fin
{
    public partial class GongZi : BackPage
    {

        #region attributes
        protected int pageSize = 20, pageIndex = 1, recordCount = 0;        
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        protected bool Privs_Insert = false;
        /// <summary>
        /// 查看全部权限
        /// </summary>
        bool Privs_ChaKanQuanBu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            if (Utils.GetQueryStringValue("doType") == "delete") Delete();
            initList();
        }

        #region   private members
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex("page");
            var chaXun = new EyouSoft.Model.FinStructure.MGongZiChaXunInfo();
            chaXun.SYear = Utils.GetIntNull(Utils.GetQueryStringValue("txtSYear"));
            chaXun.SMonth = Utils.GetIntNull(Utils.GetQueryStringValue("txtSMonth"));
            chaXun.YuanGongName = Utils.GetQueryStringValue("txt_userName");
            chaXun.EYear = Utils.GetIntNull(Utils.GetQueryStringValue("txtEYear"));
            chaXun.EMonth = Utils.GetIntNull(Utils.GetQueryStringValue("txtEMonth"));
            chaXun.FaFangLeiXing = (EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing), Utils.GetQueryStringValue("txtFaFangLeiXing"));

            if (!Privs_ChaKanQuanBu)
            {
                chaXun.YuanGongId = SiteUserInfo.UserId;
            }

            chaXun.Status = (EyouSoft.Model.EnumType.FinStructure.GongZiStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.FinStructure.GongZiStatus), Utils.GetQueryStringValue("txtStatus"));
            chaXun.ZxsId = CurrentZxsId;

            EyouSoft.Model.FinStructure.MGongZiHeJiInfo heJi;
            var items = new EyouSoft.BLL.FinStructure.BGongZi().GetGongZis(SiteUserInfo.CompanyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();
                rpts.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;


                ltrJiBenGongZiHeJi.Text = ToMoneyString(heJi.JiBenGongZi);
                ltrGongLingBuTieHeJi.Text = ToMoneyString(heJi.GongLingBuTie);
                ltrShengHuoFeiBuTieHeJi.Text = ToMoneyString(heJi.ShengHuoFeiBuTie);
                ltrSheBaoBuTieHeJi.Text = ToMoneyString(heJi.SheBaoBuTie);
                ltrGangWeiBuTieHeJi.Text = ToMoneyString(heJi.GangWeiBuTie);
                ltrJiDuJiangJinHeJi.Text = ToMoneyString(heJi.JiDuJiangJin);
                ltrSheBaoKouChuHeJi.Text = ToMoneyString(heJi.SheBaoKouChu);
                ltrGongZiHeJiHeJi.Text = ToMoneyString(heJi.GongZiHeJi);
                ltrShengHuoFeiKouChuHeJi.Text = ToMoneyString(heJi.ShengHuoFeiKouChu);
                ltrChiDaoKouChuHeJi.Text = ToMoneyString(heJi.ChiDaoKouChu);
                ltrQiTaKouChuHeJi.Text = ToMoneyString(heJi.QiTaKouChu);
                ltrShiFaGongZiHeJi.Text = ToMoneyString(heJi.ShiFaGongZi);
            }
            else
            {
                rpts.Visible = phPaging.Visible = phHeJi.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetStatus(object status)
        {
            string s = string.Empty;
            GongZiStatus _status = (GongZiStatus)status;

            switch (_status)
            {
                case GongZiStatus.未审批: s = "<a href=\"javascript:void(0)\" class=\"i_shenpi\">未审批</a>"; break;
                case GongZiStatus.未支付: s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\">未支付</a>"; break;
                case GongZiStatus.已支付: s = "<a href=\"javascript:void(0)\" class=\"i_zhifu\">已支付</a>"; break;
                default: break;
            }

            return s.ToString();
        }

        /// <summary>
        /// 删除工资信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string gzid = Utils.GetFormValue("gongzi");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().Delete(CurrentUserCompanyID, gzid);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_新增);

            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_删除);
            phInsert.Visible = Privs_Insert;

            Privs_ChaKanQuanBu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_查看全部);
        }
        #endregion

        #region protect members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            string s = string.Empty;
            GongZiStatus _status = (GongZiStatus)status;

            if (_status == GongZiStatus.未审批)
            {
                if (Privs_Insert) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
                else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

                if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";
            }
            else
            {
                s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";
            }

            return s.ToString();
        }

        /// <summary>
        /// 获取年份下拉菜单项
        /// </summary>
        /// <param name="v">选中项的值</param>
        /// <returns></returns>
        protected string GetYearOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 2012;
            int e = DateTime.Now.Year;

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
        protected string GetMonthOptions(string v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</option>");
            int i = 1;

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
        #endregion
    }
}
