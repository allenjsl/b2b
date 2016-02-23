using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.Model.EnumType.CompanyStructure;

namespace Web.ResourceManage
{
    /// <summary>
    /// 创建:刘树超
    /// 功能:景点列表
    /// </summary>
    public partial class ScenicList : BackPage
    {
        EyouSoft.BLL.CompanyStructure.CompanySupplier sightBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
        #region 设置分页变量
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 15;
        #endregion

        #region 查询条件
        protected int[] provinceId = new int[1];
        protected int[] cityId = new int[1];
        protected int scStar = 0;
        protected string scName = string.Empty;
        #endregion

        #region 权限变量
        protected bool add = false;//新增
        protected bool update = false;//修改
        protected bool del = false;//删除
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            PowControl();

            if (!IsPostBack)
            {
                BindHotelStart();
                string act = Utils.GetQueryStringValue("act");              //判断是否为导出操作
                pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);     //取得页面上的pageindex值.

                provinceId[0] = Utils.GetInt(Utils.GetQueryStringValue("proid"));
                cityId[0] = Utils.GetInt(Utils.GetQueryStringValue("cityId"));
                scName = Utils.GetQueryStringValue("sight_name");
                scStar = Utils.GetInt(Utils.GetQueryStringValue("star"));
                //页面初始化方法
                PageInit();
            }


        }
        #region 绑定页面数据
        protected void PageInit()
        {
            EyouSoft.Model.CompanyStructure.QuerySupplierSpot sightSearchInfo = new EyouSoft.Model.CompanyStructure.QuerySupplierSpot();
            IList<EyouSoft.Model.CompanyStructure.SupplierSpot> sights = new List<EyouSoft.Model.CompanyStructure.SupplierSpot>();
            #region 设置景点的查询条件值
            if (cityId[0] > 0)
            {
                sightSearchInfo.CityId = cityId;
            }
            if (provinceId[0] > 0)
            {
                sightSearchInfo.ProvinceId = provinceId;
            }
            if (!string.IsNullOrEmpty(scName))
            {
                sightSearchInfo.Name = scName;
            }
            if (scStar > 0)
            {
                sightSearchInfo.Star = (EyouSoft.Model.EnumType.CompanyStructure.ScenicSpotStar)Enum.Parse(typeof(EyouSoft.Model.EnumType.CompanyStructure.ScenicSpotStar), scStar.ToString());
            }
            #endregion

            #region 控件赋值
            ScenicSpotStar? star = (ScenicSpotStar)Utils.GetInt(Utils.GetQueryStringValue("ddlstar"));

            this.sight_name.Value = scName;
            if (this.ddlscStar.Items.FindByValue(scStar.ToString()) != null)
            {
                this.ddlscStar.Items.FindByValue(scStar.ToString()).Selected = true;
            }
            #endregion

            sightSearchInfo.ZxsId = CurrentZxsId;

            sights = sightBll.GetSupplierSpot(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, sightSearchInfo);
            if (sights != null && sights.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.rptList.DataSource = sights;
                this.rptList.DataBind();
                BindExportPage();           //绑定分页控件
            }



        }
        #endregion
        #region 获得联系人信息
        /// <summary>
        /// 获得联系人信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected string GetContactInfo(object list)
        {
            string str = "";

            IList<EyouSoft.Model.CompanyStructure.SupplierContact> contactList = (List<EyouSoft.Model.CompanyStructure.SupplierContact>)list;
            if (contactList != null && contactList.Count > 0)
            {
                str = "<td align=\"center\">" + contactList[0].ContactName + "</td><td align=\"center\">" + contactList[0].ContactTel + "</td><td align=\"center\">" + contactList[0].ContactFax + "</td>";
            }
            else
            {
                str = "<td align=\"center\"></td><td align=\"center\"></td><td align=\"center\"></td>";
            }


            return str;
        }
        #endregion


        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExportPageInfo1.intPageSize = pageSize;
            this.ExportPageInfo1.CurrencyPage = pageIndex;
            this.ExportPageInfo1.intRecordCount = recordCount;
        }
        #endregion

        /// <summary>
        /// 星级过滤掉"_"字符
        /// </summary>
        /// <param name="star"></param>
        /// <returns></returns>
        protected string DisponseStar(string star)
        {
            if (star.Trim() != "" || star != null)
            {
                star = star.Substring(1, star.Length - 1);
                return star;
            }
            else
            {
                return "";
            }

        }

        #region 绑定星级
        protected string getStarScenic()
        {
            string star = "";
            List<EnumObj> scenicStar = EnumObj.GetList(typeof(ScenicSpotStar));
            if (scenicStar.Count > 0 && scenicStar != null)
            {
                for (int i = 0; i < scenicStar.Count; i++)
                {
                    switch (scenicStar[i].Value)
                    {
                        case "1": star += "<option value='1'>一星</option>"; break;
                        case "2": star += "<option value='2'>二星</option>"; break;
                        case "3": star += "<option value='3'>三星</option>"; break;
                        case "4": star += "<option value='4'>四星</option>"; break;
                        case "5": star += "<option value='5'>五星</option>"; break;
                        default: break;
                    }
                }
            }
            return star;
        }
        #endregion

        #region 绑定酒店星级
        protected void BindHotelStart()
        {
            //清空下拉框选项
            this.ddlscStar.Items.Clear();
            this.ddlscStar.Items.Add(new ListItem("--请选择景点星级--", "-1"));
            List<EnumObj> scStart = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ScenicSpotStar));
            if (scStart.Count > 0 && scStart != null)
            {
                for (int i = 0; i < scStart.Count; i++)
                {
                    ListItem item = new ListItem();
                    switch (scStart[i].Value)
                    {
                        case "1": item.Text = "一星"; break;
                        case "2": item.Text = "二星"; break;
                        case "3": item.Text = "三星"; break;
                        case "4": item.Text = "四星"; break;
                        case "5": item.Text = "五星"; break;
                        default: break;
                    }
                    item.Value = scStart[i].Value;
                    this.ddlscStar.Items.Add(item);
                }
            }
        }
        #endregion

        #region 权限判断
        private void PowControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_景点_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_景点_栏目, true);
            }
            add = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_景点_新增);
            update = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_景点_修改);
            del = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_景点_删除);

        }
        #endregion
    }
}
