using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.CompanyStructure
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class CompanyUser : BLLBase
    {
        private readonly IDAL.CompanyStructure.ICompanyUser _dal =
            Component.Factory.ComponentFactory.CreateDAL<IDAL.CompanyStructure.ICompanyUser>();
        private readonly SysHandleLogs _handleLogsBll = new SysHandleLogs();

        #region private members

        /// <summary>
        /// 添加日志记录
        /// </summary>
        /// <param name="actionName">操作名称</param>
        /// <param name="id">用户编号</param>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        private Model.CompanyStructure.SysHandleLogs AddLogs(string actionName, string id, string userName)
        {
            var model = new Model.CompanyStructure.SysHandleLogs
                {
                    ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_组织机构,
                    EventCode = Model.CompanyStructure.SysHandleLogsNO.EventCode,
                    EventMessage =
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "{0}在"
                        + Model.EnumType.PrivsStructure.Privs2.系统设置_组织机构 + actionName + "了部门人员数据，编号为" + id + "，用户名为"
                        + userName,
                    EventTitle = actionName + Model.EnumType.PrivsStructure.Privs2.系统设置_组织机构 + "部门人员数据"
                };

            return model;
        }

        /// <summary>
        /// 根据关键字获取用户信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="s">关键字(用户名或邮箱)</param>
        /// <returns></returns>
        EyouSoft.Model.CompanyStructure.MYongHuJianYaoXinXiInfo GetYongHuInfo(int companyId, string s)
        {
            if (companyId < 1 || string.IsNullOrEmpty(s)) return null;
            return _dal.GetYongHuInfo(companyId, s);
        }

        /// <summary>
        /// 设置用户密码，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="miMa">新密码</param>
        /// <param name="miMaMd5">新密码MD5</param>
        /// <returns></returns>
        int SheZhiMiMa(int companyId, int yongHuId, string miMa, string miMaMd5)
        {
            if (companyId < 1 || yongHuId < 1 || string.IsNullOrEmpty(miMa) || string.IsNullOrEmpty(miMaMd5)) return 0;

            int dalRetCode = _dal.SheZhiMiMa(companyId, yongHuId, miMa, miMaMd5);

            return dalRetCode;
        }
        #endregion

        #region public members
        /// <summary>
        /// 判断E-MAIL是否已存在
        /// </summary>
        /// <param name="email">email地址</param>
        /// <param name="userId">当前修改Email的用户ID</param>
        /// <returns></returns>
        public bool IsExistsEmail(string email, int userId,int companyId)
        {
            if (string.IsNullOrEmpty(email)) return false;

            return this._dal.IsExistsEmail(email, userId,companyId);
        }

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="id">要排除的用户编号</param>
        /// <param name="userName">用户名</param>
        /// <param name="companyId">当前公司编号</param>
        /// <returns></returns>
        public bool IsExists(int id, string userName, int companyId)
        {
            if (string.IsNullOrEmpty(userName) || companyId <= 0) return false;
            return this._dal.IsExists(id, userName, companyId);
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Add(Model.CompanyStructure.CompanyUser model)
        {
            if (model == null || model.PassWordInfo == null || model.PersonInfo == null) return false;

            bool dalResult = this._dal.Add(model);

            if (dalResult)
            {
                this._handleLogsBll.Add(AddLogs("添加", model.ID.ToString(), model.UserName));
            }

            return dalResult;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户信息实体</param>
        /// <returns>true:成功 false:失败</returns>
        public bool Update(Model.CompanyStructure.CompanyUser model)
        {
            if (model == null || model.PassWordInfo == null || model.PersonInfo == null || model.ID <= 0) return false;

            bool dalResult = this._dal.Update(model);

            if (dalResult)
            {
                //修改密码
                UpdatePassWord(model.ID, model.PassWordInfo);

                this._handleLogsBll.Add(AddLogs("修改", model.ID.ToString(), model.UserName));
            }

            return dalResult;
        }

        /// <summary>
        /// 根据用户编号获取用户信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>用户实体</returns>
        public Model.CompanyStructure.CompanyUser GetUserInfo(int userId)
        {
            if (userId <= 0) return null;

            return this._dal.GetUserInfo(userId);
        }

        /*/// <summary>
        /// 根据用户名及密码获取用户信息实体
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">MD5密码</param>
        /// <returns>用户信息实体</returns>
        public Model.CompanyStructure.CompanyUser GetUserInfo(string userName, string pwd)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd)) return null;

            return this._dal.GetUserInfo(userName, pwd);
        }*/

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="password">密码实体类</param>
        /// <returns></returns>
        public bool UpdatePassWord(int id, Model.CompanyStructure.PassWord password)
        {
            if (id <= 0 || password == null || string.IsNullOrEmpty(password.NoEncryptPassword)
                || string.IsNullOrEmpty(password.MD5Password)) return false;

            return this._dal.UpdatePassWord(id, password);
        }

        /*/// <summary>
        /// 获得管理员实体信息
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public Model.CompanyStructure.CompanyUser GetAdminModel(int companyId)
        {
            if (companyId <= 0) return null;

            return this._dal.GetAdminModel(companyId);
        }*/

        /// <summary>
        /// 获取指定公司下的所有帐号用户详细信息列表
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">总的记录数</param>
        /// <param name="model">查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.CompanyUser> GetList(int companyId, int pageSize, int pageIndex, ref int recordCount
            , Model.CompanyStructure.QueryCompanyUser model)
        {
            if (companyId <= 0 || pageSize <= 0 || pageIndex <= 0) return null;

            return _dal.GetList(companyId, pageSize, pageIndex, ref recordCount, model);
        }

        /// <summary>
        /// 获取指定公司的所有用户信息
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="model">查询实体</param>
        /// <returns></returns>
        public IList<Model.CompanyStructure.CompanyUser> GetList(int companyId, Model.CompanyStructure.QueryCompanyUser model)
        {
            if (companyId <= 0) return null;

            return _dal.GetList(companyId, model);
        }

        /// <summary>
        /// 设置用户启用状态
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="status">用户状态</param>
        /// <returns>true:成功 false:失败</returns>
        public bool SetEnable(int id, Model.EnumType.CompanyStructure.UserStatus status)
        {
            if (id <= 0) return false;

            return this._dal.SetEnable(id, status);
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <param name="permissionList">权限集合</param>
        /// <returns>是否成功</returns>
        public bool SetPermission(int userId, int roleId, params string[] permissionList)
        {
            if (userId <= 0 || permissionList == null) return false;
            return this._dal.SetPermission(userId, roleId, permissionList);
        }

        /// <summary>
        /// （平台）员工新增修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int PT_YuanGong_CU(EyouSoft.Model.CompanyStructure.CompanyUser info)
        {
            if (info == null
                || info.CompanyId < 1
                || string.IsNullOrEmpty(info.KeHuId)
                || string.IsNullOrEmpty(info.PersonInfo.ContactEmail)
                || info.OperatorId < 1)
                return 0;

            info.IssueTime = DateTime.Now;

            int dalRetCode = _dal.PT_YuanGong_CU(info);

            return dalRetCode;
        }

        /// <summary>
        /// （平台）获取员工信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.CompanyUser> PT_GetYuanGongs(int companyId, string keHuId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo chaXun)
        {
            if (companyId < 1 || string.IsNullOrEmpty(keHuId)|| !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.PT_GetYuanGongs(companyId, keHuId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// （平台）员工删除
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="keHuId">客户编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <param name="keHuLxrId">客户联系人编号</param>
        /// <returns></returns>
        public int PT_YuanGong_D(int companyId, string keHuId, int yongHuId, int keHuLxrId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(keHuId) || keHuLxrId < 1) return 0;

            int dalRetCode = _dal.PT_YuanGong_D(companyId, keHuId, yongHuId, keHuLxrId);
            return dalRetCode;
        }

        /// <summary>
        /// 获取用户积分信息
        /// </summary>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public EyouSoft.Model.CompanyStructure.MYongHuJiFenInfo GetYongHuJiFenInfo(int yongHuId)
        {
            var info = new EyouSoft.Model.CompanyStructure.MYongHuJiFenInfo();

            if (yongHuId < 1) return info;

            info = _dal.GetYongHuJiFenInfo(yongHuId);

            return info;
        }

        /// <summary>
        /// （平台）用户找回密码发送修改密码验证码邮件，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="s">关键字（用户名或邮箱）</param>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="youXiang">发送到的邮箱</param>
        /// <returns></returns>
        public int PT_YongHu_ZhaoHuiMiMa_FaSongYanZhengMa(int companyId, string s, out string yanZhengMaId, out string youXiang)
        {
            yanZhengMaId = string.Empty;
            youXiang = string.Empty;
            var yongHuInfo = GetYongHuInfo(companyId, s);
            if (yongHuInfo == null) return 0;
            if (yongHuInfo.LeiXing != EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.同行用户) return -1;
            if (string.IsNullOrEmpty(yongHuInfo.YouXiang)) return -2;

            var _regYouXiang = new System.Text.RegularExpressions.Regex("^(\\w)+(\\.\\w+)*@(\\w)+((\\.\\w+)+)$");
            if (!_regYouXiang.Match(yongHuInfo.YouXiang).Success) return -3;

            var yzmInfo = new EyouSoft.Model.PtStructure.MYanZhengMaInfo();
            yzmInfo.IssueTime = DateTime.Now;
            yzmInfo.LeiXing = EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing.找回密码;
            yzmInfo.Status = EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.有效;
            yzmInfo.YanZhengMa = new EyouSoft.BLL.PtStructure.BYanZhengMa().CreateYanZhengMa(6);
            yzmInfo.YanZhengMaId = string.Empty;
            yzmInfo.YongHuId = yongHuInfo.YongHuId;

            int bllRetCode1 = new EyouSoft.BLL.PtStructure.BYanZhengMa().Insert(yzmInfo);
            if (bllRetCode1 != 1) return -4;

            //发送邮件
            var youJianInfo = new EyouSoft.Toolkit.YouJian();

            youJianInfo.FaJianRenDisplayName = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码发件人显示名).V;
            youJianInfo.FaJianRenYouXiang = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码发件人邮箱账号).V;
            youJianInfo.IsBodyHtml = true;
            youJianInfo.NetworkCredentialPassword = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码发件人邮箱密码).V;
            youJianInfo.NetworkCredentialUsername = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码发件人邮箱账号).V;
            youJianInfo.ShouJianRenyouXiang = yongHuInfo.YouXiang;
            youJianInfo.SmtpClientHost = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码SMTP服务器).V;
            youJianInfo.XiaoXi = string.Empty;
            string zw = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码邮件正文).V;
            zw = zw.Replace("<%=YanZhengMaZhanWeiFu%>", yzmInfo.YanZhengMa);
            youJianInfo.YouJianZhengWen = zw;
            youJianInfo.YouJianZhuTi = new EyouSoft.BLL.PtStructure.BPt().GetKvInfo(companyId, EyouSoft.Model.EnumType.PtStructure.KvKey.找回密码邮件主题).V;
            youJianInfo.Send();

            youXiang = yongHuInfo.YouXiang;
            yanZhengMaId = yzmInfo.YanZhengMaId;

            return 1;
        }

        /// <summary>
        /// （平台）用户修改密码，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="yaZhengMa">验证码</param>
        /// <param name="miMa">新密码</param>
        /// <returns></returns>
        public int PT_YongHu_ZhaoHuiMiMa_XiuGaiMiMa(int companyId,string yanZhengMaId,string yaZhengMa,string miMa)
        {
            if (companyId < 1 || string.IsNullOrEmpty(yanZhengMaId) || string.IsNullOrEmpty(yaZhengMa) || string.IsNullOrEmpty(miMa)) return 0;

            var yzmInfo = new EyouSoft.BLL.PtStructure.BYanZhengMa().GetInfo(yanZhengMaId, yaZhengMa, EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing.找回密码);
            if (yzmInfo == null) return -1;
            if (yzmInfo.Status1 != EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.有效) return -2;

            var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            pwdInfo.NoEncryptPassword = miMa;

            int bllRetCode = SheZhiMiMa(companyId, yzmInfo.YongHuId, miMa, pwdInfo.MD5Password);

            if (bllRetCode == 1)
            {
                new EyouSoft.BLL.PtStructure.BYanZhengMa().SetYiShiYong(yzmInfo.YanZhengMaId);
                return 1;
            }

            return -3;
        }

        /// <summary>
        /// 获取客户账号信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.CompanyUser> GetKeHuYongHus(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MPtYuanGongChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetKeHuYongHus(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 用户删除，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="yongHuId">用户编号</param>
        /// <returns></returns>
        public int YongHu_D(int companyId, string zxsId, int yongHuId)
        {
            if (companyId < 1 || string.IsNullOrEmpty(zxsId) || yongHuId < 1) return 0;

            int dalRetCode = _dal.YongHu_D(companyId, zxsId, yongHuId);

            if (dalRetCode == 1)
            {
                var log = new EyouSoft.Model.CompanyStructure.SysHandleLogs();
                log.EventTitle = "删除用户信息";
                log.ModuleId = Model.EnumType.PrivsStructure.Privs2.系统设置_组织机构;
                log.EventMessage = "删除用户信息，用户编号：" + yongHuId + "。";

                new EyouSoft.BLL.CompanyStructure.SysHandleLogs().Add(log);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取供应商账号信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.CompanyStructure.CompanyUser> GetGysYongHus(int companyId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.CompanyStructure.MGysYongHuChaXunInfo chaXun)
        {
            if (companyId < 1 || !ValidPaging(pageSize, pageIndex)) return null;

            return _dal.GetGysYongHus(companyId, pageSize, pageIndex, ref recordCount, chaXun);
        }
        #endregion
    }
}
