using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using Web.UserControl;

namespace Web.LineProduct
{
    /// <summary>
    /// 添加修改线路信息
    /// </summary>
    public partial class LineAdd : EyouSoft.Common.Page.BackPage
    {
        private string _returnUrl = "/LineProduct/LineList.aspx";

        /// <summary>
        /// 线路是否有行程
        /// </summary>
        protected bool IsRoutePlan;

        protected string QuYuId = string.Empty;
        protected string LeiXing = string.Empty;
        protected string BiaoZhun = "0";
        protected string Status = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            string doType = Utils.GetQueryStringValue("doType");
            _returnUrl = Utils.GetQueryStringValue("rurl");

            InitWUC();

            if (!IsPostBack)
            {
                //InitArea();
                InitQuYu();

                switch (doType.ToLower())
                {
                    case "add":
                        this.Master.ITitle = "添加线路";
                        ltrWZ.Text = "添加";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增))
                        {
                            Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增, true);
                            return;
                        }
                        break;
                    case "edit":
                        this.Master.ITitle = "修改线路";
                        ltrWZ.Text = "修改";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_修改))
                        {
                            Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_修改, true);
                            return;
                        }
                        string routeId = Utils.GetQueryStringValue("rid");
                        if (string.IsNullOrEmpty(routeId))
                        {
                            Utils.ShowAndRedirect("参数丢失，请再次进行操作！", _returnUrl);
                            return;
                        }
                        InitPage(routeId);
                        break;
                    case "copy":
                        this.Master.ITitle = "复制线路";
                        ltrWZ.Text = "复制";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增))
                        {
                            Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增, true);
                            return;
                        }
                        string routeId1 = Utils.GetQueryStringValue("rid");
                        if (string.IsNullOrEmpty(routeId1))
                        {
                            Utils.ShowAndRedirect("参数丢失，请再次进行操作！", _returnUrl);
                            return;
                        }
                        InitPage(routeId1);
                        break;
                    default:
                        this.Master.ITitle = "添加线路";
                        ltrWZ.Text = "添加";
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增))
                        {
                            Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增, true);
                            return;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// init wuc
        /// </summary>
        void InitWUC()
        {
            UploadXLYM.CompanyID = UploadXLTP.CompanyID = UploadXLFM.CompanyID = CurrentUserCompanyID;
            UploadXLYM.IsUploadSelf = UploadXLTP.IsUploadSelf = UploadXLFM.IsUploadSelf = true;
        }

        /// <summary>
        /// 初始化线路信息
        /// </summary>
        /// <param name="routeId"></param>
        private void InitPage(string routeId)
        {
            if (string.IsNullOrEmpty(routeId)) return;

            var model = new EyouSoft.BLL.TourStructure.BRoute().GetRouteById(routeId);
            if (model == null) return;

            txtRouteName.Value = model.RouteName;
            //if (ddlArea.Items.FindByValue(model.AreaId.ToString()) != null)
            //    ddlArea.Items.FindByValue(model.AreaId.ToString()).Selected = true;
            QuYuId = model.AreaId.ToString();
            txtXLMS.Value = model.AreaDesc;
            txtTS.Value = model.Days.ToString();
            txtJTBZ.Value = model.TrafficStandard;
            txtZSBZ.Value = model.StayStandard;
            txtCYBZ.Value = model.DiningStandard;
            txtJDBZ.Value = model.AttractionsStandard;
            txtDYFW.Value = model.GuideStandard;
            txtGWBZ.Value = model.ShoppingStandard;
            txtETBZ.Value = model.ChildStandard;
            txtBXSM.Value = model.InsuranceDesc;
            txtZFTJ.Value = model.ExpenseRecommend;
            txtWXTS.Value = model.Tips;
            txtNBXX.Value = model.InsideInfo;
            txtBMXZ.Value = model.RegistrationNotes;

            this.InitRoutePlan(model.RoutePlanList);

            LeiXing = ((int)model.LeiXing).ToString();
            BiaoZhun = ((int)model.BiaoZhun).ToString();
            txtJiHeShiJian.Value = model.JiHeShiJian;
            txtJiHeDiDian.Value = model.JiHeDiDian;
            txtSongTuanXinXi.Value = model.SongTuanXinXi;
            txtMuDiDiJieTuanFangShi.Value = model.MuDiDiJieTuanFangShi;
            if (model.GuoQiShiJian.HasValue) txtGuoQiShiJian.Value = model.GuoQiShiJian.Value.ToString("yyyy-MM-dd");
            Status = ((int)model.Status).ToString();

            MFileInfo xianLuYeMeiFile = new MFileInfo();
            xianLuYeMeiFile.FilePath = model.RouteHeader;
            var xianLuYeMeiFiles = new List<MFileInfo>();
            xianLuYeMeiFiles.Add(xianLuYeMeiFile);
            UploadXLYM.YuanFiles = xianLuYeMeiFiles;

            MFileInfo femgMianFile = new MFileInfo();
            femgMianFile.FilePath = model.FengMian;
            var femgMianFiles = new List<MFileInfo>();
            femgMianFiles.Add(femgMianFile);
            UploadXLFM.YuanFiles = femgMianFiles;

            var fuJianFiles=new List<MFileInfo>();
            if (model.FuJians != null && model.FuJians.Count > 0)
            {
                foreach (var item in model.FuJians)
                {
                    var fuJianFile = new MFileInfo();
                    fuJianFile.FilePath = item.Filepath;
                    fuJianFiles.Add(fuJianFile);
                }
            }
            UploadXLTP.YuanFiles = fuJianFiles;
        }

        /// <summary>
        /// 初始化线路行程
        /// </summary>
        /// <param name="list"></param>
        private void InitRoutePlan(IList<EyouSoft.Model.TourStructure.MRoutePlan> list)
        {
            if (list == null || !list.Any()) return;

            IsRoutePlan = true;

            rptRoutePlan.DataSource = list;
            rptRoutePlan.DataBind();
        }

        /*/// <summary>
        /// 初始化线路区域
        /// </summary>
        private void InitArea()
        {
            ddlArea.DataSource = new EyouSoft.BLL.CompanyStructure.Area().GetAreaByCompanyId(CurrentUserCompanyID);
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();

            ddlArea.Items.Insert(0, new ListItem("请选择", "0"));
        }*/

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string doType = Utils.GetQueryStringValue("doType");

            var model = this.GetFormValues();

            var bll = new EyouSoft.BLL.TourStructure.BRoute();
            int r = 0;
            switch (doType.ToLower())
            {
                case "add":
                    r = bll.AddRoute(model);
                    break;
                case "edit":
                    string routeId = Utils.GetQueryStringValue("rid");
                    if (string.IsNullOrEmpty(routeId))
                    {
                        Utils.ShowAndRedirect("参数丢失，请再次进行操作！", _returnUrl);
                        return;
                    }
                    model.RouteId = routeId;
                    r = bll.UpdateRoute(model); ;
                    break;
                case "copy":
                    r = bll.AddRoute(model);
                    break;
                default:
                    Response.Redirect("/LineProduct/LineList.aspx");
                    break;
            }

            Utils.ShowAndRedirect(r == 1 ? "操作成功！" : "操作失败！", _returnUrl);
        }

        /*protected void btrReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect(_returnUrl);
        }*/

        /// <summary>
        /// 获取表单值
        /// </summary>
        /// <returns></returns>
        private EyouSoft.Model.TourStructure.MRoute GetFormValues()
        {
            var model = new EyouSoft.Model.TourStructure.MRoute
                {
                    RouteName = Utils.GetFormValue(txtRouteName.UniqueID),
                    AreaId = Utils.GetInt(Utils.GetFormValue("txtQuYu")),
                    AreaDesc = Utils.EditInputText(Request.Form[txtXLMS.UniqueID]),
                    Days = Utils.GetInt(Utils.GetFormValue(txtTS.UniqueID)),
                    TrafficStandard = Utils.EditInputText(Request.Form[txtJTBZ.UniqueID]),
                    StayStandard = Utils.EditInputText(Request.Form[txtZSBZ.UniqueID]),
                    DiningStandard = Utils.EditInputText(Request.Form[txtCYBZ.UniqueID]),
                    AttractionsStandard = Utils.EditInputText(Request.Form[txtJDBZ.UniqueID]),
                    GuideStandard = Utils.EditInputText(Request.Form[txtDYFW.UniqueID]),
                    ShoppingStandard = Utils.EditInputText(Request.Form[txtGWBZ.UniqueID]),
                    ChildStandard = Utils.EditInputText(Request.Form[txtETBZ.UniqueID]),
                    InsuranceDesc = Utils.EditInputText(Request.Form[txtBXSM.UniqueID]),
                    ExpenseRecommend = Utils.EditInputText(Request.Form[txtZFTJ.UniqueID]),
                    Tips = Utils.EditInputText(Request.Form[txtWXTS.UniqueID]),
                    InsideInfo = Utils.EditInputText(Request.Form[txtNBXX.UniqueID]),
                    RegistrationNotes = Utils.EditInputText(Request.Form[txtBMXZ.UniqueID]),
                    OperatorId = SiteUserInfo.UserId,
                    CompanyId = CurrentUserCompanyID,
                    RoutePlanList = GetRoutePlan()
                };

            model.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus>(Utils.GetFormValue("txtStatus"), EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.正常);
            model.LeiXing = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing>(Utils.GetFormValue("txtLeiXing"), EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing.常规旅游);
            model.BiaoZhun = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun>(Utils.GetFormValue("txtBiaoZhun"), EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun.None);
            model.JiHeShiJian = Utils.GetFormValue(txtJiHeShiJian.UniqueID);
            model.JiHeDiDian = Utils.GetFormValue(txtJiHeDiDian.UniqueID);
            model.SongTuanXinXi = Utils.GetFormValue(txtSongTuanXinXi.UniqueID);
            model.MuDiDiJieTuanFangShi = Utils.GetFormValue(txtMuDiDiJieTuanFangShi.UniqueID);
            model.GuoQiShiJian = Utils.GetDateTimeNullable(Utils.GetFormValue(txtGuoQiShiJian.UniqueID));
            model.ZxsId = CurrentZxsId;

            var quYuInfo = new EyouSoft.BLL.CompanyStructure.Area().GetModel(model.AreaId);
            if (quYuInfo != null)
            {
                model.ZhanDianId = quYuInfo.ZhanDianId;
                model.ZxlbId = quYuInfo.ZxlbId;
            }

            var xianLuYeMeiFiles = UploadXLYM.Files;
            if (xianLuYeMeiFiles != null && xianLuYeMeiFiles.Count > 0)
            {
                model.RouteHeader = xianLuYeMeiFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = UploadXLYM.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    model.RouteHeader = yuanFiles[0].FilePath;
                }
            }

            var fengMianFiles = UploadXLFM.Files;
            if (fengMianFiles != null && fengMianFiles.Count > 0)
            {
                model.FengMian = fengMianFiles[0].FilePath;
            }
            else
            {
                var yuanFiles = UploadXLFM.YuanFiles;
                if (yuanFiles != null && yuanFiles.Count > 0)
                {
                    model.FengMian = yuanFiles[0].FilePath;
                }
            }

            model.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            var fuJianFiles = UploadXLTP.Files;
            var yuanFuJianFiles = UploadXLTP.YuanFiles;

            if (fuJianFiles != null && fuJianFiles.Count > 0)
            {
                foreach (var item in fuJianFiles)
                {
                    var fuJian = new EyouSoft.Model.PtStructure.MFuJianInfo();

                    fuJian.Filepath = item.FilePath;

                    model.FuJians.Add(fuJian);
                }
            }

            if (yuanFuJianFiles != null && yuanFuJianFiles.Count > 0)
            {
                foreach (var item in yuanFuJianFiles)
                {
                    var fuJian = new EyouSoft.Model.PtStructure.MFuJianInfo();

                    fuJian.Filepath = item.FilePath;

                    model.FuJians.Add(fuJian);
                }
            }

            return model;
        }

        /// <summary>
        /// 获取行程内容 
        /// </summary>
        /// <returns></returns>
        private IList<EyouSoft.Model.TourStructure.MRoutePlan> GetRoutePlan()
        {
            //行程内容
            string[] xcnr = HttpContext.Current.Request.Form.GetValues("txtXCNR");

            if (xcnr == null || xcnr.Length <= 0) return null;

            var list = new List<EyouSoft.Model.TourStructure.MRoutePlan>();
            for (int i = 0; i < xcnr.Length; i++)
            {
                list.Add(new EyouSoft.Model.TourStructure.MRoutePlan
                    {
                        Days = i + 1,
                        Content = Utils.EditInputText(xcnr[i])
                    });
            }

            return list;
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetZxsZhanDians(CurrentZxsId);

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<option value=\"\">请选择</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var item1 in item.Zxlbs)
                    {
                        s.AppendFormat("<optgroup label=\"{0}\">", item.ZhanDianName + "站-" + item1.ZxlbName);

                        foreach (var item2 in item1.QuYus)
                        {
                            //s.AppendFormat("<option value=\"{0}\" data-zhandianid=\"{2}\" data-zxlbid=\"{3}\" data-quyuid=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName, item.ZhanDianId, item1.ZxlbId);
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName);
                        }

                        s.AppendFormat("</optgroup>");
                    }
                }
            }

            ltrQuYuOption.Text = s.ToString();
        }

        #region protected members
        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType jiChuXinXiType)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType, null, CurrentZxsId);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</options>", item.Name);
                }
            }

            return s.ToString();
        }
        #endregion
    }
}
