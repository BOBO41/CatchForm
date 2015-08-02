using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using ECommerce.Admin.Model;
using ECommerce.Lib.Security;

namespace ECommerce.Web {
    public partial class Login : System.Web.UI.Page {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                //TextBox1.Text = "ch";
                //TextBox2.Text = "1";

                try {
                    var httpCookie = Request.Cookies["UserName"];
                    var cookie = Request.Cookies["PassWord"];
                    if (httpCookie != null)
                        TextBox1.Text = DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(httpCookie.Value);

                    if (cookie != null)
                        TextBox2.Attributes.Add("value", DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(cookie.Value));
                    //if (httpCookie != null && cookie != null)
                    //{
                    //var res = SecurityMgr.Login(DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(httpCookie.Value), DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(cookie.Value));
                    //if (!string.IsNullOrEmpty(res))
                    //{
                    //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + res + "');</script>");
                    //}
                    //else
                    //{
                    //    Response.Redirect("/Manage/Systems/Default.aspx");
                    //}
                    //    CheckBox1.Checked = true;
                    //}
                }
                catch (Exception) {
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            var userName = TextBox1.Text.Trim();
            var passWord = TextBox2.Text.Trim();
            //var checkCode = TextBox3.Text.Trim();
            if (string.IsNullOrEmpty(userName)) {
                TextBox1.Focus();
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入用户名');</script>");
                return;
            }
            if (string.IsNullOrEmpty(passWord)) {
                TextBox2.Focus();
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入密码');</script>");
                return;
            }
            //if (checkCode != Session[ValidateCode.VALIDATECODEKEY].ToString())
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('验证码输入错误');</script>");
            //    TextBox3.Text = "";
            //    TextBox3.Focus();
            //    return;
            //}
            var res = SecurityMgr.Login(userName, passWord);
            if (!string.IsNullOrEmpty(res)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + res + "');</script>");
            }
            else {
                var httpCookie = Request.Cookies["UserName"];
                if (httpCookie != null) {
                    var cookName = DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(httpCookie.Value);
                    if (cookName != userName) {
                        var cUserNameStore = new HttpCookie("UserName") {
                            Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(userName)
                        };
                        //var cPassWord = new HttpCookie("PassWord")
                        //    {
                        //        Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(passWord)
                        //    };
                        cUserNameStore.Expires = DateTime.Now.AddDays(30);
                        //cPassWord.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cUserNameStore);
                    }
                }
                else {
                    var cUserNameStore = new HttpCookie("UserName") {
                        Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(userName)
                    };
                    cUserNameStore.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cUserNameStore);
                }
                LoginToUnido();
                Response.Redirect("/Manage/Systems/Default.aspx");
            }
        }

        public void LoginToUnido() {
            try {
                HttpWebRequest request = null;
                var cookieContainer = new CookieContainer();
                if (null != Session["CookieContainer"]) {
                    cookieContainer = Session["CookieContainer"] as CookieContainer;
                }
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                string url = "https://unido.benchmarkindex.com/login.php";
                request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = cookieContainer;
                request.ProtocolVersion = HttpVersion.Version10;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.UserAgent = DefaultUserAgent;
                //string form = "userId=" + ConfigurationManager.AppSettings["user"] + "&password=" + ConfigurationManager.AppSettings["pwd"] + "&login=Enter&theaction=1";
                var user = HttpContext.Current.Session["CurrentUser"] as OrgUsers;
                string form = "userId=" + user.UuserId + "&password=" + user.Upwd + "&login=Enter&theaction=1";
                byte[] data = Encoding.UTF8.GetBytes(form);
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
                HttpWebResponse wr = request.GetResponse() as HttpWebResponse;
                Session["CookieContainer"] = cookieContainer;
            }
            catch (Exception) {
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) {
            return true;
        }

    }
}