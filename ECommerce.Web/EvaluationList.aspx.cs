using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class EvaluationList : System.Web.UI.Page {
        private readonly Admin.DAL.ComInfo _comInfoDal = new Admin.DAL.ComInfo();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).ser = "class=\"active\"";
            rptCom.DataSource = _comInfoDal.GetList(" 1=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            rptCom.DataBind();
        }
    }
}