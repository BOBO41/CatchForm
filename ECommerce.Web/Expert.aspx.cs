using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Expert : System.Web.UI.Page {
        private readonly Admin.DAL.ProfInfo _profInfoDal = new Admin.DAL.ProfInfo();

        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).imp = "class=\"active\"";
            rptexp.DataSource =
                _profInfoDal.GetList(" Status=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            rptexp.DataBind();
        }
    }
}