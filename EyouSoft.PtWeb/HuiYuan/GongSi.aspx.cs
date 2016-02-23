//会员-公司信息 汪奇志 2014-09-02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb.HuiYuan
{
    /// <summary>
    /// 会员-公司信息
    /// </summary>
    public partial class GongSi : HuiYuanYeMian
    {
        #region attributes
        protected string ShengFenId = string.Empty;
        protected string ChengShiId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "submit") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CustomerInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.CustomerInfo();

            info.CompanyId = YongHuInfo.CompanyId;
            info.Id = YongHuInfo.KeHuId;
            info.ProviceId = Utils.GetInt(Utils.GetFormValue("txtShengFen"));
            info.CityId = Utils.GetInt(Utils.GetFormValue("txtChengShi"));
            info.Adress = Utils.GetFormValue(txtDiZhi.UniqueID);
            info.GongSiDianHua = Utils.GetFormValue(txtGongSiDianHua.UniqueID);
            info.GongSiFax = Utils.GetFormValue(txtGongSiFax.UniqueID);
            info.ContactName = Utils.GetFormValue(txtLxrName.UniqueID);
            info.Phone = Utils.GetFormValue(txtLxrDianHua.UniqueID);
            info.Mobile = Utils.GetFormValue(txtLxrShouJi.UniqueID);
            info.LxrQQ = Utils.GetFormValue(txtLxrQQ.UniqueID);
            info.LxrEmail = Utils.GetFormValue(txtLxrYouXiang.UniqueID);
            info.JieShao = Utils.GetFormEditorValue(txtJieShao.UniqueID);

            info.OperatorId = YongHuInfo.YongHuId;
            info.IssueTime = DateTime.Now;

            #region logo
            var logoFiles = txtLogo.Files;
            if (logoFiles != null && logoFiles.Count > 0)
            {
                info.LogoFilepath = logoFiles[0].Filepath;
            }
            else
            {
                logoFiles = txtLogo.YuanFiles;
                if (logoFiles != null && logoFiles.Count > 0)
                {
                    info.LogoFilepath = logoFiles[0].Filepath;
                }
            }
            #endregion

            #region daju dayin moban
            var danJuDaYinMoBanFiles = txtDaYinMoBan.Files;
            if (danJuDaYinMoBanFiles != null && danJuDaYinMoBanFiles.Count > 0)
            {
                info.DanJuDaYinMoBan = danJuDaYinMoBanFiles[0].Filepath;
            }
            else
            {
                danJuDaYinMoBanFiles = txtDaYinMoBan.YuanFiles;
                if (danJuDaYinMoBanFiles != null && danJuDaYinMoBanFiles.Count > 0)
                {
                    info.DanJuDaYinMoBan = danJuDaYinMoBanFiles[0].Filepath;
                }
            }
            #endregion

            return info;
        }

        /// <summary>
        /// baocun
        /// </summary>
        void BaoCun()
        {
            var info = GetFormInfo();
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.Customer().PT_KeHuXiuGai(info);

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));            
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetCustomerModel(YongHuInfo.KeHuId);

            if (info == null) return;

            txtGongSiName.Value = info.Name;
            txtXuKeZhengHao.Value = info.Licence;
            txtYingYeZhiZhaoHao.Value = info.YingYeZhiZhaoHao;
            txtDiZhi.Value = info.Adress;
            txtFaRenName.Value = info.FaRenName;
            txtGongSiDianHua.Value = info.GongSiDianHua;
            txtGongSiFax.Value = info.GongSiFax;
            txtLxrName.Value = info.ContactName;
            txtLxrDianHua.Value = info.Phone;
            txtLxrShouJi.Value = info.Mobile;
            txtLxrQQ.Value = info.LxrQQ;
            txtLxrYouXiang.Value = info.LxrEmail;
            txtJieShao.Value = info.JieShao;
            ShengFenId = info.ProviceId.ToString();
            ChengShiId = info.CityId.ToString();

            #region logo
            var logoFiles = new List<EyouSoft.PtWeb.ashx.uploadfile.MFileInfo>();

            if (!string.IsNullOrEmpty(info.LogoFilepath))
            {
                var logoFile = new EyouSoft.PtWeb.ashx.uploadfile.MFileInfo();
                logoFile.Filepath = info.LogoFilepath;
                logoFiles.Add(logoFile);

                txtLogo.YuanFiles = logoFiles;
            }
            #endregion

            #region danju dayin moban
            var danJuDaYinMoBanFiles = new List<EyouSoft.PtWeb.ashx.uploadfile.MFileInfo>();

            if (!string.IsNullOrEmpty(info.DanJuDaYinMoBan))
            {
                var danJuDanYinMoBanFile = new EyouSoft.PtWeb.ashx.uploadfile.MFileInfo();
                danJuDanYinMoBanFile.Filepath = info.DanJuDaYinMoBan;
                danJuDaYinMoBanFiles.Add(danJuDanYinMoBanFile);

                txtDaYinMoBan.YuanFiles = danJuDaYinMoBanFiles;
            }
            #endregion
        }
        #endregion
    }
}
