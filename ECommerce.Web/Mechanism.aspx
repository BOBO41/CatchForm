<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mechanism.aspx.cs" Inherits="ECommerce.Web.Mechanism" %>
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
                    <li><a class="active" href="Mechanism.aspx">提升服务机构</a></li>
                    <li><a href="Expert.aspx">提升服务专家</a></li>
                    <li><a href="Message.aspx">提升服务留言咨询</a></li>
                    <li><a href="Apply.aspx">提升服务申请</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <h2>提升服务机构</h2>
                <div class="mechanism-list">
                    <asp:Repeater ID="rptCom" runat="server">
                        <ItemTemplate>
                            <div class="media">
                                <h4><%#Eval("Name").ToString().Length>20? Eval("Name").ToString().Substring(0,20)+"...":Eval("Name").ToString()%></h4>
                                <p><%#Eval("Descr").ToString().Length>100? Eval("Descr").ToString().Substring(0,100)+"...":Eval("Descr").ToString()%></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!--/right-box-->
        </div>
    </div>
</asp:Content>
