using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;

namespace Web.ResourceManage
{
    /// <summary>
    /// 供应商管理-地接
    /// </summary>
    /// 刘树超
    public partial class GroundList : BackPage
    {
        #region 变量
        /// <summary>
        /// 每页显示记录条数
        /// </summary>
        protected int pageSize = 20;
        /// <summary>
        /// 显示第几页
        /// </summary>
        protected int pageIndex = 1;
        /// <summary>
        /// 总记录条数
        /// </summary>
        protected int recordCount;

        /// <summary>
        /// 省份id
        /// </summary>
        protected int[] province = new int[1];
        /// <summary>
        /// 城市id
        /// </summary>
        protected int[] city = new int[1];
        /// <summary>
        /// 查询条件
        /// </summary>
        protected string unionName = string.Empty;
        /// <summary>
        /// 操作
        /// </summary>
        protected string act = string.Empty;
        /// <summary>
        /// 业务逻辑层
        /// </summary>
        EyouSoft.BLL.CompanyStructure.CompanySupplier csBll = null;
        /// <summary>
        /// 记录条数
        /// </summary>
        protected int len = 0;


        //权限变量
        protected bool add = false;//新增
        protected bool update = false;//修改
        protected bool del = false;//删除

        /// <summary>
        /// 账号管理权限
        /// </summary>
        protected bool Privs_ZhangHaoGuanLi = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            PowControl();
            //初始化比BLL
            csBll = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            //操作赋值
            act = EyouSoft.Common.Utils.GetQueryStringValue("act");
            if (!IsPostBack)
            {
                switch (act)
                {
                    //删除
                    case "areadel":
                        if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_删除))
                        {
                            AreaDel();
                        }
                        break;
                    default:
                        //加载数据
                        DataInit();
                        break;
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void AreaDel()
        {
            string stid = Utils.GetFormValue("tid");

            bool res = false;
            res = csBll.DeleteSupplierLocal(stid) == 1 ? true : false;

            Response.Clear();
            Response.Write(string.Format("{{\"res\":{0}}}", res ? 1 : -1));
            Response.End();
        }

        /// <summary>
        /// 初使化
        /// </summary>
        private void DataInit()
        {
            //初使化条件
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            //获取查询省份
            province[0] = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("province"));
            //获取查询城市
            city[0] = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("city"));
            //获取查询名称
            unionName = EyouSoft.Common.Utils.GetQueryStringValue("unionName");
            //初始化List
            IList<EyouSoft.Model.CompanyStructure.SupplierLocal> list = null;
            EyouSoft.Model.CompanyStructure.QuerySupplierLocal searchModel = new EyouSoft.Model.CompanyStructure.QuerySupplierLocal();

            if (city[0] != 0)
            {

                searchModel.CityId = city;
            }

            if (province[0] != 0)
            {
                searchModel.ProvinceId = province;
            }

            searchModel.Name = unionName;

            searchModel.ZxsId = CurrentZxsId;

            //分页获取数据
            list = csBll.GetSupplierLocal(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, searchModel);


            //绑定数据
            if (list != null && list.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.rptList.DataSource = list;
                this.rptList.DataBind();
            }
            else
            {
                Literal1.Text = "<tr align=\"center\"> <td colspan=\"7\">没有相关数据</td></tr>";
            }


            //设置分页
            BindPage();

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
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_栏目, true);
            }
            add = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_新增);
            update = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_修改);
            del = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_删除);

            Privs_ZhangHaoGuanLi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社_账号管理);
            Privs_ZhangHaoGuanLi = false;
        }
        #endregion
    }
}
