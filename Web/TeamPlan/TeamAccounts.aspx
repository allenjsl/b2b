<%@ Page Title="团队结算" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="TeamAccounts.aspx.cs" Inherits="Web.TeamPlan.TeamAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">
                                <asp:Literal runat="server" ID="ltrTitle"></asp:Literal></span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            所在位置&gt;&gt; 团队结算
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <div class="hr_10">
            </div>
            <span class="formtableT">收入</span>
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="tabShouRu">
                <tbody>
                    <tr style="background-color: #BDDCF4;">
                        <th width="15%" height="30" align="center">
                            订单号
                        </th>
                        <th width="35%" align="center">
                            客户单位
                        </th>
                        <th width="35%" align="center">
                            价格明细
                        </th>
                        <th width="15%" align="center">
                            收入金额
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptShouRu">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                                <td height="30" align="center">
                                    <%# Eval("OrderCode") %>
                                </td>
                                <td align="center">
                                    <%# Eval("KeHuName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("JiaGeMingXi2")%>
                                </td>
                                <td align="center">
                                    <%# this.ToMoneyString(Eval("JinE"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="even">
                        <td height="30" align="right" colspan="3">
                            <strong>收入合计：</strong>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrShouRuHeJi"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="hr_10">
            </div>
            <span class="formtableT">其他收入</span> <a id="a_QiTaShouRu" href="javascript:void(0);">
                <span class="fred">添加收入</span></a>
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="tabQiTaShouRu">
                <tbody>
                    <tr style="background-color: #BDDCF4;">
                        <th width="15%" height="30" align="center">
                            操作时间
                        </th>
                        <th width="25%" align="center">
                            收入项目
                        </th>
                        <th width="20%" align="center">
                            对方单位
                        </th>
                        <th width="25%" align="center">
                            收入备注
                        </th>
                        <th width="15%" align="center">
                            收入金额
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptQiTaShouRu">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                                <td height="30" align="center">
                                    <%# this.ToDateTimeString(Eval("ShiJian"))%>
                                </td>
                                <td align="center">
                                    <%# Eval("XiangMu")%>
                                </td>
                                <td align="center">
                                    <%# Eval("KeHuName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("BeiZhu")%>
                                </td>
                                <td align="center">
                                    <%# this.ToMoneyString(Eval("JinE"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="even">
                        <td height="30" align="right" colspan="4">
                            <strong>收入合计：</strong>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrQiTaShouRuHeJi"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="hr_10">
            </div>
            <span class="formtableT">支出</span>
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="tabZhiChu">
                <tbody>
                    <tr style="background-color: #BDDCF4;">
                        <th width="15%" height="30" align="center">
                            交易号
                        </th>
                        <th width="35%" align="center">
                            供应商
                        </th>
                        <th width="35%" align="center">
                            结算明细
                        </th>
                        <th width="15%" align="center">
                            结算金额
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptZhiChu">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                                <td height="30" align="center">
                                    <%# Eval("JiaoYiHao")%>
                                </td>
                                <td align="center">
                                    <%# Eval("GysName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("JieSuanMingXi")%>
                                </td>
                                <td align="center">
                                    <%# this.ToMoneyString(Eval("JinE"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="even">
                        <td height="30" align="right" colspan="3">
                            <strong>结算合计：</strong>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrZhiChuHeJi"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="hr_10">
            </div>
            <span class="formtableT">其他支出</span> <a id="a_QiTaZhiChu" href="javascript:void(0);">
                <span class="fred">添加支出</span></a>
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="tabQiTaZhiChu">
                <tbody>
                    <tr style="background-color: #BDDCF4;">
                        <th width="15%" height="30" align="center">
                            操作时间
                        </th>
                        <th width="25%" align="center">
                            支出项目
                        </th>
                        <th width="20%" align="center">
                            对方单位
                        </th>
                        <th width="25%" align="center">
                            支出备注
                        </th>
                        <th width="15%" align="center">
                            结算金额
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptQiTaZhiChu">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                                <td height="30" align="center">
                                    <%# this.ToDateTimeString(Eval("ShiJian"))%>
                                </td>
                                <td align="center">
                                    <%# Eval("XiangMu")%>
                                </td>
                                <td align="center">
                                    <%# Eval("KeHuName")%>
                                </td>
                                <td style="text-align:center;"><%#Eval("BeiZhu") %></td>
                                <td align="center">
                                    <%# this.ToMoneyString(Eval("JinE"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="even">
                        <td height="30" align="right" colspan="4">
                            <strong>结算合计：</strong>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrQiTaZhiChuHeJi"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="hr_10">
            </div>
            <table width="100%" cellspacing="1" cellpadding="0" border="0">
                <tbody>
                    <tr class="odd">
                        <th width="50%" height="30" align="center">
                            毛利
                        </th>
                        <th width="50%" align="center">
                            毛利率
                        </th>
                    </tr>
                    <tr class="even">
                        <td height="30" align="center">
                            <asp:Literal runat="server" ID="ltrMaoLi"></asp:Literal>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrMaoLiLv"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" border="0" align="center">
                <tbody>
                    <tr>
                        <td width="85" align="center" class="tjbtn02">
                            <asp:LinkButton runat="server" ID="btrReturn" Text="返回" OnClick="btrReturn_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var TeamAccounts = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            _tourId: '<%= EyouSoft.Common.Utils.GetQueryStringValue("tourId") %>',
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height,
                    afterHide: function() { TeamAccounts.reload();}
                });
            },
            AddQiTaShouRu: function() {
                TeamAccounts.ShowBoxy({ iframeUrl: "/fin/qitashouruedit.aspx?KongWeiId=" + TeamAccounts._tourId, title: "添加其他收入", width: "670px", height: "300px" });
            },
            AddQiTaZhiChu: function() {
                TeamAccounts.ShowBoxy({ iframeUrl: "/fin/qitazhichuedit.aspx?KongWeiId=" + TeamAccounts._tourId, title: "添加其他支出", width: "670px", height: "300px" });
            }
        };

        $(document).ready(function() {
            $("#a_QiTaShouRu").click(function() {
                TeamAccounts.AddQiTaShouRu();
                return false;
            });
            $("#a_QiTaZhiChu").click(function() {
                TeamAccounts.AddQiTaZhiChu();
                return false;
            });

            tableToolbar.init({ tableContainerSelector: "#tabShouRu" });
            tableToolbar.init({ tableContainerSelector: "#tabQiTaShouRu" });
            tableToolbar.init({ tableContainerSelector: "#tabZhiChu" });
            tableToolbar.init({ tableContainerSelector: "#tabQiTaZhiChu" });

        }); 
    </script>

    </form>
</asp:Content>
