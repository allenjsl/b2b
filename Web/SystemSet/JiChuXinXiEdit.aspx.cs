//汪奇志 2013-01-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.Model.CompanyStructure;
using System.Text;

namespace Web.SystemSet
{
    /// <summary>
    /// 系统设置-基础设置-基础信息新增、修改
    /// </summary>
    public partial class JiChuXinXiEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 信息编号
        /// </summary>
        int InfoId = 0;
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        /// <summary>
        /// 基础信息类型
        /// </summary>
        protected EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType IJiChuXinXiType = EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoId =Utils.GetInt( Utils.GetQueryStringValue("xinxiid"));
            IJiChuXinXiType = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType>(Utils.GetQueryStringValue("jichuxinxitype"), EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次);
            txtName.Attributes.Add("errmsg", "请填写" + IJiChuXinXiType);

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

            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        void InitInfo()
        {
            InitT1(string.Empty);
            InitT2(string.Empty);

            switch (IJiChuXinXiType)
            {
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目:
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目:
                    phT1.Visible = true;
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次:
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程班次:
                    phQuYu.Visible = true;
                    InitQuYu();
                    break;
                default: break;                   
            }

            var info = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetInfo(InfoId);
            if (info == null) return;

            InitT1(((int)info.T1).ToString());
            InitT2(((int)info.T2).ToString());

            txtName.Value = info.Name;

            var quYusScript = string.Format("var quYus={0};", Newtonsoft.Json.JsonConvert.SerializeObject(info.QuYus));
            RegisterScript(quYusScript);
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.Id = InfoId;
            int bllRetCode = 4;
            if (InfoId<1)
            {
                bllRetCode = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MJiChuXinXiInfo GetFormInfo()
        {
            MJiChuXinXiInfo info = new MJiChuXinXiInfo();

            info.CompanyId = CurrentUserCompanyID;
            info.Id = 0;
            info.IssueTime = DateTime.Now;
            info.Name = Utils.GetFormValue("txtName");
            info.OperatorId = SiteUserInfo.UserId;
            info.Type = IJiChuXinXiType;
            info.T1 = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1>(Utils.GetFormValue("txtT1"), EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.None);
            info.T2 = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2>(Utils.GetFormValue("txtT2"), EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.None);
            info.ZxsId = CurrentZxsId;

            info.QuYus = new List<EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo>();

            #region quyu
            string txtQuYu = Utils.GetFormValue("txtQuYu");
            if (!string.IsNullOrEmpty(txtQuYu))
            {
                var quYuItems = txtQuYu.Split(',');
                if (quYuItems != null && quYuItems.Length > 0)
                {
                    foreach (var quYuItem in quYuItems)
                    {
                        if (string.IsNullOrEmpty(quYuItem)) continue;
                        var item = new EyouSoft.Model.CompanyStructure.MJiChuXinXiQuYuInfo();
                        item.QuYuId = Utils.GetInt(quYuItem);
                        if (item.QuYuId == 0) continue;
                        info.QuYus.Add(item);
                    }
                }
            }
            #endregion

            return info;
        }

        /// <summary>
        /// init T1
        /// </summary>
        /// <param name="v">选中的值</param>
        void InitT1(string v)
        {

            if (IJiChuXinXiType != EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目 
                && IJiChuXinXiType != EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目) return;

            string s = string.Empty;
            s += "<option value=''>请选择</option>";

            if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.团队结算).ToString())
            {
                s += string.Format("<option value='{0}' selected='selected'>团队结算</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.团队结算);
            }
            else
            {
                s += string.Format("<option value='{0}'>团队结算</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.团队结算);
            }

            switch (IJiChuXinXiType)
            {
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目:
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>其它收入</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>其它收入</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支);
                    }
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目:
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>其它支出</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>其它支出</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支);
                    }
                    break;
                default: break;
            }

            ltrT1.Text = s;
        }

        /// <summary>
        /// init T2
        /// </summary>
        /// <param name="v">选中的值</param>
        void InitT2(string v)
        {
            if (IJiChuXinXiType != EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目
                && IJiChuXinXiType != EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目) return;

            string s = string.Empty;
            s += "<option value=''>请选择</option>";

            switch (IJiChuXinXiType)
            {
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它收入项目:
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.营业外收入_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>营业外收入</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.营业外收入_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>营业外收入</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.营业外收入_收入);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.公司暂收款_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>公司暂收款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.公司暂收款_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>公司暂收款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.公司暂收款_收入);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.账户互转_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>账户互转</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.账户互转_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>账户互转</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.账户互转_收入);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.理财产品_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>理财产品</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.理财产品_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>理财产品</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.理财产品_收入);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.原公司帐款_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>原公司帐款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.原公司帐款_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>原公司帐款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.原公司帐款_收入);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.股本金_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>股本金</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.股本金_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>股本金</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.股本金_收入);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_收入).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>长期投资（保证金）</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_收入);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>长期投资（保证金）</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_收入);
                    }
                    break;
                case EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目:
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.营业外支出_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>营业外支出</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.营业外支出_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>营业外支出</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.营业外支出_支出);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.公司暂付款_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>公司暂付款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.公司暂付款_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>公司暂付款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.公司暂付款_支出);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.账户互转_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>账户互转</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.账户互转_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>账户互转</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.账户互转_支出);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.股本金_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>股本金</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.股本金_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>股本金</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.股本金_支出);
                    }

                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.理财产品_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>理财产品</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.理财产品_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>理财产品</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.理财产品_支出);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.原公司帐款_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>原公司帐款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.原公司帐款_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>原公司帐款</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.原公司帐款_支出);
                    }
                    if (v == ((int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_支出).ToString())
                    {
                        s += string.Format("<option value='{0}' selected='selected'>长期投资（保证金）</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_支出);
                    }
                    else
                    {
                        s += string.Format("<option value='{0}'>长期投资（保证金）</option>", (int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT2.长期投资_保证金_支出);
                    }
                    break;
                default: break;
            }

            ltrT2.Text = s;
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetZxsZhanDians(CurrentZxsId);
            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            s.AppendFormat("<div>");
            int i = 0;
            foreach (var item in items)
            {
                if (item.Zxlbs == null || item.Zxlbs.Count == 0) continue;
                foreach (var item1 in item.Zxlbs)
                {
                    s.AppendFormat("<ul class=\"p1\">");
                    s.AppendFormat("<li class=\"p1title\"><input type=\"checkbox\" name=\"chk_zxlb\" value=\"{0}\" id=\"chk_zxlb_{0}\"><label for=\"chk_zxlb_{0}\">{1}</label></li>", item1.ZxlbId, item.ZhanDianName+"站-"+item1.ZxlbName);

                    foreach (var item2 in item1.QuYus)
                    {
                        s.AppendFormat("<li class=\"p1item\"><input type=\"checkbox\" name=\"chk_quyu\" value=\"{0}\" id=\"chk_quyu_{0}\"><label for=\"chk_quyu_{0}\">{1}</label></li>", item2.QuYuId, item2.QuYuName);
                    }

                    s.AppendFormat("</ul>");
                    if (i % 3 == 2)
                    {
                        s.Append("<ul class=\"p2\"><li></li></ul>");
                    }
                    i++;
                }
            }
            s.AppendFormat("</div>");
            ltrQuYu.Text = s.ToString();
        }
        #endregion
    }
}
