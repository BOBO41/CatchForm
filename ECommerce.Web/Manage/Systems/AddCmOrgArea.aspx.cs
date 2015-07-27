using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;
using System.Web.UI.WebControls;
using System.Text;

namespace ECommerce.Web.Manage.CM
{
    public partial class AddCmOrgArea : ECommerce.Web.UI.WebPage
    {
        OrgArea orgAreaDal = new OrgArea(); //创建区域DAL对象
        ECommerce.CM.DAL.CMArea cmAreaDal = new ECommerce.CM.DAL.CMArea();    //内容区域关系
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var aid = Request.QueryString["AID"];
                hidAID.Value = aid;
            }
        }
        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetArea()
        {
            DataSet dt = new DataSet();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlWhere = "  ParentId =0 ";
            dt = orgAreaDal.GetList(sqlWhere, parameters);
            return dt;
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string delStr = Request.Form["checkbox"];
                if (!string.IsNullOrEmpty(delStr))
                {
                    string areaNames = "";
                    string areaIds = "";
                    Session["OrgAreaIds"] = delStr.ToString();
                    if (!string.IsNullOrEmpty(delStr))
                    {
                        var area = delStr.Split(',');
                        if (area != null)
                        {
                            for (int i = 0; i < area.Length; i++)
                            {
                                var areaInfo = orgAreaDal.GetModel(area[i]);
                                areaNames += areaInfo.AreaName + ",";
                                areaIds += areaInfo.AreaId + ",";
                            }
                        }
                    }

                    StringBuilder strBuilder = new StringBuilder();
                    if (!string.IsNullOrEmpty(areaNames))
                    {
                        var areaName = areaNames.Split(',');
                        var areaId = areaIds.Split(',');
                        for (int i = 0; i < areaName.Length - 1; i++)
                        {
                            strBuilder.Append(" <tr id=\"tr2\">");
                            strBuilder.Append("   <td>" + areaName[i] + "</td>");
                            strBuilder.Append("   <td style=\"width: 15%; text-align: center\">");
                            strBuilder.Append("      <a href=\"javascript:void(0);\" data-backdrop=\"false\"  onclick=\"delTrAIds(this," + areaId[i] + ");return false;\">删除</a>");
                            strBuilder.Append("  </td>");
                            strBuilder.Append(" </tr>");
                        }
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.top.$op.$('#divAreaSelect').html(window.top.$op.$('#divAreaSelect').html()+'" + strBuilder.ToString() + "');window.top.$modal.destroy();</script>");
                    return;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择区域信息！')</script>");
                    return;
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择区域信息！')</script>");
                return;
            }


        }
    }
}