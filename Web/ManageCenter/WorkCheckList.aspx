<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="WorkCheckList.aspx.cs" Inherits="Web.ManageCenter.WorkCheckList" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/SelectSection.ascx" TagName="SelectSection" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
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
                            <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;考勤管理
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
        <form method="GET" id="form1">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="../images/yuanleft.gif">
                    </td>
                    <td height="50">
                        <div class="searchbox">
                            员工编号：
                            <input type="text" size="20" id="txtArchiveNo" class="searchinput2" name="txtArchiveNo" value='<%=Request.QueryString["txtArchiveNo"] %>'/>
                            姓名：<input type="text" size="12" id="txtStaffName" class="searchinput2" name="txtStaffName" value='<%=Request.QueryString["txtStaffName"]%>'/>
                            部门：
                            <uc1:SelectSection ID="SelectSection1" runat="server" SetTitle="部门选用" SModel="1" />
                            <input type="submit" value=" " class="search-btn" id="btnSubmit" />
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
                            <a id="link3" class="toolbar_piliangkq" style='visibility:<%=IsAddGrant?"visible":"hidden" %>'>批量考勤</a>
                        </td>
                        <td width="90" align="center">
                            <a target="_blank" href="PersonalList.aspx">个人考勤表</a>
                        </td>
                        <td width="90" align="center">
                            <a target="_blank" href="CollectAllList.aspx">考勤汇总表</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="5%" bgcolor="#BDDCF4" align="center" class="thinputbg">
                            全选<input type="checkbox" id="checkbox" name="checkbox"/>
                        </th>
                        <th width="8%" bgcolor="#BDDCF4" align="center">
                            <strong>员工编号</strong>
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            <strong>姓名</strong>
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            <strong>部门</strong>
                        </th>
                        <th width="51%" bgcolor="#bddcf4" align="center">
                            <strong>当月考勤概况</strong>
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            <strong>考勤明细</strong>
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            <strong>考勤登记</strong>
                        </th>
                    </tr>
                    <asp:repeater ID="rptLst" runat="server">
                        <ItemTemplate>
                            <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                                <td align="center">
                                    <input type="checkbox" name="checkbox" value="<%#Eval("StaffNo")%>" data-name="<%#Eval("StaffName") %>"/>
                                    <span class="selector_index"><%# (this.pageIndex-1)*this.pageSize + Container.ItemIndex+1 %></span>
                                </td>
                                <td  align="center" class="pandl3">
                                    <%#Eval("ArchiveNo")%>
                                </td>
                                <td align="center">
                                    <%#Eval("StaffName")%>
                                </td>
                                <td  align="center">
                                    <%#this.GetDeptNameByList(((System.Collections.Generic.List<EyouSoft.Model.CompanyStructure.Department>)Eval("DepartmentList")))%>
                                </td>
                                <td  align="center">
                                    准点<%#Eval("Punctuality") %>天，迟到<%#Eval("Late") %>天，早退<%#Eval("LeaveEarly")%>天，旷工<%#Eval("Absenteeism")%>天，休假<%#Eval("Vacation")%>天，外出<%#Eval("Out")%>天，出团<%#Eval("Group")%>天，请假<%#Math.Round((decimal)Eval("AskLeave"),1)%>天，加班<%#Math.Round((decimal)Eval("OverTime"),1)%>小时
                                </td>
                                <td  align="center">
                                    <a class="kq_ck check-btn" href="WorkCheckInfo.aspx?id=<%#Eval("StaffNo")%>">查看</a>
                                </td>
                                <td  align="center">
                                    <a class="kq_dj" href="WorkCheckAdd.aspx?id=<%#Eval("StaffNo")%>" style='visibility:<%=IsAddGrant?"visible":"hidden" %>'>登记</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:repeater>
                    <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                        <tr>
                            <td colspan="11" align="center">
                                暂无数据。
                            </td>
                        </tr>
                    </asp:PlaceHolder>
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
<%-- ReSharper disable LValueIsExpected --%>
    <script type="text/javascript">
        var PageJsDataObj = {
        	BindClose: function() {
        		$("a[data-class='a_close']").unbind().click(function() {
        			window.location.reload();
        			return false;
        		});
        	},
        	DataBoxy: function() { /*弹窗默认参数*/
        		return {
        			url: '/ManageCenter',
        			title: "",
        			width: "520px",
        			height: "420px"
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
            //考勤登记
        	AttentBook: function(obj) {
        		var data = this.DataBoxy();
        		data.url = $(obj).attr("href") + "&";
        		data.url += $.param({
        				doType: "add"
        			});
        		data.title = "考勤登记";
        		this.ShowBoxy(data);
        	},
            //考勤明细
        	AttenShow: function(obj) {
        		var data = this.DataBoxy();
        		data.url = $(obj).attr("href") + "&";
        		data.url += $.param({
        			});
        		data.width = "650px";
        		data.height = "650px";
        		data.title = "考勤明细";
        		this.ShowBoxy(data);
        	},
            //考勤汇总
        	AttenStaic: function(obj) {
        		var data = this.DataBoxy();
        		data.url = $(obj).attr("href") + '?';
        		data.url += $.param({
        				toxlsrecordcount: 2

        			});
        		data.title = "考勤汇总表";
        		data.width = "850px";
        		data.height = "460px";
        		this.ShowBoxy(data);
        	},
        	BindBtn: function() {
        		tableToolbar.init({
        				objectName: "考勤信息",
        				otherButtons: [{
        					button_selector: '.toolbar_piliangkq',
        					sucessRulr: 2,
        					msg: '未选中任何考勤信息 ',
        					buttonCallBack: function(objArr) {
        						var list = new Array();
        						var names = new Array();
        						for (var i = 0; i < objArr.length; i++) {
        							if (objArr[i].find("input[type='checkbox']").val() != "on") {
        								list.push(objArr[i].find("input[type='checkbox']").val());
        								names.push(objArr[i].find("input[type='checkbox']").attr("data-name"));
        							}
        						}
        						var data = PageJsDataObj.DataBoxy();
        						data.url = "BatchExamine.aspx?";
        						data.url += $.param({
        								id: list.join(','),
        								names: names.join('、')
        							});
        						data.title = "批量考勤";
        						data.width = "620px";
        						PageJsDataObj.ShowBoxy(data);
        						return false;
        					}
        				}]
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
        	$(".kq_hz").click(function() {
        		PageJsDataObj.AttenStaic(this);
        		return false;
        	});
        	$(".kq_dj").click(function() {
        		PageJsDataObj.AttentBook(this);
        		return false;
        	});
        	$(".kq_ck").click(function() {
        		PageJsDataObj.AttenShow(this);
        		PageJsDataObj.BindClose();
        		return false;
        	});
        	PageJsDataObj.PageInit();
        });
    </script>
<%-- ReSharper restore LValueIsExpected --%>
</asp:Content>
