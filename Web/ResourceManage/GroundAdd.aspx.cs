using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using Web.UserControl;

namespace Web.ResourceManage
{
    /// <summary>
    /// 功能：地接新增修改
    /// 作者：刘树超
    /// </summary>
    public partial class GroundAdd : BackPage
    {
        #region form信息

        protected string type = string.Empty;
        protected string tid = "";
        protected bool show = false;

        protected EyouSoft.Model.CompanyStructure.SupplierLocal csModel = null;
        EyouSoft.BLL.CompanyStructure.CompanySupplier csBll = null;

        /// <summary>
        /// 省份编号
        /// </summary>
        protected int ProvinceId = 0;
        /// <summary>
        /// 城市编号
        /// </summary>
        protected int CityId = 0;
        #endregion

        /// <summary>
        /// 地接的增加和修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            csBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            csModel = new EyouSoft.Model.CompanyStructure.SupplierLocal();            
            this.UploadControl1.CompanyID = CurrentUserCompanyID;
            if (IsPostBack)
            {
                Save();
            }
            else
            {
                type = Utils.GetQueryStringValue("type");
                switch (type)
                {
                    case "modify":
                        bind();
                        break;
                    case "show":
                        show = true;
                        bind();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 绑定要修改数据
        /// </summary>
        /// <param name="tid"></param>
        private void bind()
        {
            tid = Utils.GetQueryStringValue("tid");
            if (string.IsNullOrEmpty(tid)) return;

            csModel = csBll.GetSupplierLocal(tid);
            if (csModel == null) return;

            if (!string.IsNullOrEmpty(csModel.AgreementFile))
            {
                this.lbfilename.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidefile' value='{0}'/></span>", csModel.AgreementFile);
            }

            if (csModel.Annexs != null && csModel.Annexs.Count > 0)
            {
                var annexs = new List<MFileInfo>();
                foreach (var item in csModel.Annexs)
                {
                    annexs.Add(new MFileInfo() { FilePath = item.FilePath });
                }
                UploadControl2.YuanFiles = annexs;
            }

            if (csModel.SupplierContact != null && csModel.SupplierContact.Count > 0)
            {
                Contact1.SetTravelList = csModel.SupplierContact;
            }
            if (csModel.SupplierBank != null && csModel.SupplierBank.Count > 0)
            {
                BankContact1.SetTravelList = csModel.SupplierBank;
            }
            this.unionname.Value = csModel.UnitName;
            this.txtAddress.Value = csModel.UnitAddress;
            this.remark.InnerText = csModel.Remark;

            ProvinceId = csModel.ProvinceId;
            CityId = csModel.CityId;
        }

        /// <summary>
        /// 保存或修改信息
        /// </summary>
        private void Save()
        {
            tid = Utils.GetFormValue("tid");
            if (!string.IsNullOrEmpty(tid))
            {
                csModel = csBll.GetSupplierLocal(tid);
            }
            //省份编号
            csModel.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtProvince"));
            //城市编号
            csModel.CityId = Utils.GetInt(Utils.GetFormValue("txtCity"));
            //单位名称
            csModel.UnitName = Utils.GetFormValue(this.unionname.UniqueID);

            if (csModel.UnitName.Length == 1)
            {
                csModel.UnitName += " ";
            }
            //地址
            csModel.UnitAddress = Utils.GetFormValue(this.txtAddress.UniqueID);

            //备注
            csModel.Remark = Utils.GetFormValue(this.remark.UniqueID);
            //公司编号
            csModel.CompanyId = this.SiteUserInfo.CompanyId;
            //操作人
            csModel.OperatorId = this.SiteUserInfo.UserId;

            #region  获取合作协议
            string filename = Utils.GetFormValue(UploadControl1.ClientHideID);
            string oldname = Utils.GetFormValue("hidefile");
            if (string.IsNullOrEmpty(filename))
            {
                csModel.AgreementFile = oldname;
            }
            else
            {
                csModel.AgreementFile = filename.Split('|')[1].ToString();
            }
            #endregion

            #region 其它附件
            csModel.Annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
            //新上传的文件
            var fuJians1 = UploadControl2.Files;
            //原上传的文件
            var fuJians2 = UploadControl2.YuanFiles;

            if (fuJians1 != null && fuJians1.Count > 0)
            {
                foreach (var item in fuJians1)
                {
                    csModel.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            if (fuJians2 != null && fuJians2.Count > 0)
            {
                foreach (var item in fuJians2)
                {
                    csModel.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            #endregion

            #region 获取供应商联系人
            csModel.SupplierContact = UtilsCommons.GetContactData();
            #endregion

            #region 获取银行账户
            csModel.SupplierBank = UtilsCommons.GetBankSupper(csModel.Id);
            #endregion

            csModel.ZxsId = CurrentZxsId;
            
            bool res = false;
            if (!string.IsNullOrEmpty(tid))
            {
                res = csBll.UpdateSupplierLocal(csModel) == 1 ? true : false;
            }
            else
            {
                res = csBll.AddSupplierLocal(csModel) == 1 ? true : false;
            }

            if (res)
            {
                MessageBox.ResponseScript(this, string.Format(";alert('{0}');window.parent.Boxy.getIframeDialog('{1}').hide();{2}", "保存成功！", Utils.GetQueryStringValue("iframeId"), !string.IsNullOrEmpty(tid) ? "window.parent.location.reload();" : "window.parent.location.href='/ResourceManage/GroundList.aspx';"));
            }
            else
            {
                MessageBox.ResponseScript(this, ";alert('保存失败!');");
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
            base.OnInit(e);
        }

    }
}
