<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiuDianQueRenDan.aspx.cs"
    Inherits="EyouSoft.PtWeb.DanJu.JiuDianQueRenDan" Title="代订酒店业务确认单" MasterPageFile="~/MP/DanJu.Master"
    ValidateRequest="false" %>

<asp:Content ContentPlaceHolderID="PageYeMei" runat="server" ID="PageYeMei1">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="70" align="center">
                <asp:Literal runat="server" ID="ltrYeiMei"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="PageMain1" ContentPlaceHolderID="PageMain" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">
                    <asp:Literal runat="server" ID="ltrZxsName"></asp:Literal>
                    代订酒店业务确认单</b>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                (TO)：<asp:Literal runat="server" ID="ltrKeHuName"></asp:Literal>
            </td>
            <td align="left">
                自(From)：<asp:Literal runat="server" ID="ltrZxsName1"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                传真(Fax)：<asp:Literal runat="server" ID="ltrKeHuLxrFax"></asp:Literal>
            </td>
            <td align="left">
                传真(Fax)：<asp:Literal runat="server" ID="ltrZxsFaJianRenFax"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                收件人：<asp:Literal runat="server" ID="ltrKeHuLxrName"></asp:Literal>
            </td>
            <td align="left">
                发件人：<asp:Literal runat="server" ID="ltrZxsFaJianRenName"></asp:Literal>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <th align="left" colspan="7">
                <input type="checkbox" name="chkYouKeMingDan" id="chkYouKeMingDan" />
                <label for="chkYouKeMingDan">
                    游客名单</label>
            </th>
        </tr>
        <tr class="i_tr_youkemingdan">
            <th align="center" width="40" style="background: none;">
                序号
            </th>
            <th width="100" align="center" style="background: none;">
                姓名
            </th>
            <th width="60" align="center" style="background: none;">
                类型
            </th>
            <th width="60" align="center" style="background: none;">
                性别
            </th>
            <th width="80" align="center" style="background: none;">
                证件
            </th>
            <th width="" align="center" style="background: none;">
                证件号码
            </th>
            <th width="120" align="center" style="background: none;">
                游客电话
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptCustomer">
            <ItemTemplate>
                <tr class="i_tr_youkemingdan">
                    <td align="center">
                        <%#Container.ItemIndex + 1%>
                    </td>
                    <td align="center">
                        <%# Eval("TravellerName")%>
                    </td>
                    <td align="center">
                        <%#Eval("TravellerType")%>
                    </td>
                    <td align="center">
                        <%# Eval("Sex")%>
                    </td>
                    <td align="center">
                        <%#Eval("CardType")%>
                    </td>
                    <td align="center">
                        <%# Eval("CardNumber")%>
                    </td>
                    <td align="center">
                        <%# Eval("Contact")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr class="i_tr_youkemingdan">
            <td colspan="7" align="center">
                请核对客人名单及证件号码，谢谢！
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <th align="center">
                预订酒店
            </th>
            <th align="center">
                入住时间
            </th>
            <th align="center">
                退房时间
            </th>
            <th align="center">
                房型
            </th>
            <th align="center">
                间夜
            </th>
            <th align="center">
                备注
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptHotel">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%# Eval("JiuDianName")%>
                    </td>
                    <td align="center">
                        <%# Eval("RuZhuTime")%>
                    </td>
                    <td align="center">
                        <%# Eval("TuiFangTime")%>
                    </td>
                    <td align="center">
                        <%# Eval("FangXing")%>
                    </td>
                    <td align="center">
                        <%# Eval("JianYe")%>
                    </td>
                    <td align="center">
                        <%# Eval("QuFangFangShi")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                <strong>价格明细：</strong><asp:Literal runat="server" ID="ltrJiaGeMinXi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>结算金额：</strong><asp:Literal runat="server" ID="ltrZongJinE"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>价格备注：</strong><asp:Literal runat="server" ID="ltrJiaGeBeiZhu"></asp:Literal>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="ckbBZ" id="ckbBZ" />
                <label for="ckbBZ">
                    特殊要求说明</label>
            </th>
        </tr>
        <tr data-class="trBZ">
            <td>
                <asp:Literal runat="server" ID="ltrRemark"></asp:Literal>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list i_yinhangzhanghao">
        <tr>
            <th width="47" style="text-align: center" class="unprint">
                &nbsp;
            </th>
            <th width="200" align="center">
                开户行
            </th>
            <th width="92" align="center">
                户名
            </th>
            <th width="200" align="center">
                卡号
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptBank">
            <ItemTemplate>
                <tr id="tr_yinhangzhanghao_<%#Container.ItemIndex %>">
                    <td style="text-align: center;" class="unprint">
                        <input type="checkbox" id="chk_yinhangzhanghao_<%#Container.ItemIndex %>" />
                    </td>
                    <td align="center">
                        <%# Eval("BankName")%>
                    </td>
                    <td align="center">
                        <%# Eval("AccountName")%>
                    </td>
                    <td align="center">
                        <%# Eval("BankNo")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" height="150px" align="center">
                组团社盖章
            </td>
            <td width="50%" align="center" height="150px">
                <div id="divImgCachet">
                    签章
                    <asp:Literal runat="server" ID="ltrIssueTime"></asp:Literal>
                </div>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        var ScheduleHotel = {
            BindClickByCheckBox: function(idhz) {
                $("#ckb" + idhz).bind("click", function() {
                    if ($(this).attr("checked")) {
                        $("tr[data-class='tr" + idhz + "']").show();
                    }
                    else {
                        $("tr[data-class='tr" + idhz + "']").hide();
                    }
                });
            },
            bindChkClick: function(chkExpr, shExpr) {
                $(chkExpr).bind("click", function() {
                    var _$chkTr = $(chkExpr).closest("tr");
                    if ($(this).attr("checked")) {
                        _$chkTr.removeClass("unprint")
                        //$(shExpr).show();
                    }
                    else {
                        _$chkTr.addClass("unprint");
                        //$(shExpr).hide();
                    }
                });
            }
        }

        $(document).ready(function() {
            //divContent    为母版页div容器
            $("#divContent").find("input[type='checkbox']").attr("checked", true);

            ScheduleHotel.BindClickByCheckBox("BZ");

            PrintMaster.bindChkClick("#chkYouKeMingDan", "tr.i_tr_youkemingdan");

            //银行账号打印处理
            $(".i_yinhangzhanghao").find("input[type='checkbox']").attr("checked", false);
            var _yinHangZhangHaoCount = $(".i_yinhangzhanghao").find("tr").length;
            for (var i = 0; i < _yinHangZhangHaoCount; i++) {
                $("#tr_yinhangzhanghao_" + i).addClass("unprint");
                ScheduleHotel.bindChkClick("#chk_yinhangzhanghao_" + i, "#tr_yinhangzhanghao_" + i);
            }
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageYeJiao" runat="server" ID="PageYeJiao1">
    <table border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 20px;">
        <tr>
            <td align="center">
                <asp:Literal runat="server" ID="ltrYeJiao"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
