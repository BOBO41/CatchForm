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
            string query = HttpContext.Current.Server.UrlEncode(context.Request.QueryString.ToString());
            string form = HttpContext.Current.Server.UrlEncode(context.Request.Form.ToString());
            if (path.Length >= 4 && ".php" == path.Substring(path.Length - 4).ToLower()) {
                path = "/Info.aspx?or_path=" + HttpContext.Current.Server.UrlEncode(path) + "&method=" + context.Request.HttpMethod + "&query=" + query + "&form=" + form;
                context.Server.TransferRequest(path);
            }
        }


        #region End Request

        void context_EndRequest(object sender, EventArgs e) {
            System.Web.HttpApplication app = (System.Web.HttpApplication)sender;
        }

        #endregion End Request
    }
}