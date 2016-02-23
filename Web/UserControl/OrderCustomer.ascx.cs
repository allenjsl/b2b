using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;
using System.ComponentModel;

namespace Web.UserControl
{
    /// <summary>
    /// 订单游客控件
    /// </summary>
    public partial class OrderCustomer : System.Web.UI.UserControl
    {
        /// <summary>
        /// 获取或者设置游客集合
        /// </summary>
        public IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> CustomerList { get; set; }

        /// <summary>
        /// 游客是否可以编辑(修改、删除；默认 false 根据游客状态控制游客是否可以被修改和删除；赋值true后 不控制游客是否可编辑)
        /// </summary>
        [Bindable(true)]
        public bool IsEditOrderCustomer { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                CustomerList = GetCustomerList();
            }
            else
            {
                InitControl();
            }
        }

        #region 获取表单中的游客信息

        /// <summary>
        /// 获取表单中的游客信息
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MTourOrderTraveller> GetCustomerList()
        {
            string[] name = Utils.GetFormValues("txt_OrderCustomer_Name");
            string[] type = Utils.GetFormValues("ddl_OrderCustomer_CustomerType");
            string[] card = Utils.GetFormValues("ddl_OrderCustomer_CustomerCard");
            string[] cardNo = Utils.GetFormValues("txt_OrderCustomer_CardNo");
            string[] tel = Utils.GetFormValues("txt_OrderCustomer_Tel");
            string[] sex = Utils.GetFormValues("ddl_OrderCustomer_CustomerSex");
            string[] id = Utils.GetFormValues("hid_OrderCustomer_CustomerId");
            string[] status = Utils.GetFormValues("ddl_OrderCustomer_Status");

            if (id == null || name == null || type == null || card == null || cardNo == null || tel == null || sex == null
                || id.Length != name.Length || name.Length != type.Length || type.Length != card.Length
                || card.Length != cardNo.Length || cardNo.Length != tel.Length || tel.Length != sex.Length || sex.Length != status.Length)
            {
                return null;
            }

            var list = new List<EyouSoft.Model.TourStructure.MTourOrderTraveller>();
            for (int i = 0; i < name.Length; i++)
            {
                //没有填写名称，整行数据不保存
                if (string.IsNullOrEmpty(name[i])) continue;

                list.Add(new EyouSoft.Model.TourStructure.MTourOrderTraveller
                    {
                        TravellerId = id[i],
                        TravellerName = name[i],
                        TravellerType = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.TravellerType>(type[i], EyouSoft.Model.EnumType.TourStructure.TravellerType.成人),
                        CardType = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.CardType>(card[i], EyouSoft.Model.EnumType.TourStructure.CardType.未知),
                        CardNumber = cardNo[i],
                        Sex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)Utils.GetInt(sex[i]),
                        Contact = tel[i],
                        TravellerStatus = Utils.GetEnumValue(status[i], EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团)
                    });
            }

