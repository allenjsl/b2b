<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityAdd.aspx.cs" Inherits="Web.SystemSet.CityAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="ce_form" runat="server">
    <input type="hidden" name="hidMethod" id="hidMethod" value="save" />
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="18%" height="30" align="right">
                    所属省份：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="selProvince" name="selProvince" runat="server" valid="required" errmsg="省份不为空">
                    </select>
                    <span id="errMsg_<%=selProvince.ClientID %>" class="errmsg"></span>
                </td>
                <th width="18%" height="30" align="right">
                    所属地区：
                </th>
                <td bgcolor="#E3F1FC">
                    <select id="ddlArea" name="ddlArea">
                        <asp:Literal ID="lit_option" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="18%" height="30" align="right">
                    城市名称：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <input name="txtCityName" type="text" class="xtinput" id="txtCityName" maxlength="20"
                        size="40" value="<%=cityName %>" valid="required" errmsg="城市不为空" />
                    <span id="errMsg_txtCityName" class="errmsg"></span>
                    <input type="text" style="display: none;" />
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="4">
                    <table width="324" cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td width="90" height="40" align="center">
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btnsave" onclick="return save('');" runat="server">保存</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>

<script src="/js/ValiDatorForm.js" type="text/javascript"></script>

<script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

<script src="../JS/table-toolbar.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function() {
        FV_onBlur.initValid($("#<%=ce_form.ClientID %>").get(0));
    });
    //保存城市信息
    function save(method) {
        var isSuccess = ValiDatorForm.validator($("#<%=ce_form.ClientID %>").get(0), "span");
        if (!isSuccess) { return false; }
        $.newAjax(
            { url: "/SystemSet/CityAdd.aspx",
                data: { cityId: "<%=cId %>", cityName: $("#txtCityName").val(), isExist: "isExist" },
                dataType: "json",
                cache: false,
                async: false,
                type: "post",
                success: function(result) {
                    if (result.success == "1") {
                        parent.tableToolbar._showMsg("该城市已经存在！");
                        isSuccess = false;
                    }
                }
            })
        if (!isSuccess) { return false; }
        if (method == "continue") {
            document.getElementById("hidMethod").value = "continue";
        }
        //提交表单
        $("#<%=ce_form.ClientID %>").get(0).submit();
        return false;
    }
</script>

