//财务管理相关业务逻辑 汪奇志 2012-11-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;
using EyouSoft.Model.EnumType.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 财务管理相关业务逻辑
    /// </summary>
    public class BFin:BLLBase
    {
        private readonly EyouSoft.IDAL.FinStructure.IFin dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IFin>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BFin() { }
        #endregion

        #region public members
        /// <summary>
        /// 获取银行余额信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="time">截止时间</param>
        /// <param name="heJi">余额合计</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<MYinHangYuEInfo> GetYinHangYuE(int companyId, DateTime time, out decimal heJi,string zxsId)
        {
            heJi = 0M;
            if (companyId < 1 || time == DateTime.MinValue || time == DateTime.MaxValue) return null;

            var items = dal.GetYinHangYuE(companyId, time,zxsId);

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    heJi += item.YuE;
                }
            }

            return items;
        }

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
        public IList<MYinHangMingXiInfo> GetYinHangMingXi(int companyId, int pageSize, int pageIndex, ref int recordCount, MYinHangMingXiChaXunInfo chaXun, out decimal[] heJi)
        {
            heJi = new decimal[] { 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            object[] _heJi;
            var items = dal.GetYinHangMingXi(companyId, pageSize, pageIndex, ref recordCount, chaXun, out _heJi);
            heJi[0] = (decimal)_heJi[0];
            heJi[1] = (decimal)_heJi[1];

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.ZhangHuName = new BYinHangZhangHu().GetName(item.ZhangHuId, companyId,chaXun.ZxsId);
                }
            }

            return items;
        }

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
        public IList<MOrderInfo> GetOrders(int companyId, int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0, 0M, 0 };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetOrders(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }
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
        public IList<MYingShouInfo> GetYingShou(int companyId, int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0, 0M, 0M, 0M, 0M, 0M,0 };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetYingShou(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        /// <summary>
        /// 获取销应付地接费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:成人数合计][1:int:儿童数合计][2:int:全陪数合计][3:decimal:结算金额合计][4:decimal:已支付金额合计][5:decimal:已审批金额合计][6:decimal:未审批金额合计],[7:int:婴儿数合计]</param>
        /// <returns></returns>
        public IList<MYingFuDiJieInfo> GetYingFuDiJie(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0, 0, 0M, 0M, 0M, 0M, 0 };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetYingFuDiJie(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        /// <summary>
        /// 获取销应付交通费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:int:出票数合计][1:decimal:结算金额合计][2:decimal:已支付金额合计][3:decimal:已审批金额合计][4:decimal:未审批金额合计]</param>
        /// <returns></returns>
        public IList<MYingFuJiaoTongInfo> GetYingFuJiaoTong(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0M, 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetYingFuJiaoTong(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        /// <summary>
        /// 获取销应付酒店费信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:结算金额合计][1:decimal:已支付金额合计][2:decimal:已审批金额合计][3:decimal:未审批金额合计]</param>
        /// <returns></returns>
        public IList<MYingFuJiuDianInfo> GetYingFuJiuDian(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetYingFuJiuDian(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        /// <summary>
        /// 获取销押金登记表信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <param name="heJi">合计信息[0:decimal:押金金额合计][1:decimal:已支付押金金额合计][2:decimal:已审批押金金额合计][3:decimal:未审批押金金额合计][4:decimal:应退押金金额合计][5:decimal:已审批退回押金金额合计][6:decimal:未审批退回押金金额合计]</param>
        /// <returns></returns>
        public IList<MYaJinInfo> GetYaJins(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetYaJins(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

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
        public IList<MTuiPiaoInfo> GetTuiPiaos(int companyId, int pageSize, int pageIndex, ref int recordCount, MYingFuChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0, 0M, 0M, 0M, 0M };
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetTuiPiaos(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);

            return items;
        }

        /// <summary>
        /// 获取应付金额信息，[0:decimal:结算金额][1:decimal:已支付金额][2:decimal:已审批金额][3:decimal:未审批金额]
        /// </summary>
        /// <param name="xmid">支出项目编号</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        public decimal[] GetYingFuJinE(string xmid, KuanXiangType kuanXiangType)
        {
            decimal[] jinE = { 0M, 0M, 0M, 0M };
            KuanXiangType[] _types = {KuanXiangType.地接支出付款
                                       ,KuanXiangType.订单退款
                                       ,KuanXiangType.酒店安排付款
                                       ,KuanXiangType.票务安排付款
                                       ,KuanXiangType.票务押金付款
                                       ,KuanXiangType.其它支出付款 };
            if (string.IsNullOrEmpty(xmid) || !_types.Contains(kuanXiangType)) return jinE;

            return dal.GetYingFuJinE(xmid, kuanXiangType);
        }

        /// <summary>
        /// 获取应收金额信息，[0:decimal:应收金额][1:decimal:已审批金额][2:decimal:未审批金额]
        /// </summary>
        /// <param name="xmid">收入项目编号</param>
        /// <param name="kuanXiangType">款项类型</param>
        /// <returns></returns>
        public decimal[] GetYingShouJinE(string xmid, KuanXiangType kuanXiangType)
        {
            decimal[] jinE = { 0M, 0M, 0M };

            KuanXiangType[] _types = {KuanXiangType.订单收款
                                       ,KuanXiangType.票务押金退还
                                       ,KuanXiangType.票务退款
                                       ,KuanXiangType.其它收入收款};
            if (string.IsNullOrEmpty(xmid) || !_types.Contains(kuanXiangType)) return jinE;

            return dal.GetYingShouJinE(xmid, kuanXiangType);
        }

        /// <summary>
        /// 获取控位收入信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<MKongWeiShouRuInfo> GetKongWeiShouRus(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiShouRus(kongWeiId);
        }
        /// <summary>
        /// 获取控位支出信息集合
        /// </summary>
        /// <param name="kongWeiId">控位编号</param>
        /// <returns></returns>
        public IList<MKongWeiZhiChuInfo> GetKongWeiZhiChus(string kongWeiId)
        {
            if (string.IsNullOrEmpty(kongWeiId)) return null;

            return dal.GetKongWeiZhiChus(kongWeiId);
        }

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
        public IList<MTuanDuiJieSuanInfo> GetTuanDuiJieSuans(int companyId, int pageSize, int pageIndex, ref int recordCount, MTuanDuiJieSuanChaXunInfo chaXun, out object[] heJi)
        {
            heJi = new object[] { 0M, 0M, 0M, 0M, 0, 0 };

            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;
            var items = dal.GetTuanDuiJieSuans(companyId, pageSize, pageIndex, ref recordCount, chaXun, out heJi);
            return items;
        }

        /// <summary>
        /// 获取催款单集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MCuiKuanDanInfo> GetCuiKuanDans(int companyId, MCuiKuanDanChaXunInfo chaXun)
        {
            if (companyId < 1 
                || chaXun == null 
                || string.IsNullOrEmpty(chaXun.ZxsId) 
                || string.IsNullOrEmpty(chaXun.KeHuId)) return null;

            return dal.GetCuiKuanDans(companyId, chaXun);
        }
        #endregion
    }
}
