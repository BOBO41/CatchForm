//**************************************************************
// 文件名：AddCmPro（设置商品）
// 数据表：
// 创建人：田霄
// 创建时间： 2014年4月08日
//**************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Product.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ECommerce.Web.Manage.Systems
{
    public partial class AddCmPro : ECommerce.Web.UI.WebPage
    {
        protected string aid = "";   //内容Id
        ProductInfo proDal = new ProductInfo();
        ECommerce.Admin.DAL.OrgOrganize orgDal = new ECommerce.Admin.DAL.OrgOrganize();  //供应商
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                DataBindOrgName();              //绑定厂家
                aid = Request.QueryString["AID"];
                hidAid.Value = aid;
            }
        }
        /// <summary>
        /// 下拉框绑定厂家
        /// </summary>
        private void DataBindOrgName()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();         //创建sql参数存储对象
                string sqlWhere = " Status =1 and OrgType=3";
                DataSet dtor = orgDal.GetList(sqlWhere, parameters);
                ddlOrgName.DataSource = dtor;
                ddlOrgName.DataTextField = "OrgName";
                ddlOrgName.DataValueField = "OrgId";
                ddlOrgName.DataBind();
                ddlOrgName.SelectedIndex = 0;

            }
            catch (Exception)
            {
            }

        }
        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns>分类集合</returns>
        protected string GetPro()
        {
            StringBuilder strBuilder = new StringBuilder();
            string sqlWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(ddlOrgName.SelectedValue))
            {
                sqlWhere += " and orgId =" + ddlOrgName.SelectedValue + " and  Status !=2 ";       //查询条件
            }
            List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
            DataSet dt = proDal.GetList(sqlWhere, parameters);
            if (dt != null)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        strBuilder.Append("  <tr>");
                        strBuilder.Append("  <td style=\"text-align: center; width: 30px\">");
                        strBuilder.Append("    <input type=\"checkbox\" name=\"cboProType\" id='cboProType " + dt.Tables[0].Rows[i]["Pid"] + "' value=\"" + dt.Tables[0].Rows[i]["Pid"] + "\">");
                        strBuilder.Append(" </td>");
                        strBuilder.Append("  <td style=\"text-align: center\">" + dt.Tables[0].Rows[i]["Title"] + "");
                        strBuilder.Append("   </td>");
                        strBuilder.Append("  </tr>");
                    }
                }
            }
            return strBuilder.ToString();

        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var FarmerIds = Request.Form["cboProType"];         //商品
            if (!string.IsNullOrEmpty(FarmerIds))
            {
                #region 添加/修改
                try
                {
                    Session["AID"] = hidAid.Value;
                    Session["PIDS"] = FarmerIds;
                    Session["OrgId"] = ddlOrgName.SelectedValue;
                    var pids = FarmerIds.Split(',');
                    StringBuilder strBuilder = new StringBuilder();
                    if (pids != null)
                    {
                        for (int i = 0; i < pids.Length; i++)
                        {
                            var proInfo = proDal.GetModel(Convert.ToInt32(pids[i]));
                            strBuilder.Append(" <tr id=\"tr2\">");
                            strBuilder.Append("   <td>" + proInfo.Title + "</td>");
                            var orgInfo = orgDal.GetModel(Convert.ToInt64(proInfo.OrgId));
                            strBuilder.Append("   <td>" + orgInfo.OrgName + "</td>");
                            strBuilder.Append("   <td style=\"width: 15%; text-align: center\">");
                            strBuilder.Append("      <a href=\"javascript:void(0);\" data-backdrop=\"false\"  onclick=\"delProAIds(this," + pids[i] + ");return false;\">删除</a>");
                            strBuilder.Append("  </td>");
                            strBuilder.Append(" </tr>");
                        }
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.top.$op.document.getElementById('divProSelect').innerHTML =window.top.$op.document.getElementById('divProSelect').innerHTML+'" + strBuilder.ToString() + "';window.top.$modal.destroy();</script>");
                    return;

                }
                catch (System.Threading.ThreadAbortException ex)
                {
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败！');</script>");
                    return;
                }
                #endregion
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择商品！');</script>");
                return;
            }
        }
    }
}