using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EyouSoft.Model.CompanyStructure
{
    /*
    #region 公司Hash配置实体[键：值形式]
    /// <summary>
    /// 公司Hash配置实体[键：值形式]
    /// </summary>
    /// 鲁功源 2011-01-18
    public class CompanySetting
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CompanySetting() { }
        #endregion

        #region 属性
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 字段名称[Key]
        /// </summary>
        public string FieldName
        {
            get;
            set;
        }
        /// <summary>
        /// 字段数值[Value]
        /// </summary>
        public string FieldValue
        {
            get;
            set;
        }
        #endregion

    }
    #endregion
    */

    #region 公司配置实体
    /// <summary>
    /// 公司配置实体
    /// </summary>
    [Serializable]
    public class CompanyFieldSetting
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /*/// <summary>
        /// 最长留位时间(分钟)
        /// </summary>
        public int ReservationTime { get; set; }
        /// <summary>
        /// 公司 LOGO
        /// </summary>
        public string CompanyLogo { get; set; }
        /// <summary>
        /// 打印页眉
        /// </summary>
        public string PageHeadFile { get; set; }
        /// <summary>
        /// 打印页脚
        /// </summary>
        public string PageFootFile { get; set; }
        /// <summary>
        /// 打印模版
        /// </summary>
        public string TemplateFile { get; set; }
        /// <summary>
        /// 公司章
        /// </summary>
        public string CompanyStamp { get; set; }*/
        /// <summary>
        /// 登录限制类型
        /// </summary>
        public EnumType.CompanyStructure.UserLoginLimitType UserLoginLimitType { get; set; }
        /// <summary>
        /// 打印页宽度
        /// </summary>
        public int PrintPageWidth { get; set; }
        /*/// <summary>
        /// 收付款默认银行账户-对应公司银行账户编号
        /// </summary>
        public string SFKYHZH { get; set; }
        /// <summary>
        /// 收付款默认支付方式-对应支付方式枚举值
        /// </summary>
        public string SFKZFFS { get; set; }*/

        /// <summary>
        /// sys logo filepath
        /// </summary>
        public string SysLogoFilepath { get; set; }
    }
    #endregion

    #region 专线商配置信息业务实体
    /// <summary>
    /// 专线商配置信息业务实体
    /// </summary>
    public class MZxsPeiZhiInfo
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
        /// <summary>
        /// logo filepath
        /// </summary>
        public string LogoFilepath { get; set; }
        /// <summary>
        /// 打印页眉filepath
        /// </summary>
        public string DaYinYeMeiFilepath { get; set; }
        /// <summary>
        /// 打印页脚filepath
        /// </summary>
        public string DaYinYeJiaoFilepath { get; set; }
        /// <summary>
        /// 图章filepath
        /// </summary>
        public string TuZhangFilepath { get; set; }
        /// <summary>
        /// 打印模板filepath
        /// </summary>
        public string DaYinMoBanFilepath { get; set; }
        /// <summary>
        /// 收付款默认银行账户-对应公司银行账户编号
        /// </summary>
        public string SFKYHZH { get; set; }
        /// <summary>
        /// 收付款默认支付方式-对应支付方式枚举值
        /// </summary>
        public string SFKZFFS { get; set; }
    }
    #endregion
}
