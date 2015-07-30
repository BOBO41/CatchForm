using System;
using System.Web;

namespace ECommerce.Web {

    public class UrlReWriter : IHttpModule {
        #region Constructor

        public UrlReWriter() {
        }

        #endregion Constructor

        #region IHttpModule Members

        public void Dispose() {
            // Do nothing, this method is required by IHttpModule
        }

        public void Init(HttpApplication context) {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        #endregion


        void context_BeginRequest(object sender, EventArgs e) {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string path = context.Request.Path;
            string query = HttpContext.Current.Server.UrlEncode(context.Request.QueryString.ToString());
            if (path.Length >= 4 && ".php" == path.Substring(path.Length - 4).ToLower()) {
                path = "/Info.aspx?or_path=" + HttpContext.Current.Server.UrlEncode(path) + "&query=" + query;
                context.Server.TransferRequest(path, true, context.Request.HttpMethod, null);
            }
        }


        #region End Request

        void context_EndRequest(object sender, EventArgs e) {
            HttpApplication app = (HttpApplication)sender;
        }

        #endregion End Request
    }
}