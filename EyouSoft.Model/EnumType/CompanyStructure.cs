//系统设置-相关枚举
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.EnumType.CompanyStructure
{
    #region 公司银行账号性质

    /// <summary>
    /// 公司银行账号性质
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// 对公
        /// </summary>
        对公 = 0,
        /// <summary>
        /// 对私
        /// </summary>
        对私 = 1
    }

    #endregion

    #region 公司银行帐号状态

    /// <summary>
    /// 公司银行帐号状态
    /// </summary>
    public enum AccountState
    {
        /// <summary>
        /// 未审批
        /// </summary>
        未审批 = 0,
        /// <summary>
        /// 可用
        /// </summary>
        可用 = 1,
        /// <summary>
        /// 不可用
        /// </summary>
        不可用 = 2
    }

    #endregion

    #region 性别
    /// <summary>
    /// 性别
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 未知
        /// </summary>
        未知 = 0,
        /// <summary>
        /// 女
        /// </summary>
        女 = 1,
        /// <summary>
        /// 男
        /// </summary>
        男 = 2
    }

    #endregion

    #region 客户类型

    /// <summary>
    /// 客户类型
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// 同行客户
        /// </summary>
        同行客户 = 0,
        /// <summary>
        /// 单位直客
        /// </summary>
        单位直客 = 1,
        /// <summary>
        /// 特殊客户
        /// </summary>
        特殊客户=2
    }

    #endregion

    #region 用户状态
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 未启用=0
        /// </summary>
        未启用 = 0,
        /// <summary>
        /// 正常=1
        /// </summary>
        正常 = 1,
        /// <summary>
        /// 黑名单=2
        /// </summary>
        黑名单 = 2,
        /// <summary>
        /// 已停用=3
        /// </summary>
        已停用 = 3
    }
    #endregion

    #region 用户在线状态
    /// <summary>
    /// 用户在线状态
    /// </summary>
    public enum UserOnlineStatus
    {
        /// <summary>
        /// 离线
        /// </summary>
        Offline = 0,
        /// <summary>
        /// 在线
        /// </summary>
        Online
    }
    #endregion

    #region 用户登录类型
    /// <summary>
    /// 用户登录类型
    /// </summary>
    public enum UserLoginType
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        用户登录 = 0,
        /// <summary>
        /// 客服登录
        /// </summary>
        客服登录,
        /// <summary>
        /// 自动登录
        /// </summary>
        自动登录
    }
    #endregion

    #region 用户登录限制类型
    /// <summary>
    /// 用户登录限制类型
    /// </summary>
    public enum UserLoginLimitType
    {
        /// <summary>
        /// 所有登录有效
        /// </summary>
        None,
        /// <summary>
        /// 最早登录有效
        /// </summary>
        Earliest,
        /// <summary>
        /// 最近登录有效
        /// </summary>
        Latest
    }
    #endregion

    #region 供应商类型

    /// <summary>
    /// 供应商类型
    /// </summary>
    public enum SupplierType
    {
        /// <summary>
        /// 地接
        /// </summary>
        地接 = 1,
        /// <summary>
        /// 票务
        /// </summary>
        票务 = 2,
        /// <summary>
        /// 酒店
        /// </summary>
        酒店 = 3,
        /// <summary>
        /// 景点
        /// </summary>
        景点 = 4,
        /// <summary>
        /// 景点
        /// </summary>
        其他 = 5
    }

    #endregion

    #region 酒店星级

    /// <summary>
    /// 酒店星级
    /// </summary>
    public enum HotelStar
    {
        /// <summary>
        /// 3星以下
        /// </summary>
        _3星以下 = 1,
        /// <summary>
        /// 挂3
        /// </summary>
        挂3,
        /// <summary>
        /// 准3
        /// </summary>
        准3,
        /// <summary>
        /// 挂4
        /// </summary>
        挂4,
        /// <summary>
        /// 准4
        /// </summary>
        准4,
        /// <summary>
        /// 挂5
        /// </summary>
        挂5,
        /// <summary>
        /// 准5
        /// </summary>
        准5
    }

    #endregion

    #region 景点星级

    /// <summary>
    /// 景点星级
    /// </summary>
    public enum ScenicSpotStar
    {
        /// <summary>
        /// 1星
        /// </summary>
        _1星 = 1,
        /// <summary>
        /// 2星
        /// </summary>
        _2星,
        /// <summary>
        /// 3星
        /// </summary>
        _3星,
        /// <summary>
        /// 4星
        /// </summary>
        _4星,
        /// <summary>
        /// 5星
        /// </summary>
        _5星
    }

    #endregion

    #region 公司基础信息类型
    /// <summary>
    /// 公司基础信息类型
    /// </summary>
    public enum JiChuXinXiType
    {
        /// <summary>
        /// 去程时间
        /// </summary>
        去程时间 = 0,
        /// <summary>
        /// 回程时间
        /// </summary>
        回程时间 = 1,
        /// <summary>
        /// 去程班次
        /// </summary>
        去程班次 = 2,
        /// <summary>
        /// 回程班次
        /// </summary>
        回程班次 = 3,
        /// <summary>
        /// 集合地点
        /// </summary>
        集合地点 = 4,
        /// <summary>
        /// 集合时间
        /// </summary>
        集合时间 = 5,
        /// <summary>
        /// 送团信息
        /// </summary>
        送团信息 = 6,
        /// <summary>
        /// 目的地接团方式
        /// </summary>
        目的地接团方式 = 7,
        /// <summary>
        /// 用餐标准
        /// </summary>
        用餐标准 = 8,
        /// <summary>
        /// 其它收入项目
        /// </summary>
        其它收入项目 = 9,
        /// <summary>
        /// 其它支出项目
        /// </summary>
        其它支出项目 = 10
    }
    #endregion

    #region 线路政策状态
    /// <summary>
    /// 线路政策状态
    /// </summary>
    public enum ZhengCeStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常=0,
        /// <summary>
        /// 已过期
        /// </summary>
        已过期=1
    }
    #endregion

    #region 公司附件类型
    /// <summary>
    /// 公司附件类型
    /// </summary>
    public enum AnnexType
    {
        /// <summary>
        /// 公司信息
        /// </summary>
        公司信息 = 0,
        /// <summary>
        /// 客户信息
        /// </summary>
        客户信息 = 1,
        /// <summary>
        /// 资源信息
        /// </summary>
        资源信息 = 2,
        /// <summary>
        /// 个人中心-文档信息
        /// </summary>
        个人中心文档 = 3
    }
    #endregion

    #region 城市地区
    /// <summary>
    /// 城市地区
    /// </summary>
    public enum ChengShiDiQu
    {
        /// <summary>
        /// 其它地区
        /// </summary>
        其它地区 = 0,
        /// <summary>
        /// 温州地区
        /// </summary>
        温州地区,
        /// <summary>
        /// 台州地区
        /// </summary>
        台州地区,
        /// <summary>
        /// 丽水地区
        /// </summary>
        丽水地区,
        /// <summary>
        /// 金华地区
        /// </summary>
        金华地区,
        /// <summary>
        /// 衢州地区
        /// </summary>
        衢州地区
    }
    #endregion

    #region 用户类型
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum YongHuLeiXing
    {
        /// <summary>
        /// 专线用户
        /// </summary>
        专线用户 = 0,
        /// <summary>
        /// 同行用户
        /// </summary>
        同行用户 = 1,
        /// <summary>
        /// 平台酒店用户
        /// </summary>
        平台酒店用户 = 2,
        /// <summary>
        /// 平台景点用户
        /// </summary>
        平台景点用户 = 3,
        /// <summary>
        /// 供应商用户
        /// </summary>
        供应商用户=4
    }
    #endregion

    #region 客户来源
    /// <summary>
    /// 客户来源
    /// </summary>
    public enum KeHuLaiYuan
    {
        /// <summary>
        /// 系统添加
        /// </summary>
        系统添加 = 0,
        /// <summary>
        /// 平台注册
        /// </summary>
        平台注册
    }
    #endregion

    #region 客户审核状态
    /// <summary>
    /// 客户审核状态
    /// </summary>
    public enum KeHuShenHeStatus
    {
        /// <summary>
        /// 未审核
        /// </summary>
        未审核 = 0,
        /// <summary>
        /// 已审核
        /// </summary>
        已审核 = 1
    }
    #endregion

    #region 客户联系人状态
    /// <summary>
    /// 客户联系人状态
    /// </summary>
    public enum KeHuLxrStatus
    {
        /// <summary>
        /// 可修改可删除
        /// </summary>
        可修改可删除 = 0,
        /// <summary>
        /// 可修改不可删除
        /// </summary>
        可修改不可删除 = 1,
        /// <summary>
        /// 不可修改不可删除
        /// </summary>
        不可修改不可删除 = 2
    }
    #endregion

    #region 消息类型
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum XiaoXiLeiXing
    {
        /// <summary>
        /// 未确认订单
        /// </summary>
        未确认订单 = 0,
        /// <summary>
        /// 申请中订单
        /// </summary>
        申请中订单 = 1,
        /// <summary>
        /// 名单不全订单
        /// </summary>
        名单不全订单 = 2,
        /// <summary>
        /// 预留订单
        /// </summary>
        预留订单 = 3,
        /// <summary>
        /// 未处理兑换订单
        /// </summary>
        未处理兑换订单 = 4,
        /// <summary>
        /// 未审核注册用户
        /// </summary>
        未审核注册用户 = 5
    }
    #endregion

    #region 城市类型
    /// <summary>
    /// 城市类型
    /// </summary>
    public enum ChengShiLeiXing
    {
        /// <summary>
        /// 显示
        /// </summary>
        显示 = 0,
        /// <summary>
        /// 隐藏（线路区域、常用城市时隐藏）
        /// </summary>
        隐藏 = 1
    }
    #endregion
}
