<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Expert-show.aspx.cs" Inherits="ECommerce.Web.Expert_show" %>

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
                    <li><a href="Mechanism.aspx">专业机构</a></li>
                    <li><a class="active" href="Expert.aspx">专家顾问库</a></li>
                    <li><a href="Message.aspx">提升服务留言咨询</a></li>
                    <li><a href="Apply.aspx">提升服务申请</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <div class="show-content">
                    <a href="Expert.aspx">【返回】</a>
                    <div class="page-info-header">
                        <h2>
                            <asp:literal id="Literal10" runat="server"></asp:literal>
                        </h2>
                        <p>分类：<a href="Expert.aspx" rel="tag">专家顾问库</a>&nbsp;&nbsp;&nbsp;发布时间：<asp:literal id="Literal9" runat="server"></asp:literal></p>

                    </div>
                    <div class="page-info-body">
                        <p style="text-align: center">
                            <img src="<%#Eval("Photo")!=DBNull.Value? Eval("Photo").ToString():"images/image/expert.jpg"%>"></p>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td>所属分类：<asp:literal id="Literal1" runat="server"></asp:literal></td>
                                    <td>工作单位：<asp:literal id="Literal2" runat="server"></asp:literal></td>
                                </tr>
                                <tr>
                                    <td>职称/职务：
                                        <asp:literal id="Literal3" runat="server"></asp:literal>
                                    </td>
                                    <td>研究方向：<asp:literal id="Literal4" runat="server"></asp:literal></td>
                                </tr>
                                <tr>
                                    <td>学历：<asp:literal id="Literal5" runat="server"></asp:literal></td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                        <p>
                            <asp:literal id="Literal8" runat="server"></asp:literal>
                        </p>

                    </div>
                </div>
            </div>
            <!--/right-box-->
        </div>
    </div>
</asp:Content>
