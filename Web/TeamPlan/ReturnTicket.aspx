<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnTicket.aspx.cs" Inherits="Web.TeamPlan.ReturnTicket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>常规业务-退票</title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 830px; margin: 10px auto;">
        <span class="formtableT">已退票列表</span>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th width="36" height="30">
                        编号
                    </th>
                    <th width="106">
                        退票时间
                    </th>
                    <th width="67">
                        经手人
                    </th>
                    <th width="67">
                        退票人数
                    </th>
                    <th width="129">
                        客户单位
                    </th>
                    <th width="185">
                        损失明细
                    </th>
                    <th width="100">
                        损失金额
                    </th>
                    <th width="70">
                        应退金额
                    </th>
                    <th width="60">
                        操作
                    </th>
                </tr>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="center">
                        1
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        2012-11-02
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        杨艳
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        5
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        &nbsp;
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        &nbsp;
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        5889
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        598
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        <a href="">修改</a> <a href="">删除</a>
                    </td>
                </tr>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="center">
                        2
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        2012-11-02
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        杨艳
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        5
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        &nbsp;
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        &nbsp;
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        5896
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        698
                    </td>
                    <td bgcolor="#E3F1FC" align="center">
                        <a href="">修改</a> <a href="">删除</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="width: 830px; margin: 10px auto;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th height="22" align="left" class="pandl4" colspan="4">
                        请选择你需要退票的游客
                    </th>
                </tr>
                <tr class="even">
                    <td align="right" colspan="4">
                        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#ffffff"
                            align="center">
                            <tbody>
                                <tr class="even">
                                    <th height="22" align="left" class="pandl4" colspan="8">
                                        订单号：2012110208&nbsp; 客户单位：XXXX旅行社&nbsp; 人数：8+2+0&nbsp; 占位数：10
                                    </th>
                                </tr>
                                <tr class="odd">
                                    <td bgcolor="#E3F1FC" align="center">
                                        <input type="checkbox" id="checkbox" name="checkbox">
                                        1
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        杨燕
                                    </td>
                                    <td height="30" bgcolor="#E3F1FC" align="center">
                                        成人
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        身份证
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        420321199011051856
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        女
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        18758585958
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        已出票
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td bgcolor="#E3F1FC" align="center">
                                        <input type="checkbox" id="checkbox2" name="checkbox2">
                                        2
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        杨洋
                                    </td>
                                    <td height="30" bgcolor="#E3F1FC" align="center">
                                        成人
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        户口本
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        36420321199011051856
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        男
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        0571-87868589
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        已退票
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr class="odd">
                    <td align="right" colspan="4">
                        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#ffffff"
                            align="center">
                            <tbody>
                                <tr class="even">
                                    <th height="22" align="left" class="pandl4" colspan="8">
                                        订单号：2012110208&nbsp; 客户单位：XXXX旅行社&nbsp; 人数：8+2+0&nbsp; 占位数：10
                                    </th>
                                </tr>
                                <tr class="odd">
                                    <td bgcolor="#E3F1FC" align="center">
                                        <input type="checkbox" id="checkbox3" name="checkbox3">
                                        1
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        杨燕
                                    </td>
                                    <td height="30" bgcolor="#E3F1FC" align="center">
                                        成人
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        身份证
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        420321199011051856
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        女
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        18758585958
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        已出票
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td bgcolor="#E3F1FC" align="center">
                                        <input type="checkbox" id="checkbox4" name="checkbox3">
                                        2
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        杨洋
                                    </td>
                                    <td height="30" bgcolor="#E3F1FC" align="center">
                                        成人
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        户口本
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        36420321199011051856
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        男
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        0571-87868589
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center">
                                        未出票
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="120" align="right">
                        退票时间：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtBackTicketTime" CssClass="formsize80 inputtext" runat="server"></asp:TextBox>
                    </td>
                    <th width="120" align="right">
                        损失明细：
                    </th>
                    <td bgcolor="#E3F1FC">
                         <asp:TextBox ID="txtSesc" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="120" align="right">
                        损失总价：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtTotalPrice" CssClass="formsize80 inputtext" runat="server"></asp:TextBox>
                    </td>
                    <th align="right">
                        承担方：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtChengdan" CssClass="formsize80 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        经手人：
                    </th>
                    <td bgcolor="#E3F1FC">
                        刘茂
                    </td>
                    <th align="right">
                        应退金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtYingTuiMoney" CssClass="formsize80 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="left" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="80" height="40" align="center" class="tjbtn02">
                                        <a href="#">退票</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
