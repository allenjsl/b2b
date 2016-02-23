using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    /// <summary>
    /// 旅游资讯管理
    /// </summary>
    public partial class ZiXun : EyouSoft.Common.Page.BackPage
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

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "shanchu": ShanChu(); break;
                case "shezhistatus": SheZhiStatus(); break;
                default: break;
            }

            InitRpt();
            InitZhanDain();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_旅游资讯_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_旅游资讯_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_旅游资讯_修改);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_旅游资讯_删除);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZiXunChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MZiXunChaXunInfo();

            info.BiaoTi = Utils.GetQueryStringValue("txtBiaoTi");
            info.ShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtShiJian1"));
            info.ShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtShiJian2"));
            info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing), Utils.GetQueryStringValue("txtLeiXing"));
            info.Status = (EyouSoft.Model.EnumType.PtStructure.ZiXunStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.ZiXunStatus), Utils.GetQueryStringValue("txtStatus"));
            info.ZhanDianId = Utils.GetIntNull(Utils.GetQueryStringValue("txtZhanDian"));

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            var items = new EyouSoft.BLL.PtStructure.BZiXun().GetZiXuns(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// shan chu
        /// </summary>
        void ShanChu()
        {
            if (!Privs_Delete) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string ziXunId = Utils.GetFormValue("txtZiXunId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BZiXun().Delete(CurrentUserCompanyID, ziXunId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// shezhi status
        /// </summary>
        void SheZhiStatus()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string txtZiXunId = Utils.GetFormValue("txtZiXunId");
            string txtFS = Utils.GetFormValue("txtFS");

            var status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
            if (txtFS == "tingyong") status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.停用;

            int bllRetCode = new EyouSoft.BLL.PtStructure.BZiXun().SheZhiStatus(CurrentUserCompanyID, txtZiXunId, status);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init zhandain
        /// </summary>
        void InitZhanDain()
        {
            StringBuilder s = new StringBuilder();

            var chaXun = new EyouSoft.Model.PtStructure.MZhanDianChaXunInfo();
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians(CurrentUserCompanyID, chaXun);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</options>", item.ZhanDianId, item.MingCheng);
                }
            }

            ltrZhanDianOption.Text = s.ToString();
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            string s = string.Empty;
            var _status = (EyouSoft.Model.EnumType.PtStructure.ZiXunStatus)status;

            if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            if (Privs_Update)
            {
                if (_status == EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shezhistatus\" data-fs=\"tingyong\">停用</a> ";
                }
                else
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shezhistatus\" data-fs=\"qiyong\">启用</a> ";
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
