﻿using System;
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
    /// 积分兑换商品管理
    /// </summary>
    public partial class JiFenShangPin : EyouSoft.Common.Page.BackPage
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
            if (!CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_栏目))
            {
                RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.同行端口_积分兑换商品管理_删除);

            phInsert.Visible = Privs_TianJia;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MJiFenShangPinChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MJiFenShangPinChaXunInfo();

            info.BianMa = Utils.GetQueryStringValue("txtBianMa");
            info.LeiXing = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing), Utils.GetQueryStringValue("txtLeiXing"));
            info.MingCheng = Utils.GetQueryStringValue("txtMingCheng");
            info.Status = (EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenShangPingStatus), Utils.GetQueryStringValue("txtStatus"));

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
            var items = new EyouSoft.BLL.PtStructure.BJiFen().GetShangPins(CurrentUserCompanyID, pageSize, pageIndex, ref recordCount, chaXun);

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

            string shangPinId = Utils.GetFormValue("txtShangPinId");

            int bllRetCode = new EyouSoft.BLL.PtStructure.BJiFen().DeleteShangPin(CurrentUserCompanyID, shangPinId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
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
        /// get fengmian
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetFengMian(object filepath)
        {
            if (filepath == null) return "未上传封面";
            string _filepath = filepath.ToString();
            if (string.IsNullOrEmpty(_filepath)) return "未上传封面";

            return string.Format("<img src=\"{0}\" style=\"width:106px;height:47px;margin:4px;\" />", _filepath);
        }
        #endregion
    }
}