<%@ Page Title="测评申请" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComApply.aspx.cs" Inherits="ECommerce.Web.ComApply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <form runat="server" id="form2">
        <div class="inner-page">
            <div class="container">
                <h2>测评申请</h2>
                <p class="lead">企业测评申请</p>
            </div>
        </div>
        <div class="service-box">
            <div class="row">
                <div class="left-menu media-left">
                    <ul class="nav">
                        <li><a href="Evaluation.aspx">测评介绍</a></li>
                        <li><a class="active" href="ComApply.aspx">测评申请</a></li>
                        <li><a href="EvaluationList.aspx">测评企业</a></li>
                    </ul>
                </div>
                <!--/left-menu-->
                <div class="right-box">
                    <h2>测评申请</h2>
                    <div class="message">
                        <div class="form-group">
                            <label>企业姓名</label>
                            <input name="subject" class="form-control" required="" type="text" id="txtname" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>企业地址</label>
                            <input name="subject" class="form-control" required="" type="text" id="txtAddr" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>联系人</label>
                            <input name="subject" class="form-control" required="" type="text" id="txtContact" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>联系电话</label>
                            <input name="subject" class="form-control" required="" type="text" id="txtTel" runat="server" />
                        </div>
                        <div class="form-group">
                            <asp:button runat="server" text="提交" class="btn btn-primary btn-lg" onclick="Unnamed1_Click" />
                        </div>
                    </div>

                </div>
                <!--/right-box-->
            </div>
        </div>
    </form>
</asp:Content>
