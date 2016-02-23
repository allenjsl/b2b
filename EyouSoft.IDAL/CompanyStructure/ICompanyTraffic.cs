using System.Collections.Generic;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 公司交通信息
    /// </summary>
    public interface ICompanyTraffic
    {
        /// <summary>
        /// 验证交通名称是否已经存在，存在返回true
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="name">要验证的交通名称</param>
        /// <param name="id">要排除的交通交通编号</param>
        /// <returns></returns>
        bool ExistsTrafficName(int companyId, string name, int id);

        /// <summary>
        /// 验证交通是否被使用
        /// </summary>
        /// <param name="ids">交通编号</param>
        /// <returns>返回已经被使用的编号数组</returns>
        int[] ExistsTraffic(params int[] ids);

        /// <summary>
        /// 添加公司交通信息
        /// </summary>
        /// <param name="model">交通信息实体</param>
        /// <returns>返回1成功，其他失败</returns>
        int AddTraffic(Model.CompanyStructure.CompanyTraffic model);

        /// <summary>
        /// 修改公司交通信息
        /// </summary>
        /// <param name="model">交通信息实体</param>
        /// <returns>返回1成功，其他失败</returns>
        int UpdateTraffic(Model.CompanyStructure.CompanyTraffic model);

        /// <summary>
        /// 删除公司交通信息
        /// </summary>
        /// <param name="ids">交通编号</param>
        /// <returns>返回1成功，其他失败</returns>
        /// <remarks>
        /// 批量删除的情况下，有用到的交通不会被删除且没有提示
        /// </remarks>
        int DeleteTraffic(params int[] ids);

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="id">交通编号</param>
        /// <returns></returns>
        Model.CompanyStructure.CompanyTraffic GetModel(int id);

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.CompanyTraffic> GetList(int companyId, int pageSize, int pageIndex, ref int recordCount);

        /// <summary>
        /// 获取交通信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.CompanyTraffic> GetList(int companyId);
    }
}
