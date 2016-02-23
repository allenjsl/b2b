using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.EnumType.TourStructure
{
    #region 业务类型
    /// <summary>
    /// 业务类型
    /// </summary>
    public enum BusinessType
    {
        /// <summary>
        /// 常规旅游
        /// </summary>
        常规旅游 = 0,
        /// <summary>
        /// 单订票
        /// </summary>
        单订票 = 1,
        /// <summary>
        /// 票务酒店
        /// </summary>
        票务酒店 = 2,
        /// <summary>
        /// 代订酒店
        /// </summary>
        代订酒店 = 3,
        /// <summary>
        /// 私人订制(原特殊旅游)
        /// </summary>
        私人订制 = 4,
        /// <summary>
        /// 自由行
        /// </summary>
        自由行=5
    }
    #endregion

    #region 业务性质
    /// <summary>
    /// 业务性质
    /// </summary>
    public enum BusinessNature
    {
        /// <summary>
        /// 散拼
        /// </summary>
        散拼 = 0,
        /// <summary>
        /// 组团
        /// </summary>
        组团 = 1
    }
    #endregion

    #region 控位收客状态
    /// <summary>
    /// 控位收客状态
    /// </summary>
    public enum KongWeiStatus
    {
        /// <summary>
        /// 报名中 = 0
        /// </summary>
        正常收客 = 0,
        /// <summary>
        /// 手动停收=1
        /// </summary>
        手动停收 = 1,
        /// <summary>
        ///  自动客满=2
        /// </summary>
        自动客满 = 2
    }
    #endregion

    #region 订单状态
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 已留位
        /// </summary>
        已留位 = 0,
        /// <summary>
        /// 已成交
        /// </summary>
        已成交 = 1,
        /// <summary>
        /// 留位过期
        /// </summary>
        留位过期 = 2,
        /// <summary>
        /// 已取消
        /// </summary>
        已取消 = 3,
        /// <summary>
        /// 未确认
        /// </summary>
        未确认 = 4,
        /// <summary>
        /// 名单不全
        /// </summary>
        名单不全 = 5,
        /// <summary>
        /// 申请中
        /// </summary>
        申请中 = 6,
        /// <summary>
        /// 已拒绝
        /// </summary>
        已拒绝 = 7
    }
    #endregion

    #region 游客类型
    /// <summary>
    /// 游客类型
    /// </summary>
    public enum TravellerType
    {
        /// <summary>
        /// 儿童
        /// </summary>
        儿童 = 0,
        /// <summary>
        /// 成人
        /// </summary>
        成人 = 1,
        /// <summary>
        /// 军残
        /// </summary>
        军残 = 2,
        /// <summary>
        /// 婴儿
        /// </summary>
        婴儿 = 3,
        /// <summary>
        /// 全陪
        /// </summary>
        全陪 = 4
    }
    #endregion

    #region 游客状态
    /// <summary>
    /// 游客状态
    /// </summary>
    public enum TravellerStatus
    {
        /// <summary>
        /// 在团
        /// </summary>
        在团 = 0,
        /// <summary>
        /// 退团
        /// </summary>
        退团 = 1
    }
    #endregion

    #region 出票状态
    /// <summary>
    /// 出票状态
    /// </summary>
    public enum TicketType
    {
        /// <summary>
        /// 未出票
        /// </summary>
        未出票 = 0,
        /// <summary>
        /// 已出票
        /// </summary>
        已出票 = 1,
        /// <summary>
        /// 已退票
        /// </summary>
        已退票 = 2
    }
    #endregion

    #region 游客证件类型枚举
    /// <summary>
    /// 游客证件类型枚举
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// 未知
        /// </summary>
        未知 = 0,
        /// <summary>
        /// 身份证
        /// </summary>
        身份证 = 1,
        /// <summary>
        /// 军官证
        /// </summary>
        军官证 = 2,
        /// <summary>
        /// 台胞证
        /// </summary>
        台胞证 = 3,
        /// <summary>
        /// 港澳通行证
        /// </summary>
        港澳通行证 = 4,
        /// <summary>
        /// 户口本
        /// </summary>
        户口本 = 5,
        /// <summary>
        /// 护照
        /// </summary>
        护照 = 6
    }
    #endregion

    #region 变更类型
    /// <summary>
    /// 变更类型
    /// </summary>
    public enum BianType
    {
        /// <summary>
        /// 订单
        /// </summary>
        订单变更 = 0,
        /// <summary>
        /// 地接
        /// </summary>
        地接安排变更,
        /// <summary>
        /// 票务
        /// </summary>
        票务安排变更,
        /// <summary>
        /// 代订酒店
        /// </summary>
        代订酒店,
        /// <summary>
        /// 利润表
        /// </summary>
        利润表,
        /// <summary>
        /// 资产负债表
        /// </summary>
        资产负债表
    }
    #endregion

    #region 控位状态
    /// <summary>
    /// 控位状态
    /// </summary>
    public enum KongWeiZhuangTai
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常 = 0,
        /// <summary>
        /// 核算结束
        /// </summary>
        核算结束 = 1
    }
    #endregion

    #region 线路类型
    /// <summary>
    /// 线路类型
    /// </summary>
    public enum XianLuLeiXing
    {
        /// <summary>
        /// 常规旅游
        /// </summary>
        常规旅游 = 0,
        /// <summary>
        /// 私人订制
        /// </summary>
        私人订制 = 4,
        /// <summary>
        /// 自由行
        /// </summary>
        自由行 = 5
    }
    #endregion

    #region 线路标准
    /// <summary>
    /// 线路标准
    /// </summary>
    public enum XianLuBiaoZhun
    {
        None = 0,
        New = 1,
        特价 = 2,
        经济 = 3,
        豪华 = 4,
        纯玩 = 5,
        自由行 = 6,
        订制 = 7,
        推荐 = 8,
        热销 = 9
    }
    #endregion

    #region 控位线路产品类型
    /// <summary>
    /// 控位线路产品类型
    /// </summary>
    public enum KongWeiXianLuLeiXing
    {
        线路=0,
        单订票=1
    }
    #endregion

    #region 控位线路状态
    /// <summary>
    /// 控位线路状态
    /// </summary>
    public enum KongWeiXianLuStatus
    {
        正常销售=0,
        停止销售=1
    }
    #endregion

    #region 下单类型
    /// <summary>
    /// 下单类型
    /// </summary>
    public enum XiaDanLeiXing
    {
        /// <summary>
        /// 系统下单（代客户下单）
        /// </summary>
        系统下单=0,
        /// <summary>
        /// 平台下单（客户自行下单）
        /// </summary>
        平台下单=1
    }
    #endregion

    #region 平台控位状态
    /// <summary>
    /// 平台控位收客状态
    /// </summary>
    public enum PingTaiShouKeStatus
    {
        /// <summary>
        /// 正常收客 = 0
        /// </summary>
        正常收客 = 0,
        /// <summary>
        /// 手动停收=1
        /// </summary>
        手动停收 = 1
    }
    #endregion    

    #region 积分显示标识
    /// <summary>
    /// 积分显示标识
    /// </summary>
    public enum JiFenXianShiBiaoShi
    {
        /// <summary>
        /// 显示
        /// </summary>
        显示=0,
        /// <summary>
        /// 不显示
        /// </summary>
        不显示=1
    }
    #endregion

    #region 控位显示状态
    /// <summary>
    /// 控位显示状态
    /// </summary>
    public enum KongWeiXianShiStatus
    {
        /// <summary>
        /// 显示
        /// </summary>
        显示=0,
        /// <summary>
        /// 隐藏
        /// </summary>
        隐藏=1
    }
    #endregion

    #region 确认状态
    /// <summary>
    /// 确认状态
    /// </summary>
    public enum QueRenStatus
    {
        /// <summary>
        /// 未确认
        /// </summary>
        未确认=0,
        /// <summary>
        /// 已确认
        /// </summary>
        已确认=1
    }
    #endregion
}
