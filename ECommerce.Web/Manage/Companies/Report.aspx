<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ECommerce.Web.Manage.Companies.Report" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="pannel">
            <div class="pannel-body">
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="table-form">
                    <tr>
                        <th>文件名</th>
                        <th>创建时间</th>
                        <th>下载</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center"><%# Eval("FileName") %></td>
                                <td style="text-align: center"><%# Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd") %></td>
                                <td style="text-align: center"><a href="Report.aspx?fid=<%# Eval("ID") %>">下载</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="text-center">
                <input type="button" class="btn" style="margin-bottom: 10px;" name="Previous" id="Previous" value="返回" onclick="javascript: history.back();">
            </div>
        </div>
    </form>
</body>
</html>
