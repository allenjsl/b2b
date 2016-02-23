using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.CompanyStructure;

namespace Web.ManageCenter
{
    using EyouSoft.Model.AdminCenterStructure;

    using TrainPlan = EyouSoft.BLL.AdminCenterStructure.TrainPlan;

    public partial class TrainPlanAdd : BackPage
    {
        /// <summary>
        /// 操作权限
        /// </summary>
        protected bool IsSaveGrant;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitGrant();
            this.InitUC();
            switch (Utils.GetQueryStringValue("save"))
            {
                case "save":
                    Save(Utils.GetInt(Utils.GetQueryStringValue("id")));
                    break;
            }
            this.InitPage(Utils.GetQueryStringValue("id"));
        }

        /// <summary>
        /// 用户控件初始化
        /// </summary>
        void InitUC()
        {
            this.SingleFileUpload1.CompanyID = this.SiteUserInfo.CompanyId;
            this.ZhiDingBuMenSel.ReadOnly = true;
            this.ZhiDingBuMenSel.SModel = "2";
            this.ZhiDingBuMenSel.IsNotValid = false;
            this.ZhiDingBuMenSel.SetTitle = "指定部门";
            this.ZhiDingRenYuanSel.SMode = true;
            this.ZhiDingRenYuanSel.ReadOnly = true;
            this.ZhiDingRenYuanSel.IsShowSelect=true;
            this.ZhiDingRenYuanSel.IsNotValid = false;
            this.ZhiDingRenYuanSel.SetTitle = "指定人员";
            this.FaBuRenSel.ReadOnly = true;
            this.FaBuRenSel.SellsID = this.SiteUserInfo.UserId.ToString();
            this.FaBuRenSel.SellsName = this.SiteUserInfo.Name;
            this.txtFaBuDate.Value = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        }

