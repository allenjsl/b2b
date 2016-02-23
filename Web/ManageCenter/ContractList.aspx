<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ContractList.aspx.cs" Inherits="Web.ManageCenter.ContractList" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %><%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">行政中心</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;劳动合同管理
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <form>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="../images/yuanleft.gif">
                    </td>
                    <td height="50">
                        <div class="searchbox">
                            员工编号：<input type="text" size="8" id="txtStaffNo" class="inputtext formsize80" name="txtStaffNo" value="<%=Request.QueryString["txtStaffNo"] %>"/>
                            姓名：<input type="text" size="10" id="txtStaffName" class="inputtext formsize80" name="txtStaffName"value="<%=Request.QueryString["txtStaffName"] %>"/>
                            签订时间：<input type="text" size="9" id="txtBeginDateF" class="inputtext formsize100" name="txtBeginDateF"value="<%=Request.QueryString["txtBeginDateF"] %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtBeginDateF\')}'})"/>-<input
                                type="text" size="9" id="txtBeginDateE" class="inputtext formsize100" name="txtBeginDateE"value="<%=Request.QueryString["txtBeginDateE"] %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtBeginDateE\')}'})" />
                            到期时间：<input type="text" size="9" id="txtEndDateF" class="inputtext formsize100" name="txtEndDateF"value="<%=Request.QueryString["txtEndDateF"] %>"onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtEndDateF\')}'})"/>-<input
                                type="text" size="9" id="txtEndDateE" class="inputtext formsize100" name="txtEndDateE"value="<%=Request.QueryString["txtEndDateE"] %>"onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtEndDateE\')}'})"/>
                            <button type="submit" id="btnSubmit" class="search-btn" style="vertical-align: top;"></button>
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="../images/yuanright.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a id="link1" href="#" style='visibility:<%=IsAddGrant?"visible":"hidden" %>'>新增</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" style="word-wrap:break-word; overflow:hidden;word-break: break-all;table-layout:fixed;">
                <tbody>
                    <tr>
                        <th width="36" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th width="7%" bgcolor="#bddcf4" align="center">
                            <strong>员工编号</strong>
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            <strong>姓名</strong>
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            <strong>签订时间</strong>
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            <strong>到期时间</strong>
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            <strong>状态</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>备注</strong>
                        </th>
                        <th width="10%" bgcolor="#bddcf4" align="center">
                            <strong>操作</strong>
                        </th>
                    </tr>
                    <asp:Repeater ID="RepList" runat="server">
                    <ItemTemplate>
                    <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                        <td align="center">
                            <%#Container.ItemIndex+1+(this.pageIndex-1)*this.pageSize %>
                        </td>
                        <td align="center">
                            <%#Eval("StaffNo")%>
                        </td>
                        <td align="center">
                             <%#Eval("StaffName")%>
                        </td>
                        <td align="center">
                             <%#Eval("BeginDate")%>
                        </td>
                        <td align="center">
                             <%#Eval("EndDate")%>
                        </td>
                        <td align="center">
                             <%#Eval("ContractStatus")%>
                        </td>
                        <td align="center">
                             <%#Eval("Remark")%>
                        </td>
                        <td align="center">
                            <a data-class="a_Upd" data-id="<%#Eval("Id") %>">修改</a>|<a href="#" data-class="a_Del" data-id="<%#Eval("Id") %>">删除</a>
                        </td>
                    </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </tbody>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right">
                             <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <script type="text/javascript">
    var ContractList = {
    	DataBoxy: function() {
    		return {
    			url: "/ManageCenter",
    			title: "",
    			width: "600px",
    			height: "350px"
    		};
    	},
    	ShowBoxy: function(data) { /*显示弹窗*/
    		Boxy.iframeDialog({
    				iframeUrl: data.url,
    				title: data.title,
    				modal: true,
    				width: data.width,
    				height: data.height
    			});
    	},
    	GoAjax: function(url) {
    		$.newAjax({
    				type: "post",
    				cache: false,
    				url: url,
    				dataType: "json",
    				success: function(result) {
    					if (result.result == "1") {
    						tableToolbar._showMsg(result.msg, function() {
    							$("#btnSubmit").click();
    						});

    					}
    					else { tableToolbar._showMsg(result.msg); }
    				},
    				error: function() {
    					tableToolbar._showMsg(tableToolbar.errorMsg);
    				}
    			});
    	},
    	Add: function() {
    		var data = this.DataBoxy();
    		data.url += '/ContractAdd.aspx?';
    		data.title = '添加劳动合同';
    		data.url += $.param({
    				doType: "add"
    			});
    		this.ShowBoxy(data);
    	},
    	Update: function(o) {
    		var data = this.DataBoxy();
    		data.url += '/ContractAdd.aspx?';
    		data.title = '修改劳动合同';
    		data.url += $.param({
    				doType: "update",
    				id: $(o).attr("data-id")
    			});
    		this.ShowBoxy(data);
    	},
    	Delete: function(o) {
    		var data = this.DataBoxy();
    		data.url += "/ContractList.aspx?";
    		data.url += $.param({
    				doType: "delete",
    				id: $(o).attr("data-id")
    			});
    		this.GoAjax(data.url);
    	},
    	BindBtn: function() {
    		$("#link1").click(function() {
    			ContractList.Add();
    			return false;
    		});
    		$("a[data-class='a_Upd']").click(function() {
    			ContractList.Update(this);
    			return false;
    		});
    		$("a[data-class='a_Del']").click(function() {
    			ContractList.Delete(this);
    			return false;
    		});
    	},
    	PageInit: function() {
    		//绑定功能按钮
    		this.BindBtn();
    		//当列表页面出现横向滚动条时使用以下方法 $("需要滚动最外层选择器").moveScroll();
    		//$('.tablelist-box').moveScroll();
    	}    };
    
    $(document).ready(function(){
    	ContractList.PageInit();
    });
    </script>
</asp:Content>
