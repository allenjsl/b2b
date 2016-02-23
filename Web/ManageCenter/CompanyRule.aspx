<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true" CodeBehind="CompanyRule.aspx.cs" Inherits="Web.ManageCenter.CompanyRole" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %><%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" width="15%">
                        <span class="lineprotitle">行政中心</span></td>
                    <td align="right" nowrap="nowrap" 
                        style="padding: 0 10px 2px 0; color: #13509f;" width="85%">
                        <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;规章制度</td>
                </tr>
                <tr>
                    <td bgcolor="#000000" colspan="2" height="2">
                    </td>
                </tr>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <form method="GET">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td valign="top" width="10">
                        <img src="../images/yuanleft.gif" /></td>
                    <td height="50">
                        <div class="searchbox">
                            编号： <input type="text" name="txtNum" id="txtNum" class="inputtext formsize120" size="30" value='<%=Request.QueryString["txtNum"] %>' />
                            制度标题： <input type="text" name="txtTitle" id="txtTitle" class="inputtext formsize140" size="35" value='<%=Request.QueryString["txtTitle"] %>' />
                            <button type="submit" id="btnSubmit" class="search-btn" style="vertical-align: top;"></button>
                        </div>
                    </td>
                    <td valign="top" width="10">
                        <img src="../images/yuanright.gif" /></td>
                </tr>
            </table>
        </form>
        <div class="btnbox">
            <table align="left" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="90">
                        <a id="link1" href="RuleAdd.aspx" class="toolbar_add add_gg" style='visibility:<%=IsAddGrant?"visible":"hidden" %>'>新增</a></td>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <table border="0" cellpadding="0" cellspacing="1" width="100%">
                <tr>
                    <th align="center" bgcolor="#BDDCF4" width="36">
                        序号</th>
                    <th align="center" bgcolor="#bddcf4">
                        <strong>标题</strong></th>
                    <th align="center" bgcolor="#bddcf4" width="15%">
                        <strong>操作</strong></th>
                </tr>
                <asp:Repeater ID="RepList" runat="server">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td align="center">
                                <%#Container.ItemIndex+1+(this.pageIndex-1)*this.pageSize %></td>
                            <td align="left" class="pandl10">
                                <a href="/PrintPage/ZhiDu.aspx?id=<%#Eval("id") %>" target="_blank"><%#Eval("Title")%></a></td>
                            <td align="center">
                                <a data-class="a_Upd" data-id="<%#Eval("Id") %>">修改</a>|<a data-class="a_Del" data-id="<%#Eval("Id") %>">删除</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
        var PageJsDataObj = {
        	DataBoxy: function() { /*弹窗默认参数*/
        		return {
        			url: '/ManageCenter',
        			title: "",
        			width: "650px",
        			height: "400px"
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
        						parent.tableToolbar._showMsg(result.msg, function() {
        							$("#btnSubmit").click();
        						});

        					}
        					else { parent.tableToolbar._showMsg(result.msg); }
        				},
        				error: function() {
        					parent.tableToolbar._showMsg(tableToolbar.errorMsg);
        				}
        			});
        	},
        	Add: function() {
        		var data = this.DataBoxy();
        		data.url += '/RuleAdd.aspx?';
        		data.title = '添加规章制度';
        		data.url += $.param({
        				doType: "add"
        			});
        		this.ShowBoxy(data);
        	},
        	Update: function(o) {
        		var data = this.DataBoxy();
        		data.url += '/RuleAdd.aspx?';
        		data.title = '修改规章制度';
        		data.url += $.param({
        				doType: "update",
        				id: $(o).attr("data-id")
        			});
        		this.ShowBoxy(data);
        	},
        	Delete: function(o) {
        		var data = this.DataBoxy();
        		data.url += "/CompanyRule.aspx?";
        		data.url += $.param({
        				doType: "delete",
        				id: $(o).attr("data-id")
        			});
        		this.GoAjax(data.url);
        	},
        	BindBtn: function() {
        		$(".add_gg").click(function() {
        			PageJsDataObj.Add();
        			return false;
        		});
        		$("a[data-class='a_Upd']").click(function() {
        			PageJsDataObj.Update(this);
        			return false;
        		});
        		$("a[data-class='a_Del']").click(function() {
        			PageJsDataObj.Delete(this);
        			return false;
        		});
        	},
        	PageInit: function() {
        		//绑定功能按钮
        		this.BindBtn();
        		//当列表页面出现横向滚动条时使用以下方法 $("需要滚动最外层选择器").moveScroll();
        		$('.tablelist-box').moveScroll();
        	}
        };
        
        $(function() {
        	PageJsDataObj.PageInit();
        });
    </script>
</asp:Content>