            return list;
        }

        #endregion

        /// <summary>
        /// 初始化游客信息
        /// </summary>
        private void InitControl()
        {
            if (CustomerList == null || !CustomerList.Any()) plnAdd.Visible = true;
            else
            {
                plnAdd.Visible = false;

                rptCustomer.DataSource = CustomerList;
                rptCustomer.DataBind();
            }
        }

        #region 前台方法

        /// <summary>
        /// 获取游客是否可编辑
        /// </summary>
        /// <param name="ticketStatus">游客机票状态</param>
        /// <returns></returns>
        protected bool GetCustomerIsEdit(int ticketStatus)
        {
            if (!IsEditOrderCustomer)
            {
                if (ticketStatus > 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 生成游客类型下拉框
        /// </summary>
        /// <param name="id">要选中的项的值</param>
        /// <returns></returns>
        protected string GetCustomerType(object id)
        {

            var strHtml = new StringBuilder();
            string strValue = ((int)EyouSoft.Model.EnumType.TourStructure.TravellerType.成人).ToString();
            if (id != null && !string.IsNullOrEmpty(id.ToString())) strValue = id.ToString();
            strHtml.AppendFormat(
                " <select class=\"inputselect\" name=\"ddl_OrderCustomer_CustomerType\" id=\"ddl_{0}\" > ",
                new Random().Next(1000, 99999));
            var list = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.TravellerType), new string[] { "2" });
            foreach (var t in list)
            {
                if (t == null || string.IsNullOrEmpty(t.Value) || string.IsNullOrEmpty(t.Text)) continue;

                strHtml.AppendFormat(
                    " <option value=\"{0}\" {2}>{1}</option> ",
                    t.Value,
                    t.Text,
                    t.Value == strValue ? "selected=\"selected\"" : string.Empty);

            }
            strHtml.Append(" </select> ");

            return strHtml.ToString();
        }

        /// <summary>
        /// 生成游客证件类型下拉框
        /// </summary>
        /// <param name="id">要选中的项的值</param>
        /// <returns></returns>
        protected string GetCustomerCard(object id)
        {
            var strHtml = new StringBuilder();
            string strValue = ((int)EyouSoft.Model.EnumType.TourStructure.CardType.身份证).ToString();
            if (id != null && !string.IsNullOrEmpty(id.ToString())) strValue = id.ToString();
            strHtml.AppendFormat(
                " <select class=\"inputselect\" name=\"ddl_OrderCustomer_CustomerCard\" id=\"ddl_{0}\" > ",
                new Random().Next(1000, 99999));
            var list = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.CardType));
            foreach (var t in list)
            {
                if (t == null || string.IsNullOrEmpty(t.Value) || string.IsNullOrEmpty(t.Text)) continue;

                strHtml.AppendFormat(
                    " <option value=\"{0}\" {2}>{1}</option> ",
                    t.Value,
                    t.Text,
                    t.Value == strValue ? "selected=\"selected\"" : string.Empty);
            }
            strHtml.Append(" </select> ");

            return strHtml.ToString();
        }

        /// <summary>
        /// 生成性别下拉框
        /// </summary>
        /// <param name="id">要选中的项的值</param>
        /// <returns></returns>
        protected string GetCustomerSex(object id)
        {
            var strHtml = new StringBuilder();
            string strValue = ((int)EyouSoft.Model.EnumType.CompanyStructure.Sex.未知).ToString();
            if (id != null && !string.IsNullOrEmpty(id.ToString())) strValue = id.ToString();
            strHtml.AppendFormat(" <select class=\"inputselect\" name=\"ddl_OrderCustomer_CustomerSex\" id=\"ddl_{0}\" > ",
                new Random().Next(1000, 99999));
            var list = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.Sex));
            foreach (var t in list)
            {
                if (t == null || string.IsNullOrEmpty(t.Value) || string.IsNullOrEmpty(t.Text)) continue;

                strHtml.AppendFormat(
                    " <option value=\"{0}\" {2}>{1}</option> ",
                    t.Value,
                    t.Text,
                    t.Value == strValue ? "selected=\"selected\"" : string.Empty);
            }
            strHtml.Append(" </select> ");

            return strHtml.ToString();
        }

        /// <summary>
        /// 生成游客状态下拉框
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetCustomerStatus(int status)
        {
            var strHtml = new StringBuilder();
            strHtml.AppendFormat(" <select data-isEdit='1' class=\"inputselect\" name=\"ddl_OrderCustomer_Status\" id=\"ddl_{0}\" > ",
                new Random().Next(1000, 99999));
            var list = EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.TravellerStatus));
            foreach (var t in list)
            {
                if (t == null || string.IsNullOrEmpty(t.Value) || string.IsNullOrEmpty(t.Text)) continue;

                strHtml.AppendFormat(
                    " <option value=\"{0}\" {2}>{1}</option> ",
                    t.Value,
                    t.Text,
                    t.Value == status.ToString() ? "selected=\"selected\"" : string.Empty);
            }
            strHtml.Append(" </select> ");

            return strHtml.ToString();
        }

        #endregion
    }
}