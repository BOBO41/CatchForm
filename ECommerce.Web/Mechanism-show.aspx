<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mechanism-show.aspx.cs" Inherits="ECommerce.Web.Mechanism_show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>提升服务</h2>
            <p class="lead">提升服务介绍</p>
        </div>
    </div>
    <div class="service-box">
        <div class="row">
            <div class="left-menu media-left">
                <ul class="nav">
                    <li><a href="Promote.aspx">提升服务介绍</a></li>
                    <li><a class="active" href="Mechanism.aspx">专业机构</a></li>
                    <li><a href="Expert.aspx">专家顾问库</a></li>
                    <li><a href="Message.aspx">提升服务留言咨询</a></li>
                    <li><a href="Apply.aspx">提升服务申请</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <div class="show-content">
                    <a href="Mechanism.aspx">【返回】</a>
                    <div class="page-info-header">
                        <h2><asp:Literal ID="Literal10" runat="server"></asp:Literal></h2>
                        <p>分类：<a href="Mechanism.aspx" rel="tag">专业机构</a>&nbsp;&nbsp;&nbsp;发布时间：<asp:Literal ID="Literal9" runat="server"></asp:Literal></p>

                    </div>
                    <div class="page-info-body">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td>机构名称：<asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                                    <td>地址：<asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td>法人：
                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
                                    <td>联系人：<asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td>联系电话：<asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
                                    <td>邮箱：<asp:Literal ID="Literal6" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td>主营方向：<asp:Literal ID="Literal7" runat="server"></asp:Literal></td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                        <p>
                            <asp:Literal ID="Literal8" runat="server"></asp:Literal></p>

                    </div>
                </div>
            </div>
            <!--/right-box-->
        </div>
    </div>
</asp:Content>
