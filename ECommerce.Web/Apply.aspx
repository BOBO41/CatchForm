<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="ECommerce.Web.Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <form runat="server" id="form2">
        <div class="inner-page">
            <div class="container">
                <h2>提升服务</h2>
                <p class="lead">提升服务申请</p>
            </div>
        </div>
        <div class="service-box">
            <div class="row">
                <div class="left-menu media-left">
                    <ul class="nav">
                        <li><a href="Promote.aspx">提升服务介绍</a></li>
                        <li><a href="Mechanism.aspx">专业机构</a></li>
                        <li><a href="Expert.aspx">专家顾问库</a></li>
                        <li><a href="Message.aspx">提升服务留言咨询</a></li>
                        <li><a class="active" href="Apply.aspx">提升服务申请</a></li>
                    </ul>
                </div>
                <!--/left-menu-->
                <div class="right-box">
                    <h2>服务申请</h2>
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
                            <asp:Button runat="server" Text="提交" class="btn btn-primary btn-lg" OnClick="Unnamed1_Click" />
                        </div>
                    </div>

                </div>
                <!--/right-box-->
            </div>
        </div>
    </form>
</asp:Content>
