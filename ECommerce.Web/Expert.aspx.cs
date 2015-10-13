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
            var pageNum = 1;
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["Page"]))
                {
                    pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                }
            }
            catch (Exception ex) {
                pageNum = 1;
            }
            var sql = "select row_number() over(order by PIID DESC) as rownum, * from ProfInfo where Status=1";
            Pager11.GetDataBind("Repeater", "rptList", sql, pageNum, 5, " ", "rownum", "Expert.aspx?");
        }
    }
}