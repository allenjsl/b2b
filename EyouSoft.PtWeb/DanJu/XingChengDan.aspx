<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XingChengDan.aspx.cs" Inherits="EyouSoft.PtWeb.DanJu.XingChengDan"
    Title="行程单" MasterPageFile="~/MP/DanJu.Master" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MP/DanJu.Master" %>
<asp:Content ContentPlaceHolderID="PageYeMei" runat="server" ID="PageYeMei1">
    
    <asp:PlaceHolder runat="server" ID="phYeMei1" Visible="false">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td width="41%" rowspan="3" style="padding:11px 9px; height:91px;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouLogo"><%--<img src="/images/logo.gif" class="djtt_logo">--%></asp:Literal>
            </td>
            <td width="59%" align="center" class="p_title" style="text-align:left;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouMingCheng">金芒果商旅网</asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouDiZhi">&nbsp;</asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouDianHua">&nbsp;</asp:Literal>
            </td>
        </tr>
    </table>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder runat="server" ID="phYeMei2" Visible="false">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td align="center" class="p_title" style="text-align:left;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouMingCheng1">金芒果商旅网</asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left; line-height:22px;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouDiZhi1"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left; line-height: 22px;">
                <asp:Literal runat="server" ID="ltrDanJuTaiTouDianHua1"></asp:Literal>
            </td>
        </tr>
    </table>
    </asp:PlaceHolder>
    
</asp:Content>

