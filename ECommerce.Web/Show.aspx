<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="ECommerce.Web.Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <div class="show">
        <div class="row">
            <div class="back"><a href="EvaluationList.aspx">[返回]</a></div>
            <div class="show-title">
                <h1><asp:Literal ID="litName" runat="server"></asp:Literal></h1>
                <div class="time">发布时间：<asp:Literal ID="litDate" runat="server"></asp:Literal></div>
            </div>
            <asp:Literal ID="litCon" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
