using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.CompanyStructure
{
    #region 用户信息实体
    /// <summary>
    /// 专线公司用户信息表
    /// </summary>
    public class CompanyUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码(在应用层设置时,只需设置其NoEncryptPassword属性)
        /// </summary>
        public PassWord PassWordInfo { get; set; }
        /// <summary>
        /// 专线公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public int DepartId { get; set; }
        /// <summary>
        /// 监管部门编号
        /// </summary>
        public int SuperviseDepartId { get; set; }
        /// <summary>
        /// 监管部门名称
        /// </summary>
        public string SuperviseDepartName { get; set; }
        /// <summary>
        /// 联系人信息
        /// </summary>
        public ContactPersonInfo PersonInfo { get; set; }
        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 权限组(角色)编号
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 权限集合(权限值以逗号隔开)
        /// </summary>
        public string PermissionList { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public EnumType.CompanyStructure.UserStatus UserStatus { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 操作时间 
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 用户银行账户信息
        /// </summary>
        public IList<UserBank> UserBank { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiXinHao { get; set; }
        /// <summary>
        /// 同行用户部门（门市部）
        /// </summary>
        public string BuMenName { get; set; }
        /// <summary>
        /// 单据抬头名称
        /// </summary>
        public string DanJuTaiTouMingCheng { get; set; }
        /// <summary>
        /// 单据抬头地址
        /// </summary>
        public string DanJuTaiTouDiZhi { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string MiMa { get; set; }
        /// <summary>
        /// 新密码MD5
        /// </summary>
        public string MiMaMd5 { get; set; }
        /// <summary>
        /// 原密码MD5
        /// </summary>
        public string YuanMiMaMd5 { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 客户联系人编号
        /// </summary>
        public int KeHuLxrId { get; set; }
        /// <summary>
        /// 客户联系人状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus KeHuLxrStatus { get; set; }
        /// <summary>
        /// 可用积分
        /// </summary>
        public int KeYongJiFen { get; set; }
        /// <summary>
        /// 冻结积分
        /// </summary>
        public int DongJieJiFen { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing LeiXing { get; set; }
        /// <summary>
        /// 单据打印模板
        /// </summary>
        public string DanJuDaYinMoBan { get; set; }
        /// <summary>
        /// 单据抬头电话
        /// </summary>
        public string DanJuTaiTouDianHua { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 供应商联系人编号
        /// </summary>
        public int GysLxrId { get; set; }
    }
    #endregion

    #region 用户密码实体
    /// <summary>
    /// 密码实体
    /// </summary>
    [Serializable]
    public class PassWord
    {
        private readonly Toolkit.DataProtection.HashCrypto hashcrypto = new Toolkit.DataProtection.HashCrypto();
        /// <summary>
        /// MD5加密密码
        /// </summary>
        private string _md5Password = string.Empty;

        /// <summary>
        /// 明文密码
        /// </summary>
        private string _noEncryptPassword = string.Empty;

        /// <summary>
        /// 获取或设置未加密密码(只需要设置未加密密码即可)
        /// </summary>
        public string NoEncryptPassword
        {
            get
            {
                return _noEncryptPassword;
            }
            set
            {
                this._noEncryptPassword = value;
                this._md5Password = hashcrypto.MD5Encrypt(this._noEncryptPassword);
            }
        }
        /// <summary>
        /// 获取MD5加密密码(只需要设置未加密密码即可)
        /// </summary>
        public string MD5Password { get { return this._md5Password; } }

        /// <summary>
        /// 构造方法
        /// </summary>
        public PassWord() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="noencryptpassword">未加密密码</param>
        public PassWord(string noencryptpassword)
        {
            this.NoEncryptPassword = noencryptpassword;
        }

        /// <summary>
        /// 设置所有密码(该方法只需在业务逻辑层使用)
        /// </summary>
        /// <param name="noencryptpassword">未加密密码</param>
        /// <param name="md5password">MD5加密密码</param>
        public void SetEncryptPassWord(string noencryptpassword, string md5password)
        {
            this._noEncryptPassword = noencryptpassword;
            this._md5Password = md5password;
        }

        /// <summary>
        /// 设置MD5密码
        /// </summary>
        /// <param name="md5pwd"></param>
        public void SetMd5Pwd(string md5pwd)
        {
            this._md5Password = md5pwd;
        }
    }
    #endregion

    #region 联系人信息实体类
    /// <summary>
    /// 联系人信息实体类
    /// </summary>
    [Serializable]
    public class ContactPersonInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public EnumType.CompanyStructure.Sex ContactSex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string ContactFax { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string ContactEmail { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// MSN
        /// </summary>
        public string MSN { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 个人简介
        /// </summary>
        public string PeopProfile { get; set; }
        /// <summary>
        /// 个人备注
        /// </summary>
        public string Remark { get; set; }
    }
    #endregion

    #region 用户账户信息

    /// <summary>
    /// 用户账户信息
    /// </summary>
    public class UserBank : CompanyAccountBase
    {
        /// <summary>
        /// 用户账户编号
        /// </summary>
        public string UserBankId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
    }

    #endregion

    #region 用户查询实体

    /// <summary>
    /// 用户查询实体
    /// </summary>
    public class QueryCompanyUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int[] UserId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public int[] DepartId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public EnumType.CompanyStructure.UserStatus[] UserStatus { get; set; }
        /// <summary>
        /// 是否包含删除的用户（传值 null 或者 false 都为false，传值为true 则结果集包含已经删除的用户）
        /// </summary>
        public bool? IsDelete { get; set; }
        /// <summary>
        /// 是否取管理员的用户
        /// </summary>
        public bool? IsAdmin { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public int? BuMenId { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing? LeiXing { get; set; }
    }

    #endregion

    #region 平台员工查询信息业务实体
    /// <summary>
    /// 平台员工查询信息业务实体
    /// </summary>
    public class MPtYuanGongChaXunInfo
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KeHuName { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string YongHuXingMing { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.UserStatus? YongHuStatus { get; set; }
    }
    #endregion

    #region 用户积分信息业务实体
    /// <summary>
    /// 用户积分信息业务实体
    /// </summary>
    public class MYongHuJiFenInfo
    {
        /// <summary>
        /// 可用积分
        /// </summary>
        public int KeYongJiFen { get; set; }
        /// <summary>
        /// 冻结积分
        /// </summary>
        public int DongJieJiFen { get; set; }
        /// <summary>
        /// 已使用积分
        /// </summary>
        public int YiShiYongJiFen { get; set; }
    }
    #endregion

    #region 用户简要信息业务实体
    /// <summary>
    /// 用户简要信息业务实体
    /// </summary>
    public class MYongHuJianYaoXinXiInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string YouXiang { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing LeiXing { get; set; }
    }
    #endregion

    #region 供应商用户查询信息业务实体
    /// <summary>
    /// 供应商用户查询信息业务实体
    /// </summary>
    public class MGysYongHuChaXunInfo
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string GysName { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string YongHuXingMing { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.UserStatus? YongHuStatus { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.SupplierType? GysLeiXing { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
