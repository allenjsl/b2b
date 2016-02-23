//找回密码 汪奇志 2014-09-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.PtWeb
{
    /// <summary>
    /// 找回密码
    /// </summary>
    public partial class ZhaoHuiMiMa : QianTaiYeMian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "step1": Step1(); break;
                case "step2": Step2(); break;
                case "step3": Step3(); break;
            }
        }

        #region private members
        /// <summary>
        /// step1
        /// </summary>
        void Step1()
        {
            var info = new MAjaxZhaoHuiMiMaInfo();
            string txtYongHuMing = Utils.GetFormValue("txtYongHuMing");

            if (string.IsNullOrEmpty(txtYongHuMing))
            {
                info.RetCode = 0;
                info.XiaoXi = "请输入用户名或邮箱";

                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }

            string yanZhengMaId,youXiang;
            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().PT_YongHu_ZhaoHuiMiMa_FaSongYanZhengMa(SysCompanyId, txtYongHuMing, out yanZhengMaId, out youXiang);

            if (bllRetCode == 1)
            {
                info.RetCode = 1;
                info.XiaoXi = "已发送验证码至邮箱";
                info.YanZhengMaId = yanZhengMaId;
                info.YouXiang = youXiang;

                var s = info.YouXiang.Split('@');
                if (s[0].Length <= 4) info.YouXiang = s[0].Substring(0, 1) + "*****@" + s[1];
                else info.YouXiang = s[0].Substring(0, 1) + "*****" + s[0].Substring(s[0].Length - 1) + "@" + s[1];

                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }
            else if (bllRetCode == 0 || bllRetCode == -1)
            {
                info.RetCode = 0;
                info.XiaoXi = "不存在的用户名或邮箱，请重新输入";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }
            else if (bllRetCode == -2 || bllRetCode == -3)
            {
                info.RetCode = 0;
                info.XiaoXi = "你的用户名未绑定邮箱，请联系网站客服";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }
            else
            {
                info.RetCode = 0;
                info.XiaoXi = "找回密码错误，请联系网站客服";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }
        }

        /// <summary>
        /// step2
        /// </summary>
        void Step2()
        {
            var info = new MAjaxZhaoHuiMiMaInfo();
            string txtYanZhengMaId = Utils.GetFormValue("txtYanZhengMaId");
            string txtYanZhengMa = Utils.GetFormValue("txtYanZhengMa");

            if (string.IsNullOrEmpty(txtYanZhengMaId) || string.IsNullOrEmpty(txtYanZhengMa))
            {
                info.RetCode = 0;
                info.XiaoXi = "请输入正确的验证码";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }

            var yzmInfo = new EyouSoft.BLL.PtStructure.BYanZhengMa().GetInfo(txtYanZhengMaId, txtYanZhengMa, EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing.找回密码);
            if (yzmInfo == null)
            {
                info.RetCode = 0;
                info.XiaoXi = "请输入正确的验证码";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }

            if (yzmInfo.Status1 != EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.有效)
            {
                info.RetCode = 0;
                info.XiaoXi = "您输入的验证码已过期，请重新获取验证码";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }

            info.RetCode = 1;
            info.XiaoXi = "验证码验证成功";
            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));

        }

        /// <summary>
        /// step3
        /// </summary>
        void Step3()
        {
            var info = new MAjaxZhaoHuiMiMaInfo();
            string txtYanZhengMaId = Utils.GetFormValue("txtYanZhengMaId");
            string txtYanZhengMa = Utils.GetFormValue("txtYanZhengMa");
            string txtMiMa1 = Utils.GetFormValue("txtMiMa1");
            string txtMiMa2 = Utils.GetFormValue("txtMiMa2");

            if (string.IsNullOrEmpty(txtYanZhengMaId) || string.IsNullOrEmpty(txtYanZhengMa))
            {
                info.RetCode = 0;
                info.XiaoXi = "请输入正确的验证码";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }

            if (string.IsNullOrEmpty(txtMiMa1) || txtMiMa1 != txtMiMa2)
            {
                info.RetCode = 0;
                info.XiaoXi = "两次输入的密码不一致，请重新输入";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }

            int bllRetCode = new EyouSoft.BLL.CompanyStructure.CompanyUser().PT_YongHu_ZhaoHuiMiMa_XiuGaiMiMa(SysCompanyId, txtYanZhengMaId, txtYanZhengMa, txtMiMa1);

            if (bllRetCode == 1)
            {
                info.RetCode = 1;
                info.XiaoXi = "密码修改成功";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }
            else
            {
                info.RetCode = 0;
                info.XiaoXi = "找回密码失败，请重试";
                Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(info));
            }
        }
        #endregion

        #region 找回密码返回信息业务实体
        /// <summary>
        /// 找回密码返回信息业务实体
        /// </summary>
        class MAjaxZhaoHuiMiMaInfo
        {
            /// <summary>
            /// default constructor
            /// </summary>
            public MAjaxZhaoHuiMiMaInfo()
            {
                this.RetCode = 0;
                this.XiaoXi = string.Empty;
                this.YouXiang = string.Empty;
                this.YanZhengMaId = string.Empty;
            }

            /// <summary>
            /// 返回值
            /// </summary>
            public int RetCode { get; set; }
            /// <summary>
            /// 消息
            /// </summary>
            public string XiaoXi { get; set; }
            /// <summary>
            /// 邮箱
            /// </summary>
            public string YouXiang { get; set; }
            /// <summary>
            /// 验证码编号
            /// </summary>
            public string YanZhengMaId { get; set; }
        }
        #endregion
    }
}
