using System;
using System.Collections.Generic;
using EyouSoft.Model.CompanyStructure;
using System.Linq;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 公司交通信息
    /// </summary>
    public class BCompanyTraffic : BLLBase
    {
        private readonly IDAL.CompanyStructure.ICompanyTraffic _dal =
            Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ICompanyTraffic>();
        private readonly SysHandleLogs _handleLogsBll = new SysHandleLogs();

        /// <summary>
        /// 添加公司交通信息
        /// </summary>
        /// <param name="model">交通信息实体</param>
        /// <returns>返回1成功，其他失败; -2 交通名称已经存在</returns>
        public int AddTraffic(CompanyTraffic model)
        {
            if (model.CompanyId <= 0 || string.IsNullOrEmpty(model.TrafficName)) return 0;

            if (_dal.ExistsTrafficName(model.CompanyId, model.TrafficName, 0))
            {
                return -2;
            }

            int r = _dal.AddTraffic(model);
            if (r == 1)
            {
                _handleLogsBll.Add(new Model.CompanyStructure.SysHandleLogs
                    {
                        ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置,
                        EventCode = SysHandleLogsNO.EventCode,
                        EventMessage =
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                            + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + "添加了交通信息，编号为" + model.TrafficId + "，名称为"
                            + model.TrafficId,
                        EventTitle = "添加" + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + "交通信息"
                    });
            }

            return r;
        }

        /// <summary>
        /// 修改公司交通信息
        /// </summary>
        /// <param name="model">交通信息实体</param>
        /// <returns>返回1成功，其他失败，-2 交通名称已经存在;-3 交通已经被使用</returns>
        public int UpdateTraffic(CompanyTraffic model)
        {
            if (model.TrafficId <= 0 || string.IsNullOrEmpty(model.TrafficName)) return 0;

            if (_dal.ExistsTrafficName(model.CompanyId, model.TrafficName, model.TrafficId))
            {
                return -2;
            }

            var ycz = _dal.ExistsTraffic(model.TrafficId);
            if (ycz != null && ycz.Any())
            {
                return -3;
            }

            int r = _dal.UpdateTraffic(model);
            if (r == 1)
            {
                _handleLogsBll.Add(new Model.CompanyStructure.SysHandleLogs
                {
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置,
                    EventCode = SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + "修改了交通信息，编号为" + model.TrafficId + "，名称为"
                        + model.TrafficId,
                    EventTitle = "修改" + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + "交通信息"
                });
            }

            return r;
        }

        /// <summary>
        /// 删除公司交通信息
        /// </summary>
        /// <param name="ids">交通编号</param>
        /// <returns>返回1成功，其他失败
        /// 返回 -2  表示单个删除的时候，交通又使用，删除失败
        /// 返回 -3 表示多个删除的时候，已使用的没有删除，没有使用的已经删除成功
        /// </returns>
        /// <remarks>
        /// 批量删除的情况下，有用到的交通不会被删除且没有提示
        /// </remarks>
        public int DeleteTraffic(params int[] ids)
        {
            if (ids == null || ids.Length <= 0) return 0;

            int r;
            var ycz = _dal.ExistsTraffic(ids);
            if (ycz != null && ycz.Any())
            {
                if (ids.Length == 1 && ycz.Length == 1)
                {
                    r = -2;
                    return r;
                }

                ids = ids.Where(t => (!ycz.Contains(t))).ToArray();
                r = _dal.DeleteTraffic(ids);
                if (r == 1) r = -3;
            }
            else
            {
                r = _dal.DeleteTraffic(ids);
            }
            if (r == 1)
            {
                _handleLogsBll.Add(new Model.CompanyStructure.SysHandleLogs
                {
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置,
                    EventCode = SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + "删除了交通信息，编号为" + this.GetIdsByArr(ids),
                    EventTitle = "删除" + Model.EnumType.PrivsStructure.Privs2.系统设置_基础设置 + "交通信息"
                });
            }

            return r;
        }

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<CompanyTraffic> GetList(int companyId, int pageSize, int pageIndex, ref int recordCount)
        {
            if (companyId <= 0 || pageSize <= 0 || pageIndex <= 0) return null;

            return _dal.GetList(companyId, pageSize, pageIndex, ref recordCount);
        }

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        public IList<CompanyTraffic> GetList(int companyId)
        {
            if (companyId <= 0) return null;

            return _dal.GetList(companyId);
        }

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="id">交通编号</param>
        /// <returns></returns>
        public CompanyTraffic GetModel(int id)
        {
            if (id <= 0) return null;

            return _dal.GetModel(id);
        }
    }
}
