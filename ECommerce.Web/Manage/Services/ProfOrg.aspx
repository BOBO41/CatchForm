<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfOrg.aspx.cs" Inherits="ECommerce.Web.Manage.Services.ProfOrg" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>专业机构</title>
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
        function addData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfOrg.aspx?aId=' + aId, title: '新增专业机构' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfOrg.aspx?OrgId=' + aId, title: '编辑专业机构' });
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
                <strong>专业机构</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    机构名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="机构名称" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">机构名称</th>
                        <th nowrap="nowrap">地址</th>
                        <th nowrap="nowrap">法人</th>
                        <th nowrap="nowrap">联系人</th>
                        <th nowrap="nowrap">联系电话</th>
                        <th nowrap="nowrap">邮箱</th>
                        <th nowrap="nowrap">主营方向</th>
                        <th nowrap="nowrap">机构简介</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("OID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("Name")%></td>
                                <td style="text-align: center"><%#Eval("Addr")%></td>
                                <td style="text-align: center"><%#Eval("FR")%></td>
                                <td style="text-align: center"><%#Eval("Contact")%></td>
                                <td style="text-align: center"><%#Eval("Tel")%></td>
                                <td style="text-align: center"><%#Eval("Email")%></td>
                                <td style="text-align: center"><%#Eval("MajorSell")%></td>
                                <td style="text-align: center"><%#Eval("Descr")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑机构信息" onclick="editData('<%#Eval("OID")%>')">编辑</a>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("OID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
