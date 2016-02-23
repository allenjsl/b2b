<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="AdminFileList.aspx.cs" Inherits="Web.ManageCenter.AdminFileList" %>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" width="15%">
                        <span class="lineprotitle">行政中心</span>
                    </td>
                    <td align="right" nowrap="nowrap" style="padding: 0 10px 2px 0; color: #13509f;"
                        width="85%">
                        <b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;人事档案
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#000000" colspan="2" height="2">
                    </td>
                </tr>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <form id="form1" method="get">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
            <tr>
                <td valign="top" width="10">
                    <img src="../images/yuanleft.gif" alt="" />
                </td>
                <td height="50">
                    <div class="searchbox">
                        档案编号：<input id="txtcode" class="inputtext" name="txtcode" size="20" type="text" value='<%=Request.QueryString["txtcode"] %>' />
                        姓名：<input id="txtname" class="inputtext" name="txtname" size="12" type="text" value='<%=Request.QueryString["txtname"] %>' />
                        性别：<select id="selsex" name="selsex" class="inputselect">
                            <option value="0">请选择</option>
                            <option value="1">女</option>
                            <option value="2">男</option>
                        </select>
                        出生日期：<input id="txtstartdate" class="inputtext" name="txtstartdate" size="9" type="text"
                            onfocus="WdatePicker()" value='<%=Request.QueryString["txtstartdate"] %>' />
                        -
                        <input id="txtenddate" class="inputtext" name="txtenddate" size="9" type="text" onfocus="WdatePicker()"
                            value='<%=Request.QueryString["txtenddate"] %>' />
                        <br/>工龄：
                        <input id="txtstartage" class="inputtext" name="txtage" size="6" type="text" value='<%=Request.QueryString["txtage"] %>' />-
                        <input id="txtendage" class="inputtext" name="txtendage" size="6" type="text" value='<%=Request.QueryString["txtendage"] %>' />
                        职务：
                        <select id="dpJobPostion" name="dpJobPostion" class="inputselect">
                            <%=dutylist%>
                        </select>
                        类型：
                        <select id="dpWorkerType" name="dpWorkerType" class="inputselect">
                            <option <%=Request.QueryString["dpWorkerType"]=="-1"? "selected='selected'":""%> value="-1">请选择</option>
                            <option <%=Request.QueryString["dpWorkerType"]=="0"? "selected='selected'":""%> value="0">正式员工</option>
                            <option <%=Request.QueryString["dpWorkerType"]=="1"? "selected='selected'":""%> value="1">试用期</option>
                            <option <%=Request.QueryString["dpWorkerType"]=="2"? "selected='selected'":""%> value="2">学徒期</option>
                        </select>
                        员工状态：
                        <select id="dpWorkerState" name="dpWorkerState" class="inputselect">
                            <option <%=Request.QueryString["dpWorkerState"]=="-1"? "selected='selected'":""%> value="-1">请选择</option>
                            <option <%=Request.QueryString["dpWorkerState"]=="0"? "selected='selected'":""%> value="0">在职</option>
                            <option <%=Request.QueryString["dpWorkerState"]=="1"? "selected='selected'":""%> value="1">离职</option>
                        </select>
                        婚姻状况：
                        <select id="dpMarriageState" name="dpMarriageState" class="inputselect">
                            <option <%=Request.QueryString["dpMarriageState"]=="-1"? "selected='selected'":""%> value="-1">请选择</option>
                            <option <%=Request.QueryString["dpMarriageState"]=="0"? "selected='selected'":""%> value="0">未婚</option>
                            <option <%=Request.QueryString["dpMarriageState"]=="1"? "selected='selected'":""%> value="1">已婚</option>
                        </select>
                        <input type="submit" class="search-btn" value="" />
                        </div>
                </td>
                <td valign="top" width="10">
                    <img src="../images/yuanright.gif" alt="" />
                </td>
            </tr>
        </table>
        </form>
        <div class="btnbox">
            <table align="left" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" width="90">
                        <a href="javascript:;" id="add_bar">新 增</a>
                    </td>
                    <td align="center" width="90">
                        <a href="javascript:;" class="toolbar_daochu" onclick="toXls1();return false;" hidefocus="true">
                            <img src="../images/excel-xz.gif" style="vertical-align: top;" alt="" />导出excel</a>
                    </td>
                    <td align="center" width="90">
                        <a id="btn_print" href="/PrintPage/DangAn.aspx??txtcode=<%=Request.QueryString["txtcode"] %>&txtname=<%=Request.QueryString["txtname"] %>&selsex=<%=Request.QueryString["selsex"] %>&txtstartdate=<%=Request.QueryString["txtstartdate"] %>&txtenddate=<%=Request.QueryString["txtenddate"] %>&txtage=<%=Request.QueryString["txtage"] %>&txtendage=<%=Request.QueryString["txtendage"] %>&dpJobPostion=<%=Request.QueryString["dpJobPostion"] %>&dpWorkerType=<%=Request.QueryString["dpWorkerType"] %>&dpWorkerState=<%=Request.QueryString["dpWorkerState"] %>&dpMarriageState=<%=Request.QueryString["dpMarriageState"] %>&page=<%=Request.QueryString["page"] %>" target="_blank">打印</a>
                    </td>

                </tr>
            </table>
        </div>
        <div class="tablelist" class="tablelist-box">
            <table border="0" cellpadding="0" cellspacing="1" width="100%" id="liststyle">
                <tr>
                    <th align="center" bgcolor="#BDDCF4" width="36">
                        序号
                    </th>
                    <th align="center" bgcolor="#BDDCF4">
                        <strong>档案编号</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="7%">
                        <strong>姓名</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="5%">
                        <strong>性别</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="8%">
                        <strong>出生日期</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="9%">
                        <strong>所属部门</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="7%">
                        <strong>职务</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="4%">
                        <strong>工龄</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="8%">
                        <strong>联系电话</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="8%">
                        <strong>手机</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        <strong>E-mail</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="8%">
                        <strong>微信号</strong>
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="12%">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-id='<%#Eval("Id") %>'>
                            <td align="center">
                                <%#Container.ItemIndex+1+(this.pageIndex-1)*this.pageSize %>
                            </td>
                            <td align="center">
                                <%#Eval("ArchiveNo")%>
                            </td>
                            <td align="center" >
                                <%#Eval("UserName") %>
                            </td>
                            <td align="center">
                                <%#((EyouSoft.Model.EnumType.CompanyStructure.Sex)Eval("ContactSex")).ToString() %>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("BirthDate"),"yyyy-MM-dd")%>
                            </td>
                            <td align="center">
                                <%#GetDepartMent(Eval("DepartmentList"))%>
                            </td>
                            <td align="center">
                                <%#Eval("DutyName")%>
                            </td>
                            <td align="center">
                                <%#Eval("WorkYear")%>
                            </td>
                            <td align="center">
                                <%#Eval("ContactTel") %>
                            </td>
                            <td align="center">
                                <%#Eval("ContactMobile")%>
                            </td>
                            <td align="center" >
                                <%#Eval("Email")%>
                            </td>
                            <td align="center" >
                                <%#Eval("WeiXinHao")%>
                            </td>
                            <td align="center">
                                <a href="javascript:;" class="update_bar">修改</a>|<a href="javascript:;" class="delete_bar">删除</a>|<a
                                    href="AdminInfo.aspx?id=<%#Eval("Id") %>" target="_blank" class="showinfo">查看</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal runat="server" ID="lbemptymsg"></asp:Literal>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
    $(function(){
        tableToolbar.init({tableContainerSelector: "#liststyle"});
        AdminManage.PageInit();
    })
    var AdminManage={
         ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            AddData:function(){
               location.href="/ManageCenter/AdminAdd.aspx?dotype=add";
            },
            UpdateData:function(id){
               location.href="/ManageCenter/AdminAdd.aspx?dotype=update&PersonnelID="+id;
            },
            PageInit:function(){
                $("#add_bar").click(function(){
                    AdminManage.AddData();
                    return false;
                })
                $(".update_bar").click(function(){
                    var id=$(this).closest("tr").attr("data-id");
                    AdminManage.UpdateData(id);
                    return false;
                })
                $(".delete_bar").click(function(){
                    var id=$(this).closest("tr").attr("data-id");
                    var url="/ManageCenter/AdminFileList.aspx?dotype=delete&id="+id;
                    AdminManage.GoAjax(url);
                    return false;
                })
                $(".showinfo").click(function(){
                    var id=$(this).closest("tr").attr("data-id");
                    location.href="#";
                })
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
    }
    </script>

</asp:Content>
