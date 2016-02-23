<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="MailList.aspx.cs" Inherits="Web.ManageCenter.MailList" %>
 <%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Src="~/UserControl/SelectSection.ascx" TagName="SelectSection1" TagPrefix="uc2" %>
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
                            <b>当前所在位置：</b>&gt;&gt; <a href="#">行政中心</a>&gt;&gt;内部通讯录
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
        <form method="GET">
            <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
                <tbody>
                    <tr>
                        <td width="10" valign="top">
                            <img src="../images/yuanleft.gif">
                        </td>
                        <td valign="top">
                            <div style="height: 30px;" class="searchbox">
                                姓名：<input type="text" class="inputtext formsize140" size="35" id="txtName" name="txtName" value='<%=Request.QueryString["txtName"] %>' />
                                <%--<input type="text" size="20" id="textfield" class="searchinput2" name="textfield">--%>
                                部门：
                                <uc2:SelectSection1 ID="SelectSection1" runat="server" SModel="1" SetTitle="部门选用" />
                                &nbsp;员工状态：
                                <select name="select" id="select">
                                    <option <%=Request.QueryString["select"]=="0"? "selected='selected'":"" %> value="0">请选择</option>
                                    <option <%=Request.QueryString["select"]=="1"? "selected='selected'":"" %> value="1">在职</option>
                                    <option <%=Request.QueryString["select"]=="2"? "selected='selected'":"" %> value="2">离职</option>
                                </select>
                                <button type="submit" class="search-btn" style="vertical-align: top;"></button>
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
                            <a target="_blank" href="PrintMailList.aspx">打印</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:void(0);" onclick="toXls1();return false;">导出</a>
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
                        <th width="7%" bgcolor="#BDDCF4" align="center">
                            <strong>姓名</strong>
                        </th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            <strong>部门</strong>
                        </th>
                        <th width="11%" bgcolor="#bddcf4" align="center">
                            <strong>电话</strong>
                        </th>
                        <th width="10%" bgcolor="#bddcf4" align="center">
                            <strong>手机</strong>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <strong>银行账号</strong>
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            QQ
                        </th>
                        <th width="10%" bgcolor="#bddcf4" align="center">
                            <!--MSN-->手机短号
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            微信号
                        </th>
                    </tr>
                    <asp:Repeater ID="RepList" runat="server">
                        <ItemTemplate>
                            <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                                <td align="center">
                                    <%#Container.ItemIndex+1+(this.pageIndex-1)*this.pageSize %>
                                </td>
                                <td align="center" class="pandl3">
                                    <%#Eval("UserName")%>
                                </td>
                                <td align="center">
                                    <%#this.getSectionInfo(Eval("DepartmentList"))%>
                                </td>
                                <td align="center">
                                    <%#Eval("ContactTel")%>
                                </td>
                                <td align="center">
                                    <%#Eval("ContactMobile")%>
                                </td>
                                <td align="center">
                                    <%#GetYinHangZhangHu(Eval("YinHangZhangHus"))%>
                                </td>
                                <td align="center">
                                    <%#Eval("QQ")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Msn")%>
                                </td>
                                <td align="center">
                                    <%#Eval("WeiXinHao")%>
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
</asp:Content>
