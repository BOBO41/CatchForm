<%@ Page Title="提升服务" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Promote.aspx.cs" Inherits="ECommerce.Web.Promote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>提升服务</h2>
            <p class="lead">提升服务介绍</p>
        </div>
    </div>
    <!--/inner-page-->

    <div class="service-box">
        <div class="row">
            <div class="left-menu media-left">
                <ul class="nav">
                    <li><a class="active" href="Promote.aspx">提升服务介绍</a></li>
                    <li><a href="Mechanism.aspx">专业机构</a></li>
                    <li><a href="Expert.aspx">专家顾问库</a></li>
                    <li><a href="Message.aspx">提升服务留言咨询</a></li>
                    <li><a href="Apply.aspx">提升服务申请</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <h2>提升服务介绍</h2>
                <div class="cp-about">
                    <asp:Literal ID="litDescri" runat="server"></asp:Literal>
                </div>
            </div>
            <!--/right-box-->
        </div>
    </div>
    <!--/service-box-->
</asp:Content>
