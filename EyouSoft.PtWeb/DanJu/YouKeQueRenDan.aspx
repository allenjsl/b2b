<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YouKeQueRenDan.aspx.cs"
    Inherits="EyouSoft.PtWeb.DanJu.YouKeQueRenDan" Title="游客确认单" MasterPageFile="~/MP/DanJu.Master"
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
                    <asp:Literal runat="server" ID="ltrZxsName"></asp:Literal>游客确认单</b>
            </td>
        </tr>
    </table>
    
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
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
                (Fax)：<asp:Literal runat="server" ID="ltrKeHuLxrFax"></asp:Literal>
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
        <tr>
            <td align="left">
                人数：<asp:Literal runat="server" ID="ltrPeopleNum"></asp:Literal>
            </td>
            <td align="left">
                线路名称：<asp:Literal runat="server" ID="ltrRouteName"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                集合时间：<asp:Literal runat="server" ID="ltrJiHeTime"></asp:Literal>
            </td>
            <td align="left">
                集合地点：<asp:Literal runat="server" ID="ltrJiHeAddress"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                送团信息：<asp:Literal runat="server" ID="ltrSendTour"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                接团方式：<asp:Literal runat="server" ID="ltrJieTuanFangShi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                结算明细：<asp:Literal runat="server" ID="ltrJieSuanMingXi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                结算金额：<asp:Literal runat="server" ID="ltrZongJinE"></asp:Literal>
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
    
    <asp:PlaceHolder runat="server" ID="phJiuDianAnPai" Visible="false">
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
            <asp:Repeater runat="server" ID="rptJiuDianAnPai">
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
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="chkJGBZ" id="chkJGBZ" />
                <label for="chkJGBZ">
                    价格备注</label>
            </th>
        </tr>
        <tr class="i_JGBZ">
            <td>
                <asp:Literal runat="server" ID="ltrJiaGeBeiZhu"></asp:Literal>&nbsp;
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="chkTSYQSM" id="chkTSYQSM" />
                <label for="chkTSYQSM">
                    特殊要求说明</label>
            </th>
        </tr>
        <tr class="i_TSYQSM">
            <td>
                <asp:Literal runat="server" ID="ltrRemark"></asp:Literal>&nbsp;
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th colspan="2" align="left">
                <input type="checkbox" name="ckbXCAP" id="ckbXCAP" />
                <label for="ckbXCAP">
                    行程安排</label>
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptXCAP">
            <ItemTemplate>
                <tr data-class="trXCAP">
                    <th width="20px">
                        第<br />
                        <%# Eval("Days") %><br />
                        天
                    </th>
                    <td>
                        <%# Eval("Content")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="ckbFWBZ" id="ckbFWBZ" />
                <label for="ckbFWBZ">
                    服务标准</label>
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="phJiaoTongBiaoZhun">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">交通标准：</strong><asp:Literal runat="server" ID="ltrJTBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phZhuSuBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">住宿标准：</strong><asp:Literal runat="server" ID="ltrZSBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phCanYinBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">餐饮标准：</strong><asp:Literal runat="server" ID="ltrCYBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phJingDianBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">景点标准：</strong><asp:Literal runat="server" ID="ltrJDBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phDaoYouFuWu" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">导游服务：</strong><asp:Literal runat="server" ID="ltrDYFW"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phGouWuShuoMing" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">购物说明：</strong><asp:Literal runat="server" ID="ltrGWSM"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phErTongBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">儿童标准：</strong><asp:Literal runat="server" ID="ltrETBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phBaoXianShuoMing" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">保险说明：</strong><asp:Literal runat="server" ID="ltrBXSM"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phZiFeiTuiJian" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">自费推荐：</strong><asp:Literal runat="server" ID="ltrZFTJ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phWenXinTiShi" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">温馨提示：</strong><asp:Literal runat="server" ID="ltrWXTX"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="chkBMXZ" id="chkBMXZ" />
                <label for="chkBMXZ">
                    报名须知</label>
            </th>
        </tr>
        <tr class="i_BMXZ">
            <td>
                <asp:Literal runat="server" ID="ltrBMXZ"></asp:Literal>&nbsp;
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
                    签章
                    <asp:Literal runat="server" ID="ltrIssueTime"></asp:Literal>
                </div>
            </td>
        </tr>
    </table>
    

    <script type="text/javascript">
        var iPage = {
            bindClickByCheckBox: function(idhz) {
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
                    }
                    else {
                        _$chkTr.addClass("unprint");
                    }
                });
            }
        }

        $(document).ready(function() {
            $("#divContent").find("input[type='checkbox']").attr("checked", true);

            iPage.bindClickByCheckBox("XCAP");
            iPage.bindClickByCheckBox("FWBZ");

            PrintMaster.bindChkClick("#chkTSYQSM", "tr.i_TSYQSM");
            PrintMaster.bindChkClick("#chkBMXZ", "tr.i_BMXZ")
            PrintMaster.bindChkClick("#chkJGBZ", "tr.i_JGBZ");
            
            //银行账号打印处理
            $(".i_yinhangzhanghao").find("input[type='checkbox']").attr("checked", false);
            var _yinHangZhangHaoCount = $(".i_yinhangzhanghao").find("tr").length;
            for (var i = 0; i < _yinHangZhangHaoCount; i++) {
                $("#tr_yinhangzhanghao_" + i).addClass("unprint");
                iPage.bindChkClick("#chk_yinhangzhanghao_" + i, "#tr_yinhangzhanghao_" + i);
            }

            $("strong[data-class='next_p_replace_span']").next("p").each(function() {
                $(this).replaceWith("<span>" + $(this).html() + "</span>");
            });
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
