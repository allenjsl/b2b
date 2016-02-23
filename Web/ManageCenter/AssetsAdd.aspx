<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetsAdd.aspx.cs" Inherits="Web.ManageCenter.AssetsAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    <script src="/Js/datepicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/Js/ValiDatorForm.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    <script src="/Js/table-toolbar.js" type="text/javascript"></script>
    <script src="/Js/jquery.boxy.js" type="text/javascript"></script>
    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="600" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="15%" height="30" align="right">
                    资产编号：
                </th>
                <td width="35%" bgcolor="#E3F1FC">
                    <input type="text" size="20" id="txtAssetNo" class="inputtext formsize80" name="txtAssetNo" runat="server" valid="required" errmsg="资产编号不能为空！" maxlength="250"/>
                </td>
                <th width="16%" height="30" align="right">
                    资产名称：
                </th>
                <td width="34%" bgcolor="#E3F1FC">
                    <input type="text" size="28" id="txtAssetName" class="inputtext formsize80" name="txtAssetName" runat="server" valid="required" errmsg="资产名称不能为空！" maxlength="250"/>
                </td>
            </tr>
            <tr class="odd">
                <th width="16%" height="30" align="right">
                    购买时间：
                </th>
                <td width="34%" bgcolor="#E3F1FC">
                <asp:TextBox runat="server" ID="txtBuyDate" CssClass="inputtext formsize100" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtBuyDate\')}',dateFmt:'yyyy-MM-dd'})"
                        valid="required" errmsg="购买时间不能为空！"/>
                </td>
                <th width="16%" height="30" align="right">
                    折&nbsp;旧&nbsp;费：
                </th>
                <td width="34%" bgcolor="#E3F1FC">
                    <asp:TextBox  id="txtCost" CssClass="inputtext formsize100"  runat="server" valid="isMoney" errmsg="请输入正确的金额！"/>
                </td>
            </tr>
            <tr class="odd">
                <th width="15%" height="30" align="right">
                    备注：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <textarea rows="5" cols="60" name="txtRemark" id="txtRemark" runat="server" maxlength="1000"/>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="center" colspan="10">
                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0);" hidefocus="true"id="btnSave" style='visibility:<%=IsSaveGrant?"visible":"hidden" %>'><s class="baochun"></s>保 存</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <script type="text/javascript">
        var PageJsData = {
            CloseForm: function() {
                parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
            },
            Form: null,
            FormCheck: function() {
                this.Form = $("#btnSave").closest("form").get(0)
                FV_onBlur.initValid(this.Form);
                return ValiDatorForm.validator(this.Form, "parent");
            },
            Save: function() {
                var that = this;
                if (that.FormCheck()) {
                    $("#btnSave").unbind("click").addClass("alertbox-btn_a_active").html("<s class=\"baochun\"></s> 提交中...");
                    var url = "/ManageCenter/AssetsAdd.aspx?";
                    url += $.param({
                        doType: '<%=Request.QueryString["doType"] %>',
                        id: '<%=Request.QueryString["id"] %>',
                        save: "save"
                    });
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: url,
                        data: $(that.Form).serialize().replace(),
                        dataType: "json",
                        success: function(result) {
                            if (result.result == 1) {
                                parent.tableToolbar._showMsg(result.msg, function() {
                                    parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
                                    parent.window.document.getElementById("btnSubmit").click();
                                });

                            }
                            else {
                                parent.tableToolbar._showMsg(result.msg, function() {
                                    PageJsData.BindBtn();
                                });
                            }
                        },
                        error: function() {
                            parent.tableToolbar._showMsg(tableToolbar.errorMsg, function() {
                                PageJsData.BindBtn();
                            });
                        }
                    });
                }
            },
            BindBtn: function() {
                $("#btnSave").click(function() {
                    PageJsData.Save();
                    return false;
                })
                $("#btnSave").attr("class", "").html("<s class=\"baochun\"></s>保 存");
            }
        }
        $(function() {
            PageJsData.BindBtn();

        })
    </script>
</body>
</html>
