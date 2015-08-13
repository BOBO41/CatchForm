<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfType.aspx.cs" Inherits="ECommerce.Web.Manage.Services._ProfType" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>专家类型</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/themes/js/wiimedia-market.js"></script>
</head>
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
    function addData() {
        window.top.$op = this.window;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfType.aspx', title: '新增专家类型' });
        window.top.$modal.show();
    }
    function openModal(url, title) {
        window.top.$op = this.window;
        window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
        window.top.$modal.show();
    }
</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel" style="border-top: none">
            <div class="pannel-header">
                <strong>专家类型</strong>
            </div>
            <div class="pannel-body">
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">专家类型</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th class="act" nowrap="nowrap">操作</th>
                    </tr>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("PTID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("Name")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td class="act">
                                    <a href="javascript:void(0);" class="btn btn-mini" onclick="openModal('/Manage/Systems/AddProfType.aspx?empId=<%#Eval("PTID")%>','编辑专家类型')">编辑</a>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("PTID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
