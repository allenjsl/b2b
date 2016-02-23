using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;

namespace EyouSoft.GysWeb.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Handler : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext _context)
        {
            context = _context;
            string dotype = Utils.GetQueryStringValue("dotype");

            switch (dotype)
            {
                case "getautocompletedaoyou": GetAutocompleteDaoYou(); break;
                default: break;
            }
        }

        #region private members
        /// <summary>
        /// get autocomplete daoyou
        /// </summary>
        void GetAutocompleteDaoYou()
        {
            int companyId = 0;
            int recordCount = 0;
            string gysZhuTiId = "-1";

            var chaXun = new EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo();

            chaXun.GysZhuTiId = gysZhuTiId;
            chaXun.DaoYouName = Utils.GetQueryStringValue("q");
            EyouSoft.Model.SSOStructure.MGysYongHuInfo loginYongHuInfo = null;

            var isLogin = EyouSoft.Security.Membership.GysYongHuProvider.IsLogin(out loginYongHuInfo);
            if (isLogin)
            {
                companyId = loginYongHuInfo.CompanyId;
                chaXun.GysZhuTiId = loginYongHuInfo.GysId;
            }

            var items = new EyouSoft.BLL.GysStructure.BGysZhuTi().GetZhuTiDaoYous(companyId, 10, 1, ref recordCount, chaXun);
            if (items == null || items.Count == 0)
            {
                items = new List<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo>();
                items.Add(new EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo() { DaoYouName="未匹配到导游，请直接录入" });
            }

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }
        #endregion

        #region public members
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
}
