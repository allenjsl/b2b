<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainCheck.aspx.cs" Inherits="Web.ManageCenter.TrainCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Css/sytle.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <table width="700" cellspacing="1" cellpadding="0" border="0" align="center" style="margin-top: 20px;">
        <tbody>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    计划标题：
                </th>
                <td height="30" bgcolor="#E3F1FC" class="pandl3" colspan="3">
                    <InnerText runat="server" id="txtTitle"></InnerText>
                </td>
            </tr>
            <tr class="odd">
                <th width="17%" valign="middle" height="30" align="right">
                    计划内容：
                </th>
                <td bgcolor="#E3F1FC" class="pandl4" colspan="3">
                    <InnerText runat="server" id="txtContent"></InnerText>
                </td>
            </tr>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    发送对象&nbsp;：
                </th>
                <td height="30" bgcolor="#E3F1FC" class="pandl4" colspan="3">
                    <InnerText runat="server" id="txtDuiXiang"></InnerText>
                </td>
            </tr>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    发布人：
                </th>
                <td width="32%" bgcolor="#E3F1FC" class="pandl3">
                    <InnerText runat="server" id="txtFaBuRen"></InnerText>
                </td>
                <th width="17%" height="30" align="right">
                    发布时间：
                </th>
                <td width="34%" bgcolor="#E3F1FC" class="pandl3">
                    <InnerText runat="server" id="txtFaBuDate"></InnerText>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
