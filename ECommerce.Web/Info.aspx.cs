using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using Sgml;

namespace ECommerce.Web {
    public partial class Info : System.Web.UI.Page {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        protected void Page_Load(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["or_path"])) {
                    GetHttpResponse();
                }
            }
            catch (System.Threading.ThreadAbortException ex) {
            }
            catch (Exception) {
                Response.Write("Error!!!");
                Response.End();
            }
        }

        public void GetHttpResponse() {
            HttpWebRequest request = null;
            var cookieContainer = new CookieContainer();
            if (null != Session["CookieContainer"]) {
                cookieContainer = Session["CookieContainer"] as CookieContainer;
            }
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            string or_path = HttpContext.Current.Server.UrlDecode(Request.QueryString["or_path"]);
            string url = "https://unido.benchmarkindex.com" + or_path;
            string query = HttpUtility.UrlDecode(Request.QueryString["query"]);
            if (!string.IsNullOrEmpty(query)) {
                url = url + "?" + query;
            }
            request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = cookieContainer;
            request.ProtocolVersion = HttpVersion.Version10;

            string method = Request.QueryString["method"];
            if ("POST" == method.ToUpper()) {
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = method;
            }
            request.UserAgent = DefaultUserAgent;
            string form = HttpUtility.UrlDecode(Request.QueryString["form"]);
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
            if ("POST" == method) {
                HtmlHelper.DataProcess(or_path, wr.ResponseUri.AbsolutePath, query, form);
            }
            if (url != urlResponse) {
                Response.Redirect(wr.ResponseUri.PathAndQuery);
            }
            else {
                System.IO.Stream resp = wr.GetResponseStream();
                string coder = wr.CharacterSet;
                System.IO.StreamReader respreader = new System.IO.StreamReader(resp);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(respreader);
                try {
                    doc.GetElementbyId("header").Remove();
                    doc.GetElementbyId("topLogin").Remove();
                    doc.GetElementbyId("footer").Remove();
                    doc.GetElementbyId("menu").Remove();
                    //doc = HtmlHelper.AppendScript(or_path, doc);
                    HtmlNode head = doc.DocumentNode.SelectSingleNode("//head");
                    HtmlNode jquery = HtmlNode.CreateNode("<script src=\"/includes/js/formsubmit.js\"></script>");
                    head.AppendChild(jquery);
                }
                catch (Exception e) {
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