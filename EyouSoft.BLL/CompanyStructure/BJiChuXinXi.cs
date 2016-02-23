//公司基础信息相关业务逻辑类 汪奇志 2013-01-06 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;
using EyouSoft.Model.EnumType.CompanyStructure;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 公司基础信息相关业务逻辑类
    /// </summary>
    public class BJiChuXinXi : BLLBase
    {
        private readonly EyouSoft.IDAL.CompanyStructure.IJiChuXinXi dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.CompanyStructure.IJiChuXinXi>();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BJiChuXinXi() { }
        #endregion

        #region public members
        /// <summary>
        /// 写入公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">业务实体</param>
        /// <returns></returns>
        public int Insert(MJiChuXinXiInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.Name)) return 0;
            info.IssueTime = DateTime.Now;

            if (info.Type == JiChuXinXiType.去程时间
               || info.Type == JiChuXinXiType.回程时间
               || info.Type == JiChuXinXiType.其它收入项目
               || info.Type == JiChuXinXiType.其它支出项目)
            {
                info.ZxsId = string.Empty;
            }

            return dal.JiChuXinXi_CU(info);
        }

        /// <summary>
        /// 获取公司基础信息业务实体
        /// </summary>
        /// <param name="id">自增编号</param>
        /// <returns></returns>
        public MJiChuXinXiInfo GetInfo(int id)
        {
            if (id < 1) return null;

            return dal.GetInfo(id);
        }

        /// <summary>
        /// 更新公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">业务实体</param>
        /// <returns></returns>
        public int Update(MJiChuXinXiInfo info)
        {
            if (info == null || info.CompanyId < 1 || info.OperatorId < 1 || string.IsNullOrEmpty(info.Name) || info.Id < 1) return 0;
            info.IssueTime = DateTime.Now;

            return dal.JiChuXinXi_CU(info);
        }

        /// <summary>
        /// 删除公司基础信息，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="id">自增编号</param>
        /// <returns></returns>
        public int Delete(int companyId, int id)
        {
            if (companyId < 1 || id < 1) return 0;

            return dal.Delete(companyId, id);
        }

        /*/// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<MJiChuXinXiInfo> GetJiChuXinXis(int companyId, JiChuXinXiType type,string zxsId)
        {
            return GetJiChuXinXis(companyId, type, null, zxsId);
        }*/

        /// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="t1">t1</param>
        /// <param name="zxsId">专线商编号</param>
        /// <returns></returns>
        public IList<MJiChuXinXiInfo> GetJiChuXinXis(int companyId, JiChuXinXiType type, EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1? t1, string zxsId)
        {
            if (companyId < 1) return null;

            if (type == JiChuXinXiType.去程时间
                || type == JiChuXinXiType.回程时间
                || type == JiChuXinXiType.其它收入项目
                || type == JiChuXinXiType.其它支出项目)
            {
                zxsId = string.Empty;
            }

            return dal.GetJiChuXinXis(companyId, type, t1, zxsId);
        }

        /// <summary>
        /// 获取公司基础信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="type">类型</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询实体</param>
        /// <returns></returns>
        public IList<MJiChuXinXiInfo> GetJiChuXinXis(int companyId, JiChuXinXiType type, int pageSize, int pageIndex, ref int recordCount, MJiChuXinXiChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            if (type == JiChuXinXiType.去程时间 
                || type == JiChuXinXiType.回程时间 
                || type == JiChuXinXiType.其它收入项目 
                || type == JiChuXinXiType.其它支出项目)
            {
                if (chaXun != null) chaXun.ZxsId = string.Empty;
            }

            return dal.GetJiChuXinXis(companyId, type, pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
