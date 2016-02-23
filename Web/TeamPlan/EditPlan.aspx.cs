using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Collections.Generic;
using System.Text;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.TourStructure;

namespace Web.TeamPlan
{
    /// <summary>
    /// 控位新增、修改
    /// </summary>
    public partial class EditPlan : BackPage
    {
        #region attributes
        /// <summary>
        /// 线路区域编号
        /// </summary>
        protected string QuYuId = "";
        protected string QuJiaoTongId = string.Empty;
        protected string HuiJiaoTongId = string.Empty;
        protected int LeaveTrafficId = 0;
        protected int BackTrafficId = 0;
        private IList<MBaseKongWeiDaiLi> _setCustomList;

        /// <summary>
        /// 设置客户名单数据源
        /// </summary>
        private IList<MBaseKongWeiDaiLi> SetCustomList
        {
            get { return _setCustomList; }
            set { _setCustomList = value; }
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        bool Privs_Insert = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        bool Privs_Update = false;
        /// <summary>
        /// 控位编号
        /// </summary>
        string KongWeiId = string.Empty;
        /// <summary>
        /// 计划天数
        /// </summary>
        protected string TianShu = string.Empty;

        /// <summary>
        /// 控位编号集合
        /// </summary>
        IList<string> KongWeiIds = null;

        protected string CZFS = "INSERT";
        /// <summary>
        /// 去程出发地省份编号
        /// </summary>
        protected string QuChuFaDiShengFenId = string.Empty;
        /// <summary>
        /// 去程出发地城市编号
        /// </summary>
        protected string QuChuFaDiChengShiId = string.Empty;
        /// <summary>
        /// 去程目的地省份编号
        /// </summary>
        protected string QuMuDiDiShengFenId = string.Empty;
        /// <summary>
        /// 去程目的地城市编号
        /// </summary>
        protected string QuMuDiDiChengShiId = string.Empty;

        /// <summary>
        /// 回程出发地省份编号
        /// </summary>
        protected string HuiChuFaDiShengFenId = string.Empty;
        /// <summary>
        /// 回程出发地城市编号
        /// </summary>
        protected string HuiChuFaDiChengShiId = string.Empty;
        /// <summary>
        /// 回程目的地省份编号
        /// </summary>
        protected string HuiMuDiDiShengFenId = string.Empty;
        /// <summary>
        /// 回程目的地城市编号
        /// </summary>
        protected string HuiMuDiDiChengShiId = string.Empty;
        /// <summary>
        /// 专线商积分发放状态
        /// </summary>
        protected EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus ZxsJiFenStatus = EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            CZFS = Utils.GetQueryStringValue("czfs");

            if (string.IsNullOrEmpty(CZFS)) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求!"));

            CZFS = CZFS.ToUpper();
            if (CZFS != "INSERT" && CZFS != "UPDATE" && CZFS != "COPY") RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求!"));

            if (CZFS == "UPDATE" || CZFS == "COPY")
            {
                KongWeiIds = GetKongWeiIds();

                if (KongWeiIds == null || KongWeiIds.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求!"));
                KongWeiId = KongWeiIds[0];
            }

            if (CZFS == "UPDATE")
            {
                if (KongWeiIds.Count > 1)
                {
                    phBuTongBuDaiLiShang.Visible = true;
                    ltrPiLiangXiuGaiJiHuaWeiShuLiang.Text = KongWeiIds.Count.ToString();
                }
            }

            InitPrivs();

            switch (dotype)
            {
                case "save": Save(); break;
                default: break;
            }

            InitInfo();
            InitQuYu();
            InitCompanyQuYu();
            InitZxsJiFenStatus();

            InitBanCi();
        }

        #region private members
        /// <summary>
        /// 初始化表单
        /// </summary>
        void InitInfo()
        {
            RegisterScript(string.Format("var kongWeiCaoZuoFangShi='{0}';", CZFS));

            if (CZFS == "INSERT") return;
            if (string.IsNullOrEmpty(KongWeiId)) return;

            EyouSoft.BLL.TourStructure.BTour bll = new EyouSoft.BLL.TourStructure.BTour();
            EyouSoft.Model.TourStructure.MKongWei model = bll.GetKongWeiById(KongWeiId);

            if (model == null) RCWE("异常请求");

            this.txtBackBanci.Text = model.HuiBanCi;
            //this.txtBackTime.Text = model.HuiTime;
            this.txtGobanci.Text = model.QuBanCi;
            //this.txtGoTime.Text = model.QuTime;

            QuYuId = model.AreaId.ToString();
            QuJiaoTongId = model.QuJiaoTongId.ToString();
            HuiJiaoTongId = model.HuiJiaoTongId.ToString();

            QuChuFaDiShengFenId = model.QuDepProvinceId.ToString();
            QuChuFaDiChengShiId = model.QuDepCityId.ToString();
            QuMuDiDiShengFenId = model.QuArrProvinceId.ToString();
            QuMuDiDiChengShiId = model.QuArrCityId.ToString();

            HuiChuFaDiShengFenId = model.HuiDepProvinceId.ToString();
            HuiChuFaDiChengShiId = model.HuiDepCityId.ToString();
            HuiMuDiDiShengFenId = model.HuiArrProvinceId.ToString();
            HuiMuDiDiChengShiId = model.HuiArrCityId.ToString();
            txtTianShu.Value = model.TianShu.ToString();

            txtPingTaiShuLiang.Value = model.PingTaiShuLiang.ToString();

            if (model.KongWeiDaiLiList != null && model.KongWeiDaiLiList.Count > 0)
            {
                this.rptlist.DataSource = model.KongWeiDaiLiList;
                this.rptlist.DataBind();
                this.PHdefaultTr.Visible = false;
            }

            if (CZFS=="UPDATE" && model.KongWeiZhuangTai == EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束)
            {
                phOperatorHtml.Visible = false;
                ltrOperatorHtml.Text = "该控位已核算结束";
            }

            if (CZFS == "UPDATE")
            {
                var kongWeisRiQis = new EyouSoft.BLL.TourStructure.BTour().GetKongWeisRiQis(KongWeiIds);
                if (kongWeisRiQis != null && kongWeisRiQis.Count > 0)
                {
                    Newtonsoft.Json.Converters.IsoDateTimeConverter converter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
                    converter.DateTimeFormat = "yyyy-M-d";
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(kongWeisRiQis, converter);
                    string script = string.Format("var kongWeisRiQis={0};", json);
                    txtKongWeiRiQis.Value = json;
                    RegisterScript(script);
                }
            }

            if (CZFS == "UPDATE" || CZFS == "COPY")
            {
                var kongWeisXls = new EyouSoft.BLL.TourStructure.BTour().GetKongWeisXianLus(KongWeiIds);
                if (kongWeisXls != null && kongWeisXls.Count > 0)
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(kongWeisXls);
                    string script = string.Format("var kongWeisXls={0};", json);
                    RegisterScript(script);
                }
            }

            if (model.HangDuans != null && model.HangDuans.Count > 0)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model.HangDuans);
                string script = string.Format("var hangDuans={0};", json);

