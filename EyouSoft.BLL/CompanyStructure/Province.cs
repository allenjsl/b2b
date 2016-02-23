using System;
using System.Collections.Generic;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 省份管理BLL
    /// Author xuqh 2011-01-24
    /// </summary>
    public class Province : BLLBase
    {
        private readonly IDAL.CompanyStructure.IProvince _dal = Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.IProvince>();
        private readonly SysHandleLogs _handleLogsBll = new SysHandleLogs();

        #region 成员方法
        /// <summary>
        /// 验证省份名是否已经存在
        /// </summary>
        /// <param name="provinceName">省份名称</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="provinceId">身份编号</param>
        /// <returns>true:已存在 false:不存在</returns>
        public bool IsExists(string provinceName, int companyId, int provinceId)
        {
            if (string.IsNullOrEmpty(provinceName) || companyId <= 0) return true;
            return this._dal.IsExists(provinceName, companyId, provinceId);
        }


        /// <summary>
        /// 添加省份
        /// </summary>
        /// <param name="model">省份实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.Province model)
        {
            if (model == null || string.IsNullOrEmpty(model.ProvinceName)) return false;

            bool result = this._dal.Add(model);
            if (result) this._handleLogsBll.Add(AddLogs("添加", model.Id.ToString(), model.ProvinceName));

            return result;
        }

        /// <summary>
        /// 修改省份
        /// </summary>
        /// <param name="model">省份实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(Model.CompanyStructure.Province model)
        {
            if (model == null || model.Id <= 0) return false;

            bool result = this._dal.Update(model);
            if (result) this._handleLogsBll.Add(AddLogs("修改", model.Id.ToString(), model.ProvinceName));

            return result;
        }

        /// <summary>
        /// 获取省份实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.Province GetModel(int id)
        {
            if (id <= 0) return null;

            return this._dal.GetModel(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">省份编号</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Delete(int id)
        {
            if (id < 1) return false;
            bool result = this._dal.Delete(id);
            if (result) this._handleLogsBll.Add(AddLogs("删除", id.ToString(), string.Empty));

            return result;
        }

        /// <summary>
        /// 获取某个公司所有省份的信息包括城市
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.Province> GetProvinceInfo(int companyId)
        {
            if (companyId <= 0) return null;

            return this._dal.GetProvinceInfo(companyId);
        }
        #endregion

        /// <summary>
        /// 添加日志记录
        /// </summary>
        /// <param name="actionName">操作名称</param>
        /// <param name="provinceId">操作的省份编号（可以是多个）</param>
        /// <param name="provinceName">省份名称</param>
        /// <returns></returns>
        private Model.CompanyStructure.SysHandleLogs AddLogs(string actionName, string provinceId, string provinceName)
        {
            var model = new Model.CompanyStructure.SysHandleLogs
                {
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + actionName + "了省份，编号为" + provinceId + "，名称为"
                        + provinceName,
                    EventTitle = actionName + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + " 省份"
                };

            return model;
        }
    }
}
