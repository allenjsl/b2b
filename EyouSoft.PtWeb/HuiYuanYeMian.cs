using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EyouSoft.Common;

namespace EyouSoft.PtWeb
{
    /// <summary>
    /// 同行后台页面基类
    /// </summary>
    public class HuiYuanYeMian : System.Web.UI.Page
    {
        #region attributes
        EyouSoft.Model.SSOStructure.MTongHangYongHuInfo _YongHuInfo = null;
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public EyouSoft.Model.SSOStructure.MTongHangYongHuInfo YongHuInfo { get { return _YongHuInfo; } }
        bool _IsLogin = false;
        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin { get { return _IsLogin; } }
        /// <summary>
        /// 登录url
        /// </summary>
        public string LoginUrl { get { return "/"; } }

        EyouSoft.Model.PtStructure.MYuMingInfo _YuMingInfo = null;
        /// <summary>
        /// 域名信息
        /// </summary>
        public EyouSoft.Model.PtStructure.MYuMingInfo YuMingInfo { get { return _YuMingInfo; } }
        /// <summary>
        /// Erp Url
        /// </summary>
        public string ErpUrl { get { return _YuMingInfo.ErpUrl; } }
        /// <summary>
        /// 系统公司编号
        /// </summary>
        public int SysCompanyId { get { return _YuMingInfo.CompanyId; } }
        #endregion

        #region protected members
        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _YuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();

            if (_YuMingInfo == null) RCWE("请求异常：错误的域名配置。");

            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo yongHuInfo = null;
            _IsLogin = EyouSoft.Security.Membership.TongHangYongHuProvider.IsLogin(out yongHuInfo);
            _YongHuInfo = yongHuInfo;

            if (!_IsLogin)
            {
                if (Utils.GetQueryStringValue("urltype")=="ajax")
                {
                    RCWE("{\"Islogin\":\"false\"}");
                }
                else
                {
                    string s = string.Empty;
                    s += "<script type='text/javascript'>";
                    s += string.Format(" if (\"{0}\" != \"\") {{", Utils.GetQueryStringValue("iframeId"));
                    s += string.Format(" window.parent.location.href = \"{0}\"; ", LoginUrl);
                    s += "} else {";
                    s += string.Format(
                        " window.location.href = \"{0}?rurl={1}\"; ",
                        LoginUrl,
                        Server.UrlEncode(Request.Url.ToString()));
                    s += "}";
                    s += "</script>";
                    RCWE(s);
                }
            }
        }

        /// <summary>
        /// OnPreRender
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        /// <summary>
        /// Response.Clear();Response.Write(s);Response.End();
        /// </summary>
        /// <param name="s">输出字符串</param>
        protected void RCWE(string s)
        {
            Response.Clear();
            Response.Write(s);
            Response.End();
        }

        /// <summary>
        /// register scripts
        /// </summary>
        /// <param name="script"></param>
        protected void RegisterScript(string script)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
        #endregion
    }
}
