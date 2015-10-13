using System;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Services {
    public partial class Advisory1 : UI.WebPage {
        private readonly ECommerce.Admin.DAL.AdvisoryList _dataDal = new ECommerce.Admin.DAL.AdvisoryList();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", true);
            if (!IsPostBack) {
                //if (!string.IsNullOrEmpty(Request.QueryString["Status"])) {
                //    ddlStatus.SelectedValue = Request.QueryString["Status"];
                //}
                if (!string.IsNullOrEmpty(Request.QueryString["ProName"])) {
                    txtRealName.Value = Request.QueryString["ProName"];
                }
                BindData(false);
            }
        }

        /// <summary>
        /// 绑定数据 
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void BindData(bool isFirstPage) {
            #region 分页
            //当前页码
            int pageNum = 1;
            int pageSize = 10;
            //分页查询语句
            string sql = "select row_number() over(order by CreateDate desc) as rownum,* FROM AdvisoryList where 1=1 and AdvisoryList.MType=1 ";
            var name = string.Empty;
            var status = string.Empty;
            //if (!string.IsNullOrEmpty(ddlStatus.SelectedValue) && ddlStatus.SelectedValue != "-1") {
            //    status = ddlStatus.SelectedValue;
            //    sql += " and Status =" + status;
            //}
            if (!string.IsNullOrEmpty(txtRealName.Value)) {
                name = txtRealName.Value;
                sql += " and Contact like '%" + name.Trim() + "%'";
            }
            if (!isFirstPage) {
                try {

                    if (!string.IsNullOrEmpty(Request.QueryString["Page"])) //页数判断
                    {
                        pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                    }
                }
                catch (Exception ex) {
                    pageNum = 1;
                }
            }
            //分页方法
            Pager1.GetDataBind("Repeater", "rptListWork", sql, pageNum, pageSize, "", "rownum", "Advisory.aspx?ProName=" + name + "&Status=" + status + "&");
            #endregion
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelAll_Click(object sender, EventArgs e) {
            string delStr = "";
            foreach (RepeaterItem item in rptListWork.Items) {
                CheckBox cb = (CheckBox)item.FindControl("cbList");
                if (cb == null || !cb.Checked) continue;
                var litId = cb.ToolTip;
                if (litId != null) {
                    delStr += litId + ",";
                }
            }
            if (!string.IsNullOrEmpty(delStr)) {
                delStr = delStr.Substring(0, delStr.Length - 1);
                var res = _dataDal.DeleteList(delStr);
                if (res) {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    BindData(true);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            BindData(true);
        }

        /// <summary>
        /// 删除单条数据方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, CommandEventArgs e) {
            if (!string.IsNullOrEmpty(e.CommandName)) {
                var res = _dataDal.DeleteList(e.CommandName);
                if (res) {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    BindData(true);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }
    }
}