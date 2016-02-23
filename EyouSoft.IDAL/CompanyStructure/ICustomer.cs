using System.Collections.Generic;
using System;
namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 客户管理数据访问接口
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.CompanyStructure.CustomerInfo GetCustomerModel(string id);
        /// <summary>
        /// 按指定条件获取客户资料信息集合
        /// </summary>
        /// <param name="companyId">公司（专线）编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="seachInfo">查询条件业务实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.CustomerInfo> GetCustomers(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.MCustomerSeachInfo seachInfo);
        /// <summary>
        /// 客户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int KeHu_CU(EyouSoft.Model.CompanyStructure.CustomerInfo info);
        /// <summary>
        /// 删除客户，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">当前操作人ZxsId</param>
        /// <param name="keHuId">客户编号</param>
        /// <returns></returns>
        int KeHu_D(int companyId, string zxsId, string keHuId);
        /// <summary>
        /// (管理系统)客户联系人用户新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuMing">用户名</param>
        /// <param name="miMa">密码</param>
        /// <param name="md5MiMa">MD5密码</param>
        /// <param name="youXiang">邮箱</param>
        /// <returns></returns>
        int KeHuLxrYongHu_CU(string keHuId, int lxrId, string yongHuMing, string miMa, string md5MiMa,string youXiang);
        /// <summary>
        /// (管理系统)客户联系人用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        int KeHulxrYonHu_D(string keHuId, int lxrId, int yongHuId);
        /// <summary>
        /// 获取客户联系人信息
        /// </summary>
        /// <param name="keHuId">客户编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.CustomerContactInfo GetKeHuLxrInfo(string keHuId, int lxrId);

        /// <summary>
        /// 注册客户审核，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="shenHeRenId">审核人编号</param>
        /// <param name="sheHeShiJian">审核时间</param>
        /// <returns></returns>
        int ZhuCeKeHuShenHe(int companyId, string keHuId, int shenHeRenId, DateTime sheHeShiJian);

        /// <summary>
        /// （平台）客户注册，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int PT_KeHuZhuCe(EyouSoft.Model.CompanyStructure.MKeHuZhuCeInfo info);
        /// <summary>
        /// （平台）客户资料修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int PT_KeHuXiuGai(EyouSoft.Model.CompanyStructure.CustomerInfo info);

        /// <summary>
        /// 客户联系人新增修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int KeHuLxr_CU(EyouSoft.Model.CompanyStructure.CustomerContactInfo info);
        /// <summary>
        /// 客户联系人删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">操作人公司编号</param>
        /// <param name="zxsId">操作人专线商编号</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="keHulxrId">客户联系人编号</param>
        /// <returns></returns>
        int KeHuLxr_D(int companyId, string zxsId, int operatorId, string keHuId, int keHulxrId);
    }
}


