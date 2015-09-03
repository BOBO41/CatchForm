using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using ECommerce.Admin.DAL;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Companies {
    public partial class Report : WebPage {
        private readonly FileList _dataDal = new FileList();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["fid"])) {
                    var model = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["fid"]));
                    if (null != model) {
                        var filePath = HttpContext.Current.Server.MapPath("/UploadFiles/") + model.FPath;
                        Response.Clear();
                        Response.Charset = "utf-8";
                        Response.Buffer = true;
                        EnableViewState = false;
                        Response.ContentEncoding = System.Text.Encoding.UTF8;

                        Response.AppendHeader("Content-Disposition", "attachment;filename=" + model.FileName);
                        Response.WriteFile(filePath);
                        Response.Flush();
                        Response.Close();
                        Response.End();
                    }
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"])) {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var comId = new SqlParameter("@ComID", DbType.AnsiString) { Value = Request.QueryString["id"] };
                    parameters.Add(comId);
                    var dt = _dataDal.GetList(" ComID=@ComID ", parameters).Tables[0];
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                }
            }
            catch (Exception) {
            }
        }
    }
}