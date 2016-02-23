//订单回访信息业务逻辑类 汪奇志 2012-11-23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.BLL.FinStructure
{
    /// <summary>
    /// 订单回访信息业务逻辑类
    /// </summary>
    public class BHuiFang
    {
        private readonly EyouSoft.IDAL.FinStructure.IHuiFang dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.FinStructure.IHuiFang>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BHuiFang() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MHuiFangInfo info)
        {
            if (info == null || info.OperatorId < 1 || string.IsNullOrEmpty(info.OrderId)) return 0;
            info.HuiFangId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);

            return dalRetCode;
        }
        /// <summary>
        /// 修改回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MHuiFangInfo info)
        {
            if (info == null || info.OperatorId < 1 || string.IsNullOrEmpty(info.OrderId)||string.IsNullOrEmpty(info.HuiFangId)) return 0;

            int dalRetCode = dal.Update(info);

            return dalRetCode;
        }

        /// <summary>
        /// 删除回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="huiFangId">回访编号</param>
        /// <returns></returns>
        public int Delete(string huiFangId)
        {
            if (string.IsNullOrEmpty(huiFangId)) return 0;

            int dalRetCdoe = dal.Delete(huiFangId);

            return dalRetCdoe;
        }

        /// <summary>
        /// 获取回访信息集合
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public IList<MHuiFangInfo> GetHuiFangs(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return null;

            return dal.GetHuiFangs(orderId);
        }
        #endregion
    }
}
