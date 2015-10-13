using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class About : System.Web.UI.Page {
        private readonly CM.DAL.CMArticle _cmArticleDal = new CM.DAL.CMArticle();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).abo = "class=\"active\"";
            var art = _cmArticleDal.GetModel(" Status=1 and Title='关于我们' ", new List<SqlParameter>());
            if (null != art) {
                litDescri.Text = art.Content;
            }
        }
    }
}