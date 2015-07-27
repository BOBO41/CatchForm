using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM
{
    public partial class AddArticleType : System.Web.UI.Page
    {
        private string ATId = "";        //商品分类Id变量
        ECommerce.CM.DAL.CMArticleType atDAL = new ECommerce.CM.DAL.CMArticleType();        //创建商品分类DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            //VerifyPage("", false);
            if (!IsPostBack)
            {
                ATId = Request.QueryString["ATId"] == null ? "" : Request.QueryString["ATId"];         //获取商品分类Id
                if (!string.IsNullOrEmpty(ATId))        //判断商品分类Id是否为空
                {
                    //this.lblColName.Text = "修改内容类型";
                    ECommerce.CM.Model.CMArticleType atModel = atDAL.GetModel(Convert.ToInt32(ATId));          //通过商品分类Id查询商品分类信息
                    if (atModel != null)          //判断商品分类对象是否为空
                    {
                        this.txtATName.Value = atModel.ATName;        //给商品分类名称文本框赋值
                        ddlDisplayCss.SelectedValue = atModel.DisplayCss;
                    }
                }
            }
        }
    }
}