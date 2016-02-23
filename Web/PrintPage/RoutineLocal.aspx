<%@ Page Title="地接安排计划单" Language="C#" MasterPageFile="~/MasterPage/Print.Master"
    AutoEventWireup="true" CodeBehind="RoutineLocal.aspx.cs" Inherits="Web.PrintPage.RoutineLocal"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24"><asp:Literal runat="server" ID="ltrZxsName"></asp:Literal>地接安排计划单</b>&nbsp;&nbsp;
                <span style="font-size:18px;">(<asp:Literal runat="server" ID="ltrOperatorName"></asp:Literal>)<br />
                    &nbsp;<asp:Literal runat="server" ID="ltrFax"></asp:Literal></span>
            </td>
        </tr>
    </table>
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                地接社：<asp:Literal runat="server" ID="ltrGysName"></asp:Literal>
            </td>
            <td align="left">
                地接社传真：<asp:Literal runat="server" ID="ltrGysFax"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                团号：<asp:Literal runat="server" ID="ltrTourNo"></asp:Literal>
            </td>
            <td align="left">
                总人数：<asp:Literal runat="server" ID="ltrPeopleNum"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                用餐：<asp:Literal runat="server" ID="ltrYongCan"></asp:Literal>
            </td>
            <td align="left">
                全陪：<asp:Literal runat="server" ID="ltrQuanPei"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                性质：<asp:Literal runat="server" ID="ltrXingZhi"></asp:Literal>
            </td>
            <td align="left">
                线路名称：<asp:Literal runat="server" ID="ltrRouteName"></asp:Literal>
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
                导游：<asp:Literal runat="server" ID="ltrDaoYou"></asp:Literal>
            </td>
            <td align="left">
                接团方式：<asp:Literal runat="server" ID="ltrJieTuanFangShi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="left">
                结算明细：<asp:Literal runat="server" ID="ltrJieSuanMingXi"></asp:Literal>
            </td>
            <td align="left">
                结算金额：<asp:Literal runat="server" ID="ltrJieSuanJinE"></asp:Literal>
            </td>
        </tr>
        <asp:PlaceHolder runat="server" ID="phYouKeXinXi">
        <tr>
            <td colspan="2" align="left">
                客人信息：<asp:Literal runat="server" ID="ltrYouKeXinXi"></asp:Literal></td>
        </tr>
        </asp:PlaceHolder>
        <tr>
            <td colspan="2" align="left">
                <asp:Literal runat="server" ID="ltrRemark"></asp:Literal></td>
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
                    <th style="width:20px;">
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
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" height="150" align="center">
                <div id="divImgCachet">
                    签章 <asp:Literal runat="server" ID="ltrIssueTime"></asp:Literal>
                </div>
            </td>
            <td width="50%" align="center">
                地接社盖章
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        var RoutineLocal = {
            BindClickByCheckBox: function(idhz) {
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
            //divContent    为母版页div容器
            $("#divContent").find("input[type='checkbox']").attr("checked", true);

            RoutineLocal.BindClickByCheckBox("XCAP");
            RoutineLocal.BindClickByCheckBox("FWBZ");

            $("strong[data-class='next_p_replace_span']").next("p").each(function() {
                $(this).replaceWith("<span>" + $(this).html() + "</span>");
            });
        });
    </script>

</asp:Content>
