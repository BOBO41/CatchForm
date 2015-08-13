<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProfInfo.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddProfInfo" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">

    <title>专家信息</title>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>专家姓名：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="专家姓名" runat="server" />
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>所属分类：</label>
                    <div class="controls">
                        <asp:DropDownList ID="ddltype" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>专家年龄：</label>
                    <div class="controls">
                        <input type="text" id="txtage" placeholder="年龄" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>工作单位：</label>
                    <div class="controls">
                        <input type="text" id="txtaddr" placeholder="工作单位" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>职称/职务：</label>
                    <div class="controls">
                        <input type="text" id="txtjob" placeholder="职称/职务" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>研究方向：</label>
                    <div class="controls">
                        <input type="text" id="txtserch" placeholder="研究方向" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>专家简介：</label>
                    <div class="controls">
                        <textarea id="txtdescr" placeholder="专家简介" runat="server" rows="4"></textarea>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>学历：</label>
                    <div class="controls">
                        <input type="text" id="txtedu" placeholder="学历" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>照片：</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuphoto" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
