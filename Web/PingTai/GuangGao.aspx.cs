using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.PingTai
{
    /// <summary>
    /// 广告管理
    /// </summary>
    public partial class GuangGao : EyouSoft.Common.Page.BackPage
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
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_广告管理_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_广告管理_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_广告管理_修改);
            Privs_Delete = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_广告管理_删除);

            phInsert.Visible = Privs_Insert;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo();

            info.MingCheng = Utils.GetQueryStringValue("txtBiaoTi");
            info.WeiZhi = (EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi), Utils.GetQueryStringValue("txtWeiZhi"));
            info.Status = (EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus), Utils.GetQueryStringValue("txtStatus"));

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
            var items = new EyouSoft.BLL.PtStructure.BGuangGao().GetGuangGaos(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

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

            string guangGaoId = Utils.GetFormValue("txtGuangGaoId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BGuangGao().Delete(CurrentUserCompanyID, guangGaoId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// shezhi status
        /// </summary>
        void SheZhiStatus()
        {
            if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string txtGuangGaoId = Utils.GetFormValue("txtGuangGaoId");
            string txtStatus = Utils.GetFormValue("txtStatus");

            var status = EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.正常;
            if (txtStatus == "tingyong") status = EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.停用;

            int bllRetCode = new EyouSoft.BLL.PtStructure.BGuangGao().SheZhiGuangGaoStatus(txtGuangGaoId, status);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml(object status)
        {
            var _status = (EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus)status;
            string s = string.Empty;

            if (Privs_Update) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a>&nbsp;";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a>&nbsp;";

            if (Privs_Delete) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a>&nbsp;";

            if (Privs_Update)
            {
                if (_status == EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.停用)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shezhistatus\" data-status=\"qiyong\">启用</a>&nbsp;";
                }
                else
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shezhistatus\" data-status=\"tingyong\">停用</a>&nbsp;";
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// get tupian
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        protected string GetTuPian(object filepath, object url)
        {
            string _filepath = string.Empty;
            string _url = string.Empty;

            if (filepath != null) _filepath = filepath.ToString();
            if (url != null) _url = url.ToString();

            if (string.IsNullOrEmpty(_url)) _url = "javascript:void(0)";

            if (!string.IsNullOrEmpty(_filepath))
            {
                return string.Format("<a href=\"{0}\"><img src=\"{1}\" style=\"width:106px;height:47px;margin:4px;\" /></a>", _url, _filepath);
            }

            return string.Format("<a href=\"{0}\">{1}</a>", _url, "查看");
        }
        #endregion
    }
}
