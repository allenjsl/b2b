using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.EnumType.PrivsStructure;
using EyouSoft.Security.Membership;
using EyouSoft.Common;

namespace Web.MasterPage
{
    public partial class Front : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// 页面标题
        /// </summary>
        public string ITitle = string.Empty;
        /// <summary>
        /// 当前登录用户姓名
        /// </summary>
        protected string UserXingMing = string.Empty;
        /// <summary>
        /// 专线商名称
        /// </summary>
        protected string ZxsName = string.Empty;
        /// <summary>
        /// 专线商Logo
        /// </summary>
        protected string ZxsLogoFilepath = "/images/pngclear.gif";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SysStructure.SystemDomain sysDomain = EyouSoft.Security.Membership.UserProvider.GetDomain();

            if (sysDomain == null || sysDomain.CompanyId < 1 || sysDomain.SysId < 1)
            {
                Response.Clear();
                Response.Write("请求异常：错误的域名配置。");
                Response.End();
            }

            var uinfo = EyouSoft.Security.Membership.UserProvider.GetUserInfo();

            if (uinfo != null)
            {
                UserXingMing = uinfo.Name;
                ImgNewNotice.Visible = new EyouSoft.BLL.CompanyStructure.News().IsNews(uinfo.CompanyId, uinfo.DeptId, uinfo.UserId,uinfo.ZxsId);

                ZxsName = uinfo.ZxsName;

                var zxsPeiZhiInfo = new EyouSoft.BLL.CompanyStructure.CompanySetting().GetZxsPeiZhiInfo(uinfo.CompanyId, uinfo.ZxsId);

                if (zxsPeiZhiInfo != null && !string.IsNullOrEmpty(zxsPeiZhiInfo.LogoFilepath)) ZxsLogoFilepath = zxsPeiZhiInfo.LogoFilepath;
            }

            if (ZxsLogoFilepath == "/images/pngclear.gif")
            {
                var setting = EyouSoft.Security.Membership.UserProvider.GetComSetting(sysDomain.CompanyId);

                if (setting != null && !string.IsNullOrEmpty(setting.SysLogoFilepath)) ZxsLogoFilepath = setting.SysLogoFilepath;
            }

            if (string.IsNullOrEmpty(ITitle)) ITitle = Page.Title;

