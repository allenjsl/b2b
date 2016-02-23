using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TourStructure
{
    public interface ITour
    {
        /// <summary>
        /// 添加控位，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddKongWei(EyouSoft.Model.TourStructure.MKongWei model);
        /// <summary>
        /// 删除控位，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        int DeleteKongWei(string kongWeiId);

        /// <summary>
        /// 修改控位，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateKongWeid(EyouSoft.Model.TourStructure.MKongWei model);
        /// <summary>
        /// 修改控位收客状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <param name="kongWeiStatus"></param>
        /// <returns></returns>
        int UpdateKongWeiShouKeStatus(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiStatus kongWeiStatus);
        /// <summary>
        /// 获取控位实体
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        EyouSoft.Model.TourStructure.MKongWei GetKongWeiById(string kongWeiId);
        /// <summary>
        /// 获取控位列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <param name="heJi">合计信息 [0:int:实收数量合计] [1:int:实际出票数量合计]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MPageKongWei> GetKongWei(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            EyouSoft.Model.TourStructure.MSearchKongWei search, out object[] heJi);

        /// <summary>
        /// 根据控位编号 获取计划控位代理商信息表
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiDaiLi> GetKongWeiDaiLiById(string kongWeiId);
        /// <summary>
        /// 获取控位剩余数量
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        int GetShengYuShuLiang(string kongWeiId);

        /*/// <summary>
        /// 设置控位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="zhuangTai">控位状态</param>
        /// <returns></returns>
        int SetKongWeiZhuangTai(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai zhuangTai);*/
        /// <summary>
        /// 设置控位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="zhuangTai">控位状态</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        int SetKongWeiZhuangTai(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai zhuangTai, int companyId, string zxsId);
        /// <summary>
        /// 获取控位状态
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai GetKongWeiZhuangTai(string kongWeiId);

        /// <summary>
        /// 新增控位操作备注，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertKongWeiBeiZhu(EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo info);
        /// <summary>
        /// 获取控位操作备注集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo> GetKongWeiBeiZhus(string kongWeiId, EyouSoft.Model.TourStructure.MKongWeiBeiZhuChaXunInfo chaXun);
        /// <summary>
        /// 设置控位操作备注状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="beiZhuId">操作备注编号</param>
        /// <param name="status">状态 0:有效 1:失效</param>
        /// <param name="operatorId">操作员编号</param>
        /// <param name="shiJian">操作时间</param>
        /// <returns></returns>
        int SheZhiKongWeiBeiZhuStatus(string kongWeiId, string beiZhuId, int status, int operatorId, DateTime shiJian);

        /// <summary>
        /// 根据控位编号集合获取控位日期集合
        /// </summary>
        /// <param name="kongWeiIds">控位编号集合</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiRiQiInfo> GetKongWeisRiQis(IList<string> kongWeiIds);
        /// <summary>
        /// 获取控位线路产品集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> GetKongWeiXianLus(string kongWeiId);

        /// <summary>
        /// 获取控位线路产品集合
        /// </summary>
        /// <param name="kongWeiIds">控位编号集合</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> GetKongWeisXianLus(IList<string> kongWeiIds);

        /// <summary>
        /// 获取控位线路信息
        /// </summary>
        /// <param name="kongWeiXianLuId">控位线路编号</param>
        /// <returns></returns>
        EyouSoft.Model.TourStructure.MKongWeiXianLuInfo GetKongWeiXianLuInfo(string kongWeiXianLuId);
        /// <summary>
        /// 设置平台收客状态，返回1成功，其它失败
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="status">平台收客状态</param>
        /// <returns></returns>
        int SheZhiPingTaiShouKeStatus(string zxsId, string kongWeiId, EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus status);
        /// <summary>
        /// 设置平台控位数量，返回1成功，其它失败
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="pingTaiShuLiang">平台数量</param>
        /// <returns></returns>
        int SheZhiPingTaiShuLiang(string zxsId, string kongWeiId, int pingTaiShuLiang);
        /// <summary>
        /// 设置控位显示状态
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="xianShiStatus">显示状态</param>
        /// <returns></returns>
        int SheZhiKongWeiXianShiStatus(string zxsId, string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus xianShiStatus);
    }
}
