using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyouSoft.PtWeb
{
    /// <summary>
    /// 网站前台页面基类
    /// </summary>
    public class QianTaiYeMian : System.Web.UI.Page
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
        #endregion
    }
}
