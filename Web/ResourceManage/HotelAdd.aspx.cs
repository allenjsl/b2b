using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Function;
using EyouSoft.Common.Page;
using EyouSoft.Model.CompanyStructure;
using Web.UserControl;

namespace Web.ResourceManage
{

    /// <summary>
    /// 酒店修改
    /// 刘树超
    /// </summary>
    public partial class HotelAdd : BackPage
    {
        #region 变量
        //操作类型
        protected string type = string.Empty;
        //酒店编号
        protected string tid = string.Empty;
        /// <summary>
        /// 记录图片列表的行数
        /// </summary>
        protected int photo_row = 1;
        //酒店业务逻辑类和实体类
        protected EyouSoft.Model.CompanyStructure.SupplierHotel Hotelinfo = null;
        EyouSoft.BLL.CompanyStructure.CompanySupplier HotelBll = null;
        protected bool show = false;//是否查看
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
            //实例化酒店业务逻辑类和实体类
            Hotelinfo = new EyouSoft.Model.CompanyStructure.SupplierHotel();
            HotelBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            
            this.UploadControl1.CompanyID = CurrentUserCompanyID;

            if (!IsPostBack)
            {
                BindHotelStart();

                type = Utils.GetQueryStringValue("type");
                switch (type)
                {
                    case "modify":
                        Databind();
                        break;
                    case "show":
                        LinkButton1.Visible = false;
                        Databind();
                        break;
                    default:
                        photo_row = 0;
                        break;
                }

            }
        }

