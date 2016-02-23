using System;
using System.Collections.Generic;
using System.Linq;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 资源管理业务逻辑类
    /// </summary>
    public class CompanySupplier : BLLBase
    {
        private readonly IDAL.CompanyStructure.ICompanySupplier _dal =
            Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ICompanySupplier>();
        private readonly SysHandleLogs _handleLogs = new SysHandleLogs();

        #region 地接业务

        /// <summary>
        /// 添加地接社
        /// </summary>
        /// <param name="model">地接社实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddSupplierLocal(Model.CompanyStructure.SupplierLocal model)
        {
            if (model == null || string.IsNullOrEmpty(model.UnitName)) return 0;

            model.Id = Guid.NewGuid().ToString();
            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.地接;

            int r = _dal.AddSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                        {
                            ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_地接社,
                            EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                            EventMessage =
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                                + Model.EnumType.PrivsStructure.Privs2.资源管理_地接社 + "添加了地接社，编号为" + model.Id + "，名称为"
                                + model.UnitName,
                            EventTitle = "添加" + Model.EnumType.PrivsStructure.Privs2.资源管理_地接社 + "数据"
                        });
            }

            return r;
        }

        /// <summary>
        /// 修改地接社
        /// </summary>
        /// <param name="model">地接社实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateSupplierLocal(Model.CompanyStructure.SupplierLocal model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id)) return 0;

            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.地接;

            int r = _dal.UpdateSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_地接社,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_地接社 + "修改了地接社，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "修改" + Model.EnumType.PrivsStructure.Privs2.资源管理_地接社 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 删除地接社
        /// </summary>
        /// <param name="id">地接社编号</param>
        /// <returns>返回1成功，其他失败,返回-101表示地接社被使用，不允许删除</returns>
        public int DeleteSupplierLocal(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;

            var list = _dal.ExistsYsy(id);
            if (list != null && list.Any()) return -101;

            int r = _dal.DeleteSupplier(id);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_地接社,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_地接社 + "删除了地接社，编号为" + id,
                        EventTitle = "删除" + Model.EnumType.PrivsStructure.Privs2.资源管理_地接社 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 获取地接社信息
        /// </summary>
        /// <param name="id">地接社编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.SupplierLocal GetSupplierLocal(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return (Model.CompanyStructure.SupplierLocal)_dal.GetSupplier(id);
        }

        /// <summary>
        /// 获取地接信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">地接社查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.SupplierLocal> GetSupplierLocal(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QuerySupplierLocal model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            return _dal.GetSupplierLocal(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        #endregion

        #region 票务业务

        /// <summary>
        /// 添加票务
        /// </summary>
        /// <param name="model">票务实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddSupplierTicket(Model.CompanyStructure.SupplierTicket model)
        {
            if (model == null || string.IsNullOrEmpty(model.UnitName)) return 0;

            model.Id = Guid.NewGuid().ToString();
            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.票务;

            int r = _dal.AddSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_票务,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_票务 + "添加了票务，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "添加" + Model.EnumType.PrivsStructure.Privs2.资源管理_票务 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 修改票务
        /// </summary>
        /// <param name="model">票务实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateSupplierTicket(Model.CompanyStructure.SupplierTicket model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id)) return 0;

            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.票务;

            int r = _dal.UpdateSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_票务,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_票务 + "修改了票务，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "修改" + Model.EnumType.PrivsStructure.Privs2.资源管理_票务 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 删除票务
        /// </summary>
        /// <param name="id">票务编号</param>
        /// <returns>返回1成功，其他失败,返回-101表示票务被使用，不允许删除</returns>
        public int DeleteSupplierTicket(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;

            var list = _dal.ExistsYsy(id);
            if (list != null && list.Any()) return -101;

            int r = _dal.DeleteSupplier(id);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_票务,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_票务 + "删除了票务，编号为" + id,
                        EventTitle = "删除" + Model.EnumType.PrivsStructure.Privs2.资源管理_票务 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 获取票务信息
        /// </summary>
        /// <param name="id">票务编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.SupplierTicket GetSupplierTicket(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return (Model.CompanyStructure.SupplierTicket)_dal.GetSupplier(id);
        }

        /// <summary>
        /// 获取票务信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">票务查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.SupplierTicket> GetSupplierTicket(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QuerySupplierTicket model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            return _dal.GetSupplierTicket(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        #endregion

        #region 酒店业务

        /// <summary>
        /// 添加酒店
        /// </summary>
        /// <param name="model">酒店实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddSupplierHotel(Model.CompanyStructure.SupplierHotel model)
        {
            if (model == null || string.IsNullOrEmpty(model.UnitName)) return 0;

            model.Id = Guid.NewGuid().ToString();
            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.酒店;

            int r = _dal.AddSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_酒店,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_酒店 + "添加了酒店，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "添加" + Model.EnumType.PrivsStructure.Privs2.资源管理_酒店 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 修改酒店
        /// </summary>
        /// <param name="model">酒店实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateSupplierHotel(Model.CompanyStructure.SupplierHotel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id)) return 0;

            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.酒店;

            int r = _dal.UpdateSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_酒店,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_酒店 + "修改了酒店，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "修改" + Model.EnumType.PrivsStructure.Privs2.资源管理_酒店 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 删除酒店
        /// </summary>
        /// <param name="id">酒店编号</param>
        /// <returns>返回1成功，其他失败,返回-101表示酒店被使用，不允许删除</returns>
        public int DeleteSupplierHotel(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;

            var list = _dal.ExistsYsy(id);
            if (list != null && list.Any()) return -101;

            int r = _dal.DeleteSupplier(id);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_酒店,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_酒店 + "删除了酒店，编号为" + id,
                        EventTitle = "删除" + Model.EnumType.PrivsStructure.Privs2.资源管理_酒店 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="id">酒店编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.SupplierHotel GetSupplierHotel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return (Model.CompanyStructure.SupplierHotel)_dal.GetSupplier(id);
        }

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">酒店查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.SupplierHotel> GetSupplierHotel(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QuerySupplierHotel model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            return _dal.GetSupplierHotel(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        /// <summary>
        /// 获取供应商信息业务实体
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.SupplierBasic GetInfo(string gysId)
        {
            return _dal.GetSupplier(gysId);
        }
        #endregion

        #region 景点业务

        /// <summary>
        /// 添加景点
        /// </summary>
        /// <param name="model">景点实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddSupplierSpo(Model.CompanyStructure.SupplierSpot model)
        {
            if (model == null || string.IsNullOrEmpty(model.UnitName)) return 0;

            model.Id = Guid.NewGuid().ToString();
            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.景点;

            int r = _dal.AddSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_景点,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_景点 + "添加了景点，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "添加" + Model.EnumType.PrivsStructure.Privs2.资源管理_景点 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 修改景点
        /// </summary>
        /// <param name="model">景点实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateSupplierSpot(Model.CompanyStructure.SupplierSpot model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id)) return 0;

            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.景点;

            int r = _dal.UpdateSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_景点,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_景点 + "修改了景点，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "修改" + Model.EnumType.PrivsStructure.Privs2.资源管理_景点 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 删除景点
        /// </summary>
        /// <param name="id">景点编号</param>
        /// <returns>返回1成功，其他失败,返回-101表示景点被使用，不允许删除</returns>
        public int DeleteSupplierSpot(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;

            var list = _dal.ExistsYsy(id);
            if (list != null && list.Any()) return -101;

            int r = _dal.DeleteSupplier(id);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_景点,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_景点 + "删除了景点，编号为" + id,
                        EventTitle = "删除" + Model.EnumType.PrivsStructure.Privs2.资源管理_景点 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="id">景点编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.SupplierSpot GetSupplierSpot(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return (Model.CompanyStructure.SupplierSpot)_dal.GetSupplier(id);
        }

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">景点查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.SupplierSpot> GetSupplierSpot(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QuerySupplierSpot model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            return _dal.GetSupplierSpot(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        #endregion

        #region 其他业务

        /// <summary>
        /// 添加其他
        /// </summary>
        /// <param name="model">其他实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int AddSupplierOther(Model.CompanyStructure.SupplierOther model)
        {
            if (model == null || string.IsNullOrEmpty(model.UnitName)) return 0;

            model.Id = Guid.NewGuid().ToString();
            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.其他;

            int r = _dal.AddSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_其它,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_其它 + "添加了其他数据，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "添加" + Model.EnumType.PrivsStructure.Privs2.资源管理_其它 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 修改其他
        /// </summary>
        /// <param name="model">其他实体</param>
        /// <returns>返回1成功，其他失败</returns>
        public int UpdateSupplierOther(Model.CompanyStructure.SupplierOther model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id)) return 0;

            model.SupplierType = Model.EnumType.CompanyStructure.SupplierType.其他;

            int r = _dal.UpdateSupplier(model);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_其它,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_其它 + "修改了其他资源，编号为" + model.Id + "，名称为"
                            + model.UnitName,
                        EventTitle = "修改" + Model.EnumType.PrivsStructure.Privs2.资源管理_其它 + "资源数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 删除其它
        /// </summary>
        /// <param name="id">其它编号</param>
        /// <returns>返回1成功，其他失败,返回-101表示其它被使用，不允许删除</returns>
        public int DeleteSupplierOther(string id)
        {
            if (string.IsNullOrEmpty(id)) return 0;

            var list = _dal.ExistsYsy(id);
            if (list != null && list.Any()) return -101;

            int r = _dal.DeleteSupplier(id);
            if (r == 1)
            {
                _handleLogs.Add(
                    new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.资源管理_其它,
                        EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.资源管理_其它 + "删除了其他资源，编号为" + id,
                        EventTitle = "删除" + Model.EnumType.PrivsStructure.Privs2.资源管理_其它 + "数据"
                    });
            }

            return r;
        }

        /// <summary>
        /// 获取其它信息
        /// </summary>
        /// <param name="id">其它编号</param>
        /// <returns></returns>
        public Model.CompanyStructure.SupplierOther GetSupplierOther(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return (Model.CompanyStructure.SupplierOther)_dal.GetSupplier(id);
        }

        /// <summary>
        /// 获取其他信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">其他查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.SupplierOther> GetSupplierOther(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QuerySupplierOther model)
        {
            if (companyId <= 0 || pageIndex <= 0 || pageSize <= 0) return null;

            return _dal.GetSupplierOther(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        #endregion

        /// <summary>
        /// 根据供应商编号获取联系人集合
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.SupplierContact> GetSupplierContactById(string Id)
        {
            return _dal.GetSupplierContactById(Id);
        }

        /// <summary>
        /// (管理系统)供应商联系人用户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="yongHuMing">用户名</param>
        /// <param name="miMa">密码</param>
        /// <param name="md5MiMa">MD5密码</param>
        /// <returns></returns>
        public int GysLxrYongHu_CU(string gysId, int lxrId, int yongHuId, int caoZuoRenId, string yongHuMing, string miMa, string md5MiMa)
        {
            if (string.IsNullOrEmpty(gysId) || lxrId < 1 || string.IsNullOrEmpty(yongHuMing)) return 0;
            if (yongHuId == 0 && (string.IsNullOrEmpty(miMa) || string.IsNullOrEmpty(md5MiMa))) return 0;

            int dalRetCode = _dal.GysLxrYongHu_CU(gysId, lxrId, caoZuoRenId, yongHuMing, miMa, md5MiMa);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "供应商联系人用户管理";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "供应商联系人用户管理，供应商编号：" + gysId + "，联系人编号：" + lxrId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }

        /// <summary>
        /// (管理系统)供应商联系人用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public int GysLxrYonHu_D(string gysId, int lxrId, int yongHuId)
        {
            if (string.IsNullOrEmpty(gysId) || lxrId < 1 || yongHuId < 1) return 0;

            int dalRetCode = _dal.GysLxrYonHu_D(gysId, lxrId, yongHuId);
            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "供应商联系人用户删除";
                log.ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.客户管理_客户管理;
                log.EventMessage = "供应商联系人用户删除，供应商编号：" + gysId + "，联系人编号：" + lxrId;

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }
            return dalRetCode;
        }
    }
}
