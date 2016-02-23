using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace EyouSoft.Toolkit
{
    public sealed class YouJian
    {
        /// <summary>
        ///  用于 SMTP 事务的主机的名称或 IP 地址。
        /// </summary>
        public string SmtpClientHost { get; set; }
        /// <summary>
        /// 与凭据关联的用户名。
        /// </summary>
        public string NetworkCredentialUsername { get; set; }
        /// <summary>
        /// 与凭据关联的用户名的密码。
        /// </summary>
        public string NetworkCredentialPassword { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string YouJianZhuTi { get; set; }
        /// <summary>
        /// 邮件正文
        /// </summary>
        public string YouJianZhengWen { get; set; }
        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string FaJianRenYouXiang { get; set; }
        /// <summary>
        /// 收件人邮箱
        /// </summary>
        public string ShouJianRenyouXiang { get; set; }
        System.Text.Encoding _YouJianEncoding = System.Text.Encoding.UTF8;
        /// <summary>
        /// 邮件编码
        /// </summary>
        public System.Text.Encoding YouJianEncoding { get { return _YouJianEncoding; } set { _YouJianEncoding = value; } }
        /// <summary>
        /// 邮件正文是否为 Html 格式的值。
        /// </summary>
        public bool IsBodyHtml { get; set; }
        /// <summary>
        /// 发件人关联的显示名
        /// </summary>
        public string FaJianRenDisplayName { get; set; }

        /// <summary>
        /// 提示消息
        /// </summary>
        public string XiaoXi { get; set; }

        /// <summary>
        /// 发送邮件，返回0成功，其它失败
        /// </summary>
        /// <returns></returns>
        public int Send()
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.Host = SmtpClientHost;
            _smtpClient.Credentials = new System.Net.NetworkCredential(NetworkCredentialUsername, NetworkCredentialPassword);

            var _fromMailAddress = new MailAddress(FaJianRenYouXiang, FaJianRenDisplayName);
            var _toMailAddress = new MailAddress(ShouJianRenyouXiang, string.Empty);

            //MailMessage _mailMessage = new MailMessage(FaJianRenYouXiang, ShouJianRenyouXiang);
            MailMessage _mailMessage = new MailMessage(_fromMailAddress, _toMailAddress);
            _mailMessage.Subject = YouJianZhuTi;
            _mailMessage.Body = YouJianZhengWen;
            _mailMessage.BodyEncoding = YouJianEncoding;
            _mailMessage.IsBodyHtml = IsBodyHtml;
            _mailMessage.Priority = System.Net.Mail.MailPriority.Normal;

            try
            {
                _smtpClient.Send(_mailMessage);
                _mailMessage.Dispose();
                _smtpClient = null;
                return 0;
            }
            catch (Exception ex)
            {
                _mailMessage.Dispose();
                _smtpClient = null;
                XiaoXi = "发送邮件时发生了异常";
                return -1;
            }

        }
    }
}
