<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalWorkCheck.aspx.cs"
    Inherits="Web.ManageCenter.PersonalWorkCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <body>
        <table width="600" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px;">
            <tbody>
                <tr>
                    <td height="26" bgcolor="#bddcf4" align="left" class="pandl10">
                        考勤时间：
                        <input type="text" size="15" value="用日期控件" class="searchinput2" name="textfield">
                        至
                        <input type="text" size="15" value="用日期控件" class="searchinput2" name="textfield4">
                        考勤人员：<input type="text" size="25" class="searchinput2" name="textfield42">
                        <a id="link1" href="xuanzerenyuan.html">
                            <img border="0" style="vertical-align: top;" src="../images/sanping_04.gif"></a>
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        <input type="checkbox" value="checkbox" name="checkbox">准点
                        <input type="checkbox" value="checkbox" name="checkbox2">
                        迟到
                        <input type="checkbox" value="checkbox" name="checkbox3">
                        早退
                        <input type="checkbox" value="checkbox" name="checkbox4">
                        旷工
                        <input type="checkbox" value="checkbox" name="checkbox5">
                        休假
                        <input type="checkbox" value="checkbox" name="checkbox6">
                        外出
                        <input type="checkbox" value="checkbox" name="checkbox7">
                        出团
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        <input type="checkbox" value="checkbox" name="checkbox8">请假
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        请假原因：
                        <input type="text" size="60" class="searchinput2" name="textfield2">
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        请假时间：
                        <input type="text" value="用日期控件" class="searchinput2" name="textfield3">
                        至
                        <input type="text" value="用日期控件" class="searchinput2" name="textfield32">
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        请假天数：
                        <input type="text" size="15" class="searchinput2" name="textfield33">
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        <input type="checkbox" value="checkbox" name="checkbox82">加班
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        加班内容：
                        <input type="text" size="60" class="searchinput2" name="textfield22">
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        加班时间：
                        <input type="text" value="用日期控件" class="searchinput2" name="textfield34">
                        至
                        <input type="text" value="用日期控件" class="searchinput2" name="textfield322">
                    </td>
                </tr>
                <tr>
                    <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                        加班时数：
                        <input type="text" size="15" class="searchinput2" name="textfield22">
                    </td>
                </tr>
                <tr>
                    <td height="40" bgcolor="#bddcf4" align="center">
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td width="86" height="40" align="center" class="tjbtn02">
                                        <a href="#">确认</a>
                                    </td>
                                    <td width="86" height="40" align="center" class="tjbtn02">
                                        <a href="#">取消</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </body>
    </form>
</body>
</html>
