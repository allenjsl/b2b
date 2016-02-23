//个人信息 汪奇志 2014-09-03
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
    /// 个人信息
    /// </summary>
    public partial class GeRen : HuiYuanYeMian
    {
        #region attributes
        /// <summary>
        /// 性别
        /// </summary>
        protected string XingBie = "0";
        /// <summary>
        /// 客户联系人状态
        /// </summary>
        protected string KeHuLxrStatus = "UNLOCK";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "submit") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(YongHuInfo.YongHuId);

            txtYongHuMing.Value = info.UserName;
            txtXingMing.Value = info.PersonInfo.ContactName;
            txtShouJi.Value = info.PersonInfo.ContactMobile;
            txtDianHua.Value = info.PersonInfo.ContactTel;
            txtFax.Value = info.PersonInfo.ContactFax;
            txtYouXiang.Value = info.PersonInfo.ContactEmail;
            txtQQ.Value = info.PersonInfo.QQ;
            txtWeiXinHao.Value = info.WeiXinHao;
            txtBuMenName.Value = info.BuMenName;
            txtZhiWu.Value = info.PersonInfo.JobName;
            txtDanJuTaiTouMingCheng.Value = info.DanJuTaiTouMingCheng;
            txtDanJuTaiTouDiZhi.Value = info.DanJuTaiTouDiZhi;
            txtDanJuTaiTouDianHua.Value = info.DanJuTaiTouDianHua;

            XingBie = ((int)info.PersonInfo.ContactSex).ToString();
            if (info.KeHuLxrStatus == EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除) KeHuLxrStatus = "LOCK";

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

        /// <summary>
        /// get from info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CompanyUser GetFormInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.CompanyUser();
            info.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();

            info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(YongHuInfo.YongHuId);

            info.ID = YongHuInfo.YongHuId;
            info.CompanyId = YongHuInfo.CompanyId;
            info.KeHuId = YongHuInfo.KeHuId;
            info.UserName = YongHuInfo.Username;
           
            info.PersonInfo.ContactSex = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(Utils.GetFormValue("txtXingBie"), EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
            info.PersonInfo.QQ = Utils.GetFormValue(txtQQ.UniqueID);
            info.WeiXinHao = Utils.GetFormValue(txtWeiXinHao.UniqueID);
            
            info.DanJuTaiTouMingCheng = Utils.GetFormValue(txtDanJuTaiTouMingCheng.UniqueID);
            info.DanJuTaiTouDiZhi = Utils.GetFormValue(txtDanJuTaiTouDiZhi.UniqueID);
            info.OperatorId = YongHuInfo.YongHuId;
            info.IssueTime = DateTime.Now;
            info.KeHuLxrId = YongHuInfo.KeHuLxrId;
            info.DanJuTaiTouDianHua = Utils.GetFormValue(txtDanJuTaiTouDianHua.UniqueID);

            if (info.KeHuLxrStatus != EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除)
            {
                info.PersonInfo.ContactName = YongHuInfo.XingMing;//Utils.GetFormValue(txtXingMing.UniqueID);
                info.PersonInfo.ContactMobile = Utils.GetFormValue(txtShouJi.UniqueID);
                info.PersonInfo.ContactTel = Utils.GetFormValue(txtDianHua.UniqueID);
                info.PersonInfo.ContactFax = Utils.GetFormValue(txtFax.UniqueID);
                info.PersonInfo.ContactEmail = Utils.GetFormValue(txtYouXiang.UniqueID);
                info.BuMenName = Utils.GetFormValue(txtBuMenName.UniqueID);
                info.PersonInfo.JobName = Utils.GetFormValue(txtZhiWu.UniqueID);
            }

            string yuanMiMa = Utils.GetFormValue(txtYuanMiMa.UniqueID);
            string miMa = Utils.GetFormValue(txtMiMa.UniqueID);

            if (!string.IsNullOrEmpty(miMa) && !string.IsNullOrEmpty(yuanMiMa))
            {
                var pwd1 = new EyouSoft.Model.CompanyStructure.PassWord(miMa);
                var pwd2 = new EyouSoft.Model.CompanyStructure.PassWord(yuanMiMa);

                info.MiMa = pwd1.NoEncryptPassword;
                info.MiMaMd5 = pwd1.MD5Password;
                info.YuanMiMaMd5 = pwd2.MD5Password;
            }

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
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().PT_YuanGong_CU(info);

            if (bllRetCode == 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经存在相同的电子信箱"));
            else if (bllRetCode == -96) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：原始密码不正确"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));           
        }
        #endregion
    }
}
