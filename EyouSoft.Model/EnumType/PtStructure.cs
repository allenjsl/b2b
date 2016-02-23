using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.EnumType.PtStructure
{
    #region 专线类别状态
    /// <summary>
    /// 专线类别状态
    /// </summary>
    public enum ZhuanXianLeiBieStatus
    {
        /// <summary>
        /// 启用
        /// </summary>
        启用 = 0,
        /// <summary>
        /// 禁用
        /// </summary>
        禁用 = 1
    }
    #endregion

    #region key-value key
    /// <summary>
    /// key-value key
    /// </summary>
    public enum KvKey
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// 平台标题
        /// </summary>
        平台标题 = 1,
        /// <summary>
        /// 平台关键字keywords
        /// </summary>
        平台关键字 = 2,
        /// <summary>
        /// 平台描述description
        /// </summary>
        平台描述 = 3,
        /// <summary>
        /// 客服电话
        /// </summary>
        客服电话 = 4,
        /// <summary>
        /// 关于我们
        /// </summary>
        关于我们 = 5,
        /// <summary>
        /// 免责声明
        /// </summary>
        免责声明 = 6,
        /// <summary>
        /// 平台版权
        /// </summary>
        平台版权 = 7,
        /// <summary>
        /// 联系方式
        /// </summary>
        联系方式 = 8,
        /// <summary>
        /// 找回密码SMTP服务器
        /// </summary>
        找回密码SMTP服务器 = 9,
        /// <summary>
        /// 找回密码发件人邮箱账号
        /// </summary>
        找回密码发件人邮箱账号 = 10,
        /// <summary>
        /// 找回密码发件人邮箱密码
        /// </summary>
        找回密码发件人邮箱密码 = 11,
        /// <summary>
        /// 找回密码邮件正文
        /// </summary>
        找回密码邮件正文 = 12,
        /// <summary>
        /// 找回密码邮件主题
        /// </summary>
        找回密码邮件主题 = 13,
        /// <summary>
        /// 找回密码发件人显示名
        /// </summary>
        找回密码发件人显示名=14
    }
    #endregion

    #region 专线商状态
    /// <summary>
    /// 专线商状态
    /// </summary>
    public enum ZhuanXianShangStatus
    {
        /// <summary>
        /// 启用
        /// </summary>
        启用=0,
        /// <summary>
        /// 禁用
        /// </summary>
        禁用=1
    }
    #endregion

    #region 专线商积分发放状态
    /// <summary>
    /// 专线商积分发放状态
    /// </summary>
    public enum ZhuanXianShangJiFenStatus
    {
        /// <summary>
        /// 启用
        /// </summary>
        启用 = 0,
        /// <summary>
        /// 禁用
        /// </summary>
        禁用 = 1
    }
    #endregion

    #region 线路区域出发地目的地类型
    /// <summary>
    /// 线路区域省份城市类型
    /// </summary>
    public enum QuYuShengFenChengShiLeiXing
    {
        /// <summary>
        /// 去程出发地
        /// </summary>
        去程出发地=0,
        /// <summary>
        /// 去程目的地
        /// </summary>
        去程目的地=1
    }
    #endregion

    #region 资讯类型
    /// <summary>
    /// 资讯类型
    /// </summary>
    public enum ZiXunLeiXing
    {
        /// <summary>
        /// 平台资讯
        /// </summary>
        平台资讯 = 0,
        /// <summary>
        /// 平台站点公告
        /// </summary>
        平台站点公告 = 1
    }
    #endregion

    #region 广告位置
    /// <summary>
    /// 广告位置
    /// </summary>
    public enum GuangGaoWeiZhi
    {
        /// <summary>
        /// 导航滚动横幅
        /// </summary>
        导航滚动横幅 = 0,
        /// <summary>
        /// 商家大全左侧广告位
        /// </summary>
        商家大全左侧广告位 = 1,
        /// <summary>
        /// 酒店左侧广告位
        /// </summary>
        酒店左侧广告位 = 2,
        /// <summary>
        /// 注册右侧热门线路推荐
        /// </summary>
        注册右侧热门线路推荐 = 3
    }
    #endregion

    #region 酒店星级
    /// <summary>
    /// 酒店星级
    /// </summary>
    public enum JiuDianXingJi
    {
        /// <summary>
        /// 三星以下
        /// </summary>
        三星以下 = 1,
        /// <summary>
        /// 挂三
        /// </summary>
        挂三,
        /// <summary>
        /// 准三
        /// </summary>
        准三,
        /// <summary>
        /// 挂四
        /// </summary>
        挂四,
        /// <summary>
        /// 准四
        /// </summary>
        准四,
        /// <summary>
        /// 挂五
        /// </summary>
        挂五,
        /// <summary>
        /// 准五
        /// </summary>
        准五
    }
    #endregion

    #region 积分商品状态
    /// <summary>
    /// 积分商品状态
    /// </summary>
    public enum JiFenShangPingStatus
    {
        /// <summary>
        /// 上架
        /// </summary>
        上架=0,
        /// <summary>
        /// 下架
        /// </summary>
        下架
    }
    #endregion

    #region 积分商品类型
    /// <summary>
    /// 积分商品类型
    /// </summary>
    public enum JiFenShangPingLeiXing
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// 数码产品
        /// </summary>
        数码产品 = 1,
        /// <summary>
        /// 生活用品
        /// </summary>
        生活用品 = 2,
        /// <summary>
        /// 家用电器
        /// </summary>
        家用电器 = 3,
        /// <summary>
        /// 食品
        /// </summary>
        食品 = 4
    }
    #endregion

    #region 积分订单状态
    /// <summary>
    /// 积分订单状态
    /// </summary>
    public enum JiFenDingDanStatus
    {
        /// <summary>
        /// 未确认
        /// </summary>
        未确认 = 0,
        /// <summary>
        /// 已确认
        /// </summary>
        已确认 = 1,
        /// <summary>
        /// 已发货
        /// </summary>
        已发货 = 2,
        /// <summary>
        /// 已取消
        /// </summary>
        已取消 = 3
    }
    #endregion

    #region 积分状态
    /// <summary>
    /// 积分状态
    /// </summary>
    public enum JiFenStatus
    {
        /// <summary>
        /// 冻结
        /// </summary>
        冻结 = 0,
        /// <summary>
        /// 有效
        /// </summary>
        有效 = 1,
        /// <summary>
        /// 取消
        /// </summary>
        取消 = 2,
        /// <summary>
        /// 删除
        /// </summary>
        删除 = 3
    }
    #endregion

    #region 积分类型
    /// <summary>
    /// 积分类型
    /// </summary>
    public enum JiFenLeiXing
    {
        /// <summary>
        /// 积分
        /// </summary>
        积分=0,
        /// <summary>
        /// 兑换
        /// </summary>
        兑换=1
    }
    #endregion

    #region 积分收付款明细类型
    /// <summary>
    /// 积分收付款明细类型
    /// </summary>
    public enum JiFenShouFuKuanMxLeiXing
    {
        /// <summary>
        /// 结算积分-收入
        /// </summary>
        结算积分=0,
        /// <summary>
        /// 兑换商品-支出
        /// </summary>
        兑换商品=1
    }
    #endregion

    #region zxs t1
    /// <summary>
    /// zxs t1
    /// </summary>
    public enum ZxsT1
    {
        其它专线商=0,
        主专线商=1
    }
    #endregion

    #region 验证码类型
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum YanZhengMaLeiXing
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// 找回密码
        /// </summary>
        找回密码 = 1
    }
    #endregion

    #region 验证码状态
    /// <summary>
    /// 验证码状态
    /// </summary>
    public enum YanZhengMaStatus
    {
        /// <summary>
        /// 有效
        /// </summary>
        有效 = 0,
        /// <summary>
        /// 已过期
        /// </summary>
        已过期 = 1,
        /// <summary>
        /// 已使用
        /// </summary>
        已使用 = 2
    }
    #endregion

    #region 广告状态
    /// <summary>
    /// 广告状态
    /// </summary>
    public enum GuangGaoStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常=0,
        /// <summary>
        /// 停用
        /// </summary>
        停用=1
    }
    #endregion

    #region 资讯状态
    /// <summary>
    /// 资讯状态
    /// </summary>
    public enum ZiXunStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常 = 0,
        /// <summary>
        /// 停用
        /// </summary>
        停用 = 1
    }
    #endregion

    #region 促销状态
    /// <summary>
    /// 促销状态
    /// </summary>
    public enum CuXiaoStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常 = 0,
        /// <summary>
        /// 停用
        /// </summary>
        停用 = 1
    }
    #endregion

    #region 推荐状态
    /// <summary>
    /// 推荐状态
    /// </summary>
    public enum TuiJianStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常 = 0,
        /// <summary>
        /// 停用
        /// </summary>
        停用 = 1
    }
    #endregion

    #region zxs t2
    /// <summary>
    /// zxs t2
    /// </summary>
    public enum ZxsT2
    {
        /// <summary>
        /// 默认：专线商系统、同行平台均开放
        /// </summary>
        默认 = 0,
        /// <summary>
        /// 仅专线商系统
        /// </summary>
        仅专线商系统
    }
    #endregion

    #region 域名类型
    /// <summary>
    /// 域名类型
    /// </summary>
    public enum YuMingLeiXing
    {
        /// <summary>
        /// 专线商平台
        /// </summary>
        专线商平台 = 0,
        /// <summary>
        /// 同行平台
        /// </summary>
        同行平台 = 1,
        /// <summary>
        /// 地接平台
        /// </summary>
        地接平台 = 2
    }
    #endregion
}
