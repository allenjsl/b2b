<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkCheckInfo.aspx.cs"
    Inherits="Web.ManageCenter.WorkCheckInfo" %>
<%@ Import Namespace="EyouSoft.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/sytle.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <style type="text/css">
        .ulStyle
        {
            width: 532px;
            height: 457px;
            padding: 0px;
            border-top: solid 1px #85C1DD;
            border-left: solid 1px #85C1DD;
        }
        .ulStyle li
        {
            width: 75px;
            height: 70px;
            float: left;
            border-right: solid 1px #85C1DD;
            border-bottom: solid 1px #85C1DD;
            list-style: none;
            text-align: center;
        }
        .ulStyle .header
        {
            background-color: #b7e0f3;
            height: 30px;
            line-height: 30px;
        }
    </style>
</head>
<body style="background: 0 none;">
    <div class="alertbox-outbox02">
        <table width="100%" align="center" cellpadding="0" cellspacing="0" bgcolor="#e9f4f9"
            style="margin: 0 auto">
            <tr>
                <td align="center" width="18%"><a data-class="Month" data-value="-1" href="javascript:void(0);" data-curdate='<%=this.dt %>'><strong><%=Utils.ConvertMonthToChinese(this.dt.AddMonths(-1)) %></strong></a></td>
                <td height="38" align="center" class="alertboxTableT">
                    <span style="font-size: 18px; font-weight: bold; color: #000;"><%=this.dt.Year%>年<%=this.dt.Month %>月</span>
                </td>
                <td align="center" width="18%"><a data-class="Month" data-value="1" href="javascript:void(0);" data-curdate='<%=this.dt %>'><strong><%=Utils.ConvertMonthToChinese(this.dt.AddMonths(1)) %></strong></a></td>
            </tr>
            <tr>
                <td height="28" class="alertboxTableT" align="center" colspan="3">
                    <ul class="ulStyle">
                        <li class="header">一</li>
                        <li class="header">二</li>
                        <li class="header">三</li>
                        <li class="header">四</li>
                        <li class="header">五</li>
                        <li class="header">六</li>
                        <li class="header">日</li>
                        <%=this.getNullDay()%>
                        <%=this.getTables()%>
                        <%=this.nullDayEndStr.ToString()%>
                    </ul>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center">
                    &nbsp;<strong>本年：</strong>
                    <asp:Label runat="server" ID="lblYear"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<strong>本月：</strong>
                    <asp:Label runat="server" ID="lbAttInfo"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="alertbox-btn" style="text-align: right;">
            <a href="javascript:window.print()" hidefocus="true"><s class="dayin"></s>打 印</a><a
                href="javascript:void(0)" onclick="PageJsDataObj.CloseForm()" hidefocus="true">关
                闭</a>
        </div>
    </div>

    <script src="/Js/table-toolbar.js" type="text/javascript"></script>

    <script src="/Js/jquery.boxy.js" type="text/javascript"></script>

    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/Js/bt.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        var PageJsDataObj = {
        	//ajax执行文件路径,默认为本页面
            ajaxurl: "/ManageCenter/WorkCheckInfo.aspx?",
        	DataBoxy: function() { /*弹窗默认参数*/
        		return {
        			url: '/ManageCenter/Attendance',
        			title: "",
        			width: "520px",
        			height: "420px"
        		};
        	},
        	ShowBoxy: function(data) { /*显示弹窗*/
        		var win = top || window;
        		win.Boxy.iframeDialog({
        				iframeUrl: data.url,
        				title: data.title,
        				modal: true,
        				width: data.width,
        				height: data.height
        			});
        	},
            SearchFun: function(key,date) {
            	var data = { iframeId: '<%=Request.QueryString["iframeId"]%>', m: key, curdate: date,id: '<%=Utils.GetQueryStringValue("id") %>' };
            	window.location.href = PageJsDataObj.ajaxurl + $.param(data);
            },
            //泡泡提示
        	Bt: function(obj) {
        		$(obj).bt({
        				contentSelector: function() {
        					return $(obj).next("div").html();
        				},
        				positions: ['left', 'right', 'bottom'],
        				fill: '#FFF2B5',
        				strokeStyle: '#D59228',
        				noShadowOpts: { strokeStyle: "#D59228" },
        				spikeLength: 5,
        				spikeGirth: 15,
        				width: 475,
        				overlap: 0,
        				centerPointY: 4,
        				cornerRadius: 4,
        				shadow: true,
        				shadowColor: 'rgba(0,0,0,.5)',
        				cssStyles: { color: '#00387E', 'line-height': '200%' }
        			});
        	},
        	AttendDetail: function(obj) {
        		var data = this.DataBoxy();
        		data.url = $(obj).attr("href") + "&";
        		data.url += $.param({
        				pIframeId: '<%=Request.QueryString["iframeId"] %>'
        			});
        		data.title = "考勤登记";
        		this.ShowBoxy(data);
        	},
        	CloseForm: function() {
        		parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
        		parent.window.document.getElementById("btnSubmit").click();
        		return false;
        	}
        };

        $(function() {
        	$(".attendBt").each(function() {
        		PageJsDataObj.Bt(this);
        	});
        	$("a[data-class='attDetail']").click(function() {
        		PageJsDataObj.AttendDetail(this);
        		return false;
        	});
            $("a[data-class='Month']").click(function() {
        		PageJsDataObj.SearchFun($(this).attr("data-value"),$(this).attr("data-curdate"));
        		return false;
        	});
        });
    </script>

</body>
</html>
