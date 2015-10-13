<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="ECommerce.Web.Message" %>

<%@ Register Src="UserControl/Pager1.ascx" TagName="Pager1" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <form runat="server" id="form3">
        <div class="inner-page">
            <div class="container">
                <h2>提升服务</h2>
                <p class="lead">留言咨询</p>
            </div>
        </div>
        <div class="service-box">
            <div class="row">
                <div class="left-menu media-left">
                    <ul class="nav">
                        <li><a href="Promote.aspx">提升服务介绍</a></li>
                        <li><a href="Mechanism.aspx">专业机构</a></li>
                        <li><a href="Expert.aspx">专家顾问库</a></li>
                        <li><a class="active" href="Message.aspx">提升服务留言咨询</a></li>
                        <li><a href="Apply.aspx">提升服务申请</a></li>
                    </ul>
                </div>
                <!--/left-menu-->
                <div class="right-box">
                    <h2>留言咨询<a class="up_d" id="_strHref" href="javascript:show_hiddendiv();"><span id="_strSpan">我要留言</span></a></h2>
                    <div class="message">
                        <div id="hidden_div" style="display: none;">
                            <div class="form-group">
                                <label>姓名</label>
                                <input name="subject" class="form-control" required="" type="text" id="txtname">
                            </div>
                            <div class="form-group">
                                <label>联系方式</label>
                                <input name="subject" class="form-control" required="" type="text" id="txtaddr">
                            </div>
                            <div class="form-group">
                                <label>内容</label>
                                <textarea name="message" class="form-control" id="txtmessage" required="" rows="8"></textarea>
                            </div>
                            <div class="form-group">
                                <button name="submit" class="btn btn-primary btn-lg" required="required" type="button" onclick="lmessage();">提交</button>
                            </div>
                        </div>
                        <ul class="mess-list">
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <h4><%#Eval("Contact")%>  <%#Eval("Tel")%></h4>
                                        <p><%#Eval("Advisory")%></p>
                                        <ul class="reply">
                                            <li><%#Eval("Reply").ToString()==""?"":(Eval("EmplName")+" 回复："+Eval("Reply"))%>
                                        </ul>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <uc1:Pager1 ID="Pager11" runat="server" />
                        <script type="text/javascript">
                            function show_hiddendiv() {
                                document.getElementById("hidden_div").style.display = 'block';
                                document.getElementById("_strHref").href = 'javascript:hidden_showdiv();';
                                document.getElementById("_strSpan").innerHTML = "我要留言";
                            }
                            function hidden_showdiv() {
                                document.getElementById("hidden_div").style.display = 'none';
                                document.getElementById("_strHref").href = 'javascript:show_hiddendiv();';
                                document.getElementById("_strSpan").innerHTML = "我要留言";
                            }

                            function lmessage() {
                                var name = $("#txtname").val();
                                var addr = $("#txtaddr").val();
                                var cont = $("#txtmessage").val();
                                if (name == '') {
                                    alert("请填写姓名");
                                    return;
                                }
                                if (addr == '') {
                                    alert("请填写联系方式");
                                    return;
                                }
                                if (cont == '') {
                                    alert("请填写内容");
                                    return;
                                }
                                $.ajax({
                                    type: 'POST', url: '/AjaxMessage.aspx?mtype=0&name=' + encodeURI(encodeURI(name)) + '&cont=' + encodeURI(encodeURI(cont)) + '&addr=' + encodeURI(encodeURI(addr)), success: function (data) {
                                        if (data == "保存成功") {
                                            hidden_showdiv();
                                            $("#txtname").val('');
                                            $("#txtmessage").val('');
                                            $("#txtaddr").val('');
                                            alert("留言成功!");
                                        } else {
                                            alert(data);
                                        }
                                    }
                                });
                            }
                        </script>


                    </div>

                </div>
                <!--/right-box-->
            </div>
        </div>
    </form>
</asp:Content>
