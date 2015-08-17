using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddProfOrg : UI.WebPage {
        private readonly ProfOrg _dataDal = new ProfOrg();
        private readonly ProfType _dataSWCDal = new ProfType();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                    BindData(Request.QueryString["OrgId"]);
                }

            }
        }
        private void BindData(string orgId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (null != model) {
                    txtName.Value = model.Name;
                    txtaddr.Value = model.Addr;
                    txtContact.Value = model.Contact;
                    txtMajorSell.Value = model.MajorSell;
                    txtdescri.Value = model.Descr;
                    txtfr.Value = model.FR;
                    txttel.Value = model.Tel;
                    txtemail.Value = model.Email;
                    if (!string.IsNullOrEmpty(model.OrgAptitude)) {
                        Image1.Visible = true;
                        Image1.ImageUrl = model.OrgAptitude;
                    }
                    if (!string.IsNullOrEmpty(model.YYZZ)) {
                        Image2.Visible = true;
                        Image2.ImageUrl = model.YYZZ;
                    }
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            const string imgPath = "/UpLoad/Image";
            var name = txtName.Value.Trim();
            var addr = txtaddr.Value;
            var Contact = txtContact.Value;
            var MajorSell = txtMajorSell.Value;
            var descri = txtdescri.Value;
            var fr = txtfr.Value;
            var tel = txttel.Value;
            var email = txtemail.Value;
            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写机构名称！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(addr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写地址！');</script>");
                return;
            }

            if (string.IsNullOrEmpty(Contact)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写联系人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(fr)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写法人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(MajorSell)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写主营方向！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(descri)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写机构简介！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(tel)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写联系电话！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(email)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写邮箱！');</script>");
                return;
            }


            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('机构信息不存在！');</script>");
                        return;
                    }
                    var exists =
                        _dataDal.GetModel(
                            " Name='" + name + "' and OID!=" + Convert.ToInt32(Request.QueryString["OrgId"]),
                            new List<SqlParameter>());
                    if (null != exists) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('机构名称已经存在！');</script>");
                        return;
                    }
                    dt.Email = email;
                    dt.Addr = addr;
                    dt.Contact = Contact;
                    dt.FR = fr;
                    dt.MajorSell = MajorSell;
                    dt.Tel = tel;
                    dt.Name = name;
                    dt.UpdateDate = DateTime.Now;
                    dt.UId = CurrentUser.UId;
                    if (fuPImg.HasFile) {
                        if (!string.IsNullOrEmpty(dt.OrgAptitude)) {
                            DirFile.DeleteFile(dt.OrgAptitude);
                        }
                        int size;
                        string msg;
                        string imgUrl;
                        UpImg(ref fuPImg, out imgUrl, out msg, imgPath, out size);
                        if (string.IsNullOrEmpty(imgUrl)) {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + msg + "');</script>");
                            return;
                        }
                        dt.OrgAptitude = imgUrl;
                    }
                    if (FileUpload1.HasFile) {
                        if (!string.IsNullOrEmpty(dt.YYZZ)) {
                            DirFile.DeleteFile(dt.YYZZ);
                        }
                        int size;
                        string msg;
                        string imgUrl;
                        UpImg(ref FileUpload1, out imgUrl, out msg, imgPath, out size);
                        if (string.IsNullOrEmpty(imgUrl)) {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + msg + "');</script>");
                            return;
                        }
                        dt.YYZZ = imgUrl;
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
                var model = new ECommerce.Admin.Model.ProfOrg {
                    Descr = descri,
                    Tel = tel,
                    Email = email,
                    CreateDate = DateTime.Now,
                    Addr = addr,
                    FR = fr,
                    MajorSell = MajorSell,
                    Name = name,
                    UId = CurrentUser.UId,
                    Contact = Contact,
                    Status = 1
                };
                var exists = _dataDal.GetModel(" Name='" + name + "' ", new List<SqlParameter>());
                if (null != exists) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('机构名称已经存在！');</script>");
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
                    model.OrgAptitude = imgUrl;
                }
                if (FileUpload1.HasFile) {
                    int size;
                    string msg;
                    string imgUrl;
                    UpImg(ref FileUpload1, out imgUrl, out msg, imgPath, out size);
                    if (string.IsNullOrEmpty(imgUrl)) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + msg + "');</script>");
                        return;
                    }
                    model.YYZZ = imgUrl;
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