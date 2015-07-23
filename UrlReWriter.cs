using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace API.Web {

    public class UrlReWriter : IHttpModule {
        #region Constructor

        public UrlReWriter() {
        }

        #endregion Constructor

        #region IHttpModule Members

        public void Dispose() {
            // Do nothing, this method is required by IHttpModule
        }

        public void Init(System.Web.HttpApplication context) {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        #endregion


        void context_BeginRequest(object sender, EventArgs e) {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string path = context.Request.Path;
            string domain = ConfigurationManager.AppSettings["udomain"];
            //Regex regex = new Regex(domain, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Match match = regex.Match(path);
            //if (match.Success) {
            //    string para = match.Groups[1].Value;
            //    string rewritePath = "Info.aspx?para=" + HttpContext.Current.Server.UrlEncode(para);
            //    context.RewritePath(rewritePath);
            //}
            string para = path.Replace(domain, "");
            path = domain + "Info.aspx?para=" + HttpContext.Current.Server.UrlEncode(para);
            context.RewritePath(path);
        }
                

        #region End Request

        void context_EndRequest(object sender, EventArgs e) {
            System.Web.HttpApplication app = (System.Web.HttpApplication)sender;
        }

        #endregion End Request
    }
}