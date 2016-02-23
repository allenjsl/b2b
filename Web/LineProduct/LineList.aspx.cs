using System;
using EyouSoft.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.LineProduct
{
    /// <summary>
    /// 线路管理
    /// </summary>
    public partial class LineList : EyouSoft.Common.Page.BackPage
    {
        private const int PageSize = 10;

        private int _pageIndex = 1;

        private int _recordCount;

        //private IList<EyouSoft.Model.CompanyStructure.Area> _areaList;

        protected bool IsEdit;

        protected bool IsDel;
        protected string ZhuangTai = string.Empty;
        protected string LeiXing = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_栏目, true);
                return;
            }

            if (!IsPostBack)
            {
                string doType = Utils.GetQueryStringValue("doType");
                string rid = Utils.GetQueryStringValue("rid");

                if (!string.IsNullOrEmpty(doType) && doType.ToLower() == "del" && !string.IsNullOrEmpty(rid))
                {
                    DeleteRoute(rid);
                    return;
                }

                CheckPrive();
                //InitArea();
                InitPage();
                InitQuYu();
            }
        }

        /// <summary>
        /// 根据权限控制按钮显示
        /// </summary>
        private void CheckPrive()
        {
            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_新增))
            {
                plnAdd.Visible = false;
            }
            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_修改))
            {
                IsEdit = true;
            }
            //判断权限
            if (CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_删除))
            {
                IsDel = true;
            }
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            int areaId = Utils.GetInt(Utils.GetQueryStringValue("txtQuYu"));
            string rName = Utils.GetQueryStringValue("rName");
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            var chaXun= new EyouSoft.Model.TourStructure.MSearchRoute { AreaId = areaId, RouteName = rName, ZhengCeStatus = (EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus), Utils.GetQueryStringValue("txtZhengCeStatus")) };
            chaXun.LeiXing = (EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing), Utils.GetQueryStringValue("txtLeiXing"));
            chaXun.BiaoZhun = (EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun), Utils.GetQueryStringValue("txtBiaoZhun"));
            
            if (Utils.GetQueryStringValue("iscx") != "1")
            {
                chaXun.ZhengCeStatus = EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.正常;
                chaXun.LeiXing = EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing.常规旅游;
            }

            if (chaXun.ZhengCeStatus.HasValue)
            {
                ZhuangTai = ((int)chaXun.ZhengCeStatus.Value).ToString();
            }

            if (chaXun.LeiXing.HasValue)
            {
                LeiXing = ((int)chaXun.LeiXing.Value).ToString();
            }
            chaXun.ZxsId = CurrentZxsId;


            var list = new EyouSoft.BLL.TourStructure.BRoute().GetRouteList(
                CurrentUserCompanyID,
                PageSize,
                _pageIndex,
                ref _recordCount,
               chaXun);

            UtilsCommons.Paging(PageSize, ref _pageIndex, _recordCount);
            rptRoute.DataSource = list;
            rptRoute.DataBind();

            page1.intPageSize = PageSize;
            page1.intRecordCount = _recordCount;
            page1.CurrencyPage = _pageIndex;
        }

        /*/// <summary>
        /// 初始化线路区域
        /// </summary>
        private void InitArea()
        {
            //_areaList = new EyouSoft.BLL.CompanyStructure.Area().GetAreaByCompanyId(CurrentUserCompanyID);
            //rptArea.DataSource = _areaList;
            //rptArea.DataBind();
        }*/

        /*protected string GetAreaDropDownList()
        {
            if (_areaList == null)
                _areaList = new EyouSoft.BLL.CompanyStructure.Area().GetAreaByCompanyId(CurrentUserCompanyID);
            var str = new System.Text.StringBuilder();
            str.Append(" <select id=\"aId\" name=\"aId\" class=\"select inputselect\" >");
            str.Append(" <option value=\"0\">请选择</option> ");
            if (_areaList != null && _areaList.Any())
            {
                foreach (var t in _areaList)
                {
                    str.AppendFormat(" <option value=\"{0}\">{1}</option> ", t.Id, t.AreaName);
                }
            }
            str.Append(" </select> ");

            return str.ToString();
        }*/

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
        /// 初始化线路区域td
        /// </summary>
        /// <param name="index">行索引</param>
        /// <param name="areaName">线路区域名称</param>
        /// <param name="areaId">线路区域编号</param>
        /// <returns></returns>
        protected string GetAreaName(int index, object areaName, object areaId)
        {
            if (index < 0 || areaName == null || areaId == null) return string.Empty;

            if (index == 0)
            {
                return
                    "<a title=\"点击查询\" href=\"/LineProduct/LineList.aspx?aid=0\"><img width=\"76\" height=\"24\" alt=\"\" src=\"/images/xianlubtn.gif\"></a>";
            }
            if (index % 14 == 0)
            {
                return "&nbsp;";
            }

            return
                string.Format(
                    "<a title=\"点击查询\" href=\"/LineProduct/LineList.aspx?aid={1}\"><img src=\"/images/icon002.gif\"/> {0}</a>",
                    areaName.ToString(),
                    Utils.GetInt(areaId.ToString()));
        }

        /// <summary>
        /// 删除线路
        /// </summary>
        /// <param name="rid">线路编号</param>
        private void DeleteRoute(string rid)
        {
            string str;
            if (string.IsNullOrEmpty(rid))
            {
                str = UtilsCommons.AjaxReturnJson("0", "参数丢失，请刷新页面后重试！");
                this.RCWE(str);
                return;
            }

            //判断权限
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.线路产品_线路管理_删除))
            {
                str = UtilsCommons.AjaxReturnJson("0", "您没有删除权限，请联系管理员！");
                this.RCWE(str);
                return;
            }

            int r = new EyouSoft.BLL.TourStructure.BRoute().DeleteRouteById(rid);

            if (r == 1)
            {
                str = UtilsCommons.AjaxReturnJson("1", "删除成功");
            }
            else if (r == -1)
            {
                str = UtilsCommons.AjaxReturnJson("0", "该线路下存在收客数不允许删除");
            }
            else
            {
                str = UtilsCommons.AjaxReturnJson("0", "删除失败");
            }

            //str = r == 1 ? UtilsCommons.AjaxReturnJson("1", "删除成功") : UtilsCommons.AjaxReturnJson("0", "删除失败");

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
                            //s.AppendFormat("<option value=\"{0}\" data-zhandianid=\"{2}\" data-zxlbid=\"{3}\" data-quyuid=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName, item.ZhanDianId, item1.ZxlbId);
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName);
                        }

                        s.AppendFormat("</optgroup>");
                    }
                }
            }

            ltrQuYuOption.Text = s.ToString();
        }
    }
}
