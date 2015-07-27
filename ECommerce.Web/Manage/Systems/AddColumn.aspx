<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddColumn.aspx.cs" Inherits="ECommerce.Web.Manage.CM.AddColumn" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">

    <title>农资电商后台管理系统</title>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label"><span style="color: red">*</span>栏目名称：</label>
                    <div class="controls">
                        <input type="text" id="txtColName" runat="server" style="width: 300px" maxlength="20" placeholder="请输入栏目分类名称" class="input-block-level">
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
                var ColName = $("#txtColName").val();
                $.ajax({
                    type: 'POST', url: '/Manage/CM/Ajax/AddColumn.aspx?ColId=<%=Request.QueryString["ColId"]%>&PTColId=<%=Request.QueryString["PTColId"]%>&ColName=' + encodeURI(encodeURI(ColName)), success: function (data) {
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

