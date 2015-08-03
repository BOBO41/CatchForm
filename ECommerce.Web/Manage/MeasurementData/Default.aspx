<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Web.Manage.MeasurementData.Default" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>企业测评诊断与提升服务系统</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#cbSelAll").click(function () {
                if ($(this).attr("checked")) {
                    $("#tabList input").attr("checked", $(this).attr("checked"));
                } else {
                    $("#tabList input").attr("checked", false);
                }
            });
        });
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel" style="border-top: none">
            <div class="pannel-header">
                <strong>测评数据</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    公司名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="公司名称" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-success" Text="导出" OnClick="btnExport_Click"/>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">公司编号</th>
                        <th nowrap="nowrap">公司名称</th>
                        <%--<th nowrap="nowrap">性别</th>
                        <th nowrap="nowrap">电话</th>
                        <th nowrap="nowrap">人员类型</th>
                        <th nowrap="nowrap">所属分站</th>--%>
                        <th nowrap="nowrap">录入时间</th>
                        <th class="act" nowrap="nowrap">查看详情</th>
                    </tr>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("ID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("ComID")%></td>
                                <td style="text-align: center"><%#Eval("ComName")%></td>
                                <%--<td style="text-align: center"><%#Eval("Sex").ToString()=="1" ? "男":"女"%></td>
                                <td style="text-align: center"><%#Eval("Phone")%></td>
                                <td style="text-align: center"><%#GetRoleName(Eval("Type"))%></td>
                                <td style="text-align: center"><%#Eval("OrgName")%></td>--%>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td class="act">
                                    <a href="Detail.aspx?id=<%#Eval("ComID") %>" class="btn btn-mini">查看详情</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <uc1:Pager ID="Pager1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
