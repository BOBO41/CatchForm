using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Mechanism_show : System.Web.UI.Page {
        private readonly Admin.DAL.ProfOrg _comInfoDal = new Admin.DAL.ProfOrg();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).org = "class=\"active\"";
            if (string.IsNullOrEmpty(Request.QueryString["id"])) return;
            try {
                var cum = _comInfoDal.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (null != cum) {
                    Literal10.Text = Literal1.Text = cum.Name;
                    Literal2.Text = cum.Addr;
                    Literal3.Text = cum.FR;
                    Literal4.Text = cum.Contact;
                    Literal5.Text = cum.Tel;
                    Literal6.Text = cum.Email;
                    Literal7.Text = cum.MajorSell;
                    Literal8.Text = cum.Descr;
                    Literal9.Text = Convert.ToDateTime(cum.CreateDate).ToString("yyyy年MM月dd日");
                }
            }
            catch (Exception) {
            }
        }
    }
}