<%@ Page Title="酒店预订单" Language="C#" MasterPageFile="~/MasterPage/Print.Master" AutoEventWireup="true"
    CodeBehind="SupplierHotel.aspx.cs" Inherits="Web.PrintPage.SupplierHotel" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">酒店预订单</b>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                (TO)：<asp:Literal runat="server" ID="ltrSupplierName"></asp:Literal>
            </td>
            <td align="left">
                自(From)：<asp:Literal runat="server" ID="ltrCompanyName"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                传真(Fax)：<asp:Literal runat="server" ID="ltrSupplierFax"></asp:Literal>
            </td>
            <td align="left">
                传真(Fax)：<asp:Literal runat="server" ID="ltrCompanyFax"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                收件人：<asp:Literal runat="server" ID="ltrSupplierContact"></asp:Literal>
            </td>
            <td align="left">
                发件人：<asp:Literal runat="server" ID="ltrCompanyContact"></asp:Literal>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <th align="center">
                预订酒店
            </th>
            <th align="center">
                入住时间
            </th>
            <th align="center">
                退房时间
            </th>
            <th align="center">
                房型
            </th>
            <th align="center">
                间夜
            </th>
            <th align="center">
                备注
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rpthotel">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%# Eval("JiuDianname")%>
                    </td>
                    <td align="center">
                        <%# EyouSoft.Common.UtilsCommons.GetDateString(Eval("RuZhuTime"), this.ProviderToDate)%>
                    </td>
                    <td align="center">
                        <%# EyouSoft.Common.UtilsCommons.GetDateString(Eval("TuiFangTime"), this.ProviderToDate)%>
                    </td>
                    <td align="center">
                        <%# Eval("FangXing")%>
                    </td>
                    <td align="center">
                        <%# Eval("Jianye")%>
                    </td>
                    <td align="center">
                        <%# Eval("QuFangFangShi")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td width="60%" align="left">
                <strong>结算明细：</strong><asp:Literal runat="server" ID="ltrMingXi"></asp:Literal>
            </td>
            <td width="40%" align="left">
                <strong>结算金额：</strong><asp:Literal runat="server" ID="ltrJinE"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <strong>安排备注：</strong><asp:Literal runat="server" ID="ltrRemark"></asp:Literal>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td width="45%" align="left">
                接待方确认：
            </td>
            <td align="left">
                预订方：<asp:Literal runat="server" ID="ltrCompanyName1"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <p>
                    确认说明：</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" height="150" align="center">
                接待方（签名）盖章
            </td>
            <td width="50%" align="center">
                <div id="divImgCachet">
                    签章 <asp:Literal runat="server" ID="ltrIssueTime"></asp:Literal>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
