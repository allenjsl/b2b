using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.LineProduct
{
    /// <summary>
    /// 线路政策列表
    /// </summary>
    public partial class PolicyList : EyouSoft.Common.Page.BackPage
    {
        private const int PageSize = 10;

        private int _pageIndex = 1;

        private int _recordCount;

        protected bool IsEdit;

        protected bool IsDel;

        protected void Page_Load(object sender, EventArgs e)
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_栏目, true);
                return;
            }

            if (!IsPostBack)
            {
                string doType = Utils.GetQueryStringValue("doType");
                string pid = Utils.GetQueryStringValue("pid");

                if (!string.IsNullOrEmpty(doType) && doType.ToLower() == "del" && !string.IsNullOrEmpty(pid))
                {
                    DeletePolicy(pid);
                    return;
                }

                CheckPrive();
                InitPage();
            }
        }

        /// <summary>
        /// 根据权限控制按钮显示
        /// </summary>
        private void CheckPrive()
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_新增))
            {
                plnAdd.Visible = false;
            }
            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_修改))
            {
                IsEdit = true;
            }
            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_删除))
            {
                IsDel = true;
            }
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            var chaXun = new EyouSoft.Model.TourStructure.MSeachRouteZhengCe();
            chaXun.BeginDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("sd"));
            chaXun.EndDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("ed"));
            chaXun.Title = Utils.GetQueryStringValue("t");
            chaXun.Status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus), Utils.GetQueryStringValue("txtStatus"));
            chaXun.ZxsId = CurrentZxsId;

            var list = new EyouSoft.BLL.TourStructure.BRoute().GetRouteZhengCeList(
                CurrentUserCompanyID,
                PageSize,
                _pageIndex,
                ref _recordCount,
                chaXun);

            UtilsCommons.Paging(PageSize, ref _pageIndex, _recordCount);
            rptPolicy.DataSource = list;
            rptPolicy.DataBind();
            
            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;
            page1.CurrencyPage = _pageIndex;
        }

        /// <summary>
        /// 获取行序号
        /// </summary>
        /// <param name="index">行索引</param>
        /// <returns></returns>
        protected int GetIndex(int index)
        {
            return PageSize * (_pageIndex - 1) + index + 1;
        }

        /// <summary>
        /// 生成附件下载链接
        /// </summary>
        /// <param name="path">附件路径</param>
        /// <returns></returns>
        protected string GetFilePath(object path)
        {
            if (path == null) return string.Empty;
            if (string.IsNullOrEmpty(path.ToString())) return string.Empty;
            return
                string.Format(
                    "<a target=\"_blank\" href=\"{0}\"><img width=\"15\" height=\"14\" alt=\"点击下载\" src=\"/images/fujian_bg.gif\"></a>",
                    path.ToString());
        }

        /// <summary>
        /// 删除线路
        /// </summary>
        /// <param name="pid">线路编号</param>
        private void DeletePolicy(string pid)
        {
            string str;
            if (string.IsNullOrEmpty(pid))
            {
                str = UtilsCommons.AjaxReturnJson("0", "参数丢失，请刷新页面后重试！");
                this.RCWE(str);
                return;
            }

            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_政策中心_删除))
            {
                str = UtilsCommons.AjaxReturnJson("0", "您没有删除权限，请联系管理员！");
                this.RCWE(str);
                return;
            }

            int r = new EyouSoft.BLL.TourStructure.BRoute().DeleteRouteZhengCe(pid);

            str = r == 1 ? UtilsCommons.AjaxReturnJson("1", "删除成功") : UtilsCommons.AjaxReturnJson("0", "删除失败");

            this.RCWE(str);
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetStatus(object status)
        {
            EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus _status = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)status;

            if (_status == EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.已过期)
            {
                return "&nbsp;<sapn style=\"color:#ff0000\">已过期</span>";
            }

            return "&nbsp;<sapn style=\"color:#000000\">正常</span>";
        }
    }
}
