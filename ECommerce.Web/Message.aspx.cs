using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Message : System.Web.UI.Page {
        private readonly Admin.DAL.AdvisoryList _comInfoDal = new Admin.DAL.AdvisoryList();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).imp = "class=\"active\"";
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
            var sql = "select row_number() over(order by CreateDate DESC) as rownum, AdvisoryList.*,OrgEmployees.EmplName from AdvisoryList JOIN OrgUsers ON OrgUsers.UId = AdvisoryList.UId JOIN OrgEmployees ON OrgEmployees.EmplId = OrgUsers.EmplId where AdvisoryList.Status=1 and AdvisoryList.MType=0";
            Pager11.GetDataBind("Repeater", "rptList", sql, pageNum, 5, " ", "rownum", "Message.aspx?");
        }
    }
}