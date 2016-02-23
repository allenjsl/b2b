//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using System.Text;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-订单中心
    /// </summary>
    public partial class DingDanZhongXin : BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ITitle = "订单中心-财务管理";

            InitPrivs();
            InitRpts();
            InitQuYu();

        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_订单中心_栏目, true);
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            var chaXun = GetChaXunInfo();
            pageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            object[] heJi;

            var items = new EyouSoft.BLL.FinStructure.BFin().GetOrders(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrRenShuHeJi.Text = heJi[0] + "+" + heJi[1] + "+" + heJi[5] + "+" + heJi[2];
                ltrZhanWeiShuHeJi.Text = heJi[3].ToString();
                ltrJinEHeJi.Text = ToMoneyString(heJi[4]);

                rpts.Visible = phHeJi.Visible = phPaging.Visible = true;
                phEmpty.Visible = false;
                
                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MOrderChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.FinStructure.MOrderChaXunInfo();

            info.KeHuCityId = Utils.GetIntNull(Utils.GetQueryStringValue("txtCity"));
            info.keHuName = Utils.GetQueryStringValue("txtKeHuName");
            info.KeHuProvinceId = Utils.GetIntNull(Utils.GetQueryStringValue("txtProvince"));
            info.LEDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLEDate"));
            info.LSDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtLSDate"));
            info.OperatorName = Utils.GetQueryStringValue("txtOperatorName");
            info.OrderCode = Utils.GetQueryStringValue("txtOrderCode");
            info.Status = (EyouSoft.Model.EnumType.TourStructure.OrderStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.OrderStatus), Utils.GetQueryStringValue("txtStatus"));
            info.YouKeName = Utils.GetQueryStringValue("txtYouKeName");
            info.YeWuLeiXing = (EyouSoft.Model.EnumType.TourStructure.BusinessType?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.BusinessType), Utils.GetQueryStringValue("txtYeWuLeiXing"));
            info.ZxsId = CurrentZxsId;

            info.RouteName = Utils.GetQueryStringValue("txtRouteName");
            info.QuJiaoTongId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuJiaoTong"));
            info.QuYuId = Utils.GetIntNull(Utils.GetQueryStringValue("txtQuYu"));

            info.PaiXuLeiXing = Utils.GetInt(Utils.GetQueryStringValue("paixuleixing"));

            return info;
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetZxsZhanDians(CurrentZxsId);

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<option value=\"\">请选择</option>");
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var item1 in item.Zxlbs)
                    {
                        s.AppendFormat("<optgroup label=\"{0}\">", item.ZhanDianName + "站-" + item1.ZxlbName);

                        foreach (var item2 in item1.QuYus)
                        {
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName);
                        }

                        s.AppendFormat("</optgroup>");
                    }
                }
            }

            ltrQuYuOption.Text = s.ToString();
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="liuWeiDaoQiTime">留位到期时间</param>
        /// <returns></returns>
        protected string GetStatus(object status, object liuWeiDaoQiTime)
        {
            EyouSoft.Model.EnumType.TourStructure.OrderStatus _status = (EyouSoft.Model.EnumType.TourStructure.OrderStatus)status;
            DateTime? _liuWeiDaoQiTime = (DateTime?)liuWeiDaoQiTime;

            if (_status == EyouSoft.Model.EnumType.TourStructure.OrderStatus.已留位) return "已留位<br/>" + (_liuWeiDaoQiTime.HasValue ? _liuWeiDaoQiTime.Value.ToString("MM-dd HH:ss") : "");

            return _status.ToString();
        }

        /// <summary>
        /// 获取列表行样式
        /// </summary>
        /// <param name="biaoShiYanSe">标识颜色</param>
        /// <returns></returns>
        protected string GetHangYangShi(object biaoShiYanSe)
        {
            if (biaoShiYanSe == null || string.IsNullOrEmpty(biaoShiYanSe.ToString())) return string.Empty;

            return ";color:" + biaoShiYanSe + ";";
        }

        /// <summary>
        /// 获取去程交通下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetQuJiaoTongOptions()
        {
            int _quJiaoTongId = Utils.GetInt(Utils.GetQueryStringValue("txtQuJiaoTong"));
            StringBuilder s = new StringBuilder();

            var items = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic().GetList(CurrentUserCompanyID);

            s.Append("<option value=\"\">-请选择-</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.TrafficId, item.TrafficId == _quJiaoTongId ? "selected=\"selected\"" : "", item.TrafficName);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// get fapiao xinxi
        /// </summary>
        /// <param name="faPiaoMxId"></param>
        /// <param name="faPiaoJinE"></param>
        /// <returns></returns>
        protected string GetFaPiaoXinXi(object faPiaoMxId, object faPiaoJinE)
        {
            int _faPiaoMxId = (int)faPiaoMxId;
            decimal _faPiaoJinE = (decimal)faPiaoJinE;

            if (_faPiaoMxId == 0)
            {
                return "是否开票：否";
            }
            else
            {
                return "是否开票：是&nbsp;&nbsp;开票金额：" + _faPiaoJinE.ToString("F2");
            }
        }
        #endregion
    }
}
