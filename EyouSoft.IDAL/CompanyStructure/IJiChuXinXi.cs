//公司基础信息相关数据访问类接口 汪奇志 2013-01-06 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.EnumType.CompanyStructure;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 公司基础信息相关数据访问类接口
    /// </summary>
    public interface IJiChuXinXi
    {
        /*/// <summary>
        /// 写入公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">业务实体</param>
        /// <returns></returns>
        int Insert(MJiChuXinXiInfo info);*/
        /// <summary>
        /// 获取公司基础信息业务实体
        /// </summary>
        /// <param name="id">自增编号</param>
        /// <returns></returns>
        MJiChuXinXiInfo GetInfo(int id);
        /*/// <summary>
        /// 更新公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">业务实体</param>
        /// <returns></returns>
        int Update(MJiChuXinXiInfo info);*/
        /// <summary>
        /// 删除公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">自增编号</param>
        /// <returns></returns>
        int Delete(int companyId, int id);
        /// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="t1">t1</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<MJiChuXinXiInfo> GetJiChuXinXis(int companyId, JiChuXinXiType type, EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1? t1,string zxsId);
        /// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        IList<MJiChuXinXiInfo> GetJiChuXinXis(int companyId, JiChuXinXiType type, int pageSize, int pageIndex, ref int recordCount, MJiChuXinXiChaXunInfo chaXun);
        /// <summary>
        /// 公司基础信息添加、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">puws</param>
        /// <returns></returns>
        int JiChuXinXi_CU(EyouSoft.Model.CompanyStructure.MJiChuXinXiInfo info);
    }
}
