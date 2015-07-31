using System;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Companies {
    public partial class Default : WebPage {
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", true);
            if (!IsPostBack) {
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
            string sql = "select row_number() over(order by CreateDate desc,ID DESC) as rownum,* FROM ComInfo where 1=1 ";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value)) {
                name = txtRealName.Value;
                sql += " and  ComName like '%" + name + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"])) {
                name = Request.QueryString["name"];
                txtRealName.Value = name;
                sql += " and  ComName like '%" + name + "%' ";
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
            Pager1.GetDataBind("Repeater", "rptList", sql, pageNum, pageSize, "", "rownum", "Default.aspx?id=" + Request.QueryString["id"] + "&name=" + name + "&");
            #endregion
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            BindData(true);
        }
    }

}