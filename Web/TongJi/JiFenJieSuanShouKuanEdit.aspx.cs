using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.TongJi
{
    /// <summary>
    /// 统计分析-积分发放结算统计-积分结算收款登记
    /// </summary>
    public partial class JiFenJieSuanShouKuanEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 登记权限
        /// </summary>
        protected bool Privs_DengJi = false;
        /// <summary>
        /// 专线商编号
        /// </summary>
        string ZxsId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ZxsId = Utils.GetQueryStringValue("zxsid");
            if (string.IsNullOrEmpty(ZxsId)) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求。"));

            InitPrivs();

            switch (Utils.GetQueryStringValue("doType"))
            {
                case "baocun": BaoCun(); break;
                case "shanchu": ShanChu(); break;
            }

            InitTiShiXinXi();
            InitRpts();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_DengJi = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.统计分析_积分发放结算统计表_结算收款登记);
        }

        /// <summary>
        /// init tishixinxi
        /// </summary>
        void InitTiShiXinXi()
        {
            var jieSuanXinXi = new EyouSoft.BLL.TongJiStructure.BJiFen().GetZxsJieSuanXinXi(CurrentUserCompanyID, ZxsId);
            var zxsInfo = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(ZxsId);
            if (zxsInfo == null) RCWE(UtilsCommons.AjaxReturnJson("-1", "异常请求。"));

            ltrTiShiXinXi.Text = string.Format("{4} 有效积分：{0}，已结算积分：{1}，已审批金额：{2}，未审批金额：{3}", jieSuanXinXi[0]
                , jieSuanXinXi[1]
                , ToMoneyString(jieSuanXinXi[2])
                , ToMoneyString(jieSuanXinXi[3])
                , zxsInfo.MingCheng);
        }

        /// <summary>
        /// int repeater
        /// </summary>
        void InitRpts()
        {
            var items = new EyouSoft.BLL.TongJiStructure.BJiFen().GetJiFenJieSuanShouKuans(CurrentUserCompanyID,ZxsId);

            if (items != null && items.Count > 0)
            {
                rpts.DataSource = items;
                rpts.DataBind();
            }
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        void BaoCun()
        {
            if (!Privs_DengJi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            var info = new EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo();
            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;
            info.JieSuanBeiZhu = Utils.GetFormValue("txtBeiZhu");
            info.JieSuanFangShi = Utils.GetEnumValue<EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi>(Utils.GetFormValue("txtFangShi"), EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi.财务现收);
            info.JieSuanId = Utils.GetFormValue("txtJieSuanId");
            info.JieSuanRenName = Utils.GetFormValue("txtName");
            info.JieSuanRiQi = Utils.GetDateTime(Utils.GetFormValue("txtRiQi"), DateTime.Now);
            info.JieSuanZhangHao = Utils.GetFormValue("txtZhangHu");
            info.JiFen = Utils.GetInt(Utils.GetFormValue("txtJiFen"));
            info.JinE = Utils.GetDecimal(Utils.GetFormValue("txtJinE"));
            info.OperatorId = SiteUserInfo.UserId;
            info.ShenPiBeiZhu = string.Empty;
            info.ShenPiRenId = 0;
            info.ShenPiShiJian = DateTime.Now;
            info.Status = EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批;
            info.ZxsId = ZxsId;


            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.JieSuanId)) bllRetCode = new EyouSoft.BLL.TongJiStructure.BJiFen().InsertJiFenJieSuanShouKuan(info);
            else bllRetCode= new EyouSoft.BLL.TongJiStructure.BJiFen().UpdateJiFenJieSuanShouKuan(info);
           
            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// 删除
        /// </summary>
        void ShanChu()
        {
            if (!Privs_DengJi) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));

            string jieSuanId = Utils.GetFormValue("txtJieSuanId");
            int bllRetCode = new EyouSoft.BLL.TongJiStructure.BJiFen().DeleteJiFenJieSuanShouKuan(CurrentUserCompanyID,ZxsId,jieSuanId);

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        
        #endregion

        #region protected members   
        /// <summary>
        /// 获取操作列HTML
        /// </summary>
        /// <param name="obj">状态</param>
        /// <returns></returns>
        protected string GetOperatorHtml(object obj)
        {
            var status = (EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)obj;
            string s = string.Empty;

            if (status == EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批)
            {
                if (Privs_DengJi)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_baocun\">修改</a>&nbsp;";
                }

                if (Privs_DengJi)
                {
                    s += "<a href=\"javascript:void(0)\" class=\"i_shanchu\">删除</a>&nbsp;";
                }
            }
            else
            {
                s = "已审批";
            }

            return s;
        }
        #endregion
    }
}
