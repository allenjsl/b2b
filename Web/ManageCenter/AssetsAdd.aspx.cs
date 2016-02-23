using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.BLL.AdminCenterStructure;

namespace Web.ManageCenter
{
    public partial class AssetsAdd : BackPage
    {
        /// <summary>
        /// 操作权限
        /// </summary>
        protected bool IsSaveGrant;
        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            PowerControl();
            string save = Utils.GetQueryStringValue("save");
            string doType = Request.QueryString["doType"];
            #region ajax请求
            if (save == "save")
            {
                PageSave(doType);
            }
            #endregion
            if (!IsPostBack)
            {
                string id = Utils.GetQueryStringValue("id");
                PageInit(id);
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit(string id)
        {
            //编辑初始化
            if (!string.IsNullOrEmpty(id))
            {
                var BLL = new FixedAsset();
                var Model = BLL.GetModel(this.SiteUserInfo.CompanyId,Utils.GetInt(id));
                if (null != Model)
                {
                    //员资产编号
                    this.txtAssetNo.Value = Model.AssetNo;
                    //资产名称
                    this.txtAssetName.Value = Model.AssetName;
                    //购买时间
                    this.txtBuyDate.Text = Model.BuyDate.ToString(ProviderToDate);
                    //折旧费
                    this.txtCost.Text = Model.Cost.ToString();
                    //备注 
                    this.txtRemark.Value = Model.Remark;
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        protected void PageSave(string doType)
        {
            var isOk = false;
            var msg = string.Empty;
            var Model = new EyouSoft.Model.AdminCenterStructure.FixedAsset();
            Model.CompanyId = this.SiteUserInfo.CompanyId;
            Model.AssetNo = Utils.GetFormValue("txtAssetNo");
            Model.AssetName = Utils.GetFormValue("txtAssetName");
            Model.BuyDate = Utils.GetDateTime(Utils.GetFormValue("txtBuyDate"));
            Model.Cost = Utils.GetDecimalNull(Utils.GetFormValue("txtCost"));
            Model.Remark = Utils.GetFormValue("txtRemark");
            Model.Id = Utils.GetInt(Utils.GetQueryStringValue("id"));

            var BLL = new FixedAsset();
            if (doType == "add")
            {
                isOk = BLL.Add(Model);
                msg = isOk ? "添加成功！" : "添加失败！";
            }
            if (doType == "update")
            {
                isOk = BLL.Update(Model);
                msg = isOk ? "修改成功！" : "修改失败！";
            }
            Response.Write(UtilsCommons.AjaxReturnJson(isOk ? "1" : "0", msg));
            Response.End();
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        protected void PowerControl()
        {
            if (!this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_固定资产管理_栏目))
            {
                Utils.ResponseNoPermit(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_固定资产管理_栏目, false);
            }
            else
            {
                string doType = Utils.GetQueryStringValue("doType");
                if (doType == "add")
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_固定资产管理_新增);
                }
                else
                {
                    IsSaveGrant = this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_固定资产管理_修改);
                }
            }
        }
        #endregion

        #region 重写OnPreInit
        /// <summary>
        /// 重写OnPreInit 指定页面类型
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = PageType.boxyPage;
        }
        #endregion        
    }
}