                RegisterScript(script);
            }
        }

        /// <summary>
        /// get form hangduans
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo> GetFormHangDuans()
        {
            IList<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo> items = new List<EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo>();

            string[] txt_hd_riqi = Utils.GetFormValues("txt_hd_riqi");
            string[] txt_hd_jiaotong = Utils.GetFormValues("txt_hd_jiaotong");
            string[] txt_hd_banci = Utils.GetFormValues("txt_hd_banci");
            string[] txt_hd_chufadi_shengfen = Utils.GetFormValues("txt_hd_chufadi_shengfen");
            string[] txt_hd_chufadi_chengshi = Utils.GetFormValues("txt_hd_chufadi_chengshi");
            string[] txt_hd_mudidi_shengfen = Utils.GetFormValues("txt_hd_mudidi_shengfen");
            string[] txt_hd_mudidi_chengshi = Utils.GetFormValues("txt_hd_mudidi_chengshi");
            string[] txt_hd_beizhu = Utils.GetFormValues("txt_hd_beizhu");

            int length = txt_hd_riqi.Length;

            if (length > 0
                && txt_hd_jiaotong.Length == length
                && txt_hd_banci.Length == length
                && txt_hd_chufadi_shengfen.Length == length
                && txt_hd_chufadi_chengshi.Length == length
                && txt_hd_mudidi_shengfen.Length == length
                && txt_hd_mudidi_shengfen.Length == length
                && txt_hd_mudidi_chengshi.Length == length
                && txt_hd_beizhu.Length == length)
            {
                for (var i = 0; i < length; i++)
                {
                    if (string.IsNullOrEmpty(txt_hd_riqi[i])
                        && string.IsNullOrEmpty(txt_hd_jiaotong[i])
                        && string.IsNullOrEmpty(txt_hd_banci[i])
                        && string.IsNullOrEmpty(txt_hd_chufadi_shengfen[i])
                        && string.IsNullOrEmpty(txt_hd_chufadi_chengshi[i])
                        && string.IsNullOrEmpty(txt_hd_mudidi_shengfen[i])
                        && string.IsNullOrEmpty(txt_hd_mudidi_chengshi[i])
                        && string.IsNullOrEmpty(txt_hd_beizhu[i])) continue;

                    var item = new EyouSoft.Model.TourStructure.MKongWeiHangDuanInfo();
                    item.RiQi = Utils.GetDateTime(txt_hd_riqi[i], DateTime.Now);
                    item.JiaoTongId = Utils.GetInt(txt_hd_jiaotong[i]);
                    item.BanCi = txt_hd_banci[i];
                    item.ChuFaShengFenId = Utils.GetInt(txt_hd_chufadi_shengfen[i]);
                    item.ChuFaChengShiId = Utils.GetInt(txt_hd_chufadi_chengshi[i]);
                    item.MuDiDiShengFenId = Utils.GetInt(txt_hd_mudidi_shengfen[i]);
                    item.MuDiDiChengShiId = Utils.GetInt(txt_hd_mudidi_chengshi[i]);
                    item.BeiZhu = txt_hd_beizhu[i];
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get form info
        /// </summary>
        /// <returns></returns>
        MKongWei GetFormInfo()
        {
            var info = new MKongWei();

            info.CompanyId = SiteUserInfo.CompanyId;
            info.KongWeiDaiLiList = GetDaiLis();
            info.AreaId = Utils.GetInt(Utils.GetFormValue("txtQuYu"));
            info.HuiArrCityId = Utils.GetInt(Utils.GetFormValue("txtHuiMuDiDiChengShi"));
            info.HuiArrProvinceId = Utils.GetInt(Utils.GetFormValue("txtHuiMuDiDiShengFen"));
            info.HuiBanCi = Utils.GetFormValue(this.txtBackBanci.UniqueID);
            info.HuiDepCityId = Utils.GetInt(Utils.GetFormValue("txtHuiChuFaDiChengShi"));
            info.HuiDepProvinceId = Utils.GetInt(Utils.GetFormValue("txtHuiChuFaDiShengFen"));
            //info.HuiTime = Utils.GetFormValue(this.txtBackTime.UniqueID); ;
            info.HuiJiaoTongId = Utils.GetInt(Utils.GetFormValue("txtHuiJiaoTongId"));
            info.OperatorId = SiteUserInfo.UserId;
            info.QuArrCityId = Utils.GetInt(Utils.GetFormValue("txtQuMuDiDiChengShi"));
            info.QuArrProvinceId = Utils.GetInt(Utils.GetFormValue("txtQuMuDiDiShengFen"));
            info.QuBanCi = Utils.GetFormValue(this.txtGobanci.UniqueID);
            info.QuDepCityId = Utils.GetInt(Utils.GetFormValue("txtQuChuFaDiChengShi"));
            info.QuDepProvinceId = Utils.GetInt(Utils.GetFormValue("txtQuChuFaDiShengFen"));
            info.QuJiaoTongId = Utils.GetInt(Utils.GetFormValue("txtQuJiaoTongId"));
            //info.QuTime = Utils.GetFormValue(this.txtGoTime.UniqueID);
            info.KongWeiType = EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游;
            info.KongWeiStatus = EyouSoft.Model.EnumType.TourStructure.KongWeiStatus.正常收客;

            info.ZxsId = CurrentZxsId;

            var quYuInfo = new EyouSoft.BLL.CompanyStructure.Area().GetModel(info.AreaId);
            if (quYuInfo != null)
            {
                info.ZhanDianId = quYuInfo.ZhanDianId;
                info.ZxlbId = quYuInfo.ZxlbId;
            }

            info.TianShu = Utils.GetInt(Utils.GetFormValue(txtTianShu.UniqueID));

            info.PingTaiShuLiang = Utils.GetInt(Utils.GetFormValue(txtPingTaiShuLiang.UniqueID));
            info.HangDuans = GetFormHangDuans();

            info.ShiFouXGDLS = !(Utils.GetFormValue("txtBuTongBuDaiLiShang") == "1");

            return info;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        void Save()
        {
            if (CZFS == "INSERT" || CZFS == "COPY")
            {
                if (!Privs_Insert) RCWE(UtilsCommons.AjaxReturnJson("0", "没有操作权限!"));
            }

            if (CZFS == "UPDATE")
            {
                if (!Privs_Update) RCWE(UtilsCommons.AjaxReturnJson("0", "没有操作权限!"));
            }

            EyouSoft.BLL.TourStructure.BTour bll = new EyouSoft.BLL.TourStructure.BTour();
            var model = GetFormInfo();

            if (model.TianShu < 0) RCWE(UtilsCommons.AjaxReturnJson("0", "天数不能小于0!"));

            string txtRiQi = Utils.GetFormValue("txtRiQi");

            if (CZFS=="INSERT"||CZFS=="COPY")
            {
                if (string.IsNullOrEmpty(txtRiQi)) RCWE(UtilsCommons.AjaxReturnJson("0", "请选择出团日期!"));
            }

            if (model.KongWeiDaiLiList == null || model.KongWeiDaiLiList.Count == 0)
            {
                RCWE( UtilsCommons.AjaxReturnJson("0", "请至少添加一条代理商信息!"));
            }

            if (CZFS == "INSERT" || CZFS == "COPY")
            {
                Insert(model);
            }

            if(CZFS=="UPDATE")
            {
                Update(model);
            }

            RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求!"));
        }

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="info"></param>
        void Insert(MKongWei info)
        {
            string txtRiQi = Utils.GetFormValue("txtRiQi");
            var riQis = txtRiQi.Split(',');
            int jishu = 0;
            info.MoBanId = Guid.NewGuid().ToString();
            var bll = new EyouSoft.BLL.TourStructure.BTour();

            var formXianLus = GetFormXianLus();

            var formDanDingPiaoInfo = GetFormDanDingPiaoInfo();

            foreach (var riQi in riQis)
            {
                info.QuDate = Utils.GetDateTime(riQi);
                info.HuiDate = info.QuDate.Value.AddDays(info.TianShu - 1);

                info.XianLus = GetXianLus(formXianLus, info.QuDate.Value);

                if (formDanDingPiaoInfo != null)
                {
                    if (info.XianLus == null) info.XianLus = new List<MKongWeiXianLuInfo>();
                    formDanDingPiaoInfo.XianLuId = string.Empty;
                    info.XianLus.Add(formDanDingPiaoInfo);
                }

                var bllRetCode = bll.AddKongWei(info);
                if (bllRetCode == 1) jishu++;
            }

            if (jishu > 0)
                RCWE(UtilsCommons.AjaxReturnJson("1", "成功新增" + jishu + "个计划位!"));
            else
                RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败!"));
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="info"></param>
        void Update(MKongWei info)
        {
            var bll = new EyouSoft.BLL.TourStructure.BTour();
            var kongWeiRiQis = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<EyouSoft.Model.TourStructure.MKongWeiRiQiInfo>>(Utils.GetFormValue(txtKongWeiRiQis.UniqueID));

            if (kongWeiRiQis == null || kongWeiRiQis.Count == 0) RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求!"));
            var formXianLus = GetFormXianLus();
            var formDanDingPiaoInfo = GetFormDanDingPiaoInfo();

            int jishu = 0;
            foreach (var item in kongWeiRiQis)
            {
                info.KongWeiId = item.KongWeiId;
                info.QuDate = item.QuDate;
                info.HuiDate = item.QuDate.AddDays(info.TianShu - 1);

                info.XianLus = GetXianLus(formXianLus, info.QuDate.Value);
                if (formDanDingPiaoInfo != null)
                {
                    if (info.XianLus == null) info.XianLus = new List<MKongWeiXianLuInfo>();
                    formDanDingPiaoInfo.XianLuId = string.Empty;
                    info.XianLus.Add(formDanDingPiaoInfo);
                }

                var bllRetCode = bll.UpdateKongWeid(info);
                if (bllRetCode == 1) jishu++;
            }

            if (jishu > 0)
                RCWE(UtilsCommons.AjaxReturnJson("1", "成功修改" + jishu + "个计划位!"));
            else
                RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败!"));
        }

        /// <summary>
        /// 获取代理商信息数据
        /// </summary>
        /// <returns></returns>
        IList<MBaseKongWeiDaiLi> GetDaiLis()
        {
            string[] Id = Utils.GetFormValues("ShowID");
            string[] Name = Utils.GetFormValues("SourceName");
            string[] OrderNum = Utils.GetFormValues("txtOrderNum");
            string[] ContactName = Utils.GetFormValues("txtContactName");
            string[] ContactTel = Utils.GetFormValues("txtContactTel");
            string[] Price = Utils.GetFormValues("txtPrice");
            string[] Count = Utils.GetFormValues("txtCount");
            string[] TimeLemit = Utils.GetFormValues("txtTimeLemit");
            string[] remark = Utils.GetFormValues("txtremark");
            string[] dailiId = Utils.GetFormValues("hidDaiLiId");
            string[] txtMoBanId = Utils.GetFormValues("txtMoBanId");
            IList<MBaseKongWeiDaiLi> list = new List<MBaseKongWeiDaiLi>();

            if (Name.Length == 0) return null;

            for (int i = 0; i < Name.Length; i++)
            {
                if (string.IsNullOrEmpty(Name[i]) || string.IsNullOrEmpty(Count[i])) continue;
                var model = new MBaseKongWeiDaiLi();

                model.CompanyId = this.SiteUserInfo.CompanyId;
                model.GysId = Id[i].ToString();
                model.GysName = Name[i].ToString();
                model.GysOrderCode = OrderNum[i].ToString();
                model.LxrName = ContactName[i].ToString();
                model.LxrTelephone = ContactTel[i].ToString();
                model.Price = Utils.GetDecimal(Price[i].ToString());
                model.Remark = remark[i].ToString();
                model.ShiXian = TimeLemit[i].ToString();
                model.ShuLiang = Utils.GetInt(Count[i].ToString());
                if (model.ShuLiang < 0) model.ShuLiang = 0;
                model.MoBanId = txtMoBanId[i];
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// init privs
        /// </summary>
        void InitPrivs()
        {
            Privs_Insert = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_新增);
            Privs_Update = CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.收客计划_常规业务_修改);

            if (string.IsNullOrEmpty(KongWeiId)) this.btn.Visible = Privs_Insert;
            else this.btn.Visible = Privs_Update;
        }

        /// <summary>
        /// init quyu
        /// </summary>
        void InitQuYu()
        {
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetZxsZhanDians(CurrentZxsId);

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<option value=\"\">请选择</option>");

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    foreach (var item1 in item.Zxlbs)
                    {
                        s.AppendFormat("<optgroup label=\"{0}\">", item.ZhanDianName + "站-" + item1.ZxlbName);

                        foreach (var item2 in item1.QuYus)
                        {
                            s.AppendFormat("<option value=\"{0}\">{1}</option>", item2.QuYuId, item2.QuYuName);
                        }

                        s.AppendFormat("</optgroup>");
                    }
                }
            }

            ltrQuYuOption.Text = s.ToString();
        }

        /// <summary>
        /// get kongweiids
        /// </summary>
        /// <returns></returns>
        IList<string> GetKongWeiIds()
        {
            IList<string> items = new List<string>();

            string s = Utils.GetQueryStringValue("kongweiids");
            if (string.IsNullOrEmpty(s)) return null;

            var items1 = s.Split(',');

            if (items1 == null || items1.Length == 0) return null;
            foreach (var item1 in items1)
            {
                if (string.IsNullOrEmpty(item1)) continue;
                items.Add(item1);
            }

            if (items.Count == 0) return null;

            return items;
        }

        /// <summary>
        /// get form xianlus
        /// </summary>
        /// <returns></returns>
        IList<MFormXianLuInfo> GetFormXianLus()
        {
            IList<MFormXianLuInfo> items = new List<MFormXianLuInfo>();
            var txt_xl_riqi = Utils.GetFormValues("txt_xl_riqi");
            var txt_xl_routeid = Utils.GetFormValues("txt_xl_routeid");
            var txt_xl_routename = Utils.GetFormValues("txt_xl_routename");
            var txt_xl_menshijiage1 = Utils.GetFormValues("txt_xl_menshijiage1");
            var txt_xl_menshijiage2 = Utils.GetFormValues("txt_xl_menshijiage2");
            var txt_xl_menshijiage3 = Utils.GetFormValues("txt_xl_menshijiage3");
            var txt_xl_jiesuanjiage1 = Utils.GetFormValues("txt_xl_jiesuanjiage1");
            var txt_xl_jiesuanjiage2 = Utils.GetFormValues("txt_xl_jiesuanjiage2");
            var txt_xl_jiesuanjiage3 = Utils.GetFormValues("txt_xl_jiesuanjiage3");
            var txt_xl_quanpeijiage = Utils.GetFormValues("txt_xl_quanpeijiage");
            var txt_xl_bufangchajiage = Utils.GetFormValues("txt_xl_bufangchajiage");
            var txt_xl_tuifangchajiage = Utils.GetFormValues("txt_xl_tuifangchajiage");
            var txt_xl_jifen = Utils.GetFormValues("txt_xl_jifen");
            var txt_xl_status = Utils.GetFormValues("txt_xl_status");
            var txt_xl_paixuid = Utils.GetFormValues("txt_xl_paixuid");
            var txt_xl_xingdingrenshu = Utils.GetFormValues("txt_xl_xiandingrenshu");
            var txt_xl_zuixiaorenshu = Utils.GetFormValues("txt_xl_zuixiaorenshu");

            int length = txt_xl_riqi.Length;

            if (length == 0 || txt_xl_routeid.Length != length || txt_xl_routename.Length != length || txt_xl_menshijiage1.Length != length || txt_xl_menshijiage2.Length != length || txt_xl_menshijiage3.Length != length || txt_xl_jiesuanjiage1.Length != length || txt_xl_jiesuanjiage2.Length != length || txt_xl_jiesuanjiage3.Length != length || txt_xl_quanpeijiage.Length != length || txt_xl_bufangchajiage.Length != length || txt_xl_tuifangchajiage.Length != length || txt_xl_jifen.Length != length || txt_xl_status.Length != length || txt_xl_paixuid.Length != length) return null;

            for (int i = 0; i < length; i++)
            {
                if (string.IsNullOrEmpty(txt_xl_routeid[i]) || string.IsNullOrEmpty(txt_xl_riqi[i])) continue;
                var riqis = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<DateTime>>(txt_xl_riqi[i]);
                if (riqis == null || riqis.Count == 0) continue;

                var item = new MFormXianLuInfo();

                item.BuFangChaJiaGe = Utils.GetDecimal(txt_xl_bufangchajiage[i]);
                item.JieSuanJiaGe1 = Utils.GetDecimal(txt_xl_jiesuanjiage1[i]);
                item.JieSuanJiaGe2 = Utils.GetDecimal(txt_xl_jiesuanjiage2[i]);
                item.JieSuanJiaGe3 = Utils.GetDecimal(txt_xl_jiesuanjiage3[i]);
                item.JiFen = Utils.GetInt(txt_xl_jifen[i]);
                item.MenShiJiaGe1 = Utils.GetDecimal(txt_xl_menshijiage1[i]);
                item.MenShiJiaGe2 = Utils.GetDecimal(txt_xl_menshijiage2[i]);
                item.MenShiJiaGe3 = Utils.GetDecimal(txt_xl_menshijiage3[i]);
                item.PaiXuId = Utils.GetInt(txt_xl_paixuid[i]);
                item.QuanPeiJiaGe = Utils.GetDecimal(txt_xl_quanpeijiage[i]);
                item.RiQis = riqis;
                item.RouteId = txt_xl_routeid[i];
                item.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus>(txt_xl_status[i], EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus.正常销售);
                item.TuiFangChaJiaGe = Utils.GetDecimal(txt_xl_tuifangchajiage[i]);
                item.XianDingRenShu = Utils.GetInt(txt_xl_xingdingrenshu[i]);
                item.ZuiXiaoRenShu = Utils.GetInt(txt_xl_zuixiaorenshu[i]);

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// get form dandingpiao info
        /// </summary>
        /// <returns></returns>
        MKongWeiXianLuInfo GetFormDanDingPiaoInfo()
        {
            MKongWeiXianLuInfo info = new MKongWeiXianLuInfo();

            info.BuFangChaJiaGe = 0;
            info.JieSuanJiaGe1 = Utils.GetDecimal(Utils.GetFormValue("txt_ddp_jiesuanjiage1"));
            info.JieSuanJiaGe2 = Utils.GetDecimal(Utils.GetFormValue("txt_ddp_jiesuanjiage2"));
            info.JieSuanJiaGe3 = Utils.GetDecimal(Utils.GetFormValue("txt_ddp_jiesuanjiage3"));
            info.JiFen = 0;
            info.KongWeiId = string.Empty;
            info.LeiXing = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票;
            info.MenShiJiaGe1 = Utils.GetDecimal(Utils.GetFormValue("txt_ddp_menshijiage1"));
            info.MenShiJiaGe2 = Utils.GetDecimal(Utils.GetFormValue("txt_ddp_menshijiage2"));
            info.MenShiJiaGe3 = Utils.GetDecimal(Utils.GetFormValue("txt_ddp_menshijiage3"));
            info.PaiXuId = 9999;
            info.QuanPeiJiaGe = 0;
            info.RouteId = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
            //info.Status = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus.正常销售;
            info.TuiFangChaJiaGe = 0;
            info.XianLuCode = string.Empty;
            info.XianLuId = string.Empty;
            info.Status = Utils.GetEnumValue<EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus>(Utils.GetFormValue("txt_ddp_status"), EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus.正常销售);

            if (info.JieSuanJiaGe1 <= 0) return null;

            return info;
        }


        /// <summary>
        /// get xianlus
        /// </summary>
        /// <param name="formXianLus"></param>
        /// <param name="riqi"></param>
        /// <returns></returns>
        IList<MKongWeiXianLuInfo> GetXianLus(IList<MFormXianLuInfo> formXianLus, DateTime riqi)
        {
            if (formXianLus == null || formXianLus.Count == 0) return null;
            IList<MKongWeiXianLuInfo> items = new List<MKongWeiXianLuInfo>();

            foreach (var formXianLu in formXianLus)
            {
                if (!formXianLu.RiQis.Contains(riqi)) continue;

                var item = new MKongWeiXianLuInfo();
                item.BuFangChaJiaGe = formXianLu.BuFangChaJiaGe;
                item.JieSuanJiaGe1 = formXianLu.JieSuanJiaGe1;
                item.JieSuanJiaGe2 = formXianLu.JieSuanJiaGe2;
                item.JieSuanJiaGe3 = formXianLu.JieSuanJiaGe3;
                item.JiFen = formXianLu.JiFen;
                item.KongWeiId = string.Empty;
                item.LeiXing = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.线路;
                item.MenShiJiaGe1 = formXianLu.MenShiJiaGe1;
                item.MenShiJiaGe2 = formXianLu.MenShiJiaGe2;
                item.MenShiJiaGe3 = formXianLu.MenShiJiaGe3;
                item.PaiXuId = formXianLu.PaiXuId;
                item.QuanPeiJiaGe = formXianLu.QuanPeiJiaGe;
                item.RouteId = formXianLu.RouteId;
                item.Status = formXianLu.Status;
                item.TuiFangChaJiaGe = formXianLu.TuiFangChaJiaGe;
                item.XianLuCode = string.Empty;
                item.XianLuId = string.Empty;
                item.XianDingRenShu = formXianLu.XianDingRenShu;
                item.ZuiXiaoRenShu = formXianLu.ZuiXiaoRenShu;

                items.Add(item);
            }

            return items;
        }

        /// <summary>
        /// init company quyu
        /// </summary>
        void InitCompanyQuYu()
        {
            var script = "var zxsQuYu={0};";
            var items = new EyouSoft.BLL.CompanyStructure.Area().GetQuYusByZxsId(CurrentZxsId);

            if (items != null && items.Count > 0)
            {
                script = string.Format(script, Newtonsoft.Json.JsonConvert.SerializeObject(items));
            }
            else
            {
                script = string.Format(script, "[]");
            }

            RegisterScript(script);
        }

        /// <summary>
        /// init zxs jifenstatus
        /// </summary>
        void InitZxsJiFenStatus()
        {
            ZxsJiFenStatus = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetZxsJiFenStatus(CurrentZxsId);
        }

        /// <summary>
        /// init banci
        /// </summary>
        void InitBanCi()
        {
            var quBanCi = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次, null, CurrentZxsId);
            var huiBanCi = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程班次, null, CurrentZxsId);

            var output1 = string.Format("var quBanCi={0};", Newtonsoft.Json.JsonConvert.SerializeObject(quBanCi));
            var output2 = string.Format("var huiBanCi={0};", Newtonsoft.Json.JsonConvert.SerializeObject(huiBanCi));

            RegisterScript(output1 + output2);
        }
        #endregion

        #region protected members
        /// <summary>
        /// get jiaotong options
        /// </summary>
        /// <returns></returns>
        protected string GetJiaoTongOptions()
        {
            EyouSoft.BLL.CompanyStructure.BCompanyTraffic blltraffic = new EyouSoft.BLL.CompanyStructure.BCompanyTraffic();
            IList<CompanyTraffic> list = blltraffic.GetList(this.SiteUserInfo.CompanyId);
            StringBuilder str = new StringBuilder();
            str.Append("<option value=''>请选择</option>");
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    str.AppendFormat("<option value='{0}'>{1}</option>", list[i].TrafficId.ToString(), list[i].TrafficName);
                }
            }
            return str.ToString();
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
        }

        /// <summary>
        /// 获取基础信息下拉菜单项
        /// </summary>
        /// <returns></returns>
        protected string GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType jiChuXinXiType)
        {
            StringBuilder s = new StringBuilder();

            s.Append("<option value=\"\">请选择</options>");
            var items = new EyouSoft.BLL.CompanyStructure.BJiChuXinXi().GetJiChuXinXis(CurrentUserCompanyID, jiChuXinXiType, null, CurrentZxsId);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    s.AppendFormat("<option value=\"{0}\">{0}</options>", item.Name);
                }
            }

            return s.ToString();
        }
        #endregion
    }

    #region form xianlu info
    /// <summary>
    /// form xianlu info
    /// </summary>
    public class MFormXianLuInfo
    {
        /// <summary>
        /// 线路编号
        /// </summary>
        public string RouteId { get; set; }
        /// <summary>
        /// 门市成人价
        /// </summary>
        public decimal MenShiJiaGe1 { get; set; }
        /// <summary>
        /// 门市儿童价
        /// </summary>
        public decimal MenShiJiaGe2 { get; set; }
        /// <summary>
        /// 门市婴儿价
        /// </summary>
        public decimal MenShiJiaGe3 { get; set; }
        /// <summary>
        /// 结算成人价
        /// </summary>
        public decimal JieSuanJiaGe1 { get; set; }
        /// <summary>
        /// 结算儿童价
        /// </summary>
        public decimal JieSuanJiaGe2 { get; set; }
        /// <summary>
        /// 结算婴儿价
        /// </summary>
        public decimal JieSuanJiaGe3 { get; set; }
        /// <summary>
        /// 全陪价
        /// </summary>
        public decimal QuanPeiJiaGe { get; set; }
        /// <summary>
        /// 补房差价
        /// </summary>
        public decimal BuFangChaJiaGe { get; set; }
        /// <summary>
        /// 退房差价
        /// </summary>
        public decimal TuiFangChaJiaGe { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int JiFen { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus Status { get; set; }
        /// <summary>
        /// 日期集合
        /// </summary>
        public IList<DateTime> RiQis { get; set; }
        /// <summary>
        /// 限定人数（最大）
        /// </summary>
        public int XianDingRenShu { get; set; }
        /// <summary>
        /// 限定人数（最小）
        /// </summary>
        public int ZuiXiaoRenShu { get; set; }
    }
    #endregion
}
