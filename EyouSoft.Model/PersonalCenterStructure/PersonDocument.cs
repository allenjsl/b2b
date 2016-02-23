using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.CompanyStructure;

namespace EyouSoft.Model.PersonalCenterStructure
{
    #region 文档管理实体
    /// <summary>
    /// 个人中心-文档管理实体
    /// </summary>
    [Serializable]
    public class PersonDocument
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonDocument() { }

        /// <summary>
        /// 文档编号
        /// </summary>
        public int DocumentId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 文档名称
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// 文档路径
        /// </summary>
        public string FilePath
        {
            get
            {
                if (Annexs != null && Annexs.Count > 0)
                {
                    return Annexs[0].FilePath;
                }

                return string.Empty;
            }        
        }
        /// <summary>
        /// 上传人编号
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 上传人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }

        /// <summary>
        /// 附件信息集合
        /// </summary>
        public IList<CompanyFile> Annexs { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }
    #endregion
}
