<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCmPro.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddCmPro" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>设置</title>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <asp:HiddenField runat="server" ID="hidAid" />
                <table>
                    <tr>
                        <td>
                            <span style="color: red">*</span>生产厂商：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOrgName" runat="server" CssClass="inputText input-block-level" onchange="selectPro();">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table id="tabUser" class="table table-bordered" style="width: 100%;" border="0" cellspacing="0">
                    <tr>
                        <th style="width: 30px; text-align: center">选择</th>
                        <th style="text-align: center">商品名称</th>
                    </tr>
                    <tbody id="divPro">
                        <%=GetPro() %>
                    </tbody>
                </table>
            </div>
        </div>
        <script type="text/javascript">
            function selectPro() {
                var orgId = $("#<%=ddlOrgName.ClientID%>").val();
                $.ajax({
                    type: 'POST', url: '/Manage/CM/Ajax/CMProAjax.aspx?OrgId=' + orgId, success: function (data) {
                        $("#divPro").html(data);
                    }
                });

            }
        </script>
        <div class="modal-footer">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="保存" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
