using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM
{
    public partial class AddColumn : System.Web.UI.Page
    {
        private string ColId = "";        //商品分类Id变量
        private string prParentId = "";        //添加子商品分类Id变量
        ECommerce.CM.DAL.CMColumn cDAL = new ECommerce.CM.DAL.CMColumn();        //创建商品分类DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            //VerifyPage("", false);
            if (!IsPostBack)
            {
                ColId = Request.QueryString["ColId"] == null ? "" : Request.QueryString["ColId"];         //获取商品分类Id
                prParentId = Request.QueryString["PTColId"] == null ? "" : Request.QueryString["PTColId"];         //获取添加子商品分类Id
                if (!string.IsNullOrEmpty(ColId))        //判断商品分类Id是否为空
                {
                    //this.lblColName.Text = "修改栏目信息";
                    ECommerce.CM.Model.CMColumn cModel = cDAL.GetModel(Convert.ToInt32(ColId));          //通过商品分类Id查询商品分类信息
                    if (cModel != null)          //判断商品分类对象是否为空
                    {
                        this.txtColName.Value = cModel.ColName;        //给商品分类名称文本框赋值
                    }
                }
            }
        }
    }
}