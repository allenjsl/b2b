<%@ Page Title="编辑出纳登账信息" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master"
    AutoEventWireup="true" CodeBehind="DengZhangEdit.aspx.cs" Inherits="Web.Fin.DengZhangEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form runat="server" id="form1">
    <table width="99%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 0px auto; margin-top:5px;">
        <tbody>
            <tr class="odd">
                <th width="110" height="30" align="right">
                    <font class="xinghao">*</font>到款时间：
                </th>
                <td bgcolor="#E3F1FC">
                    <input runat="server" name="txtDaoKuanDate" type="text" id="txtDaoKuanDate" onfocus="WdatePicker()"
                        class="searchinput inputtext" valid="required" errmsg="请选择到款时间！" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <font class="xinghao">*</font>到款金额：
                </th>
                <td bgcolor="#E3F1FC">
                    <input runat="server" name="txtDaoKuanJinE" type="text" id="txtDaoKuanJinE" class="searchinput inputtext"
                        valid="required|isMoney" errmsg="请填写到款金额！|到款金额格式不正确！" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <font class="xinghao">*</font>到款银行：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:DropDownList runat="server" ID="ddlBank" valid="isNo" errmsg="请选择到款银行！" noValue="0">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <font class="xinghao">*</font>支付方式：
                </th>
                <td bgcolor="#E3F1FC">
                    <asp:DropDownList runat="server" ID="ddlPayType" valid="isNo" errmsg="请选择支付方式！" noValue="-1">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    备注：
                </th>
                <td bgcolor="#E3F1FC">
                    <textarea runat="server" name="txtRemark" id="txtRemark" class="searchinput inputtext"
                        style="width: 400px; height: 100px"></textarea>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2" align="center">
                    <table width="200" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:PlaceHolder runat="server" ID="plnSave"><a id="a_DengZhangEdit_Save" href="javascript:void(0);">
                                    保存</a></asp:PlaceHolder>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        var DengZhangEdit = {
            data: {
                doType: '<%= EyouSoft.Common.Utils.GetQueryStringValue("doType") %>',
                dzid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("dzid") %>',
                iframeId: '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>'
            },
            btnSaveClick: function() {
                var isC = ValiDatorForm.validator($("#a_DengZhangEdit_Save").closest("form").get(0), "alert");
                if (!isC) return false;

                $("#a_DengZhangEdit_Save").unbind("click");
                $("#a_DengZhangEdit_Save").html("正在提交");

                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/Fin/DengZhangEdit.aspx?save=1&" + $.param(DengZhangEdit.data),
                    dataType: "json",
                    data: $("#a_DengZhangEdit_Save").closest("form").serialize(),
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                                window.parent.Boxy.getIframeDialog('<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                parent.location.href = parent.location.href;
                            });
                        } else {
                            tableToolbar._showMsg(ret.msg);
                            DengZhangEdit.bindBtn();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        DengZhangEdit.bindBtn();
                    }
                });
            },
            bindBtn: function() {
                $("#a_DengZhangEdit_Save").click(function() {
                    DengZhangEdit.btnSaveClick();
                    return false;
                });

                $("#a_DengZhangEdit_Save").html("保存");
            }
        };

        $(document).ready(function() {
            DengZhangEdit.bindBtn();
        });
    </script>

    </form>
</asp:Content>
