using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.ShangCheng
{
    public partial class ShangCengTiJiao : QianTaiYeMian
    {
        protected string pSelect = "0", cSelect = "0";
        protected string ShuLiang = "";//最多可兑换数量
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["shangpinid"]))
                {
                    InteBind();
                }
                else
                {
                    Response.Redirect("/shangcheng/");
                }
            }
        }
        void InteBind()
        {
            string shangpinid = Request.QueryString["shangpinid"];
            var list = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPinInfo(shangpinid);
            SuoXuJIFen.Text = list.JiFen.ToString();
            if (YongHuInfo != null && YongHuInfo.YongHuId != 0)
            {
                var yongHuJiFenInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetYongHuJiFenInfo(YongHuInfo.YongHuId);

                //KeYongJiFen.Text = "5000";
                //if (list.JiFen > 5000)
                //{
                //    Response.Write("<script>alert('您的积分不够，请重新选择商品兑换！');parent.location.href =/shangcheng/</script>");
                //}
                //else
                //{
                //    for (int i = 0; i < (5000 / list.JiFen); i++)
                //    {
                //        ShuLiang += "<option value=\"" + (i + 1) + "\">" + (i + 1) + "</option>";
                //    }
                //}


                KeYongJiFen.Text = yongHuJiFenInfo.KeYongJiFen.ToString();
                if (list.JiFen > yongHuJiFenInfo.KeYongJiFen)
                {
                    Response.Write("<script>alert('您的积分不够，请重新选择商品兑换！');parent.location.href =/shangcheng/</script>");
                }
                else
                {
                    int DuiHuanLiang =10;
                    /*if (list.JiFen != 0)
                    {
                        DuiHuanLiang = yongHuJiFenInfo.KeYongJiFen / list.JiFen;
                    }*/
                    for (int i = 0; i < DuiHuanLiang; i++)
                    {
                        ShuLiang += "<option value=\"" + (i + 1) + "\">" + (i + 1) + "</option>";
                    }
                }
            }
            
        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            EyouSoft.BLL.PtStructure.BJiFen bll = new EyouSoft.BLL.PtStructure.BJiFen();
            EyouSoft.Model.PtStructure.MJiFenDingDanInfo OrderModel = new EyouSoft.Model.PtStructure.MJiFenDingDanInfo();

            string shangpinid = Utils.GetFormValue("productid");
            var list = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPinInfo(shangpinid);

            OrderModel.ShuLiang = Utils.GetInt(Utils.GetFormValue("DuiHuanNum"));
            OrderModel.JiFen1 = list.JiFen;
            OrderModel.JiFen2 = OrderModel.ShuLiang * OrderModel.JiFen1;
            OrderModel.IssueTime = DateTime.Now;
            OrderModel.LatestTime = DateTime.Now;
            OrderModel.LxrProvinceId = Utils.GetInt(Utils.GetFormValue("ddprovince"));
            OrderModel.LxrCityId = Utils.GetInt(Utils.GetFormValue("ddlcity"));
            OrderModel.LxrDianHua = Utils.GetFormValue("UserTel");
            OrderModel.LxrDiZhi = Utils.GetFormValue("XiangXiDiZhi");
            OrderModel.LxrShouJi = Utils.GetFormValue("UserMobile");
            OrderModel.LxrXingMing = Utils.GetFormValue("ShouHuoRen");
            OrderModel.LxrYouXiang = Utils.GetFormValue("UserEmail");
            OrderModel.ShangPinBianMa = list.BianMa;
            OrderModel.ShangPinId = list.ShangPinId;
            OrderModel.ShangPinMingCheng = list.MingCheng;
            OrderModel.Status = EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus.未确认;
            OrderModel.XiaDanBeiZhu = Utils.GetFormValue("BeiZhu");
            OrderModel.XiaDanRenId = YongHuInfo.YongHuId;
            OrderModel.CompanyId = YongHuInfo.CompanyId;
            OrderModel.LxrYouBian = Utils.GetFormValue("YouBian");
            OrderModel.LatestOperatorId = YongHuInfo.YongHuId;

            string tishixinxi = "";
            int count = bll.InsertDingDan(OrderModel);
            if (count == 1)
            {
                tishixinxi="下单成功";
            }
            else if (count == -96)
            {
                tishixinxi="积分不足";
            }
            else if(count == -98)
            {
                tishixinxi="商品已下架";
            }
            else if(count ==-99)
            {
                tishixinxi ="商品信息不存在";
            }
            else
            {
                tishixinxi ="下单失败，请联系管理员";
            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson(count.ToString(), tishixinxi));
        }
    }
}
