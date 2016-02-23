using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.ResourceManage
{
    /// <summary>
    /// 供应商管理：酒店管理
    /// 刘树超
    /// 2012-11-28
    /// </summary>
    public partial class HotelList : BackPage
    {
        #region Private Mebers
        protected int PageSize = 20;  //每页显示的记录
        protected int PageIndex = 1;  //页码
        protected int RecordCount = 0; //总记录数

        //查询条件设置
        protected int[] province = new int[1];
        protected int[] city = new int[1];
        protected int HotelStartValue = 0;
        protected string TxtHotelName = string.Empty;
        protected int len = 0;
        //操作类型变量 删除 导出excel
        protected string action = string.Empty;
        #endregion


        //权限变量
        protected bool add = false;//新增
        protected bool update = false;//修改
        protected bool del = false;//删除

        //酒店业务逻辑类和实体类
        protected EyouSoft.BLL.CompanyStructure.CompanySupplier HotelBll = null;
        EyouSoft.Model.CompanyStructure.SupplierHotel HotelModle = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            PowControl();
            //实例化酒店业务逻辑类和实体类
            HotelModle = new EyouSoft.Model.CompanyStructure.SupplierHotel();
            HotelBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();

            if (!this.Page.IsPostBack)
            {
                BindHotelStart();

                //操作类型变量 删除 导出excel
                action = Utils.GetQueryStringValue("action");
                switch (action)
                {
                    case "hoteldel":
                        {
                            if (del)
                            {
                                HotelDel();
                            }
                        }
                        break;
                    default:
                        DataInit();
                        break;
                }
            }
        }



        #region 绑定酒店星级
        protected void BindHotelStart()
        {
            //清空下拉框选项
            this.HotelStartList.Items.Clear();
            this.HotelStartList.Items.Add(new ListItem("--请选择酒店星级--", "-1"));
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
                    this.HotelStartList.Items.Add(item);
                }
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        private void HotelDel()
        {
            string stid = Utils.GetFormValue("tid");
            bool res = false;
            //删除酒店信息
            res = HotelBll.DeleteSupplierHotel(stid) == 1 ? true : false;

            Response.Clear();
            Response.Write(string.Format("{{\"res\":{0}}}", res ? 1 : -1));
            Response.End();
        }
        #endregion

        #region 初始化
        protected void DataInit()
        {
            //初使化条件
            PageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            province[0] = Utils.GetInt(Utils.GetQueryStringValue("province"));
            city[0] = Utils.GetInt(Utils.GetQueryStringValue("city"));
            TxtHotelName = Utils.GetQueryStringValue("HotelName");
            HotelStartValue = Utils.GetInt(Utils.GetQueryStringValue("HotelStartValue"));
            if (this.HotelStartList.Items.FindByValue(HotelStartValue.ToString()) != null)
            {
                this.HotelStartList.Items.FindByValue(HotelStartValue.ToString()).Selected = true;
            }

            //查询条件初始化
            EyouSoft.Model.CompanyStructure.QuerySupplierHotel Searchinfo = new EyouSoft.Model.CompanyStructure.QuerySupplierHotel();
            Searchinfo.Name = TxtHotelName;

            if (city == null || city[0] <= 0)
            {
                Searchinfo.CityId = null;
            }
            else
            {
                Searchinfo.CityId = city;
            }
            if (province == null || province[0] <= 0)
            {
                Searchinfo.ProvinceId = null;
            }
            else
            {
                Searchinfo.ProvinceId = province;
            }
            if (HotelStartValue == 0)
            {
                Searchinfo.Star = null;
            }
            else
            {
                Searchinfo.Star = (EyouSoft.Model.EnumType.CompanyStructure.HotelStar)Enum.Parse(typeof(EyouSoft.Model.EnumType.CompanyStructure.HotelStar), HotelStartValue.ToString());
            }
            Searchinfo.ZxsId = CurrentZxsId;

            IList<EyouSoft.Model.CompanyStructure.SupplierHotel> list = null;
            list = HotelBll.GetSupplierHotel(CurrentUserCompanyID, PageSize, PageIndex, ref RecordCount, Searchinfo);
            if (list.Count > 0 && list != null)
            {
                UtilsCommons.Paging(PageSize, ref PageIndex, RecordCount);
                //统计列表
                len = list.Count;
                //列表数据绑定           
                this.RepList.DataSource = list;
                this.RepList.DataBind();
                //设置分页
                BindPage();
            }
            else
            {

                this.ExporPageInfoSelect1.Visible = false;
                Literal1.Text = "<tr align=\"center\"> <td colspan=\"7\">没有相关数据</td></tr>";
            }

            list = null;
        }
        #endregion

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = PageSize;
            this.ExporPageInfoSelect1.CurrencyPage = PageIndex;
            this.ExporPageInfoSelect1.intRecordCount = RecordCount;
        }
        #endregion

        #region 酒店星级转化
        protected string GetStarValue(string StarValue)
        {
            string Star = "";
            switch (StarValue)
            {
                case "_3星以下": Star = "3星以下"; break;
                case "挂3": Star = "挂3星"; break;
                case "准3": Star = "准3星"; break;
                case "挂4": Star = "挂4星"; break;
                case "准4": Star = "准4星"; break;
                case "挂5": Star = "挂5星"; break;
                case "准5": Star = "准5星"; break;
                case "0": Star = "无星级"; break;
                default: break;
            }
            return Star;
        }
        #endregion

        #region 权限判断
        private void PowControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_酒店_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_酒店_栏目, true);
            }
            add = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_酒店_新增);
            update = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_酒店_修改);
            del = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_酒店_删除);

        }
        #endregion
    }
}
