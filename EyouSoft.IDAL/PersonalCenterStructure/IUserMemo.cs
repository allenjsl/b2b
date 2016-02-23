using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.PersonalCenterStructure
{
    using EyouSoft.Model.PersonalCenterStructure;

    /// <summary>
    /// 个人中心-个人备忘
    /// zhengzy 2012-11-20
    /// </summary>
    public interface IUserMemo
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl">个人备忘实体</param>
        /// <returns>True：成功 False：失败</returns>
        bool Add(UserMemorandum mdl);

        /// <summary>
        ///修改
        /// </summary>
        /// <param name="mdl">个人备忘实体</param>
        /// <returns>True：成功 False：失败</returns>
        bool Upd(UserMemorandum mdl);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>True：成功 False：失败</returns>
        bool Del(int id);

        /// <summary>
        /// 获取个人备忘实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>个人备忘实体</returns>
        UserMemorandum GetMdl(int id);

        /// <summary>
        /// 获取个人备忘列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="operatorId">当前操作者编号</param>
        /// <param name="search">搜索实体</param>
        /// <returns>个人备忘列表</returns>
        IList<UserMemorandum> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, int operatorId,UserMemoSearch search);
    }
}
