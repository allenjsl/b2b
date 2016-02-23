<%@ Page Title="代订机票+酒店业务确认单" Language="C#" MasterPageFile="~/MasterPage/Print.Master"
    AutoEventWireup="true" CodeBehind="RoutineTicketHotel.aspx.cs" Inherits="Web.PrintPage.RoutineTicketHotel"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">
                    <asp:Literal runat="server" ID="ltrCompanyName"></asp:Literal><asp:Literal runat="server" ID="ltrYeWuLeiXing"></asp:Literal></b>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                (TO)：<asp:Literal runat="server" ID="ltrBuyCompanyName"></asp:Literal>
            </td>
            <td align="left">
                自(From)：<asp:Literal runat="server" ID="ltrCompanyName1"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                (Fax)：<asp:Literal runat="server" ID="ltrBuyCompanyFax"></asp:Literal>
            </td>
            <td align="left">
                传真(Fax)：<asp:Literal runat="server" ID="ltrCompanyFax"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                收件人：<asp:Literal runat="server" ID="ltrBuyOperator"></asp:Literal>
            </td>
            <td align="left">
                发件人：<asp:Literal runat="server" ID="ltrCompanyContact"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                去程日期：<asp:Literal runat="server" ID="ltrQuDate"></asp:Literal>
            </td>
            <td align="left">
                <asp:Literal runat="server" ID="ltrQuAirAndTime"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                回程日期：<asp:Literal runat="server" ID="ltrHuiDate"></asp:Literal>
            </td>
            <td align="left">
                <asp:Literal runat="server" ID="ltrHuiAirAndTime"></asp:Literal>
            </td>
        </tr>
    </table>
    
    <asp:PlaceHolder runat="server" ID="phHangDuan" Visible="false">
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <td style="border: 0px">
                中间航段信息
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <th align="center" width="30">
                序号
            </th>
            <th width="80" align="center">
                日期
            </th>
            <th width="80" align="center">
                交通
            </th>
            <th width="140" align="center">
                班次
            </th>
            <th width="120" align="center">
                出发地
            </th>
            <th width="120" align="center">
                目的地
            </th>
            <th align="center">
                备注
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptHangDuan">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Container.ItemIndex + 1%>
                    </td>
                    <td align="center">
                        <%# Eval("RiQi","{0:yyyy-MM-dd}")%>
                    </td>
                    <td align="center">
                        <%#Eval("JiaoTongName")%>
                    </td>
                    <td align="center">
                        <%# Eval("BanCi")%>
                    </td>
                    <td align="center">
                        <%#Eval("ChuFaShengFenName") %>-<%#Eval("ChuFaChengShiName") %>
                    </td>
                    <td align="center">
                        <%#Eval("MuDiDiShengFenName") %>-<%#Eval("MuDiDiChengShiName") %>
                    </td>
                    <td align="center">
                        <%# Eval("BeiZhu")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </asp:PlaceHolder>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <td style="border: 0px">
                游客信息
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <th align="center" width="40">
                序号
            </th>
            <th width="100" align="center">
                姓名
            </th>
            <th width="60" align="center">
                类型
            </th>
            <th width="60" align="center">
                性别
            </th>
            <th width="80" align="center">
                证件
            </th>
            <th width="" align="center">
                证件号码
            </th>
            <th width="120" align="center">
                游客电话
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptCustomer">
            <ItemTemplate>
                <tr>
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
        <tr>
            <td colspan="7" align="center">
                请核对客人名单及证件号码，谢谢！
            </td>
        </tr>
    </table>
    <asp:PlaceHolder runat="server" ID="plnHotel">
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
                            <%# Eval("JiuDianname")%>
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
                            <%# Eval("Jianye")%>
                        </td>
                        <td align="center">
                            <%# Eval("QuFangFangShi")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:PlaceHolder>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                <strong>价格明细：</strong><asp:Literal runat="server" ID="ltrJiaGeMingXi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td  align="left">
                <strong>结算金额：</strong><asp:Literal runat="server" ID="ltrZongJinE"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>价格备注：</strong><asp:Literal runat="server" ID="ltrJiaGeRemark"></asp:Literal>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="ckbRemark" id="ckbRemark" />
                <label for="ckbRemark">特殊要求说明</label>
            </th>
        </tr>
        <tr data-class="trRemark">
            <td>
                <asp:Literal runat="server" ID="ltrRemark"></asp:Literal>&nbsp;
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
            <td width="50%" height="150" align="center">
                组团社盖章
            </td>
            <td width="50%" align="center">
                <div id="divImgCachet">
                    签章 <asp:Literal runat="server" ID="ltrIssueTime"></asp:Literal>
                </div>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        var RoutineTicketHotel = {
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
            RoutineTicketHotel.BindClickByCheckBox("Remark");

            //银行账号打印处理
            $(".i_yinhangzhanghao").find("input[type='checkbox']").attr("checked", false);
            var _yinHangZhangHaoCount = $(".i_yinhangzhanghao").find("tr").length;
            for (var i = 0; i < _yinHangZhangHaoCount; i++) {
                $("#tr_yinhangzhanghao_" + i).addClass("unprint");
                RoutineTicketHotel.bindChkClick("#chk_yinhangzhanghao_" + i, "#tr_yinhangzhanghao_" + i);
            }
        });
    </script>

</asp:Content>
