<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiRunGuSuanBiao1.aspx.cs"
    Inherits="Web.TongJi.LiRunGuSuanBiao1" MasterPageFile="~/MasterPage/Front.Master"
    Title="利润估算表一-统计分析" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">统计分析</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 统计分析 >> 利润估算表一
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <div class="hr_10">
    </div>
    <form id="form1" method="get" action="" onsubmit="return iPage.yanZhengChaXunForm()">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    年份：<select name="txtYear1" id="txtYear1" class="inputselect">
                        <asp:Literal runat="server" ID="ltrYearOption1"></asp:Literal>
                    </select><select name="txtMonth1" id="txtMonth1" class="inputselect">
                        <asp:Literal runat="server" ID="ltrMonthOption1"></asp:Literal>
                    </select> -
                    <select name="txtYear2" id="txtYear2" class="inputselect">
                        <asp:Literal runat="server" ID="ltrYearOption2"></asp:Literal>
                    </select><select name="txtMonth2" id="txtMonth2" class="inputselect">
                        <asp:Literal runat="server" ID="ltrMonthOption2"></asp:Literal>
                    </select>
                    
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    <div class="btnbox">
    </div>
    <div class="tablelist">
        <div style="text-align: center; font-weight: bold; height: 30px; line-height: 30px;
            font-size: 18px;"><asp:Literal runat="server" ID="ltrBiaoTi"></asp:Literal></div>
            
        <asp:PlaceHolder runat="server" ID="phTongJiBiao">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th align="center" width="10%">
                    年月
                </th>
                <th align="right">
                    结算收入&nbsp;
                </th>
                <th align="right">
                    结算支出&nbsp;
                </th>
                <th align="right">
                    结算毛利&nbsp;
                </th>
                <th align="right">
                    营业外收入&nbsp;
                </th>
                <th align="right">
                    报销金额&nbsp;
                </th>
                <th align="right">
                    工资费用&nbsp;
                </th>
                <th align="right">
                    利润&nbsp;
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <%#Eval("Year") %>年<%#Eval("Month") %>月
                        </td>
                        <td align="right">
                            <%#Eval("JieSuanShouRuJinE","{0:F2}") %>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("JieSuanZhiChuJinE","{0:F2}") %>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("JieSuanMaoLiJinE","{0:F2}") %>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("YingYeWaiShouRuJinE","{0:F2}") %>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("BaoXiaoJinE","{0:F2}") %>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("GongZiJinE","{0:F2}") %>&nbsp;
                        </td>
                        <td align="right">
                            <%#Eval("LiRun","{0:F2}") %>&nbsp;
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无相关利润估算信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td colspan="2" style="text-align: right; height: 30px;">
                        合计：
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrJieSuanShouRuJinEHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrJieSuanZhiChuJinEHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrJieSuanMaoLiJinEHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrYingYeWaiShouRuJinEHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrBaoXiaoJinEHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrGongZiJinEHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrLiRunHeJi"></asp:Literal>&nbsp;
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        </asp:PlaceHolder>
    </div>

    <script type="text/javascript">
        var iPage = {
            yanZhengChaXunForm: function() {
                var _txtYear1 = parseInt($("#txtYear1").val());
                var _txtYear2 = parseInt($("#txtYear2").val());

                if (_txtYear2 - _txtYear1 > 3) { alert("一次最多只能统计48个月的利润估算信息"); return false; }

                return true;
            }
        };
    </script>

</asp:Content>
