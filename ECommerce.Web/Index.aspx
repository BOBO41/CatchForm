<%@ Page Title="企业测评诊断及提升服务平台" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ECommerce.Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <!-- banner start -->
    <div class="banner">
        <div class="banner-box"></div>
    </div>
    <!-- banner end -->
    <div class="mainbox features">
        <div class="row">
            <div class="col-md-4">
                <div class="feature-wrap">
                    <img src="images/image/ico-cp.png">
                    <h2>测评服务</h2>
                    <p>西安生产力促进中心项目咨询部，是定位于围绕高科技项目的科技计划申报的专业咨询服务机构。以“科技项目申报”为主营业务，背靠政府</p>
                    <a href="Evaluation.aspx">了解&gt;</a>
                </div>
            </div>
            <!--/.col-md-4-->
            <div class="col-md-4">
                <div class="feature-wrap">
                    <img src="images/image/ico-ts.png">
                    <h2>提升服务</h2>
                    <p>西安生产力促进中心项目咨询部，是定位于围绕高科技项目的科技计划申报的专业咨询服务机构。以“科技项目申报”为主营业务，背靠政府</p>
                    <a href="Promote.aspx">了解&gt;</a>
                </div>
            </div>
            <!--/.col-md-4-->
            <div class="col-md-4">
                <div class="feature-wrap" style="background: none;">
                    <img src="images/image/ico-qyk.png">
                    <h2>企业库</h2>
                    <p>西安生产力促进中心项目咨询部，是定位于围绕高科技项目的科技计划申报的专业咨询服务机构。以“科技项目申报”为主营业务，背靠政府</p>
                    <a href="#">了解&gt;</a>
                </div>
            </div>
            <!--/.col-md-4-->
        </div>
        <!--/.row-->
    </div>
    <!--/.container-->
    <div class="mainbox promote">
        <div class="row">
            <div class="col-sm-6 mechanism">
                <h3>提升服务机构</h3>
                <asp:Repeater ID="rptOrg" runat="server">
                    <ItemTemplate>
                        <div class="media">
                            <h4><%#Eval("Name").ToString().Length>20? Eval("Name").ToString().Substring(0,20)+"...":Eval("Name").ToString()%></h4>
                            <p><%#Eval("Descr").ToString().Length>29? Eval("Descr").ToString().Substring(0,29)+"...":Eval("Descr").ToString()%></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="more"><a href="Mechanism.aspx">更多机构&gt;</a></div>
            </div>
            <!--/.col-sm-6-->

            <div class="col-sm-6" id="ad">
                <div class="accordion">
                    <h3>提升服务专家</h3>
                    <div>
                        <asp:Repeater ID="rptexp" runat="server">
                            <ItemTemplate>
                                <div class="media">
                                    <div class="media-left">
                                        <img src="<%#Eval("Photo")%>">
                                    </div>
                                    <div class="media-body">
                                        <h4 class="media-heading"><%#Eval("Name")%></h4>
                                        <%#Eval("Descri").ToString().Length>35? Eval("Descri").ToString().Substring(0,35)+"...":Eval("Descri").ToString()%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="more"><a href="Expert.aspx">更多专家&gt;</a></div>

                </div>
            </div>
            <!--/.col-sm-6-->
        </div>
        <!--/.row-->
    </div>
    <!--/.container-->
    <div class="mainbox listbox">
        <div class="row">
            <div class="col-sm-6 mechanism">
                <div class="reviews">
                    <div class="last-title">
                        <h3>客户评价</h3>
                        <a href="CMessage.aspx">更多评价&gt;</a>
                    </div>
                    <div class="media list_lh">
                        <asp:Literal ID="litCum" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <!--/.col-sm-6-->

            <div class="col-sm-6">
                <div class="accordion">
                    <div class="last-title">
                        <h3>已评测企业</h3>
                        <a href="EvaluationList.aspx">更多企业&gt;</a>
                    </div>
                    <ul id="list">
                        <asp:Repeater ID="rptCom" runat="server">
                            <ItemTemplate>
                                <li><%#Eval("ComName").ToString().Length>20? Eval("ComName").ToString().Substring(0,20)+"...":Eval("ComName").ToString()%></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--/.col-sm-6-->
        </div>
        <!--/.row-->
    </div>
    <script src="js/scroll.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("div.list_lh").myScroll({
                speed: 40, //数值越大，速度越慢
                rowHeight: 200 //li的高度
            });
        })
</script>
</asp:Content>
