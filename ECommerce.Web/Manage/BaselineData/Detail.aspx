<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ECommerce.Web.Manage.BaselineData.Detail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <style>
        .table-form .tf-label	{
             width: 500px;
         }
    </style>
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="pannel">
            <div class="pannel-body">
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="table-form">
                    <tr>
                        <td class="tf-label">企业编号：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>企业财务</strong></td></tr>
                    <tr>
                        <td class="tf-label">财务年度：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">本地营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">出口营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">总营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">上一年度本地营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">上一年度出口营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">上一年度总营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">销售成本 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal9" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">营业利润 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">税前利润 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal11" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">上一年度税前利润 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal12" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">员工成本 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal13" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">上一年度员工成本 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal14" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">应收账款 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal15" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">库存 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal16" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">银行存款和库存现金 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal17" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">其他流动资产 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal18" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">应付账款 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal19" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">其他流动负债 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal20" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">短期贷款 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal21" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">长期贷款 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal22" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">其他长期负债 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal23" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">股东资金 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal24" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">购入材料及服务的成本 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal25" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">投入资本 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal26" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>企业客户</strong></td></tr>
                    <tr>
                        <td class="tf-label">客户数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal27" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">新客户数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal28" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">市场营销支出 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal29" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">收到订单数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal30" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">有记录的客户投诉数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal31" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">未按约定时间交货的订单数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal32" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>企业流程</strong></td></tr>
                    <tr>
                        <td class="tf-label">信息通讯技术总支出 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal33" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">全部订单的交付时间总和 (天)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal34" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">交货时未达标的产品总值 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal35" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">按时交货的产品总值 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal36" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">意外事故或事件数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal37" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">年度能源成本 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal38" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">年度水费 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal39" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">废物处理费用 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal40" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">供货数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal41" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">次品数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal42" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">在保质期内被客户退货的订单数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal43" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">废品率 (%)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal44" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">装配准备时间 (分钟)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal45" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">生产计划执行比例 (%)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal46" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>企业学习与成长</strong></td></tr>
                    <tr>
                        <td class="tf-label">全时员工人数：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal47" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">缺勤天数 (天/年)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal48" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">全时员工离职人数：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal49" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">培训开支 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal50" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">研发开支 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal51" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">现有的产品/服务数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal52" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">新产品/服务数量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal53" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">新产品/服务产生的营业额 (CNY K)：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal54" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>企业的业务计划和执行能力</strong></td></tr>
                    <tr>
                        <td class="tf-label">长期目标：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal55" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">市场开发：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal56" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">财务计划：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal57" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">员工总数的发展与增长：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal58" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">业务技能和经验：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal59" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">企业外部环境认知：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal60" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>业务发展</strong></td></tr>
                    <tr>
                        <td class="tf-label">在我们客户的眼中，我们的产品/服务与其他同类企业相比是怎样的？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal61" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们对我们的客户了解多少？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal62" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们如何了解客户的真实需求，以及我们如何确保满足客户的需求？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal63" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">如果客户不满意我们该怎么做？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal64" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们怎样得知我们的客户有多满意？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal65" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们认为我们的客户有多满意？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal66" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">遵守我们的承诺：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal67" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们的客户能与我们合作多长时间？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal68" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">业务水平：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal69" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">在制定企业发展计划的过程中员工的参与度有多少？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal70" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">在改进工作方法方面员工的参与度有多少？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal71" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">出现错误时我们怎么做？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal72" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">好的工作表现将怎样被识别？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal73" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">职业培训：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal74" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">员工满意度：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal75" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">招聘与入职培训：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal76" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">雇佣合同，条件与福利：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal77" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">员工的自由裁量权：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal78" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>做工作</strong></td></tr>
                    <tr>
                        <td class="tf-label">保持稳定的质量：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal79" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">提高业务：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal80" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我(和/或员工)的反应速度有多快？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal81" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们如何衡量绩效表现？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal82" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">所需时间：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal83" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们怎样控制工作流程？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal84" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们可以按时完成工作吗？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal85" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">设备和机器的可靠性：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal86" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们怎样选择我们的供应商？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal87" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们的供应商有多可靠？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal88" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们怎样处理健康与安全问题？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal89" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们企业业务的可持续性如何？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal90" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们对环境和社会有什么影响？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal91" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">企业是否采纳外部专家的意见？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal92" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">向其他企业学习：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal93" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">管理“关键时刻”：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal94" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">生产率：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal95" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">营业成本：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal96" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">设备摆放：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal97" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">拉动排程：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal98" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">批量大小：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal99" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们怎样寻找新客户？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal100" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们怎样开发新市场？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal101" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td><td><strong>开发产品与服务</strong></td></tr>
                    <tr>
                        <td class="tf-label">改进产品与服务：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal102" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">计划产品/服务的改变：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal103" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">完全新的想法：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal104" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">计算机的使用：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal105" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们对企业融资的流程了解多少？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal106" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们管理企业资金流动的能力有多强？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal107" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tf-label">我们多久做一次现金流量预测？：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="Literal108" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="text-center">
                <input type="button" class="btn" style="margin-bottom: 10px;" name="Previous" id="Previous" value="返回" onclick="javascript: history.back();">
            </div>
        </div>
    </form>
</body>
</html>
