using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 公司产品数据层接口
    /// </summary>
    /// 鲁功源 2011-01-21
    public interface IArea
    {
        /// <summary>
        /// 获取线路区域实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        Model.CompanyStructure.Area GetModel(int id);
        /// <summary>
        /// 分页获取公司线路区域集合
        /// </summary>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns>公司线路区域集合</returns>
        IList<Model.CompanyStructure.Area> GetList(int pageSize, int pageIndex, ref int recordCount, int companyId,string zxsId);

        /// <summary>
        /// 获取专线商所有线路区域信息
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.Area> GetQuYusByZxsId(string zxsId);

        /// <summary>
        /// 获取专线商站点、专线类别、线路区域集合
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MZxsZhanDianInfo> GetZxsZhanDians(string zxsId);
        /// <summary>
        /// 获取线路区域集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<Model.CompanyStructure.Area> GetQuYus(int companyId, EyouSoft.Model.CompanyStructure.MQuYuChaXunInfo chaXun);
        /// <summary>
        /// 线路区域新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int QuYu_CU(EyouSoft.Model.CompanyStructure.Area info);
        /// <summary>
        /// 线路区域删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="quYuId">线路区域编号</param>
        /// <returns></returns>
        int QuYu_D(int companyId, string zxsId, int quYuId);
    }
}
