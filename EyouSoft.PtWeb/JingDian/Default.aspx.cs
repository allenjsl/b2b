using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.PtWeb.JingDian
{
    public partial class Default : QianTaiYeMian
    {
        #region attributes
        protected int recordCount = 0;
        protected int pageSize = 8;
        protected int pageIndex = 0;

        /// <summary>
        /// 查询区域编号
        /// </summary>
        int? ChaXunQuYuId;
        /// <summary>
        /// 查询关键字
        /// </summary>
        string ChaXunGuanJianZi = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ChaXunQuYuId = Utils.GetIntNull(Utils.GetQueryStringValue("qyid"));
            ChaXunGuanJianZi = Utils.GetQueryStringValue("searchkey");

            InitQuYu();
            InitJingDian();
        }

        #region private members
        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {            
            var items = new EyouSoft.BLL.PtStructure.BJingDian().GetJingDianQuYus(SysCompanyId);

            if (items == null || items.Count == 0) return;

            if (ChaXunQuYuId.HasValue&& ChaXunQuYuId.Value > 0)
            {
                int chaXunQuYuIndex = 0;

                for (var j = 0; j < items.Count; j++)
                {
                    if (items[j].QuYuId == ChaXunQuYuId.Value) { chaXunQuYuIndex = j; break; }
                }

                ChaXunQuYuId = items[chaXunQuYuIndex].QuYuId;

                if (chaXunQuYuIndex > 7)
                {
                    var item = items[chaXunQuYuIndex];
                    items.RemoveAt(chaXunQuYuIndex);
                    items.Insert(0, item);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ChaXunGuanJianZi)) ChaXunQuYuId = items[0].QuYuId;
            }

            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();

            int i = 0;
            foreach (var item in items)
            {
                if (i <= 7)
                {
                    string _class1 = "";
                    if (ChaXunQuYuId == item.QuYuId) _class1 = " class=\"active\" ";
                    string _class2 = "";

                    if (i == 7 || i == items.Count) _class2 = " class=\"noborder\" ";

                    s1.AppendFormat("<li {2}><a href=\"?qyid={0}\" {3}>{1}</a><i></i></li>", item.QuYuId, item.MingCheng, _class1, _class2);
                }

                s2.AppendFormat("<a href=\"?qyid={0}\">{1}</a>", item.QuYuId, item.MingCheng);

                i++;
            }

            ltrQuYu.Text = s1.ToString();
            ltrGengDuoQuYu.Text = s2.ToString();
        }

        /// <summary>
        /// init jingdian
        /// </summary>
        void InitJingDian()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            var chaXun = new EyouSoft.Model.PtStructure.MJingDianChaXunInfo();
            chaXun.JingDianQuYuId = ChaXunQuYuId;
            chaXun.MingCheng = Utils.GetQueryStringValue("searchkey");

            var items = new EyouSoft.BLL.PtStructure.BJingDian().GetJingDians(SysCompanyId, pageSize, pageIndex, ref recordCount, chaXun);
            if (items.Count > 0)
            {
                RepJingDian.DataSource = items;
                RepJingDian.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 景点封面
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        protected string GetJingDianFengMian(object filepath)
        {
            string _filepath = "/images/jinqu_no.gif";
            if (filepath != null && !string.IsNullOrEmpty(filepath.ToString())) _filepath = ErpUrl + filepath.ToString();
            return _filepath;
        }
        #endregion
    }
}
