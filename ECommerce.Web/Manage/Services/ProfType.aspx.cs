using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Services {
    public partial class _ProfType : ECommerce.Web.UI.WebPage {
        private readonly ECommerce.Admin.DAL.ProfType _dataDal = new ECommerce.Admin.DAL.ProfType();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                BindData(false);
            }
        }

        private void BindData(bool isFirstPage) {
            var user = HttpContext.Current.Session["CurrentUser"] as Admin.Model.OrgUsers;
            #region 分页
            //当前页码
            int pageNum = 1;
            int pageSize = 10;
            //分页查询语句
            string sql = "select row_number() over(order by CreateDate desc,PTID DESC) as rownum,* FROM ProfType where 1=1 ";
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
            Pager1.GetDataBind("Repeater", "rptList", sql, pageNum, pageSize, "", "rownum", "ProfType.aspx?id=" + Request.QueryString["id"] + "&");
            #endregion
        }

        protected void btnDelAll_Click(object sender, EventArgs e) {
            string delStr = "";
            foreach (RepeaterItem item in rptList.Items) {
                CheckBox cb = (CheckBox)item.FindControl("cbList");
                if (cb == null || !cb.Checked) continue;
                var litId = cb.ToolTip;
                if (litId != null) {
                    delStr += litId + ",";
                }
            }
            if (!string.IsNullOrEmpty(delStr)) {
                delStr = delStr.Substring(0, delStr.Length - 1);
                var res = _dataDal.DelList(delStr);
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
                var res = _dataDal.DelList(e.CommandName);
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