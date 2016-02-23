<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConferenceAdd.aspx.cs"
    Inherits="Web.ManageCenter.ConferenceAdd" %>
<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="Seller" TagPrefix="Uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>

    <script src="/Js/table-toolbar.js" type="text/javascript"></script>

    <script src="/Js/jquery.boxy.js" type="text/javascript"></script>

    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>
    <style type="text/css">  	
        #HrSelect1_txtSelectName{ width:550px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="650" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
        <tbody>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    会议编号：
                </th>
                <td width="86%" bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" ID="txtNum" valid="required" class="inputtext formsize120" errmsg="会议编号不能为空！" MaxLength="100"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hidId" />
                </td>
            </tr>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    会议主题：
                </th>
                <td width="86%" bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" ID="txtTitle" valid="required" class="inputtext formsize600" Width="300px" errmsg="会议主题不能为空！" MaxLength="250"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    参会人员：
                </th>
                <td width="86%" bgcolor="#E3F1FC">
                    <asp:textbox ID="Seller1" runat="server" CssClass="formsize180 inputtext" valid="required" errmsg="参会人员不能为空！" MaxLength="1000"></asp:textbox>
                </td>
            </tr>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    会议时间：
                </th>
                <td width="86%" bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" ID="txtStartTime" class="inputtext formsize100" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtEndTime\')}',dateFmt:'yyyy-MM-dd HH:mm'})"
                        valid="required" errmsg="会议开始时间不能为空！"></asp:TextBox>
                    <a href="javascript:document.getElementById('txtStartTime').focus();" class="timesicon">
                        开始时间</a> 至
                    <asp:TextBox runat="server" ID="txtEndTime" class="inputtext formsize100" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtStartTime\')}',dateFmt:'yyyy-MM-dd HH:mm'})"
                        valid="required" errmsg="会议结束时间不能为空！"></asp:TextBox>
                    <a href="javascript:document.getElementById('txtEndTime').focus();" class="timesicon">
                        结束时间</a>
                </td>
            </tr>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    会议地点：
                </th>
                <td width="86%" bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" ID="txtPlace" valid="required" errmsg="会议地点不能为空！" class="inputtext formsize140" MaxLength="250"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    备注：
                </th>
                <td width="86%" bgcolor="#E3F1FC">
                    <asp:TextBox runat="server" class="inputtext formsize600" TextMode="MultiLine" Width="400"
                        Height="93" ID="txtContent" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="center" colspan="8">
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
       <script src="/Js/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/Js/ValiDatorForm.js" type="text/javascript"></script>

    <style type="text/css">
        .errmsg
        {
            font-size: 12px;
            color: Red;
        }
    </style>

    <script type="text/javascript">
        var PageJsData = {
            CloseForm: function() {
                parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
            },
            CheckSelect: function(obj) {
                if ($(obj).val() == "-1") return false;
                else return true;
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
                    var url = "/ManageCenter/ConferenceAdd.aspx?";
                    url += $.param({
                        doType: '<%=Request.QueryString["doType"] %>',
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
