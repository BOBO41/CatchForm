﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgDefault.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.OrgDefault" %>

<%@ Register Src="/UserControl/OrgTree.ascx" TagName="OrgTree" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <title>企业测评诊断与提升服务系统</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.ui.all.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.layout.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('body').layout();
        });
    </script>
</head>
<body class="pd">
    <div class="ui-layout-center" style="overflow: hidden;">
        <iframe id="ifrOrg" name="ifrOrg" width="100%" height="100%" frameborder="0" scrolling="auto" src="<%= Request.QueryString["menu"] %>"></iframe>
    </div>
    <div class="ui-layout-west">
        <uc1:OrgTree ID="OrgTree1" runat="server" />
    </div>
</body>
</html>
