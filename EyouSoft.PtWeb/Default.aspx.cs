using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb
{
    public partial class _Default : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            InitCuXiao();
            InitZiXun();
            InitTuiJian();
        }

        #region private members
        /// <summary>
        /// init cuxiao
        /// </summary>
        void InitCuXiao()
        {
            int recordCount = 0;
            var chaXun=new EyouSoft.Model.PtStructure.MCuXiaoChaXunInfo();
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus.正常;
            var items = new EyouSoft.BLL.PtStructure.BCuXiao().GetCuXiaos(SysCompanyId, 6, 1, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptCuXiao.DataSource = items;
                rptCuXiao.DataBind();
            }

        }

        /// <summary>
        /// init zixun
        /// </summary>
        void InitZiXun()
        {
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.PtStructure.MZiXunChaXunInfo();
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.ZiXunStatus.正常;
            chaXun.LeiXing = EyouSoft.Model.EnumType.PtStructure.ZiXunLeiXing.平台资讯;

            var items = new EyouSoft.BLL.PtStructure.BZiXun().GetZiXuns(SysCompanyId, 9, 1, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptZiXun.DataSource = items;
                rptZiXun.DataBind();
            }
        }

        /// <summary>
        /// init tuijian
        /// </summary>
        void InitTuiJian()
        {
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.PtStructure.MTuiJianChaXunInfo();
            chaXun.Status = EyouSoft.Model.EnumType.PtStructure.TuiJianStatus.正常;

            var items = new EyouSoft.BLL.PtStructure.BTuiJian().GetTuiJians(SysCompanyId, 12, 1, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rptTuiJian.DataSource = items;
                rptTuiJian.DataBind();
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 促销时间
        /// </summary>
        /// <param name="shiJian1"></param>
        /// <param name="shiJian2"></param>
        /// <returns></returns>
        protected string GetCuXiaoShiJian(object shiJian1, object shiJian2)
        {
            var _shiJian1 = (DateTime)shiJian1;
            var _shiJian2 = (DateTime)shiJian2;

            if (_shiJian2 < DateTime.Today)
            {
                return "已结束";
            }

            return "活动时间："+_shiJian1.ToString("yyyy-MM-dd") + " 至 " + _shiJian2.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 促销封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetCuXiaoFengMian(object filepath)
        {
            string _filepath="/images/i_cx_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }

        /// <summary>
        /// 推荐封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetTuiJianFengMian(object filepath)
        {
            string _filepath = "/images/i_tj_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
