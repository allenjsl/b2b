using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.JiuDian
{
    public partial class Default : QianTaiYeMian
    {
        #region attributes
        protected int recordCount = 0;
        protected int pageSize = 5;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InteBind();
        }

        #region private members
        void InteBind()
        {
            #region 资讯绑定
            var ziXunChaXun = new EyouSoft.Model.PtStructure.MZiXunChaXunInfo();
            ziXunChaXun.Status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
            ziXunChaXun.LeiXing = EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台资讯;
            int Count = 0;
            var list = new EyouSoft.BLL.PtStructure.BZiXun().GetZiXuns(SysCompanyId, 15, 1, ref Count, ziXunChaXun);
            if (list.Count > 0)
            {
                RepZiXun.DataSource = list;
                RepZiXun.DataBind();

            }
            #endregion
            #region 酒店绑定
            var searchModel = new EyouSoft.Model.PtStructure.MJiuDianChaXunInfo();
            searchModel.JiuDianMingCheng = Utils.GetQueryStringValue("searchkey");
            searchModel.ChengShiId = Utils.GetIntNull(Utils.GetQueryStringValue("ChengShiId"));
            pageIndex = UtilsCommons.GetPagingIndex();
            var items = new EyouSoft.BLL.PtStructure.BJiuDian().GetJiuDians(SysCompanyId, pageSize, pageIndex,ref recordCount, searchModel);
            if (items.Count > 0)
            {
                RepHotelList.DataSource = items;
                RepHotelList.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
            #endregion
            #region 绑定广告
            var chaXun = new EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo();
            chaXun.WeiZhi = EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi.酒店左侧广告位;
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.正常;
            int GuangGaoCount = 0;
            var item = new EyouSoft.BLL.PtStructure.BGuangGao().GetGuangGaos(YuMingInfo.CompanyId, 1, 1, ref GuangGaoCount, chaXun);

            if (item.Count > 0)
            {
                GuangGao.Text = "<a href=\""+ item[0].XXUrl+"\"><img src=\"" + (ErpUrl + item[0].Filepath) + "\" width=\"261\" height=\"196\" /></a>";
            }
            #endregion
        }
        #endregion

        #region protected members
        protected string GetJiuDianXingJi(object xingji)
        {
            string jiudianxingji = "";
            int jixing=0;
            switch (xingji.ToString())
            {
                case "三星以下":
                    jixing = 0;
                    break;
                case "挂三":
                    jixing = 1;
                    break;
                case "准三":
                    jixing = 4;
                    break;
                case "挂四":
                    jixing = 2;
                    break;
                case "准四":
                    jixing = 5;
                    break;
                case "挂五":
                    jixing = 3;
                    break;
                case "准五":
                    jixing = 6;
                    break;
                default:
                    jixing = 0;
                    break;
                    
            }
            if (jixing > 0 && jixing < 4)
            {
                for (int i = 0; i < jixing + 2; i++)
                {
                    jiudianxingji += "<img src=\"/images/star.gif\" />";
                }
            }
            else if (jixing > 3 && jixing < 7)
            {
                for (int i = 3; i < jixing+2; i++)
                {
                    jiudianxingji += "<img src=\"/images/star_h.gif\" />";
                }
            }
            return jiudianxingji;
        }

        /// <summary>
        /// 酒店封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetJiuDianFengMian(object filepath)
        {
            string _filepath = "/images/hotel_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
