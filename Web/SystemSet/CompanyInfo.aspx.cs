using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.BLL.CompanyStructure;
using EyouSoft.Common.Function;
using EyouSoft.Model.CompanyStructure;
using Web.UserControl;

namespace Web.SystemSet
{
    public partial class CompanyInfo : BackPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            PageInit();
        }

        #region private members
        /// <summary>
        /// 页面初始化
        /// </summary>
        void PageInit()
        {            
            EyouSoft.BLL.CompanyStructure.CompanyInfo companyBll = new EyouSoft.BLL.CompanyStructure.CompanyInfo();
            EyouSoft.Model.CompanyStructure.CompanyInfo infoModel = null;
            string method = Utils.GetFormValue("hidMethod");
            if (method == "save")
            {
                #region 保存公司信息
                if (Utils.InputText(txtCompanyName.Value) == "")
                {
                    MessageBox.Show(this, "公司名称不为空");
                    return;
                }
                //保存

                infoModel = new EyouSoft.Model.CompanyStructure.CompanyInfo();
                infoModel.CompanyAddress = Utils.InputText(txtAddress.Value);//地址
                infoModel.ContactName = Utils.InputText(txtAdmin.Value);//负责人
                infoModel.CompanyZip = Utils.InputText(txtEmail.Value);//邮箱
                infoModel.CompanyEnglishName = Utils.InputText(txtEngName.Value);//公司英文名
                infoModel.ContactFax = Utils.InputText(txtFax.Value);//公司传真
                infoModel.License = Utils.InputText(txtLicence.Value);//公司许可证
                infoModel.ContactMobile = Utils.InputText(txtMoible.Value);//公司手机
                infoModel.CompanyName = Utils.InputText(txtCompanyName.Value);//公司名
                infoModel.ContactTel = Utils.InputText(txtTel.Value);//电话
                infoModel.CompanyType = Utils.InputText(txtType.Value);//旅行社类别
                infoModel.CompanySiteUrl = Utils.InputText(txtWeb.Value);//网站
                infoModel.SystemId = CurrentUserCompanyID;//系统号
                infoModel.Id = CurrentUserCompanyID;//公司号

                bool result = companyBll.Update(infoModel);

                if (result)
                {
                    //要删除的公司附件
                    string[] delFiles = Utils.GetFormValues(UploadControl1.DelYuanFileIdClientName);
                    if (delFiles != null && delFiles.Length > 0)
                    {
                        companyBll.DeleteCompanyFile(delFiles);
                    }

                    //新上传的公司附件
                    string[] xinFiles = Utils.GetFormValues(UploadControl1.ClientHideID);
                    if (xinFiles != null && xinFiles.Length > 0)
                    {
                        IList<string> _xinFiles = new List<string>();
                        foreach (var xinFile in xinFiles)
                        {
                            string[] _arr = xinFile.Split('|');
                            if (_arr.Length == 2) _xinFiles.Add(_arr[1]);
                        }

                        companyBll.AddCompanyFile(CurrentUserCompanyID, _xinFiles);
                    }

                    //string[] yuanFiles = Utils.GetFormValues(UploadControl1.YuanFilePathClientName);
                }

                MessageBox.ShowAndRedirect(this, result ? "保存成功！" : "保存失败！", "/systemset/CompanyInfo.aspx");
                #endregion
            }
            else
            {
                #region 初始化公司信息
                //初始化
                infoModel = companyBll.GetModel(CurrentUserCompanyID, CurrentUserCompanyID);
                if (infoModel != null)
                {
                    txtAddress.Value = infoModel.CompanyAddress;//地址
                    txtAdmin.Value = infoModel.ContactName;//负责人
                    txtEmail.Value = infoModel.CompanyZip;//邮箱
                    txtEngName.Value = infoModel.CompanyEnglishName;//公司英文名
                    txtFax.Value = infoModel.ContactFax;//公司传真
                    txtLicence.Value = infoModel.License;//公司许可证
                    txtMoible.Value = infoModel.ContactMobile;//公司手机
                    txtCompanyName.Value = infoModel.CompanyName;//公司名
                    txtTel.Value = infoModel.ContactTel;//电话
                    txtType.Value = infoModel.CompanyType;//旅行社类别
                    txtWeb.Value = infoModel.CompanySiteUrl;//网站
                    if (infoModel.FilePath != null && infoModel.FilePath.Count > 0)
                    {
                        var items = new List<MFileInfo>();

                        foreach (var item in infoModel.FilePath)
                        {
                            MFileInfo file = new MFileInfo();
                            file.FileId = item.FileId;
                            file.FilePath = item.FilePath;
                            items.Add(file);
                        }

                        UploadControl1.YuanFiles = items;
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_公司信息_栏目))
            {
                Utils.ResponseNoPermit(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_公司信息_栏目, true);
                return;
            }

            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_公司信息_修改))
            {
                ltrOperatorHtml.Text = "<a href=\"javascript:;\" id=\"btn_save\" onclick=\"return save();\">保存</a>";
            }
            else
            {
                UploadControl1.IsChaKan = true;
                ltrOperatorHtml.Text = "<span id='btn_save'>你没有公司信息修改权限。</span>";
            }
        }
        #endregion

    }
}
