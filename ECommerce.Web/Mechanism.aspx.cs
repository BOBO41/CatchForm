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
            //rptCom.DataSource = _comInfoDal.GetList(" Status=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            //rptCom.DataBind();
            var pageNum = 1;
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["Page"])) {
                    pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                }
            }
            catch (Exception ex) {
                pageNum = 1;
            }
            var sql = "select row_number() over(order by OID DESC) as rownum, * from ProfOrg where Status=1";
            Pager11.GetDataBind("Repeater", "rptList", sql, pageNum, 6, " ", "rownum", "Mechanism.aspx?");
        }
    }
}
