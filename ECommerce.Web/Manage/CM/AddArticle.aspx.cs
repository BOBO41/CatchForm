using System.Collections;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;
using ECommerce.Lib.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ECommerce.Web.Manage.CM
{
    public partial class AddArticle : ECommerce.Web.UI.WebPage
    {
        public string AId = "";        //文章分类Id变量
        private string areaId = "";        //区域Id变量
        ECommerce.CM.DAL.CMColumn cDAL = new ECommerce.CM.DAL.CMColumn();
        ECommerce.CM.DAL.CMArticle aDAL = new ECommerce.CM.DAL.CMArticle();        //创建文章分类DAL对象
        ECommerce.CM.DAL.CMArticleType atDAL = new ECommerce.CM.DAL.CMArticleType();
        ECommerce.CM.DAL.CMAttchment attDAL = new ECommerce.CM.DAL.CMAttchment();
        ECommerce.CM.Model.CMArticle aModel = new ECommerce.CM.Model.CMArticle();
        ECommerce.CM.Model.CMAttchment attModel = new ECommerce.CM.Model.CMAttchment();
        ECommerce.CM.Model.CMAttchment attMod = new ECommerce.CM.Model.CMAttchment();
        ECommerce.CM.DAL.CMArea cmAreaDal = new ECommerce.CM.DAL.CMArea();
        ECommerce.CM.DAL.CMPro cmProDal = new ECommerce.CM.DAL.CMPro();
        ECommerce.Admin.DAL.OrgArea orgAreaDal = new ECommerce.Admin.DAL.OrgArea();

        ECommerce.Admin.DAL.OrgOrganize orgDal = new ECommerce.Admin.DAL.OrgOrganize();  //供应商
        const string imgPath = "/UpLoad/Image/"; //图片存储路径
        private readonly Admin.DAL.Logs _logsDal = new Admin.DAL.Logs();
        public int page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                if (!IsPostBack)
                {
                    Session["OrgAreaIds"] = null;
                    Session["AID"] = null;
                    Session["PIDS"] = null;
                    Session["OrgId"] = null;
                    AId = Request.QueryString["AId"] == null ? "" : Request.QueryString["AId"];         //获取文章分类Id
                    hidAId.Value = AId;
                    DBindLm();
                    DBingType();
                    GetArea();            //查询区域信息
                    if (!string.IsNullOrEmpty(hidAId.Value))        //判断文章分类Id是否为空
                    {
                        this.lblTitle.Text = "修改内容";
                        ECommerce.CM.Model.CMArticle aModel = aDAL.GetModel(Convert.ToInt32(hidAId.Value));          //通过文章分类Id查询文章分类信息
                        if (aModel != null)
                        {
                            this.txtTitle.Value = aModel.Title;        //给文章分类名称文本框赋值
                            this.ddlColumn.SelectedValue = aModel.ColId.ToString();
                            this.ddlType.SelectedValue = aModel.ATId.ToString();
                            if (aModel.IsTop == 1)                //是否幻灯
                            {
                                rboIsTopTrue.Checked = true;
                                rboIsTopFalse.Checked = false;
                            }
                            else
                            {
                                rboIsTopTrue.Checked = false;
                                rboIsTopFalse.Checked = true;
                            }
                            var attInfo = attDAL.GetModel(Convert.ToInt32(hidAId.Value), 0);
                            if (attInfo != null)            //幻灯图
                            {
                                Image2.ImageUrl = imgPath + "S_" + attInfo.AttName;

                            }

                            List<SqlParameter> parameters = new List<SqlParameter>();
                            string sqlWhere = "  AId =@AId and Type=1";
                            var parameter = new SqlParameter("@AId", DbType.Int32);
                            parameter.Value = hidAId.Value;
                            parameters.Add(parameter);
                            string attNames = "";
                            string attNas = "";
                            DataSet dts = attDAL.GetList(sqlWhere, parameters);
                            if (dts != null)
                            {
                                if (dts.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                                    {
                                        attNames += "<li><span><a href=\"javascript:void(0);\" onclick=\"delTr(this,'" + dts.Tables[0].Rows[i]["AttId"] + "','" + dts.Tables[0].Rows[i]["AttName"] + "');return false;\">删除</a></span>" + dts.Tables[0].Rows[i]["AttName"] + "</li>";
                                        attNas += dts.Tables[0].Rows[i]["AttName"] + ",";
                                    }
                                }
                            }
                            att.InnerHtml = attNames;
                            atts.Value = attNas;

                            this.txtAuthor.Value = aModel.Author;
                            this.txtFrom.Value = aModel.Source;
                            this.tarDescription.Value = aModel.Description;
                            this.tarContent.Value = aModel.Content;
                            this.txtDisplayTime.Value = aModel.DisplayTime.ToString();
                        }
                    }
                }
            }
            catch
            {
                Response.Redirect("AddArticle.aspx");
            }
        }


        /// <summary>
        /// 绑定栏目
        /// </summary>
        private void DBindLm()
        {
            ddlColumn.Items.Add(new ListItem("请选择栏目", "0"));
            var dataTable = cDAL.GetDateList().Tables[0];
            var table1 = GetNewDataTable(dataTable, " Level=1 ", " ColId ");
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ddlColumn.Items.Add(new ListItem(table1.Rows[i]["ColName"].ToString(),//绑定父类
                                                 table1.Rows[i]["ColID"].ToString()));
                var table2 = GetNewDataTable(dataTable, " ParentID='" + table1.Rows[i]["ColID"] + "'", " ColId ");
                if (table2.Rows.Count > 0)
                {
                    for (int k = 0; k < table2.Rows.Count; k++)
                    {
                        ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄" + table2.Rows[k]["ColName"]),//绑定子类
                                                         table2.Rows[k]["ColID"].ToString()));
                        var table3 = GetNewDataTable(dataTable, " ParentID='" + table2.Rows[k]["ColID"] + "'",
                                                 " ColId");
                        if (table3.Rows.Count > 0)
                        {

                            for (int j = 0; j < table3.Rows.Count; j++)
                            {
                                ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄┄┄" + table3.Rows[j]["ColName"]),//绑定二级子类
                                                         table3.Rows[j]["ColID"].ToString()));
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 绑定类型
        /// </summary>
        private void DBingType()
        {
            ddlType.Items.Add(new ListItem("请选择类型", "0"));
            var dataTable = atDAL.GetDateList().Tables[0];
            var table1 = GetNewDataTable(dataTable, "", " ATId ");
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ddlType.Items.Add(new ListItem(table1.Rows[i]["ATName"].ToString(), table1.Rows[i]["ATId"].ToString()));
            }
        }
        public DataTable GetNewDataTable(DataTable dt, string condition, string sortOrder)
        {
            var newdt = dt.Clone();
            var dr = dt.Select(condition, sortOrder);
            foreach (var t in dr)
            {
                newdt.ImportRow(t);
            }
            return newdt;
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 获取字段值并赋给变量
            string title = txtTitle.Value.Trim();//标题
            string col = ddlColumn.SelectedValue;//栏目
            string type = ddlType.SelectedValue;//类型
            string author = txtAuthor.Value.Trim();//作者 
            string from = txtFrom.Value.Trim();//来源
            string description = tarDescription.Value.Trim();//导读
            string content = tarContent.Value.Trim();//详细内容 
            bool isTop = rboIsTopTrue.Checked;//是否置顶
            string displayTime = txtDisplayTime.Value;     //显示时长
            #endregion
            #region  验证输入内容
            if (string.IsNullOrEmpty(title))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入标题');</script>");
                txtTitle.Focus();
                return;
            }
            if (string.IsNullOrEmpty(col) || col == "0") //判断栏目
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择栏目');</script>");
                ddlColumn.Focus();
                return;
            }
            if (string.IsNullOrEmpty(type) || type == "0") //判断类型
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择类型');</script>");
                ddlType.Focus();
                return;
            }
            //if (string.IsNullOrEmpty(author)) //判断库存是否为空
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入作者');</script>");
            //    txtAuthor.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(from)) //判断库存是否为空
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入来源');</script>");
            //    txtFrom.Focus();
            //    return;
            //}
            //if (Request.QueryString["AId"] == "0")
            //{
            //    if (isFlash)
            //    {
            //        if (!fuPFlash.HasFile)
            //        {
            //            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择幻灯图片');</script>");
            //            fuPFlash.Focus();
            //            return;
            //        }
            //    }
            //}
            if (string.IsNullOrEmpty(description)) //判断商品概述是否为空
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入导读');</script>");
                tarDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(content)) //判断商品概述是否为空
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入详细内容');</script>");
                tarContent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(displayTime)) //判断商品概述是否为空
            {
                displayTime = "0";
            }
            else
            {
                try
                {
                    Convert.ToInt32(displayTime);
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('显示时长请输入数字');</script>");
                    tarContent.Focus();
                    return;
                }

            }
            #endregion
            //修改信息
            if (!string.IsNullOrEmpty(hidAId.Value)) //判断商品Id是否为空，如果不为空就是编辑数据
            {
                #region 修改内容
                try
                {
                    List<Logs.InfoLog> infolist = new List<Logs.InfoLog>();
                    #region 查询编辑对象，并赋值给对象字段
                    //查询编辑的商品信息
                    aModel = aDAL.GetModel(Convert.ToInt32(hidAId.Value)); //查询产品信息
                    if (aModel != null) //判断编辑果品对象是否为空
                    {
                        if (title != aModel.Title)
                        {
                            infolist.Add(new Logs.InfoLog(title, aModel.Title, "文章标题"));
                        }
                        aModel.Title = title; //文章标题

                        string orgId = Session["OrgId"] != null ? Session["OrgId"].ToString() : "";
                        if (!string.IsNullOrEmpty(orgId))
                        {
                            if (Convert.ToInt32(orgId) != aModel.OrgId)
                            {
                                infolist.Add(new Logs.InfoLog(orgId, aModel.OrgId.ToString(), "生产厂商"));
                            }
                            aModel.OrgId = Convert.ToInt32(orgId); //生产厂商
                        }

                        if (Convert.ToInt32(col) != aModel.ColId)
                        {
                            ECommerce.CM.DAL.CMColumn cmColumnDal = new ECommerce.CM.DAL.CMColumn();
                            var cmColimnInfo = cmColumnDal.GetModel(Convert.ToInt32(aModel.ColId));
                            infolist.Add(new Logs.InfoLog(ddlColumn.SelectedItem.Text, cmColimnInfo.ColName.ToString(), "栏目"));
                        }
                        aModel.ColId = Convert.ToInt32(col); //栏目
                        if (Convert.ToInt32(type) != aModel.ATId)
                        {

                            ECommerce.CM.DAL.CMArticleType cmArticleDal = new ECommerce.CM.DAL.CMArticleType();
                            var cmColimnInfo = cmArticleDal.GetModel(Convert.ToInt32(aModel.ATId));
                            infolist.Add(new Logs.InfoLog(ddlType.SelectedItem.Text, cmColimnInfo.ATName.ToString(), "类型"));
                        }
                        aModel.ATId = Convert.ToInt32(type); //类型
                        if (author != aModel.Author)
                        {
                            infolist.Add(new Logs.InfoLog(author, aModel.Author, "作者"));
                        }
                        aModel.Author = author;
                        if (from != aModel.Source)
                        {
                            infolist.Add(new Logs.InfoLog(from, aModel.Source, "来源"));
                        }
                        aModel.Source = from;
                        if (description != aModel.Description)
                        {
                            infolist.Add(new Logs.InfoLog(description, aModel.Description, "内容导读"));
                        }
                        aModel.Description = description;
                        if (content != aModel.Content)
                        {
                            infolist.Add(new Logs.InfoLog(content, aModel.Content, "详细内容"));
                        }
                        aModel.Content = content;

                        aModel.CheckTime = DateTime.Now;
                        aModel.DisplayTime = Convert.ToInt32(displayTime);
                        //aModel.PEmplId=  修改人
                        //审核人
                        if (isTop)
                        {
                            if (1 != aModel.IsTop)
                            {
                                infolist.Add(new Logs.InfoLog("1", aModel.IsTop.ToString(), "是否置顶"));
                            }
                            aModel.IsTop = 1;

                        }
                        else
                        {
                            if (0 != aModel.IsTop)
                            {
                                infolist.Add(new Logs.InfoLog("0", aModel.IsTop.ToString(), "是否置顶"));
                            }
                            aModel.IsTop = 0;
                        }

                    #endregion

                        if (fuPFlash.HasFile)
                        {
                            int sizeFlash;
                            string msgFlash;
                            string imgFlashUrl;
                            if (attDAL.Exists(Convert.ToInt32(hidAId.Value), 0)) //判断图片地址是否存在
                            {
                                attModel = attDAL.GetModel(Convert.ToInt32(hidAId.Value), 0);
                                attMod = attDAL.GetModel(Convert.ToInt32(hidAId.Value), 0);
                                DirFile.DeleteFile(attModel.AttName); // 删除图片地址

                                UpImg(ref fuPFlash, out imgFlashUrl, out msgFlash, imgPath, out sizeFlash);
                                //上传图片(无水印)
                                if (string.IsNullOrEmpty(imgFlashUrl))
                                {
                                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                                        "<script>alert('" + msgFlash + "');</script>");
                                    return;
                                }
                                attModel.AttName = imgFlashUrl; //幻灯地址
                                if (!attDAL.Update(attModel))
                                {
                                    return;
                                }

                            }
                            else
                            {
                                UpImg(ref fuPFlash, out imgFlashUrl, out msgFlash, imgPath, out sizeFlash);
                                //上传图片(无水印)
                                if (string.IsNullOrEmpty(imgFlashUrl))
                                {
                                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                                        "<script>alert('" + msgFlash + "');</script>");
                                    return;
                                }
                                attModel.AttName = imgFlashUrl; //幻灯地址
                                attModel.Type = 0;
                                attModel.AId = Convert.ToInt32(hidAId.Value);
                                attModel.Status = 1;
                                if (!(attDAL.Add(attModel) > 0))
                                {
                                    return;
                                }

                            }
                        }
                        attDAL.DeleteByAid(Convert.ToInt32(hidAId.Value));
                        string attName = atts.Value;
                        if (!string.IsNullOrEmpty(attName))
                        {
                            var attNames = attName.Split(',');
                            for (int i = 0; i < attNames.Length - 1; i++)
                            {
                                if (!string.IsNullOrEmpty(attNames[i]))
                                {
                                    attMod.AId = Convert.ToInt32(hidAId.Value);
                                    attMod.Type = 1;
                                    attMod.AttName = attNames[i];

                                    attMod.Status = 1;
                                    attDAL.Add(attMod);
                                }
                            }
                        }

                        bool re = aDAL.Update(aModel);
                        if (re)
                        {
                            string orgAreaIds = Session["OrgAreaIds"] != null ? Session["OrgAreaIds"].ToString() : "";
                            if (!string.IsNullOrEmpty(orgAreaIds))
                            {
                                bool res = cmAreaDal.AddList(hidAId.Value, orgAreaIds);
                                if (res)
                                {
                                    if (infolist.Count > 0)
                                    {

                                        _logsDal.WriteLogs(infolist, CurrentUser.EmplId.ToString(), aModel.AId, DateTime.Now, "CMArticle");
                                    }
                                }
                                else
                                {
                                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                     "<script>alert('修改区域失败'); </script>", false);
                                }
                            }
                            else
                            {
                                if (infolist.Count > 0)
                                {
                                    _logsDal.WriteLogs(infolist, CurrentUser.EmplId.ToString(), aModel.AId, DateTime.Now, "CMArticle");
                                }
                            }
                            Session["OrgAreaIds"] = null;

                            string aid = hidAId.Value;
                            string pids = Session["PIDS"] != null ? Session["PIDS"].ToString() : "";

                            if (!string.IsNullOrEmpty(aid) && !string.IsNullOrEmpty(pids))
                            {
                                int res = cmProDal.AddPro(Convert.ToInt32(aid), pids);
                                if (res > 0)
                                {
                                    if (infolist.Count > 0)
                                    {
                                        _logsDal.WriteLogs(infolist, CurrentUser.EmplId.ToString(), aModel.AId, DateTime.Now, "CMPro");
                                    }
                                }
                                else
                                {
                                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                     "<script>alert('修改关联商品失败'); </script>", false);
                                }
                            }
                            else
                            {
                                if (infolist.Count > 0)
                                {
                                    _logsDal.WriteLogs(infolist, CurrentUser.EmplId.ToString(), aModel.AId, DateTime.Now, "CMArticle");
                                }
                            }
                            Session["AID"] = null;
                            Session["PIDS"] = null;
                            Session["OrgId"] = null;

                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                       "<script>window.location = '/Manage/CM/CMArticle.aspx?Page=" + page + "';</script>", false);//跳转页面
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                        "<script>alert('修改失败'); </script>", false);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                #endregion
            }
            else //新增信息
            {
                #region 新增信息
                try
                {
                    #region 给果品实体对象字段赋值
                    aModel.Title = title; //商品名称  
                    string orgId = Session["OrgId"] != null ? Session["OrgId"].ToString() : "";
                    if (!string.IsNullOrEmpty(orgId))
                    {
                        aModel.OrgId = Convert.ToInt32(orgId); //生产厂商
                    }
                    aModel.ColId = Convert.ToInt32(col); //产品概述
                    aModel.ATId = Convert.ToInt32(type); //产品描述
                    aModel.Author = author;
                    aModel.Source = from;
                    aModel.Description = description;
                    aModel.Content = content;
                    aModel.Hits = 0;
                    aModel.Status = 0;
                    aModel.AddTime = DateTime.Now;
                    aModel.DisplayTime = Convert.ToInt32(displayTime);
                    if (isTop)
                    {
                        aModel.IsTop = 1;
                    }
                    else
                    {
                        aModel.IsTop = 0;
                    }

                    #endregion
                    int re = aDAL.Add(aModel); //增加方法

                    if (fuPFlash.HasFile)
                    {
                        int sizeFlash;
                        string msgFlash;
                        string imgFlashUrl;
                        UpImg(ref fuPFlash, out imgFlashUrl, out msgFlash, imgPath, out sizeFlash);//上传图片                   
                        if (string.IsNullOrEmpty(imgFlashUrl))
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "",
                                "<script>alert('" + msgFlash + "');</script>");
                            return;
                        }

                        attModel.Type = 0;
                        attModel.AttName = imgFlashUrl; //幻灯地址
                        attModel.Status = 1;
                        attModel.AId = re;
                        attDAL.Add(attModel);
                    }

                    string attName = atts.Value;
                    if (!string.IsNullOrEmpty(attName))
                    {
                        var attNames = attName.Split(',');
                        for (int i = 0; i < attNames.Length - 1; i++)
                        {
                            if (!string.IsNullOrEmpty(attNames[i]))
                            {
                                attMod.AId = re;
                                attMod.Type = 1;
                                attMod.AttName = attNames[i];
                                attMod.Status = 1;
                                attDAL.Add(attMod);
                            }
                        }
                    }
                    if (re > 0) //判断商品增加是否成功
                    {
                        string orgAreaIds = Session["OrgAreaIds"] != null ? Session["OrgAreaIds"].ToString() : "";
                        if (!string.IsNullOrEmpty(orgAreaIds))
                        {
                            bool res = cmAreaDal.AddList(re.ToString(), orgAreaIds);
                            if (res)
                            {
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "", "<script>window.location = '/Manage/CM/CMArticle.aspx?Page=" + page + "';</script>", false);//跳转页面
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                  "<script>alert('新增区域失败'); </script>", false);

                            }
                        }
                        Session["OrgAreaIds"] = null;

                        string aid = re.ToString();
                        string pids = Session["PIDS"] != null ? Session["PIDS"].ToString() : "";
                        if (!string.IsNullOrEmpty(aid) && !string.IsNullOrEmpty(pids))
                        {
                            int res = cmProDal.AddPro(Convert.ToInt32(aid), pids);
                            if (res > 0)
                            {

                                page = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "", "<script>window.location = '/Manage/CM/CMArticle.aspx?Page=" + page + "';</script>", false);//跳转页面
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                  "<script>alert('新增关联商品失败');</script> ", false);

                            }
                        }
                        Session["AID"] = null;
                        Session["PIDS"] = null;
                        Session["OrgId"] = null;
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "", "<script>window.location = '/Manage/CM/CMArticle.aspx';</script>", false);//跳转页面
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                            "<script>alert('新增失败'); </script>", false);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
        }
        /// <summary>
        /// 取消方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            page = Request.QueryString["Page"] == null ? 1 : Convert.ToInt32(Request.QueryString["Page"]);
            Response.Redirect("CMArticle.aspx?Page=" + page + "");
        }
        /// <summary>
        /// 上传图片(无水印)
        /// </summary>
        /// <param name="upfile_href">ref上传空间ID</param>
        /// <param name="imgurl">out返回的图片路径</param>
        /// <param name="msg">out提示消息</param>
        /// <param name="imgPath">图片存放路径</param>
        public static void UpImg(ref FileUpload upfile_href, out string imgurl, out string msg, string imgPath, out int size)
        {
            string datatime = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (upfile_href.HasFile)
            {
                string fileName = upfile_href.FileName;
                string fileExition = System.IO.Path.GetExtension(fileName).ToLower();
                string imgType = "|.gif|.png|.jpeg|.jpg|.bmp";
                string strDay = System.DateTime.Now.ToString("yyyyMM");
                string path = HttpContext.Current.Server.MapPath(imgPath + "/");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (fileName == "")
                {
                    msg = "请选择上传的图片";
                    imgurl = "";
                    size = 0;
                    return;
                }
                if (imgType.IndexOf(fileExition) > 0)
                {
                    string NewFileName = datatime + fileExition;
                    upfile_href.PostedFile.SaveAs(path + NewFileName);
                    size = upfile_href.PostedFile.ContentLength;
                    imgurl = NewFileName;
                    msg = "上传成功!";
                    JXY_UPLOAD_IMG.MakeThumbnail(HttpContext.Current.Server.MapPath("/UpLoad/Image/" + imgurl), HttpContext.Current.Server.MapPath("/UpLoad/Image/Wine_" + NewFileName), 300, 300, "Cut");
                    JXY_UPLOAD_IMG.MakeThumbnail(HttpContext.Current.Server.MapPath("/UpLoad/Image/" + imgurl), HttpContext.Current.Server.MapPath("/UpLoad/Image/S_" + NewFileName), 240, 240, "Cut");
                }
                else
                {
                    msg = "上传图片格式错误";
                    imgurl = "";
                    size = 0;
                }
            }
            else
            {
                imgurl = "";
                msg = "请选择上传的图片";
                size = 0;
            }
        }

        /// <summary>
        /// 查询区域
        /// </summary>
        /// <returns></returns>
        public string GetArea()
        {
            DataSet dt = new DataSet();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlWhere = "  AID =@AID ";
            var parameter = new SqlParameter("@AID", DbType.AnsiString);
            parameter.Value = hidAId.Value;
            parameters.Add(parameter);
            dt = cmAreaDal.GetListArea(sqlWhere, parameters);
            StringBuilder strBuilder = new StringBuilder();
            if (dt != null)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        var areaInfo = orgAreaDal.GetModel(dt.Tables[0].Rows[i]["AreaId"].ToString());
                        strBuilder.Append(" <tr id='tr2'>");
                        strBuilder.Append("   <td>" + areaInfo.AreaName + "</td>");
                        strBuilder.Append("   <td style=\"width: 15%; text-align: center\">");
                        strBuilder.Append("      <a href=\"javascript:void(0);\" onclick=\"delTrAId(this,'" + areaInfo.AreaId + "');return false;\" data-backdrop=\"false\">删除</a>");
                        strBuilder.Append("  </td>");
                        strBuilder.Append(" </tr>");
                    }
                }
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <returns></returns>
        public string GetPro()
        {
            DataSet dt = new DataSet();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlWhere = "  AID =@AID ";
            var parameter = new SqlParameter("@AID", DbType.AnsiString);
            parameter.Value = hidAId.Value;
            parameters.Add(parameter);
            dt = cmProDal.GetListPro(sqlWhere, parameters);
            StringBuilder strBuilder = new StringBuilder();
            if (dt != null)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        strBuilder.Append(" <tr id='tr2'>");
                        strBuilder.Append("   <td>" + dt.Tables[0].Rows[i]["Title"] + "</td>");
                        var orgInfo = orgDal.GetModel(Convert.ToInt64(dt.Tables[0].Rows[i]["OrgId"]));
                        strBuilder.Append("   <td>" + orgInfo.OrgName + "</td>");
                        strBuilder.Append("   <td style=\"width: 15%; text-align: center\">");
                        strBuilder.Append("      <a href=\"javascript:void(0);\" onclick=\"delProAId(this,'" + dt.Tables[0].Rows[i]["AID"] + "','" + dt.Tables[0].Rows[i]["PID"] + "');return false;\" data-backdrop=\"false\">删除</a>");
                        strBuilder.Append("  </td>");
                        strBuilder.Append(" </tr>");
                    }
                }
            }
            return strBuilder.ToString();
        }
    }
}