<%@ Page Title="测评服务" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="ECommerce.Web.Evaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>测评服务</h2>
            <p class="lead">测评介绍</p>
        </div>
    </div>
    <!--/inner-page-->

    <div class="service-box">
        <div class="row">
            <div class="left-menu media-left">
                <ul class="nav">
                    <li><a class="active" href="Evaluation.aspx">测评介绍</a></li>
                    <li><a href="ComApply.aspx">测评申请</a></li>
                    <li><a href="EvaluationList.aspx">测评企业</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <h2>测评介绍</h2>
                <div class="cp-about">
                    <asp:Literal ID="litDescri" runat="server"></asp:Literal>
                </div>
            </div>
            <!--/right-box-->
        </div>
    </div>
    <!--/service-box-->
</asp:Content>
