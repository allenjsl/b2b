<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobAdd.aspx.cs" Inherits="Web.ManageCenter.JobAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>

    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="500" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    职务名称：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <input type="text" size="40" id="txtDutyName" class="xtinput inputtext" name="txtDutyName" maxlength="100"
                        runat="server" />
                        <span class="errmsg" id="tip" style="display:none;">*请填写职务名称!</span>
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    职务说明：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <textarea rows="4" cols="50" style="height:90px;" name="txtDesc" id="txtDesc" class="inputtext" maxlength="1000" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    职务具体要求：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <textarea rows="4" cols="50" style="height:90px;" name="txtDutyRequired" id="txtDutyRequired" class=" inputtext" maxlength="1000"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th width="21%" height="30" align="right">
                    备&nbsp;&nbsp;&nbsp;&nbsp;注：
                </th>
                <td width="79%" bgcolor="#E3F1FC">
                    <textarea rows="4" cols="50" style="height:90px;" name="txtremark" id="txtremark" runat="server" class="inputtext" maxlength="1000"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="8">
                    <table width="340" cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td width="106" height="40" align="center">
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn" runat="server">保存</a>
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" onclick="window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();">关闭</a>
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

<script type="text/javascript">
    $(function() {
        DutyAdd.BindBtn();
    })
    var DutyAdd = {
        GoAjax: function(url) {
         $("#<%=btn.ClientID %>").html("提交中...");
         $("#<%=btn.ClientID %>").unbind("click");
            $.newAjax({
                type: "post",
                cache: false,
                url: url,
                dataType: "json",
                data: $("#<%=btn.ClientID %>").closest("form").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                       parent.tableToolbar._showMsg(ret.msg, function() { parent.location.href = parent.location.href; });
                    }
                    else {
                       parent.tableToolbar._showMsg(ret.msg,function(){DutyAdd.BindBtn()});
                    }
                },
                error: function() {
                  tableToolbar._showMsg(tableToolbar.errorMsg,function(){DutyAdd.BindBtn()});
                }
            });
        },
        BindBtn: function() {
            //绑定Add事件
            $("#<%=btn.ClientID %>").click(function() {
                if($("#<%=txtDutyName.ClientID %>").val()==""){
                     $("#tip").show();
                     return false;
                   }
                var ajaxUrl = "/ManageCenter/JobAdd.aspx?type=save&dotype=update&dutyid=" + '<%=Request.QueryString["dutyid"]%>';
                DutyAdd.GoAjax(ajaxUrl);
                return false;
            })
            $("#<%=txtDutyName.ClientID %>").focus(function(){
                $("#tip").hide();
            })
            $("#<%=btn.ClientID %>").html("保存");
        }

    }
   
</script>

