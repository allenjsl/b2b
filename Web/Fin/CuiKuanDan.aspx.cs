using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.Fin
{
    public partial class CuiKuanDan : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 催款单栏目权限
        /// </summary>
        bool Privs_CuiKuanDan = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPrivs();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_CuiKuanDan = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_催款单_栏目);
            if (!Privs_CuiKuanDan) RCWE("没有权限");
        }
        #endregion
    }
}
