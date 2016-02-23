using System;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 公司系统配置BLL
    /// </summary>
    public class CompanySetting : BLLBase
    {
        private readonly IDAL.CompanyStructure.ICompanySetting _dal =
            Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ICompanySetting>();

        #region public members

        /*/// <summary>
        /// 设置系统配置信息
        /// </summary>
        /// <param name="model">系统配置实体</param>
        /// <returns>true：成功 false:失败</returns>
        public bool SetCompanySetting(Model.CompanyStructure.CompanyFieldSetting model)
        {
            if (model == null) return false;

            bool dalResult = this._dal.SetCompanySetting(model);

            if (dalResult)
            {
                Cache.Facade.EyouSoftCache.Remove(string.Format(Cache.Tag.TagName.ComSetting, model.CompanyId));

                #region LGWR

                var logInfo = new Model.CompanyStructure.SysHandleLogs
                {
                    CompanyId = 0,
                    DepatId = 0,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventIp = string.Empty,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.系统设置_系统配置 + "更新了系统配置信息。",
                    EventTime = DateTime.Now,
                    EventTitle = "更新系统配置",
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_系统配置,
                    OperatorId = 0
                };

                new SysHandleLogs().Add(logInfo);

                #endregion
            }

            return dalResult;
        }*/

        /*/// <summary>
        /// 设置公司的LOGO
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="logo">LOGO文件路径</param>
        /// <returns></returns>
        public bool SetCompanyLogo(int companyId, string logo)
        {
            if (companyId <= 0 || string.IsNullOrEmpty(logo))
                return false;
            bool dalResult = this._dal.SetValue(companyId, "CompanyLogo", logo);

            if (dalResult)
            {
                Cache.Facade.EyouSoftCache.Remove(string.Format(Cache.Tag.TagName.ComSetting, companyId));
            }

            return dalResult;
        }*/

        /*/// <summary>
        /// 获取指定公司的系统配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.CompanyFieldSetting GetSetting(int companyId)
        {
            if (companyId <= 0) return null;

            return Security.Membership.UserProvider.GetComSetting(companyId);
        }*/

        /*/// <summary>
        /// 获取指定公司的LOGO
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public string GetCompanyLogo(int companyId)
        {
            if (companyId <= 0) return string.Empty;
                
            var model = GetSetting(companyId);
            return model == null ? string.Empty : model.CompanyLogo;
        }

        /// <summary>
        /// 最长留位时间
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public int GetReservationTime(int companyId)
        {
            if (companyId <= 0) return 0;

            var model = GetSetting(companyId);
            return model == null ? 0 : model.ReservationTime;
        }*/

        /// <summary>
        /// 设置专线商配置信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int SheZhiZxsPeiZhi(EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo info)
        {
            if (info == null || info.CompanyId < 1 || string.IsNullOrEmpty(info.ZxsId)) return 0;

            int dalRetCode = _dal.SheZhiZxsPeiZhi(info);

            if (dalRetCode==1)
            {
                Cache.Facade.EyouSoftCache.Remove(string.Format(Cache.Tag.TagName.ZxsPeiZhi, info.CompanyId, info.ZxsId));

                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "更新配置信息";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.同行端口_积分兑换商品管理;
                log.EventMessage = "更新配置信息";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取专线商配置信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.MZxsPeiZhiInfo GetZxsPeiZhiInfo(int companyId, string zxsId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId)) return null;

            return EyouSoft.Security.Membership.UserProvider.GetZxsPeiZhiInfo(companyId, zxsId);
        }
        #endregion
    }
}