        #region 绑定酒店星级
        protected void BindHotelStart()
        {
            //清空下拉框选项
            this.HotelStart.Items.Clear();
            this.HotelStart.Items.Add(new ListItem("--请选择酒店星级--", "-1"));
            List<EnumObj> HotelStart = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.HotelStar));
            if (HotelStart.Count > 0 && HotelStart != null)
            {
                for (int i = 0; i < HotelStart.Count; i++)
                {
                    ListItem item = new ListItem();
                    switch (HotelStart[i].Value)
                    {
                        case "1": item.Text = "3星以下"; break;
                        case "2": item.Text = "挂3"; break;
                        case "3": item.Text = "准3"; break;
                        case "4": item.Text = "挂4"; break;
                        case "5": item.Text = "准4"; break;
                        case "6": item.Text = "挂5"; break;
                        case "7": item.Text = "准5"; break;
                        default: break;
                    }
                    item.Value = HotelStart[i].Value;
                    this.HotelStart.Items.Add(item);
                }
            }
        }
        #endregion

        #region 初始化酒店信息
        private void Databind()
        {
            tid = Utils.GetQueryStringValue("tid");
            if (string.IsNullOrEmpty(tid)) return;
            Hotelinfo = HotelBll.GetSupplierHotel(tid);
            if (Hotelinfo == null) return;

            if (this.HotelStart.Items.FindByValue(((int)Hotelinfo.Star).ToString()) != null)
                this.HotelStart.Items.FindByValue(((int)Hotelinfo.Star).ToString()).Selected = true;
            if (Hotelinfo.SupplierPic != null && Hotelinfo.SupplierPic.Count > 0)
            {
                BindPhoto(Hotelinfo.SupplierPic);
            }
            else
            {
                photo_row = 0;
            }
            if (Hotelinfo != null && Hotelinfo.SupplierContact.Count > 0)
            {
                Contact1.SetTravelList = Hotelinfo.SupplierContact;
            }
            if (Hotelinfo != null && Hotelinfo.SupplierBank.Count > 0)
            {
                BankContact1.SetTravelList = Hotelinfo.SupplierBank;
            }
            this.TxtHotelAddress.Value = Hotelinfo.UnitAddress;
            this.HotelRemarks.InnerText = Hotelinfo.Remark;
            this.unionname.Value = Hotelinfo.UnitName;
            this.HotelIntroduction.InnerText = Hotelinfo.Introduce;
            this.TourGuids.InnerText = Hotelinfo.TourGuide;

            ProvinceId = Hotelinfo.ProvinceId;
            CityId = Hotelinfo.CityId;

            //合作协议
            MFileInfo file = new MFileInfo();
            file.FilePath = Hotelinfo.AgreementFile;
            var items = new List<MFileInfo>();
            items.Add(file);
            UploadHeZuoXieYi.YuanFiles = items;

            if (Hotelinfo.Annexs != null && Hotelinfo.Annexs.Count > 0)
            {
                var annexs = new List<MFileInfo>();
                foreach (var item in Hotelinfo.Annexs)
                {
                    annexs.Add(new MFileInfo() { FilePath = item.FilePath });
                }
                UploadControl2.YuanFiles = annexs;
            }
        }
        #endregion

        //弹窗设置
        protected override void OnInit(EventArgs e)
        {
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
            base.OnInit(e);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //接受参数
            tid = Utils.GetQueryStringValue("tid");
            if (!string.IsNullOrEmpty(tid))
            {
                //Hotelinfo = HotelBll.GetSupplierHotel(tid);
                Hotelinfo.Id = tid;
            }
            else
            {
                Hotelinfo.SupplierType = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.酒店;
            }
            //省份编号
            Hotelinfo.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtProvince"));            
            //城市编号
            Hotelinfo.CityId = Utils.GetInt(Utils.GetFormValue("txtCity"));
            //单位名称
            string unionname = Utils.GetFormValue(this.unionname.UniqueID);
            //酒店星级
            int HotelStart = Utils.GetInt(Utils.GetFormValue(this.HotelStart.UniqueID));
            //酒店地址
            string TxtHotelAddress = Utils.GetFormValue(this.TxtHotelAddress.UniqueID);
            //酒店简介
            string HotelIntroduction = Utils.GetFormValue(this.HotelIntroduction.UniqueID);
            //导游词
            string TourGuids = Utils.GetFormValue(this.TourGuids.UniqueID);
            //当前公司编号
            Hotelinfo.CompanyId = this.SiteUserInfo.CompanyId;
            //当前操作人编号
            Hotelinfo.OperatorId = this.SiteUserInfo.UserId;

            #region 酒店图片
            List<EyouSoft.Model.CompanyStructure.SupplierPic> picList = new List<EyouSoft.Model.CompanyStructure.SupplierPic>();
            string[] UploadFile = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            string[] picId = Utils.GetFormValues("hidefile");
            if (UploadFile.Length > 0)
            {

                for (int i = 0; i < UploadFile.Length; i++)
                {
                    EyouSoft.Model.CompanyStructure.SupplierPic picModel = new EyouSoft.Model.CompanyStructure.SupplierPic();
                    picModel.PicPath = UploadFile[i].Split('|')[1];
                    picModel.SupplierId = tid;
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
                    picModel.SupplierId = tid;
                    picList.Add(picModel);
                }

            }
            Hotelinfo.SupplierPic = picList;
            #endregion

            #region 联系人信息
            Hotelinfo.SupplierContact = UtilsCommons.GetContactData();
            #endregion

            #region 价格信息
            Hotelinfo.RoomTypes = new List<EyouSoft.Model.CompanyStructure.SupplierHotelRoomType>();
            string[] Chamber = Utils.GetFormValues("Chamber");
            string[] SalaesPrices = Utils.GetFormValues("SalaesPrices");
            string[] SettlementPrice = Utils.GetFormValues("SettlementPrice");
            string[] radiobtnValue = Utils.GetFormValues("hd_rbtn");
            for (int j = 0; j < Chamber.Length; j++)
            {
                EyouSoft.Model.CompanyStructure.SupplierHotelRoomType roomtype = new EyouSoft.Model.CompanyStructure.SupplierHotelRoomType();
                roomtype.AccountingPrice = Utils.GetDecimal(SettlementPrice[j]);
                if (radiobtnValue[j] == "1") { roomtype.IsBreakfast = true; }
                else { roomtype.IsBreakfast = false; }
                roomtype.Name = Chamber[j];
                roomtype.SellingPrice = Utils.GetDecimal(SalaesPrices[j]);
                Hotelinfo.RoomTypes.Add(roomtype);
            }
            #endregion

            #region 银行账户
            Hotelinfo.SupplierBank = UtilsCommons.GetBankSupper(tid);
            #endregion

            //合作协议
            string file = Utils.GetFormValue(UploadHeZuoXieYi.ClientHideID);
            if (!string.IsNullOrEmpty(file))
            {
                string[] _arr = file.Split('|');
                if (_arr.Length == 2) Hotelinfo.AgreementFile = _arr[1];
            }
            if (string.IsNullOrEmpty(Hotelinfo.AgreementFile)) Hotelinfo.AgreementFile = Utils.GetFormValue(UploadHeZuoXieYi.YuanFilePathClientName);

            //备注
            string HotelRemarks = Utils.GetFormValue(this.HotelRemarks.UniqueID);

            Hotelinfo.UnitName = unionname;
            Hotelinfo.UnitAddress = TxtHotelAddress;
            Hotelinfo.Star = (EyouSoft.Model.EnumType.CompanyStructure.HotelStar)Enum.Parse(typeof(EyouSoft.Model.EnumType.CompanyStructure.HotelStar), HotelStart.ToString());
            Hotelinfo.Introduce = HotelIntroduction;
            Hotelinfo.TourGuide = TourGuids;
            Hotelinfo.Remark = HotelRemarks;
            Hotelinfo.IssueTime = System.DateTime.Now;

            #region 其它附件
            Hotelinfo.Annexs = new List<EyouSoft.Model.CompanyStructure.CompanyFile>();
            //新上传的文件
            var fuJians1 = UploadControl2.Files;
            //原上传的文件
            var fuJians2 = UploadControl2.YuanFiles;

            if (fuJians1 != null && fuJians1.Count > 0)
            {
                foreach (var item in fuJians1)
                {
                    Hotelinfo.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            if (fuJians2 != null && fuJians2.Count > 0)
            {
                foreach (var item in fuJians2)
                {
                    Hotelinfo.Annexs.Add(new EyouSoft.Model.CompanyStructure.CompanyFile() { FilePath = item.FilePath });
                }
            }

            #endregion

            Hotelinfo.ZxsId = CurrentZxsId;

            int res = 0;
            if (!string.IsNullOrEmpty(tid))
            {
                //修改酒店信息
                res = HotelBll.UpdateSupplierHotel(Hotelinfo);
            }
            else
            {
                //添加酒店信息
                res = HotelBll.AddSupplierHotel(Hotelinfo);
            }

            if (res > 0)
            {
                MessageBox.ResponseScript(this, string.Format(";alert('{0}');window.parent.Boxy.getIframeDialog('{1}').hide(); {2}", "保存成功!", Utils.GetQueryStringValue("iframeId"), !string.IsNullOrEmpty(tid) ? "window.parent.location.reload();" : "window.parent.location.href='/ResourceManage/HotelList.aspx';"));
            }
            else
            {
                MessageBox.ResponseScript(this, ";alert('保存失败!');");
            }
        }

        /// <summary>
        /// 绑定景点图片
        /// </summary>
        /// <param name="pics">数据源</param>
        protected void BindPhoto(IList<EyouSoft.Model.CompanyStructure.SupplierPic> pics)
        {
            this.rplfile.DataSource = pics;
            this.rplfile.DataBind();
        }
    }
}