            InitMenuPrivs(uinfo);
            InitHighlight();
            InitPrivs(uinfo);
        }

        #region private members
        /// <summary>
        /// init left menu
        /// </summary>
        /// <param name="info">user info</param>
        void InitMenuPrivs(EyouSoft.Model.SSOStructure.MUserInfo info)
        {
            if (info == null)
            {
                div_1.Visible = div_2.Visible = div_3.Visible = div_4.Visible = div_5.Visible = div_6.Visible = div_7.Visible = div_8.Visible = div_9.Visible = false;
                return;
            }

            bool b1 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.线路产品_线路管理_栏目);
            bool b2 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.线路产品_政策中心_栏目);
            div_1.Visible = b1 || b2;
            li_1.Visible = b1;
            li_2.Visible = b2;

            bool b3 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.收客计划_常规业务_栏目);
            bool b4 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.收客计划_代订酒店_栏目);
            bool b80 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.收客计划_最新报价_栏目);
            div_2.Visible = b3 || b4 || b80;
            li_3.Visible = b3;
            li_4.Visible = b4;
            li_80.Visible = b80;

            bool b5 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_票务_栏目);
            bool b6 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_地接社_栏目);
            bool b7 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_酒店_栏目);
            bool b8 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_景点_栏目);
            bool b9 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_其它_栏目);
            bool b83 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_地接社账号管理_栏目);
            b83 = false;
            bool b84 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.资源管理_地接社主体管理_栏目);
            div_3.Visible = b5 || b6 || b7 || b8 || b9 || b83 || b84;
            li_5.Visible = b5;
            li_6.Visible = b6;
            li_7.Visible = b7;
            li_8.Visible = b8;
            li_9.Visible = b9;
            li_83.Visible = b83;
            li_84.Visible = b84;

            bool b10 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.客户管理_客户管理_栏目);
            bool b65 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.客户管理_注册客户管理_栏目);
            bool b78=UserProvider.IsPrivs3(info.Privs, (int)Privs3.客户管理_客户账号管理_栏目);
            div_4.Visible = b10 || b65 || b78;
            li_10.Visible = b10;
            li_65.Visible = b65;
            li_78.Visible = b78;

            bool b11 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_订单中心_栏目);
            bool b12 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_销售收款_栏目);
            bool b13 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_应付地接费_栏目);
            bool b14 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_应付交通费_栏目);
            bool b15 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_押金登记表_栏目);
            bool b16 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_退票登记表_栏目);
            bool b17 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_预订酒店应付费_栏目);
            bool b18 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_借款登记表_栏目);
            bool b19 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_报销登记表_栏目);
            bool b20 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_银行账号表_栏目);
            bool b21 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_其他收入表_栏目);
            bool b22 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_其他支出表_栏目);
            bool b23 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_付款审批_栏目);
            bool b24 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_银行余额表_栏目);
            bool b25 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_银行明细表_栏目);
            bool b26 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_银行核对表_栏目);
            bool b27 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_出纳日记账_栏目);
            bool b28 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_发票管理_栏目);
            bool b29 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_请假管理_栏目);
            bool b54 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_出纳登账_栏目);
            bool b55 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_结算汇总表_栏目);
            bool b56 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_利润表_栏目);
            bool b57 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_资产负债表_栏目);
            bool b58 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_工资管理_栏目);
            bool b64 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.财务管理_催款单_栏目);

            div_5.Visible = b11 || b12 || b13 || b14 || b15 || b16 || b17 || b18 || b19 || b20 || b21 || b22 || b23 || b24 || b25 || b26 || b27 || b28 || b29 || b54 || b55 || b56 || b57 || b58 || b64;
            li_11.Visible = b11;
            li_12.Visible = b12;
            li_13.Visible = b13;
            li_14.Visible = b14;
            li_15.Visible = b15;
            li_16.Visible = b16;
            li_17.Visible = b17;
            li_18.Visible = b18;
            li_19.Visible = b19;
            li_20.Visible = b20;
            li_21.Visible = b21;
            li_22.Visible = b22;
            li_23.Visible = b23;
            li_24.Visible = b24;
            li_25.Visible = b25;
            li_26.Visible = b26;
            li_27.Visible = b27;
            li_28.Visible = b28;
            li_29.Visible = b29;
            li_54.Visible = b54;
            li_55.Visible = b55;
            li_56.Visible = b56;
            li_57.Visible = b57;
            li_58.Visible = b58;
            li_64.Visible = b64;

            bool b30 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_职务管理_栏目);
            bool b31 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_人事档案_栏目);
            bool b32 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_考勤管理_栏目);
            bool b33 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_内部通讯录_栏目);
            bool b34 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_规章制度_栏目);
            bool b35 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_会议记录_栏目);
            bool b36 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_劳动合同管理_栏目);
            bool b37 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_固定资产管理_栏目);
            bool b38 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.行政中心_培训计划_栏目);
            div_6.Visible = b30 || b31 || b32 || b33 || b34 || b35 || b36 || b37 || b38;
            li_30.Visible = b30;
            li_31.Visible = b31;
            li_32.Visible = b32;
            li_33.Visible = b33;
            li_34.Visible = b34;
            li_35.Visible = b35;
            li_36.Visible = b36;
            li_37.Visible = b37;
            li_38.Visible = b38;

            bool b39 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_基础设置_栏目);
            bool b40 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_组织机构_栏目);
            bool b41 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_角色管理_栏目);
            bool b42 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_公司信息_栏目);
            bool b43 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_信息管理_栏目);
            bool b44 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_系统配置_栏目);
            bool b45 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.系统设置_系统日志_栏目);
            div_7.Visible = b39 || b40 || b41 || b42 || b43 || b44 || b45;
            li_39.Visible = b39;
            li_40.Visible = b40;
            li_41.Visible = b41;
            li_42.Visible = b42;
            li_43.Visible = b43;
            li_44.Visible = b44;
            li_45.Visible = b45;

            bool b46 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_事务提醒_栏目);
            bool b47 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_公告通知_栏目);
            bool b48 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_文档管理_栏目);
            bool b49 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_工作交流_栏目);
            bool b50 = true;// UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_个人信息_栏目);
            bool b51 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_个人备忘_栏目);
            bool b52 = true;// UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_请假申请_栏目);
            bool b53 = true;// UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_个人借款表_栏目);

            if (info.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户 || info.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台景点用户)
            {
                b50 = b52 = b53 = false;
            }

            div_8.Visible = b46 || b47 || b48 || b49 || b50 || b51 || b52 || b53;
            li_46.Visible = b46;
            li_47.Visible = b47;
            li_48.Visible = b48;
            li_49.Visible = b49;
            li_50.Visible = b50;
            li_51.Visible = b51;
            li_52.Visible = b52;
            li_53.Visible = b53;

            bool b59 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_旅行社人头统计_栏目);
            bool b60 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_我方操作人统计_栏目);
            bool b74 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_积分发放明细表_栏目);
            bool b75 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_积分发放结算统计表_栏目);
            bool b76 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_积分收付款明细表_栏目);
            bool b81 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_利润估算表一_栏目);
            bool b82=UserProvider.IsPrivs3(info.Privs, (int)Privs3.统计分析_客户用户积分统计表_栏目);

            div_9.Visible = b59 || b60 || b74 || b75 || b76 || b81 || b82;
            li_59.Visible = b59;
            li_60.Visible = b60;
            li_74.Visible = b74;
            li_75.Visible = b75;
            li_76.Visible = b76;
            li_81.Visible = b81;
            li_82.Visible = b82;

            bool b61 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_站点管理_栏目);
            bool b62 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_专线类别管理_栏目);
            bool b63 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_专线商管理_栏目);
            bool b66 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_旅游资讯_栏目);
            bool b67 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_酒店管理_栏目);
            bool b68 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_景点管理_栏目);
            bool b69 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_广告管理_栏目);
            bool b70 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_平台推荐_栏目);
            bool b71 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_积分兑换商品管理_栏目);
            bool b72 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_积分兑换订单管理_栏目);
            bool b73 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_基础信息_栏目);
            bool b77 = UserProvider.IsPrivs3(info.Privs, (int)Privs3.同行端口_促销信息_栏目);

            div_10.Visible = b61 || b62 || b63 || b66 || b67 || b68 || b69 || b70 || b71 || b72 || b73||b77;
            li_61.Visible = b61;
            li_62.Visible = b62;
            li_63.Visible = b63;
            li_66.Visible = b66;
            li_67.Visible = b67;
            li_68.Visible = b68;
            li_69.Visible = b69;
            li_70.Visible = b70;
            li_71.Visible = b71;
            li_72.Visible = b72;
            li_73.Visible = b73;
            li_77.Visible = b77;

            if (info.ZxsT1 == EyouSoft.Model.EnumType.PtStructure.ZxsT1.其它专线商) li_79.Visible = false;
        }

        /// <summary>
        /// init hightlight
        /// </summary>
        void InitHighlight()
        {
            string s = Request.Url.AbsolutePath.ToLower();
            string showStyle = "display:'';";
            string highlightClass = "listIn";
            string h2ShowClass = "firstNav";

            if (s.Equals("/LineProduct/LineList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_1.Attributes["class"] = h2ShowClass;
                ul_1.Attributes["style"] = showStyle;
                a_1.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/LineProduct/LineAdd.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_1.Attributes["class"] = h2ShowClass;
                ul_1.Attributes["style"] = showStyle;
                a_1.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/LineProduct/PolicyList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_1.Attributes["class"] = h2ShowClass;
                ul_1.Attributes["style"] = showStyle;
                a_2.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TeamPlan/PlanList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_2.Attributes["class"] = h2ShowClass;
                ul_2.Attributes["style"] = showStyle;
                a_3.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TeamPlan/TeamAccounts.aspx", StringComparison.OrdinalIgnoreCase) && Utils.GetQueryStringValue("type") == "tour")
            {
                h2_2.Attributes["class"] = h2ShowClass;
                ul_2.Attributes["style"] = showStyle;
                a_3.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TeamPlan/ScheduleHotelList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_2.Attributes["class"] = h2ShowClass;
                ul_2.Attributes["style"] = showStyle;
                a_4.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TeamPlan/TeamAccounts.aspx", StringComparison.OrdinalIgnoreCase) && Utils.GetQueryStringValue("type") == "hotel")
            {
                h2_2.Attributes["class"] = h2ShowClass;
                ul_2.Attributes["style"] = showStyle;
                a_4.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ResourceManage/TicketList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_5.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ResourceManage/GroundList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_6.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ResourceManage/HotelList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_7.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ResourceManage/ScenicList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_8.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ResourceManage/OtherList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_9.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/CustomerManage/CustomerList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_4.Attributes["class"] = h2ShowClass;
                ul_4.Attributes["style"] = showStyle;
                a_10.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/dingdanzhongxin.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_11.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/xiaoshoushoukuan.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_12.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yingfudijie.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_13.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yingfujiaotong.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_14.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yajin.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_15.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/tuipiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_16.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yingfujiudian.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_17.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/jiekuan.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_18.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/baoxiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_19.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yinhangzhanghu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_20.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/qitashouru.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_21.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/qitazhichu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_22.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/fukuanshenpi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_23.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yinhangyue.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_24.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yinhangmingxi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_25.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/yinhanghedui.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_26.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/DengZhang.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_54.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/rijizhang.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_27.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/fapiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_28.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/qingjia.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_29.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/JobManage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_30.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/AdminFileList.aspx", StringComparison.OrdinalIgnoreCase) || s.Equals("/ManageCenter/AdminAdd.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_31.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/WorkCheckList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_32.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/MailList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_33.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/CompanyRule.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_34.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/ConManage.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_35.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/ContractList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_36.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/AssetsList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_37.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/ManageCenter/TrainPlanList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_6.Attributes["class"] = h2ShowClass;
                ul_6.Attributes["style"] = showStyle;
                a_38.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/CityManage.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/SystemSet/LineManage.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/SystemSet/TrafficManage.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/systemset/quchengshijian.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/systemset/huichengshijian.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/systemset/jichuxinxi.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/systemset/changyongchengshi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_39.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/DepartManage.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/SystemSet/UserList.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/SystemSet/pingtaijiudianyonghu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_40.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/RoleList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_41.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/CompanyInfo.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_42.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/MsgManageList.aspx", StringComparison.OrdinalIgnoreCase) || s.Equals("/SystemSet/MsgAdd.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_43.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/PeiZhi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_44.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/LoginLog.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_45.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/SystemSet/OperationLog.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_7.Attributes["class"] = h2ShowClass;
                ul_7.Attributes["style"] = showStyle;
                a_45.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/ReceivablesRemind.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_46.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/PayReminder.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_46.Attributes["class"] = highlightClass;
            }

            else if (s.Equals("/UserCenter/NoticeList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_47.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/NoticeDetail.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_47.Attributes["class"] = highlightClass;
            }

            else if (s.Equals("/UserCenter/FileList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_48.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/WorkReport.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/WorkReportAdd.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/WorkPlan.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/WorkPlanAdd.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }

            else if (s.Equals("/UserCenter/WorkCommun.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/WorkCommunAdd.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/WorkCommunReply.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_49.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/UserInfo.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_50.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/UserMemo.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_51.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/VacaList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_52.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/UserCenter/LoanList.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_8.Attributes["class"] = h2ShowClass;
                ul_8.Attributes["style"] = showStyle;
                a_53.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/jiesuanhuizongbiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_55.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/lirunbiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_56.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/zichanfuzhaibiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_57.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/GongZi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_58.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/LxsRenTou.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_59.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/CaoZuoRen.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_60.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/LxsRenTouXX.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_59.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/zhandian.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_61.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/zhuanxianleibie.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_62.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/zhuanxianshang.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_63.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/fin/cuikuandan.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_5.Attributes["class"] = h2ShowClass;
                ul_5.Attributes["style"] = showStyle;
                a_64.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/CustomerManage/ZhuCeKeHu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_4.Attributes["class"] = h2ShowClass;
                ul_4.Attributes["style"] = showStyle;
                a_65.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/zixun.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_66.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/jiudian.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_67.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/jingdian.aspx", StringComparison.OrdinalIgnoreCase) || s.Equals("/pingtai/jingdianquyu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_68.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/guanggao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_69.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/tuijian.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_70.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/jifenshangpin.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_71.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/jifendingdan.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_72.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/wangzhanjichuxinxi.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/pingtai/wangzhanjichuxinxi1.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/pingtai/wangzhanjichuxinxi2.aspx", StringComparison.OrdinalIgnoreCase)
                || s.Equals("/pingtai/wangzhanjichuxinxi3.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_73.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/jifenfafangmingxi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_74.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/jifenjiesuanmingxi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_75.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/jifenshoufukuanmingxi.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_76.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/pingtai/cuxiao.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_10.Attributes["class"] = h2ShowClass;
                ul_10.Attributes["style"] = showStyle;
                a_77.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/CustomerManage/KeHuYongHu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_4.Attributes["class"] = h2ShowClass;
                ul_4.Attributes["style"] = showStyle;
                a_78.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/baojia/baojia.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_2.Attributes["class"] = h2ShowClass;
                ul_2.Attributes["style"] = showStyle;
                a_80.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/lirungusuanbiao1.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_81.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/TongJi/kehuyonghujifen.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_9.Attributes["class"] = h2ShowClass;
                ul_9.Attributes["style"] = showStyle;
                a_82.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/resourcemanage/gysyonghu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_83.Attributes["class"] = highlightClass;
            }
            else if (s.Equals("/resourcemanage/dijieshezhuti.aspx", StringComparison.OrdinalIgnoreCase) || s.Equals("/resourcemanage/dijieshezhutiyonghu.aspx", StringComparison.OrdinalIgnoreCase))
            {
                h2_3.Attributes["class"] = h2ShowClass;
                ul_3.Attributes["style"] = showStyle;
                a_84.Attributes["class"] = highlightClass;
            }
            else
            {
                throw new SystemException("请到~\\MasterPage\\Front.Master页InitHighlight()设置高亮显示的位置，3Q。");
            }

        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs(EyouSoft.Model.SSOStructure.MUserInfo info)
        {
            phXiaoXi.Visible = UserProvider.IsPrivs3(info.Privs, (int)Privs3.个人中心_消息提醒_栏目);
        }
        #endregion
    }
}
