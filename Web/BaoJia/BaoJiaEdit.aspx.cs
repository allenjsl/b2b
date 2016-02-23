//最新报价编辑 汪奇志 2014-10-21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Web.UserControl;
using System.Text;

namespace Web.BaoJia
{
    /// <summary>
    /// 最新报价编辑
    /// </summary>
    public partial class BaoJiaEdit : EyouSoft.Common.Page.BackPage
    {
        #region private members
        /// <summary>
        /// 报价编号
        /// </summary>
        string EditId = string.Empty;
        /// <summary>
        /// 添加权限
        /// </summary>
        bool Privs_TianJia = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_XiuGai = false;

        protected string ZxlbId = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EditId = Utils.GetQueryStringValue("editid");

            InitPrivs();
            if (Utils.GetQueryStringValue("dotype") == "baocun") BaoCun();

            InitWuc();
            InitInfo();
            InitZxlbs();
        }

        #region private members
        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_TianJia = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_最新报价_新增);
            Privs_XiuGai = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_最新报价_修改);

            if (string.IsNullOrEmpty(EditId))
            {
                if (Privs_TianJia) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
            else
            {
                if (Privs_XiuGai) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                else ltrOperatorHtml.Text = "你没有操作权限";
            }
        }

        /// <summary>
        /// int web user control
        /// </summary>
        void InitWuc()
        {
            txtFuJian.Multi = "1";
            txtFuJian.XianShiLeiXing = "1";
            txtFuJian.XianShiClassName = "uploadify_xianshi1";
            txtFuJian.FileTypeExts = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;*.zip;*.doc;*.docx;*.xls;*.xlsx;*.ara;*.txt";
            txtFuJian.FileTypeDesc = "请选择文件";
            txtFuJian.UploadifyFormData1 = "1";
            txtFuJian.FileSizeLimit = "10MB";
            txtFuJian.ShuoMing = "上传的文件大小不能超过10MB";
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            if (string.IsNullOrEmpty(EditId)) return;

            var info = new EyouSoft.BLL.PtStructure.BBaoJia().GetInfo(EditId);
            if (info == null) RCWE("异常请求");

            txtBiaoTi.Value = info.BiaoTi;
            ZxlbId = info.ZxlbId.ToString();

            var fuJianFiles = new List<EyouSoft.Web.ashx.uploadfile.MFileInfo>();
            if (info.FuJians != null && info.FuJians.Count > 0)
            {
                foreach (var item in info.FuJians)
                {
                    var item1 = new EyouSoft.Web.ashx.uploadfile.MFileInfo();
                    item1.FileMiaoShu = item.MiaoShu;
                    item1.Filepath = item.Filepath;
                    fuJianFiles.Add(item1);
                }
            }
            txtFuJian.YuanFiles = fuJianFiles;
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MBaoJiaInfo GetFormInfo()
        {
            var info = new EyouSoft.Model.PtStructure.MBaoJiaInfo();

            info.BaoJiaId = EditId;            
            info.BiaoTi = Utils.GetFormValue(txtBiaoTi.UniqueID);
            info.CompanyId = CurrentUserCompanyID;
            info.IssueTime = DateTime.Now;           
            info.OperatorId = SiteUserInfo.UserId;
            info.ZxlbId = Utils.GetInt(Utils.GetFormValue("txtZxlb"));
            info.ZxsId = CurrentZxsId;

            info.FuJians = new List<EyouSoft.Model.PtStructure.MFuJianInfo>();
            #region fujian
            var fuJianFiles = txtFuJian.Files;
            if (fuJianFiles != null && fuJianFiles.Count > 0)
            {
                foreach (var fuJianFile in fuJianFiles)
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = fuJianFile.Filepath;
                    item.LeiXing = 0;
                    item.MiaoShu = fuJianFile.FileMiaoShu;
                    info.FuJians.Add(item);
                }
            }
            var yuanFuJianFiles = txtFuJian.YuanFiles;
            if (yuanFuJianFiles != null && yuanFuJianFiles.Count > 0)
            {
                foreach (var fuJianFile in yuanFuJianFiles)
                {
                    var item = new EyouSoft.Model.PtStructure.MFuJianInfo();
                    item.Filepath = fuJianFile.Filepath;
                    item.LeiXing = 0;
                    item.MiaoShu = fuJianFile.FileMiaoShu;
                    info.FuJians.Add(item);
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

            if (string.IsNullOrEmpty(info.BiaoTi)) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：请填写报价标题。"));

            if (string.IsNullOrEmpty(info.BaoJiaId))
            {
                if (!Privs_TianJia) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_XiuGai) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }

            int bllRetCode = 0;

            if (string.IsNullOrEmpty(info.BaoJiaId))
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BBaoJia().BaoJia_C(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.PtStructure.BBaoJia().BaoJia_U(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));
        }

        /// <summary>
        /// init zxlb
        /// </summary>
        void InitZxlbs()
        {
            var items = new EyouSoft.BLL.PtStructure.BPt().GetZxsZhanDians(CurrentUserCompanyID, CurrentZxsId);

            if (items == null || items.Count == 0) return;

            StringBuilder s = new StringBuilder();

            foreach (var item in items)
            {
                s.AppendFormat("<optgroup label=\"{0}\">", item.MingCheng + "站");

                foreach (var item1 in item.Zxlbs)
                {
                    s.AppendFormat("<option value=\"{0}\">{1}</option>", item1.ZxlbId, item1.MingCheng);
                }

                s.AppendFormat("</optgroup>");
            }

            ltrZxlbOption.Text = s.ToString();
        }
        #endregion
    }
}
