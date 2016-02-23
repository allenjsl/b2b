using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.ResourceManage
{
    public partial class DiJieSheZhuTiEdit : EyouSoft.Common.Page.BackPage
    {
        #region attributes
        /// <summary>
        /// 供应商主体编号
        /// </summary>
        protected string EditId = string.Empty;

        /// <summary>
        /// 添加权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;
        /// <summary>
        /// 删除权限
        /// </summary>
        bool Privs_ShanChu = false;

        /// <summary>
        /// 省份编号
        /// </summary>
        protected string ShengFenId = string.Empty;
        /// <summary>
        /// 城市编号
        /// </summary>
        protected string ChengShiId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");
            InitPrivs();

            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_修改);
            Privs_ShanChu = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.资源管理_地接社主体管理_删除);

            if (string.IsNullOrEmpty(EditId))
            {
                if (Privs_TianJia) ltrCaoZuo.Text = "<a href=\"javascript:void(0)\" id=\"a_baocun\">保存</a>";
                else ltrCaoZuo.Text = "你没有操作权限";
            }
            else
            {
                if (Privs_XiuGai) ltrCaoZuo.Text = "<a href=\"javascript:void(0)\" id=\"a_baocun\">保存</a>";
                else ltrCaoZuo.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(EditId)) return;
            var info = new EyouSoft.BLL.GysStructure.BGysZhuTi().GetInfo(EditId);
            if (info == null) Utils.RCWE("异常请求");

            txtGysName.Value = info.GysName;
            ShengFenId = info.ShengFenId.ToString();
            ChengShiId = info.ChengShiId.ToString();
            txtLxrName.Value = info.LxrName;
            txtLxrDianHua.Value = info.LxrDianHua;
            txtLxrShouJi.Value = info.LxrShouJi;
            txtFax.Value = info.Fax;
            txtDiZhi.Value = info.DiZhi;

            var outputScript = string.Format("var guanXiItems={0};", Newtonsoft.Json.JsonConvert.SerializeObject(info.GuanXis));
            if (info.GuanXis != null && info.GuanXis.Count > 0) RegisterScript(outputScript);
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.GysStructure.MGysZhuTiInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.GysStructure.MGysZhuTiInfo();
            info.CaoZuoRenId = SiteUserInfo.UserId;
            info.ChengShiId = Utils.GetInt(Utils.GetFormValue("txtChengShi"));
            info.CompanyId = SiteUserInfo.CompanyId;
            info.DiZhi = Utils.GetFormValue(txtDiZhi.UniqueID);
            info.Fax = Utils.GetFormValue(txtFax.UniqueID);
            info.GuanXis = new List<EyouSoft.Model.GysStructure.MGysZhuTiGuanXiInfo>();
            info.GysId = EditId;
            info.GysName = Utils.GetFormValue(txtGysName.UniqueID);
            info.IssueTime = DateTime.Now;
            info.JieShao = string.Empty;
            info.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.SupplierType.地接;
            info.LxrDianHua = Utils.GetFormValue(txtLxrDianHua.UniqueID);
            info.LxrName = Utils.GetFormValue(txtLxrName.UniqueID);
            info.LxrShouJi = Utils.GetFormValue(txtLxrShouJi.UniqueID);
            info.ShengFenId = Utils.GetInt(Utils.GetFormValue("txtShengFen"));
            info.ZxsId = SiteUserInfo.ZxsId;

            var txtGuanXiGysId = Utils.GetFormValues("txtGuanXiGysId");
            if (txtGuanXiGysId != null && txtGuanXiGysId.Length > 0)
            {
                foreach (var item in txtGuanXiGysId)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    bool isExists = false;
                    foreach (var item1 in info.GuanXis)
                    {
                        if (item1.GysId == item) { isExists = true; }
                    }
                    if (isExists) continue;

                    info.GuanXis.Add(new EyouSoft.Model.GysStructure.MGysZhuTiGuanXiInfo() { GysId = item });
                }
            }

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();

            if (string.IsNullOrEmpty(EditId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(EditId))
            {
                bllRetCode = new EyouSoft.BLL.GysStructure.BGysZhuTi().GysZhuTi_C(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.GysStructure.BGysZhuTi().GysZhuTi_U(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }
        #endregion
    }
}
