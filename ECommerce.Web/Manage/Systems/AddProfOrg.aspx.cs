using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddProfOrg : UI.WebPage {
        private readonly ProfOrg _dataDal = new ProfOrg();
        private readonly ProfType _dataSWCDal = new ProfType();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                    BindData(Request.QueryString["OrgId"]);
                }

            }
        }
        private void BindData(string orgId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (null != model) {
                    txtName.Value = model.Name;
                    txtaddr.Value = model.Addr;
                    txtContact.Value = model.Contact;
                    txtMajorSell.Value = model.MajorSell;
                    txtdescri.Value = model.Descr;
                    txtfr.Value = model.FR;
                    txttel.Value = model.Tel;
                    txtemail.Value = model.Email;
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var name = txtName.Value.Trim();
            var addr = txtaddr.Value;
            var Contact = txtContact.Value;
            var MajorSell = txtMajorSell.Value;
            var descri = txtdescri.Value;
            var fr = txtfr.Value;
            var tel = txttel.Value;
            var email = txtemail.Value;
            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写机构名称！');</script>");
                return;
            }
            //if (string.IsNullOrEmpty(type)) {
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择所属分类！');</script>");
            //    return;
            //}
            if (string.IsNullOrEmpty(addr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写地址！');</script>");
                return;
            }

            if (string.IsNullOrEmpty(Contact)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写联系人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(fr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写法人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(MajorSell)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写主营方向！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(descri)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写机构简介！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(tel)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写联系电话！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(email)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写邮箱！');</script>");
                return;
            }


            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('机构信息不存在！');</script>");
                        return;
                    }
                    var exists =
                        _dataDal.GetModel(
                            " Name='" + name + "' and OID=" + Convert.ToInt32(Request.QueryString["OrgId"]),
                            new List<SqlParameter>());
                    if (null != exists) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('机构名称已经存在！');</script>");
                        return;
                    }
                    dt.Email = email;
                    dt.Addr = addr;
                    dt.Contact = Contact;
                    dt.FR = fr;
                    dt.MajorSell = MajorSell;
                    dt.Tel = tel;
                    dt.Name = name;
                    dt.UpdateDate = DateTime.Now;
                    dt.UId = CurrentUser.UId;
                    var res = _dataDal.Update(dt);
                    if (res) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('更新失败！');window.top.$modal.destroy();</script>");
                    }
                }
                catch (Exception) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                }
            }
            else {
                var model = new ECommerce.Admin.Model.ProfOrg {
                    Descr = descri,
                    Tel = tel,
                    Email = email,
                    CreateDate = DateTime.Now,
                    Addr = addr,
                    FR = fr,
                    MajorSell = MajorSell,
                    Name = name,
                    UId = CurrentUser.UId,
                    Contact = Contact,
                    Status = 1
                };
                var exists = _dataDal.GetModel(" Name='" + name + "' ", new List<SqlParameter>());
                if (null != exists) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('机构名称已经存在！');</script>");
                    return;
                }
                var resAdd = _dataDal.Add(model);
                if (resAdd > 0) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('新增失败！');window.top.$modal.destroy();</script>");
                }
            }
        }
    }
}