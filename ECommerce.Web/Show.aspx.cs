using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Show : System.Web.UI.Page {
        private readonly Admin.DAL.ComInfo _comInfoDal = new Admin.DAL.ComInfo();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).index = "class=\"active\"";
            if (string.IsNullOrEmpty(Request.QueryString["id"])) return;
            try {
                var cum = _comInfoDal.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (null != cum) {
                    litName.Text = cum.ComName;
                    litDate.Text = Convert.ToDateTime(cum.CreateDate).ToString("yyyy-MM-dd");
                    litCon.Text = cum.ComDesc;
                }
            }
            catch (Exception) {
            }
        }
    }
}