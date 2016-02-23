//平台-用户编辑 汪奇志 2014-09-04
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
    /// 平台-用户编辑
    /// </summary>
    public partial class YuanGongEdit : HuiYuanYeMian
    {
        #region attributes
        /// <summary>
        /// 用户编号
        /// </summary>
        int YongHuId = 0;
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        int KeHuLxrId = 0;

        protected string XingBie = "0";

        /// <summary>
        /// 用户操作方式
        /// </summary>
        protected string YongHuCZFS = "C";
        /// <summary>
        /// 客户联系人操作方式
        /// </summary>
        protected string KeHuLxrCZFS = "C";
        /// <summary>
        /// 客户联系人状态
        /// </summary>
        protected string KeHuLxrStatus = "UNLOCK";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            YongHuId = Utils.GetInt(Utils.GetQueryStringValue("txtYongHuId"));
            KeHuLxrId = Utils.GetInt(Utils.GetQueryStringValue("txtKeHuLxrId"));

            if (YongHuId > 0 && KeHuLxrId == 0) RCWE("异常请求");

            if (Utils.GetQueryStringValue("dotype") == "submit") BaoCun();

            InitInfo();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (YongHuId == 0 && KeHuLxrId == 0) return;

            if (YongHuId > 0) InitYongHuInfo();
            else InitKeHuLxrInfo();    
        }

        /// <summary>
        /// init yonghu info
        /// </summary>
        void InitYongHuInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(YongHuId);
            if (info == null) RCWE("异常请求");

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

            XingBie = ((int)info.PersonInfo.ContactSex).ToString();

            YongHuCZFS = KeHuLxrCZFS = "U";
            if (info.KeHuLxrStatus == EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除) KeHuLxrStatus = "LOCK";
        }

        /// <summary>
        /// init kehulxr info
        /// </summary>
        void InitKeHuLxrInfo()
        {
            var info = new EyouSoft.BLL.CompanyStructure.Customer().GetKeHuLxrInfo(YongHuInfo.KeHuId, KeHuLxrId);
            if (info == null) RCWE("异常请求");

            //txtYongHuMing.Value = info.UserName;
            txtXingMing.Value = info.Name;
            txtShouJi.Value = info.Mobile;
            txtDianHua.Value = info.Tel;
            txtFax.Value = info.Fax;
            txtYouXiang.Value = info.Email;
            txtQQ.Value = info.qq;
            //txtWeiXinHao.Value = in;
            txtBuMenName.Value = info.DepartId;
            txtZhiWu.Value = info.Job;

            XingBie = ((int)info.Sex).ToString();

            YongHuCZFS = "C";
            KeHuLxrCZFS = "U";
            if (info.Status == EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除) KeHuLxrStatus = "LOCK";
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CompanyUser GetFormInfo()
        {
            var info = new EyouSoft.Model.CompanyStructure.CompanyUser();
            info.PersonInfo = new EyouSoft.Model.CompanyStructure.ContactPersonInfo();

            string keHuLxrStatus = "UNLOCK";
            if (YongHuId > 0)
            {
                info = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetUserInfo(YongHuId);
                if (info == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));
                if (info.KeHuLxrStatus == EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除) keHuLxrStatus = "LOCK";
            }
            else if (KeHuLxrId > 0)
            {
                var keHuLxrInfo = new EyouSoft.BLL.CompanyStructure.Customer().GetKeHuLxrInfo(YongHuInfo.KeHuId, KeHuLxrId);
                if (keHuLxrInfo == null) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求"));
                if (keHuLxrInfo.Status == EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除) keHuLxrStatus = "LOCK";

                info.ID = keHuLxrInfo.YongHuId;
                info.PersonInfo.ContactName = keHuLxrInfo.Name;
                info.PersonInfo.ContactSex = keHuLxrInfo.Sex;
                info.PersonInfo.ContactMobile = keHuLxrInfo.Mobile;
                info.PersonInfo.ContactTel = keHuLxrInfo.Tel;
                info.PersonInfo.ContactFax = keHuLxrInfo.Fax;
                info.PersonInfo.ContactEmail = keHuLxrInfo.Email;
                info.PersonInfo.QQ = keHuLxrInfo.qq;
                info.PersonInfo.JobName = keHuLxrInfo.Job;
                info.BuMenName = keHuLxrInfo.DepartId;
                info.UserName = Utils.GetFormValue(txtYongHuMing.UniqueID);
                info.KeHuLxrId = keHuLxrInfo.ContactId;
            }
            else
            {
                info.UserName = Utils.GetFormValue(txtYongHuMing.UniqueID);
            }

            info.PersonInfo.QQ = Utils.GetFormValue(txtQQ.UniqueID);
            info.WeiXinHao = Utils.GetFormValue(txtWeiXinHao.UniqueID);

            if (keHuLxrStatus == "UNLOCK")
            {
                info.PersonInfo.ContactName = Utils.GetFormValue(txtXingMing.UniqueID);
                info.PersonInfo.ContactSex = Utils.GetEnumValue<EyouSoft.Model.EnumType.CompanyStructure.Sex>(Utils.GetFormValue("txtXingBie"), EyouSoft.Model.EnumType.CompanyStructure.Sex.未知);
                info.PersonInfo.ContactMobile = Utils.GetFormValue(txtShouJi.UniqueID);
                info.PersonInfo.ContactTel = Utils.GetFormValue(txtDianHua.UniqueID);
                info.PersonInfo.ContactFax = Utils.GetFormValue(txtFax.UniqueID);
                info.PersonInfo.ContactEmail = Utils.GetFormValue(txtYouXiang.UniqueID);
                info.BuMenName = Utils.GetFormValue(txtBuMenName.UniqueID);
                info.PersonInfo.JobName = Utils.GetFormValue(txtZhiWu.UniqueID);
            }

            info.KeHuId = YongHuInfo.KeHuId;
            info.OperatorId = YongHuInfo.YongHuId;
            info.IssueTime = DateTime.Now;
            info.CompanyId = SysCompanyId;

            string miMa = Utils.GetFormValue(txtMiMa.UniqueID);

            if (!string.IsNullOrEmpty(miMa))
            {
                var pwd1 = new EyouSoft.Model.CompanyStructure.PassWord(miMa);

                info.MiMa = pwd1.NoEncryptPassword;
                info.MiMaMd5 = pwd1.MD5Password;
            }

            info.KeHuLxrStatus = EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除;

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
            else if (bllRetCode == -99) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经存在的用户账号"));
            else if (bllRetCode == -98) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：已经存在相同的电子信箱"));
            else if (bllRetCode == -96) Utils.RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：原始密码不正确"));
            else Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));         
        }
        #endregion
    }
}
