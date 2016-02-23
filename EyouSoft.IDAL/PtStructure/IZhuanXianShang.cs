using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PtStructure
{
    /// <summary>
    /// 专线商相关interface
    /// </summary>
    public interface IZhuanXianShang
    {
        /// <summary>
        /// 专线商新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int ZhuanXianShang_CU(EyouSoft.Model.PtStructure.MZhuanXianShangInfo info);
        /// <summary>
        /// 专线商删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        int Delete(int companyId, string zxsId);
        /// <summary>
        /// 获取专线商信息
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MZhuanXianShangInfo GetInfo(string zxsId);
        /// <summary>
        /// 获取专线商集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZhuanXianShangInfo> GetZxss(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo chaXun);
        /// <summary>
        /// 设置专线商状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiStatus(int companyId, string zxsId, EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangStatus status);
        /// <summary>
        /// 设置专线商积分发放状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="status">积分发放状态</param>
        /// <returns></returns>
        int SheZhiJiFenStatus(int companyId, string zxsId,EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus status);
        /// <summary>
        /// 专线商授权
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="privs1">privs1</param>
        /// <param name="privs2">privs2</param>
        /// <param name="privs3">privs3</param>
        /// <returns></returns>
        int SheZhiPrivs(int companyId, string zxsId, string privs1, string privs2, string privs3);

        /// <summary>
        /// 专线商积分结算新增、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int JiFenJieSuan_CU(EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo info);
        /// <summary>
        /// 删除专线商积分结算信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <returns></returns>
        int DeleteJiFenJieSuan(int companyId, string jiFenJieSuanId);
        /// <summary>
        /// 获取专线商积分结算信息
        /// </summary>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <returns></returns>
        EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo GetJiFenJieSuanInfo(string jiFenJieSuanId);
        /// <summary>
        /// 获取专线商积分结算集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MFinJiFenJieSuanInfo> GetJiFenJieSuans(int companyId, string zxsId);
        /// <summary>
        /// 设置专线商积分结算状态，返回1成功，其它失败
        /// </summary>
        /// <param name="jiFenJieSuanId">积分结算编号</param>
        /// <param name="shouKuanStatus">收款状态</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int SheZhiJiFenJieSuanStatus(string jiFenJieSuanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus shouKuanStatus, EyouSoft.Model.FinStructure.MOperatorInfo info);

        /// <summary>
        /// 获取专线商(简)信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MZxsInfo> GetZxss1(int companyId, EyouSoft.Model.PtStructure.MZhuanXianShangChaXunInfo chaXun);
        /// <summary>
        /// 获取专线商积分发放状态
        /// </summary>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus GetZxsJiFenStatus(string zxsId);

        /// <summary>
        /// 获取AJAX自动完成专线商信息信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户单位编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsInfo> GetAutocompleteZxss(int companyId, string keHuId, EyouSoft.Model.PtStructure.MAjaxAutocompleteZxsChaXunInfo chaXun);
    }
}
