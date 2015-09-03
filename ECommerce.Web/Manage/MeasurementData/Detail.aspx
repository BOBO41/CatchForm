<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ECommerce.Web.Manage.MeasurementData.Detail" %>

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
	<div class="pannel-header"><strong>对比数据</strong></div>
            <div class="pannel-body">
 <div class="btn-toolbar">
                <input type="button" class="btn btn-mini" style="margin-bottom: 10px;" name="Previous" id="Previous" value="返回" onclick="javascript: history.back();">
            </div>
     
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="table">
                    <tr>
                        <td class="tf-label">国家及地区：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">员工人数：
                        </td>
                        <td class="tf-con">
                            多于 <asp:Literal ID="Literal2" runat="server"></asp:Literal> 少于 <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">营业额：
                        </td>
                        <td class="tf-con">
                            多于 <asp:Literal ID="Literal4" runat="server"></asp:Literal> 少于 <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">行业领域：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">NACE代码：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">支行业：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal9" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">Select NACE：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">SIC Code：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal11" runat="server"></asp:Literal>
                        </td>
                    </tr>

                </table>
            </div>
              </div>
    </form>
</body>
</html>
