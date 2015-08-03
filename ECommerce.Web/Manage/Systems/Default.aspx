<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="utf-8">
    <title>企业测评诊断与提升服务系统</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.ui.all.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.layout.min.js"></script>
    <link href="/Scripts/jquery-ui-1.8.7.custom.css" rel="stylesheet" />
    <script src="/Scripts/jquery-ui-1.8.7.custom.min.js"></script>
    <script type="text/javascript">
        $('body').on('hidden', '.modal', function () {
            $(this).removeData('modal');
        });
        var $modal;
        var $op;
        var $tmp;
        var $ajaxget;
        $(document).ready(function () {
            $('body').layout({ resizable: false });
        });
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
    </script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <!--[if lt IE 9]>
        <script src="/js/html5shiv.min.js"></script>
        <script src="/js/respond.min.js"></script>
    <![endif]-->
</head>

<body>
    <form runat="server" id="form86">
        <div class="ui-layout-center" style="overflow: hidden;">
            <iframe id="mainFrame" name="mainFrame" width="100%" height="100%" frameborder="0" scrolling="auto" src="Welcome.aspx"></iframe>
        </div>
        <div class="ui-layout-north" style="overflow: visible;">
            <div class="top clearfix">
                <div class="pull-left">
                    <div class="logo" onclick="window.location='/Manage/Systems/Default.aspx'" style="cursor: pointer">
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="pull-right">
                    <div class="top-info">
                        <i class="icon-user icon-white"></i>
                        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
                        登陆成功！<br>
                        <a href="javascript:void(0);" onclick="openModal('/Manage/Systems/ChangePass.aspx','修改密码')"><i class="icon-lock icon-white"></i>修改密码</a>
                        <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click"><i class=" icon-remove-circle icon-white"></i>退出系统</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="bar">
                <div class="pull-left"><i class="icon-user"></i>当前用户角色 <strong style="color: #C30;">系统管理员</strong></div>
                <div class="pull-right"><i class="icon-time"></i>年月日 时分秒</div>
            </div>
        </div>
        <div class="ui-layout-west">
            <h3 class="titbar mb">系统菜单</h3>
            <div class="dl-menu">
                <asp:Literal ID="litRoleTree" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>

