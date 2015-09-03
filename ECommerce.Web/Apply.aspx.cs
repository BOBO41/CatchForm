using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class Apply : System.Web.UI.Page {
        private ECommerce.Admin.DAL.ApplyList _applyListDal = new ECommerce.Admin.DAL.ApplyList();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).imp = "class=\"active\"";
        }

        protected void Unnamed1_Click(object sender, EventArgs e) {
            var name = txtname.Value.Trim();
            var addr = txtAddr.Value.Trim();
            var tel = txtTel.Value.Trim();
            var contact = txtContact.Value.Trim();
            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写企业名称！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(addr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写企业地址！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(contact)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写联系人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(tel)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写联系电话！');</script>");
                return;
            }
            var model = new ECommerce.Admin.Model.ApplyList {
                Addr = addr,
                CreateDate = DateTime.Now,
                Tel = tel,
                Contact = contact,
                Name = name,
                Status = 0,
                AType = 1
            };
            var exists = _applyListDal.GetModel(" Name='" + name + "' and AType=1 and Status = 0 ", new List<SqlParameter>());
            if (null != exists) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('企业已提交过申请！');</script>");
                return;
            }
            var resAdd = _applyListDal.Add(model);
            if (resAdd > 0) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('申请成功！');</script>");
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('申请失败！');</script>");
            }
        }
    }
}