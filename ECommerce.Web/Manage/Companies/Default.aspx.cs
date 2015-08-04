using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web;
using ECommerce.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;

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
            var user = HttpContext.Current.Session["CurrentUser"] as Admin.Model.OrgUsers;
            #region 分页
            //当前页码
            int pageNum = 1;
            int pageSize = 10;
            //分页查询语句
            string sql = "select row_number() over(order by CreateDate desc,ID DESC) as rownum,* FROM ComInfo where 1=1 and UId= " + user.UId;
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

        protected void btnExport_Click(object sender, EventArgs e) {
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
            //var sdate = string.Empty;
            //if (!string.IsNullOrEmpty(txtRealName.Value)) {
            //    sdate = txtRealName.Value;
            //    sql += " and a.minDate>='" + Convert.ToDateTime(txtRealName.Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            //}
            //var edate = string.Empty;
            //if (!string.IsNullOrEmpty(Text1.Value)) {
            //    edate = Text1.Value;
            //    sql += " and a.maxDate<='" + Convert.ToDateTime(Text1.Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            //}
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            var dt = db.ExecuteDataSet(dbCommand);
            if (dt.Tables[0].Rows.Count > 0) {
                CreateExcel(dt);
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('没有数据,修改查询条件试试');</script>");
            }
        }

        protected void CreateExcel(DataSet ds) {
            Response.Clear();
            //Response.Buffer = true;
            Response.Charset = "utf8";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("Companies" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", Encoding.UTF8));
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder table = new StringBuilder();
            table.Append("<table border='1' ><tr>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("企业名称");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("企业编号");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("地址1");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("地址2");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("地址3");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("城市");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("地区");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("邮政编码");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("国家");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("联系电话");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("传真");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("企业描述");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("行业");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("支行业");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("NACE代码");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("行业");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("支行业");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("NACE代码");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("选择SIC代码");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("选择支行业");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("选择支行业");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("员工人数");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("本国公司");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("联系人称谓");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("联系人姓氏");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("联系人名字");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("职位");
            table.Append("</strong></td>");
            table.Append("</tr>");

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++) {
                //1） 文本：vnd.ms-excel.numberformat:@ 
                //2） 日期：vnd.ms-excel.numberformat:yyyy/mm/dd 
                //3） 数字：vnd.ms-excel.numberformat:#,##0.00 
                //4） 货币：vnd.ms-excel.numberformat:￥#,##0.00 
                //5） 百分比：vnd.ms-excel.numberformat: #0.00% 
                table.Append("<tr>");

                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["ComName"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:@'>");
                table.Append(ds.Tables[0].Rows[i]["ComID"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Add1"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Add2"]);
                table.Append("</td>");

                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Add3"]);
                table.Append("</td>");

                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["City"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Area"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:@'>");
                table.Append(ds.Tables[0].Rows[i]["PostCode"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Country"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:@'>");
                table.Append(ds.Tables[0].Rows[i]["Phone"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:@'>");
                table.Append(ds.Tables[0].Rows[i]["Fax"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["ComDesc"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Industry"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["SubIndustry"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["SicCode"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Industry2"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["SubIndustry2"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["SicCode2"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Probe_sic"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Probe_sic2"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Probe_sic3"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:@'>");
                table.Append(ds.Tables[0].Rows[i]["Employees"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Domestic_company"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["Title"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["ContactFirstName"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["contactSurname"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["JobTitle"]);
                table.Append("</td>");
                table.Append("</tr>");
            }
            table.Append("</table>");
            Response.Write(table.ToString());
            Response.End();
        }
    }

}