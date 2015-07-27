<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="ECommerce.Web.Manage.CM.AddArticle" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设置</title>

    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/kindeditor-min.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/lang/zh_CN.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <style type="text/css">
        .amimg {
            background-color: #eee;
            background-image: url(/themes/default/images/photo-default.png);
            height: 100px;
            width: 100px;
            border-top-style: none;
            border-right-style: none;
            border-bottom-style: none;
            border-left-style: none;
            display: block;
            font-size: 12px;
            overflow: hidden;
        }

        .am {
            background-color: #eee;
            height: 100px;
            overflow: auto;
        }

            .am ul {
                padding: 15px;
                margin: 0px;
                list-style: none;
                font-size: 12px;
            }

                .am ul li {
                    border-bottom-width: 1px;
                    border-bottom-style: solid;
                    border-bottom-color: #D6D6D6;
                }

                    .am ul li span {
                        float: right;
                    }
    </style>
    <script language="javascript" type="text/javascript">
        function OnCompleted(fileName) {
            document.getElementById("att").innerHTML = document.getElementById("att").innerHTML +
			"<li><span><a  href=\"javascript:void(0);\" onclick=\"delTrPro(this,'" + fileName + "');return false;\">删除</a></span>" + fileName + "</li>";
            var name = $("#atts").val() + fileName + ",";
            $("#atts").val(name);
        }

        function delTr(obj, attId, attName) {
            if (!confirm("确实要删除吗?")) {
                return false;
            }
            $.ajax({
                type: 'POST', url: '/Manage/CM/Ajax/AddArticle.aspx?AId=' +<%= AId%> + '&AttId=' + attId, success: function (data) {
                    if (data.substring(0, 1) == "1") {
                        document.getElementById("att").innerHTML = data.substring(1, data.length);
                        var attNa = "";
                        var atts = "";
                        attNa = $("#atts").val();
                        if (attNa != "") {
                            var att = attNa.split(',');
                            for (var i = 0; i < att.length - 1; i++) {
                                if (att[i] != attName) {
                                    atts += att[i] + ",";
                                }
                            }
                            $("#atts").val(atts);
                        }
                    } else {
                        alert(data);
                    }
                }
            });

        }
        function delTrPro(obj, attName) {
            if (!confirm("确实要删除吗?")) {
                return false;
            }
            var attNa = "";
            var atts = "";
            var delatts = "";
            attNa = $("#atts").val();
            if (attNa != "") {
                var att = attNa.split(',');
                for (var i = 0; i < att.length - 1; i++) {
                    if (att[i] != attName) {
                        atts += att[i] + ",";
                    } else {
                        delatts += att[i] + ",";
                    }
                }
                if (atts != "") {
                    $("#atts").val(atts);
                }
            }
            $.ajax({
                type: 'POST', url: '/Manage/CM/Ajax/AddArticle.aspx?AttIds=' + delatts, success: function (data) {

                    $(obj).parent().parent().remove();
                }
            });
        }

        function delTrAId(obj, areaId) {
            if (!confirm("确实要删除吗?")) {
                return false;
            }
            $.ajax({
                type: 'POST', url: '/Manage/CM/Ajax/CMOrgAreaAjax.aspx?AIDDel=<%= AId %>&ArId=' + areaId, success: function (data) {
                    if (data.substring(0, 1) == "1") {
                        $(obj).parent().parent().remove();
                    } else {
                        alert(data);
                    }
                }
            });

        }
        function delTrAIds(obj, areaId) {
            if (!confirm("确实要删除吗?")) {
                return false;
            }
            $.ajax({
                type: 'POST', url: '/Manage/CM/Ajax/CMOrgAreaAjax.aspx?AreaIds=' + areaId, success: function (data) {
                    if (data.substring(0, 1) == "1") {
                        $(obj).parent().parent().remove();
                    } else {
                        alert(data);
                    }
                }
            });

        }
        function addData(aid) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: 'AddCmOrgArea.aspx?AID=' + aid, title: '设置有效区域' });
            window.top.$modal.show();
        }

        function addProData(aid) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: 'AddCmPro.aspx?AID=' + aid, title: '设置关联商品' });
            window.top.$modal.show();
        }

        function delProAId(obj, aid, pids) {
            if (!confirm("确实要删除吗?")) {
                return false;
            }
            $.ajax({
                type: 'POST', url: '/Manage/CM/Ajax/CMProAjax.aspx?AIDDel=' + aid + '&Pids=' + pids, success: function (data) {
                    if (data.substring(0, 1) == "1") {
                        $(obj).parent().parent().remove();
                    } else {
                        alert(data);
                    }
                }
            });

        }
        function delProAIds(obj, aid, pids) {
            if (!confirm("确实要删除吗?")) {
                return false;
            }
            $.ajax({
                type: 'POST', url: '/Manage/CM/Ajax/CMProAjax.aspx?pids=' + pids, success: function (data) {
                    if (data.substring(0, 1) == "1") {
                        $(obj).parent().parent().remove();
                    } else {
                        alert(data);
                    }
                }
            });

        }
    </script>
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="pannel">
            <div class="pannel-header">
                <strong>
                    <asp:Literal ID="lblTitle" runat="server" Text="新增内容"></asp:Literal></strong>
            </div>

            <div class="pannel-body">
                <asp:HiddenField ID="hidAId" runat="server" />

                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="table-form">
                    <tr>
                        <td class="tf-label"><span style="color: red">*</span>标题：
                        </td>
                        <td class="tf-con">
                            <input type="text" runat="server" id="txtTitle" class="input-block-level" placeholder="请输入标题" />
                        </td>
                        <td class="tf-label">
                            <div style="text-align: right; width: 100px;"><span style="color: red">*</span>栏目：</div>
                        </td>
                        <td class="tf-con">
                            <asp:DropDownList ID="ddlColumn" runat="server" class="input-block-level">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>

                        <td class="tf-label">
                            <span style="color: red">*</span>类型：</td>
                        <td class="tf-con">
                            <asp:DropDownList ID="ddlType" runat="server" class="input-block-level">
                            </asp:DropDownList></td>
                        <td class="tf-label">是否置顶：</td>
                        <td class="tf-con" style="font-size: 12px;">
                            <asp:RadioButton runat="server" ID="rboIsTopTrue" GroupName="rboIsTop" />
                            是
                               
                            <asp:RadioButton runat="server" ID="rboIsTopFalse" Checked="true" GroupName="rboIsTop" />
                            否
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label">幻灯图片：</td>
                        <td valign="top" class="tf-con">
                            <asp:FileUpload ID="fuPFlash" runat="server" /></td>
                        <td valign="top" class="tf-label">附件：</td>
                        <td valign="top" class="tf-con">
                            <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0"
                                width="400" height="30" id="SWFFileUpload" align="middle">
                                <param name="allowScriptAccess" value="sameDomain" />
                                <param name="movie" value="SWFFileUpload.swf" />
                                <param name="wmode" value="transparent" />
                                <param name="quality" value="high" />
                                <param name="FlashVars" value="CompletedFunction=OnCompleted" />
                                <embed width="400" height="30" src="SWFFileUpload.swf" name="fileUpload1" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="transparent" />
                            </object>

                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align: right">&nbsp;</td>
                        <td valign="top" class="tf-con">
                            <!--<img class="amimg" name="" src=""   alt="缩略图">-->
                            <div class="amimg">
                                <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" />
                            </div>
                        </td>
                        <td valign="top" style="text-align: right">&nbsp;</td>
                        <td valign="top" class="tf-con">
                            <div class="am">
                                <ul id="att" runat="server">
                                    <!-- <li><span><a href="#">删除</a></span>附件一</li>
                            <li><span><a href="#">删除</a></span>附件二</li>
                            <li><span><a href="#">删除</a></span>附件三</li>
                            <li><span><a href="#">删除</a></span>附件四</li>
                            <li><span><a href="#">删除</a></span>附件二</li>
                            <li><span><a href="#">删除</a></span>附件三</li>
                            <li><span><a href="#">删除</a></span>附件四</li>-->
                                </ul>
                                <input type="hidden" id="atts" runat="server" />
                            </div>
                            <asp:Literal ID="litAtt" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label">作者：</td>
                        <td valign="top" class="tf-con">
                            <input type="text" id="txtAuthor" runat="server" placeholder="请输入作者" class="input-block-level" /></td>
                        <td valign="top" class="tf-label">来源：</td>
                        <td valign="top" class="tf-con">
                            <input type="text" id="txtFrom" runat="server" placeholder="请输入来源" class="input-block-level" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td valign="top" class="tf-label">所属区域：</td>
                        <td valign="top" class="tf-con">
                            <a class="btn btn-mini" onclick="addData('<%=AId %>');" href="javascript:void(0);" data-title="设置有效区域">设置有效区域</a>
                        </td>
                        <td valign="top" class="tf-label">关联商品：</td>
                        <td valign="top" class="tf-con">
                            <a class="btn btn-mini" onclick="addProData('<%=AId %>');" href="javascript:void(0);" data-title="设置关联商品">设置关联商品</a>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td valign="top" class="tf-label">&nbsp;</td>
                        <td style="text-align: left; vertical-align: top" class="tf-con">
                            <div id="divArea" name="divArea" runat="server" class="pd" style="padding-left: 0px">
                                <table class="table table-bordered" style="width: 100%; font-size: 12px;" border="0" cellspacing="0" id="divAreaSelect">
                                    <tr>
                                        <th>区域名称</th>
                                        <th>操作</th>
                                    </tr>
                                    <%= GetArea() %>
                                </table>
                            </div>
                        </td>
                        <td valign="top" class="tf-label">&nbsp;</td>
                        <td style="text-align: left; vertical-align: top" class="tf-con">
                            <div id="div1" name="divArea" runat="server" class="pd" style="padding-left: 0px">
                                <table class="table table-bordered" style="width: 80%; font-size: 12px;" border="0" cellspacing="0" id="divProSelect">
                                    <tr>
                                        <th>商品名称</th>
                                        <th>生产厂商</th>
                                        <th>操作</th>
                                    </tr>
                                    <%= GetPro() %>
                                </table>
                            </div>
                        </td>
                    </tr>--%> 
                     <tr>
                        <td valign="top" class="tf-label">显示时长:</td>
                        <td colspan="3" valign="top" class="tf-con">
                           <input type="text" id="txtDisplayTime" runat="server" style="width:300px" value="0" class="input-block-level" /><span style="color: red">(单位：小时）</span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label"><span style="color: red">*</span>导读：</td>
                        <td colspan="3" valign="top" class="tf-con">
                            <textarea id="tarDescription" rows="5" class="input-block-level" runat="server" maxlength="240"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label" style="vertical-align: top"><span style="color: red">*</span>详细内容：</td>
                        <td colspan="3" valign="top" class="tf-con">
                            <textarea id="tarContent" style="width: 100%; height: 500px" maxlength="500" runat="server" class="input-block-level"></textarea>
                        </td>
                    </tr>

                </table>


            </div>
            <div class="text-center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClientClick="return checkText();" OnClick="btnSave_Click" Text="保存" />
                <asp:Button ID="btnCancel" runat="server" class="btn" OnClick="btnCancel_Click" Text="返回" />
            </div>

            <script type="text/javascript">
                var editor;
                KindEditor.ready(function (K) {

                    editor = K.create('textarea[name="tarContent"]', {
                        uploadJson: '/themes/js/kindeditor-4.1.6/asp.net/upload_json.ashx',
                        fileManagerJson: '/themes/js/kindeditor-4.1.6/asp.net/file_manager_json.ashx',
                        allowFileManager: true
                    });
                });
                function checkText() {
                    //标题
                    var title = $("#<%=txtTitle.ClientID%>").val();
                    //栏目
                    var column = $("#<%=ddlColumn.ClientID%>").val();
                    //类型
                    var type = $("#<%=ddlType.ClientID%>").val();
                    //导读
                    var description = $("#<%=tarDescription.ClientID%>").val();

                    if (editor.html() == "") {
                        alert("请输入详细内容");
                        $("#<%=tarContent.ClientID%>").focus();
                        return false;
                    }

                    if (title == "" || title == null) {
                        alert('请输入标题！');
                        $("#<%=txtTitle.ClientID%>").focus();
                        return false;
                    }
                    if (column == "" || column == null || column == "0") {
                        alert('请选择栏目！');
                        $("#<% =ddlColumn.ClientID%>").focus();
                        return false;
                    }
                    if (type == "" || type == null || type == "0") {
                        alert('请选择类型！');
                        $("#<% =ddlType.ClientID%>").focus();
                        return false;
                    }
                    if (description == "" || description == null) {
                        alert('请输入导读！');
                        $("#<% =tarDescription.ClientID%>").focus();
                        return false;
                    }
                    if (editor.html() == "") {
                        alert("请输入详细内容");
                        $("#<%=tarContent.ClientID%>").focus();
                        return false;
                    }
                }

            </script>
        </div>
    </form>
</body>
</html>
