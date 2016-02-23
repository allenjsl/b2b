using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TourStructure
{
    #region 代理商信息
    /// <summary>
    /// 代理商信息
    /// </summary>
    public class MBaseKongWeiDaiLi
    {

        /// <summary>
        /// 代理编号
        /// </summary>
        public string DaiLiId { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }

        /// <summary>
        /// 订单号或编号
        /// </summary>
        public string GysOrderCode { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string LxrName { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrTelephone { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int ShuLiang { get; set; }

        /// <summary>
        /// 出票时限
        /// </summary>
        public string ShiXian { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 已出票数量
        /// </summary>
        public int YiChuPiaoShuLiang { get; set; }
        /// <summary>
        /// 代理商模板编号
        /// </summary>
        public string MoBanId { get; set; }
    }
    #endregion

    #region 代理商详细实体
    /// <summary>
    /// 代理商详细实体
    /// </summary>
    public class MKongWeiDaiLi : MBaseKongWeiDaiLi
    {
        /// <summary>
        /// 押金金额
        /// </summary>
        public decimal YaJinAmount { get; set; }

        /// <summary>
        /// 押金备注
        /// </summary>
        public string YaJinBeiZhu { get; set; }

        /// <summary>
        /// 押金操作人编号
        /// </summary>
        public int YaJinOperatorId { get; set; }

        /// <summary>
        /// 押金退回来的金额
        /// </summary>
        public decimal TuiYaJinAmount { get; set; }

        /// <summary>
        /// 押金退回来的备注
        /// </summary>
        public string TuiYaJinBeiZhu { get; set; }

        /// <summary>
        /// 退回来的时间
        /// </summary>
        public DateTime? TuiTime { get; set; }

        /// <summary>
        /// 押金退回来操作人编号
        /// </summary>
        public int TuiYaJinOperatorId { get; set; }
    }
    #endregion

    #region 控位信息
    /// <summary>
    /// 控位信息
    /// </summary>
    public class MKongWei
    {
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 控位类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType? KongWeiType { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 控位数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 控位收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiStatus? KongWeiStatus { get; set; }
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 去程日期
        /// </summary>
        public DateTime? QuDate { get; set; }
        /// <summary>
        /// 去程交通编号
        /// </summary>
        public int QuJiaoTongId { get; set; }
        /// <summary>
        /// 去程出发省市编号
        /// </summary>
        public int QuDepProvinceId { get; set; }
        /// <summary>
        /// 去程出发城市编号
        /// </summary>
        public int QuDepCityId { get; set; }
        /// <summary>
        /// 去程到达省份编号
        /// </summary>
        public int QuArrProvinceId { get; set; }
        /// <summary>
        /// 去程到达城市编号
        /// </summary>
        public int QuArrCityId { get; set; }
        /// <summary>
        /// 去程班次
        /// </summary>
        public string QuBanCi { get; set; }
        /// <summary>
        /// 去程时间
        /// </summary>
        public string QuTime { get; set; }
        /// <summary>
        /// 回程时间
        /// </summary>
        public DateTime? HuiDate { get; set; }
        /// <summary>
        /// 回程交通编号
        /// </summary>
        public int HuiJiaoTongId { get; set; }
        /// <summary>
        /// 回程出发省份编号
        /// </summary>
        public int HuiDepProvinceId { get; set; }
        /// <summary>
        /// 回程出发城市编号
        /// </summary>
        public int HuiDepCityId { get; set; }
        /// <summary>
        /// 回程到达省份编号
        /// </summary>
        public int HuiArrProvinceId { get; set; }
        /// <summary>
        /// 回程到达城市编号
        /// </summary>
        public int HuiArrCityId { get; set; }
        /// <summary>
        /// 回程班次
        /// </summary>
        public string HuiBanCi { get; set; }
        /// <summary>
        /// 回程时间
        /// </summary>
        public string HuiTime { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 控位状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai KongWeiZhuangTai { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public int TianShu { get; set; }
        /// <summary>
        /// 模板编号
        /// </summary>
        public string MoBanId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 站点编号
        /// </summary>
        public int ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int ZxlbId { get; set; }
        /// <summary>
        /// 控位线路产品集合
        /// </summary>
        public IList<MKongWeiXianLuInfo> XianLus { get; set; }
        /// <summary>
        /// 批次代码
        /// </summary>
        public string PiCiCode { get; set; }

        /// <summary>
        /// 去程交通名称
        /// </summary>
        public string QuJiaoTongName { get; set; }
        /// <summary>
        /// 去程出发地-省份名称
        /// </summary>
        public string QuChuFaDiShengFenName { get; set; }
        /// <summary>
        /// 去程出发地-城市名称
        /// </summary>
        public string QuDepCityName { get; set; }
        /// <summary>
        /// 去程目的地-省份名称
        /// </summary>
        public string QuMuDiDiShengFenName { get; set; }
        /// <summary>
        /// 去程目的地-城市名称
        /// </summary>
        public string QuArrCityName { get; set; }

        /// <summary>
        /// 回程交通名称
        /// </summary>
        public string HuiJiaoTongName { get; set; }
        /// <summary>
        /// 回程出发地-省份名称
        /// </summary>
        public string HuiChuFaDiShengFenName { get; set; }
        /// <summary>
        /// 回程出发地-城市名称
        /// </summary>
        public string HuiDepCityName { get; set; }
        /// <summary>
        /// 回程目的地-省份名称
        /// </summary>
        public string HuiMuDiDiShengFenName { get; set; }
        /// <summary>
        /// 回程目的地-城市名称
        /// </summary>
        public string HuiArrCityName { get; set; }

        /// <summary>
        /// 代理商信息的集合
        /// </summary>
        public IList<MBaseKongWeiDaiLi> KongWeiDaiLiList { get; set; }

        /// <summary>
        /// 平台控位数量(控制同行平台对外展示的控位数)
        /// </summary>
        public int PingTaiShuLiang { get; set; }
        /// <summary>
        /// 平台控位收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus PingTaiShouKeStatus { get; set; }
        /// <summary>
        /// 航段信息集合
        /// </summary>
        public IList<MKongWeiHangDuanInfo> HangDuans { get; set; }
        /// <summary>
        /// 有效收客人数（有效订单[未确认、已留位、已成交、名单不全]的成人+儿童+婴儿+全陪）
        /// </summary>
        public int YouXiaoShouKeRenShu { get; set; }
        /// <summary>
        /// 是否修改代理商及平台数量信息（仅用于修改控位，其它情况无意义）
        /// </summary>
        public bool ShiFouXGDLS { get; set; }
        /// <summary>
        /// 控位显示状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus XianShiStatus { get; set; }
    }
    #endregion

    #region 列表展示的控位信息
    /// <summary>
    /// 列表展示的控位信息
    /// </summary>
    public class MPageKongWei : MKongWei
    {
        /// <summary>
        /// 线路区域名称
        /// </summary>
        public string AreaName { get; set; }        
        /// <summary>
        /// 控位实收数量
        /// </summary>
        public int ShiShouShuLiang { get; set; }
        /// <summary>
        /// 预留数量
        /// </summary>
        public int YuLiuShuLiang { get; set; }
        /// <summary>
        /// 出票安排实际出票数量
        /// </summary>
        public int ShiJiChuPiaoShuLiang { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int ShengYuShuLiang
        {
            get
            {
                if (ShiJiChuPiaoShuLiang > ShiShouShuLiang + YuLiuShuLiang + MingDanBuQuanShuLiang + WeiQueRenShuLiang) return ShuLiang - ShiJiChuPiaoShuLiang;

                return ShuLiang - ShiShouShuLiang - YuLiuShuLiang - MingDanBuQuanShuLiang - WeiQueRenShuLiang;
            }
        }
        /// <summary>
        /// 名单不全数量
        /// </summary>
        public int MingDanBuQuanShuLiang { get; set; }
        /// <summary>
        /// 未确认数量
        /// </summary>
        public int WeiQueRenShuLiang { get; set; }
        /// <summary>
        /// 申请数量
        /// </summary>
        public int ShenQingShuLiang { get; set; }
    }
    #endregion

    #region 控位搜索的实体类
    /// <summary>
    /// 控位搜索的实体类
    /// </summary>
    public class MSearchKongWei
    {
        /// <summary>
        /// 出团开始时间
        /// </summary>
        public DateTime? LBeginDate { get; set; }
        /// <summary>
        /// 出团结束时间
        /// </summary>
        public DateTime? LEndDate { get; set; }
        /// <summary>
        /// 控位号
        /// </summary>
        public string KongWeiCode { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单号或编码 
        /// </summary>
        public string GysOrderCode { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string BuyCompanyName { get; set; }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string TravellerName { get; set; }
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int? AreaId { get; set; }
        /// <summary>
        /// 去程交通
        /// </summary>
        public int? QuJiaoTongId { get; set; }
        /// <summary>
        /// 去程出发地省份
        /// </summary>
        public int? QuDepProvinceId { get; set; }
        /// <summary>
        /// 去程出发地城市 
        /// </summary>
        public int? QuDepCityId { get; set; }
        /// <summary>
        /// 去程目的地省份
        /// </summary>
        public int? QuArrProvinceId { get; set; }
        /// <summary>
        /// 去程目的地城市 
        /// </summary>
        public int? QuArrCityId { get; set; }
        /// <summary>
        /// 控位状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai? KongWeiZhuangTai { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 批次代码
        /// </summary>
        public string PiCiCode { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.OrderStatus? DingDanStatus { get; set; }
        /// <summary>
        /// 线路产品代码
        /// </summary>
        public string XianLuCode { get; set; }
        /// <summary>
        /// 收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiStatus? ShouKeStatus { get; set; }
        /// <summary>
        /// 平台收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus? PingTaiShouKeStatus { get; set; }
        /// <summary>
        /// 控位显示状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus? XianShiStatus { get; set; }
    }
    #endregion

    #region 控位操作备注信息业务实体
    /// <summary>
    /// 控位操作备注信息业务实体
    /// </summary>
    public class MKongWeiBeiZhuInfo
    {
        /// <summary>
        /// 操作备注编号
        /// </summary>
        public string BeiZhuId { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 备注内容
        /// </summary>
        public string NeiRong { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 最后操作人编号
        /// </summary>
        public int LatestOperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 最后操作人姓名
        /// </summary>
        public string LatestOperatorName { get; set; }
        /// <summary>
        /// 状态 0:有效 1:失效
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// 操作备注查询实体
    /// </summary>
    public class MKongWeiBeiZhuChaXunInfo
    {
        /// <summary>
        /// 状态 0：有效 1：失效
        /// </summary>
        public int? Status { get; set; }
    }
    #endregion

    #region 控位线路信息业务实体
    /// <summary>
    /// 控位线路产品信息业务实体
    /// </summary>
    public class MKongWeiXianLuInfo
    {
        /// <summary>
        /// 控位线路产品编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 线路产品类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing LeiXing { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
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
        /// 线路产品代码
        /// </summary>
        public string XianLuCode { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int PaiXuId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus Status { get; set; }
        /// <summary>
        /// 线路名称(OUTPUT)
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 专线商编号（OUTPUT）
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 限定人数（最大）0不限定 （总人数）大于指定人数的下单订单状态为申请中
        /// </summary>
        public int XianDingRenShu { get; set; }
        /// <summary>
        /// 限定人数（最小）0不限定 （成人数）小于指定人数的单订单状态为申请中
        /// </summary>
        public int ZuiXiaoRenShu { get; set; }
    }
    #endregion

    #region 控位日期信息业务实体
    /// <summary>
    /// 控位日期信息业务实体
    /// </summary>
    public class MKongWeiRiQiInfo
    {
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 去程日期
        /// </summary>
        public DateTime QuDate { get; set; }
    }
    #endregion

    #region 控位航段信息业务实体
    /// <summary>
    /// 控位航段信息业务实体
    /// </summary>
    public class MKongWeiHangDuanInfo
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime RiQi { get; set; }
        /// <summary>
        /// 交通编号
        /// </summary>
        public int JiaoTongId { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        public string BanCi { get; set; }
        /// <summary>
        /// 出发地省份编号
        /// </summary>
        public int ChuFaShengFenId { get; set; }
        /// <summary>
        /// 出发地城市编号
        /// </summary>
        public int ChuFaChengShiId { get; set; }
        /// <summary>
        /// 目的地省份编号
        /// </summary>
        public int MuDiDiShengFenId { get; set; }
        /// <summary>
        /// 目的地城市编号
        /// </summary>
        public int MuDiDiChengShiId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }

        /// <summary>
        /// 交通名称（OUTPUT）
        /// </summary>
        public string JiaoTongName { get; set; }
        /// <summary>
        /// 出发地省份名称（OUTPUT）
        /// </summary>
        public string ChuFaShengFenName { get; set; }
        /// <summary>
        /// 出发地城市名称（OUTPUT）
        /// </summary>
        public string ChuFaChengShiName { get; set; }
        /// <summary>
        /// 目的地省份名称（OUTPUT）
        /// </summary>
        public string MuDiDiShengFenName { get; set; }
        /// <summary>
        /// 目的地城市名称（OUTPUT）
        /// </summary>
        public string MuDiDiChengShiName { get; set; }
    }
    #endregion
}
