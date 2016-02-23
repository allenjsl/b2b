using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb
{
    public partial class ZhuCe : QianTaiYeMian
    {
        #region attributes
        /// <summary>
        /// 客服电话
        /// </summary>
        protected string KeFuDianHua = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
            InteBind();

            InitInfo();
        }

        #region private members
        void InteBind()
        {
            #region 绑定广告
            var chaXun = new EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo();
            chaXun.WeiZhi = EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi.注册右侧热门线路推荐;
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.正常;
            int recordCount = 0;
            var item = new EyouSoft.BLL.PtStructure.BGuangGao().GetGuangGaos(SysCompanyId, 3, 1, ref recordCount, chaXun);

            if (item.Count > 0)
            {
                RepReMen.DataSource = item;
                RepReMen.DataBind();
            } 
            #endregion
        }

        void BaoCun()
        {
            EyouSoft.Model.CompanyStructure.MKeHuZhuCeInfo Model = new EyouSoft.Model.CompanyStructure.MKeHuZhuCeInfo();
            Model.KeHuChengShiId = Utils.GetInt(Utils.GetFormValue("txtChengShi"));
            Model.KeHuDianHua = Utils.GetFormValue("CompanyTel");
            Model.KeHuDiZhi = Utils.GetFormValue("CompanyAdress");
            Model.KeHuFax = Utils.GetFormValue("CompanyFax");
            Model.KeHuName = Utils.GetFormValue("ComapnyName");
            Model.KeHuShengFenId = Utils.GetInt(Utils.GetFormValue("txtShengFen"));
            Model.YongHuDianHua = Utils.GetFormValue("HuiYuanTel");
            Model.YongHuMiMa = Utils.GetFormValue("HuiYuanPassword");
            Model.YongHuYouXiang = Utils.GetFormValue("HuiYuanEmail");
            Model.YongHuMing = Utils.GetFormValue("HuiYuanName");
            Model.YongHuShouJi = Utils.GetFormValue("HuiYuanMobile");
            Model.YongHuXingMing = Utils.GetFormValue("MemberName");
            Model.ZhuCeShiJian = DateTime.Now;
            Model.CompanyId = YuMingInfo.CompanyId;

            int count = new EyouSoft.BLL.CompanyStructure.Customer().PT_KeHuZhuCe(Model);
            if (count == 1)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count.ToString(), "注册成功，请等待审核后为您开通账号！"));
            }
            else if(count == -99)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count.ToString(), "注册失败，该公司已注册！"));
            }
            else if (count == -98)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count.ToString(), "注册失败，该用户名已存在！"));
            }
            else if (count == -97)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count.ToString(), "注册失败，该邮箱已注册！"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson(count.ToString(), "注册失败，请联系客服！"));
            }

        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var keFuDianHuaInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.客服电话);

            KeFuDianHua = keFuDianHuaInfo.V;
        }
        #endregion
    }
}
