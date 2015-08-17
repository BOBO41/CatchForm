using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;
using ECommerce.Web.Manage.Services;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddReply : UI.WebPage {
        private readonly AdvisoryList _dataDal = new AdvisoryList();
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
                    txtdescr.Value = model.Reply;
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var descr = txtdescr.Value;
            if (string.IsNullOrEmpty(descr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写回复内容！');</script>");
                return;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('咨询信息不存在！');</script>");
                        return;
                    }
                    dt.Reply = descr;
                    dt.UId = CurrentUser.UId;
                    dt.UpdateDate = DateTime.Now;
                    dt.Status = 1;
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
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
            }
        }
    }
}