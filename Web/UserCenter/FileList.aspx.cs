using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class FileList : EyouSoft.Common.Page.BackPage
    {
        /// <summary>
        /// 每页显示条数(常量)
        /// </summary>
        public int pageSize = 10;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int pageIndex = 0;
        /// <summary>
        /// 总记录条数
        /// </summary>
        private int recordCount = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Ajax for Delete
            string type = Utils.GetFormValue("Type");
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Equals("Del"))
                {
                    Response.Clear();
                    Response.Write(Del(Utils.GetInt(Utils.GetFormValue("Id"))));
                    Response.End();
                }
            }
            if (!IsPostBack)
            {
                InitData();



            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            pageIndex = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("page"), 1);
            EyouSoft.BLL.PersonalCenterStructure.PersonDocument bll = new EyouSoft.BLL.PersonalCenterStructure.PersonDocument();
            IList<EyouSoft.Model.PersonalCenterStructure.PersonDocument> list = bll.GetList(pageSize, pageIndex, ref  recordCount, SiteUserInfo.CompanyId, 0,CurrentZxsId);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpFile.DataSource = list;
            this.rpFile.DataBind();

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


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string Del(int id)
        {
            string msg = string.Empty;

            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_文档管理_删除))
            {
                msg =
                    UtilsCommons.AjaxReturnJson(
                        "0",
                        string.Format(
                            "您没有{0}的权限，请线路管理员！", EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_文档管理_删除));

            }
            else
            {
                EyouSoft.BLL.PersonalCenterStructure.PersonDocument bll = new EyouSoft.BLL.PersonalCenterStructure.PersonDocument();

                string[] str = new string[] { id.ToString() };
                if (bll.Delete(str))
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "删除成功！");
                }
                else
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "删除失败！");
                }
            }
            return msg;
        }
        #endregion




    }
}
