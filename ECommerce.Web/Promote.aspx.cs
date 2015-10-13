using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Promote : System.Web.UI.Page {
        private readonly CM.DAL.CMArticle _cmArticleDal = new CM.DAL.CMArticle();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).imp = "class=\"active\"";
            var art = _cmArticleDal.GetModel("  Status=1 and Title='提升服务介绍' ", new List<SqlParameter>());
            if (null != art) {
                litDescri.Text = art.Content;
            }
        }
    }
}