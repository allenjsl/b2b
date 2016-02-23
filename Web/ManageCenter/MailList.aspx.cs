using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ManageCenter
{
    using System.Text;

    using EyouSoft.BLL.AdminCenterStructure;
    using EyouSoft.Common;
    using EyouSoft.Common.Page;

    public partial class MailList : BackPage
    {
        #region 分页参数
        /// <summary>
        /// 页大小
        /// </summary>
        protected int pageSize = 20;
        /// <summary>
        /// 页码
        /// </summary>
        protected int pageIndex = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        private int recordCount = 0;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ITitle = "内部通讯录_行政中心";
            if (!IsPostBack)
            {
                //权限判断
                PowerControl();
                //初始化
                DataInit();
            }
            if (UtilsCommons.IsToXls()) ToXls();
        }

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void DataInit()
        {
            //获取分页参数并强转
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            string sectionName = Utils.GetQueryStringValue(this.SelectSection1.SelectNameClient);
            string sectionID = Utils.GetQueryStringValue(this.SelectSection1.SelectIDClient);
            this.SelectSection1.SectionName = sectionName;
            this.SelectSection1.SectionID = sectionID;
            string txtName = Utils.GetQueryStringValue("txtName");//姓名
            var s = Utils.GetQueryStringValue("select");
            var BLL = new PersonnelInfo();
            var lst = BLL.GetList(this.pageSize, this.pageIndex, ref this.recordCount, this.SiteUserInfo.CompanyId, txtName, Utils.GetIntNull(sectionID), sectionName, s);
            if (null != lst && lst.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                this.RepList.DataSource = lst;
                this.RepList.DataBind();
                if (recordCount <= pageSize)
                {
                    this.ExporPageInfoSelect1.Visible = false;
                    this.ExporPageInfoSelect1.intRecordCount = recordCount;
                }
                else
                {
                    BindPage();
                }
            }
            else
            {
                this.RepList.Controls.Add(new Label() { Text = "<tr><td colspan='10' align='center'>对不起，没有相关数据！</td></tr>" });
                this.ExporPageInfoSelect1.Visible = false;

            }
        }
        #endregion

        #region 绑定分页
        /// <summary>
        /// 绑定分页
        /// </summary>
        private void BindPage()
        {            
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion

        #region 获取部门
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string getSectionInfo(object o)
        {
            if (null == o)
                return "";
            string[] strArr = { };
            List<string> lstStr = new List<string>();
            var lst = (IList<EyouSoft.Model.CompanyStructure.Department>)o;
            if (null != lst && lst.Count > 0)
            {
                foreach (EyouSoft.Model.CompanyStructure.Department m in lst)
                {
                    lstStr.Add(m.DepartName);
                }
            }
            strArr = lstStr.ToArray();
            return strArr == null ? "" : String.Join(",", strArr);
        }
        #endregion

        /// <summary>
        /// 导出
        /// </summary>
        void ToXls()
        {
            string browser = this.Context.Request.UserAgent.ToUpper();
            int toXlsRecordCount = UtilsCommons.GetToXlsRecordCount();
            if (toXlsRecordCount < 1) ResponseToXls(string.Empty);
            int recordCount = 0;
            StringBuilder s = new StringBuilder();
            var BLL = new PersonnelInfo();
            var data = BLL.GetList(toXlsRecordCount, 1, ref recordCount, this.SiteUserInfo.CompanyId, Utils.GetQueryStringValue("txtName"), Utils.GetIntNull(Utils.GetQueryStringValue(this.SelectSection1.SelectIDClient)), Utils.GetQueryStringValue(this.SelectSection1.SelectNameClient), Utils.GetQueryStringValue("select"));
            if (data != null && data.Count > 0)
            {
                s.AppendFormat("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/><table border='1' style='border-collapse:collapse;'><tr><th width='105'>姓名</th><th width='107'>部门</th><th width='168'>电话</th><th width='158'>手机</th><th width='168'>E-mail</th><th width='164'>QQ</th><th width='164'>MSN</th>");
                foreach (var item in data)
                {
                    s.AppendFormat("<tr><td align='center'>{0}</td><td align='center'>{1}</td><td align='center'>{2}</td><td align='center'>{3}</td><td align='center'>{4}</td><td align='center'>{5}</td><td align='center'>{6}</td></tr>", item.UserName, getSectionInfo(item.DepartmentList), item.ContactTel, item.ContactMobile, item.Email, item.QQ, item.MSN);
                }
                s.AppendFormat("</table>");
            }
            string fileName = "内部通讯录";
            if (browser.Contains("MS") && browser.Contains("IE"))
            {
                fileName = System.Web.HttpUtility.UrlEncode(fileName, Encoding.UTF8);
            }
            ResponseToXls(s.ToString(), Encoding.UTF8, fileName);
        }


        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        private void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_内部通讯录_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_内部通讯录_栏目, false);
            }
        }
        #endregion

        protected string GetYinHangZhangHu(object items)
        {
            string s = string.Empty;
            var _items = (IList<EyouSoft.Model.CompanyStructure.CompanyAccountBase>)items;

            if (_items != null && _items.Count > 0)
            {
                s = _items[0].BankName + "-" + _items[0].AccountName + "-" + _items[0].BankNo;
            }

            return s;
        }
    }
}
