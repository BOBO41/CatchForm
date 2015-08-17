<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisory.aspx.cs" Inherits="ECommerce.Web.Manage.Services.Advisory" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>咨询管理</title>
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
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddReply.aspx?OrgId=' + aId, title: '回复' });
            window.top.$modal.show();
        }
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
        function navIframe(url) {
            $("#mainFrame", top.document.body).attr("src", url);
        }
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel" style="border-top: none">
            <div class="pannel-header">
                <strong>咨询管理</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    姓名：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="姓名" />
                    状态：<asp:DropDownList runat="server" ID="ddlStatus" Width="120px" OnSelectedIndexChanged="btnSearch_Click" AutoPostBack="True">
                        <asp:ListItem Value="-1" Selected="True">回复状态</asp:ListItem>
                        <asp:ListItem Value="0">未回复</asp:ListItem>
                        <asp:ListItem Value="1">已回复</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">咨询内容</th>
                        <th nowrap="nowrap">姓名</th>
                        <th nowrap="nowrap">联系方式</th>
                        <th nowrap="nowrap">咨询时间</th>
                        <th nowrap="nowrap">状态</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("ID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center" title="<%#Eval("Advisory")%>"><%#Eval("Advisory")%></td>
                                <%--<td style="text-align: center" title="<%#Eval("Advisory")%>"><%#Eval("Advisory").ToString().Length>90?Eval("Advisory").ToString().Substring(0,90)+"...":Eval("Advisory").ToString()%></td>--%>
                                <td style="text-align: center"><%#Eval("Contact")%></td>
                                <td style="text-align: center"><%#Eval("Tel")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center"><%#Eval("status").ToString()=="0"?"未回复":"已回复"%></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="回复" onclick="editData('<%#Eval("ID")%>')">回复</a>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("ID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
