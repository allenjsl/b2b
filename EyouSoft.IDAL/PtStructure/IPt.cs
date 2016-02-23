using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 平台相关interface
    /// </summary>
    public interface IPt
    {
        /// <summary>
        /// 设置KV信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int SheZhiKvInfo(EyouSoft.Model.PtStructure.MKvInfo info);
        /// <summary>
        /// 获取KV信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="k">key</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MKvInfo GetKvInfo(int companyId, EyouSoft.Model.EnumType.PtStructure.KvKey k);

        /// <summary>
        /// 站点新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int ZhanDian_CU(EyouSoft.Model.PtStructure.MZhanDianInfo info);
        /// <summary>
        /// 站点删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zhanDianId">站点编号</param>
        /// <returns></returns>
        int ZhanDian_D(int companyId, int zhanDianId);
        /// <summary>
        /// 获取站点信息
        /// </summary>
        /// <param name="zhanDianId">站点编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhanDianInfo GetZhanDianInfo(int zhanDianId);
        /// <summary>
        /// 获取站点集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhanDianInfo> GetZhanDians(int companyId,EyouSoft.Model.PtStructure.MZhanDianChaXunInfo chaXun);

        /// <summary>
        /// 专线类别新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int ZhuanXianLeiBie_CU(EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo info);
        /// <summary>
        /// 专线类别删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxlbId">专线类别编号</param>
        /// <returns></returns>
        int ZhuanXianLeiBie_D(int companyId, int zxlbId);
        /// <summary>
        /// 获取专线类别信息
        /// </summary>
        /// <param name="zxlbId">专线类别编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo GetZhuanXianLeiBieInfo(int zxlbId);
        /// <summary>
        /// 获取专线类别集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhuanXianLeiBieInfo> GetZhuanXianLeiBies(int companyId, EyouSoft.Model.PtStructure.MZhuanXianLeiBieChaXunInfo chaXun);

        /// <summary>
        /// 获取站点信息集合（含专线类别信息）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZhanDians1(int companyId);

        /// <summary>
        /// 获取平台域名信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="leiXing">域名类型</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MYuMingInfo> GetYuMings(int? companyId, EyouSoft.Model.EnumType.PtStructure.YuMingLeiXing? leiXing);
        /// <summary>
        /// 获取专线商站点信息集合（含专线类别信息）
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhanDianInfo1> GetZxsZhanDians(int companyId, string zxsId);

        /// <summary>
        /// 根据专线类别编号获取专线商编号
        /// </summary>
        /// <param name="zxlbId">专线类别编号</param>
        /// <param name="companyId">公司编号</param>
        /// <returns></returns>
        string GetZxsIdByZxlbId(int zxlbId, int companyId);
    }
}
