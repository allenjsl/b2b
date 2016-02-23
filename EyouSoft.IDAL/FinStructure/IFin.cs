//财务管理相关数据访问类接口 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理相关数据访问类接口
    /// </summary>
    public interface IFin
    {
        /// <summary>
        /// 获取银行余额信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="time">截止时间</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        IList<MYinHangYuEInfo> GetYinHangYuE(int companyId,DateTime time,string zxsId);
        /// <summary>
        /// 获取银行明细信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:借方金额合计][1:decimal:贷方金额合计]</param>
        /// <returns></returns>
        IList<MYinHangMingXiInfo> GetYinHangMingXi(int companyId, int pageSize, int pageIndex, ref int recordCount, MYinHangMingXiChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取订单中心列表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:int:占位数合计][4:decimal:订单金额合计][5:int:婴儿数量合计]</param>
        /// <returns></returns>
        IList<MOrderInfo> GetOrders(int companyId, int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取销售收款列表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:int:占位数合计][4:decimal:订单金额合计][5:decimal:收款已审核金额合计][6:decimal:收款未审核金额合计][7:decimal:退款已审核金额合计][8:decimal:退款未审核金额合计][9:int:婴儿人数合计]</param>
        /// <returns></returns>
        IList<MYingShouInfo> GetYingShou(int companyId, int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取应付地接费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:decimal:结算金额合计][4:decimal:已支付金额合计][5:decimal:已审批金额合计][6:decimal:未审批金额合计],[7:int:婴儿数合计]</param>
        /// <returns></returns>
        IList<MYingFuDiJieInfo> GetYingFuDiJie(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取应付交通费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:出票数合计][1:decimal:结算金额合计][2:decimal:已支付金额合计][3:decimal:已审批金额合计][4:decimal:未审批金额合计]</param>
        /// <returns></returns>
        IList<MYingFuJiaoTongInfo> GetYingFuJiaoTong(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取应付酒店费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:结算金额合计][1:decimal:已支付金额合计][2:decimal:已审批金额合计][3:decimal:未审批金额合计]</param>
        /// <returns></returns>
        IList<MYingFuJiuDianInfo> GetYingFuJiuDian(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取押金登记表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:押金金额合计][1:decimal:已支付押金金额合计][2:decimal:已审批押金金额合计][3:decimal:未审批押金金额合计][4:decimal:应退押金金额合计][5:decimal:已审批退回押金金额合计][6:decimal:未审批退回押金金额合计]</param>
        /// <returns></returns>
        IList<MYaJinInfo> GetYaJins(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取退票登记表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:退票人数合计][1:decimal:损失金额合计][2:decimal:应退金额合计][3:decimal:已审批金额][4:decimal:未审批金额]</param>
        /// <returns></returns>
        IList<MTuiPiaoInfo> GetTuiPiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取应付金额信息，[0:decimal:结算金额][1:decimal:已支付金额][2:decimal:已审批金额][3:decimal:未审批金额]
        /// </summary>
        /// <param name="xmid">支出项目编号</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        decimal[] GetYingFuJinE(string xmid, KuanXiangType kuanXiangType);
        /// <summary>
        /// 获取应收金额信息，[0:decimal:应收金额][1:decimal:已审批金额][2:decimal:未审批金额]
        /// </summary>
        /// <param name="xmid">收入项目编号</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        decimal[] GetYingShouJinE(string xmid, KuanXiangType kuanXiangType);
        /// <summary>
        /// 获取控位收入信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        IList<MKongWeiShouRuInfo> GetKongWeiShouRus(string kongWeiId);
        /// <summary>
        /// 获取控位支出信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        IList<MKongWeiZhiChuInfo> GetKongWeiZhiChus(string kongWeiId);
        /// <summary>
        /// 获取团队结算汇总表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息,[0:decimal:收入金额合计][1:decimal:其它收入金额合计][2:decimal:支出金额合计][3:decimal:其它支出金额合计][4:int:数量合计][5:int:占位数量合计]</param>
        /// <returns></returns>
        IList<MTuanDuiJieSuanInfo> GetTuanDuiJieSuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MTuanDuiJieSuanChaXunInfo chaXun, out object[] heJi);
        /// <summary>
        /// 获取催款单集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MCuiKuanDanInfo> GetCuiKuanDans(int companyId, MCuiKuanDanChaXunInfo chaXun);
    }
}
