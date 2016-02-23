using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台通知相关业务逻辑
    /// </summary>
    internal class BTongZhi
    {
        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="key">key</param>
        public static void RemoveCache(int companyId, string key)
        {
            if (companyId < 1 || string.IsNullOrEmpty(key)) return;

            var items = new EyouSoft.BLL.PtStructure.BPt().GetYuMings(companyId, EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing.同行平台);

            if (items == null || items.Count == 0) return;

            string url = "http://" + items[0].YuMing + "/ashx/handler.ashx";
            string data = "dotype=removecache&key=" + key;

            EyouSoft.Toolkit.request1.create(url, data, true);
        }
    }
}
