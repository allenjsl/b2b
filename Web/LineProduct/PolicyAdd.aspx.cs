using System;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.LineProduct
{
    public partial class PolicyAdd : EyouSoft.Common.Page.BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
            UploadZCFJ.CompanyID = CurrentUserCompanyID;
            UploadZCFJ.IsUploadSelf = true;

            string doType = Utils.GetQueryStringValue("doType");
            string iframeId = Utils.GetQueryStringValue("iframeId");

            if (!IsPostBack)
            {
                switch (doType.ToLower())
                {
                    case "add":
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_新增))
                        {
                            Utils.ShowMsgAndCloseBoxy("您没有线路产品_政策中心_新增权限，请联系管理员！", iframeId, true);
                            return;
                        }
                        ltrStatusOptions.Text = GetStatusOptions(string.Empty);
                        txtContact.Value = SiteUserInfo.Name;
                        txtDate.Value = DateTime.Now.ToShortDateString();
                        break;
                    case "edit":
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_修改))
                        {
                            Utils.ShowMsgAndCloseBoxy("您没有线路产品_线路管理_修改权限，请联系管理员！", iframeId, true);
                            return;
                        }
                        string pId = Utils.GetQueryStringValue("pid");
                        if (string.IsNullOrEmpty(pId))
                        {
                            Utils.ShowMsgAndCloseBoxy("参数丢失，请再次进行操作！", iframeId, true);
                            return;
                        }
                        InitPage(pId);
                        break;
                    default:
                        //判断权限
                        if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_新增))
                        {
                            Utils.ShowMsgAndCloseBoxy("您没有线路产品_政策中心_新增权限，请联系管理员！", iframeId, true);
                            return;
                        }
                        txtContact.Value = SiteUserInfo.Name;
                        txtDate.Value = DateTime.Now.ToShortDateString();
                        break;
                }
            }
        }

        /// <summary>
        /// 初始化线路信息
        /// </summary>
        /// <param name="policyId"></param>
        private void InitPage(string policyId)
        {
            if (string.IsNullOrEmpty(policyId))
            {
                ltrStatusOptions.Text = GetStatusOptions(string.Empty);
                return;
            }

            var model = new EyouSoft.BLL.TourStructure.BRoute().GetRouteZhengCeById(policyId);
            if (model == null) return;

            txtTitle.Value = model.Title;
            txtContact.Value = SiteUserInfo.Name;
            txtDate.Value = model.IssueTime.ToShortDateString();
            ltrStatusOptions.Text = GetStatusOptions(((int)model.Status).ToString());

            this.InitUploadImg(ltrZCFJ, model.FilePath, string.Empty);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string doType = Utils.GetQueryStringValue("doType");
            string iframeId = Utils.GetQueryStringValue("iframeId");

            var model = this.GetFormValues();

            var bll = new EyouSoft.BLL.TourStructure.BRoute();
            int r = 0;
            switch (doType.ToLower())
            {
                case "add":
                    r = bll.AddRouteZhengCe(model);
                    break;
                case "edit":
                    string pId = Utils.GetQueryStringValue("pid");
                    if (string.IsNullOrEmpty(pId))
                    {
                        Utils.ShowMsgAndCloseBoxy("参数丢失，请再次进行操作！", iframeId, true);
                        return;
                    }
                    model.Id = pId;
                    r = bll.UpdateRouteZhengCe(model);
                    break;
                default:
                    Utils.ShowMsgAndCloseBoxy("没有进行任何操作！", iframeId, true);
                    break;
            }

            Utils.ShowMsgAndCloseBoxy(r == 1 ? "操作成功！" : "操作失败！", iframeId, true);
        }

        /// <summary>
        /// 获取表单值
        /// </summary>
        /// <returns></returns>
        private EyouSoft.Model.TourStructure.MRouteZhengCe GetFormValues()
        {
            var model = new EyouSoft.Model.TourStructure.MRouteZhengCe
                {
                    CompanyId = CurrentUserCompanyID,
                    FilePath = GetUploadImgPath(UploadZCFJ, ltrZCFJ),
                    IssueTime = DateTime.Now,
                    OperatorId = SiteUserInfo.UserId,
                    OperatorName = SiteUserInfo.Name,
                    Title = Utils.GetFormValue(txtTitle.UniqueID),
                    Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus>(Utils.GetFormValue("txtStatus"), EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.正常)
                };
            model.ZxsId = CurrentZxsId;

            return model;
        }

        /// <summary>
        /// 初始化已经上传的附件
        /// </summary>
        /// <param name="ltr"></param>
        /// <param name="strPath"></param>
        /// <param name="strFileName"></param>
        private void InitUploadImg(Literal ltr, string strPath, string strFileName)
        {
            if (ltr == null || string.IsNullOrEmpty(strPath)) return;

            var str = new System.Text.StringBuilder();

            str.Append("<div class='upload_filename'>&nbsp; ");
            str.AppendFormat(
                " <a href=\"{0}\" target=\"_blank\" title=\"查看附件\">{1}</a>",
                strPath,
                string.IsNullOrEmpty(strFileName) ? "查看附件" : strFileName);
            str.Append(" <a href=\"javascript:void(0);\" onclick=\"PolicyEdit.RemoveFile(this);return false;\" title=\"删除附件\"> ");
            str.Append(" <img style=\"vertical-align:middle\" src=\"/images/cha.gif\"> ");
            str.Append(" </a> ");
            str.AppendFormat(" <input type=\"hidden\" name=\"hide{0}File\" value=\"{1}\">", ltr.ClientID, strPath);
            str.Append("</div>");

            ltr.Text = str.ToString();
        }

        /// <summary>
        /// 获取线路附件
        /// </summary>
        /// <param name="uc">上传控件</param>
        /// <param name="ltr">对应的显示查看附件的容器控件</param>
        /// <returns></returns>
        private string GetUploadImgPath(UserControl.UploadControl uc, Literal ltr)
        {
            if (ltr == null) return string.Empty;

            string str = Utils.GetFormValue(uc.ClientHideID);
            if (string.IsNullOrEmpty(str))
            {
                string strOld = Utils.GetFormValue(string.Format("hide{0}File", ltr.ClientID));
                strOld = this.GetFilePathByKey(strOld, 1);

                return strOld;
            }

            return this.GetFilePathByKey(str, 1);
        }


        /// <summary>
        /// 获取分割后的上传控件文件路径
        /// </summary>
        /// <param name="index"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetFilePathByKey(string filePath, int index)
        {
            if (string.IsNullOrEmpty(filePath)) return string.Empty;
            if (index != 0 && index != 1) return string.Empty;

            var tmp = filePath.Split('|');
            if (tmp.Length <= 0 || tmp.Length > 2) return string.Empty;
            if (index > tmp.Length - 1) return tmp[tmp.Length - 1];

            return tmp[index];
        }

        /// <summary>
        /// 获取政策状态下拉菜单项
        /// </summary>
        /// <param name="_v">要选中的值 ((int)EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus).ToString()</param>
        /// <returns></returns>
        string GetStatusOptions(string _v)
        {
            string s = string.Empty;
            var items = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus));

            foreach (var item in items)
            {
                s += string.Format("<option value=\"{0}\" {1}>{2}</option>", item.Value, item.Value == _v ? "selected=\"selected\"" : string.Empty, item.Text);
            }

            return s;
        }
    }
}
