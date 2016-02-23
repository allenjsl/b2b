//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;
using EyouSoft.Model.EnumType.CompanyStructure;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-其它收入
    /// </summary>
    public partial class QiTaShouRu : BackPage
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
        protected bool Privs_Insert = false;
        /// <summary>
        /// 操作列HTML
        /// </summary>
        protected string OperatorHtml = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (UtilsCommons.IsToXls()) ToXls();

            if (Utils.GetQueryStringValue("doType") == "delete") Delete();

            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_栏目))
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_栏目, true);
                }
            }

            Privs_Insert = Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_其他收入表_项目管理);

            phInsert.Visible = Privs_Insert;

            OperatorHtml = GetOperatorHtml();
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            decimal[] heJi;
            int recordCount = 0;
            var items = new EyouSoft.BLL.FinStructure.BQiTaShouRu().GetQiTaShouRus(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrJinEHeJi.Text = ToMoneyString(heJi[0]);
                ltrYiShouJinEHeJi.Text = ToMoneyString(heJi[1]);
                ltrWeiShouJinEHeJi.Text = ToMoneyString(heJi[0] - heJi[1]);

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
        EyouSoft.Model.FinStructure.MQiTaShouZhiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MQiTaShouZhiChaXunInfo();

            info.DanWeiName = Utils.GetQueryStringValue("txtKeHuName");
            info.EShiJian = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEDate"));
            info.SShiJian = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtSDate"));
            info.XiangMu = Utils.GetQueryStringValue("txtXiangMu");
            info.JinEOperator = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QueryOperator>(Utils.GetQueryStringValue("txtJinEOperator"), EyouSoft.Model.EnumType.FinStructure.QueryOperator.None);
            info.JinE = Utils.GetDecimalNull(Utils.GetQueryStringValue("txtJinE"));
            info.XiangMuId = Utils.GetIntNull(Utils.GetQueryStringValue("txtXiangMuId"));
            info.JieQingStatus = Utils.GetIntNull(Utils.GetQueryStringValue("txtJieQingStatus"));
            info.ZxsId = CurrentZxsId;

            return info;
        }

        /// <summary>
        /// 删除其它收入信息
        /// </summary>
        void Delete()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string shouruid = Utils.GetFormValue("shouruid");
            int bllRetCode = new EyouSoft.BLL.FinStructure.BQiTaShouRu().Delete(shouruid, CurrentUserCompanyID);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：已经存在收款登记的收入项不能删除"));
            else if (bllRetCode == -3) RCWE(UtilsCommons.AjaxReturnJson("-1", "操作失败：该收入项目通过出纳登账自动登记，不能删除"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 导出excel
        /// </summary>
        void ToXls()
        {
            var s = new StringBuilder();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            int _recordCount = 0;

            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);

            var search = GetChaXunInfo();

            decimal[] heJi;
            var list = new EyouSoft.BLL.FinStructure.BQiTaShouRu().GetQiTaShouRus(CurrentUserCompanyID, toXlsRecordCount, 1, ref _recordCount, search, out heJi);

            if (list == null || !list.Any()) ResponseToXls(string.Empty);

            s.Append("序号\t收入时间\t收入项目\t收入金额\t收入备注\t对方单位\t已收金额\t未收金额\n");
            int i = 1;
            foreach (var t in list)
            {
                s.AppendFormat("{0}\t", i);
                s.AppendFormat("{0}\t", t.ShiJian.ToString("yyyy-MM-dd"));
                s.AppendFormat("{0}\t", t.XiangMu);
                s.AppendFormat("{0}\t", t.JinE.ToString("F2"));
                s.AppendFormat("{0}\t", t.BeiZhu);
                s.AppendFormat("{0}\t", t.KeHuName);
                s.AppendFormat("{0}\t", t.YiShenPiJinE.ToString("F2"));
                s.AppendFormat("{0}\n", (t.JinE - t.YiShenPiJinE).ToString("F2"));

                i++;
            }

            ResponseToXls(s.ToString());
        }

        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        string GetOperatorHtml()
        {
            string s = "<a href=\"javascript:void(0)\" class=\"i_shoukuan\">收款</a> ";

            if (Privs_Insert) s += "<a href=\"javascript:void(0)\" class=\"i_update\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_update\" i_chakan=\"1\">查看</a> ";
            if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_delete\">删除</a> ";

            return s.ToString();
        }

        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <param name="jiChuXinXiType">基础信息类型</param>
        /// <param name="_v">选中的值</param>
        /// <returns></returns>
        protected string GetJiChuXinXiOptions(JiChuXinXiType jiChuXinXiType, string _v)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType, null, CurrentZxsId);

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
