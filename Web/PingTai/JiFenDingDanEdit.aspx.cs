using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    public partial class JiFenDingDanEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 订单管理权限
        /// </summary>
        bool Privs_DingDanGuanLi = false;
        /// <summary>
        /// 订单编号
        /// </summary>
        protected string DingDanId = string.Empty;
        /// <summary>
        /// 商品编号
        /// </summary>
        protected string ShangPinId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DingDanId = Utils.GetQueryStringValue("editid");

            if (string.IsNullOrEmpty(DingDanId)) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "querendingdan": QueRenDingDan(); break;
                case "quxiaodingdan": QuXiaoDingDan(); break;
                default: break;
            }

            InitDingDanInfo();
            InitShangPinInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_DingDanGuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换订单管理_订单管理);
        }

        /// <summary>
        /// init dingdan info
        /// </summary>
        void InitDingDanInfo()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);
            if (info==null) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            ShangPinId = info.ShangPinId;
            ltrJiaoYiHao.Text = info.JiaoYiHao;
            ltrShuLiang.Text = info.ShuLiang.ToString();
            ltrJiFen1.Text = info.JiFen1.ToString();
            ltrJiFen2.Text = info.JiFen2.ToString();
            ltrShouJianRenName.Text = info.LxrXingMing;
            ltrShouJianRenShouJi.Text = info.LxrShouJi;
            ltrShouJianRenDianHua.Text = info.LxrDianHua;            
            ltrShouJianRenYouBian.Text = info.LxrYouBian;
            ltrShouJianRenYouXiang.Text = info.LxrYouXiang;
            ltrXiaDanBeiZhu.Text = info.XiaDanBeiZhu;
            
            

            #region dizhi
            var shengFenInfo = new EyouSoft.BLL.CompanyStructure.Province().GetModel(info.LxrProvinceId);
            var chengShiInfo = new EyouSoft.BLL.CompanyStructure.City().GetModel(info.LxrCityId);
            string diZhi = string.Empty;
            if (shengFenInfo != null) diZhi += shengFenInfo.ProvinceName;
            if (chengShiInfo != null) diZhi += "&nbsp;" + chengShiInfo.CityName;
            diZhi += "&nbsp;" + info.LxrDiZhi;
            ltrShouJianRenDiZhi.Text = diZhi;
            #endregion

            InitCaoZuo(info);
            InitTiShiXinXi(info);
        }

        /// <summary>
        /// init shangpin info
        /// </summary>
        void InitShangPinInfo()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPinInfo(ShangPinId);
            if (info == null) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求"));

            ltrShangPinMingCheng.Text = info.MingCheng;
            ltrShangPinLeiXing.Text = info.LeiXing.ToString();
            ltrShangPinJiaGe.Text = info.JiaGe.ToString("F2");
            ltrShangPinJiFen.Text = info.JiFen.ToString();
            ltrShangPinBianMa.Text = info.BianMa;
        }

        /// <summary>
        /// init caozuo
        /// </summary>
        /// <param name="info"></param>
        void InitCaoZuo(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            if (!Privs_DingDanGuanLi)
            {
                ph_XiaoXi.Visible = true;
                ltrXiaoXi.Text = "你没有操作权限";
                return;
            }
            switch (info.Status)
            {
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认:
                    ph_QueRen.Visible = ph_QuXiao.Visible = true;
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已确认:
                    ph_FaHuo.Visible = ph_QuXiao.Visible = true;
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货:
                    ph_XiaoXi.Visible = true;
                    ltrXiaoXi.Text = "订单已发货";
                    break;
                case EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已取消:
                    ph_XiaoXi.Visible = true;
                    ltrXiaoXi.Text = "订单已取消";
                    break;
            }
        }

        /// <summary>
        /// 初始化提示信息
        /// </summary>
        /// <param name="info"></param>
        void InitTiShiXinXi(EyouSoft.Model.PtStructure.MJiFenDingDanInfo info)
        {
            ph_TiShiXinXi.Visible = true;

            StringBuilder s = new StringBuilder();
            s.AppendFormat("当前订单状态为：<b>{0}</b>。", info.Status);
           
            string latestOperatorName=string.Empty;
            var latestOperatorInfo=new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(info.LatestOperatorId);
            if(latestOperatorInfo!=null&&latestOperatorInfo.PersonInfo!=null) latestOperatorName=latestOperatorInfo.PersonInfo.ContactName;

            var xiaDanRenInfo=new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(info.XiaDanRenId);

            s.AppendFormat("客户单位：{2}，下单人：{0}，下单时间：{1}。", info.XiaDanRenXingMing, info.IssueTime.ToString("yyyy-MM-dd HH:mm"), info.XiaDanRenKeHuName);

            s.AppendFormat("<a href=\"javascript:void(0)\" data-class=\"yonghujifenmingxi\" data-yonghuid=\"{0}\" data-kehuid=\"{1}\">查看用户积分明细</a>。", xiaDanRenInfo.ID, xiaDanRenInfo.KeHuId);

            s.AppendFormat("<br/>最后操作人：{0}，最后操作时间：{1}。", latestOperatorName, info.LatestTime.ToString("yyyy-MM-dd HH:mm"));

            if (info.Status == EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已发货)
            {
                s.AppendFormat("<a href=\"javascript:void(0)\" id=\"i_a_fahuo\" data-fs=\"chakanfahuo\">点击这里可查看订单发货信息</a>");
            }

            ltrTiShiXinXi.Text = s.ToString();
        }

        /// <summary>
        /// 确认订单
        /// </summary>
        void QueRenDingDan()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);

            info.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已确认;
            info.LatestOperatorId = SiteUserInfo.UserId;
            info.LatestTime = DateTime.Now;

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanStatus(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        void QuXiaoDingDan()
        {
            var info = new EyouSoft.BLL.PtStructure.BJiFen().GetDingDanInfo(DingDanId);

            info.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.已取消;
            info.LatestOperatorId = SiteUserInfo.UserId;
            info.LatestTime = DateTime.Now;

            int bllRetCode=new EyouSoft.BLL.PtStructure.BJiFen().SheZhiDingDanStatus(info);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：该兑换订单付款金额已支付，不能取消"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
