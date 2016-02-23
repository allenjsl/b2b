using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.GysWeb
{
    public partial class logindomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string u = Utils.GetQueryStringValue("yhm");//用户名
            string p = Utils.GetQueryStringValue("pwd");//用户密码
            string pmd5 = Utils.GetQueryStringValue("pwd1");//md5密码
            string vc = Utils.GetQueryStringValue("yzm");//验证码
            string callback = Utils.GetQueryStringValue("callback");//callback
            string cookietian = Utils.GetQueryStringValue("cookietian");//cookie保存天数

            string rukouleixing = Utils.GetQueryStringValue("rukouleixing");


            var yuMingInfo = EyouSoft.Security.Membership.GysYongHuProvider.GetYuMingInfo();

            if (yuMingInfo == null || yuMingInfo.CompanyId < 1)
            {
                Utils.RCWE(";" + callback + "({success:0,xiaoxi:'系统域名配置错误'});");
            }

            var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            pwdInfo.SetMd5Pwd(pmd5);

            EyouSoft.Model.SSOStructure.MGysYongHuInfo yongHuInfo = null;

            var loginRetCode = EyouSoft.Security.Membership.GysYongHuProvider.Login(yuMingInfo.CompanyId, u, pwdInfo, out yongHuInfo, Utils.GetDouble(cookietian));

            if (rukouleixing == "zxs" && loginRetCode == 1)
            {
                Utils.RCWE("1");
            }

            if (rukouleixing == "zxs1" && loginRetCode == 1)
            {
                Response.Redirect("/");
            }

            switch (loginRetCode)
            {
                case 1: Utils.RCWE(";" + callback + "({success:1,xiaoxi:'登录成功',gysleixing:" + (int)yongHuInfo.GysLeiXing + "});"); break;
                case -1: Utils.RCWE(";" + callback + "({success:-1,xiaoxi:'请输入用户名'});"); break;
                case -2: Utils.RCWE(";" + callback + "({success:-2,xiaoxi:'请输入密码'});"); break;
                case -3: Utils.RCWE(";" + callback + "({success:-3,xiaoxi:'系统域名配置错误'});"); break;
                case -4: Utils.RCWE(";" + callback + "({success:-4,xiaoxi:'请输入正确的用户名和密码'});"); break;
                case -5: Utils.RCWE(";" + callback + "({success:-5,xiaoxi:'您的账号已禁用，请联系网站客服'});"); break;
                case -6: Utils.RCWE(";" + callback + "({success:-5,xiaoxi:'您的账号未审核，请联系网站客服'});"); break;
                default: Utils.RCWE(";" + callback + "({success:0,xiaoxi:'登录异常'});"); break;
            }

        }
    }
}