<asp:Content ID="PageMain1" ContentPlaceHolderID="PageMain" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">
                    <asp:Literal runat="server" ID="ltrRouteName"></asp:Literal></b>
            </td>
        </tr>
    </table>
    
    <asp:PlaceHolder runat="server" ID="phJBXX">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left" colspan="4">
                <input type="checkbox" name="ckbXLMS" id="ckbJBXX" />
                <label for="ckbJBXX">基本信息</label>
            </th>
        </tr>
        <tr data-class="trJBXX">
            <th style="width:80px;">产品编号</th>
            <td style="width:250px;"><asp:Literal runat="server" ID="ltrChanPinBianHao"></asp:Literal></td>
            <th style="width:100px;">旅游天数</th>
            <td><asp:Literal runat="server" ID="ltrTianShu"></asp:Literal></td>            
        </tr>
        <tr data-class="trJBXX">
            <th>去程日期</th>
            <td><asp:Literal runat="server" ID="ltrQuDate"></asp:Literal></td>
            <th>去程交通</th>
            <td><asp:Literal runat="server" ID="ltrQuJiaoTong"></asp:Literal></td>            
        </tr>
        <tr data-class="trJBXX">
            <th>回程日期</th>
            <td><asp:Literal runat="server" ID="ltrHuiDate"></asp:Literal></td>
            <th>回程交通</th>
            <td><asp:Literal runat="server" ID="ltrHuiJiaoTong"></asp:Literal></td>            
        </tr>
        <tr data-class="trJBXX">
            <th>集合时间</th>
            <td><asp:Literal runat="server" ID="ltrJiHeShiJian"></asp:Literal></td>
            <th>集合地点</th>
            <td><asp:Literal runat="server" ID="ltrJiHeDiDian"></asp:Literal></td>            
        </tr>
        <tr data-class="trJBXX">
            <th>送团信息</th>
            <td colspan="3"><asp:Literal runat="server" ID="ltrSongTuanXinXi"></asp:Literal></td>         
        </tr>
        <tr data-class="trJBXX">
            <th>接团方式</th>
            <td colspan="3"><asp:Literal runat="server" ID="ltrMuDiDiJieTuanFangShi"></asp:Literal></td>        
        </tr>
        <tr data-class="trJBXX">
            <th>价格信息</th>
            <td colspan="3"><asp:Literal runat="server" ID="ltrJiaGeXinXi"></asp:Literal></td>        
        </tr>
    </table>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder runat="server" ID="phHangDuan" Visible="false">
        
        <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
            class="list">
            <tr>
                <th align="left" colspan="7">
                    <input type="checkbox" name="ckbHDXX" id="ckbHDXX" />中间航段信息
                </th>
            </tr>
            <tr data-class="trHDXX">
                <th align="center" width="30" style="background: #D7F0FC;">
                    序号
                </th>
                <th width="80" align="center" style="background: #D7F0FC;">
                    日期
                </th>
                <th width="80" align="center" style="background: #D7F0FC;">
                    交通
                </th>
                <th width="140" align="center" style="background: #D7F0FC;">
                    班次
                </th>
                <th width="120" align="center" style="background: #D7F0FC;">
                    出发地
                </th>
                <th width="120" align="center" style="background: #D7F0FC;">
                    目的地
                </th>
                <th align="center" style="background: #D7F0FC;">
                    备注
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rptHangDuan">
                <ItemTemplate>
                    <tr data-class="trHDXX">
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
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="ckbXLMS" id="ckbXLMS" />
                <label for="ckbXLMS">
                    线路描述</label>
            </th>
        </tr>
        <tr data-class="trXLMS">
            <td>
                <asp:Literal runat="server" ID="ltrXLMS"></asp:Literal>
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
        <asp:Repeater runat="server" ID="rptPlan">
            <ItemTemplate>
                <tr data-class="trXCAP">
                    <th style="width: 20px">
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
        <asp:PlaceHolder runat="server" ID="phJiaoTongBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">交通标准：</strong>
                    <asp:Literal runat="server" ID="ltrJTBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phZhuSuBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">住宿标准：</strong>
                    <asp:Literal runat="server" ID="ltrZSBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phCanYinBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">餐饮标准：</strong>
                    <asp:Literal runat="server" ID="ltrCYBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phJingDianBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">景点标准：</strong>
                    <asp:Literal runat="server" ID="ltrJDBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phDaoYouFuWu" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">导游服务：</strong>
                    <asp:Literal runat="server" ID="ltrDYFW"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phGouWuShuoMing" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">购物说明：</strong>
                    <asp:Literal runat="server" ID="ltrGWSM"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phErTongBiaoZhun" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">儿童标准：</strong>
                    <asp:Literal runat="server" ID="ltrETBZ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phBaoXianShuoMing" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">保险说明：</strong>
                    <asp:Literal runat="server" ID="ltrBXSM"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phZiFeiTuiJian" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">自费推荐：</strong>
                    <asp:Literal runat="server" ID="ltrZFTJ"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phWenXinTiShi" Visible="false">
            <tr data-class="trFWBZ">
                <td>
                    <strong data-class="next_p_replace_span">温馨提示：</strong>
                    <asp:Literal runat="server" ID="ltrWXTX"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="ckbBMXZ" id="ckbBMXZ" />
                <label for="ckbBMXZ">
                    报名须知</label>
            </th>
        </tr>
        <tr data-class="trBMXZ">
            <td>
                <asp:Literal runat="server" ID="ltrBMXZ"></asp:Literal>
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
            }
        }

        $(document).ready(function() {
            $("#divContent").find("input[type='checkbox']").attr("checked", true);

            iPage.bindClickByCheckBox("JBXX");
            iPage.bindClickByCheckBox("XLMS");
            iPage.bindClickByCheckBox("XCAP");
            iPage.bindClickByCheckBox("FWBZ");
            iPage.bindClickByCheckBox("BMXZ");
            iPage.bindClickByCheckBox("HDXX");

            $("strong[data-class='next_p_replace_span']").next("p").each(function() {
                $(this).replaceWith("<span>" + $(this).html() + "</span>");
            });
        });
    </script>

</asp:Content>

<asp:Content ContentPlaceHolderID="PageYeJiao" runat="server" ID="PageYeJiao1">
    <table border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
        <tr>
            <td align="left">
                <asp:Literal runat="server" ID="ltrYeJiao"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
