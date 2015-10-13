<%@ Page Title="客户评价" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CMessage.aspx.cs" Inherits="ECommerce.Web.CMessage" %>

<%@ Register Src="UserControl/Pager1.ascx" TagName="Pager1" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <form id="form1" runat="server">
        <div class="inner-page">
            <div class="container">
                <h2>客户评价</h2>
            </div>
        </div>
        <div class="about">
            <div class="row">
                <div class="comment-list">
                    <h2>客户评价<span>(<asp:Literal ID="Literal1" runat="server"></asp:Literal>条)</span></h2>
                    <ul>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <h4 class="title"><%#Eval("Title")%><span><%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%></span></h4>
                                    <p><%#Eval("Content")%></p>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <uc1:Pager1 ID="Pager11" runat="server" />
                </div>
                <!--/comment-->
            </div>
        </div>

    </form>

</asp:Content>
