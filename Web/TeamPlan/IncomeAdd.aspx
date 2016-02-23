<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeAdd.aspx.cs" Inherits="Web.TeamPlan.IncomeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        收入时间：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="textfield2" class="formsize80" name="textfield2">
                    </td>
                    <th width="120" align="right">
                        收入项目：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="textfield3" class="formsize120" name="textfield3">
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        收入金额：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input type="text" id="textfield" class="formsize80" name="textfield">
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        收入备注：
                    </th>
                    <td bgcolor="#E3F1FC" align="left" colspan="3">
                        <textarea id="textfield5" class="formsize260" rows="3" name="textfield6"></textarea>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        单位类型：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <select id="select" name="select">
                            <option>客户单位</option>
                            <option>供应商</option>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        对方单位：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input type="text" id="textfield4" class="formsize140" name="textfield4">
                        <img width="28" height="18" style="vertical-align: top;" src="../images/sanping_04.gif">
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
                                        <a href="#">保存</a>
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
