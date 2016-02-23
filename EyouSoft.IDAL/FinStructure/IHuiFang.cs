//订单回访信息数据访问类接口 汪奇志 2012-11-23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.FinStructure;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 订单回访信息数据访问类接口
    /// </summary>
    public interface IHuiFang
    {
        /// <summary>
        /// 写入回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MHuiFangInfo info);
        /// <summary>
        /// 修改回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(MHuiFangInfo info);
        /// <summary>
        /// 删除回访信息，返回1成功，其它失败
        /// </summary>
        /// <param name="huiFangId">回访编号</param>
        /// <returns></returns>
        int Delete(string huiFangId);
        /// <summary>
        /// 获取回访信息集合
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        IList<MHuiFangInfo> GetHuiFangs(string orderId);
    }
}
