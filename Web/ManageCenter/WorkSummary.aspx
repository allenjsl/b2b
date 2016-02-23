<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkSummary.aspx.cs" Inherits="Web.ManageCenter.WorkSummary" MasterPageFile="~/MasterPage/Print.Master" Title="考勤汇总_考勤管理_行政中心" %>
<%@ Import Namespace="EyouSoft.Common" %>
<%@ MasterType VirtualPath="~/MasterPage/print.Master" %>
<%@ Register Src="~/UserControl/SelectSection.ascx" TagName="SelectSection" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
<form id="frm" name="frm" method="POST" action="WorkSummary.aspx">
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="35" align="center">
                <h2>
                    <strong>考勤汇总表</strong></h2>
            </td>
        </tr>
    </table>
    <div id="divSearch" align="center">
    <table width="800" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="35" align="center">
                年份：
                    <select name="selYear" id="selYear" class="inputselect">
                    </select>
                    月份：
                    <select name="selMonth" id="selMonth" class="inputselect">
                    </select>
                部门：
                <uc1:SelectSection ID="SelectSection1" runat="server" SetTitle="部门选用" SModel="2"/>
                员工编号：
                <input name="txtNum" type="text" class="searchinput2" size="15" id="txtNum" value='<%=Request.QueryString["txtNum"]%>'style="width: 80px"/>
                姓名：
                <input name="txtName" type="text" class="searchinput2" size="15" id="txtName" value='<%=Request.QueryString["txtName"] %>' style="width: 80px"/>
                <input style="width: 64px; height: 24px; background: url(/images/cx.gif) no-repeat center center;
                        border: 0 none; margin-left: 5px;" value="查询" id="btnSubmit" type="submit" <%--onclick="AttStatistic.OnSearch();"--%>/>
            </td>
        </tr>
    </table>

    <table width="800" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000"
        style="border-collapse: collapse; margin: 5px auto; line-height: 16px;">
        <tr>
            <td width="53" align="center">
                部门
            </td>
            <td width="50" align="center">
                编号
            </td>
            <td width="53" align="center">
                姓名
            </td>
            <%=this.getMonthDays()%>
        </tr>
        <asp:Repeater ID="RepList" runat="server">
                <ItemTemplate>
        <tr>
            <td align="center" valign="top">
                <%#this.GetDeptNameByList(((System.Collections.Generic.List<EyouSoft.Model.CompanyStructure.Department>)Eval("DepartmentList")))%>
            </td>
            <td align="center" valign="top">
                <%#Eval("ArchiveNo")%>
            </td>
            <td align="center" valign="top">
                <%#Eval("UserName")%>
            </td>
            <%#this.getTables(Eval("AttendanceList"))%>
        </tr>
         </ItemTemplate>
            </asp:Repeater>
    </table>
    </div>
    <link rel="stylesheet" type="text/css" href="/css/boxy.css" />
    <link rel="stylesheet" type="text/css" href="/css/sytle.css" />
    <script type="text/javascript" src="/js/jquery.boxy.js"></script>
    <script type="text/javascript" src="/js/bt.min.js"></script>
    
    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/unitpngfix.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/js/moveScroll.js"></script>
    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>
    <script type="text/javascript" src="/js/newjquery.autocomplete.js"></script>
    <script type="text/javascript">
        var Parms = { selYear: "", selMonth: "", DeptId: "", DeptNm: "", txtNum: "", txtName: "" };
        var AttStatistic = {
        	initYear: function() {
        		var date = new Date();
        		var year = date.getFullYear();
        		for (var i = 0; i < 10; i++) {
        			var opt = new Option(year - i, year - i);
        			document.getElementById("selYear").options.add(opt);
        		}
        	},
        	initMonth: function() {
        		for (var i = 1; i < 13; i++) {
        			var opt = new Option(i, i);
        			document.getElementById("selMonth").options.add(opt);
        		}
        	},
        	setSelectValue: function(ObjName, v) {
        		var obj = document.all[ObjName];
        		for (var i = 0; i < obj.length; i++) {
        			if (obj.options.value == v) { obj.value = v; }
        		}
        	},
            OnSearch: function() { //查询
                Parms.selYear = $("#selYear").val();
                Parms.selMonth = $.trim($("#selMonth").val());
                Parms.DeptId = $("#<%=SelectSection1.SelectIDClient%>").val();
            	Parms.DeptNm = $("#<%=SelectSection1.SelectNameClient %>").val();
                Parms.txtNum = $.trim($("#txtNum").val());
                Parms.txtName = $.trim($("#txtName").val());
//            	window.location.href = "/ManageCenter/WorkSummary.aspx?" + $.param(data);
                AttStatistic.GetCollectAllList();
            },
            GetCollectAllList: function() {//得到ajax数据
            	$.newAjax({
            			type: "GET",
            			dateType: "html",
            			url: "/ManageCenter/WorkSummary.aspx",
            			data: Parms,
            			cache: false,
            			success: function(html) {
            				$("#divContent").html(html);
             			},
            			error: function() {
            				tableToolbar._showMsg(tableToolbar.errorMsg);
            			}
            		});
            	return false;
            }        	
        };
        $(function() {
        	AttStatistic.initYear();
        	AttStatistic.initMonth();
        	var date = new Date();
        	$("#selYear").val(Boxy.queryString("selYear") || date.getFullYear());
        	$("#selMonth").val(Boxy.queryString("selMonth") || date.getMonth() + 1);
        	var form = $("#frm");
        	form.submit(function() {
        		$.post(form, Attr("action"), form.serialize(), function(result, status) {
        			debugger;
        			alert(status);alert(result.success);
        		}, "json");
        		return false;
        	});
//            AttStatistic.OnSearch();
        });
    </script>
    </form>
</asp:Content>