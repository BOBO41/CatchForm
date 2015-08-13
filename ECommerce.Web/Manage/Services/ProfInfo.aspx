<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfInfo.aspx.cs" Inherits="ECommerce.Web.Manage.Services.ProfInfo" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>专家信息</title>
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
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfInfo.aspx?aId=' + aId, title: '新增专家信息' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfInfo.aspx?OrgId=' + aId, title: '编辑专家信息' });
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
                <strong>专家信息</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    专家姓名：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="专家姓名" />
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
                        <th nowrap="nowrap">专家姓名</th>
                        <th nowrap="nowrap">所属分类</th>
                        <th nowrap="nowrap">年龄</th>
                        <th nowrap="nowrap">工作单位</th>
                        <th nowrap="nowrap">职称/职务</th>
                        <th nowrap="nowrap">研究方向</th>
                        <th nowrap="nowrap">专家简介</th>
                        <th nowrap="nowrap">学历</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("PIID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("Name")%></td>
                                <td style="text-align: center"><%#Eval("TName")%></td>
                                <td style="text-align: center"><%#Eval("Age")%></td>
                                <td style="text-align: center"><%#Eval("ComAddr")%></td>
                                <td style="text-align: center"><%#Eval("Job")%></td>
                                <td style="text-align: center"><%#Eval("MajorSearch")%></td>
                                <td style="text-align: center"><%#Eval("Descri")%></td>
                                <td style="text-align: center"><%#Eval("Education")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑专家信息" onclick="editData('<%#Eval("PIID")%>')">编辑</a>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("PIID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
