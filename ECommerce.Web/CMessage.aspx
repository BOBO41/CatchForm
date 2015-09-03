<%@ Page Title="客户评价" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CMessage.aspx.cs" Inherits="ECommerce.Web.CMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>客户评价</h2>
        </div>
    </div>
    <div class="about">
        <div class="row">
            <asp:Literal ID="litDescri" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
