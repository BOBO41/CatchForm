using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.Services {
    public partial class ApplyList : ECommerce.Web.UI.WebPage {
        private ECommerce.Admin.DAL.ApplyList aDAL = new ECommerce.Admin.DAL.ApplyList();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                if (!string.IsNullOrEmpty(Request.QueryString["Status"])) {
                    ddlStatus.SelectedValue = Request.QueryString["Status"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ProName"])) {
                    txtProName.Value = Request.QueryString["ProName"];
                }
                DataBingList(false);
            }
        }
        private void DataBingList(bool isFirstPage) {
            #region 分页
            //当前页码
            int pageNum = 1;
            string sql = "select row_number() over(order by CreateDate desc) as rownum,* FROM ApplyList where AType=1 ";
            var name = string.Empty;
            var status = string.Empty;
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue) && ddlStatus.SelectedValue != "-1") {
                status = ddlStatus.SelectedValue;
                sql += " and Status =" + status;
            }
            if (!string.IsNullOrEmpty(txtProName.Value)) {
                name = txtProName.Value;
                sql += " and Name like '%" + name.Trim() + "%'";
            }

            if (!isFirstPage) {
                try {
                    if (!string.IsNullOrEmpty(Request.QueryString["Page"]))             //页数判断
                    {
                        pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                    }
                }
                catch (Exception ex) {
                    throw ex;
                }
            }

            //分页方法
            Pager.GetDataBind("Repeater", "rptArticle", sql, pageNum, 10, " ", "rownum", "ApplyList.aspx?ProName=" + name + "&Status=" + status + "&");
            #endregion
        }
        protected void btnCheck_Click(object sender, EventArgs e) {
            try {
                bool res = false;
                #region
                int i = 0;
                string delStr = "";
                foreach (RepeaterItem item in rptArticle.Items) {
                    CheckBox cb = (CheckBox)item.FindControl("cbSelect");
                    if (cb == null || !cb.Checked) continue;
                    i++;
                    var litId = cb.ToolTip;
                    if (litId != null) {
                        delStr += litId + ",";
                    }
                }
                #endregion
                if (delStr != "") {
                    res = aDAL.CheckList(delStr.Substring(0, delStr.Length - 1), 1, CurrentUser.UId);
                }
                if (i == 0) {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
                }
                if (res) {
                    DataBingList(false);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('处理失败！');</script>");
                }
            }
            catch (Exception ex) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('处理失败！');</script>");
            }
        }
        protected void btnBackCheck_Click(object sender, EventArgs e) {
            try {
                bool res = false;
                #region
                int i = 0;
                string delStr = "";
                foreach (RepeaterItem item in rptArticle.Items) {
                    CheckBox cb = (CheckBox)item.FindControl("cbSelect");
                    if (cb == null || !cb.Checked) continue;
                    i++;
                    var litId = cb.ToolTip;
                    if (litId != null) {
                        delStr += litId + ",";
                    }
                }
                #endregion
                if (delStr != "") {
                    res = aDAL.CheckList(delStr.Substring(0, delStr.Length - 1), 0, CurrentUser.UId);
                }
                if (i == 0) {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
                }
                if (res) {
                    DataBingList(false);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消失败！');</script>");
                }
            }
            catch (Exception ex) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消失败！');</script>");
            }
        }

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e) {
            DataBingList(true);
        }
    }
}