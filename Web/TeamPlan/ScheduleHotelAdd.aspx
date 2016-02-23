<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="ScheduleHotelAdd.aspx.cs" Inherits="Web.TeamPlan.ScheduleHotelAdd"
    EnableEventValidation="false" %>

<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/CustomerRequiredControl.ascx" TagName="CustomerRequired"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/OrderCustomer.ascx" TagName="OrderCustomer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <div style="width: 99%; margin: 0px auto;margin-top:5px;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        <span class="fred">*</span>出团日期：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:TextBox ID="txtLeaveDate" name="txtLeaveDate" class="formsize80 inputtext" onfocus="WdatePicker()"
                            runat="server" errmsg="请选择出团日期！" valid="required"></asp:TextBox>
                        <a href="javascript:void(0);" class="timesicon" onclick="WdatePicker({onpicked:function(dp){$(this).prev().val(dp.cal.getDateStr())}})"></a>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        成人数：
                    </th>
                    <td width="400" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtAdultCount" CssClass="formsize50 inputtext" runat="server" valid="required|isPIntegers" errmsg="请填写成人数！|请填写正确的成人数！" data-renshu-txt="chengren"></asp:TextBox>
                    </td>
                    <th width="120" align="right">
                        儿童数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtChildCount" CssClass="formsize50 inputtext" runat="server" valid="isPIntegers" errmsg="请填写正确的儿童数！" data-renshu-txt="ertong"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>客户单位：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <uc1:KeHuXuanZe ID="txtKeHu" runat="server" DuiFangCaoZuoRenClientId="txtDuiFangCaoZuoRen" />
                    </td>
                    <th align="right">
                        <span class="fred">*</span>对方操作人：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtDuiFangCaoZuoRen" id="txtDuiFangCaoZuoRen" errmsg="请选择对方操作人" valid="required" class="inputselect" data-v="<%=DuiFangCaoZuoRenId %>">
                            <option value="">请选择客户单位</option>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>价格明细：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtPriceDesc" CssClass=" formsize260 inputtext" runat="server" errmsg="请填写价格明细!"
                            valid="required"></asp:TextBox>
                    </td>
                    <th align="right">
                        <span class="fred">*</span>总金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtTotalMoney" CssClass="formsize50 inputtext" runat="server" errmsg="请填写总金额!|请填写格式正确的总金额!"
                            valid="required|isMoney"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        价格备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtPriceRemark" TextMode="MultiLine" Height="70px" CssClass="formsize600 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        特殊要求说明：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtYaoqiuRemark" TextMode="MultiLine" Height="70px" CssClass="formsize600 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        操作备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtOperatorRemark" TextMode="MultiLine" Height="70px" CssClass="formsize600 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <uc1:OrderCustomer runat="server" ID="OrderCustomer1" />
    <uc1:CustomerRequired runat="server" ID="CustomerRequired1" />
    <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="left" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="100" height="40" align="center" class="tjbtn02">
                                        <asp:PlaceHolder runat="server" ID="plnSave"><a href="javascript:void(0);" id="a_AddHotelSave">
                                            保存</a> </asp:PlaceHolder>
                                        <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <input runat="server" type="hidden" name="hidOrderId" id="hidOrderId" />

    <script type="text/javascript">
        var ScheduleHotelAdd = {
            data: {
                dotype: '<%= EyouSoft.Common.Utils.GetQueryStringValue("dotype") %>',
                id: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                iframeId: '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>'
            },
            save: function() {
                var isC = ValiDatorForm.validator($("#a_AddHotelSave").closest("form").get(0), "alert");
                if (!isC) return false;

                $("#a_AddHotelSave").unbind("click");
                $("#a_AddHotelSave").html("正在提交");

                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/TeamPlan/ScheduleHotelAdd.aspx?save=1&" + $.param(ScheduleHotelAdd.data),
                    dataType: "json",
                    data: $("#a_AddHotelSave").closest("form").serialize(),
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() {
                                window.parent.Boxy.getIframeDialog('<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                                parent.location.href = parent.location.href;
                            });
                        } else {
                            tableToolbar._showMsg(ret.msg);
                            ScheduleHotelAdd.BindBtn();
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                        ScheduleHotelAdd.BindBtn();
                    }
                });
            },
            BindBtn: function() {
                $("#a_AddHotelSave").click(function() {
                    ScheduleHotelAdd.save();
                    return false;
                });
                $("#a_AddHotelSave").html("保存");
            }
        };

        $(document).ready(function() {
            ScheduleHotelAdd.BindBtn();
            $("#<%=txtKeHu.KeHuMingChengClientId %>,#<%=txtKeHu.KeHuIdClientId %>").attr("valid", "required").attr("errmsg", "请选择客户单位!");
        });
    </script>

    </form>
</asp:Content>
