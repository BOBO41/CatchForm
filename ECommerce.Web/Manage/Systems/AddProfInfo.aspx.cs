using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddProfInfo : UI.WebPage {
        private readonly ProfInfo _dataDal = new ProfInfo();
        private readonly ProfType _dataSWCDal = new ProfType();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                BindOrgTrain();
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                    BindData(Request.QueryString["OrgId"]);
                }
            }
        }

        private void BindOrgTrain() {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var str = " 1=1 order by CreateDate desc ";
            var dt = _dataSWCDal.GetList(str, parameters).Tables[0];
            ddltype.DataSource = dt;
            ddltype.DataTextField = "Name";
            ddltype.DataValueField = "PTID";
            ddltype.DataBind();
            ddltype.Items.Insert(0, new ListItem("请选择", ""));
        }

        private void BindData(string orgId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (null != model) {
                    txtName.Value = model.Name;
                    txtaddr.Value = model.ComAddr;
                    txtage.Value = model.Age;
                    txtdescr.Value = model.Descri;
                    txtedu.Value = model.Education;
                    txtjob.Value = model.Job;
                    txtserch.Value = model.MajorSearch;
                    ddltype.SelectedValue = model.PTID.ToString();
                    if (!string.IsNullOrEmpty(model.Photo)) {
                        Image1.Visible = true;
                        Image1.ImageUrl = model.Photo;
                    }
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            const string imgPath = "/UpLoad/Image";
            var name = txtName.Value.Trim();
            var type = ddltype.SelectedValue;
            var addr = txtaddr.Value;
            var descr = txtdescr.Value;
            var age = txtage.Value;
            var job = txtjob.Value;
            var ser = txtserch.Value;
            var edu = txtedu.Value;
            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写专家姓名！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(type)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择所属分类！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(addr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写工作单位！');</script>");
                return;
            }

            if (string.IsNullOrEmpty(descr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写专家简介！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(age)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写专家年龄！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(job)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写职称/职务！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(ser)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写研究方向！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(edu)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写学历！');</script>");
                return;
            }


            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('专家信息不存在！');</script>");
                        return;
                    }
                    var exists =
                        _dataDal.GetModel(
                            " Name='" + name + "' and PIID!=" + Convert.ToInt32(Request.QueryString["OrgId"]),
                            new List<SqlParameter>());
                    if (null != exists) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('专家信息已经存在！');</script>");
                        return;
                    }
                    dt.Age = age;
                    dt.ComAddr = addr;
                    dt.Descri = descr;
                    dt.Education = edu;
                    dt.Job = job;
                    dt.MajorSearch = ser;
                    dt.Name = name;
                    dt.PTID = Convert.ToInt32(type);
                    dt.UId = CurrentUser.UId;

                    if (fuPImg.HasFile) {
                        if (!string.IsNullOrEmpty(dt.Photo)) {
                            DirFile.DeleteFile(dt.Photo);
                        }
                        int size;
                        string msg;
                        string imgUrl;
                        UpImg(ref fuPImg, out imgUrl, out msg, imgPath, out size);
                        if (string.IsNullOrEmpty(imgUrl)) {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + msg + "');</script>");
                            return;
                        }
                        dt.Photo = imgUrl;
                    }
                    var res = _dataDal.Update(dt);
                    if (res) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('更新失败！');window.top.$modal.destroy();</script>");
                    }
                }
                catch (Exception) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                }
            }
            else {
                var model = new ECommerce.Admin.Model.ProfInfo {
                    Age = age,
                    Descri = descr,
                    ComAddr = addr,
                    CreateDate = DateTime.Now,
                    Education = edu,
                    Job = job,
                    MajorSearch = ser,
                    Name = name,
                    PTID = Convert.ToInt32(type),
                    Status = 1
                };
                var exists = _dataDal.GetModel(" Name='" + name + "' ", new List<SqlParameter>());
                if (null != exists) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('专家信息已经存在！');</script>");
                    return;
                }
                if (fuPImg.HasFile) {
                    int size;
                    string msg;
                    string imgUrl;
                    UpImg(ref fuPImg, out imgUrl, out msg, imgPath, out size);
                    if (string.IsNullOrEmpty(imgUrl)) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + msg + "');</script>");
                        return;
                    }
                    model.Photo = imgUrl;
                }
                var resAdd = _dataDal.Add(model);
                if (resAdd > 0) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('新增失败！');window.top.$modal.destroy();</script>");
                }
            }
        }

        public static void UpImg(ref FileUpload upfile_href, out string imgurl, out string msg, string imgPath, out int size) {
            string datatime = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (upfile_href.HasFile) {
                string fileName = upfile_href.FileName;
                string fileExition = System.IO.Path.GetExtension(fileName).ToLower();
                string de = "|.gif|.png|.jpeg|.jpg|.bmp";
                string strDay = System.DateTime.Now.ToString("yyyyMM");
                string path = HttpContext.Current.Server.MapPath(imgPath + "/" + strDay + "/");
                if (!System.IO.Directory.Exists(path)) {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (fileName == "") {
                    msg = "请选择上传的图片";
                    imgurl = "";
                    size = 0;
                    return;
                }
                if (de.IndexOf(fileExition) > 0) {
                    string NewFileName = datatime + fileExition;
                    upfile_href.PostedFile.SaveAs(path + NewFileName);
                    size = upfile_href.PostedFile.ContentLength;
                    imgurl = imgPath + "/" + strDay + "/" + NewFileName;
                    msg = "上传成功!";
                }
                else {
                    msg = "上传图片格式错误";
                    imgurl = "";
                    size = 0;
                }
            }
            else {
                imgurl = "";
                msg = "请选择上传的图片";
                size = 0;
            }
        }

    }
}