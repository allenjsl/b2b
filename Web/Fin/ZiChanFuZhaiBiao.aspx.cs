//汪奇志 2013-02-04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Model.FinStructure;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-资产负债表
    /// </summary>
    public partial class ZiChanFuZhaiBiao : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_Delete = false;
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

            if (Utils.GetQueryStringValue("doType") == "delete") Delete();
            if (UtilsCommons.IsToXls()) ToXls();

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_栏目, true);
                }
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_修改);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_资产负债表_删除);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            object[] heJi;
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().GetZiChanFuZhais(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrHuoBiZiJinHeJi.Text = ToMoneyString(heJi[0]);
                ltrYingShouZhangKuanHeJi.Text = ToMoneyString(heJi[1]);
                ltrQiTaYingShouKuanHeJi.Text = ToMoneyString(heJi[2]);
                ltrYuFuZhangKuanHeJi.Text = ToMoneyString(heJi[3]);
                ltrYingFuZhangKuanHeJi.Text = ToMoneyString(heJi[4]);
                ltrYuShouZhangKuanHeJi.Text = ToMoneyString(heJi[5]);
                ltrShiShouGuBenHeJi.Text = ToMoneyString(heJi[6]);
                ltrWeiFenPeiLiRunHeJi.Text = ToMoneyString(heJi[7]);
                ltrChaEHeJi.Text = ToMoneyString(heJi[8]);

                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MZiChanFuZhaiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MZiChanFuZhaiChaXunInfo();

            info.Year = Utils.GetIntNull(Utils.GetQueryStringValue("txtYear"));
            info.Month = Utils.GetIntNull(Utils.GetQueryStringValue("txtMonth"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 删除资产负债表信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string ziChanFuZhaiId = Utils.GetFormValue("txtZiChanFuZhaiId");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().Delete(ziChanFuZhaiId, CurrentUserCompanyID);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// ToXls
        /// </summary>
        private void ToXls()
        {
            StringBuilder s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            var chaXun = GetChaXunInfo();
            object[] heJi;
            var items = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().GetZiChanFuZhais(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, chaXun, out heJi);

            if (items == null || items.Count == 0) ResponseToXls(string.Empty);

            int i = 1;
            s.Append("序号\t年月\t货币资金\t应收帐款\t其他应收款\t预付款\t应付帐款\t预收帐款\t实收股本\t未分配利润\t差额\n");
            foreach (var item in items)
            {
                s.Append(i + "\t");
                s.Append(item.YMD.ToString("yyyy-MM") + "\t");
                s.Append(item.HuoBiZiJin.ToString("F2") + "\t");
                s.Append(item.YingShouZhangKuan.ToString("F2") + "\t");
                s.Append(item.QiTaYingShouKuan.ToString("F2") + "\t");
                s.Append(item.YuFuZhangKuan.ToString("F2") + "\t");
                s.Append(item.YingFuZhangKuan.ToString("F2") + "\t");
                s.Append(item.YuShouZhangKuan.ToString("F2") + "\t");
                s.Append(item.ShiShouGuBen.ToString("F2") + "\t");
                s.Append(item.WeiFenPeiLiRun.ToString("F2") + "\t");
                s.Append(item.ChaE.ToString("F2") + "\n");
                i++;
            }

            ResponseToXls(s.ToString());
        }

        /*/// <summary>
        /// ToXls
        /// </summary>
        private void ToXls1()
        {
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            var chaXun = GetChaXunInfo();
            object[] heJi;
            var items = new EyouSoft.BLL.FinStructure.BZiChanFuZhai().GetZiChanFuZhais(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, chaXun, out heJi);

            if (items == null || items.Count == 0) ResponseToXls(string.Empty);

            ApplicationClass xlsApp = new ApplicationClass();
            if (xlsApp == null) throw new Exception("未安装Excel");

            Workbook workbook = xlsApp.Workbooks.Open(Utils.GetMapPath("/PrintTemplate/zichanfuzhaibiao.xls"), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Worksheet worksheet = workbook.Sheets[1] as Worksheet;

            for (int i = 0; i < items.Count; i++)
            {
                worksheet.Cells[i + 3, 1] = i + 1;
                worksheet.Cells[i + 3, 2] = items[i].YMD.ToString("yyyy-MM");
                worksheet.Cells[i + 3, 3] = items[i].HuoBiZiJin;
                worksheet.Cells[i + 3, 4] = items[i].YingShouZhangKuan;
                worksheet.Cells[i + 3, 5] = items[i].QiTaYingShouKuan;
                worksheet.Cells[i + 3, 6] = items[i].YuFuZhangKuan;
                worksheet.Cells[i + 3, 7] = items[i].YingFuZhangKuan;
                worksheet.Cells[i + 3, 8] = items[i].YuShouZhangKuan;
                worksheet.Cells[i + 3, 9] = items[i].ShiShouGuBen;
                worksheet.Cells[i + 3, 10] = items[i].WeiFenPeiLiRun;
                worksheet.Cells[i + 3, 11] = items[i].ChaE;
            }

            workbook.Saved = true;

            string path = "/Temp/ZiChanFuZhaiBiao/" + DateTime.Now.ToString("yyyyMM");
            string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            string filePath = path + "/" + fileName;
            string directory = Server.MapPath(path);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            workbook.SaveCopyAs(Utils.GetMapPath(filePath));
            workbook.Close(true, Type.Missing, Type.Missing);
            xlsApp.Quit();
            worksheet = null;
            workbook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            //var generation = System.GC.GetGeneration(xlsApp);
            //System.GC.Collect(generation);
            xlsApp = null;

            Response.Redirect(filePath);
        }*/
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml()
        {            
            string s = string.Empty;

            if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";

            if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";

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
