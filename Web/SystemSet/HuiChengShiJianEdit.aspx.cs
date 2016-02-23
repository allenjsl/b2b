//汪奇志 2013-01-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.Model.CompanyStructure;

namespace Web.SystemSet
{
    /// <summary>
    /// 系统设置-基础设置-回程时间
    /// </summary>
    public partial class HuiChengShiJianEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 信息编号
        /// </summary>
        int InfoId = 0;
        /// <summary>
        /// 栏目权限
        /// </summary>
        bool Privs_LanMu = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoId =Utils.GetInt( Utils.GetQueryStringValue("xinxiid"));
            InitPrivs();

            if (Utils.GetQueryStringValue("doType") == "save") Save();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_LanMu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_基础设置_回程时间栏目);

            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetInfo(InfoId);
            if (info == null) return;

            txtName.Value = info.Name;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void Save()
        {
            if (!Privs_LanMu) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = GetFormInfo();
            info.Id = InfoId;
            int bllRetCode = 4;
            if (InfoId<1)
            {
                bllRetCode = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        MJiChuXinXiInfo GetFormInfo()
        {
            MJiChuXinXiInfo info = new MJiChuXinXiInfo();

            info.CompanyId = CurrentUserCompanyID;
            info.Id = 0;
            info.IssueTime = DateTime.Now;
            info.Name = Utils.GetFormValue("txtName");
            info.OperatorId = SiteUserInfo.UserId;
            info.Type = EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程时间;
            info.ZxsId = CurrentZxsId;

            return info;
        }
        #endregion
    }
}
