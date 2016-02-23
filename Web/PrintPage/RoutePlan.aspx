<%@ Page Title="线路行程单" Language="C#" MasterPageFile="~/MasterPage/Print.Master" AutoEventWireup="true"
    CodeBehind="RoutePlan.aspx.cs" Inherits="Web.PrintPage.RoutePlan" ValidateRequest="false" %>
<%@ MasterType VirtualPath="~/MasterPage/Print.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24">
                    <asp:Literal runat="server" ID="ltrRouteName"></asp:Literal></b>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="list">
        <tr>
            <th align="left">
                <input type="checkbox" name="ckbXLMS" id="ckbXLMS" />
                <label for="ckbXLMS">线路描述</label>
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
                <label for="ckbXCAP">行程安排</label>
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptPlan">
            <ItemTemplate>
                <tr data-class="trXCAP">
                    <th style="width:20px">
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
                <label for="ckbFWBZ">服务标准</label>
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
                <label for="ckbBMXZ">报名须知</label>
            </th>
        </tr>
        <tr data-class="trBMXZ">
            <td>
                <asp:Literal runat="server" ID="ltrBMXZ"></asp:Literal>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        var RoutePlanPrint = {
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

            RoutePlanPrint.BindClickByCheckBox("XLMS");
            RoutePlanPrint.BindClickByCheckBox("XCAP");
            RoutePlanPrint.BindClickByCheckBox("FWBZ");
            RoutePlanPrint.BindClickByCheckBox("BMXZ");

            $("strong[data-class='next_p_replace_span']").next().each(function() {
                $(this).replaceWith("<span>" + $(this).html() + "</span>");
            });

            $("strong[data-class='text']").next("p").each(function() {
                alert($(this).html())
                $(this).replaceWith("<span>" + $(this).html() + "</span>");
            });
        });
    </script>
</asp:Content>
