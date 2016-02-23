using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 供应商数据接口
    /// </summary>
    public interface ICompanySupplier
    {
        /// <summary>
        /// 验证供应商是否已被使用，返回被使用的供应商编号集合
        /// </summary>
        /// <param name="ids">要验证的供应商编号集合</param>
        /// <returns></returns>
        string[] ExistsYsy(params string[] ids);

        /// <summary>
        /// 添加供应商信息
        /// </summary>
        /// <param name="model">供应商信息基类</param>
        /// <returns>返回1成功，其他失败</returns>
        int AddSupplier(Model.CompanyStructure.SupplierBasic model);

        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="model">供应商信息基类</param>
        /// <returns>返回1成功，其他失败</returns>
        int UpdateSupplier(Model.CompanyStructure.SupplierBasic model);

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="ids">供应商编号集合</param>
        /// <returns>返回1成功，其他失败</returns>
        int DeleteSupplier(params string[] ids);

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="id">供应商编号</param>
        /// <returns></returns>
        Model.CompanyStructure.SupplierBasic GetSupplier(string id);

        /// <summary>
        /// 获取地接信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">地接社查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.SupplierLocal> GetSupplierLocal(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.CompanyStructure.QuerySupplierLocal model);

        /// <summary>
        /// 获取票务信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">票务查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.SupplierTicket> GetSupplierTicket(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.CompanyStructure.QuerySupplierTicket model);

        /// <summary>
        /// 获取酒店信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">酒店查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.SupplierHotel> GetSupplierHotel(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.CompanyStructure.QuerySupplierHotel model);

        /// <summary>
        /// 获取景点信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">景点查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.SupplierSpot> GetSupplierSpot(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.CompanyStructure.QuerySupplierSpot model);

        /// <summary>
        /// 获取其他信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="model">其他查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.SupplierOther> GetSupplierOther(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.CompanyStructure.QuerySupplierOther model);

        /// <summary>
        /// 根据供应商编号获取联系人集合
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.SupplierContact> GetSupplierContactById(string Id);

        /// <summary>
        /// (管理系统)供应商联系人用户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <param name="yongHuMing">用户名</param>
        /// <param name="miMa">密码</param>
        /// <param name="md5MiMa">MD5密码</param>
        /// <returns></returns>
        int GysLxrYongHu_CU(string gysId, int lxrId, int caoZuoRenId, string yongHuMing, string miMa, string md5MiMa);
        /// <summary>
        /// (管理系统)供应商联系人用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        int GysLxrYonHu_D(string gysId, int lxrId, int yongHuId);
    }
}
