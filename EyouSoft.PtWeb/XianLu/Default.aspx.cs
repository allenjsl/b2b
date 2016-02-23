using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.XianLu
{
    public partial class Default : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 查询-站点编号
        /// </summary>
        protected int? CXZdId;
        /// <summary>
        /// 查询-专线类别编号
        /// </summary>
        protected int? CXZxlbId;

        protected int recordCount = 0;
        protected int pageSize = 6;
        protected int pageIndex = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "getgengduoxianlu": GetGengDuoXianLu(); break;
                default: break;
            }

            InitXianLu();
            InitQuYu();
        }

        #region private members
        /// <summary>
        /// init xianlu
        /// </summary>
        void InitXianLu()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            var chaXun = GetChaXunInfo();
           
            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetKongWeis(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptXianLu.DataSource = items;
                rptXianLu.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo();

            info.ZhanDianId = Utils.GetIntNull(Utils.GetQueryStringValue("zdid"));
            info.ZxlbId = Utils.GetIntNull(Utils.GetQueryStringValue("zxlbid"));
            info.ZxsId = Utils.GetQueryStringValue("zxsid");
            info.RouteName = Utils.GetQueryStringValue("searchkey");
            if (string.IsNullOrEmpty(info.RouteName)) info.RouteName = Utils.GetQueryStringValue("txtRouteName");

            info.QuDate1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate1"));
            info.QuDate2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtQuDate2"));
            info.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun), Utils.GetQueryStringValue("txtBiaoZhun"));

            if (info.RouteName == "单订票")
            {
                info.KongWeiXianLuLeiXing = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票;
                info.RouteName = string.Empty;
                info.BiaoZhun = null;
            }

            if (!info.ZhanDianId.HasValue && !info.ZxlbId.HasValue && string.IsNullOrEmpty(Utils.GetQueryStringValue("searchkey")))//默认显示第1个站点第1个专线类别
            {
                var zhanDianInfo = GetZhanDian();

                if (zhanDianInfo != null)
                {
                    info.ZhanDianId = zhanDianInfo.ZhanDianId;

                    if (zhanDianInfo.Zxlbs != null && zhanDianInfo.Zxlbs.Count > 0) info.ZxlbId = zhanDianInfo.Zxlbs[0].ZxlbId;
                }
            }

            LvYouZhuanXian1.MoRenZxlbId = info.ZxlbId;

            if (info.RouteName == "关键字") info.RouteName = string.Empty;

            CXZdId = info.ZhanDianId;
            CXZxlbId = info.ZxlbId;

            info.ExistsTingShou1 = 0;
            info.ExistsTingShou2 = 0;

            info.QuYuId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuYu"));

            return info;
        }

        /// <summary>
        /// 获取第1个站点信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhanDianInfo1 GetZhanDian()
        {
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

            return items[0];
        }

        /// <summary>
        /// get gengduo xianlu
        /// </summary>
        void GetGengDuoXianLu()
        {
            string txtKongWeiId = Utils.GetFormValue("txtKongWeiId");
            var chaXun = new EyouSoft.Model.PtStructure.MKongWeiXianLuChaXunInfo();
            chaXun.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun), Utils.GetFormValue("txtBiaoZhun"));
            chaXun.RouteName = Utils.GetFormValue("txtRouteName");
            if (chaXun.RouteName == "单订票")
            {
                chaXun.KongWeiXianLuLeiXing = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票;
                chaXun.RouteName = string.Empty;
                chaXun.BiaoZhun = null;
            }
            chaXun.XianLuId1 = Utils.GetFormValue("txtXianLuId");
            if (chaXun.RouteName == "关键字") chaXun.RouteName = string.Empty;

            var items = new EyouSoft.BLL.PtStructure.BKongWeiXianLu().GetKongWeiXianLus(txtKongWeiId, chaXun);

            if (items == null || items.Count == 0) RCWE("[]");

            RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var chaXun = new EyouSoft.Model.CompanyStructure.MQuYuChaXunInfo();
            chaXun.ZhanDianId = CXZdId;
            chaXun.ZxlbId = CXZxlbId;
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetQuYus(SysCompanyId, chaXun);

            if (items != null && items.Count > 0)
            {
                StringBuilder s = new StringBuilder();
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item.Id, item.AreaName);
                }
                ltrQuYu.Text = s.ToString();
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get biaozhun
        /// </summary>
        /// <param name="biaoZhun"></param>
        /// <returns></returns>
        protected string GetBiaoZhun(object biaoZhun, object kongWeiXianLuLeiXing)
        {
            var _kongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)kongWeiXianLuLeiXing;

            if (_kongWeiXianLuLeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票)
                return string.Format("<s class=\"icon0{0}\">{1}</s>", 0, "单订票");

            var _biaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)biaoZhun;
            if (_biaoZhun == EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun.None) return string.Empty;

            return string.Format("<s class=\"icon0{0}\">{1}</s>", (int)_biaoZhun, biaoZhun);
        }

        protected string GetYuDing(object biaoZhun, object kongWeiXianLuLeiXing, object XianLuid)
        {
            var _kongWeiXianLuLeiXing = (EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing)kongWeiXianLuLeiXing;

            if (_kongWeiXianLuLeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票)
            {
                return string.Format("<a data-class=\"yuding\" href=\"javascript:void(0);\" class=\"chkan\">立即预定</a>");
            }
            else
            {
                return string.Format("<a href=\"XianLuXX.aspx?xlid="+XianLuid+"\" class=\"chkan\">查看详情</a>");
            }
        }

        /// <summary>
        /// 线路封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetXianLuFengMian(object filepath)
        {
            string _filepath = "/images/line_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
