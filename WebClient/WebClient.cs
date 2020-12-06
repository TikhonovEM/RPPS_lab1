using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class WebClient : IWebClient
    {
        private string Address { get; set; }

        private WebRequest Request { get; set; }

        public WebClient(string host, string port)
        {
            Address = $"http://{host}:{port}";
        }

        public WebClient(string host, bool isHttps = false)
        {
            var https = isHttps ? "s" : string.Empty;
            Address = $"http{https}://{host}";
        }


        public string GetInputData()
        {
            Request = WebRequest.Create(Address + "/GetInputData");
            Request.Method = "GET";

            try
            {
                using (var response = (HttpWebResponse)Request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return string.Empty;
        }

        public bool Ping()
        {
            Request = WebRequest.Create(Address + "/Ping");
            Request.Method = "GET";

            try
            {
                using (var response = (HttpWebResponse)Request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                        return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public HttpStatusCode? WriteAnswer(string objectStr)
        {
            Request = WebRequest.Create(Address + "/WriteAnswer");
            Request.Method = "POST";
            var data = Encoding.UTF8.GetBytes(objectStr);
            Request.ContentType = "application/x-www--form-urlencoded";
            Request.ContentLength = data.Length;
            try
            {
                var dataStream = Request.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
                dataStream.Close();
                var response = (HttpWebResponse)Request.GetResponse();
                return response.StatusCode;
            }
            catch { }
            return null;
        }
    }
}
