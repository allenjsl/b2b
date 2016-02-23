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
    /// 景点增加
    /// 作者：刘树超
    /// </summary>
    public partial class ScenicAdd : BackPage
    {
        #region attributes
        protected bool show = false;//是否查看
        protected int linkman_row = 1;        //联系人的数量,初始为1
        protected string sid = "";                //景点的ID
        protected string type;                //操作的类型{add,modify,dels}
        protected bool hz_img_state = false;    //用以判断有合作协议来控制层的显隐
        protected bool jd_img_state = false;    //用以判断景点是否又图片来控制层的显隐
        protected EyouSoft.Model.CompanyStructure.SupplierSpot sight = new EyouSoft.Model.CompanyStructure.SupplierSpot(); //生成一个全局景点类
        EyouSoft.BLL.CompanyStructure.CompanySupplier sightBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
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
            sid = Utils.GetQueryStringValue("sid");
            UploadControl1.CompanyID = CurrentUserCompanyID;
            UploadControl2.CompanyID = CurrentUserCompanyID;
            type = Utils.GetQueryStringValue("type");

            //判断操作类型-添加操作
            if (type == "add")
            {
                sight = new EyouSoft.Model.CompanyStructure.SupplierSpot();
                BindStatrs("");
            }
            //修改操作
            else if (type == "modify")
            {
                InitPage(sid);
            }
            //删除操作
            else if (type == "dels")
            {
                string str = Utils.GetQueryStringValue("ids");
                bool result = false;
                result = sightBll.DeleteSupplierSpot(str) == 1 ? true : false;
                Response.Clear();
                Response.Write(result);
                Response.End();
            }
            else if (type == "show")
            {
                show = true;
                this.btnSave.Visible = false;
                InitPage(sid);

            }
        }

        #region 初始化页面
        protected void InitPage(string sid)
        {
            sight = new EyouSoft.Model.CompanyStructure.SupplierSpot();
            sight = sightBll.GetSupplierSpot(sid);
            if (sight == null) return;

            BindStatrs(((int)sight.Start).ToString());
            this.txt_remark.Value = sight.Remark;
            this.txt_zc.Value = sight.UnitPolicy;
            this.companyAddress.Value = sight.UnitAddress;
            this.companyName.Value = sight.UnitName;
            this.single_price.Value = Utils.FilterEndOfTheZeroString(Utils.GetDecimal(Convert.ToString(sight.TravelerPrice)).ToString("0.00"));
            this.rl_price.Value = Utils.FilterEndOfTheZeroString(Utils.GetDecimal(Convert.ToString(sight.TeamPrice)).ToString("0.00"));
            this.guideworld.Value = sight.TourGuide;

            //联系人列表
            if (sight.SupplierContact != null && sight.SupplierContact.Count > 0)
            {
                this.Contact1.SetTravelList = sight.SupplierContact;
            }
            //合作协议
            if (!string.IsNullOrEmpty(sight.AgreementFile))
            {
                this.Label2.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>查看</a><a href='javascript:void(0);' onclick='RemoveFile(this);return false;'> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' name='hidefile' value='{0}'/></span>", sight.AgreementFile);
            }
            //景点图片
            if (sight.SupplierPic != null && sight.SupplierPic.Count > 0)
            {
                this.rplfile.DataSource = sight.SupplierPic;
                this.rplfile.DataBind();

            }
            
            //银行账户
            if (sight.SupplierBank != null && sight.SupplierBank.Count > 0)
            {
                BankContact1.SetTravelList = sight.SupplierBank;
            }

            ProvinceId = sight.ProvinceId;
            CityId = sight.CityId;

            if (sight.Annexs != null && sight.Annexs.Count > 0)
            {
                var annexs = new List<MFileInfo>();
                foreach (var item in sight.Annexs)
                {
                    annexs.Add(new MFileInfo() { FilePath = item.FilePath });
                }
                UploadControl3.YuanFiles = annexs;
            }
        }
        #endregion

        #region 绑定星级选择控件
        protected void BindStatrs(string selectIndex)
        {

            this.sel_star.Items.Clear();
            this.sel_star.Items.Add(new ListItem("-请选择-", "0"));
            IList<EnumObj> list = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ScenicSpotStar));
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Value = list[i].Value;
                    item.Text = list[i].Text.Substring(1, list[i].Text.Length - 1);
                    this.sel_star.Items.Add(item);
                }
            } if (selectIndex != "")
            {
                this.sel_star.SelectedValue = selectIndex;
            }
        }
        #endregion

        #region 获取页面控件的值并提交
        protected void GetLinkMnasAndSubmit()
        {




            sight = new EyouSoft.Model.CompanyStructure.SupplierSpot();
            //获取页面上所有联系人的信息
            IList<EyouSoft.Model.CompanyStructure.SupplierContact> contacts = new List<EyouSoft.Model.CompanyStructure.SupplierContact>();

            #region  获取联系人
            contacts = UtilsCommons.GetContactData();
            #endregion

            #region 获取银行账户
            sight.SupplierBank = UtilsCommons.GetBankSupper(sight.Id);
            #endregion

            #region 获取景点图片
            List<EyouSoft.Model.CompanyStructure.SupplierPic> picList = new List<EyouSoft.Model.CompanyStructure.SupplierPic>();
            string[] UploadFile = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            string[] picId = Utils.GetFormValues("hidefilePIC");
            if (UploadFile.Length > 0)
            {

                for (int i = 0; i < UploadFile.Length; i++)
                {
                    EyouSoft.Model.CompanyStructure.SupplierPic picModel = new EyouSoft.Model.CompanyStructure.SupplierPic();
                    picModel.PicPath = UploadFile[i].Split('|')[1].ToString();
                    picModel.SupplierId = sid;
                    picList.Add(picModel);
                }
            }
            if (picId != null && picId.Length > 0)
            {
                for (int i = 0; i < picId.Length; i++)
                {
                    EyouSoft.Model.CompanyStructure.SupplierPic picModel = new EyouSoft.Model.CompanyStructure.SupplierPic();
                    if (picId[i].Split('|').Length > 1)
                    {
                        picModel.Id = Utils.GetInt(picId[i].Split('|')[0]);
                        picModel.PicPath = picId[i].Split('|')[1];
                    }
                    picModel.SupplierId = sid;
                    picList.Add(picModel);
                }

            }
            sight.SupplierPic = picList;
            #endregion

            #region 获取合作协议
            string filename = Utils.GetFormValue(UploadControl2.ClientHideID);
            string oldname = Utils.GetFormValue("hidefile");
            if (string.IsNullOrEmpty(filename))
            {
                sight.AgreementFile = oldname;
            }
            else
            {
                sight.AgreementFile = filename.Split('|')[1].ToString();
            }
            #endregion

            #region 其它附件
            sight.Annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
            //新上传的文件
            var fuJians1 = UploadControl3.Files;
            //原上传的文件
            var fuJians2 = UploadControl3.YuanFiles;

            if (fuJians1 != null && fuJians1.Count > 0)
            {
                foreach (var item in fuJians1)
                {
                    sight.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            if (fuJians2 != null && fuJians2.Count > 0)
            {
                foreach (var item in fuJians2)
                {
                    sight.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            #endregion

            sight.CompanyId = CurrentUserCompanyID;
            //设置景点的省份名字
            sight.CityId = Utils.GetInt(Utils.GetFormValue("txtCity"));
            sight.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtProvince"));
            //为要更新的景点赋值
            sight.Id = sid;
            sight.Remark = Utils.GetFormValue(this.txt_remark.UniqueID);
            sight.SupplierContact = contacts;
            sight.Start = (EyouSoft.Model.EnumType.CompanyStructure.ScenicSpotStar)Utils.GetInt(Utils.GetFormValue(this.sel_star.UniqueID));
            sight.TeamPrice = Utils.GetDecimal(Utils.GetFormValue(this.rl_price.UniqueID));
            sight.TourGuide = Utils.GetFormValue(this.guideworld.UniqueID);
            sight.TravelerPrice = Utils.GetDecimal(Utils.GetFormValue(this.single_price.UniqueID));
            sight.UnitAddress = Utils.GetFormValue(this.companyAddress.UniqueID);
            sight.UnitName = Utils.GetFormValue(this.companyName.UniqueID);
            sight.UnitPolicy = Utils.GetFormValue(this.txt_zc.UniqueID); ;
            sight.SupplierType = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.景点;
            sight.ZxsId = CurrentZxsId;

            bool result = false;
            //操作类型判断
            if (type == "add")
            {
                //添加
                result = sightBll.AddSupplierSpo(sight) == 1 ? true : false;
            }
            else if (type == "modify")
            {
                //更新
                result = sightBll.UpdateSupplierSpot(sight) == 1 ? true : false;
            }
            //返回true操作成功,返回false操作失败
            if (result == true)
            {
                MessageBox.ResponseScript(this, string.Format(";alert('{0}');window.parent.location='/ResourceManage/ScenicList.aspx';window.parent.Boxy.getIframeDialog('{1}').hide()", "保存成功", Utils.GetQueryStringValue("iframeId")));
            }
            else
            {
                MessageBox.ResponseScript(this, ";alert('保存失败!');");
            }

        }
        #endregion

        //设定该页面为弹窗页面
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EyouSoft.Model.CompanyStructure.SupplierSpot sight = new EyouSoft.Model.CompanyStructure.SupplierSpot();
            GetLinkMnasAndSubmit();
        }


    }
}
