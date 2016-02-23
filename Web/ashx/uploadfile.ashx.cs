using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;
using System.IO;

namespace EyouSoft.Web.ashx
{
    /// <summary>
    /// 上传文件（uploadify3_2_1）
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class uploadfile : IHttpHandler
    {
        #region attributes
        HttpContext context = null;
        string uploadify_auth = string.Empty;
        /// <summary>
        /// 文件保存路径
        /// </summary>
        string UploadFilepath = "/ufiles/";
        /// <summary>
        /// 上传文件保存路径 string.empty:[/ufiles] 1:[/ufiles/baojia/]
        /// </summary>
        string uploadify_formdata1 = string.Empty;
        /// <summary>
        /// 上载文件的大小（以字节B为单位）
        /// </summary>
        int FileContentLength = 2097152;//2MB
        #endregion

        public void ProcessRequest(HttpContext _context)
        {
            context = _context;
            uploadify_auth = Utils.GetFormValue("uploadify_auth");
            uploadify_formdata1 = Utils.GetFormValue("uploadify_formdata1");
            if (uploadify_auth != "mykey") Utils.RCWE("-1");

            if (uploadify_formdata1 == "1")
            {
                UploadFilepath = "/ufiles/baojia/";
                FileContentLength = 10485760;//10MB
            }

            //获取上传文件数
            int iTotal = context.Request.Files.Count;

            if (iTotal < 1) Utils.RCWE("-2");

            IList<MFileInfo> items = new List<MFileInfo>();

            for (int i = 0; i < iTotal; i++)
            {
                HttpPostedFile file = context.Request.Files[i];

                var item = upload(file);

                if (item.RetCode != "0") continue;

                items.Add(item);
            }

            if (items == null || items.Count == 0) Utils.RCWE("-3");

            Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        }

        #region private members
        /// <summary>
        /// upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        MFileInfo upload(HttpPostedFile file)
        {
            var info = new MFileInfo();

            info.FileName = file.FileName;
            info.FileMiaoShu = Path.GetFileNameWithoutExtension(info.FileName);

            if (file.ContentLength < 1 || string.IsNullOrEmpty(info.FileName))
            {
                info.RetCode = "-1";
                info.XiaoXi = "上传文件错误";

                return info;
            }

            if (file.ContentLength > FileContentLength)
            {
                info.RetCode = "-1";
                info.XiaoXi = "上传文件错误(文件大小不能超过" + FileContentLength/1048576 + "MB)";

                return info;
            }

            string filePath = string.Empty;
            //获取文件扩展名
            string fileExtension = Path.GetExtension(file.FileName);

            if (string.IsNullOrEmpty(fileExtension))
            {
                info.RetCode = "-1";
                info.XiaoXi = "上传文件错误(不允许的文件扩展名)";

                return info;
            }

            string[] fileTypeList = Utils.GetUploadFileExtensions();
            if (!fileTypeList.Contains(fileExtension.ToLower()))
            {
                info.RetCode = "-1";
                info.XiaoXi = "上传文件错误(不允许的文件扩展名)";

                return info;
            }

            //设置文件名
            Random rnd = new Random();
            string saveFileName = DateTime.Now.ToFileTime().ToString() + rnd.Next(1000, 99999).ToString() + fileExtension;
            rnd = null;

            //保存文件
            string dPath = System.Web.HttpContext.Current.Server.MapPath(UploadFilepath);

            if (!Directory.Exists(dPath)) Directory.CreateDirectory(dPath);

            string fPath = dPath + saveFileName;
            file.SaveAs(fPath);

            filePath = UploadFilepath + saveFileName;

            info.RetCode = "0";
            info.Filepath = filePath;

            return info;
        }
        #endregion

        #region IsReusable
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region MFileInfo
        /// <summary>
        /// MFileInfo
        /// </summary>
        public class MFileInfo
        {
            string _RetCode = "0";
            /// <summary>
            /// 上传结果，0:成功，其它失败
            /// </summary>
            public string RetCode { get { return _RetCode; } set { _RetCode = value; } }
            /// <summary>
            /// 上传消息
            /// </summary>
            public string XiaoXi { get; set; }
            /// <summary>
            /// 上传的文件完全限定名称
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// 文件路径
            /// </summary>
            public string Filepath { get; set; }
            /// <summary>
            /// 文件扩展名
            /// </summary>
            public string FileExtension
            {
                get
                {
                    if (string.IsNullOrEmpty(Filepath)) return string.Empty;
                    return Path.GetExtension(Filepath);
                }
            }
            /// <summary>
            /// 文件描述
            /// </summary>
            public string FileMiaoShu { get; set; }
        }
        #endregion
    }
}
