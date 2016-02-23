<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrafficAdd.aspx.cs" Inherits="Web.SystemSet.TrafficAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="520" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="16%" height="30" align="right">
                    交通名称：
                </th>
                <td width="84%" bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox ID="txtTrafficName" CssClass="inputtext formsize180" runat="server"></asp:TextBox>
                    <span id="tip" class="errmsg" style="display: none">*请填写交通名称</span>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="248" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btn" hidefocus="true" runat="server">保存</a>
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
        TrafficAdd.BindBtn();
    })
    var TrafficAdd = {
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
                       parent.tableToolbar._showMsg(ret.msg,function(){TrafficAdd.BindBtn()});
                    }
                },
                error: function() {
                  tableToolbar._showMsg(tableToolbar.errorMsg,function(){TrafficAdd.BindBtn()});
                }
            });
        },
        BindBtn: function() {
            //绑定Add事件
            $("#<%=btn.ClientID %>").click(function() {
                if($("#<%=txtTrafficName.ClientID %>").val()==""){
                     $("#tip").show();
                     return false;
                   }
                var ajaxUrl = "/SystemSet/TrafficAdd.aspx?type=save&dotype=update&trafficid=" + '<%=Request.QueryString["trafficid"]%>';
                TrafficAdd.GoAjax(ajaxUrl);
                return false;
            })
            $("#<%=txtTrafficName.ClientID %>").focus(function(){
                $("#tip").hide();
            })
            $("#<%=btn.ClientID %>").html("保存");
        }

    }
   
</script>

