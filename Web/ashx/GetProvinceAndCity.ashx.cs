using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EyouSoft.Common;
using System.Text;

namespace Web.Ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>

    /// <summary>
    /// 页面：DOM
    /// </summary>
    /// 创建人：刘飞
    /// 创建时间：2012-11-20
    /// 说明：处理国家，省份，城市，县区
    public class GetProvinceAndCity : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int companyId = 0;

            var yuMingInfo = EyouSoft.Security.Membership.UserProvider.GetDomain();
            companyId = yuMingInfo.CompanyId;

            string getType = Utils.GetQueryStringValue("get");
            StringBuilder sb = new StringBuilder();

            var chaXun = new EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo();
            chaXun.LeiXing1 = 0;
            chaXun.LeiXing = 0;
            chaXun.ShengFenId = Utils.GetIntNull(Utils.GetQueryStringValue("pid"));

            if (Utils.GetInt(Utils.GetQueryStringValue("isCy"), 0) == 1) chaXun.LeiXing = 1;

            if (chaXun.LeiXing == 1)
            {
                EyouSoft.Model.SSOStructure.MUserInfo loginYongHuInfo=null;
                bool isLogin=EyouSoft.Security.Membership.UserProvider.IsLogin(out loginYongHuInfo);

                if (isLogin)
                {
                    chaXun.ZxsId = loginYongHuInfo.ZxsId;
                }
                else
                {
                    chaXun.LeiXing = 0;
                }
            }

            if (getType == "p")
            {
                var items = new EyouSoft.BLL.CompanyStructure.City().GetShengFens(companyId, chaXun);

                if (items != null && items.Count > 0)
                {
                    sb.Append("{\"list\":[");
                    for (int i = 0; i < items.Count; i++)
                    {
                        sb.Append("{\"id\":\"" + items[i].ShengFenId.ToString() + "\",\"name\":\"" + items[i].ShengFenName + "\"},");
                    }
                    if (sb.Length > 1)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]}");
                }
                else
                {
                    sb.Append("{\"list\":[]}");
                }
            }

            if (getType == "c" && chaXun.ShengFenId.HasValue)
            {
                var items = new EyouSoft.BLL.CompanyStructure.City().GetChengShis(companyId, chaXun);
                if (items != null && items.Count > 0)
                {
                    sb.Append("{\"list\":[");
                    for (int i = 0; i < items.Count; i++)
                    {
                        sb.Append("{\"id\":\"" + items[i].ChengShiId.ToString() + "\",\"name\":\"" + items[i].ChengShiName + "\"},");
                    }
                    if (sb.Length > 1)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]}");
                }
                else
                {
                    sb.Append("{\"list\":[]}");
                }
            }

            if (string.IsNullOrEmpty(sb.ToString())) sb.Append("{\"list\":[]}");

            Utils.RCWE(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
