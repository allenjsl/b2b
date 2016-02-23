//汪奇志 2013-01-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;

namespace Web.SystemSet
{
    /// <summary>
    /// 系统设置-基础设置-基础信息列表
    /// </summary>
    public partial class JiChuXinXi : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        /// <summary>
        /// 基础信息类型
        /// </summary>
        protected EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType IJiChuXinXiType = EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次;
        /// <summary>
        /// 新增修改操作窗口高度
        /// </summary>
        protected string WinHeight = "140px";
        /// <summary>
        /// 新增修改操作窗口宽度
        /// </summary>
        protected string WinWidth = "470px";
        /// <summary>
        /// 是否显示T1
        /// </summary>
        protected bool IsXianShiT1 = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            IJiChuXinXiType = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType>(Utils.GetQueryStringValue("jichuxinxitype"), EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次);
            JiChuXinXi1.HighlightNav = (int)IJiChuXinXiType;
            Title = IJiChuXinXiType + "-基础设置-系统设置";

            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "delete") Delete();

            InitT1();
            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            EyouSoft.Model.EnumType.PrivsStructure.Privs3 privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_去程班次栏目;

            switch (IJiChuXinXiType)
            {
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_去程班次栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程班次:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程班次栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程时间:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_去程时间栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程时间:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程时间栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.集合地点:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_集合地点栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.集合时间:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_集合时间栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.目的地接团方式:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_目的地接团方式栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_其它收入项目栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_其它支出项目栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.送团信息:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_送团信息栏目;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.用餐标准:
                    privs = EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_用餐标准栏目;
                    break;
            }

            Privs_LanMu = CheckGrant(privs);

            if (!Privs_LanMu)
            {
                if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("doType")))
                {
                    RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
                else
                {
                    Utils.ResponseNoPermit(privs, true);
                }
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.CompanyStructure.MJiChuXinXiChaXunInfo();
            chaXun.ZxsId = CurrentZxsId;

            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, IJiChuXinXiType, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                rpts.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 删除基础信息
        /// </summary>
        void Delete()
        {
            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            int id = Utils.GetInt(Utils.GetFormValue("txtId"));
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().Delete(CurrentUserCompanyID, id);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson("-99", "操作失败：已使用，不可删除，代码：-99"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init T1
        /// </summary>
        void InitT1()
        {
            switch (IJiChuXinXiType)
            {
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目:
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目:
                    IsXianShiT1 = true;
                    WinHeight = "200px";
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次:
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程班次:
                    WinWidth="800px";
                    WinHeight = "500px";
                    break;
                default: break;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get T1 name
        /// </summary>
        /// <param name="t1"></param>
        /// <returns></returns>
        protected string GetT1Name(object t1)
        {
            if (t1 == null) return "None";
            var _t1 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1)t1;

            if (_t1 == EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.None) return "None";
            else if (_t1 == EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.团队结算) return "团队结算";
            else
            {
                if (IJiChuXinXiType == EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目) return "其它收入";
                else if (IJiChuXinXiType == EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目) return "其它支出";
                else return "None";
            }
        }

        /// <summary>
        /// get T2 name
        /// </summary>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected string GetT2Name(object t2)
        {
            if (t2 == null) return "None";
            var _t2 = (EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2)t2;

            string s = string.Empty;
            switch (_t2)
            {
                case EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.None: s = "None"; break;
                case EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_收入:
                case EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_支出: s = "长期投资（保证金）"; break;
                default: s = _t2.ToString().Replace("_收入", "").Replace("_支出", ""); break;
            }

            return s;
        }
        #endregion
    }
}
