//财务管理-工资管理相关数据访问类接口 汪奇志 2013-08-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.FinStructure
{
    /// <summary>
    /// 财务管理-工资管理相关数据访问类接口
    /// </summary>
    public interface IGongZi
    {
        /// <summary>
        /// 是否存在相同的工资年月份信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yuanGongId">员工编号</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="faFangLeiXing">工资发放类型</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        bool IsExists(int companyId, int yuanGongId, int year, int month, string gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiFaFangLeiXing faFangLeiXing,string zxsId);
        /// <summary>
        /// 写入工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.FinStructure.MGongZiInfo info);
        /// <summary>
        /// 修改工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.FinStructure.MGongZiInfo info);
        /// <summary>
        /// 删除工资信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="gongZiId">工资编号</param>
        /// <returns></returns>
        int Delete(int companyId, string gongZiId);
        /// <summary>
        /// 设置工资状态
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <param name="status">状态</param>
        /// <param name="operatorInfo">操作人信息</param>
        /// <param name="zhangHuId">银行账户编号</param>
        /// <param name="bankDate">银行实际业务日期</param>
        /// <returns></returns>
        int SetStatus(string gongZiId, EyouSoft.Model.EnumType.FinStructure.GongZiStatus status, EyouSoft.Model.FinStructure.MOperatorInfo operatorInfo, string zhangHuId, DateTime? bankDate);
        /// <summary>
        /// 获取工资信息业务实体
        /// </summary>
        /// <param name="gongZiId">工资编号</param>
        /// <returns></returns>
        EyouSoft.Model.FinStructure.MGongZiInfo GetInfo(string gongZiId);
        /// <summary>
        /// 获取工资信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <param name="heJi">合计信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.FinStructure.MGongZiInfo> GetGongZis(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.FinStructure.MGongZiChaXunInfo chaXun, out EyouSoft.Model.FinStructure.MGongZiHeJiInfo heJi);
    }
}
