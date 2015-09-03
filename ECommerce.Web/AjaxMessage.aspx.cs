using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class AjaxMessage : System.Web.UI.Page {
        private readonly Admin.DAL.AdvisoryList _comInfoDal = new Admin.DAL.AdvisoryList();
        protected void Page_Load(object sender, EventArgs e) {
            var name = HttpUtility.UrlDecode(Request.QueryString["name"]);
            var cont = HttpUtility.UrlDecode(Request.QueryString["cont"]);
            var addr = HttpUtility.UrlDecode(Request.QueryString["addr"]);
            try {
                var model = new Admin.Model.AdvisoryList {
                    Advisory = cont,
                    Contact = name,
                    CreateDate = DateTime.Now,
                    Status = 0,
                    Tel = addr
                };
                Response.Write(_comInfoDal.Add(model) > 0 ? "保存成功" : "留言失败");
                Response.End();
            }
            catch (System.Threading.ThreadAbortException ex) {
            }
            catch {
                Response.Write("留言失败");
                Response.End();
            }
        }
    }
}