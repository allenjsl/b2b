using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserCenter
{
    public partial class WorkCommunReply : EyouSoft.Common.Page.BackPage
    {
        #region attributes
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
        /// <summary>
        /// 查看匿名姓名权限
        /// </summary>
        bool Privs_ChaKanNiMingXingMing = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            InitPrivs();

            //Ajax
            string type = Utils.GetQueryStringValue("Type");
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Equals("Save"))
                {
                    Response.Clear();
                    Response.Write(Save());
                    Response.End();
                }
            }

            if (!IsPostBack)
            {
                InitData();
            }

        }

        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_工作交流回复))
            {
                RCWE(UtilsCommons.AjaxReturnJson("0", "没有操作权限"));
            }

            Privs_ChaKanNiMingXingMing = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.个人中心_工作交流_查看匿名姓名);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected void InitData()
        {
            int id = Utils.GetInt(Utils.GetQueryStringValue("Id"));
            if (id != 0)
            {
                EyouSoft.BLL.PersonalCenterStructure.WorkExchange bll = new EyouSoft.BLL.PersonalCenterStructure.WorkExchange();
                EyouSoft.Model.PersonalCenterStructure.WorkExchange model = bll.GetModel(id);
                if (model != null)
                {
                    bll.SetClicks(id);

                    this.hidId.Value = model.ExchangeId.ToString();
                    this.ltTitle.Text = model.Title;
                    this.ltContent.Text = model.Description;
                    this.ltOperatorName.Text = model.IsAnonymous == true ? "匿名" : model.OperatorName;
                    this.ltCreateDate.Text = model.CreateTime.ToString("yyyy-MM-dd");

                    pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
                    IList<EyouSoft.Model.PersonalCenterStructure.WorkExchangeReply> list = bll.GetList(SiteUserInfo.CompanyId, model.ExchangeId, pageSize, pageIndex, ref recordCount);
                    this.rpReply.DataSource = list;
                    this.rpReply.DataBind();
                    BindPage();
                }
            }

        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            //if (recordCount < 10)
            //{
            //    this.ExporPageInfoSelect1.Visible = false;
            //}
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
        }
        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        protected string Save()
        {
            string msg = string.Empty;
            string content = Utils.GetFormValue("Content");
            if (string.IsNullOrEmpty(content))
            {
                msg += "回复内容不能为空！ </br>";
            }
            if (msg.Length <= 0)
            {
                int exchangeId = Utils.GetInt(Utils.GetFormValue("Id"));
                bool IsAnonymous = Utils.GetFormValue("IsAnonymous") == "1";
                // AddReply(EyouSoft.Model.PersonalCenterStructure.WorkExchangeReply model)   
                EyouSoft.Model.PersonalCenterStructure.WorkExchangeReply model = new EyouSoft.Model.PersonalCenterStructure.WorkExchangeReply();
                model.ExchangeId = exchangeId;
                model.Description = content;
                model.OperatorId = SiteUserInfo.UserId;
                model.ReplyTime = DateTime.Now;
                model.IsAnonymous = IsAnonymous;
                EyouSoft.BLL.PersonalCenterStructure.WorkExchange bll = new EyouSoft.BLL.PersonalCenterStructure.WorkExchange();
                if (bll.AddReply(model))
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("1", "回复成功！");
                }
                else
                {
                    msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "回复失败！");
                }
            }
            else
            {
                msg = EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", msg);
            }
            return msg;

        }

        /// <summary>
        /// 获取回复人姓名
        /// </summary>
        /// <returns></returns>
        protected string GetHuiFuRenName(object isNiMing,object name)
        {
            if (isNiMing == null) isNiMing = false;
            if (name == null) name = string.Empty;

            if (Privs_ChaKanNiMingXingMing || !(bool)isNiMing)
            {
                return name.ToString();
            }

            return "匿名";
        }
    }
}
