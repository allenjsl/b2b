<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractAdd.aspx.cs" Inherits="Web.ManageCenter.ContractAdd" %>

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
                    员工编号：
                </th>
                <td width="35%" bgcolor="#E3F1FC">
                    <input type="text" size="20" id="txtStaffNo" valid="required" class="inputtext formsize80" errmsg="员工编号不能为空！" name="txtStaffNo" runat="server" maxlength="50"/>
                </td>
                <th width="16%" height="30" align="right">
                    姓名：
                </th>
                <td width="34%" bgcolor="#E3F1FC">
                    <input type="text" size="20" id="txtStaffName" valid="required" class="inputtext formsize80" errmsg="姓名不能为空！" name="txtStaffName" runat="server" maxlength="50"/>
                </td>
            </tr>
            <tr class="odd">
                <th width="15%" height="30" align="right">
                    签订时间：
                </th>
                <td width="35%" bgcolor="#E3F1FC">
                    <input type="text" size="9" id="txtBeginDate" class="inputtext formsize100" name="txtBeginDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtBeginDate\')}'})"/>
                </td>
                <th width="16%" height="30" align="right">
                    到期时间：
                </th>
                <td width="34%" bgcolor="#E3F1FC">
                    <input type="text" size="9" id="txtEndDate" class="inputtext formsize100" name="txtEndDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtEndDate\')}'})"/>
                </td>
            </tr>
            <tr class="odd">
                <th width="16%" height="30" align="right">
                    状态：
                </th>
                <td width="34%" bgcolor="#E3F1FC" colspan="3">
                    <select name="ddlState" id="ddlState" class="inputselect" runat="server">
                        <option selected="selected" value="0">未到期</option>
                        <option value="1">到期未处理</option>
                        <option value="2">到期已处理</option>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="15%" height="30" align="right">
                    备注：
                </th>
                <td bgcolor="#E3F1FC" colspan="3">
                    <asp:TextBox runat="server" class="inputtext formsize600" TextMode="MultiLine" Width="400" Height="93" ID="txtRemark" MaxLength="1000"></asp:TextBox>
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
                    var url = "/ManageCenter/ContractAdd.aspx?";
                    url += $.param({
                        doType: '<%=Request.QueryString["doType"] %>',
                        save: "save",
                    		id:'<%=Request.QueryString["id"] %>'
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
