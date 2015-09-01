<%@ Page Title="测评服务" Language="C#" MasterPageFile="MasterPage.master" %>

<asp:Content runat="server" ID="CpHeader" ContentPlaceHolderID="CPHeader"></asp:Content>
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
                    <li><a href="#">测评申请</a></li>
                    <li><a href="EvaluationList.aspx">测评企业</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <h2>测评介绍</h2>
                <div class="cp-about">
                    IPX 从网络中接收到数据包后，将它们传送给 SPX 进行处理。SPX 确保接收完整的，同发送时一样排序的数据包，以及消除重复的数据包。SPX 预备好数据包信息的分组序列，并负责控制接收的数据包的重组过程，以确认所有数据包都已接收到，如果没有则请求重新发送。SPX 直接与管理网络数据包转发过程的互联网分组交换协议（IPX） 共同工作。SPX提供连接封包传送方式比IPX可靠。SPX有连接辨识号码（Connections ID），若接收到错误封包时，立即要求对方重新传送。SPX 不支持文件服务器连接服务，文件服务器的连接是通过网络核心协议（NCP）实现的。SPX 的扩展协议为 SPX-II （SPX2）。
SPX 不支持组广播，所有数据包只能传送给单个的会话对象。 SPX 能够检测到会话对象是否已经消失。
       
                </div>
            </div>
            <!--/right-box-->
        </div>
    </div>
    <!--/service-box-->
</asp:Content>
