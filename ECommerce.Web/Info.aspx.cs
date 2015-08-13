using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using HtmlAgilityPack;

namespace ECommerce.Web {
    public partial class Info : Page {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        protected void Page_Load(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["or_path"])) {
                    GetHttpResponse();
                }
            }
            catch (ThreadAbortException) {
            }
            catch (Exception ex) {
                Response.Write(ex.Message);
                Response.End();
            }
        }

        public void GetHttpResponse() {
            var cookieContainer = new CookieContainer();
            if (null != HttpContext.Current.Session["CookieContainer"]) {
                cookieContainer = HttpContext.Current.Session["CookieContainer"] as CookieContainer;
            }
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
            string orPath = HttpContext.Current.Server.UrlDecode(Request.QueryString["or_path"]);
            string url = "https://unido.benchmarkindex.com" + orPath;
            string query = HttpUtility.UrlDecode(Request.QueryString["query"]);
            if (!string.IsNullOrEmpty(query)) {
                url = url + "?" + query;
            }
            var request = WebRequest.Create(url) as HttpWebRequest;
            //String refer = url.Substring(0, url.LastIndexOf("/") + 1);
            //request.AllowAutoRedirect = true;
            //request.Referer = refer;
            request.CookieContainer = cookieContainer;
            request.ProtocolVersion = HttpVersion.Version10;

            string method = Request.HttpMethod;
            if ("POST" == method.ToUpper()) {
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = method;
            }
            request.UserAgent = DefaultUserAgent;
            string form = HttpUtility.UrlDecode(Request.Form.ToString());
            if (!string.IsNullOrEmpty(form)) {
                byte[] data = Encoding.UTF8.GetBytes(form);
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }
            HttpWebResponse wr = request.GetResponse() as HttpWebResponse;
            Session["CookieContainer"] = cookieContainer;
            string urlResponse = wr.ResponseUri.ToString();
            var helper = new HtmlHelper();
            if ("/download.php" == orPath) {
                helper.FileProcess(Page, wr, query);
            }
            if ("POST" == method) {

                helper.DataProcess(orPath, wr, query, Request.Form);
            }
            if ("https://unido.benchmarkindex.com/login.php" == urlResponse) {
                helper.LoginToUnido();
                Response.Redirect(Request.Url.ToString());
            }
            if (url != urlResponse) {
                Response.Redirect(wr.ResponseUri.PathAndQuery);
            }
            else {
                Stream resp = wr.GetResponseStream();
                string coder = wr.CharacterSet;
                StreamReader respreader = new StreamReader(resp);
                HtmlDocument doc = new HtmlDocument();
                doc.Load(respreader);
                if ("/benchmark/getpdfreportlist.php" == orPath) {
                    helper.DownLoad(doc);
                }
                try {
                    doc.GetElementbyId("header").Remove();
                    doc.GetElementbyId("topLogin").Remove();
                    doc.GetElementbyId("footer").Remove();
                    doc.GetElementbyId("menu").Remove();
                    doc.GetElementbyId("Save").Remove();
                }
                catch (Exception) {
                }
                string response = doc.DocumentNode.OuterHtml;
                response = response.Replace("includes/css/base.css.php", "includes/css/base.css.css");
                response = response.Replace("https://unido.benchmarkindex.com/", "http://" + Request.Url.Host + ":" + Request.Url.Port + "/");
                response = response.Replace("https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js", "/Scripts/jquery-1.7.1.min.js");

                Response.Write(response);
                Response.End();
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) {
            return true;
        }
    }
}