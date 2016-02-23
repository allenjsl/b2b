//客户用户积分统计表 汪奇志 2014-11-18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace Web.TongJi
{
    /// <summary>
    /// 客户用户积分统计表
    /// </summary>
    public partial class KeHuYongHuJiFen : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        protected int pageSize = 20;
        protected int pageIndex = 1;

        protected string KeHuLxrId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();

            InitRpt();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_客户用户积分统计表_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenChaXunInfo();

            info.KeHuId = txtKeHu.KeHuId = Utils.GetQueryStringValue(txtKeHu.KeHuIdClientName);
            txtKeHu.KeHuMingCheng = Utils.GetQueryStringValue(txtKeHu.KeHuMingChengClientName);
            KeHuLxrId = Utils.GetQueryStringValue("txtKeHuLxrId");
            info.KeHuLxrId = Utils.GetIntNull(KeHuLxrId);

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
            object[] heJi;
            var items = new EyouSoft.BLL.TongJiStructure.BJiFen().GetKeHuYongHuJiFens(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                ltrKeYongJiFenHeJi.Text = heJi[0].ToString();
                ltrDongJieJiFenHeJi.Text = heJi[1].ToString();
                ltrYiShiYongJiFenHeJi.Text = heJi[2].ToString();

                phEmpty.Visible = false;

                paging.intPageSize = pageSize;
                paging.CurrencyPage = pageIndex;
                paging.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
                phPaging.Visible = false;
                phHeJi.Visible = false;
            }
        }
        #endregion
    }
}
