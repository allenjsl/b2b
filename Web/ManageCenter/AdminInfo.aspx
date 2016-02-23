<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="Web.ManageCenter.AdminInfo" MasterPageFile="/MasterPage/Print.Master" Title="人事档案_行政中心" ValidateRequest="false" %>
<%@ Import Namespace="EyouSoft.Common" %>
<%@ MasterType VirtualPath="/MasterPage/Print.Master" %>
<asp:Content runat="server" ID="ZhiDu" ContentPlaceHolderID="PrintC1">
    <link href="/css/sytle.css" rel="stylesheet" type="text/css" />
    <table width="695" border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <td height="35" align="center">
                <h2>
                    <strong><span id="Name" runat="server"></span></strong></h2>
            </td>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000"  class="list"
        style="border-collapse: collapse; margin: 5px auto;">
        <tr>
            <th colspan="4" align="center" bgcolor="#eeeeee">
                ==========基本信息==========
            </th>
        </tr>
        <tr>
            <td width="222" class="pandl3">
                档案编号：<span id="ArchiveNo" runat="server"></span>
            </td>
            <td width="183" class="pandl3">
                姓 名：<span id="UserName" runat="server"></span>
            </td>
            <td width="183" class="pandl3">
                性 别：<span id="ContactSex" runat="server"></span>
            </td>
            <td width="97" rowspan="5" align="center">
                <img src="../images/photo01.gif" width="85" height="100" id="Photo" runat="server"/>
            </td>
        </tr>
        <tr>
            <td class="pandl3">
                身份证号：<span id="CardId" runat="server"></span>
            </td>
            <td class="pandl3">
                出生日期：<span id="BirthDate" runat="server"></span>
            </td>
            <td class="pandl3">
                所属部门：<span id="DepartmentList" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td class="pandl3">
                职 务：<span id="DutyName" runat="server">业务一部</span>
            </td>
            <td class="pandl3">
                类 型：<span id="PersonalType" runat="server">正式员工 </span>
            </td>
            <td class="pandl3">
                员工状态：<span id="IsLeave" runat="server">在职</span>
            </td>
        </tr>
        <tr>
            <td class="pandl3">
                入职时间：<span id="EntryDate" runat="server"></span>
            </td>
            <td class="pandl3">
                工 龄：<span id="WorkYear" runat="server"></span>
            </td>
            <td class="pandl3">
                民 族：<span id="National" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td class="pandl3">
                籍 贯：<span id="Birthplace" runat="server"></span>
            </td>
            <td class="pandl3">
                政治面貌：<span id="Politic" runat="server"></span>
            </td>
            <td class="pandl3">
                婚姻状态：<span id="IsMarried" runat="server"> </span>
            </td>
        </tr>
        <tr>
            <td class="pandl3">
                联系电话：<span id="ContactTel" runat="server"></span>
            </td>
            <td class="pandl3">
                手 机：<span id="ContactMobile" runat="server"></span>
            </td>
            <td class="pandl3">
                离职时间：<span id="LeaveDate" runat="server"></span>
            </td>
            <td class="pandl3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="pandl3">
                QQ：<span id="QQ" runat="server"></span>
            </td>
            <td class="pandl3">
                MSN：<span id="MSN" runat="server"></span>
            </td>
            <td class="pandl3">
                E-mail：<span id="Email" runat="server"></span>
            </td>
            <td class="pandl3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" class="pandl3">
                住 址：<span id="ContactAddress" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="pandl3">
                备 注：<span id="Remark" runat="server"></span>
            </td>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000"  class="list"
        style="border-collapse: collapse; margin: 5px auto;">
        <tr>
            <th colspan="7" align="center" bgcolor="#eeeeee">
                ==========学历信息==========
            </th>
        </tr>
        <tr>
            <td width="74" align="center">
                开始时间
            </td>
            <td width="74" align="center">
                结束时间
            </td>
            <td width="50" align="center">
                学历
            </td>
            <td width="105" align="center">
                所学专业
            </td>
            <td width="113" align="center">
                毕业院校
            </td>
            <td width="52" align="center">
                状态
            </td>
            <td width="211" align="center">
                备注
            </td>
        </tr>
        <asp:Repeater ID="rptXueLi" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#UtilsCommons.GetDateString(Eval("StartDate"),ProviderToDate)%>
                    </td>
                    <td align="center">
                        <%#UtilsCommons.GetDateString(Eval("EndDate"), ProviderToDate)%>
                    </td>
                    <td align="center">
                        <%#Eval("Degree")%>
                    </td>
                    <td align="center">
                        <%#Eval("Professional")%>
                    </td>
                    <td align="center">
                        <%#Eval("SchoolName")%>
                    </td>
                    <td align="center">
                        <%#(bool)Eval("StudyStatus") ? "毕业" : "在读" %>
                    </td>
                    <td align="center">
                        <%#Eval("Remark") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000"  class="list">
        <tr>
            <th colspan="6" align="center" bgcolor="#eeeeee">
                ==========履历信息==========
            </th>
        </tr>
        <tr>
            <td width="74" align="center">
                开始时间
            </td>
            <td width="74" align="center">
                结束时间
            </td>
            <td width="80" align="center">
                工作地点
            </td>
            <td width="139" align="center">
                工作单位
            </td>
            <td width="105" align="center">
                从事职业
            </td>
            <td width="209" align="center">
                备注
            </td>
        </tr>
        <asp:Repeater ID="rptLvLi" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#UtilsCommons.GetDateString(Eval("StartDate"),ProviderToDate)%>
                    </td>
                    <td align="center">
                        <%#UtilsCommons.GetDateString(Eval("EndDate"), ProviderToDate)%>
                    </td>
                    <td align="center">
                        <%#Eval("WorkPlace")%>
                    </td>
                    <td align="center">
                        <%#Eval("WorkUnit") %>
                    </td>
                    <td align="center">
                        <%#Eval("TakeUp")%>
                    </td>
                    <td align="center">
                        <%#Eval("Remark")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
