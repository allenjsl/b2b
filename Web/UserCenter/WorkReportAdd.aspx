<%@ Page Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="WorkReportAdd.aspx.cs" Inherits="Web.UserCenter.WorkReportAdd" ValidateRequest="false" Title="工作汇报-个人中心" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/kindeditor-4.1/kindeditor-min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- InstanceBeginEditable name="EditRegion3" -->
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td nowrap="nowrap" width="15%">
                            <span class="lineprotitle">个人中心</span>
                        </td>
                        <td style="padding: 0 10px 2px 0; color: #13509f;" align="right" nowrap="nowrap"
                            width="85%">
                             所在位置&gt;&gt; <a href="#">个人中心</a>&gt;&gt; 工作汇报
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" bgcolor="#000000" height="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="lineCategorybox" style="height: 50px;">
            <table class="grzxnav" border="0" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td width="108" align="center" class="grzxnav-on">
                            <a href="/UserCenter/WorkReport.aspx">工作汇报</a>
                        </td>
                        <td width="108" align="center">
                            <a href="/UserCenter/WorkPlan.aspx">工作计划</a>
                        </td>
                        <td width="108" align="center">
                            <a href="/UserCenter/WorkCommun.aspx">工作交流</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <form id="frm" runat="server">
            <asp:HiddenField ID="hidId" runat="server" />
            <table align="center" bgcolor="#BDDCF4" border="0" cellpadding="0" cellspacing="1"
                width="780">
                <tbody>
                    <tr>
                        <th colspan="3" align="center" bgcolor="#BDDCF4">
                            <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                        </th>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#e3f1fc" height="35" width="16%">
                            <strong>标题：</strong>
                        </td>
                        <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                            <asp:TextBox runat="server" ID="txtTitle" CssClass="inputtext" Width="120"></asp:TextBox>
                            <%--<input name="" size="50" type="text" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#e3f1fc" height="35">
                            <strong>汇报内容：</strong>
                        </td>
                        <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" style="height: 35px;
                            width: 650px;">
                            <span id="spanPlanContent" style="height: 35px; width: 650px;">
                                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="inputtext"></asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#e3f1fc" height="35">
                            <strong>附件上传</strong>
                        </td>
                        <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                            <uc1:UploadControl runat="server" ID="UploadControl1" />
                            <asp:Label runat="server" ID="lblFilePath"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#e3f1fc" height="35">
                            <strong>接收人：</strong>
                        </td>
                        <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                            <uc1:SellsSelect runat="server" ID="SellsSelect1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#e3f1fc" height="35">
                            <strong>汇报人</strong>
                        </td>
                        <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                            <asp:Literal runat="server" ID="ltReportMan"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#e3f1fc" height="35">
                            <strong>汇报时间：</strong>
                        </td>
                        <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                            <asp:Literal runat="server" ID="ltReportTime"></asp:Literal>
                        </td>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="phCheck" Visible="false">
                        <tr>
                            <td align="right" bgcolor="#e3f1fc" height="35">
                                <strong>评语：</strong>
                            </td>
                            <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="600" Height="45"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="phCheckPeople" Visible="false">
                        <tr>
                            <td align="right" bgcolor="#e3f1fc" height="35">
                                <strong>审核人：</strong>
                            </td>
                            <td colspan="2" class="pandl3" align="left" bgcolor="#FAFDFF" height="35">
                                <asp:Literal ID="ltPeople" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                    <tr>
                        <td colspan="3" align="center" height="30">
                            <table id="tb" align="center" border="0" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td class="tjbtn02" align="center" height="40" width="76">
                                            <a href="javascript:void(0);" id="btnSave" runat="server" visible="false">保存</a>
                                        </td>
                                        <td class="tjbtn02" align="center" height="40" width="76">
                                            <a href="javascript:void(0);" id="btnUpdate" runat="server" visible="false">修改</a>
                                        </td>
                                        <td class="tjbtn02" align="center" height="40" width="76">
                                            <a href="javascript:void(0);" id="btnCheck" runat="server" visible="false">审核</a>
                                        </td>
                                        <td class="tjbtn02" align="center" height="40" width="76">
                                            <a href="/UserCenter/WorkReport.aspx">返回</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
    <!-- InstanceEndEditable -->

    <script type="text/javascript">
    
        var Report = {
            CreatePlanEdit: function() {
                //创建行程编辑器
            KEditer.init('<%=txtContent.ClientID %>', { resizeMode: 0, items: keSimple, height: "35px", width: "670px" });
            },
            Add: function() {
                if (Report.IsValidate()) {
                    $("#<%=this.btnSave.ClientID %>").html("提交中...");
                    Report.UnBind();
                    Report.DoAjax("Save");
                }
            },
            Update: function() {
                if (Report.IsValidate()) {
                    $("#<%=this.btnUpdate.ClientID %>").html("提交中...");
                    Report.UnBind();
                    Report.DoAjax("Update");
                }
            },
            Check: function() {
                var comment = $("#<%=this.txtContent.ClientID %>").val();
                if (comment == "") {
                    tableToolbar._showMsg("评语不能为空！");
                    return;
                }
                else {
                    $("#<%=this.btnCheck.ClientID %>").html("提交中...");
                    Report.UnBind();
                    Report.DoAjax("Check");
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
                    Report.Add();
                    return false;
                });

                var _selfs = $("#<%=this.btnUpdate.ClientID %>");
                _selfs.html("修改");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Report.Update();
                    return false;
                });

                var _selfs = $("#<%=this.btnCheck.ClientID %>");
                _selfs.html("审核");
                _selfs.css("cursor", "pointer");
                _selfs.click(function() {
                    Report.Check();
                    return false;
                });
            },
            IsValidate: function() {
                var title = $("#<%=this.txtTitle.ClientID %>").val();
                if (title == "") {
                    tableToolbar._showMsg("标题不能为空！");
                    return false;
                }
                var content = $("#<%=this.txtContent.ClientID %>").val();
                if (content == "") {
                    tableToolbar._showMsg("汇报内容不能为空！");
                    return false;
                }
                var sellerIds = $("#<%=this.SellsSelect1.SellsIDClient %>").val();
                if (sellerIds == "") {
                    tableToolbar._showMsg("接收人不能为空！");
                    return false;
                }
                return true;

            },
            DelFile: function(obj) {
                $(obj).parent().remove();
            },
            DoAjax: function(type) {
                //alert(type);
                $.newAjax({
                    type: "post",
                    url: "/UserCenter/WorkReportAdd.aspx?Type=" + type,
                    data: $("#<%=this.frm.ClientID %>").serialize(),
                    dataType: "json",
                    success: function(data) {
                        if (data.result == "1") {
                            tableToolbar._showMsg(data.msg, function() {
                                //window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                //window.parent.location.reload();
                                window.location.href = "/UserCenter/WorkReport.aspx";
                            });
                        }
                        else {
                            tableToolbar._showMsg(data.msg);
                            Report.Bind();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg("服务器忙！");
                        Report.Bind();
                    }
                });
            }

        };


        $(function() {
            Report.CreatePlanEdit();

            var td = $("#tb").find("tr:eq(0)").find("td").each(function() {
                if ($(this).find("a").length == 0) {
                    $(this).remove();
                }

            });

            $("#<%=this.btnSave.ClientID %>").click(function() {
                KEditer.sync();
                Report.Add();
            });
            $("#<%=this.btnUpdate.ClientID %>").click(function() {
                KEditer.sync();
                Report.Update();
            });
            $("#<%=this.btnCheck.ClientID %>").click(function() {
                Report.Check();
            });
        });
    </script>

</asp:Content>
