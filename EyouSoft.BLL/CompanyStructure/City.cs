using System;
using System.Collections.Generic;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 城市管理BLL
    /// </summary>
    public class City : BLLBase
    {
        private readonly IDAL.CompanyStructure.ICity _dal = Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ICity>();
        private readonly SysHandleLogs _handleLogsBll = new SysHandleLogs();

        #region private members
        /// <summary>
        /// 添加日志记录
        /// </summary>
        /// <param name="actionName">操作名称</param>
        /// <param name="cityId">操作的城市编号（可以是多个）</param>
        /// <param name="cityName">城市名称</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.SysHandleLogs AddLogs(string actionName, string cityId, string cityName)
        {
            var model = new Model.CompanyStructure.SysHandleLogs
            {
                ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置,
                EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                EventMessage =
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                    + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + actionName + "了城市，编号为" + cityId + "，名称为"
                    + cityName,
                EventTitle = actionName + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + " 城市"
            };

            return model;
        }
        #endregion

        #region public members

        /// <summary>
        /// 验证城市名是否已经存在
        /// </summary>
        /// <param name="cityName">城市名称</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="cityId">城市编号</param>
        /// <returns>true:已存在 false:不存在</returns>
        public bool IsExists(string cityName, int companyId, int cityId)
        {
            if (string.IsNullOrEmpty(cityName) || companyId <= 0) return true;

            return this._dal.IsExists(cityName, companyId, cityId);
        }

        /// <summary>
        /// 添加城市
        /// </summary>
        /// <param name="model">城市实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.City model)
        {
            if (model == null || string.IsNullOrEmpty(model.CityName)) return false;

            bool result = this._dal.Add(model);
            if (result) this._handleLogsBll.Add(AddLogs("新增", model.Id.ToString(), model.CityName));

            return result;
        }

        /// <summary>
        /// 修改城市
        /// </summary>
        /// <param name="model">城市实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(Model.CompanyStructure.City model)
        {
            if (model == null || model.Id <= 0) return false;

            bool result = this._dal.Update(model);
            if (result) this._handleLogsBll.Add(AddLogs("修改", model.Id.ToString(), model.CityName));

            return result;
        }

        /// <summary>
        /// 获取城市实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.City GetModel(int id)
        {
            if (id <= 0) return null;

            return this._dal.GetModel(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">城市编号</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Delete(int id)
        {
            if (id < 0) return false;

            bool result = this._dal.Delete(id);
            if (result) this._handleLogsBll.Add(AddLogs("删除", id.ToString(), string.Empty));

            return result;
        }

        /// <summary>
        /// 设置常用城市，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chengShiId">城市编号</param>
        /// <returns></returns>
        public int SheZhiChangYongChengShi(int companyId, string zxsId, int chengShiId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || chengShiId < 1) return 0;

            int dalRetCode = _dal.SheZhiChangYongChengShi(companyId, zxsId, chengShiId);

            return dalRetCode;
        }

        /// <summary>
        /// 获取省份信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MShengFenInfo> GetShengFens(int companyId, EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo chaXun)
        {
            if (companyId < 1) return null;

            return _dal.GetShengFens(companyId, chaXun);
        }

        /// <summary>
        /// 获取城市信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.MChengShiInfo> GetChengShis(int companyId, EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo chaXun)
        {
            if (companyId < 1) return null;

            return _dal.GetChengShis(companyId, chaXun);
        }

        /// <summary>
        /// 设置城市类型，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chengShiId">城市编号</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public int SheZhiLeiXing(int companyId, int chengShiId, EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing leiXing)
        {
            if (companyId < 1 || chengShiId < 1) return 0;

            int dalRetCode = _dal.SheZhiLeiXing(companyId, chengShiId, leiXing);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "设置城市类型";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置;
                log.EventMessage = "设置城市类型，城市编号：" + chengShiId + "，类型：" + leiXing + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }
        #endregion
    }
}
