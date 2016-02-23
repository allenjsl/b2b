//平台-控位线路相关信息业务实体 汪奇志 2014-08-31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PtStructure
{
    #region 平台-控位线路列表信息业务实体
    /// <summary>
    /// 平台-控位线路列表信息业务实体
    /// </summary>
    public class MKongWeiXianLuInfo
    {
        /// <summary>
        /// 去程日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 控位线路产品编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 区域编号
        /// </summary>
        public int QuYuId { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string QuYuName { get; set; }
        /// <summary>
        /// 天数
        /// </summary>
        public int TianShu { get; set; }
        /// <summary>
        /// 控位数量
        /// </summary>
        public int KongWeiShuLiang { get; set;}
        /// <summary>
        /// 已占位数量
        /// </summary>
        public int YiZhanWeiShuLiang { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int ShengYuShuLiang { get { return KongWeiShuLiang - YiZhanWeiShuLiang; } }
        /// <summary>
        /// 去程交通名称
        /// </summary>
        public string QuJiaoTongName { get; set; }
        /// <summary>
        /// 去程班次
        /// </summary>
        public string QuBanCi { get; set; }
        /// <summary>
        /// 去程-出发地省份名称
        /// </summary>
        public string QuChuFaDiShengFenName { get; set; }
        /// <summary>
        /// 去程-出发地城市名称
        /// </summary>
        public string QuChuFaDiChengShiName { get; set; }
        /// <summary>
        /// 去程-目的地省份名称
        /// </summary>
        public string QuMuDiDiShengFenName { get; set; }
        /// <summary>
        ///  去程-目的地城市名称
        /// </summary>
        public string QuMuDiDiChengShiName { get; set; }
        /// <summary>
        /// 回程交通名称
        /// </summary>
        public string HuiJiaoTongName { get; set; }
        /// <summary>
        /// 回程班次
        /// </summary>
        public string HuiBanCi { get; set; }
        /// <summary>
        /// 回程-出发地省份名称
        /// </summary>
        public string HuiChuFaDiShengFenName { get; set; }
        /// <summary>
        /// 回程-出发地城市名称
        /// </summary>
        public string HuiChuFaDiChengShiName { get; set; }
        /// <summary>
        /// 回程-目的地省份名称
        /// </summary>
        public string HuiMuDiDiShengFenName { get; set; }
        /// <summary>
        /// 回程-目的地城市名称
        /// </summary>
        public string HuiMuDiDiChengShiName { get; set; }        
        /// <summary>
        /// 线路名称
        /// </summary>
        public string XianLuName { get; set; }
        /// <summary>
        /// 线路标准
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun XianLuBiaoZhun { get; set; }
        /// <summary>
        /// 线路积分
        /// </summary>
        public int XianLuJiFen { get; set; }
        /// <summary>
        /// 门市成人价
        /// </summary>
        public decimal XianLuMenShiJiaGe1 { get; set; }
        /// <summary>
        /// 门市儿童价
        /// </summary>
        public decimal XianLuMenShiJiaGe2 { get; set; }
        /// <summary>
        /// 结算成人价
        /// </summary>
        public decimal XianLuJieSuanJiaGe1 { get; set; }
        /// <summary>
        /// 结算儿童价
        /// </summary>
        public decimal XianLuJieSuanJiaGe2 { get; set; }
        /// <summary>
        /// 线路封面
        /// </summary>
        public string XianLuFengMian { get; set; }
        /// <summary>
        /// 控位线路产品类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing KongWeiXianLuLeiXing { get; set; }
        /// <summary>
        /// 线路标准名称
        /// </summary>
        public string XianLuBiaoZhunName { get { return XianLuBiaoZhun.ToString(); } }
        /// <summary>
        /// 平台控位数量
        /// </summary>
        public int PingTaiShuLiang { get; set; }
        /// <summary>
        /// 平台剩余数量
        /// </summary>
        public int PingTaiShengYuShuLiang
        {
            get
            {
                if (ShouKeStatus == EyouSoft.Model.EnumType.TourStructure.KongWeiStatus.手动停收) return 0;
                if (PingTaiShouKeStatus == EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus.手动停收) return 0;

                int _shengYuShuLiang = PingTaiShuLiang - YiZhanWeiShuLiang;
                if (_shengYuShuLiang < 0) return 0;
                return _shengYuShuLiang;
            }
        }

        /// <summary>
        /// 专线商控位收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiStatus ShouKeStatus { get; set; }
        /// <summary>
        /// 平台控位收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus PingTaiShouKeStatus { get; set; }

        /// <summary>
        /// 限定人数
        /// </summary>
        public int XianDingRenShu { get; set; }
    }
    #endregion

    #region 平台-控位线路查询信息业务实体
    /// <summary>
    /// 平台-控位线路查询信息业务实体
    /// </summary>
    public class MKongWeiXianLuChaXunInfo
    {
        /// <summary>
        /// 站点编号
        /// </summary>
        public int? ZhanDianId { get; set; }
        /// <summary>
        /// 专线类别编号
        /// </summary>
        public int? ZxlbId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 去程日期-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 去程日期-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }
        /// <summary>
        /// 线路区域编号
        /// </summary>
        public int? QuYuId { get; set; }
        /// <summary>
        /// 线路标准
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun? BiaoZhun { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 不需要的控位线路产品编号
        /// </summary>
        public string XianLuId1 { get; set; }
        /// <summary>
        /// 控位线路类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing? KongWeiXianLuLeiXing { get; set; }
        EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus? _KongWeiXianLuStatus = EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus.正常销售;
        /// <summary>
        /// 控位线路状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus? KongWeiXianLuStatus { get { return _KongWeiXianLuStatus; } set { _KongWeiXianLuStatus = value; } }
        /// <summary>
        /// 是否包含停收（系统停收） 0：不包含 1：包含
        /// </summary>
        public int ExistsTingShou1 { get; set; }
        /// <summary>
        /// 是否包含停收（平台停收） 0：不包含 1：包含
        /// </summary>
        public int ExistsTingShou2 { get; set; }
    }
    #endregion

    #region 平台-订单中心列表信息业务实体
    /// <summary>
    /// 平台-订单中心列表信息业务实体
    /// </summary>
    public class MDingDanLbInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 交易号（订单号）
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 订单状态 
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.OrderStatus DingDanStatus { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string XiaDanRenName { get; set; }
        /// <summary>
        /// 下单人编号（用户编号）
        /// </summary>
        public int XiaDanRenId { get; set; }
        /// <summary>
        /// 下单人联系人编号（客户联系人编号）
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 客户联系人姓名
        /// </summary>
        public string KeHuLxrName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime XiaDanShiJian { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RotueName { get; set; }
        /// <summary>
        /// 应付金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 已支付金额
        /// </summary>
        public decimal YiZhiFuJinE { get; set; }
        /// <summary>
        /// 未支付金额
        /// </summary>
        public decimal WeiZhiFuJinE { get { return JinE - YiZhiFuJinE; } }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童人数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 婴儿人数
        /// </summary>
        public int YingErShu { get; set; }
        /// <summary>
        /// 全陪人数
        /// </summary>
        public int QuanPeiShu { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
        /// <summary>
        /// 专线商操作人编号
        /// </summary>
        public int ZxsCaoZuoRenId { get; set; }
        /// <summary>
        /// 专线商操作人姓名
        /// </summary>
        public string ZxsCaoZuoRenName { get; set; }
        /// <summary>
        /// 专线商操作时间
        /// </summary>
        public DateTime ZxsCaoZuoShiJian { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing{get;set;}
        /// <summary>
        /// 下单类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.XiaDanLeiXing XiaDanLeiXing { get; set; }
        /// <summary>
        /// 单人积分
        /// </summary>
        public int JiFen1 { get; set; }
        /// <summary>
        /// 积分总计
        /// </summary>
        public int JiFen2 { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public string YuanYin1 { get; set; }
        /// <summary>
        /// 积分显示标识
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi JiFenXianShiBiaoShi { get; set; }
        /// <summary>
        /// 发票明细编号
        /// </summary>
        public int FaPiaoMxId { get; set; }
    }
    #endregion

    #region 平台-订单中心列表信息查询业务实体
    /// <summary>
    /// 平台-订单中心列表信息查询业务实体
    /// </summary>
    public class MDingDanLbChaXunInfo
    {
        /// <summary>
        /// 出团日期-起
        /// </summary>
        public DateTime? QuDate1 { get; set; }
        /// <summary>
        /// 出团日期-止
        /// </summary>
        public DateTime? QuDate2 { get; set; }
        /// <summary>
        /// 专线商名称
        /// </summary>
        public string ZxsName { get; set; }
        /// <summary>
        /// 游客姓名
        /// </summary>
        public string YouKeName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.OrderStatus? DingDanStatus { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType? YeWuLeiXing { get; set; }
        /// <summary>
        /// 结清状态 [0:未结清][1:已结清]
        /// </summary>
        public int? JieQingStatus { get; set; }

        /// <summary>
        /// 下单时间（用于控制显示指定时间后的订单）
        /// </summary>
        public DateTime? XiaDanShiJian0 { get { return new DateTime(2014, 10, 1); } }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion

    #region  线路关联控位线路信息业务实体
    /// <summary>
    /// 线路关联控位线路信息业务实体
    /// </summary>
    public class MGuanLianKongWeiXianLuInfo
    {
        /// <summary>
        /// 控位编号
        /// </summary>
        public string KongWeiId { get; set; }
        /// <summary>
        /// 去程日期
        /// </summary>
        public DateTime QuDate { get; set; }
        /// <summary>
        /// 控位数量
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 已占位数量
        /// </summary>
        public int YiZhanWeiShuLiang { get; set; }
        /// <summary>
        /// 线路产品编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 门市价格-成人
        /// </summary>
        public decimal MenShiJiaGe1 { get; set; }
        /// <summary>
        /// 结算价格-成人
        /// </summary>
        public decimal JieSuanJiaGe1 { get; set; }
        /// <summary>
        /// 控位线路产品类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing KongWeiXianLuLeiXing { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int ShengYuShuLiang { get { return ShuLiang - YiZhanWeiShuLiang; } }        
        /// <summary>
        /// 专线商控位收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiStatus ShouKeStatus { get; set; }
        /// <summary>
        /// 平台控位收客状态
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus PingTaiShouKeStatus { get; set; }
        /// <summary>
        /// 平台控位数量
        /// </summary>
        public int PingTaiShuLiang { get; set; }
        /// <summary>
        /// 平台剩余数量
        /// </summary>
        public int PingTaiShengYuShuLiang
        {
            get
            {
                if (ShouKeStatus == EyouSoft.Model.EnumType.TourStructure.KongWeiStatus.手动停收) return 0;
                if (PingTaiShouKeStatus == EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus.手动停收) return 0;

                int _shengYuShuLiang = PingTaiShuLiang - YiZhanWeiShuLiang;
                if (_shengYuShuLiang < 0) return 0;
                return _shengYuShuLiang;
            }
        }
    }
    #endregion
}
