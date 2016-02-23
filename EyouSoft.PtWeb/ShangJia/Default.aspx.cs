using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.ShangJia
{
    public partial class Default : QianTaiYeMian
    {
        #region private members
        protected int recordCount = 0;
        protected int pageSize = 16;
        protected int pageIndex = 0;
        protected int zhuanxianid = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (YongHuInfo != null && YongHuInfo.YongHuId != 0)
            {
                InitInfo();
            }
            else
            {
                Response.Write("<script>alert('本内容仅对旅行社同行开放,请登陆后继续查看!');location.href = '/XinXi/XinXiXX.aspx'</script>");
                Response.End();
            }*/

            InitInfo();

            InitGuangGao();
        }

        #region private members
        /// <summary>
        /// get zhandians
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZhanDians(out int chaXunZhanDianIndex)
        {
            chaXunZhanDianIndex = 0;

            var yuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZhanDians1(yuMingInfo.CompanyId);

            if (items == null || items.Count == 0) return null;

            var mrzdid = EyouSoft.Security.Membership.TongHangYongHuProvider.GetMoRenZhanDianId();
            if (mrzdid > 0)
            {
                int removeIndex = 0;
                int i = 0;

                foreach (var item in items)
                {
                    if (item.ZhanDianId == mrzdid)
                    {
                        removeIndex = i;
                        break;
                    }

                    i++;
                }

                if (removeIndex > 0)
                {
                    var removeItem = items[removeIndex];

                    items.RemoveAt(removeIndex);
                    items.Insert(0, removeItem);
                }
            }


            int cxzdid = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("zdid"));

            if (cxzdid > 0)
            {
                int i = 0;
                foreach (var item in items)
                {
                    if (item.ZhanDianId == cxzdid) { chaXunZhanDianIndex = i; break; }
                    i++;
                }
            }

            return items;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            string ZXName = "";
            if(!string.IsNullOrEmpty(Utils.GetQueryStringValue("zhuanxianid")))
            {
                zhuanxianid = Utils.GetInt(Utils.GetQueryStringValue("zhuanxianid"));
            }
            int chaXunZhanDianIndex = 0;

            var items = GetZhanDians(out chaXunZhanDianIndex);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                if(zhuanxianid ==0)
                {
                    zhuanxianid = items[0].ZhanDianId;
                }
                if(items[i].ZhanDianId == zhuanxianid)
                {
                    ZXName = items[i].MingCheng;
                    if(i==items.Count-1)
                    {
                        s.AppendFormat("<li class=\"noborder\"><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                    else
                    {
                        s.AppendFormat("<li class=\"on\"><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                }
                else
                {
                    if(i==items.Count-1)
                    {
                        s.AppendFormat("<li class=\"noborder\"><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                    else
                    {
                        s.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", "/shangjia/?zhuanxianid=" + items[i].ZhanDianId, items[i].MingCheng);
                    }
                }
            }
            ZhanDianList.Text = s.ToString();
            BindShangJia(zhuanxianid,ZXName);
        }

        void BindShangJia(int zxid,string zxname)
        {
            var chaxun = new EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo();
            chaxun.ZhanDianId = zxid;
            chaxun.ZxsStatus = EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus.启用;
            chaxun.T2 = EyouSoft.Model.EnumType.PtStructure.ZxsT2.默认;

            pageIndex = UtilsCommons.GetPagingIndex();
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("searchkey")))
            {
                chaxun.MingCheng = Utils.GetQueryStringValue("searchkey");
            }
            var list = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxss(SysCompanyId, pageSize, pageIndex, ref recordCount, chaxun);
            ZhanDianName.Text = zxname;
            if (list.Count > 0)
            {
                RepShangJia.DataSource = list;
                RepShangJia.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// init guanggao
        /// </summary>
        void InitGuangGao()
        {
            int _recordCount = 0;
            var chaXun = new EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo();
            chaXun.WeiZhi = EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi.商家大全左侧广告位;
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.正常;

            var items = new EyouSoft.BLL.PtStructure.BGuangGao().GetGuangGaos(SysCompanyId, 1, 1, ref _recordCount, chaXun);

            StringBuilder s = new StringBuilder();
            s.Append("<div class=\"sj_leftimg\">");
            if (items != null && items.Count > 0)
            {
                s.AppendFormat("<a href=\"{0}\" target=\"_blank\"><img width=\"212\" height=\"186\" src=\"{1}\"></a>", items[0].XXUrl, ErpUrl + items[0].Filepath);
            }
            else
            {
                s.AppendFormat("<img width=\"212\" height=\"186\" src=\"{0}\">", "/images/pngclear.gif");
            }
            s.Append("</div>");

            ltrGuanGao.Text = s.ToString();
        }
        #endregion

        #region protected members
        /// <summary>
        /// 专线商封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetZxsFengMian(object filepath)
        {
            string _filepath = "/images/shangjia_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
