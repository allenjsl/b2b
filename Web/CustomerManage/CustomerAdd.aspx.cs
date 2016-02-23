using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.EnumType.CompanyStructure;
using EyouSoft.Model.EnumType.PrivsStructure;
using Web.UserControl;

namespace Web.CustomerManage
{
    /// <summary>
    /// 客户资料添加/修改
    /// 郑知远 2012-11-22
    /// </summary>
    public partial class CustomerAdd : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected string ShengFenId = "0";
        protected string ChengShiId = "0";

        /// <summary>
        /// 操作方式
        /// </summary>
        string CZFS = "INSERT";

        protected string EditId = string.Empty;

        bool Privs_Insert = false;
        bool Privs_Update = false;
        bool Privs_ZhuCeKeHuXiuGai = false;

        protected EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan LaiYuan = KeHuLaiYuan.系统添加;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("id");

            InitPrivs();

            //保存操作
            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "save": Save(); break;
                default: break;
            }

            InitWUC();

            //初始化界面
            if (CZFS=="INSERT")
            {
                this.InitAddInfo();
            }
            
            if(CZFS=="UPDATE")
            {
                this.InitEditInfo();
            }
        }

        #region private members

        /// <summary>
        /// 权限初始化
        /// </summary>
        void InitPrivs()
        {
            if (!this.CheckGrant(Privs3.客户管理_客户管理_栏目))
            {
                Utils.ResponseNoPermit(Privs3.客户管理_客户管理_栏目, false);
                return;
            }

            Privs_Insert = CheckGrant(Privs3.客户管理_客户管理_新增);
            Privs_Update = CheckGrant(Privs3.客户管理_客户管理_修改);
            Privs_ZhuCeKeHuXiuGai = CheckGrant(Privs3.客户管理_注册客户管理_注册客户修改);

            if (!string.IsNullOrEmpty(EditId)) CZFS = "UPDATE";

            if (CZFS == "INSERT")
            {
                if (Privs_Insert)
                {
                    ltrOperatorHtml.Text = "<a id=\"btnSave\" href=\"javascript:void(0);\">保存</a>";
                }
                else
                {
                    ltrOperatorHtml.Text = "";
                }
            }

            if (CZFS == "UPDATE")
            {
                if (Privs_Update)
                {
                    ltrOperatorHtml.Text = "<a id=\"btnSave\" href=\"javascript:void(0);\">保存</a>";
                }
                else
                {
                    ltrOperatorHtml.Text = "";
                }
            }
        }

        /// <summary>
        /// init wuc
        /// </summary>
        void InitWUC()
        {
            //协议上传控件初期化
            this.UploadControl1.CompanyID = SiteUserInfo.CompanyId;
            this.UploadControl1.IsUploadSelf = true;

            //初始化责任销售选用
            this.Seller1.ReadOnly = true;
            this.Seller1.IsShowSelect = true;
        }

        /// <summary>
        /// 获取合作协议
        /// </summary>
        /// <returns></returns>
        CompanyFile GetAttach()
        {
            var info = new EyouSoft.Model.CompanyStructure.CompanyFile();

            string attach = Utils.GetFormValue(this.UploadControl1.ClientHideID);
            if (string.IsNullOrEmpty(attach))
            {
                attach = Utils.GetFormValue("txtLatestAttach");
            }

            if (!string.IsNullOrEmpty(attach) && attach.IndexOf('|') > -1)
            {
                string[] attachs = attach.Split('|');

                if (attachs != null && attachs.Length == 2)
                {
                    info.FilePath = attachs[1];
                    info.FileId = attachs[0];
                }
            }

            return info;
        }

        /// <summary>
        /// 获取银行账户信息
        /// </summary>
        /// <returns>银行账户列表</returns>
        IList<CustomerBank> GetBanks()
        {
            IList<CustomerBank> items = new List<CustomerBank>();
            string[] BankAccountArray = Utils.GetFormValues("txtBankAccount");
            string[] BankNameArray = Utils.GetFormValues("txtBankName");
            string[] AccountNameArray = Utils.GetFormValues("txtAccountName");

            if (BankAccountArray == null || BankAccountArray.Length == 0) return null;

            for (int i = 0; i < BankNameArray.Length; i++)
            {
                var item = new CustomerBank();
                item.BankNo = BankAccountArray[i];
                item.BankName = BankNameArray[i];
                item.AccountName = AccountNameArray[i];
                item.CustomerId = Utils.GetQueryStringValue("id");

                if (string.IsNullOrEmpty(item.BankNo) && string.IsNullOrEmpty(item.BankName) && string.IsNullOrEmpty(item.AccountName)) continue;

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// 获取联系人信息
        /// </summary>
        /// <returns>联系人列表</returns>
        IList<CustomerContactInfo> GetLxrs()
        {
            IList<CustomerContactInfo> items = new List<CustomerContactInfo>();
            string[] txt_lxr_bumen = Utils.GetFormValues("txt_lxr_bumen");
            string[] txt_lxr_zhiwu = Utils.GetFormValues("txt_lxr_zhiwu");
            string[] txt_lxr_xingbie = Utils.GetFormValues("txt_lxr_xingbie");
            string[] txt_lxr_fax = Utils.GetFormValues("txt_lxr_fax");
            string[] txt_lxr_shouji = Utils.GetFormValues("txt_lxr_shouji");
            string[] txt_lxr_name = Utils.GetFormValues("txt_lxr_name");
            string[] txt_lxr_qq = Utils.GetFormValues("txt_lxr_qq");
            string[] txt_lxr_dianhua = Utils.GetFormValues("txt_lxr_dianhua");
            string[] txt_lxr_status = Utils.GetFormValues("txt_lxr_status");
            string[] txt_lxr_weixin = Utils.GetFormValues("txt_lxr_weixin");

            if (txt_lxr_name == null || txt_lxr_name.Length == 0) return null;

            for (int i = 0; i < txt_lxr_name.Length; i++)
            {
                var item = new CustomerContactInfo();
                item.ContactId = 0;
                item.CompanyId = this.CurrentUserCompanyID;
                item.DepartId = txt_lxr_bumen[i];
                item.Job = txt_lxr_zhiwu[i];
                item.Sex = (Sex)Utils.GetInt(txt_lxr_xingbie[i]);
                item.Fax = txt_lxr_fax[i];
                item.Mobile = txt_lxr_shouji[i];
                item.Name = txt_lxr_name[i];
                item.qq = txt_lxr_qq[i];
                item.Tel = txt_lxr_dianhua[i];
                item.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus>(txt_lxr_status[i], KeHuLxrStatus.不可修改不可删除);
                item.WeiXinHao = txt_lxr_weixin[i];

                if (string.IsNullOrEmpty(item.Name)) continue;

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// 保存按钮点击事件执行方法
        /// </summary>
        void Save()
        {
            var laiYuan = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.KeHuLaiYuan>(Utils.GetFormValue("txtLaiYuan"), KeHuLaiYuan.系统添加);
            if (CZFS == "INSERT")
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            if (CZFS == "UPDATE")
            {
                if (laiYuan == KeHuLaiYuan.系统添加)
                {
                    if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }

                if (laiYuan == KeHuLaiYuan.平台注册)
                {
                    if (!Privs_ZhuCeKeHuXiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
                }
            }

            var bll = new EyouSoft.BLL.CompanyStructure.Customer();
            var info = new CustomerInfo();
            info.Id = EditId;//客户编号
            info.ProviceId = Utils.GetInt(Utils.GetFormValue("txtShengFen"), 0);//省份编号
            info.CityId = Utils.GetInt(Utils.GetFormValue("txtChengShi"), 0);//城市编号
            info.Name = Utils.GetFormValue(this.txtName.UniqueID);//客户名称
            info.Licence = Utils.GetFormValue(this.txtLicense.UniqueID);//许可证
            info.Adress = Utils.GetFormValue(this.txtAddress.UniqueID);//地址
            info.PostalCode = Utils.GetFormValue(this.txtPostalCode.UniqueID);//邮编
            info.FilePath = this.GetAttach().FilePath;//合作协议
            info.SaleId = Utils.GetInt(Utils.GetFormValue(this.Seller1.SellsIDClient));//责任销售编号
            info.CompanyId = this.CurrentUserCompanyID;//公司编号
            info.ContactName = Utils.GetFormValue(this.txtContactName.UniqueID);//主要联系人
            info.Phone = Utils.GetFormValue(this.txtPhone.UniqueID);//主要联系人电话
            info.Mobile = Utils.GetFormValue(this.txtMobile.UniqueID);//主要联系人手机
            info.Fax = Utils.GetFormValue(this.txtFax.UniqueID);//主要联系人传真
            info.Remark = Utils.GetFormValue(this.txtRemark.UniqueID);//备注
            info.OperatorId = this.SiteUserInfo.UserId;//当前操作者编号
            info.IssueTime = DateTime.Now;//操作时间
            info.CustomerBank = this.GetBanks();//银行账号
            info.CustomerContact = this.GetLxrs();//联系人
            info.Type = Utils.GetEnumValue<CustomerType>(Utils.GetFormValue("txtKeHuLeiXing"), CustomerType.同行客户);
            info.FaRenName = Utils.GetFormValue(txtFaRen.UniqueID);
            info.YingYeZhiZhaoHao = Utils.GetFormValue(txtYingYeZhiZhaoHao.UniqueID);
            info.GongSiDianHua = Utils.GetFormValue(txtGongSiDianHua.UniqueID);
            info.GongSiFax = Utils.GetFormValue(txtGongSiFax.UniqueID);
            info.LxrQQ = Utils.GetFormValue(txtQQ.UniqueID);
            info.LxrEmail = Utils.GetFormValue(txtEmail.UniqueID);
            info.ZxsId = CurrentZxsId;
            info.LaiYuan = KeHuLaiYuan.系统添加;
            info.ShenHeStatus = KeHuShenHeStatus.已审核;
            info.JianMa = Utils.GetFormValue(txtJianMa.UniqueID);
            info.Annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
            //新上传的文件
            var fuJians1 = UploadControl2.Files;
            //原上传的文件
            var fuJians2 = UploadControl2.YuanFiles;

            if (fuJians1 != null && fuJians1.Count > 0)
            {
                foreach (var item in fuJians1)
                {
                    info.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            if (fuJians2 != null && fuJians2.Count > 0)
            {
                foreach (var item in fuJians2)
                {
                    info.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }


            int bllRetCode = 0;
            if (CZFS == "INSERT")
            {
                bllRetCode = bll.InsertKeHu(info);
            }
            if (CZFS == "UPDATE")
            {
                bllRetCode = bll.UpdateKeHu(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：已经存在相同的客户名称"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败，异常代码：" + bllRetCode.ToString()));
        }

        /// <summary>
        /// 初始化新增界面
        /// </summary>
        void InitAddInfo()
        {
            //初始化银行账号
            this.BindYinHangZhangHu();

            //初始化责任销售
            Seller1.SellsID = SiteUserInfo.UserId.ToString();
            Seller1.SellsName = SiteUserInfo.Name;

            ltrKeHuLeiXingOptions.Text = GetKeHuLeiXingOptions(string.Empty);
        }

        /// <summary>
        /// 初始化修改界面
        /// </summary>
        void InitEditInfo()
        {
            var model = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(EditId);
            if (model == null) RCWE("异常请求");

            this.ShengFenId = model.ProviceId.ToString();//省份编号
            this.ChengShiId = model.CityId.ToString();//城市编号
            this.txtName.Value = model.Name;//客户名称
            this.txtLicense.Value = model.Licence;//许可证号
            this.txtAddress.Value = model.Adress;//地址
            this.txtPostalCode.Value = model.PostalCode;//邮编
            this.Seller1.SellsID = model.SaleId.ToString();//责任销售编号
            this.Seller1.SellsName = model.Saler;//责任销售
            this.txtContactName.Value = model.ContactName;//主要联系人
            this.txtPhone.Value = model.Phone;//主要联系人电话
            this.txtMobile.Value = model.Mobile;//主要联系人手机
            this.txtFax.Value = model.Fax;//主要联系人传真

            //联系人信息列表
            if (model.CustomerContact != null && model.CustomerContact.Count > 0)
            {
                this.rptLianXiRen.DataSource = model.CustomerContact;
                this.rptLianXiRen.DataBind();
            }

            //银行账户信息列表
            if (model.CustomerBank != null && model.CustomerBank.Count > 0)
            {
                this.rptYinHangZhangHu.DataSource = model.CustomerBank;
                this.rptYinHangZhangHu.DataBind();
            }
            else
            {
                this.BindYinHangZhangHu();
            }

            //合作协议
            if (!string.IsNullOrEmpty(model.FilePath))
            {
                this.lblFile.Text = "<span class='upload_filename' id=\"spanLatestAttach\">&nbsp;<a href='" + model.FilePath + "' target='_blank'>查看附件</a><a href='javascript:void(0);' onclick=\"CustomerEdit.delLatestAttach()\"> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='txtLatestAttach' value='|" + model.FilePath + "'></span>";
            }

            //备注
            this.txtRemark.Text = model.Remark;

            ltrKeHuLeiXingOptions.Text = GetKeHuLeiXingOptions(((int)model.Type).ToString());

            txtFaRen.Value = model.FaRenName;
            txtYingYeZhiZhaoHao.Value = model.YingYeZhiZhaoHao;
            txtGongSiDianHua.Value = model.GongSiDianHua;
            txtGongSiFax.Value = model.GongSiFax;
            txtQQ.Value = model.LxrQQ;
            txtEmail.Value = model.LxrEmail;
            txtJianMa.Value = model.JianMa;

            if (model.Annexs != null && model.Annexs.Count > 0)
            {
                var annexs = new List<MFileInfo>();
                foreach (var item in model.Annexs)
                {
                    annexs.Add(new MFileInfo() { FilePath = item.FilePath });
                }
                UploadControl2.YuanFiles = annexs;
            }

            if (model.LaiYuan == KeHuLaiYuan.系统添加)
            {
                if (model.ZxsId != CurrentZxsId && SiteUserInfo.ZxsT1 != EyouSoft.Model.EnumType.PtStructure.ZxsT1.主专线商 && !Privs_Update)
                {
                    ltrOperatorHtml.Text = "";
                }
            }

            if (model.LaiYuan == KeHuLaiYuan.平台注册)
            {
                if (!Privs_ZhuCeKeHuXiuGai) ltrOperatorHtml.Text = "";
            }

            LaiYuan = model.LaiYuan;
        }

        /// <summary>
        /// 初始化银行账号
        /// </summary>
        void BindYinHangZhangHu()
        {
            //初始化银行账号
            var bankList = new List<CustomerBank>
                {
                    new CustomerBank()
                        { AccountName = string.Empty, BankName = string.Empty, BankNo = string.Empty }
                };
            rptYinHangZhangHu.DataSource = bankList;
            rptYinHangZhangHu.DataBind();
        }

        /// <summary>
        /// 获取客户类型下拉菜单选项
        /// </summary>
        /// <param name="sv">选中的值 ((int)枚举).ToString()</param>
        string GetKeHuLeiXingOptions(string sv)
        {
            if (string.IsNullOrEmpty(sv)) sv = ((int)EyouSoft.Model.EnumType.CompanyStructure.CustomerType.同行客户).ToString();
            StringBuilder s = new StringBuilder();
            var items = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.CustomerType));

            foreach (var item in items)
            {
                s.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.Value, item.Value == sv ? "selected='selected'" : "", item.Text);
            }

            return s.ToString();
        }
        #endregion
    }
}
