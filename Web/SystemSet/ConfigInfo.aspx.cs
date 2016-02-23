//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using EyouSoft.Common;
//using EyouSoft.Common.Page;
//using EyouSoft.BLL.CompanyStructure;

//namespace Web.SystemSet
//{
//    public partial class ConfigInfo : BackPage
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            PowerControl();
//            ucchapterImg.CompanyID = SiteUserInfo.CompanyId;
//            ucchapterImg.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
//            ucfooterImg.CompanyID = SiteUserInfo.CompanyId;
//            ucfooterImg.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
//            ucheaderImg.CompanyID = SiteUserInfo.CompanyId;
//            ucheaderImg.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
//            uclogo.CompanyID = SiteUserInfo.CompanyId;
//            uclogo.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
//            ucprintImg.CompanyID = SiteUserInfo.CompanyId;
//            ucprintImg.FileTypes = "*.dot";

//            if (Utils.GetQueryStringValue("dotype") == "save")
//            {
//                Save();
//            }
//            PageInit();

//        }
//        /// <summary>
//        /// 页面初始化
//        /// </summary>
//        protected void PageInit()
//        {
//            EyouSoft.Model.CompanyStructure.CompanyFieldSetting model = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetSetting(SiteUserInfo.CompanyId);
//            if (model != null)
//            {
//                /*if (model.ReservationTime > 0)
//                {
//                    this.txthour.Value = (model.ReservationTime / 60).ToString();
//                }*/

//                if (!string.IsNullOrEmpty(model.PageHeadFile))
//                {
//                    lbfileheadimg.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='PrintConfig.RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidYM' value='{0}'/></span>", model.PageHeadFile);
//                }
//                if (!string.IsNullOrEmpty(model.PageFootFile))
//                {
//                    lbfilefooterimg.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='PrintConfig.RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidYJ' value='{0}'/></span>", model.PageFootFile);
//                }
//                if (!string.IsNullOrEmpty(model.CompanyStamp))
//                {
//                    lbfilechapterimg.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='PrintConfig.RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidchapter' value='{0}'/></span>", model.CompanyStamp);
//                }
//                if (!string.IsNullOrEmpty(model.CompanyLogo))
//                {
//                    lbfilelogo.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='PrintConfig.RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidlogo' value='{0}'/></span>", model.CompanyLogo);
//                }
//                if (!string.IsNullOrEmpty(model.TemplateFile))
//                {
//                    lbfileprintimg.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='PrintConfig.RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hideprint' value='{0}'/></span>", model.TemplateFile);
//                }
//            }
//        }


//        protected void Save()
//        {
//            string filePageMei = Utils.GetFormValue(ucheaderImg.ClientHideID);
//            string filePageFoot = Utils.GetFormValue(ucfooterImg.ClientHideID);
//            string filechapterImg = Utils.GetFormValue(ucchapterImg.ClientHideID);
//            string filelogo = Utils.GetFormValue(uclogo.ClientHideID);
//            string fileprint = Utils.GetFormValue(ucprintImg.ClientHideID);

//            //int TotalMinute = Utils.GetInt(Utils.GetFormValue(txthour.UniqueID)) * 60;
//            EyouSoft.Model.CompanyStructure.CompanyFieldSetting model = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetSetting(CurrentUserCompanyID);
//            model = model ?? new EyouSoft.Model.CompanyStructure.CompanyFieldSetting();
//            if (!string.IsNullOrEmpty(filePageMei))
//                model.PageHeadFile = filePageMei.Split('|')[1];
//            else
//                model.PageHeadFile = Utils.GetFormValue("hidYM");

//            if (!string.IsNullOrEmpty(filePageFoot))
//                model.PageFootFile = filePageFoot.Split('|')[1];
//            else
//                model.PageFootFile = Utils.GetFormValue("hidYJ");

//            if (!string.IsNullOrEmpty(filechapterImg))
//                model.CompanyStamp = filechapterImg.Split('|')[1];
//            else
//                model.CompanyStamp = Utils.GetFormValue("hidchapter");//word
//            if (!string.IsNullOrEmpty(filelogo))
//                model.CompanyLogo = filelogo.Split('|')[1];
//            else
//                model.CompanyLogo = Utils.GetFormValue("hidlogo");//gz
//            if (!string.IsNullOrEmpty(fileprint))
//                model.TemplateFile = fileprint.Split('|')[1];
//            else
//                model.TemplateFile = Utils.GetFormValue("hideprint");
//            model.CompanyId = SiteUserInfo.CompanyId;
//            //model.ReservationTime = TotalMinute;

//            Response.Clear();
//            if (new EyouSoft.BLL.CompanyStructure.CompanySetting().SetCompanySetting(model))
//            {
//                Response.Write(UtilsCommons.AjaxReturnJson("1", "修改成功!"));
//            }
//            else
//            {
//                Response.Write(UtilsCommons.AjaxReturnJson("0", "修改失败!"));
//            }
//            Response.End();
//        }
//        /// <summary>
//        /// 权限判断
//        /// </summary>
//        private void PowerControl()
//        {
//            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_系统配置_栏目))
//            {
//                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_系统配置_栏目, false);
//                return;
//            }
//        }

//        /// <summary>
//        /// 重写OnPreInit 指定页面类型
//        /// </summary>
//        /// <param name="e"></param>
//        protected override void OnPreInit(EventArgs e)
//        {
//            base.OnPreInit(e);
//            this.PageType = PageType.general;
//        }
//    }
//}
