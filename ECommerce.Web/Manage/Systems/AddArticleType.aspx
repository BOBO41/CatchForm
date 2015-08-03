<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddArticleType.aspx.cs" Inherits="ECommerce.Web.Manage.CM.AddArticleType" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">

    <title>企业测评诊断与提升服务系统</title>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label"><span style="color: red">*</span>类型名称：</label>
                    <div class="controls">
                        <input type="text" id="txtATName" runat="server" style="width: 300px" maxlength="20" placeholder="请输入类型名称" class="input-block-level">
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">显示样式：</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlDisplayCss" Width="120px">
                            <asp:ListItem Value="红色" Selected="True">红色</asp:ListItem>
                            <asp:ListItem Value="黄色">黄色</asp:ListItem>
                            <asp:ListItem Value="绿色">绿色</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAdd();" class="btn btn-success">保存</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script type="text/javascript">
            function goAdd() {
                var ATName = $("#txtATName").val();
                var DisplayCss = $("#<% =ddlDisplayCss.ClientID%>").val();
                $.ajax({
                    type: 'POST', url: '/Manage/CM/Ajax/AddArticleType.aspx?ATId=<%=Request.QueryString["ATId"]%>&ATName=' + encodeURI(encodeURI(ATName)) + '&DisplayCss=' + encodeURI(encodeURI(DisplayCss)), success: function (data) {
                        if (data == "保存成功") {
                            window.top.$op.location = window.top.$op.location;
                            window.top.$modal.destroy();
                        } else {
                            alert(data);
                        }
                    }
                });
            }
        </script>

    </form>
</body>
</html>

