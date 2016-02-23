using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.TourStructure;

namespace EyouSoft.Common
{
    public class UtilsCommons
    {
        #region 格式转换 create by dyz

        /// <summary>
        /// 金额显示格式处理
        /// </summary>
        /// <param name="m">金额</param>
        /// <param name="name">预定义的 System.Globalization.CultureInfo 名称或现有 System.Globalization.CultureInfo名称</param>
        /// <returns></returns>
        public static string GetMoneyString(decimal m, string name)
        {
            System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(name);

            return m.ToString("c2", cultureInfo);
        }

        /// <summary>
        /// 金额显示格式处理
        /// </summary>
        /// <param name="o">金额</param>
        /// <param name="name">预定义的 System.Globalization.CultureInfo 名称或现有 System.Globalization.CultureInfo名称</param>
        /// <returns></returns>
        public static string GetMoneyString(object o, string name)
        {
            if (o != null)
            {
                return GetMoneyString(Utils.GetDecimal(o.ToString()), name);
            }

            return string.Empty;
        }

        /// <summary>
        /// 时间显示格式处理
        /// </summary>
        /// <param name="d">时间值</param>
        /// <param name="format">格式字符串。</param>
        /// <returns></returns>
        public static string GetDateString(DateTime d, string format)
        {
            if (d == null || d.ToString() == "" || d.Equals(Utils.GetDateTime("1900-1-1 0:00:00")) || d.Equals(Utils.GetDateTime("0001-01-01 0:00:00")))
            {
                return "";
            }
            else
            {
                return d.ToString(format);
            }
        }

        /// <summary>
        /// 时间显示格式处理
        /// </summary>
        /// <param name="d">时间值</param>
        /// <param name="format">格式字符串。</param>
        /// <returns></returns>
        public static string GetDateString(object d, string format)
        {
            if (d != null)
            {
                return GetDateString(Utils.GetDateTime(d.ToString()), format);
            }

            return string.Empty;
        }

        #endregion

