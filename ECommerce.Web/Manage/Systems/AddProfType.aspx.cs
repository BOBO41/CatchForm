using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddProfType : UI.WebPage {
        private readonly ECommerce.Admin.DAL.ProfType _dataDal = new ECommerce.Admin.DAL.ProfType();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                if (!string.IsNullOrEmpty(Request.QueryString["empId"])) {
                    BindData(Request.QueryString["empId"]);
                }
            }
        }

        private void BindData(string empId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(empId));
                txtName.Value = model.Name;
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var name = txtName.Value.Trim();
            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写专家类型！');</script>");
                return;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["empId"])) {
                try {
                    var model = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["empId"]));
                    if (model == null) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('专家类型不存在！');</script>");
                        return;
                    }
                    model.Name = name;
                    var res = _dataDal.Update(model);
                    if (res) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('专家类型已存在！');</script>");
                    }
                }
                catch (Exception) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
                }
            }
            else {
                var model = new Admin.Model.ProfType {
                    CreateDate = DateTime.Now,
                    Name = name,
                    Status = 1
                };

                var resAdd = _dataDal.Add(model);
                if (resAdd > 0) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('专家类型已存在！');</script>");
                }
            }
        }
    }
}