using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.EnumType.FinStructure;
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace Web.Fin
{
    public partial class GongZiEdit : BackPage
    {
        #region attributes
        /// <summary>
        /// 工资编号
        /// </summary>
        string GongzId = string.Empty;
        /// <summary>
        /// 工资新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 工资修改权限
        /// </summary>
        bool Privs_Update = false;
        /// <summary>
        /// 工资发放类型
        /// </summary>
        protected int FaFangLeiXing = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            GongzId = Utils.GetQueryStringValue("gongzi");
            InitPrivs();
            if (Utils.GetQueryStringValue("doType") == "save") Save();
            InitInfo();
        }

        #region private members

        /// <summary>
        /// 初始化工资信息
        /// </summary>
        void InitInfo()
        {
            txtRiQi.Value = DateTime.Now.ToString("yyyy-MM-dd");
            if (Privs_Insert) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
            else ltrOperatorHtml.Text = "你没有工资操作权限";

            var info = new EyouSoft.BLL.FinStructure.BGongZi().GetInfo(GongzId);
            if (info == null) return;

            txtRiQi.Value = info.FaFangTime.ToString("yyyy-MM-dd");
            txtYuanGong.SellsID = info.YuanGongId.ToString();
            txtYuanGong.SellsName = info.YuanGongName;
            string[] date = Utils.Split(Utils.GetFormValue("Month"), "-");
            txtNyf.Value = info.Year.ToString() + "-" + info.Month.ToString();
            txt_jbgz.Text = info.JiBenGongZi.ToString("F2");
            txt_glbz.Text = info.GongLingBuTie.ToString("F2");
            txt_shfbz.Text = info.ShengHuoFeiBuTie.ToString("F2");
            txt_sbbt.Text = info.SheBaoBuTie.ToString("F2");
            txt_gwbt.Text = info.GangWeiBuTie.ToString("F2");
            txt_jdjj.Text = info.JiDuJiangJin.ToString("F2");
            txt_kcsb.Text = info.SheBaoKouChu.ToString("F2");
            txt_shfkc.Text = info.ShengHuoFeiKouChu.ToString("F2");
            txt_gzhj.Text = info.GongZiHeJi.ToString("F2");
            txt_shfkcmx.Text = info.ShengHuoFeiBeiZhu;
            txt_cdkc.Text = info.ChiDaoKouChu.ToString("F2");
            txt_cdkcmx.Text = info.ChiDaoBeiZhu;
            txt_qtkfje.Text = info.QiTaKouChu.ToString("F2");
            txt_qtkfmx.Text = info.QiTaBeiZhu;
            txt_jdjjmx.Text = info.JiDuJiangJinBeiZhu;
            txt_sfgz.Text = info.ShiFaGongZi.ToString("F2");
            txtGongZiBeiZhu.Text = info.BeiZhu;
            FaFangLeiXing = (int)info.FaFangLeiXing;

            switch (info.Status)
            {
                case GongZiStatus.未审批:
                    if (Privs_Update) ltrOperatorHtml.Text = "<a href=\"javascript:void(0)\" id=\"i_a_save\">保存</a>";
                    else ltrOperatorHtml.Text = "你没有操作权限";
                    break;
                case GongZiStatus.未支付:
                    ltrOperatorHtml.Text = "工资审批已通过，等待支付";
                    break;
                case GongZiStatus.已支付:
                    ltrOperatorHtml.Text = "工资已支付";
                    break;
                default: break;
            }
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert =  CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.财务管理_工资管理_修改);
        }

        /// <summary>
        /// save
        /// </summary>
        void Save()
        {
            if (string.IsNullOrEmpty(GongzId))
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            else
            {
                if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("-1000", "操作失败：没有操作权限。"));
            }
            

            EyouSoft.Model.FinStructure.MGongZiInfo info = GetFormInfo();
            info.GongZiId = GongzId;
            int bllRetCode = 0;

            if (string.IsNullOrEmpty(GongzId))
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().Insert(info);
            }
            else
            {
                bllRetCode = new EyouSoft.BLL.FinStructure.BGongZi().Update(info);
            }

            if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            else if (bllRetCode == -1) RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：" + info.YuanGongName + "的" + info.Year + "年" + info.Month + "月" + info.FaFangLeiXing + "信息已存在"));
            else RCWE(UtilsCommons.AjaxReturnJson(bllRetCode.ToString(), "操作失败：异常代码" + bllRetCode));

        }

        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MGongZiInfo GetFormInfo()
        {
            EyouSoft.Model.FinStructure.MGongZiInfo info = new EyouSoft.Model.FinStructure.MGongZiInfo();

            info.FaFangTime = Utils.GetDateTime(Utils.GetFormValue("txtRiQi"));
            info.YuanGongId = Utils.GetInt(Utils.GetFormValue("txtYuanGongId"));
            info.YuanGongName = Utils.GetFormValue("txtYuanGongName");
            info.CompanyId = CurrentUserCompanyID;
            info.OperatorId = SiteUserInfo.UserId;

            string[] date = Utils.Split(Utils.GetFormValue("Month"), "-");
            info.Year = Utils.GetInt(date[0]);
            info.Month = Utils.GetInt(date[1]);
            info.JiBenGongZi = Utils.GetDecimal(Utils.GetFormValue("JiBenGongZi"));
            info.GongLingBuTie = Utils.GetDecimal(Utils.GetFormValue("GongLingBuTie"));
            info.ShengHuoFeiBuTie = Utils.GetDecimal(Utils.GetFormValue("ShengHuoFeiBuTie"));
            info.SheBaoBuTie = Utils.GetDecimal(Utils.GetFormValue("SheBaoBuTie"));
            info.GangWeiBuTie = Utils.GetDecimal(Utils.GetFormValue("GangWeiBuTie"));
            info.JiDuJiangJin = Utils.GetDecimal(Utils.GetFormValue("JiDuJiangJin"));
            info.SheBaoKouChu = Utils.GetDecimal(Utils.GetFormValue("SheBaoKouChu"));
            info.ShengHuoFeiKouChu = Utils.GetDecimal(Utils.GetFormValue("ShengHuoFeiKouChu"));
            info.GongZiHeJi = Utils.GetDecimal(Utils.GetFormValue("GongZiHeJi"));
            info.ShengHuoFeiBeiZhu = Utils.GetFormValue("ShengHuoFeiBeiZhu");
            info.ChiDaoKouChu = Utils.GetDecimal(Utils.GetFormValue("ChiDaoKouChu")); ;
            info.ChiDaoBeiZhu = Utils.GetFormValue("ChiDaoBeiZhu");
            info.QiTaKouChu = Utils.GetDecimal(Utils.GetFormValue("QiTaKouChu")); ;
            info.QiTaBeiZhu = Utils.GetFormValue("QiTaBeiZhu");
            info.JiDuJiangJinBeiZhu = Utils.GetFormValue("JiDuJiangJinBeiZhu");

            info.ShiFaGongZi = Utils.GetDecimal(Utils.GetFormValue("ShiFaGongZi"));
            info.BeiZhu = Utils.GetFormValue("txtGongZiBeiZhu");
            info.FaFangLeiXing = Utils.GetEnumValue<GongZiFaFangLeiXing>(Utils.GetFormValue("txtFaFangLeiXing"), GongZiFaFangLeiXing.工资);
            info.ZxsId = CurrentZxsId;

            return info;
        }
        #endregion
    }
}
