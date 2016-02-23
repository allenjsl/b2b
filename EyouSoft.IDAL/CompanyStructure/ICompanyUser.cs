using System.Collections.Generic;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 用户信息数据层接口
    /// </summary>
    public interface ICompanyUser
    {
        /// <summary>
        /// 判断E-MAIL是否已存在
        /// </summary>
        /// <param name="email">email地址</param>
        /// <param name="userId">当前修改Email的用户ID</param>
        /// <returns></returns>
        bool IsExistsEmail(string email, int userId,int companyId);
        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="companyId">当前公司编号</param>
        /// <param name="id">编号</param>
        /// <returns></returns>
        bool IsExists(int id, string userName, int companyId);
        /*/// <summary>
        /// 真实删除用户信息
        /// </summary>
        /// <param name="userIdList">用户ID列表</param>
        /// <returns></returns>
        bool Delete(params int[] userIdList);*/
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <returns>true:成功 false:失败</returns>
        bool Add(Model.CompanyStructure.CompanyUser model);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <returns>true:成功 false:失败</returns>
        bool Update(Model.CompanyStructure.CompanyUser model);
        /// <summary>
        /// 根据用户编号获取用户信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>用户实体</returns>
        Model.CompanyStructure.CompanyUser GetUserInfo(int userId);
        /*/// <summary>
        /// 根据用户名密码获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Model.CompanyStructure.CompanyUser GetUserInfo(string userName, string pwd);*/
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="password">密码实体类</param>
        /// <returns></returns>
        bool UpdatePassWord(int id, Model.CompanyStructure.PassWord password);
        /*/// <summary>
        /// 获得管理员实体信息
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        Model.CompanyStructure.CompanyUser GetAdminModel(int companyId);*/
        /// <summary>
        /// 获取指定公司下的所有帐号用户详细信息列表[注;不包括总帐号]
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总的记录数</param>
        /// <param name="model">查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.CompanyUser> GetList(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QueryCompanyUser model);
        /// <summary>
        /// 根据当前用户组织架构信息分页获取用户列表
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="model">查询实体</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.CompanyUser> GetList(int companyId, Model.CompanyStructure.QueryCompanyUser model);
        
        /// <summary>
        /// 状态设置
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="status">用户状态</param>
        /// <returns></returns>
        bool SetEnable(int id, Model.EnumType.CompanyStructure.UserStatus status);

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <param name="permissionList">权限集合</param>
        /// <returns>是否成功</returns>
        bool SetPermission(int userId, int roleId, params string[] permissionList);
        /// <summary>
        /// （平台）员工新增修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int PT_YuanGong_CU(EyouSoft.Model.CompanyStructure.CompanyUser info);

        /// <summary>
        /// （平台）获取员工信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.CompanyUser> PT_GetYuanGongs(int companyId, string keHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo chaXun);
        /// <summary>
        /// （平台）员工删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="keHuLxrId">客户联系人编号</param>
        /// <returns></returns>
        int PT_YuanGong_D(int companyId, string keHuId, int yongHuId, int keHuLxrId);
        /// <summary>
        /// 获取用户积分信息
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MYongHuJiFenInfo GetYongHuJiFenInfo(int yongHuId);

        /// <summary>
        /// 根据关键字获取用户信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="s">关键字(用户名或邮箱)</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MYongHuJianYaoXinXiInfo GetYongHuInfo(int companyId, string s);
        /// <summary>
        /// 设置用户密码，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="miMa">新密码</param>
        /// <param name="miMaMd5">新密码MD5</param>
        /// <returns></returns>
        int SheZhiMiMa(int companyId, int yongHuId, string miMa, string miMaMd5);
        /// <summary>
        /// 获取客户账号信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.CompanyUser> GetKeHuYongHus(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo chaXun);

        /// <summary>
        /// 用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        int YongHu_D(int companyId, string zxsId, int yongHuId);

        /// <summary>
        /// 获取供应商账号信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.CompanyUser> GetGysYongHus(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MGysYongHuChaXunInfo chaXun);
    }
}
