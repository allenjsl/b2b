using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class VacaList : EyouSoft.Common.Page.BackPage
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
                InitDate();
            }
        }


        protected void InitDate()
        {
            pageIndex = EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("page"), 1);
            EyouSoft.BLL.PersonalCenterStructure.BUserLeave bll = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave();
            var chaXun = new EyouSoft.Model.PersonalCenterStructure.MQingJiaChaXunInfo();
            chaXun.ZxsId = CurrentZxsId;
            chaXun.QingJiaRenId = SiteUserInfo.UserId;

            IList<EyouSoft.Model.PersonalCenterStructure.UserLeave> list = bll.GetLst(pageSize, pageIndex, ref recordCount, SiteUserInfo.CompanyId, chaXun);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            this.rpVaca.DataSource = list;
            this.rpVaca.DataBind();

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
            EyouSoft.BLL.PersonalCenterStructure.BUserLeave bll = new EyouSoft.BLL.PersonalCenterStructure.BUserLeave();
            int flg = bll.Del(id);

            if (flg == 1)
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "删除成功！");
            }
            else if (flg == -1)
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请假已审核不允许删除！");
            }
            else
            {
                return EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "删除失败！");
            }
        }
        #endregion

    }
}
