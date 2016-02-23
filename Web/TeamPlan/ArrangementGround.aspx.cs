using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using EyouSoft.Common.Page;
using System.Text;

namespace Web.TeamPlan
{
    /// <summary>
    /// 安排地接
    /// 刘树超  2012-12-6
    /// </summary>
    public partial class ArrangementGround : BackPage
    {
        protected string areaID = string.Empty;
        protected string kongweiID = string.Empty;
        protected string PlandId = string.Empty;
        protected string dotype = string.Empty;
        protected string orderlist = string.Empty;
        protected string updateOrder = string.Empty;
        protected bool isPrivs_Dijie = false;
        protected bool isshow = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "getyouke") GetYouKe();

            if (Utils.GetQueryStringValue("chakan") == "1") PlaceHolder1.Visible = isshow = false;

            this.SupperControl1.SupplierType = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.地接;
            updateOrder = Utils.GetFormValue("qanpaiD");
            orderlist = Utils.GetFormValue("anpaiD");
            PlandId = Utils.GetQueryStringValue("PlanID");
            kongweiID = Utils.GetQueryStringValue("kongweiId");
            areaID = Utils.GetQueryStringValue("RoutID");
            if (!IsPostBack)
            {
                PageInit(kongweiID);
            }
            string Dtype = Utils.GetQueryStringValue("type");
            if (Dtype == "del")
            {
                this.RCWE(delByKongweiID(kongweiID));
            }
            else
            {
                DateInit(PlandId);
            }
            dotype = Utils.GetFormValue("hideDotype");

