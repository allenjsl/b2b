using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.PtWeb.GuanYu
{
    public partial class LianXiFangShi : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            inteBind();
        }
        void inteBind()
        {
            var list = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(SysCompanyId, EyouSoft.Model.EnumType.PtStructure.KvKey.联系方式);
            lianxi.Text = list.V;
        }
    }
}
