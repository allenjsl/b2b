using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.PersonalCenterStructure
{
    /// <summary>
    /// 个人中心-个人备忘录
    /// </summary>
    public class UserMemorandum
    {
        /// <summary>
        /// 备忘录编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 备忘选择时间
        /// </summary>
        public DateTime AlertTime { get; set; }
        /// <summary>
        /// 完成状况
        /// </summary>
        public EnumType.PersonalCenterStructure.MemorandumState State { get; set; }
        /// <summary>
        /// 数据添加时间
        /// </summary>
        public DateTime IssueTime  { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    /// <summary>
    /// 个人中心-个人备忘录-搜索实体
    /// </summary>
    public class UserMemoSearch
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 备忘时间-开始
        /// </summary>
        public DateTime? MemoTimeS { get; set; }
        /// <summary>
        /// 备忘时间-结束
        /// </summary>
        public DateTime? MemoTimeE { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
}
