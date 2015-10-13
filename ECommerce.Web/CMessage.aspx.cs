using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Web.UserControl;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ECommerce.Web {
    public partial class CMessage : System.Web.UI.Page {
        private readonly CM.DAL.CMArticle _cmArticleDal = new CM.DAL.CMArticle();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).index = "class=\"active\"";
            var pageNum = 1;
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["Page"]))             //页数判断
                {
                    pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                }
            }
            catch (Exception ex) {
                pageNum = 1;
            }
            var sql = "select row_number() over(order by dbo.CMArticle.AddTime DESC) as rownum, dbo.CMArticle.* from dbo.CMArticle join dbo.CMColumn ON CMColumn.ColId = CMArticle.ColId where CMArticle.Status=1 AND CMColumn.ColName='客户评价'";
            Database db = DatabaseFactory.CreateDatabase();
            var sqlCount ="select count(*) from dbo.CMArticle join dbo.CMColumn ON CMColumn.ColId = CMArticle.ColId where CMArticle.Status=1 AND CMColumn.ColName='客户评价'";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCount);
            object obj = db.ExecuteScalar(dbCommand);
            Literal1.Text = obj.ToString();
            Pager11.GetDataBind("Repeater", "rptList", sql, pageNum, 6, " ", "rownum", "CMessage.aspx?");
        }
    }
}