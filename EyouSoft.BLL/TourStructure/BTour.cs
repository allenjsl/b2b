using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TourStructure
{
    public class BTour : BLLBase
    {
        private readonly EyouSoft.IDAL.TourStructure.ITour dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TourStructure.ITour>();

        #region public members
        /// <summary>
        /// 添加控位，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddKongWei(EyouSoft.Model.TourStructure.MKongWei model)
        {
            if (model.CompanyId == 0
                || !model.KongWeiType.HasValue
                || model.AreaId == 0
                || !model.QuDate.HasValue
                || model.QuJiaoTongId == 0
                || model.QuDepProvinceId == 0
                || model.QuDepCityId == 0
                || model.QuArrProvinceId == 0
                || model.QuArrCityId == 0
                || model.OperatorId == 0
                || !model.KongWeiType.HasValue
                || model.KongWeiDaiLiList == null
                || model.KongWeiDaiLiList.Count == 0)
            {
                return 0;
            }

            model.ShuLiang = 0;
            foreach (var item in model.KongWeiDaiLiList)
            {
                model.ShuLiang += item.ShuLiang;
            }

            foreach (var item in model.KongWeiDaiLiList)
            {
                if (string.IsNullOrEmpty(item.MoBanId)) item.MoBanId = Guid.NewGuid().ToString();
                item.DaiLiId = Guid.NewGuid().ToString();
            }

            model.KongWeiId = Guid.NewGuid().ToString();

            if (model.XianLus != null && model.XianLus.Count > 0)
            {
                foreach (var item in model.XianLus)
                {
                    item.KongWeiId = model.KongWeiId;
                    item.XianLuId = Guid.NewGuid().ToString();
                }
            }

            if (model.PingTaiShuLiang > model.ShuLiang) model.PingTaiShuLiang = model.ShuLiang;

            int dalRetCode = dal.AddKongWei(model);

            if (dalRetCode == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "上传计划位，计划位编号：" + model.KongWeiId,
                    EventTitle = "上传计划位",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 删除控位，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public int DeleteKongWei(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return 0;

            int flg = dal.DeleteKongWei(kongWeiId);
            if (flg == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "删除计划位，计划位编号：" + kongWeiId,
                    EventTitle = "删除计划位",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return flg;
        }

        /// <summary>
        /// 修改控位收客状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <param name="kongWeiStatus"></param>
        /// <returns></returns>
        public int UpdateKongWeiShouKeStatus(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiStatus? kongWeiStatus)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return 0;
            
            if (!kongWeiStatus.HasValue) return 0;

            int dalRetCode = dal.UpdateKongWeiShouKeStatus(kongWeiId, kongWeiStatus.Value);

            if (dalRetCode == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "修改计划位收客状态，计划位编号：" + kongWeiId + "，状态：" + kongWeiStatus.Value,
                    EventTitle = "修改计划位收客状态",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };
            }

            return dalRetCode;
        }

        /// <summary>
        /// 修改控位，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateKongWeid(EyouSoft.Model.TourStructure.MKongWei model)
        {
            if (string.IsNullOrEmpty(model.KongWeiId)
               || model.CompanyId == 0
               || !model.KongWeiType.HasValue
               || model.AreaId == 0
               || !model.QuDate.HasValue
               || model.QuJiaoTongId == 0
               || model.QuDepProvinceId == 0
               || model.QuDepCityId == 0
               || model.QuArrProvinceId == 0
               || model.QuArrCityId == 0
               || !model.KongWeiType.HasValue
               || model.KongWeiDaiLiList == null
               || model.KongWeiDaiLiList.Count == 0)
            {
                return 0;
            }

            model.ShuLiang = 0;
            foreach (var item in model.KongWeiDaiLiList)
            {
                model.ShuLiang += item.ShuLiang;
            }

            foreach (var item in model.KongWeiDaiLiList)
            {
                if (string.IsNullOrEmpty(item.MoBanId)) item.MoBanId = Guid.NewGuid().ToString();
                item.DaiLiId = Guid.NewGuid().ToString();
            }

            if (model.XianLus != null && model.XianLus.Count > 0)
            {
                foreach (var item in model.XianLus)
                {
                    item.KongWeiId = model.KongWeiId;

                    if (string.IsNullOrEmpty(item.XianLuId)) item.XianLuId = Guid.NewGuid().ToString();
                }
            }

            if (model.PingTaiShuLiang > model.ShuLiang) model.PingTaiShuLiang = model.ShuLiang;

            int dalRetCode = dal.UpdateKongWeid(model);

            if (dalRetCode == 1)
            {
                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage ="修改计划位，计划位编号："+model.KongWeiId,
                    EventTitle = "修改计划位",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务
                };

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(logInfo);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取控位实体
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MKongWei GetKongWeiById(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiById(kongWeiId);
        }

        /// <summary>
        /// 分页获取控位列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <param name="heJi">合计信息 [0:int:实收数量合计] [1:int:实际出票数量合计]</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MPageKongWei> GetKongWei(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            EyouSoft.Model.TourStructure.MSearchKongWei search, out object[] heJi)
        {
            heJi = new object[] { 0, 0 };
            if (companyId == 0) return null;
            return dal.GetKongWei(companyId, pageSize, pageIndex, ref recordCount, search, out heJi);
        }

        /// <summary>
        /// 根据控位编号 获取计划控位代理商信息表
        /// </summary>
        /// <param name="kongWeiId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiDaiLi> GetKongWeiDaiLiById(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;
            return dal.GetKongWeiDaiLiById(kongWeiId);
        }

        /// <summary>
        /// 获取控位剩余数量
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public int GetShengYuShuLiang(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return 0;

            return dal.GetShengYuShuLiang(kongWeiId);
        }

        /*/// <summary>
        /// 设置控位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="zhuangTai">控位状态</param>
        /// <returns></returns>
        public int SetKongWeiZhuangTai(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai zhuangTai, EyouSoft.Model.EnumType.TourStructure.BusinessType yeWuLeiXing)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return 0;

            int dalRetCode = dal.SetKongWeiZhuangTai(kongWeiId, zhuangTai);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置控位状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;

                if (yeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店)
                {
                    log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_代订酒店;
                }

                log.EventMessage = "设置控位状态，控位编号：" + kongWeiId + "，状态为：" + zhuangTai.ToString();

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }*/

        /// <summary>
        /// 设置控位状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="zhuangTai">控位状态</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yeWuLeiXing">业务类型</param>
        /// <returns></returns>
        public int SetKongWeiZhuangTai(string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai zhuangTai, int companyId, string zxsId, EyouSoft.Model.EnumType.TourStructure.BusinessType yeWuLeiXing)
        {
            if (string.IsNullOrEmpty(kongWeiId)||companyId<1||string.IsNullOrEmpty(zxsId)) return 0;

            int dalRetCode = dal.SetKongWeiZhuangTai(kongWeiId, zhuangTai, companyId, zxsId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置控位状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;

                if (yeWuLeiXing == EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店)
                {
                    log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_代订酒店;
                }

                log.EventMessage = "设置控位状态，控位编号：" + kongWeiId + "，状态为：" + zhuangTai.ToString();

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取控位状态
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai GetKongWeiZhuangTai(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai.核算结束;

            return dal.GetKongWeiZhuangTai(kongWeiId);
        }

        /// <summary>
        /// 新增控位操作备注，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertKongWeiBeiZhu(EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.KongWeiId) || info.OperatorId < 1 || info.LatestOperatorId < 1) return 0;
            info.BeiZhuId = Guid.NewGuid().ToString();
            info.IssueTime = info.LatestTime = DateTime.Now;
            int dalRetCode = dal.InsertKongWeiBeiZhu(info);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "新增控位操作备注";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "新增控位操作备注，控位编号：" + info.KongWeiId + "，操作备注编号：" + info.BeiZhuId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取控位操作备注集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiBeiZhuInfo> GetKongWeiBeiZhus(string kongWeiId,EyouSoft.Model.TourStructure.MKongWeiBeiZhuChaXunInfo chaXun)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiBeiZhus(kongWeiId, chaXun);
        }

        /// <summary>
        /// 设置控位操作备注状态，返回1成功，其它失败
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="beiZhuId">操作备注编号</param>
        /// <param name="operatorId">操作员编号</param>
        /// <returns></returns>
        public int KongWeiBeiZhuShiXiao(string kongWeiId, string beiZhuId, int operatorId)
        {
            if (string.IsNullOrEmpty(kongWeiId) || string.IsNullOrEmpty(beiZhuId) || operatorId < 1) return 0;

            int dalRetCode = dal.SheZhiKongWeiBeiZhuStatus(kongWeiId, beiZhuId, 1, operatorId, DateTime.Now);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置控位操作备注状态为失效";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "设置控位操作备注状态为失效，操作备注编号：" + beiZhuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 根据控位编号集合获取控位日期集合
        /// </summary>
        /// <param name="kongWeiIds">控位编号集合</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiRiQiInfo> GetKongWeisRiQis(IList<string> kongWeiIds)
        {
            if (kongWeiIds == null || kongWeiIds.Count == 0) return null;

            return dal.GetKongWeisRiQis(kongWeiIds);
        }

        /// <summary>
        /// 获取控位线路产品集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> GetKongWeiXianLus(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiXianLus(kongWeiId);
        }

        /// <summary>
        /// 获取控位线路产品集合
        /// </summary>
        /// <param name="kongWeiIds">控位编号集合</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MKongWeiXianLuInfo> GetKongWeisXianLus(IList<string> kongWeiIds)
        {
            if (kongWeiIds == null || kongWeiIds.Count == 0) return null;

            return dal.GetKongWeisXianLus(kongWeiIds);
        }

        /// <summary>
        /// 获取控位线路信息
        /// </summary>
        /// <param name="kongWeiXianLuId">控位线路编号</param>
        /// <returns></returns>
        public EyouSoft.Model.TourStructure.MKongWeiXianLuInfo GetKongWeiXianLuInfo(string kongWeiXianLuId)
        {
            if (string.IsNullOrEmpty(kongWeiXianLuId)) return null;

            var info = dal.GetKongWeiXianLuInfo(kongWeiXianLuId);

            if (info.LeiXing == EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票)
            {
                info.QuanPeiJiaGe = info.JieSuanJiaGe1;
            }

            return info;
        }

        /// <summary>
        /// 设置平台收客状态，返回1成功，其它失败
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="status">平台收客状态</param>
        /// <returns></returns>
        public int SheZhiPingTaiShouKeStatus(string zxsId, string kongWeiId, EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus status)
        {
            if (string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(kongWeiId)) return 0;
            int dalRetCode = dal.SheZhiPingTaiShouKeStatus(zxsId, kongWeiId, status);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置平台收客状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "设置平台收客状态，控位编号：" + kongWeiId + "，平台收客状态：" + status + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 设置平台控位数量，返回1成功，其它失败
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="pingTaiShuLiang">平台数量</param>
        /// <returns></returns>
        public int SheZhiPingTaiShuLiang(string zxsId, string kongWeiId, int pingTaiShuLiang)
        {
            if (string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(kongWeiId)) return 0;
            int dalRetCode = dal.SheZhiPingTaiShuLiang(zxsId, kongWeiId, pingTaiShuLiang);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置平台控位数量";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "设置平台控位数量，控位编号：" + kongWeiId + "，数量：" + pingTaiShuLiang + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 设置控位显示状态
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="kongWeiId">控位编号</param>
        /// <param name="xianShiStatus">显示状态</param>
        /// <returns></returns>
        public int SheZhiKongWeiXianShiStatus(string zxsId, string kongWeiId, EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus xianShiStatus)
        {
            if (string.IsNullOrEmpty(zxsId) || string.IsNullOrEmpty(kongWeiId)) return 0;

            int dalRetCode = dal.SheZhiKongWeiXianShiStatus(zxsId, kongWeiId, xianShiStatus);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置控位显示状态";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.收客计划_常规业务;
                log.EventMessage = "设置控位显示状态，控位编号：" + kongWeiId + "，状态：" + xianShiStatus + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
