using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.BLL.CompanyStructure;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using Web.UserControl;

namespace Web.ResourceManage
{
    /// <summary>
    ///功能：其他新增修改
    ///作者：刘树超
    /// </summary>
    public partial class OtherAdd : BackPage
    {

        #region form信息

        protected string type = string.Empty;//操作类型
        protected string tid = "";//非零为修改ID，0表示添加
        protected bool show = false;//type查看
        protected EyouSoft.Model.CompanyStructure.SupplierOther csModel = null;
        EyouSoft.BLL.CompanyStructure.CompanySupplier ssBLl = null;

        /// <summary>
        /// 省份编号
        /// </summary>
        protected int ProvinceId = 0;
        /// <summary>
        /// 城市编号
        /// </summary>
        protected int CityId = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            UploadControl1.CompanyID = CurrentUserCompanyID;
            ssBLl = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            csModel = new EyouSoft.Model.CompanyStructure.SupplierOther();

            if (!IsPostBack)
            {
                type = Utils.GetQueryStringValue("type");//获取操作（修改或添加）
                switch (type)
                {
                    case "modify"://如果是修改
                        bind();//获取原有数据
                        break;
                    case "show":
                        show = true;
                        bind();//获取原有数据
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Save();//保存或修改操作
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

            csModel = ssBLl.GetSupplierOther(tid);
            if (csModel == null) return;

            if (!string.IsNullOrEmpty(csModel.AgreementFile))
            {
                this.Label2.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidefile' value='{0}'/></span>", csModel.AgreementFile);
            }
            
            if (csModel.SupplierContact != null && csModel.SupplierContact.Count > 0)
            {
                Contact1.SetTravelList = csModel.SupplierContact;
            }
            if (csModel.SupplierBank != null && csModel.SupplierBank.Count > 0)
            {
                BankContact1.SetTravelList = csModel.SupplierBank;
            }
            this.txtAddress.Value = csModel.UnitAddress;
            this.unionname.Value = csModel.UnitName;
            this.remark.InnerText = csModel.Remark;

            ProvinceId = csModel.ProvinceId;
            CityId = csModel.CityId;

            if (csModel.Annexs != null && csModel.Annexs.Count > 0)
            {
                var annexs = new List<MFileInfo>();
                foreach (var item in csModel.Annexs)
                {
                    annexs.Add(new MFileInfo() { FilePath = item.FilePath });
                }
                UploadControl2.YuanFiles = annexs;
            }
        }

        /// <summary>
        /// 保存或修改信息
        /// </summary>
        private void Save()
        {
            tid = Utils.GetFormValue("tid");//获取表操作值
            if (!string.IsNullOrEmpty(tid))//判断添加或修改
            {
                csModel = ssBLl.GetSupplierOther(tid);//更具表单ID于公司ID获取供应商数据
            }
            else
            {
                csModel.SupplierType = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.其他;//
            }

            csModel.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtProvince"));
            csModel.CityId = Utils.GetInt(Utils.GetFormValue("txtCity"));
            csModel.UnitName = Utils.GetFormValue(this.unionname.UniqueID);//公司名称
            csModel.UnitAddress = Utils.GetFormValue(this.txtAddress.UniqueID);//公司地址
            csModel.CompanyId = this.SiteUserInfo.CompanyId;
            csModel.OperatorId = this.SiteUserInfo.UserId;
            csModel.Remark = Utils.GetFormValue(this.remark.UniqueID);

            #region 获取合作协议
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

            #region 获取银行账户
            csModel.SupplierBank = UtilsCommons.GetBankSupper(csModel.Id);
            #endregion

            #region 获取联系人
            csModel.SupplierContact = UtilsCommons.GetContactData();
            #endregion

            csModel.ZxsId = CurrentZxsId;

            bool res = false;
            if (!string.IsNullOrEmpty(tid))
            {
                res = ssBLl.UpdateSupplierOther(csModel) == 1 ? true : false;

            }
            else
            {
                res = ssBLl.AddSupplierOther(csModel) == 1 ? true : false;
            }

            if (res)
            {
                MessageBox.ResponseScript(this, string.Format(";alert('{0}');window.parent.Boxy.getIframeDialog('{1}').hide();{2}", "保存成功!", Utils.GetQueryStringValue("iframeId"), !string.IsNullOrEmpty(tid) ? "window.parent.location.reload();" : "window.parent.location.href='/ResourceManage/OtherList.aspx';"));
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
