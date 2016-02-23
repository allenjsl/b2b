using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.Model.CompanyStructure;


namespace Web.ResourceManage
{
    public partial class OtherList : BackPage
    {
        #region 变量

        protected int pageSize = 20;
        protected int pageIndex = 1;
        protected int recordCount;

        protected string unionName = string.Empty;
        protected int len = 0;//列表长度
        //权限变量
        protected bool add = false;//新增
        protected bool update = false;//修改
        protected bool del = false;//删除
        EyouSoft.BLL.CompanyStructure.CompanySupplier csBLL = null;

        QuerySupplierOther queryModel = null;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            PowControl();

            string act = string.Empty;
            csBLL = new EyouSoft.BLL.CompanyStructure.CompanySupplier();
            act = EyouSoft.Common.Utils.GetQueryStringValue("act");
            if (!IsPostBack)
            {
                switch (act)
                {
                    case "areadel":
                        if (del)
                        {
                            AreaDel();
                        }
                        break;
                    default:
                        DataInit();
                        break;
                }
            }
        }

        /// <summary>
        /// 初使化
        /// </summary>
        private void DataInit()
        {
            //初使化条件
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            unionName = EyouSoft.Common.Utils.GetQueryStringValue("unionName");

            IList<EyouSoft.Model.CompanyStructure.SupplierOther> list = null;
            queryModel = new QuerySupplierOther();
            queryModel.Name = unionName;
            queryModel.ZxsId = CurrentZxsId;
            list = csBLL.GetSupplierOther(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, queryModel);

            if (list != null)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                len = list.Count;
                this.rptList.DataSource = list;
                this.rptList.DataBind();
                list = null;
            }
            else
            {
                Literal1.Text = "<tr align=\"center\"> <td colspan=\"7\">没有相关数据</td></tr>";
            }
            //设置分页
            BindPage();


        }


        /// <summary>
        /// 删除数据
        /// </summary>
        private void AreaDel()
        {
            string tid = Utils.GetFormValue("tid");
            bool res = false;
            if (!string.IsNullOrEmpty(tid))
            {
                res = csBLL.DeleteSupplierOther(tid) == 1 ? true : false;

            }

            Response.Clear();
            Response.Write(string.Format("{{\"res\":{0}}}", res ? 1 : -1));
            Response.End();
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
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_其它_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_其它_栏目, true);
            }
            add = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_其它_新增);
            update = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_其它_修改);
            del = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_其它_删除);

        }
        #endregion
    }
}
