using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PersonalCenterStructure
{
    using EyouSoft.Model.CompanyStructure;
    using EyouSoft.Model.PersonalCenterStructure;

    /// <summary>
    /// 个人中心-个人备忘
    /// zhengzy 2012-11-20
    /// </summary>
    public class BUserMemo : EyouSoft.BLL.BLLBase
    {
        private readonly EyouSoft.IDAL.PersonalCenterStructure.IUserMemo _idal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PersonalCenterStructure.IUserMemo>();
        private readonly BLL.CompanyStructure.SysHandleLogs _handleLogsBll = new EyouSoft.BLL.CompanyStructure.SysHandleLogs();
        private readonly Model.SSOStructure.MUserInfo _currUserInfo = Security.Membership.UserProvider.GetUserInfo();

        #region IUserMemo 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mdl">个人备忘实体</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Add(UserMemorandum mdl)
        {
            if (mdl == null || mdl.CompanyId <= 0 || mdl.UserId <= 0) return false;
            var isOk = this._idal.Add(mdl);
            if (isOk)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.个人中心_个人备忘,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "新增了个人备忘！备忘编号为：" + mdl.Id,
                    EventTitle = "新增个人备忘"
                });
            }
            return isOk;
        }

        /// <summary>
        ///修改
        /// </summary>
        /// <param name="mdl">个人备忘实体</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Upd(UserMemorandum mdl)
        {
            if (mdl == null || mdl.Id <= 0) return false;
            var isOk = this._idal.Upd(mdl);
            if (isOk)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.个人中心_个人备忘,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "修改了个人备忘！备忘编号为：" + mdl.Id,
                    EventTitle = "修改个人备忘"
                });
            }
            return isOk;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>True：成功 False：失败</returns>
        public bool Del(int id)
        {
            if (id <= 0) return false;
            var isOk = this._idal.Del(id);
            if (isOk)
            {
                this._handleLogsBll.Add(new SysHandleLogs()
                {
                    ModuleId = EyouSoft.Model.EnumType.PrivsStructure.Privs2.个人中心_个人备忘,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage = "用户编号：" + this._currUserInfo.UserId + "用户名：" + this._currUserInfo.Username + "删除了个人备忘！备忘编号为：" + id,
                    EventTitle = "删除个人备忘"
                });
            }
            return isOk;
        }

        /// <summary>
        /// 获取个人备忘实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>个人备忘实体</returns>
        public UserMemorandum GetMdl(int id)
        {
            return id<=0?null:this._idal.GetMdl(id);
        }

        /// <summary>
        /// 获取个人备忘列表
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="operatorId">当前操作者编号(0为查看全部)</param>
        /// <param name="search">搜索实体</param>
        /// <returns>个人备忘列表</returns>
        public IList<UserMemorandum> GetLst(int pageSize, int pageIndex, ref int recordCount, int companyId, int operatorId,UserMemoSearch search)
        {
            if (pageSize <= 0 || pageIndex <= 0 || companyId <= 0) return null;
            return this._idal.GetLst(pageSize, pageIndex, ref recordCount, companyId, operatorId, search);
        }

        #endregion
    }
}
