using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb.MP
{
    /// <summary>
    /// 同行平台-前台页面模板
    /// </summary>
    public partial class QianTai : System.Web.UI.MasterPage
    {
        #region attributes
        /// <summary>
        /// titile
        /// </summary>
        protected string ITitle = string.Empty;
        /// <summary>
        /// keywords
        /// </summary>
        protected string Keywords = string.Empty;
        /// <summary>
        /// description
        /// </summary>
        protected string Description = string.Empty;
        /// <summary>
        /// Copyright 
        /// </summary>
        protected string Copyright = string.Empty;
        /// <summary>
        /// 客服电话
        /// </summary>
        protected string KeFuDianHua = string.Empty;
        /// <summary>
        /// 域名信息
        /// </summary>
        EyouSoft.Model.PtStructure.MYuMingInfo YuMingInfo = null;
        /// <summary>
        /// erp url
        /// </summary>
        protected string ErpUrl = string.Empty;
        bool _IsXianShiHeFu = true;
        /// <summary>
        /// 是否显示横幅广告
        /// </summary>
        public bool IsXianShiHeFu { get { return _IsXianShiHeFu; } set { _IsXianShiHeFu = value; } }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitYuMingInfo();
            InitInfo();
            InitYongHuInfo();
            InitHengFu();
        }

        #region private members
        /// <summary>
        /// init yuming info
        /// </summary>
        void InitYuMingInfo()
        {
            YuMingInfo = EyouSoft.Security.Membership.TongHangYongHuProvider.GetYuMingInfo();
            ErpUrl = YuMingInfo.ErpUrl;
        }

        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            ITitle = Page.Title;

            var biaoTiInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台标题);
            var keywordsInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台关键字);
            var descriptionInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台描述);
            var keFuDianHuaInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.客服电话);
            var copyrightInfo = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(YuMingInfo.CompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.平台版权);

            ITitle += "-" + biaoTiInfo.V;
            Keywords = string.Format("<meta name=\"keywords\" content=\"{0}\" />", keywordsInfo.V);
            Description = string.Format("<meta name=\"description\" content=\"{0}\" />", descriptionInfo.V);
            KeFuDianHua = keFuDianHuaInfo.V;
            Copyright = copyrightInfo.V;
        }

        /// <summary>
        /// init yonghu info
        /// </summary>
        void InitYongHuInfo()
        {
            EyouSoft.Model.SSOStructure.MTongHangYongHuInfo yongHuInfo=null;
            var isLogin = EyouSoft.Security.Membership.TongHangYongHuProvider.IsLogin(out yongHuInfo);

            if (!isLogin)
            {
                ph_weidenglu_login0.Visible = ph_weidenglu_login1.Visible = true;
                return;
            }

            ph_yidenglu_login0.Visible = ph_yidenglu_login1.Visible = true;
            ltrHuiYuanXingMing0.Text = ltrYongHuXingMing1.Text = yongHuInfo.XingMing;            
            ltrYongHuLatestLoginTime.Text = yongHuInfo.LastLoginTime.Value.ToString("yyyy-MM-dd");

            var yongHuJiFenInfo = new EyouSoft.BLL.CompanyStructure.CompanyUser().GetYongHuJiFenInfo(yongHuInfo.YongHuId);
            if (yongHuJiFenInfo != null)
            {
                ltrYongHuKeYongJiFen.Text = yongHuJiFenInfo.KeYongJiFen.ToString();
                ltrYongHuDongJieJiFen.Text = yongHuJiFenInfo.DongJieJiFen.ToString();
            }
        }

        /// <summary>
        /// init hengfu
        /// </summary>
        void InitHengFu()
        {
            if (!IsXianShiHeFu)
            {
                phHeFu1.Visible = false;
                return;
            }

            int recordCount = 0;
            var chaXun = new EyouSoft.Model.PtStructure.MGuangGaoChaXunInfo();
            chaXun.WeiZhi = EyouSoft.Model.EnumType.PtStructure.GuangGaoWeiZhi.导航滚动横幅;
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.GuangGaoStatus.正常;
            var items = new EyouSoft.BLL.PtStructure.BGuangGao().GetGuangGaos(YuMingInfo.CompanyId, 9, 1, ref recordCount, chaXun);

            if (items == null || items.Count == 0)
            {
                phHeFuEmpty.Visible = true;
                phHeFu.Visible = false;
                return;
            }

            rptHeFu0.DataSource = rptHeFu1.DataSource = items;
            rptHeFu0.DataBind();
            rptHeFu1.DataBind();
        }
        #endregion
    }
}