        #region ajax request,response josn data.  create by cyn
        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode)
        {
            return AjaxReturnJson(retCode, string.Empty);
        }
        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <param name="retMsg">return msg</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode, string retMsg)
        {
            return AjaxReturnJson(retCode, retMsg, null);
        }

        /// <summary>
        /// ajax request,response josn data
        /// </summary>
        /// <param name="retCode">return code</param>
        /// <param name="retMsg">return msg</param>
        /// <param name="retObj">return object</param>
        /// <returns></returns>
        public static string AjaxReturnJson(string retCode, string retMsg, object retObj)
        {
            string output = "{}";

            if (retObj != null)
            {
                output = Newtonsoft.Json.JsonConvert.SerializeObject(retObj);
            }

            return string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\",\"obj\":{2}}}", retCode, retMsg, output);
        }
        #endregion

        /// <summary>
        /// 获取分页页索引，url页索引查询参数为Page
        /// </summary>
        /// <returns></returns>
        public static int GetPagingIndex()
        {
            return GetPagingIndex("Page");
        }

        /// <summary>
        /// 获取分页页索引
        /// </summary>
        /// <param name="s">url页索引查询参数</param>
        /// <returns></returns>
        public static int GetPagingIndex(string s)
        {
            int index = Utils.GetInt(Utils.GetQueryStringValue(s), 1);

            return index < 1 ? 1 : index;
        }

        /// <summary>
        /// 分页参数处理
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        public static void Paging(int pageSize, ref int pageIndex, int recordCount)
        {
            if (pageSize < 1) pageSize = 1;
            int pageCount = recordCount / pageSize;
            if (recordCount % pageSize > 0) pageCount++;
            if (pageIndex > pageCount) pageIndex = pageCount;
            if (pageIndex < 1) pageIndex = 1;
        }
        /// <summary>
        /// 银行账户信息
        /// </summary>
        /// <returns></returns>
        public static IList<UserBank> GetBankAccountData()
        {
            //账户名称
            string[] AccountName = Utils.GetFormValues("txtAccountName");
            //开户行
            string[] BankName = Utils.GetFormValues("txtBankName");
            //银行帐号
            string[] Account = Utils.GetFormValues("txtAccount");
            if (AccountName.Length > 0)
            {
                IList<UserBank> list = new List<UserBank>();
                for (int i = 0; i < AccountName.Length; i++)
                {
                    UserBank model = new UserBank();
                    if (AccountName[i].Trim() == "" && BankName[i].Trim() == "" && Account[i].Trim() == "")
                    {
                        return null;
                    }
                    else
                    {
                        model.AccountName = AccountName[i].ToString();
                        model.BankName = BankName[i].ToString();
                        model.BankNo = Account[i].ToString();
                        list.Add(model);
                    }
                }
                return list;
            }
            else
            {
                return null;
            }
        }


        public static IList<SupplierBank> GetBankSupper(string supperId)
        {
            //账户名称
            string[] AccountName = Utils.GetFormValues("txtAccountName");
            //开户行
            string[] BankName = Utils.GetFormValues("txtBankName");
            //银行帐号
            string[] Account = Utils.GetFormValues("txtAccount");
            if (AccountName.Length > 0)
            {
                IList<SupplierBank> list = new List<SupplierBank>();
                for (int i = 0; i < AccountName.Length; i++)
                {
                    SupplierBank model = new SupplierBank();
                    if (AccountName[i].Trim() == "" && BankName[i].Trim() == "" && Account[i].Trim() == "")
                    {

                    }
                    else
                    {
                        model.AccountName = AccountName[i].ToString();
                        model.BankName = BankName[i].ToString();
                        model.BankNo = Account[i].ToString();
                        model.SupplierId = supperId;
                        list.Add(model);
                    }
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取客人要求及安排
        /// </summary>
        /// <returns></returns>
        public static IList<MTourOrderHotelPlan> GetTourOrderHotelPlanList()
        {
            //入住时间
            string[] InroomTime = Utils.GetFormValues("txtInroomTime_require");
            //要求编号
            string[] Id = Utils.GetFormValues("hidId_require");
            //离开时间
            string[] backroomTime = Utils.GetFormValues("txtbackroomTime_require");
            //房型
            string[] roomtype = Utils.GetFormValues("txtroomtype_require");
            //要求备注
            string[] reqremark = Utils.GetFormValues("txtreqremark_require");
            //夜间
            string[] Night = Utils.GetFormValues("txtNight_require");
            //取房方式
            string[] qufang = Utils.GetFormValues("txtqufang_require");
            //酒店名称
            string[] HotelName = Utils.GetFormValues("txtHotelName_require");
            //供应商名称
            string[] SourceName = Utils.GetFormValues("SourceName_require");
            //供应商编号
            string[] ShowID = Utils.GetFormValues("ShowID_require");
            //对方操作人
            string[] dfoperater = Utils.GetFormValues("sltdfoperater");
            //结算明细
            string[] MoneyDesc = Utils.GetFormValues("txtMoneyDesc_require");
            //结算金额
            string[] Money = Utils.GetFormValues("txtMoney_require");
            //安排备注
            string[] remark = Utils.GetFormValues("txtremark_require");
            //具体安排
            string[] Desc = Utils.GetFormValues("txtDesc_require");
            //附件
            string[] files = Utils.GetFormValues("hide_Route_file_require");
            //酒店安排明细信息
            string[] planHotelMxs = System.Web.HttpContext.Current.Request.Form.GetValues("txtAnPaiMx");
            string[] txtIsRpt = Utils.GetFormValues("txtIsRpt");
            
            IList<MTourOrderHotelPlan> list = new List<MTourOrderHotelPlan>();
            if (InroomTime.Length > 0)
            {
                for (int i = 0; i < InroomTime.Length; i++)
                {
                    if (string.IsNullOrEmpty(ShowID[i])) continue;

                    var model = new MTourOrderHotelPlan();
                    model.CheckInDate = Utils.GetDateTimeNullable(InroomTime[i].ToString());
                    model.CheckOutDate = Utils.GetDateTimeNullable(backroomTime[i].ToString());
                    model.FileInfo = files[i].ToString();
                    model.GYSId = ShowID[i].ToString();
                    model.HotelName = HotelName[i].ToString();
                    model.HumorWas = qufang[i].ToString();
                    model.PlanDetail = Desc[i].ToString();
                    model.PlanRemark = remark[i].ToString();
                    model.Remark = reqremark[i].ToString();
                    model.Room = roomtype[i].ToString();
                    model.RoomNights = Night[i].ToString();
                    model.SettleAmount = Utils.GetDecimal(Money[i].ToString());
                    model.SettleDetail = MoneyDesc[i].ToString();
                    model.SideOperatorId = Utils.GetInt(dfoperater[i].ToString());
                    model.GYSName = SourceName[i].ToString();
                    model.Id = Id[i].ToString();

                    model.AnPaiMxs = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>>(planHotelMxs[i]);
                    var hotelMxInfo = new EyouSoft.Model.TourStructure.MPlanHotelMxInfo();
                    hotelMxInfo.FangXing = model.Room;
                    hotelMxInfo.JianYe = model.RoomNights;
                    hotelMxInfo.JiuDianName = model.HotelName;
                    hotelMxInfo.QuFangFangShi = model.HumorWas;
                    if (model.CheckInDate.HasValue) hotelMxInfo.RuZhuTime = model.CheckInDate.Value.ToString("yyyy-MM-dd");
                    if (model.CheckOutDate.HasValue) hotelMxInfo.TuiFangTime = model.CheckOutDate.Value.ToString("yyyy-MM-dd");
                    hotelMxInfo.YaoQiuBeiZhu = model.Remark;

                    if (model.AnPaiMxs == null || model.AnPaiMxs.Count == 0)
                    {
                        model.AnPaiMxs = new List<EyouSoft.Model.TourStructure.MPlanHotelMxInfo>();
                    }

                    if (txtIsRpt[i] == "1") model.AnPaiMxs[0] = hotelMxInfo;
                    else model.AnPaiMxs.Insert(0, hotelMxInfo);
                    

                    list.Add(model);
                }
            }

            return list;
        }
        #region  联系人信息

        /// <summary>
        /// 获取联系人信息
        /// </summary>
        public static IList<SupplierContact> GetContactData()
        {
            //联系人编号
            string[] txtLxrId = Utils.GetFormValues("txtLxrId");
            //联系人姓名
            string[] ContactName = Utils.GetFormValues("Name");
            //联系人电话
            string[] TelPhone = Utils.GetFormValues("TelPhone");
            //联系人手机
            string[] Mobel = Utils.GetFormValues("Mobel");
            //联系人QQ
            string[] QQ = Utils.GetFormValues("QQ");
            //联系人Email
            string[] Email = Utils.GetFormValues("Email");
            //联系人职务
            string[] Post = Utils.GetFormValues("Post");
            //传真
            string[] Fax = Utils.GetFormValues("Fax");

            int length = txtLxrId.Length;
            if (length == 0 || ContactName.Length != length || TelPhone.Length != length || TelPhone.Length != length
                || Mobel.Length != length || QQ.Length != length || Email.Length != length || Post.Length != length || Fax.Length != length) return null;

            IList<SupplierContact> list = new List<SupplierContact>();

            for (int i = 0; i < ContactName.Length; i++)
            {
                if (!string.IsNullOrEmpty(ContactName[i].ToString()))
                {
                    if (string.IsNullOrEmpty(ContactName[i].Trim())) continue;

                    EyouSoft.Model.CompanyStructure.SupplierContact model = new EyouSoft.Model.CompanyStructure.SupplierContact();
                    model.ContactName = ContactName[i];
                    model.Email = Email[i];
                    model.ContactTel = TelPhone[i];
                    model.Qq = QQ[i];
                    model.JobTitle = Post[i];
                    model.ContactMobile = Mobel[i];
                    model.ContactFax = Fax[i];
                    model.Id = Utils.GetInt(txtLxrId[i]);
                    list.Add(model);
                }
            }

            return list;
        }
        #endregion

        public static bool IsToXls()
        {
            return Utils.GetQueryStringValue("toxls") == "1";
        }
        public static int GetToXlsRecordCount()
        {
            return Utils.GetInt(Utils.GetQueryStringValue("toxlsrecordcount"));
        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选择value值</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal)
        {
            return GetEnumDDL(ls, selectedVal ?? "-1", false);

        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选择value值</param>
        /// <param name="isFirst">是否存在默认请选择项</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, bool isFirst)
        {

            return GetEnumDDL(ls, selectedVal, isFirst, "-1", "-请选择-");
        }
        /// <summary>
        /// 获取枚举下拉菜单
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选中的值</param>
        /// <param name="defaultValue">默认值Id</param>
        /// <param name="defaultText">默认值文本</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, string defaultValue, string defaultText)
        {
            return GetEnumDDL(ls, selectedVal, true, defaultValue, defaultText);
        }
        /// <summary>
        /// 获取枚举下拉菜单(该方法isFirst为否则后2个属性无效)
        /// </summary>
        /// <param name="ls">枚举列</param>
        /// <param name="selectedVal">选中的值</param>
        /// <param name="isFirst">是否有默认值</param>
        /// <param name="defaultValue">默认值Id</param>
        /// <param name="defaultText">默认值文本</param>
        /// <returns></returns>
        public static string GetEnumDDL(List<EnumObj> ls, string selectedVal, bool isFirst, string defaultValue, string defaultText)
        {
            if (string.IsNullOrEmpty(selectedVal)) selectedVal = string.Empty;
            if (string.IsNullOrEmpty(defaultValue)) defaultValue = string.Empty;
            if (string.IsNullOrEmpty(defaultText)) defaultText = string.Empty;

            StringBuilder sb = new StringBuilder();
            if (isFirst)
            {
                sb.Append("<option value=\"" + defaultValue + "\" selected=\"selected\">" + defaultText + "</option>");
            }

            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Value != selectedVal.Trim())
                {
                    sb.Append("<option value=\"" + ls[i].Value.Trim() + "\">" + ls[i].Text.Trim() + "</option>");
                }
                else
                {
                    sb.Append("<option value=\"" + ls[i].Value.Trim() + "\" selected=\"selected\">" + ls[i].Text.Trim() + "</option>");
                }
            }
            return sb.ToString();
        }
    }
}
