//汪奇志 2012-11-23~2012-12-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.Fin
{
    /// <summary>
    /// 财务管理-银行余额表
    /// </summary>
    public partial class YinHangYuE : BackPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行余额表_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_银行余额表_栏目, true);
            }
        }

        /// <summary>
        /// init repeater
        /// </summary>
        void InitRpts()
        {
            DateTime time = GetChaXun();

            decimal heJi;            

            var items = new EyouSoft.BLL.FinStructure.BFin().GetYinHangYuE(CurrentUserCompanyID, time, out heJi, CurrentZxsId); 

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();

                //合计信息
                ltrYuEHeJi.Text = ToMoneyString(heJi);

                rpts.Visible = phHeJi.Visible =  true;
                phEmpty.Visible = phPaging.Visible = false;
            }
            else
            {
                rpts.Visible = phHeJi.Visible = phPaging.Visible = false;
                phEmpty.Visible = true;
            }
        }

        /// <summary>
        /// 获取查询信息
        /// </summary>
        /// <returns></returns>
        public DateTime GetChaXun()
        {
            var _d = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtTime"));
            if (!_d.HasValue)
            {
                _d = DateTime.Now;

                ltrTime.Text = _d.Value.ToString("yyyy-MM-dd HH:ss");
            }
            else
            {
                ltrTime.Text = _d.Value.AddDays(1).ToString("yyyy-MM-dd HH:ss");
            }

            return _d.Value;
        }
        #endregion
    }
}
