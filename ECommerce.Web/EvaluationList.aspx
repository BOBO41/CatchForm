<%@ Page Title="测评企业" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="EvaluationList.aspx.cs" Inherits="ECommerce.Web.EvaluationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>测评服务</h2>
            <p class="lead">测评企业</p>
        </div>
    </div>
    <!--/inner-page-->

    <div class="service-box">
        <div class="row">
            <div class="left-menu media-left">
                <ul class="nav">
                    <li><a href="Evaluation.aspx">测评介绍</a></li>
                    <li><a href="ComApply.aspx">测评申请</a></li>
                    <li><a class="active" href="EvaluationList.aspx">测评企业</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <h2>测评企业展示</h2>
                <div class="cp-list">
                    <asp:Repeater ID="rptCom" runat="server">
                        <ItemTemplate>
                            <div class="media">
                                <h4><a href="Show.aspx?id=<%#Eval("ID")%>"><%#Eval("ComName").ToString().Length>20? Eval("ComName").ToString().Substring(0,20)+"...":Eval("ComName").ToString()%></a></h4>
                                <p><%#Eval("ComDesc").ToString().Length>100? Eval("ComDesc").ToString().Substring(0,100)+"...":Eval("ComDesc").ToString()%></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!--/left-menu-->
        </div>
    </div>
    <!--/service-box-->
</asp:Content>
