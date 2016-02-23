<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RuleAdd.aspx.cs" Inherits="Web.ManageCenter.RuleAdd" validateRequest="false" %>
<%@ Register TagPrefix="uc2" TagName="UploadControl" Src="~/UserControl/UploadControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
        <link href="/css/boxy.css" rel="stylesheet" type="text/css" />
        <link href="/Css/swfupload/default.css" rel="stylesheet" type="text/css" />
    <script src="/Js/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

        <script type="text/javascript" src="/js/jquery-1.4.4.js"> </script>

        <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"> </script>

        <script src="/Js/swfupload/swfupload.js" type="text/javascript"> </script>

        <style type="text/css">
        	.errmsg
        	{
        		font-size: 12px;
        		color: Red;
        	}

        	.alertbox-outbox table .progressWrapper
        	{
        		overflow: hidden;
        		width: 300px;
        	}
        </style>
    </head>
    <body>
        <form id="form1" runat="server" method="post" enctype="multipart/form-data">
            <table width="650" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px auto;">
                <tbody>
                    <tr class="odd">
                        <th width="14%" height="30" align="right">
                            编号：
                        </th>
                        <td width="86%" bgcolor="#E3F1FC">
                            <asp:TextBox runat="server" ID="txtRuleId" CssClass="inputtext formsize180" valid="required" errmsg="编号不能为空！" MaxLength="250"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hidRuleId" />
                        </td>
                    </tr>
                    <tr class="odd">
                        <th width="14%" height="30" align="right">
                            制度标题：
                        </th>
                        <td width="86%" bgcolor="#E3F1FC">
                            <asp:TextBox runat="server" ID="txtRuleTitle" CssClass="inputtext formsize180" valid="required" errmsg="制度标题不能为空！" MaxLength="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="odd">
                        <th width="14%" height="30" align="right">
                            制度内容：
                        </th>
                        <td width="86%" bgcolor="#E3F1FC">
                            <span id="spanPlanContent" style="display: inline-block;">
                                <asp:TextBox ID="txtRuleContent" runat="server" TextMode="MultiLine" CssClass="inputtext formsize800" valid="required" errmsg="制度内容不能为空！"></asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    <tr class="odd">
                        <th width="14%" height="30" align="right">
                            附件上传：
                        </th>
                        <td width="86%" bgcolor="#E3F1FC">
                            <uc2:UploadControl runat="server" ID="SingleFileUpload1" IsUploadSelf="true"/>
                            <asp:Label runat="server" ID="lbFiles" CssClass="labelFiles"></asp:Label>
                        </td>
                    </tr>
                    <tr class="odd">
                        <td height="30" bgcolor="#E3F1FC" align="center" colspan="8">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="76" height="40" align="center" class="tjbtn02">
                                            <a href="javascript:void(0);" hidefocus="true" id="btnSave" style='visibility:<%=IsSaveGrant?"visible":"hidden" %>'><s class="baochun"></s>保 存</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </form>
        <script src="/Js/table-toolbar.js" type="text/javascript"> </script>

        <script src="/Js/ValiDatorForm.js" type="text/javascript"> </script>

        <script src="/Js/jquery.boxy.js" type="text/javascript"> </script>

        <script src="/Js/jquery.blockUI.js" type="text/javascript"> </script>

        <script type="text/javascript">
        var PageJsData = {
            Query: {/*URL参数对象*/
                doType: '<%=Request.QueryString["doType"] %>'
            },
            //删除已上传合作协议附件
            delLatestAttach: function() {
                $("#spanLatestAttach").remove();
            },
        	CreatePlanEdit: function() {
        		//创建行程编辑器
                KEditer.init('<%=txtRuleContent.ClientID %>', {resizeMode: 0, items: keSimple, height: "200px", width: "500px"
                });
            },
            DelFile: function(obj) {
                var self = $(obj);
                self.closest("span").hide();
                self.next(":hidden").val("");
            },
            Form: null,
            FormCheck: function() {
                this.Form = $("#btnSave").closest("form").get(0)
                FV_onBlur.initValid(this.Form);
                return ValiDatorForm.validator(this.Form, "parent");
            },
            Save: function() {
                var that = this;
            	KEditer.sync();
            	if (PageJsData.FormCheck()) {
                    $("#btnSave").unbind("click").addClass("alertbox-btn_a_active").html("<s class=\"baochun\"></s> 提交中...");
                    var url = "/ManageCenter/RuleAdd.aspx?";
                    url += $.param({
                        doType: PageJsData.Query.doType,
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
        	PageJsData.CreatePlanEdit();
        });
    </script>
    </body>
</html>