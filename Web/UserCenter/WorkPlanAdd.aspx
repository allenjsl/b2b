<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front.Master"
    CodeBehind="WorkPlanAdd.aspx.cs" Inherits="Web.UserCenter.WorkPlanAdd" ValidateRequest="false"
    Title="工作计划-个人中心" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- InstanceBeginEditable name="EditRegion3" -->
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">个人中心</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                        所在位置>> <a href="#">个人中心</a>>> 工作计划
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="2" bgcolor="#000000">
                    </td>
                </tr>
            </table>
        </div>
        <div class="lineCategorybox" style="height: 50px;">
            <table border="0" cellpadding="0" cellspacing="0" class="grzxnav">
                <tr>
                    <td width="108" align="center">
                        <a href="/UserCenter/WorkReport.aspx">工作汇报</a>
                    </td>
                    <td width="108" align="center" class="grzxnav-on">
                        <a href="/UserCenter/WorkPlan.aspx">工作计划</a>
                    </td>
                    <td width="108" align="center">
                        <a href="/UserCenter/WorkCommun.aspx">工作交流</a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <form id="frm" runat="server">
            <asp:HiddenField ID="hidId" runat="server" />
            <table width="780" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#BDDCF4">
                <tr>
                    <th colspan="3" align="center" bgcolor="#BDDCF4">
                        <asp:Literal ID="ltPlanTitle" runat="server"></asp:Literal>
                    </th>
                </tr>
                <tr>
                    <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                        <strong>编号：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox ID="txtPlanNo" runat="server" CssClass="inputtext" Width="120"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                        <strong>提交人：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:Literal runat="server" ID="ltName"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                        <strong>接收人：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <uc1:SellsSelect runat="server" ID="SellsSelect1" />
                    </td>
                </tr>
                <tr>
                    <td width="16%" height="35" align="right" bgcolor="#e3f1fc">
                        <strong>计划标题：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="inputtext" Width="120"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>计划内容：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>附件上传</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <uc1:UploadControl runat="server" ID="UploadControl1" />
                        <asp:Label ID="lblFilePath" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>计划说明：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="inputarea" Width="600" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>预计完成时间：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <input id="txtExpectedDate" name="txtExpectedDate" type="text" class="inputtext"
                            style="width: 120px;" runat="server" onfocus="WdatePicker()" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>实际完成时间：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <input id="txtActualDate" name="txtActualDate" type="text" class="inputtext" style="width: 120px;"
                            runat="server" onfocus="WdatePicker()" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>状态：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:RadioButtonList runat="server" ID="rbStatus" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>填写时间：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:Literal runat="server" ID="ltCreateTime"></asp:Literal>
                    </td>
                </tr>
                <asp:PlaceHolder runat="server" ID="phCheck" Visible="false">
                    <tr>
                        <td height="35" align="right" bgcolor="#e3f1fc">
                            <strong>审核人评语：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <asp:TextBox ID="txtManagerComment" runat="server" CssClass="inputarea" Width="600"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phCheckMan" Visible="false">
                    <tr>
                        <td height="35" align="right" bgcolor="#e3f1fc">
                            <strong>审核人：</strong>
                        </td>
                        <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                            <asp:Literal ID="ltCheckMan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td height="30" colspan="3" align="center">
                        <table id="tb" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btnSave" runat="server" visible="false">添加</a>
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btnUpdate" runat="server" visible="false">修改</a>
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:;" id="btnCheck" runat="server" visible="false">审核</a>
                                </td>
                                <td width="76" height="40" align="center" class="tjbtn02">
                                    <a href="/UserCenter/WorkPlan.aspx">返回</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <!-- InstanceEndEditable -->
    <div class="clearboth">
    </div>
    <!--mainbodyOut end-->
    <!-- InstanceEndEditable -->

    <script type="text/javascript">
        var Plan = {
            CreatePlanEdit: function() {
                //创建行程编辑器
            KEditer.init('<%=txtContent.ClientID %>', { resizeMode: 0, items: keSimple, height: "35px", width: "670px" });
            },
            Add: function() {
                if (Plan.IsValidate()) {
                    $("#<%=this.btnSave.ClientID %>").html("提交中...");
                    Plan.UnBind();
                    Plan.DoAjax("Save");
                }
            },
            Update: function() {
                if (Plan.IsValidate()) {
                    $("#<%=this.btnUpdate.ClientID %>").html("提交中...");
                    Plan.UnBind();
                    Plan.DoAjax("Update");
                }
            },
            Check: function() {
                var comment = $("#<%=this.txtManagerComment.ClientID %>").val();
                if (comment == "") {
                    tableToolbar._showMsg("评语不能为空！");
                    return;
                }
                else {
                    $("#<%=this.btnCheck.ClientID %>").html("提交中...");
                    Plan.UnBind();
                    Plan.DoAjax("Check");
                }
            },
            UnBind: function() {
                $("#<%=this.btnSave.ClientID %>").unbind("click");
                $("#<%=this.btnUpdate.ClientID %>").unbind("click");
                $("#<%=this.btnCheck.ClientID %>").unbind("click");

            },
            Bind: function() {
                var _selfs = $("#<%=this.btnSave.ClientID %>");
                _selfs.html("保存");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Plan.Add();
                    return false;
                });

                var _selfs = $("#<%=this.btnUpdate.ClientID %>");
                _selfs.html("修改");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Plan.Update();
                    return false;
                });

                var _selfs = $("#<%=this.btnCheck.ClientID %>");
                _selfs.html("审核");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Plan.Check();
                    return false;
                });
            },
            IsValidate: function() {
                var planNo = $("#<%=this.txtPlanNo.ClientID %>").val();
                if (planNo == "") {
                    tableToolbar._showMsg("编号不能为空！");
                    return false;
                }
                var sellerIds = $("#<%=this.SellsSelect1.SellsIDClient %>").val();
                if (sellerIds == "") {
                    tableToolbar._showMsg("接收人不能为空！");
                    return false;
                }

                var title = $("#<%=this.txtTitle.ClientID %>").val();
                if (title == "") {
                    tableToolbar._showMsg("计划标题不能为空！");
                    return false;
                }

                var content = $("#<%=this.txtContent.ClientID %>").val();
                if (content == "") {
                    tableToolbar._showMsg("汇报内容不能为空！");
                    return false;
                }
                var remark = $("#<%=this.txtRemark.ClientID %>").val();
                if (remark == "") {
                    tableToolbar._showMsg("计划说明不能为空！");
                    return false;
                }
                var expectedDate = $("#<%=this.txtExpectedDate.ClientID %>").val();
                if (expectedDate == "") {
                    tableToolbar._showMsg("预计完成时间不能为空！");
                    return false;
                }

                return true;
            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DoAjax: function(type) {
                // alert(type);
                $.newAjax({
                    type: "post",
                    url: "/UserCenter/WorkPlanAdd.aspx?Type=" + type,
                    data: $("#<%=this.frm.ClientID %>").serialize(),
                    dataType: "json",
                    success: function(data) {
                        if (data.result == "1") {
                            tableToolbar._showMsg(data.msg, function() {
                                //window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                //window.parent.location.reload();
                                window.location.href = "/UserCenter/WorkPlan.aspx";
                            });
                        }
                        else {
                            tableToolbar._showMsg(data.msg);
                            Plan.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg("服务器忙！");
                        Plan.Bind();
                    }
                });
            }

        };


        $(function() {
            Plan.CreatePlanEdit();

            var td = $("#tb").find("tr:eq(0)").find("td").each(function() {
                if ($(this).find("a").length == 0) {
                    $(this).remove();
                }
            });

            $("#<%=this.btnSave.ClientID %>").click(function() {
                KEditer.sync();
                Plan.Add();
            });
            $("#<%=this.btnUpdate.ClientID %>").click(function() {
                KEditer.sync();
                Plan.Update();
            });
            $("#<%=this.btnCheck.ClientID %>").click(function() {
                Plan.Check();
            });
        });
    </script>

</asp:Content>
