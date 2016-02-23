using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 出纳登账数据接口
    /// </summary>
    public interface IDengZhang
    {
        /// <summary>
        /// 添加出纳登账信息
        /// </summary>
        /// <param name="model">出纳登帐信息</param>
        /// <returns>返回1成功；其他失败</returns>
        int AddDengZhang(Model.FinStructure.MChuNaDengZhang model);

        /// <summary>
        /// 修改登账信息
        /// </summary>
        /// <param name="model">出纳登帐信息</param>
        /// <returns>
        /// 返回1成功；
        /// 0参数错误；
        /// -1修改失败；
        /// -2登账信息已经审批，不能修改 
        /// </returns>
        int UpdateDengZhang(Model.FinStructure.MChuNaDengZhang model);

        /// <summary>
        /// 删除出纳登账信息
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <returns>
        /// 1：成功；
        /// 0：参数错误；
        /// -1：删除失败；
        /// -2：单条删除时，要删除的登账信息已审批，不能删除；
        /// -3：多条删除时，删除没有审批的，已经审批的没有删除；
        /// </returns>
        int DeleteDengZhang(params string[] dengZhangId);

        /// <summary>
        /// 获取登账信息列表
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="search">查询实体</param>
        /// <param name="zongJinE">返回总到款金额</param>
        /// <param name="zongXiaoZhangJinE">返回总销账金额</param>
        /// <returns></returns>
        IList<Model.FinStructure.MChuNaDengZhang> GetChuNaDengZhang(
            int companyId,
            int pageSize,
            int pageIndex,
            ref int recordCount,
            Model.FinStructure.MSearchChuNaDengZhang search,
            ref decimal zongJinE,
            ref decimal zongXiaoZhangJinE);

        /// <summary>
        /// 获取登账信息实体
        /// </summary>
        /// <param name="dengZhangId">登账编号</param>
        /// <returns></returns>
        Model.FinStructure.MChuNaDengZhang GetChuNaDengZhang(string dengZhangId);

        /// <summary>
        /// 审批出纳登账信息
        /// </summary>
        /// <param name="model">审批信息实体</param>
        /// <param name="dengZhangId">登账编号</param>
        /// <returns>返回1成功；其他失败</returns>
        int ShenPiDengZhang(Model.FinStructure.MShenPiDengZhang model, params string[] dengZhangId);

        /*/// <summary>
        /// 登账信息销账处理
        /// </summary>
        /// <param name="dengZhangId">登账信息编号</param>
        /// <param name="list">销账实体集合</param>
        /// <returns>返回1成功；其他失败</returns>
        int UnCheckDengZhang(string dengZhangId, IList<Model.FinStructure.MXiaoZhang> list);*/

        /// <summary>
        /// 获取已销账信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息[0:decimal:已销账金额]</param>
        /// <returns></returns>
        IList<MYiXiaoZhangInfo> GetYiXiaoZhangs(int companyId, int pageSize, int pageIndex, ref int recordCount, MYiXiaoZhangChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 取消审批，返回1成功，其它失败
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoShenPi(string dengZhangId, int companyId, MOperatorInfo info);

        /// <summary>
        /// 冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="info">冲抵信息</param>
        /// <returns></returns>
        int ChongDi(MChongDiInfo info);

        /*/// <summary>
        /// 取消销账，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">销账编号集合</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoXiaoZhang(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info);*/

        /*/// <summary>
        /// 取消冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">冲抵编号集合</param>
        /// <param name="info">相关信息</param>
        /// <returns></returns>
        int QuXiaoChongDi(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info);*/

        /// <summary>
        /// 取消销账、冲抵，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="xiaoZhangId">销账编号、冲抵编号集合</param>        
        /// <param name="info">相关信息</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        int QuXiaoXiaoZhang(int companyId, string dengZhangId, string[] xiaoZhangId, MOperatorInfo info, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing leiXing);

        /// <summary>
        /// 获取出纳登账销账订单款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.FinStructure.MXiaoZhangDingDanKuanInfo> GetXiaoZhangDingDanKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun);
        /// <summary>
        /// 获取出纳登账销账退票款信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MXiaoZhangTuiPiaoKuanInfo> GetXiaoZhangTuiPiaoKuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun);
        /// <summary>
        /// 获取出纳登账销账退回押金信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MXiaoZhangTuiHuiYaJinInfo> GetXiaoZhangTuiHuiYaJins(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun);
        /// <summary>
        /// 获取出纳登账销账团队结算其它收入信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MXiaoZhangJieSuanQiTaShouRuInfo> GetXiaoZhangJieSuanQiTaShouRus(int companyId, int pageSize, int pageIndex, ref int recordCount, MXiaoZhangChaXunInfo chaXun);

        /// <summary>
        /// 出纳登账-销账(订单款、退票款、退回押金、团队结算其它收入)，返回1成功，其它失败
        /// </summary>
        /// <param name="dengZhangId">出纳登账编号</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="leiXing1">销账类型1</param>
        /// <param name="items">销售相关信息集合</param>
        /// <returns></returns>
        int XiaoZhang(string dengZhangId, int operatorId, EyouSoft.Model.EnumType.FinStructure.XiaoZhangLeiXing1 leiXing1, IList<MXiaoZhang> items);
    }
}
