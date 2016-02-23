<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainPlanAdd.aspx.cs" Inherits="Web.ManageCenter.TrainPlanAdd" validateRequest="false" %>
<%@ Register TagPrefix="uc2" TagName="UploadControl" Src="~/UserControl/UploadControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserSelect" Src="~/UserControl/SellsSelect.ascx" %>
<%@ Register TagPrefix="uc3" TagName="DeptSelect" Src="~/UserControl/SelectSection.ascx" %>
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
    <script src="/Js/table-toolbar.js" type="text/javascript"> </script>
    <script src="/Js/ValiDatorForm.js" type="text/javascript"> </script>
    <script src="/Js/jquery.boxy.js" type="text/javascript"> </script>
    <script src="/Js/jquery.blockUI.js" type="text/javascript"> </script>
    <script type="text/javascript" src="/JS/datepicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="760" cellspacing="1" cellpadding="0" border="0" align="center" style="margin-top: 20px;">
        <tbody>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    <font color="#FF0000">*</font>计划标题：
                </th>
                <td height="30" bgcolor="#E3F1FC" colspan="3">
                    <input type="text" size="20" id="txtPlanTitle" class="inputtext formsize100" name="txtPlanTitle" runat="server" valid="required" errmsg="计划标题不能为空！" maxlength="255"/>
                </td>
            </tr>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    <font color="#FF0000">*</font>计划内容：
                </th>
                <td height="30" bgcolor="#E3F1FC" class="pandl4" colspan="3">
                    <input type="text" id="txtPlanContent" name="txtPlanContent" class="inputtext formsize600" runat="server" valid="required" errmsg="计划内容不能为空！"/>
                </td>
            </tr>
            <tr class="odd">
                <th width="14%" height="30" align="right">
                    附件上传：
                </th>
                <td width="86%" bgcolor="#E3F1FC" colspan="3">
                    <uc2:UploadControl runat="server" ID="SingleFileUpload1" IsUploadSelf="true"/>
                    <asp:Label ID="lblFile" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    <font color="#FF0000">*</font>发送对象：
                </th>
                <td height="30" bgcolor="#E3F1FC" class="pandl4" colspan="3">
                    <input type="checkbox" value="0" name="chkAll" id="chkAll" runat="server"/>全部
                    <input type="checkbox" value="1" name="chkDept" id="chkDept" runat="server" onclick="PageJsData.IsDeptChecked(this)"/>
                    指定部门<uc3:DeptSelect runat="server" ID="ZhiDingBuMenSel" />
                    <input type="checkbox" value="2" id="chkStaff" name="chk" runat="server" onclick="PageJsData.IsStaffChecked(this)"/>
                    指定人员<uc1:UserSelect runat="server" ID="ZhiDingRenYuanSel" />
                </td>
            </tr>
            <tr class="odd">
                <th width="17%" height="30" align="right">
                    发布人：
                </th>
                <td width="32%" bgcolor="#E3F1FC">
                    <uc1:UserSelect runat="server" ID="FaBuRenSel" />
                </td>
                <th width="17%" height="30" align="right">
                    发布时间：
                </th>
                <td width="34%" bgcolor="#E3F1FC">
                    <input type="text" size="20" id="txtFaBuDate" class="inputtext formsize80" name="txtFaBuDate" runat="server" onfocus="WdatePicker()"/>
                </td>
            </tr>
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="center" colspan="10">
                    <table cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a id="btnSave" href="javascript:void(0);" style='visibility:<%=this.IsSaveGrant?"visible":"hidden" %>'>保存</a>
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
            Query: {/*URL参数对象*/
                doType: '<%=Request.QueryString["doType"] %>'
            },
            //删除已上传合作协议附件
            delLatestAttach: function() {
                $("#spanLatestAttach").remove();
            },
        	CreatePlanEdit: function() {
        		//创建行程编辑器
                KEditer.init('<%=txtPlanContent.ClientID %>', {resizeMode: 0, items: keSimple, height: "300px", width: "580px"});
            },
        	IsDeptChecked: function(obj) {
                if (!obj.checked) {
                    $("#<%=chkDept.ClientID %>").attr("checked", "");
                    $("#<%=ZhiDingBuMenSel.SelectNameClient %>").removeAttr("valid");
                    $("#<%=ZhiDingBuMenSel.SelectNameClient %>").removeAttr("value");
                    $("#<%=ZhiDingBuMenSel.SelectIDClient %>").removeAttr("value");
                    $("#spanZhiDingBuMenSel").css("display", "none");
                }
                else {
                    $("#spanZhiDingBuMenSel").css("display", "inline");
                    $("#<%=this.ZhiDingBuMenSel.SelectNameClient %>").attr({ valid: "required", errmsg: "指定部门不能为空！" });
                }
            },
        	IsStaffChecked: function(obj) {
                if (!obj.checked) {
                    $("#<%=chkStaff.ClientID %>").attr("checked", "");
                    $("#<%=ZhiDingRenYuanSel.SellsNameClient %>").removeAttr("valid");
                    $("#<%=ZhiDingRenYuanSel.SellsNameClient %>").removeAttr("value");
                    $("#<%=ZhiDingRenYuanSel.SellsIDClient %>").removeAttr("value");
                    $("#spanZhiDingRenYuanSel").css("display", "none");
                }
                else {
                    $("#spanZhiDingRenYuanSel").css("display", "inline");
                    $("#<%=this.ZhiDingRenYuanSel.SellsNameClient %>").attr({ valid: "required", errmsg: "指定人员不能为空！" });
                }
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
                    var url = "/ManageCenter/TrainPlanAdd.aspx?";
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
                                    parent.document.location.reload();
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
        	//部门选择初始化
            if ($("#<%=this.chkDept.ClientID %>").attr("checked")) {
                $("#spanZhiDingBuMenSel").css("display", "inline");
                $("#<%=this.ZhiDingBuMenSel.SelectNameClient %>").attr({ valid: "required", errmsg: "指定部门不能为空！" });
            }
            else {
                $("#spanZhiDingBuMenSel").css("display", "none");
                $("#<%=ZhiDingBuMenSel.SelectNameClient %>").removeAttr("valid");
            }
        	
        	//人员选择初始化
        	if ($("#<%=this.chkStaff.ClientID %>").attr("checked")) {
                $("#spanZhiDingRenYuanSel").css("display", "inline");
                $("#<%=this.ZhiDingRenYuanSel.SellsNameClient %>").attr({ valid: "required", errmsg: "指定人员不能为空！" });
            }
            else  {
                $("#spanZhiDingRenYuanSel").css("display", "none");
                $("#<%=ZhiDingRenYuanSel.SellsNameClient %>").removeAttr("valid");
            }
            PageJsData.BindBtn();
        	PageJsData.CreatePlanEdit();
        });
    </script>
</body>
</html>
