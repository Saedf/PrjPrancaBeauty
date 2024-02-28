using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Infrastructure;

namespace FrameWork.Common.Utilities.Downloader
{
    public class Downloader:IDownloader
    {
        private readonly ILogger _logger;

        public Downloader(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string?> GetHtmlFromPageAsync(string pageUrl, object? data, Dictionary<string, string> headers)
        {
            try
            {
                string urlParameter = "";

                if (data != null)
                    urlParameter = UrlEncodeParameterGenerator(data);

                string Url = pageUrl + urlParameter.Trim(new char[] { '&' });

                HttpWebRequest ObjRequest = (HttpWebRequest)HttpWebRequest.Create(Url);

                ObjRequest.Method = WebRequestMethods.Http.Get;
                ObjRequest.ContentType = "text/html;charset=utf-8";
                ObjRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36";
               

                #region افزودن هدر ها
                if (headers != null)
                    foreach (var item in headers)
                    {
                        ObjRequest.Headers.Add(item.Key, item.Value);
                    }
                #endregion

                ObjRequest.Headers.Add("Accept-charset", "ISO-8859-9,URF-8;q=0.7,*;q=0.7");
                ObjRequest.Headers["Accept-Encoding"] = "deflate";

                var response = (HttpWebResponse)(await ObjRequest.GetResponseAsync());

                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string? result = await sr.ReadToEndAsync();

                sr.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        private string UrlEncodeParameterGenerator(object? data)
        {
            if (data == null)
                return "";

            var parameter = GetModelParameters(data);

            string urlParameter = "?";

            foreach (var item in parameter)
            {
                if (item.Value != null)
                    urlParameter += "&" + item.Key + "=" + item.Value;
            }

            return urlParameter;
        }

        private Dictionary<string, string?> GetModelParameters(object? data)
        {
            if (data == null)
                return new Dictionary<string, string?>();

            Type t = data.GetType();
            PropertyInfo[] props = t.GetProperties();

            Dictionary<string, string?> lstParameter = new Dictionary<string, string?>();

            foreach (var prop in props)
            {
                object value = prop.GetValue(data, new object[] { });
                if (value != null)
                {
                    if (value.GetType() == typeof(string[]))
                        foreach (var item in (string?[])value)
                            if (item != null)
                                lstParameter.Add(prop.Name, item);

                    if (value is string)
                        lstParameter.Add(prop.Name, value.ToString());

                    if (value is int)
                        lstParameter.Add(prop.Name, value.ToString());

                    if (value is double)
                        lstParameter.Add(prop.Name, value.ToString());

                    if (value is float)
                        lstParameter.Add(prop.Name, value.ToString());

                    if (value is long)
                        lstParameter.Add(prop.Name, value.ToString());

                    if (value is bool)
                        lstParameter.Add(prop.Name, value.ToString());

                    //if (value.GetType() == typeof(ProductVariantItems_SendFromEnum))
                    //    LstParameter.Add(prop.Name, ((int)value).ToString());

                    //if (value.GetType() == typeof(ProductVariantItems_SendByEnum))
                    //    LstParameter.Add(prop.Name, ((int)value).ToString());
                }
            }

            return lstParameter;
        }
    }
}
