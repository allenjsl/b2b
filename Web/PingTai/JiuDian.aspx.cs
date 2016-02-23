using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.PingTai
{
    /// <summary>
    /// 酒店管理
    /// </summary>
    public partial class JiuDian : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_ShanChu = false;
        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "shanchu") ShanChu();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_酒店管理_删除);

            phInsert.Visible = Privs_TianJia;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiuDianChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiuDianChaXunInfo();

            info.ChengShiId = Utils.GetIntNull(Utils.GetQueryStringValue("txtChengShi"));
            info.FangXingMingCheg = Utils.GetQueryStringValue("txtFangXingMingCheng");
            info.JiuDianMingCheng = Utils.GetQueryStringValue("txtJiuDianMingCheng");
            info.ShengFenId = Utils.GetIntNull(Utils.GetQueryStringValue("txtShengFen"));
            info.XingJi = (EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi), Utils.GetQueryStringValue("txtXingJi"));

            if (SiteUserInfo.LeiXing == EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.平台酒店用户)
            {
                info.JiuDianYongHuId = SiteUserInfo.UserId;
            }

            return info;
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpt()
        {
            pageIndex = UtilsCommons.GetPagingIndex();

            var chaXun = GetChaXunInfo();
            int recordCount = 0;
            var items = new EyouSoft.BLL.PtStructure.BJiuDian().GetJiuDians(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
            }
        }

        /// <summary>
        /// shan chu
        /// </summary>
        void ShanChu()
        {
            if (!Privs_ShanChu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string jiuDianId = Utils.GetFormValue("txtJiuDianId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiuDian().Delete(CurrentUserCompanyID, jiuDianId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            if (bllRetCode == -99) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：请先删除酒店房型信息"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <returns></returns>
        protected string GetOperatorHtml()
        {
            string s = string.Empty;

            if (Privs_XiuGai) s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\">修改</a> ";
            else s += "<a href=\"javascript:void(0)\" class=\"i_xiugai\" data-chakan=\"1\">查看</a> ";

            if (Privs_ShanChu) s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a> ";

            return s.ToString();
        }

        /// <summary>
        /// get fangxing
        /// </summary>
        /// <returns></returns>
        protected string GetFangXing(object items)
        {
            var _items = (IList<EyouSoft.Model.PtStructure.MJiuDianFangXingInfo>)items;
            StringBuilder s = new StringBuilder();

            if (_items == null || _items.Count == 0)
            {
                s.AppendFormat("<a href=\"javascript:void(0)\" class=\"i_fangxing\">暂无房型</a>");
            }
            else
            {
                s.AppendFormat("<a href=\"javascript:void(0)\" class=\"i_fangxing\">{0}</a>", _items[0].MingCheng);
            }
            
            s.Append("<span style=\"display:none;\">");
            s.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0' class='pp-tableclass'>");
            s.Append("<tr class='pp-table-title'><th width='40'>序号</th><th>房型名称</th><th width='80'>数量</th><th width='80'>面积</th><th width='80'>所在楼层</th><th width='80'>挂牌价格</th><th width='160'>入住日期</th><th width='80'>优惠价格</th></tr>");

            if (_items == null || _items.Count == 0)
            {
                s.Append("<tr><td colspan='8'>暂无房型信息</td></tr>");
            }
            else
            {
                int i = 1;
                foreach (var item in _items)
                {
                    s.Append("<tr class=''>");
                    s.AppendFormat("<td>{0}</td>", i);
                    s.AppendFormat("<td>{0}</td>", item.MingCheng);
                    s.AppendFormat("<td>{0}</td>", item.ShuLiang);
                    s.AppendFormat("<td>{0}</td>", item.MianJi);
                    s.AppendFormat("<td>{0}</td>", item.LouCeng);
                    s.AppendFormat("<td>{0}</td>", item.GuaPaiJiaGe.ToString("F2"));
                    s.AppendFormat("<td>{0}至{1}</td>", item.RuZhuRiQi1.ToString("yyyy-MM-dd"), item.RuZhuRiQi2.ToString("yyyy-MM-dd"));
                    s.AppendFormat("<td>{0}</td>", item.YouHuiJiaGe.ToString("F2"));
                    s.Append("</tr>");
                    i++;
                }
            }

            s.Append("</table>");
            s.Append("</span>");

            return s.ToString();
        }
        #endregion
    }
}