<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProfOrg.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddProfOrg" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">

    <title>专业机构</title>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>机构名称：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="机构名称" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>地址：</label>
                    <div class="controls">
                        <input type="text" id="txtaddr" placeholder="地址" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>法人：</label>
                    <div class="controls">
                        <input type="text" id="txtfr" placeholder="法人" runat="server" />
                    </div>
                </div>
                
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>联系人：</label>
                    <div class="controls">
                        <input type="text" id="txtContact" placeholder="联系人" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>联系电话：</label>
                    <div class="controls">
                        <input type="text" id="txttel" placeholder="联系电话" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>邮箱：</label>
                    <div class="controls">
                        <input type="text" id="txtemail" placeholder="邮箱" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>主营方向：</label>
                    <div class="controls">
                        <input type="text" id="txtMajorSell" placeholder="主营方向" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>机构简介：</label>
                    <div class="controls">
                        <textarea id="txtdescri" placeholder="机构简介" runat="server" rows="4"></textarea>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>机构资质：</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuphoto" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>营业执照：</label>
                    <div class="controls">
                        <asp:FileUpload ID="fuyyzz" runat="server" />
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
