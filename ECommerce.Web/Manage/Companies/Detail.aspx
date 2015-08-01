<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ECommerce.Web.Manage.Companies.Detail" %>

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
                        <td class="tf-label">企业名称：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">企业编号：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal27" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">地址1：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">地址2：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">地址3：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">城市：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">地区：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">邮政编码：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">国家：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">联系电话：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal9" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">传真：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">企业描述：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal11" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal12" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">支行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal13" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">NACE代码：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal14" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal24" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">支行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal25" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">NACE代码：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal26" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">选择SIC代码：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal15" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">选择支行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal16" runat="server"></asp:Literal>
                        </td>
                        <tr>
                            <td class="tf-label">选择支行业：
                            </td>
                            <td class="tf-con">
                                <asp:Literal ID="Literal17" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    <tr>
                        <td class="tf-label">员工人数：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal18" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">本国公司：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal19" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">联系人称谓：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal20" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">联系人姓氏：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal21" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">联系人名字：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal22" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">职位：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal23" runat="server"></asp:Literal>
                        </td>
                    </tr>

                </table>
            </div>
            <div class="text-center">
                <input type="button" class="btn" style="margin-bottom: 10px;" name="Previous" id="Previous" value="返回" onclick="javascript: history.back();">
            </div>
        </div>
    </form>
</body>
</html>
