﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace EyouSoft.Toolkit
{
    /// <summary>
    /// HttpWebRequest
    /// </summary>
    public class request1
    {
        #region private members
        /// <summary>
        /// async callback
        /// </summary>
        /// <param name="ar"></param>
        static void OnResponse(IAsyncResult ar)
        {
            WebRequest request = (WebRequest)ar.AsyncState;
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.EndGetResponse(ar);

            /*
            if (response.StatusCode != HttpStatusCode.OK) return;

            StringBuilder responseText = new StringBuilder();
            Encoding encode = System.Text.Encoding.UTF8;

            if (response != null)
            {
                try
                {
                    Stream resStream = null;
                    resStream = response.GetResponseStream();

                    StreamReader readStream = new StreamReader(resStream, encode);

                    Char[] read = new Char[256];
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        string s = new String(read, 0, count);
                        responseText.Append(s);
                        count = readStream.Read(read, 0, 256);
                    }

                    resStream.Close();
                }
                catch { }
            }*/
        }
        #endregion

        /// <summary>
        /// create httpwebrequest,async=true时异步请求，不返回结果
        /// </summary>
        /// <param name="requestUriString">requestUriString</param>
        /// <param name="data">data</param>
        /// <param name="method">method</param>
        /// <param name="cookies">cookies</param>
        /// <param name="referer">referer</param>
        /// <param name="keepAlive">keepAlive</param>
        /// <param name="async">是否异步</param>
        /// <returns></returns>
        public static string create(string requestUriString, string data, Method method, ref string cookies, string referer, bool keepAlive, string contentType, bool async)
        {
            StringBuilder responseText = new StringBuilder();

            if (method == Method.GET && !string.IsNullOrEmpty(data))
            {
                if (requestUriString.IndexOf("?") > -1) requestUriString += data;
                else requestUriString += "?" + data;
            }

            if (string.IsNullOrEmpty(contentType)) contentType = "application/x-www-form-urlencoded; charset=UTF-8";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = 300000;
            request.Method = method.ToString();
            request.ContentType = contentType;
            request.KeepAlive = keepAlive;
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:8.0) Gecko/20100101 Firefox/8.0";
            request.Accept = "*/*";
            request.Referer = referer;
            request.Headers.Set("Cookie", cookies);

            Encoding encode = System.Text.Encoding.UTF8;

            if (method == Method.POST && !string.IsNullOrEmpty(data))
            {
                byte[] bytes = encode.GetBytes(data);
                request.ContentLength = bytes.Length;

                Stream oStreamOut = request.GetRequestStream();
                oStreamOut.Write(bytes, 0, bytes.Length);
                oStreamOut.Close();
            }

            if (async)
            {
                request.BeginGetResponse(new AsyncCallback(OnResponse), request);
                return string.Empty;
            }

            HttpWebResponse response = null;

            try
            {
                int i = 1;
                while (i > 0)
                {
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK) break;
                    else response = null;
                    i--;
                }
            }
            catch { response = null; }

            if (response != null)
            {
                try
                {
                    string rcookies = response.Headers["Set-Cookie"];

                    if (!string.IsNullOrEmpty(rcookies))
                    {
                        StringBuilder sb = new StringBuilder();
                        string[] arr = rcookies.Split(';');
                        foreach (string s in arr)
                        {
                            if (string.IsNullOrEmpty(s) 
                                || s.ToLower().IndexOf("domain=") > -1 
                                || s.ToLower().IndexOf("path=") > -1 
                                || s.ToLower().IndexOf("expires=") > -1) continue;

                            sb.Append(s.Trim(','));
                            sb.Append(";");
                        }

                        cookies += sb.ToString();
                    }

                    Stream resStream = null;
                    resStream = response.GetResponseStream();

                    StreamReader readStream = new StreamReader(resStream, encode);

                    Char[] read = new Char[256];
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        string s = new String(read, 0, count);
                        responseText.Append(s);
                        count = readStream.Read(read, 0, 256);
                    }

                    resStream.Close();
                }
                catch { }
            }

            return responseText.ToString();

        }

        /// <summary>
        /// create httpwebrequest,async=true时异步请求，不返回结果
        /// </summary>
        /// <param name="requestUriString">requestUriString</param>
        /// <param name="data">data</param>
        /// <param name="method">method</param>
        /// <param name="cookies">cookies</param>
        /// <param name="referer">referer</param>
        /// <param name="keepAlive">keepAlive</param>
        /// <param name="async">是否异步</param>
        /// <returns></returns>
        public static string create1(string requestUriString, string data, Method method, ref string cookies, string referer, bool keepAlive, string contentType, bool async)
        {
            StringBuilder responseText = new StringBuilder();

            if (method == Method.GET && !string.IsNullOrEmpty(data))
            {
                if (requestUriString.IndexOf("?") > -1) requestUriString += data;
                else requestUriString += "?" + data;
            }

            if (string.IsNullOrEmpty(contentType)) contentType = "application/x-www-form-urlencoded; charset=UTF-8";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Timeout = 300000;
            request.Method = method.ToString();
            request.ContentType = contentType;
            request.KeepAlive = keepAlive;
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:8.0) Gecko/20100101 Firefox/8.0";
            request.Accept = "*/*";
            request.Referer = referer;
            request.Headers.Set("Cookie", cookies);

            Encoding encode = System.Text.Encoding.UTF8;

            if (method == Method.POST && !string.IsNullOrEmpty(data))
            {
                byte[] bytes = encode.GetBytes(data);
                request.ContentLength = bytes.Length;

                Stream oStreamOut = request.GetRequestStream();
                oStreamOut.Write(bytes, 0, bytes.Length);
                oStreamOut.Close();
            }

            if (async)
            {
                request.BeginGetResponse(new AsyncCallback(OnResponse), request);
                return string.Empty;
            }

            HttpWebResponse response = null;

            try
            {
                int i = 1;
                while (i > 0)
                {
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK) break;
                    else response = null;
                    i--;
                }
            }
            catch { response = null; }

            if (response != null)
            {
                try
                {
                    string rcookies = response.Headers["Set-Cookie"];

                    if (!string.IsNullOrEmpty(rcookies))
                    {
                        cookies += rcookies;
                    }

                    Stream resStream = null;
                    resStream = response.GetResponseStream();

                    StreamReader readStream = new StreamReader(resStream, encode);

                    Char[] read = new Char[256];
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        string s = new String(read, 0, count);
                        responseText.Append(s);
                        count = readStream.Read(read, 0, 256);
                    }

                    resStream.Close();
                }
                catch { }
            }

            return responseText.ToString();

        }

        /// <summary>
        /// create httpwebrequest:get,async=true时异步请求，不返回结果
        /// </summary>
        /// <param name="requestUriString">requestUriString</param>
        /// <param name="data">data</param>
        /// <param name="async">是否异步</param>
        /// <returns></returns>
        public static string create(string requestUriString, string data,bool async)
        {
            string cookies = string.Empty;
            string referer = string.Empty;
            bool keepAlive = false;
            Method method = Method.GET;
            string contentType = string.Empty;

            return create(requestUriString, data, method, ref cookies, referer, keepAlive, contentType, async);
        }

        /// <summary>
        /// create httpwebrequest:get,async false
        /// </summary>
        /// <param name="requestUriString">requestUriString</param>
        /// <param name="data">data</param>
        /// <param name="async">是否异步</param>
        /// <returns></returns>
        public static string create(string requestUriString, string data)
        {
            string cookies = string.Empty;
            string referer = string.Empty;
            string contentType = string.Empty;

            return create(requestUriString, data, false);
        }

        /// <summary>
        /// create httpwebrequest:post
        /// </summary>
        /// <param name="requestUriString">requestUriString</param>
        /// <param name="data">data</param>
        /// <param name="contentType">contentType</param>
        /// <returns></returns>
        public static string post(string requestUriString, string data, string contentType)
        {
            string cookies = string.Empty;
            string referer = string.Empty;
            bool keepAlive = false;
            Method method = Method.POST;

            return create(requestUriString, data, method, ref cookies, referer, keepAlive, contentType, false);
        }
    }

    /// <summary>
    /// httpwebrequest method
    /// </summary>
    public enum Method
    {
        GET, POST
    }
}
