<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCmOrgArea.aspx.cs" Inherits="ECommerce.Web.Manage.CM.AddCmOrgArea" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>设置</title>
</head>

<script type="text/javascript">
    function goArea(areaId) {
        $.ajax({
            type: 'POST', url: '/Manage/CM/Ajax/CMOrgAreaAjax.aspx?AreaId=' + areaId, success: function (data) {
                //if (data.substring(0, 1) == "4") {
                //    window.document.getElementById('divArea4').innerHTML = data.substring(1, data.length);
                //} else
                if (data.substring(0, 1) == "3") {
                    window.document.getElementById('divArea3').innerHTML = data.substring(1, data.length);
                } else if (data.substring(0, 1) == "2") {
                    window.document.getElementById('divArea2').innerHTML = data.substring(1, data.length);
                }
            }
        });
    }
</script>
<body class="pd">
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="modal-body">
            <asp:HiddenField ID="hidAID" runat="server" />
            <div class="qybox">
                <div class="c1">
                    <div class="tnav">省份</div>
                    <div class="qybox-body">
                        <ul class="list">
                            <% System.Data.DataSet dt = GetArea();
                               if (dt != null)
                               {
                                   if (dt.Tables[0].Rows.Count > 0)
                                   {
                                       for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                                       {
                            %>
                            <li onclick="goArea(<%=dt.Tables[0].Rows[i]["AreaId"] %>)"><a href="javascript:void(0);">
                                <input type="checkbox" name="cbo<%=dt.Tables[0].Rows[i]["AreaId"] %>" id="cbo<%=dt.Tables[0].Rows[i]["AreaId"] %>" value="<%=dt.Tables[0].Rows[i]["AreaId"] %>"><%=dt.Tables[0].Rows[i]["AreaName"] %></a></li>
                            <%  
                                       }
                                   }
                               } %>
                        </ul>
                    </div>
                </div>
                <div class="c2">
                    <div id="divArea2">
                    </div>
                </div>
                <div class="c3">
                    <div id="divArea3">
                    </div>
                </div>

                <%--  <div class="c3">
                    <div id="divArea4">
                    </div>
                </div>--%>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="保存" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
