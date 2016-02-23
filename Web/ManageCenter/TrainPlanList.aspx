<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="TrainPlanList.aspx.cs" Inherits="Web.ManageCenter.TrainPlanList" %>
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
                            <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;培训计划
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="height: 30px;" class="lineCategorybox">
        </div>
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
            <table width="100%" cellspacing="1" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <th width="36" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>计划标题</strong>
                        </th>
                        <th width="15%" bgcolor="#bddcf4" align="center">
                            <strong>发布时间</strong>
                        </th>
                        <th width="13%" bgcolor="#bddcf4" align="center">
                            <strong>发布人</strong>
                        </th>
                        <th width="15%" bgcolor="#bddcf4" align="center">
                            <strong>发送对象</strong>
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            <strong>操作</strong>
                        </th>
                    </tr>
                    <asp:Repeater ID="RepList" runat="server">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td align="center">
                                <%#Container.ItemIndex + 1+(this.pageIndex-1)*this.pageSize%>
                            </td>
                            <td align="left" class="pandl10">
                                <a data-class="a_Chk" data-id="<%#Eval("Id") %>"><%#Eval("PlanTitle")%></a>
                            </td>
                            <td align="center">
                                <%#Eval("IssueTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("OperatorName")%>
                            </td>
                            <td align="center">
                                <%#this.GetAcc(Eval("AcceptList"))%>
                            </td>
                            <td align="center">
                                <a data-class="a_Upd" data-id="<%#Eval("Id") %>">修改</a>|<a href="#"data-class="a_Del" data-id="<%#Eval("Id") %>">删除</a>
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
    var TrainPlanList = {
    	DataBoxy: function() {
    		return {
    			url: "/ManageCenter",
    			title: "",
    			width: "750px",
    			height: "550px"
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
    							document.location.reload();
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
    		data.url += '/TrainPlanAdd.aspx?';
    		data.title = '添加培训计划';
    		data.url += $.param({
    				doType: "add"
    			});
    		this.ShowBoxy(data);
    	},
    	Update: function(o) {
    		var data = this.DataBoxy();
    		data.url += '/TrainPlanAdd.aspx?';
    		data.title = '修改培训计划';
    		data.url += $.param({
    				doType: "update",
    				id: $(o).attr("data-id")
    			});
    		this.ShowBoxy(data);
    	},
    	Check: function(o) {
    		var data = this.DataBoxy();
    		data.url += '/TrainCheck.aspx?';
    		data.title = '查看培训计划';
    		data.url += $.param({
    				id: $(o).attr("data-id")
    			});
    		this.ShowBoxy(data);
    	},
    	Delete: function(o) {
    		var data = this.DataBoxy();
    		data.url += "/TrainPlanList.aspx?";
    		data.url += $.param({
    				doType: "delete",
    				id: $(o).attr("data-id")
    			});
    		this.GoAjax(data.url);
    	},
    	BindBtn: function() {
    		$("#link1").click(function() {
    			TrainPlanList.Add();
    			return false;
    		});
    		$("a[data-class='a_Upd']").click(function() {
    			TrainPlanList.Update(this);
    			return false;
    		});
    		$("a[data-class='a_Chk']").click(function() {
    			TrainPlanList.Check(this);
    			return false;
    		});
    		$("a[data-class='a_Del']").click(function() {
    			TrainPlanList.Delete(this);
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
    	TrainPlanList.PageInit();
    });
    </script>
</asp:Content>
