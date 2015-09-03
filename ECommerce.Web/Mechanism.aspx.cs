using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Mechanism : System.Web.UI.Page {
        private readonly Admin.DAL.ProfOrg _comInfoDal = new Admin.DAL.ProfOrg();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).org = "class=\"active\"";
            rptCom.DataSource = _comInfoDal.GetList(" Status=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            rptCom.DataBind();
        }
    }
}
