using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Expert_show : System.Web.UI.Page {
        private readonly Admin.DAL.ProfInfo _comInfoDal = new Admin.DAL.ProfInfo();
        private readonly Admin.DAL.ProfType _profType = new Admin.DAL.ProfType();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).imp = "class=\"active\"";
            if (string.IsNullOrEmpty(Request.QueryString["id"])) return;
            try {
                var cum = _comInfoDal.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (null != cum) {
                    Literal10.Text = cum.Name;
                    var tName = _profType.GetModel(Convert.ToInt32(cum.PTID));
                    if (null != tName) {
                        Literal1.Text = tName.Name;
                    }
                    if (!string.IsNullOrEmpty(cum.Photo))
                    {
                        Image1.ImageUrl = cum.Photo;
                    }
                    Literal2.Text = cum.ComAddr;
                    Literal3.Text = cum.Job;
                    Literal4.Text = cum.MajorSearch;
                    Literal5.Text = cum.Education;
                    Literal8.Text = cum.Descri;
                    Literal9.Text = Convert.ToDateTime(cum.CreateDate).ToString("yyyy年MM月dd日");
                }
            }
            catch (Exception) {
            }
        }
    }
}