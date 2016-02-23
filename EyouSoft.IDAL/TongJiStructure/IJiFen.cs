using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.TongJiStructure
{
    /// <summary>
    /// 统计分析-积分相关数据访问类接口
    /// </summary>
    public interface IJiFen
    {
        /// <summary>
        /// 获取积分发放明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:int:实际发放积分数]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiInfo> GetJiFenFaFangMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenFaFangMingXiChaXunInfo chaXun,out object[] heJi);
        /// <summary>
        /// 获取积分发放结算明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:int:有效积分合计][1:int:冻结积分合计][2:int:取消积分合计][3:int:结算积分合计]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiInfo> GetJiFenFaFangJieSuanMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenFaFangJieSuanMingXiChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取积分收付款明细集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息 [0:decimal:借方合计][1:decimal:贷方合计]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiInfo> GetJiFenShouFuKuanMingXis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MJiFenShouFuKanMingXiChaXunInfo chaXun,out object[] heJi);

        /// <summary>
        /// 积分结算收款登记、修改，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int JiFenJieSuanShouKuan_CU(EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo info);
        /// <summary>
        /// 积分结算收款删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="jieSuanId">结算编号</param>
        /// <returns></returns>
        int JiFenJieSuanShouKuan_D(int companyId, string zxsId, string jieSuanId);
        /// <summary>
        /// 设置积分结算收款状态
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="jieSuanId">结算编号</param>
        /// <param name="status">状态</param>
        /// <param name="info">操作人信息</param>
        /// <returns></returns>
        int SheZhiJiFenJieSuanShouKuanStatus(int companyId, string zxsId, string jieSuanId, EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus status, EyouSoft.Model.FinStructure.MOperatorInfo info);
        /// <summary>
        /// 获取积分结算收款集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MJiFenJieSuanShouKuanInfo> GetJiFenJieSuanShouKuans(int companyId, string zxsId);
        /// <summary>
        /// 获取专线商结算信息[0:int:有效积分][1:int:结算积分][2:decimal:结算已审批金额][3:decimal:结算未审批金额]
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        object[] GetZxsJieSuanXinXi(int companyId, string zxsId);
        /// <summary>
        /// 获取客户用户积分统计信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <param name="heJi">合计信息[0:int:可用积分][1:int:冻结积分][0:int:已使用积分]</param>
        /// <returns></returns>
        IList<EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenInfo> GetKeHuYongHuJiFens(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.TongJiStructure.MKeHuYongHuJiFenChaXunInfo chaXun, out object[] heJi);
    }
}
