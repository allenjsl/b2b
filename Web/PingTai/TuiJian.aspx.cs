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
    /// 平台推荐管理
    /// </summary>
    public partial class TuiJian : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_ShanChu = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_平台推荐_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_平台推荐_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_平台推荐_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_平台推荐_删除);

            phInsert.Visible = Privs_TianJia;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MTuiJianChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MTuiJianChaXunInfo();

            info.BiaoTi = Utils.GetQueryStringValue("txtBiaoTi");
            info.ShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtShiJian1"));
            info.ShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtShiJian2"));
            info.Status = (EyouSoft.Model.EnumType.PtStructure.TuiJianStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.TuiJianStatus), Utils.GetQueryStringValue("txtStatus"));

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
            var items = new EyouSoft.BLL.PtStructure.BTuiJian().GetTuiJians(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

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
            if (!Privs_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string tuiJianId = Utils.GetFormValue("txtTuiJianId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BTuiJian().Delete(CurrentUserCompanyID, tuiJianId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// shezhi status
        /// </summary>
        void SheZhiStatus()
        {
            if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            string txtTuiJianId = Utils.GetFormValue("txtTuiJianId");
            string txtFS = Utils.GetFormValue("txtFS");

            var status = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常;
            if (txtFS == "tingyong") status = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.停用;

            int bllRetCode = new EyouSoft.BLL.PtStructure.BTuiJian().SheZhiStatus(CurrentUserCompanyID, txtTuiJianId, status);

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
            string s = string.Empty;
            var _status = (EyouSoft.Model.EnumType.PtStructure.TuiJianStatus)status;

            if (Privs_XiuGai) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            if (Privs_ShanChu) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            if (Privs_XiuGai)
            {
                if (_status == EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常)
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

        /// <summary>
        /// get fengmian
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        protected string GetFengMian(object filepath)
        {
            string _filepath = string.Empty;

            if (filepath != null) _filepath = filepath.ToString();

            if (!string.IsNullOrEmpty(_filepath))
            {
                return string.Format("<img src=\"{0}\" style=\"width:106px;height:47px;margin:4px;\" />", _filepath);
            }

            return "未上传封面";
        }
        #endregion
    }
}