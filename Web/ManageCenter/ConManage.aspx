<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ConManage.aspx.cs" Inherits="Web.ManageCenter.ConManage" %>
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
                            <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;会议记录管理
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
                            会议编号：
                            <input type="text" id="txtNum" name="txtNum" class="inputtext formsize120" size="30" value='<%=Request.QueryString["txtNum"] %>' />
                            会议主题：
                            <input type="text" id="txtTitle" name="txtTitle" class="inputtext formsize140" size="35" value='<%=Request.QueryString["txtTitle"] %>' />
                            会议时间：
                            <input type="text" id="txtStartTime" name="txtStartTime" class="inputtext formsize120"
                        size="35" value='<%=Request.QueryString["txtStartTime"] %>' onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtEndTime\')}'})" />
                            至
                            <input type="text" id="txtEndTime" name="txtEndTime" class="inputtext formsize120"
                        size="35" value='<%=Request.QueryString["txtEndTime"] %>' onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',minDate:'#F{$dp.$D(\'txtStartTime\')}'})" />
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
                            <%--<a id="link1" href="huiyijilugl_add.html">新增</a>--%>
                            <li><a href="javascript:void(0)" hidefocus="true" class="toolbar_add add_gg" style='visibility:<%=IsAddGrant?"visible":"hidden" %>'><s class="addicon"></s><span>新增</span></a> </li>
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
                            <strong>会议编号</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>会议主题</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>参会人员</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>会议时间</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>会议地点</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>备注</strong>
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
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
                            <%#Eval("MetttingNo")%>
                        </td>
                        <td align="left" class="pandl3">
                            <%#Eval("Title")%>
                        </td>
                        <td align="left" class="pandl3">
                            <%#Eval("Personal")%>
                        </td>
                        <td align="center">
                            <%#Eval("BeginDate", "{0:yyyy-MM-dd HH:mm}")%>至<%#Eval("EndDate", "{0:yyyy-MM-dd HH:mm}")%>
                        </td>
                        <td align="center">
                            <%#Eval("Location")%>
                        </td>
                        <td align="center">
                            <%#EyouSoft.Common.Utils.GetText(Eval("Remark").ToString(), 40, true)%>
                        </td>
                        <td align="center">
                            <a data-class="a_Upd" data-id='<%#Eval("Id")%>' href="javascript:void(0)">修改</a>|<a data-class="a_Del" data-id='<%#Eval("Id")%>' href="javascript:void(0)">删除</a>
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
        var PageJsData = {
            DataBoxy: function() {/*弹窗默认参数*/
                return {
                    url: '/ManageCenter',
                    title: "",
                    width: "700px",
                    height: "350px"
                }
            },
            ShowBoxy: function(data) {/*显示弹窗*/
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
                var data =  this.DataBoxy();
                data.url += '/ConferenceAdd.aspx?';
                data.title = '添加会议';
                data.url += $.param({
                    doType: "add"
                });
                this.ShowBoxy(data);
            },
            Update: function(objsArr) {
                var data =  this.DataBoxy();
                data.url += '/ConferenceAdd.aspx?';
                data.title = '修改会议';
                data.url += $.param({
                    doType: "update",
                    id: $(objsArr).attr("data-id")
                });
                this.ShowBoxy(data);
            },
            Delete: function(objsArr) {
                var data =  this.DataBoxy();
                data.url += "/ConManage.aspx?";
                data.url += $.param({
                    doType: "delete",
                    id: $(objsArr).attr("data-id")
                });
                this.GoAjax(data.url);
            },
            BindBtn: function() {
            	$(".add_gg").click(function() {
            		PageJsData.Add();
            		return false;
            	});
            	$("a[data-class='a_Upd']").click(function() {
            		PageJsData.Update(this);
            		return false;
            	});
            	$("a[data-class='a_Del']").click(function() {
            		PageJsData.Delete(this);
            		return false;
            	});
            },
            PageInit: function() {
                //绑定功能按钮
                this.BindBtn();
                //当列表页面出现横向滚动条时使用以下方法 $("需要滚动最外层选择器").moveScroll();
                //$('.tablelist-box').moveScroll();
            }
        }
        $(function() {
            PageJsData.PageInit();
        });
    </script>
</asp:Content>