            if (dotype != "")
            {
                save(kongweiID);
            }

        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="planid">控位编号</param>
        private void PageInit(string kongweiid)
        {

            EyouSoft.BLL.PlanStructure.BPlanDiJie bll = new EyouSoft.BLL.PlanStructure.BPlanDiJie();
            IList<EyouSoft.Model.PlanStructure.MPlan_DiJie> dijielist = bll.GetPlanDiJieList(kongweiid);
            if (dijielist != null && dijielist.Count > 0)
            {
                this.rptdijieList.DataSource = dijielist;
                this.rptdijieList.DataBind();
            }
            EyouSoft.BLL.TourStructure.BTourOrder b = new EyouSoft.BLL.TourStructure.BTourOrder();
            IList<EyouSoft.Model.TourStructure.MTourOrder> orderarr = b.GetTourPlanOrderList(kongweiid);
            if (orderarr != null && orderarr.Count > 0)
            {
                this.rptorderlist.DataSource = orderarr;
                this.rptorderlist.DataBind();
            }

            if (new EyouSoft.BLL.TourStructure.BTour().GetKongWeiZhuangTai(kongweiid) == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                phOperatorHtml.Visible = false;
                ltrOperatorHtml.Text = "控位已核算结束";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="kongweiID">空位编号</param>
        protected void save(string kongweiID)
        {

            EyouSoft.Model.PlanStructure.MPlanDiJie model = new EyouSoft.Model.PlanStructure.MPlanDiJie();

            string[] strOrderid = Utils.GetFormValues("orderid");
            if (strOrderid.Length > 0)
            {
                string[] orderid = new string[strOrderid.Length];
                for (int i = 0; i < strOrderid.Length; i++)
                {
                    orderid[i] = strOrderid[i].Split('|')[0].ToString();
                }
                model.OrderId = orderid;
                model.RouteId = strOrderid[0].Split('|')[1].ToString();
            }
            else
            {
                MessageBox.Show(this, "请选择要安排的订单！");
                return;
            }

            model.CompanyId = SiteUserInfo.CompanyId;
            model.KongWeiId = kongweiID;
            model.OperatorId = SiteUserInfo.UserId;
            #region  获取表单值
            model.GysId = Utils.GetFormValue(SupperControl1.ClientValue); //地接社
            model.GysName = Utils.GetFormValue(SupperControl1.ClientText);
            model.LxrName = Utils.GetFormValue(this.txtContactName.UniqueID);//联系人
            model.LxrTelephone = Utils.GetFormValue(this.txtContactTel.UniqueID);//联系电话
            model.ChengRenShu = Utils.GetInt(Utils.GetFormValue(this.txtAdultCount.UniqueID));//成人数
            model.ErTongShu = Utils.GetInt(Utils.GetFormValue(this.txtChildCount.UniqueID));//儿童数
            model.QuPeiShu = Utils.GetInt(Utils.GetFormValue(this.txtquanpeiCount.UniqueID));//全陪数
            model.YongCan = Utils.GetFormValue(this.txtDinner.UniqueID);//用餐
            model.QuPeiName = Utils.GetFormValue(this.txtquanpei.UniqueID);//全陪            
            model.JieSuanMX = Utils.GetFormValue(this.txtjiesuanDesc.UniqueID);//结算明细
            model.JieSuanAmount = Utils.GetDecimal(Utils.GetFormValue(this.txtjiesuanMoney.UniqueID));//结算金额
            model.JieTuanFangShi = Utils.GetFormValue(this.txtjietuantype.UniqueID);//接团方式
            model.Remark = Utils.GetFormValue(this.txtRemark.UniqueID);//备注
            model.YouKeXinXi = Utils.GetFormValue(txtYouKeXinXi.UniqueID);
            model.ZxsId = CurrentZxsId;
            model.YingErShu = Utils.GetInt(Utils.GetFormValue(txtYingErRenShu.UniqueID));
            #endregion
            model.NeiBuBeiZhu = Utils.GetFormValue(txtNeiBuBeiZhu.UniqueID);

            EyouSoft.BLL.PlanStructure.BPlanDiJie bll = new EyouSoft.BLL.PlanStructure.BPlanDiJie();
            int result = 99;
            if (dotype == "add")
            {
                if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_新增地接安排))
                {
                    MessageBox.Show(this, "你没有添加地接的权限！");
                    return;
                }
                result = bll.AddPlanDiJie(model);
                switch (result)
                {
                    case -2:
                        MessageBox.Show(this, "一次只能对一个团队安排！");
                        break;
                    case -1:
                        MessageBox.Show(this, "已安排订单不能重复安排！");
                        break;
                    case 0:
                        MessageBox.Show(this, "安排失败！");
                        break;
                    case 1:
                        MessageBox.Show(this, "安排成功！");
                        MessageBox.ResponseScript(this, "window.location.href=window.location.href");
                        break;
                    case -19:
                        MessageBox.Show(this, "操作失败：控位已核算结束！");
                        break;
                    default:
                        break;
                }
            }
            else if (dotype == "update")
            {
                if (!string.IsNullOrEmpty(PlandId))
                {
                    if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改地接安排))
                    {
                        MessageBox.Show(this, "你没有修改地接的权限！");
                        return;
                    }

                    model.PlanId = PlandId;
                    result = bll.UpdatePlanDiJie(model);
                    switch (result)
                    {
                        case -2:
                            MessageBox.Show(this, "当订单性质为团队时，一次只能选择一个订单进行地接安排！");
                            break;
                        case -1:
                            MessageBox.Show(this, "已安排订单不能重复安排！");
                            break;
                        case 0:
                            MessageBox.Show(this, "修改失败！");
                            break;
                        case 1:
                            MessageBox.Show(this, "修改成功！");
                            MessageBox.ResponseScript(this, "window.location.href=\"ArrangementGround.aspx?kongweiId=" + kongweiID + "&RoutID=" + areaID + "&iframeId=" + Utils.GetQueryStringValue("iframeId") + "\"");
                            break;
                        case -19:
                            MessageBox.Show(this, "操作失败：控位已核算结束！");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(this, "页面数据丢失，请刷新页面重新操作！");
                }
            }
        }


        /// <summary>
        /// 修改，页面初始化
        /// </summary>
        /// <param name="planID">计划ID</param>
        protected void DateInit(string planID)
        {
            EyouSoft.Model.PlanStructure.MPlanDiJie model = new EyouSoft.Model.PlanStructure.MPlanDiJie();
            EyouSoft.BLL.PlanStructure.BPlanDiJie bll = new EyouSoft.BLL.PlanStructure.BPlanDiJie();
            model = bll.GetPlanDiJieById(planID);

            if (model != null)
            {
                #region 表单赋值
                SupperControl1.HideID = model.GysId;
                SupperControl1.Name = model.GysName;
                txtContactName.Text = model.LxrName;
                txtContactTel.Text = model.LxrTelephone;
                txtAdultCount.Text = model.ChengRenShu.ToString();
                txtChildCount.Text = model.ErTongShu.ToString();
                txtquanpeiCount.Text = model.QuPeiShu.ToString();
                txtDinner.Text = model.YongCan;
                txtquanpei.Text = model.QuPeiName;
                txtjiesuanDesc.Text = model.JieSuanMX;
                txtjiesuanMoney.Text = model.JieSuanAmount.ToString("F2");
                txtjietuantype.Text = model.JieTuanFangShi;
                txtRemark.Text = model.Remark;
                txtYouKeXinXi.Text = model.YouKeXinXi;
                txtNeiBuBeiZhu.Text = model.NeiBuBeiZhu;
                #endregion

                #region 恢复已安排的订单为可用
                string[] oldlist = orderlist.Split('|').ToArray<string>();
                orderlist = string.Empty;
                System.Collections.ArrayList arr = new System.Collections.ArrayList();
                for (int i = 0; i < oldlist.Length; i++)
                {
                    arr.Add(oldlist[i]);
                }
                orderlist = string.Empty;
                if (model.OrderId.Length > 0)
                {
                    for (int i = 0; i < model.OrderId.Length; i++)
                    {
                        updateOrder += model.OrderId[i] + "|";
                        arr.Remove(model.OrderId[i]);
                    }
                    for (int i = 0; i < arr.Count; i++)
                    {
                        orderlist += arr[i].ToString() + "|";
                    }

                }
                #endregion
            }



        }

        /// <summary>
        /// 删除地接
        /// </summary>
        /// <param name="kongweiID">空位编号</param>
        /// <returns></returns>
        protected string delByKongweiID(string kongweiID)
        {

            string msg = string.Empty;
            if (!string.IsNullOrEmpty(kongweiID))
            {
                if (CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_删除地接安排))
                {
                    int result = new EyouSoft.BLL.PlanStructure.BPlanDiJie().DeletePlanDiJie(kongweiID);
                    if (result == 1)
                    {
                        msg = UtilsCommons.AjaxReturnJson("1", "删除成功!");
                    }
                    else if (result == 0)
                    {
                        msg = UtilsCommons.AjaxReturnJson("0", "删除失败!");
                    }
                    else if (result == -19)
                    {
                        msg = UtilsCommons.AjaxReturnJson("0", "操作失败：控位已核算结束!");
                    }
                    else
                    {
                        msg = UtilsCommons.AjaxReturnJson("0", "已经登记过付款的安排项不允许删除!");
                    }
                }
                else
                {
                    msg = UtilsCommons.AjaxReturnJson("0", "你没有删除地接的权限,删除失败!");
                }
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "请刷新页面后再操作!");
            }
            return msg;
        }

        /// <summary>
        /// 获取泡泡
        /// </summary>
        /// <param name="pID">计划编号</param>
        /// <returns></returns>
        protected string GetOrderList(string pID)
        {
            System.Text.StringBuilder list = new System.Text.StringBuilder();
            list.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'><tr class='pp-table-title'><th>订单号</th><th>性质</th><th>线路名称</th><th >客户单位</th><th>人数</th><th>价格明细</th><th>总金额</th></tr>");
            IList<EyouSoft.Model.PlanStructure.MDiJieOrder> Dlist = new EyouSoft.BLL.PlanStructure.BPlanDiJie().GetDiJieOrder(pID);
            if (Dlist != null && Dlist.Count > 0)
            {
                for (int i = 0; i < Dlist.Count; i++)
                {

                    list.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                        Dlist[i].OrderCode,
                        Convert.ToString(Dlist[i].BusinessNature),
                        Dlist[i].RouteName,
                        Dlist[i].BuyCompanyName,
                        Dlist[i].Adults.ToString() + "+" + Dlist[i].Childs.ToString() + "+" + Dlist[i].YingErShu.ToString() + "+" + Dlist[i].Bears.ToString(),
                        Dlist[i].PriceDetials,
                        Dlist[i].SumPrice.ToString("F2"));
                    orderlist += Dlist[i].OrderId + "|";
                }
            }
            list.Append("</table>");
            return list.ToString();

        }


        //设定该页面为弹窗页面
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
        }

        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType jiChuXinXiType)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType,null,CurrentZxsId);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</options>", item.Name);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// get dijie queren xinxi
        /// </summary>
        /// <param name="queRenStatus"></param>
        /// <param name="queRenRenId"></param>
        /// <param name="queRenRenName"></param>
        /// <param name="queRenTime"></param>
        /// <returns></returns>
        protected string GetDiJieQueRenXinXi(object queRenStatus, object queRenRenId, object queRenRenName, object queRenTime)
        {
            var _queRenStatus = (EyouSoft.Model.EnumType.TourStructure.QueRenStatus)queRenStatus;
            string s=string.Empty;
            if (_queRenStatus == EyouSoft.Model.EnumType.TourStructure.QueRenStatus.未确认)
            {
                s = "地接确认状态：未确认<br/>";
            }
            else
            {
                s = "地接确认状态：已确认<br/>";
                var _queRenRenId = (int)queRenRenId;
                var _queRenTime = (DateTime?)queRenTime;
                if (_queRenRenId > 0)
                {
                    s += "地接确认人：" + queRenRenName+"<br/>";

                    if (_queRenTime.HasValue)
                    {
                        s += "地接确认时间：" + _queRenTime.Value.ToString("yyyy-MM-dd HH:mm");
                    }
                }
            }

            return s;
        }

        /// <summary>
        /// get youke
        /// </summary>
        void GetYouKe()
        {
            var txtDingDanIds = Utils.GetFormValues("txtDingDanId[]");
            if (txtDingDanIds == null || txtDingDanIds.Length == 0) { Utils.RCWE_AJAX("0", "当前安排未选择订单，不能导入游客信息"); }

            StringBuilder s = new StringBuilder();

            foreach (var txtDingDanId in txtDingDanIds)
            {
                StringBuilder s1 = new StringBuilder();
                var items = new EyouSoft.BLL.TourStructure.BTourOrder().GetYouKes(txtDingDanId);
                if (items == null || items.Count == 0) continue;

                foreach (var item in items)
                {
                    if (!string.IsNullOrEmpty(item.TravellerName) 
                        && !string.IsNullOrEmpty(item.Contact) 
                        && item.TravellerStatus == EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团)
                    {
                        s1.Append(item.TravellerName + "  " + item.Contact + "\n");
                    }
                }

                if (string.IsNullOrEmpty(s1.ToString()))
                {
                    foreach (var item in items)
                    {
                        if (item.TravellerStatus != EyouSoft.Model.EnumType.TourStructure.TravellerStatus.退团)
                        {
                            s1.Append(item.TravellerName+"\n"); break;
                        }
                    }
                }

                s.Append(s1);
            }

            if (string.IsNullOrEmpty(s.ToString())) Utils.RCWE_AJAX("0", "当前安排所选订单中未查询到游客信息");

            Utils.RCWE_AJAX("1", "", s.ToString());
        }
    }
}