        /// <summary>
        /// 权限初始化
        /// </summary>
        void InitGrant()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_栏目, false);
            }
            else
            {
                string doType = Utils.GetQueryStringValue("doType");
                if (doType == "add")
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_新增);
                }
                else
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_培训计划_修改);
                }
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id"></param>
        void InitPage(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            var m = new TrainPlan().GetModel(this.SiteUserInfo.CompanyId, Utils.GetInt(id));
            if (m==null)
            {
                return;
            }
            this.txtPlanTitle.Value = m.PlanTitle;
            this.txtPlanContent.Value = m.PlanContent;
            if (!string.IsNullOrEmpty(m.TrainPlanFile))
            {
                var arr = m.TrainPlanFile.Split('|');
                this.lblFile.Text = string.Format("<span class='upload_filename' id=\"spanLatestAttach\">&nbsp;<a href='{0}' target='_blank'>{1}</a><a href='javascript:void(0);' onclick=\"PageJsData.delLatestAttach()\"> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='txtLatestAttach' value='{2}'></span>", arr.Length > 1 ? arr[1] : arr[0], arr[0], m.TrainPlanFile);
            }
            this.FaBuRenSel.SellsID = m.OperatorId.ToString();
            this.FaBuRenSel.SellsName = m.OperatorName;
            this.txtFaBuDate.Value = string.Format("{0:yyyy-MM-dd}", m.IssueTime);
            var deptIds = string.Empty;
            var deptNms = string.Empty;
            var userIds = string.Empty;
            var userNms = string.Empty;
            foreach (var model in m.AcceptList)
            {
                switch (model.AcceptType)
                {
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定部门:
                        deptIds = deptIds + model.AcceptId + ",";
                        deptNms = deptNms + model.AcceptName + ",";
                        this.chkDept.Checked = true;
                        break;
                    case EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定人:
                        userIds = userIds + model.AcceptId + ",";
                        userNms = userNms + model.AcceptName + ",";
                        this.chkStaff.Checked = true;
                        break;
                    default:
                        this.chkAll.Checked = true;
                        break;
                }
            }
            this.ZhiDingBuMenSel.SectionID = deptIds.TrimEnd(',');
            this.ZhiDingBuMenSel.SectionName = deptNms.TrimEnd(',');
            this.ZhiDingRenYuanSel.SellsID = userIds.TrimEnd(',');
            this.ZhiDingRenYuanSel.SellsName = userNms.TrimEnd(',');
        }

        /// <summary>
        /// 获取发布对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.AdminCenterStructure.TrainPlanAccepts> GetAcc(int id)
        {
            var l = new List<EyouSoft.Model.AdminCenterStructure.TrainPlanAccepts>();

            if (this.chkAll.Checked)
            {
                l.Add(new TrainPlanAccepts()
                    {
                        TrainPlanId = id,
                        AcceptType = EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.所有
                    });
            }

            if (this.chkDept.Checked)
            {
                var ids =Utils.GetFormValue(this.ZhiDingBuMenSel.SelectIDClient).Split(',');
                var nms = Utils.GetFormValue(this.ZhiDingBuMenSel.SelectNameClient).Split(',');
                for (var i = 0; i < ids.Count(); i++)
                {
                    l.Add(new TrainPlanAccepts()
                        {
                            TrainPlanId = id,
                            AcceptType = EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定部门,
                            AcceptId = Utils.GetInt(ids[i]),
                            AcceptName = nms[i],
                        });
                }
            }

            if (this.chkStaff.Checked)
            {
                var ids = Utils.GetFormValue(this.ZhiDingRenYuanSel.SellsIDClient).Split(',');
                var nms = Utils.GetFormValue(this.ZhiDingRenYuanSel.SellsNameClient).Split(',');
                for (var i = 0; i < ids.Count(); i++)
                {
                    l.Add(new TrainPlanAccepts()
                    {
                        TrainPlanId = id,
                        AcceptType = EyouSoft.Model.EnumType.AdminCenterStructure.AcceptType.指定人,
                        AcceptId = Utils.GetInt(ids[i]),
                        AcceptName = nms[i],
                    });
                }

            }

            return l;
        }

        /// <summary>
        /// 保存按钮点击事件执行方法
        /// </summary>
        void Save(int id)
        {
            #region 表单验证

            var msg=string.Empty;
            if (!this.chkAll.Checked&&!this.chkDept.Checked&&!this.chkStaff.Checked)
            {
                msg += "-请选择发送对象！<br/>";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                this.Response.Clear();
                this.Response.Write(UtilsCommons.AjaxReturnJson("0", msg));
                this.Response.End();
                return;
            }

            #endregion

            var cd = string.Empty;
            var ms = string.Empty;
            var bll = new TrainPlan();
            var info = new EyouSoft.Model.AdminCenterStructure.TrainPlan
                {
                    Id = id,
                    PlanTitle = Utils.GetFormValue(this.txtPlanTitle.UniqueID),
                    PlanContent = Utils.EditInputText(this.Request.Form[this.txtPlanContent.UniqueID]),
                    TrainPlanFile = Utils.GetFormValue(this.SingleFileUpload1.ClientHideID),
                    CompanyId = this.CurrentUserCompanyID,
                    OperatorId = this.SiteUserInfo.UserId,
                    OperatorName = this.SiteUserInfo.Name,
                    IssueTime = Utils.GetDateTime(Utils.GetFormValue(this.txtFaBuDate.UniqueID)),
                    AcceptList = this.GetAcc(id)
                };

            if (id==0)
            {
                if (bll.Add(info))
                {
                    cd = "1";
                    ms = "新增成功！";
                }
                else
                {
                    cd = "0";
                    ms = "新增失败！";
                }
            }
            else
            {
                if (bll.Update(info))
                {
                    cd = "1";
                    ms = "修改成功！";
                }
                else
                {
                    cd = "0";
                    ms = "修改失败！";
                }
            }


            //保存培训计划
            this.RCWE(UtilsCommons.AjaxReturnJson(cd, ms));
        }
    }
}
