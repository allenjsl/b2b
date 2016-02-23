using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.CompanyStructure;

namespace Web.ResourceManage
{
    /// <summary>
    /// 票务列表 
    /// 作者：刘树超
    /// </summary>
    public partial class TicketList : BackPage
    {
        #region 分页变量
        protected int pageSize = 20;
        protected int pageIndex = 1;
        protected int recordCount;


        protected int[] province = new int[1];
        protected int[] city = new int[1];
        protected string unionName = string.Empty;
        EyouSoft.BLL.CompanyStructure.CompanySupplier csBll = null;
        protected int len = 0;
        protected string act = string.Empty;


        //权限变量
        protected bool add = false;//新增
        protected bool update = false;//修改
        protected bool del = false;//删除

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            PowControl();

            csBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            act = EyouSoft.Common.Utils.GetQueryStringValue("act");
            if (!IsPostBack)
            {
                switch (act)
                {
                    case "ticketdel":
                        if (del)
                        {
                            TicketDel();
                        }
                        break;
                    default:
                        DataInit();
                        break;
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void TicketDel()
        {
            string stid = Utils.GetFormValue("tid");

            int res = 0;
            if (!string.IsNullOrEmpty(stid))
            {
                res = csBll.DeleteSupplierTicket(stid);
            }


            Response.Clear();
            Response.Write(string.Format("{{\"res\":{0}}}", res == 1 ? 1 : -1));
            Response.End();
        }

        /// <summary>
        /// 初使化
        /// </summary>
        private void DataInit()
        {
            //初使化条件
            QuerySupplierTicket serModel = new QuerySupplierTicket();

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            province[0] = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("province"));
            if (province[0] > 0)
            {
                serModel.ProvinceId = province;
            }
            city[0] = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("city"));
            if (city[0] > 0)
            {
                serModel.CityId = city;
            }
            unionName = EyouSoft.Common.Utils.GetQueryStringValue("unionName");
            serModel.Name = unionName;
            serModel.ZxsId = CurrentZxsId;
            IList<EyouSoft.Model.CompanyStructure.SupplierTicket> list = null;
            list = csBll.GetSupplierTicket(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, serModel);


            len = list.Count;
            if (list != null && list.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.rptList.DataSource = list;
                this.rptList.DataBind();
                //设置分页
                BindPage();
            }
        }



        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion

        #region 权限判断
        private void PowControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_票务_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_票务_栏目, true);
            }
            add = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_票务_新增);
            update = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_票务_修改);
            del = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_票务_删除);

        }
        #endregion
    }
}
