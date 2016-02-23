//供应商主体相关interface 汪奇志 2015-05-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.GysStructure
{
    /// <summary>
    /// 供应商主体相关interface
    /// </summary>
    public interface IGysZhuTi
    {
        /// <summary>
        /// 供应商主体新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int GysZhuTi_CU(EyouSoft.Model.GysStructure.MGysZhuTiInfo info);
        /// <summary>
        /// 供应商主体删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        int GysZhuTi_D(int companyId, string gysId);
        /// <summary>
        /// 获取供应商主体信息业务实体
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        EyouSoft.Model.GysStructure.MGysZhuTiInfo GetInfo(string gysId);
        /// <summary>
        /// 获取供应商主体信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.GysStructure.MGysZhuTiInfo> GetGysZhuTis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiChaXunInfo chaXun);
        /// <summary>
        /// 获取供应商主体联系人信息集合
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo> GetGysLxrs(string gysId);
        /// <summary>
        /// 供应商主体联系人信息新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int GysZhuTi_Lxr_CU(EyouSoft.Model.GysStructure.MGysZhuTiLxrInfo info);
        /// <summary>
        /// 供应商主体联系人信息删除，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商主体编号</param>
        /// <param name="lxrId">联系人编号</param>
        /// <param name="yongHuId">联系人用户编号</param>
        /// <returns></returns>
        int GysZhuTi_lxr_D(string gysId, int lxrId, int yongHuId);

        /// <summary>
        /// 获取选用的供应商信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.GysStructure.MXuanYongGysInfo> GetXuanYongGyss(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MXuanYongGysChaXunInfo chaXun);

        /// <summary>
        /// 获取供应商主体导游信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo> GetZhuTiDaoYous(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo chaXun);

        /// <summary>
        /// 获取供应商主体导游信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.GysStructure.MGysZhuTiDaoYouInfo> GetGysDaoYous(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.GysStructure.MGysZhuTiDaoYouChaXunInfo chaXun);
         
        /// <summary>
        /// 根据供应商编号获取供应商主体编号
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        string GetGysZhuTiIdByGysId(int companyId, string gysId);
    }
}
