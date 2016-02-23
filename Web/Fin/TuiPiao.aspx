<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuiPiao.aspx.cs" Inherits="Web.Fin.TuiPiao"
    MasterPageFile="~/MasterPage/Front.Master" Title="退票登记表-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 退票登记表
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
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    出团日期：
                    <input name="txtLSDate" type="text" class="searchinput formsize80 inputtext" id="txtLSDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtLEDate" type="text" class="searchinput formsize80 inputtext" id="txtLEDate"
                        onfocus="WdatePicker()" />
                    交易号：
                    <input name="txtJiaoYiHao" type="text" class="searchinput formsize80 inputtext" id="txtJiaoYiHao"
                        maxlength="50" />
                    订单号或编码：
                    <input name="txtGysJiaoYiHao" type="text" class="searchinput formsize100 inputtext"
                        id="txtGysJiaoYiHao" maxlength="50" />
                    订单号
                    <input name="txtOrderCode" type="text" class="searchinput formsize100 inputtext"
                        id="txtOrderCode" maxlength="50" />
                    供应商：
                    <input name="txtGysName" type="text" class="searchinput formsize80 inputtext" id="txtGysName"
                        maxlength="50" /><br />
                    应退金额：<select name="txtTuiPiaoYingTuiOperator" id="txtTuiPiaoYingTuiOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator), new string[] { "0" }), EyouSoft.Common.Utils.GetQueryStringValue("txtTuiPiaoYingTuiOperator"), "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtTuiPiaoYingTuiJinE" id="txtTuiPiaoYingTuiJinE" class="searchinput w50 inputtext" />
                    已退金额：<select name="txtTuiPiaoYiTuiJinEOperator" id="txtTuiPiaoYiTuiJinEOperator"
                        class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator), new string[] { "0" }), string.Empty, "0", "-请选择-")%></select>&nbsp;<input
                            type="text" name="txtTuiPiaoYiTuiJinE" id="txtTuiPiaoYiTuiJinE" class="searchinput w50 inputtext" />
                    未退金额：<select name="txtTuiPiaoWeiTuiJinEOperator" id="txtTuiPiaoWeiTuiJinEOperator"
                        class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator), new string[] { "0" }), string.Empty, "0", "-请选择-")%></select>&nbsp;<input
                            type="text" name="txtTuiPiaoWeiTuiJinE" id="txtTuiPiaoWeiTuiJinE" class="searchinput w50 inputtext" />
                    游客姓名：<input type="text" id="txtYouKeName" name="txtYouKeName" class="searchinput formsize100 inputtext" />
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" height="30" align="center">
                    序号
                </th>
                <th align="center">
                    <a href="javascript:void(0)" title="按出团日期倒序排列" id="a_paixu_desc">↓</a>出团日期<a href="javascript:void(0)" title="按出团日期升序排列" id="a_paixu_asc">↑</a>
                </th>
                <th align="center">
                    订单号
                </th>
                <th align="center">
                    出票交易号
                </th>
                <th align="left" class="pandl3">
                    代理商
                </th>
                <th align="center">
                    退票时间
                </th>
                <th align="center">
                    退票人数
                </th>
                <th align="center">
                    退票游客
                </th>
                <th align="center">
                    损失明细
                </th>
                <%--<th align="center">
                    损失金额
                </th>--%>
                <th align="center">
                    承担方
                </th>
                <th align="center">
                    经手人
                </th>
                <th align="center">
                    应退金额
                </th>
                <th align="center">
                    已退金额
                </th>
                <th align="center">
                    未退金额
                </th>
                <th width="35" align="center">
                    操作
                </th>
            </tr>            
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("TuiPiaoId") %>">
                        <td height="30" align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("LDate"))%>
                        </td>
                        <td align="center">
                            <%#Eval("OrderCode")%>
                        </td>
                        <td align="center">
                            <%#Eval("JiaoYiHao") %>
                        </td>
                        <td align="left" class="pandl3">
                            <%#Eval("GysName") %>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("TuiTime"))%>
                        </td>
                        <td align="center">
                            <%#Eval("TuiRenShu")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_youkemx">
                                <%#Eval("YouKeName")%></a>
                            <div style="display: none">
                                <%#GetYouKeMxHtml(Eval("YouKes"))%></div>
                        </td>
                        <td align="center">
                            <%#Eval("SunShiMingXi") %>
                        </td>
                        <%--<td align="center">
                            <%#ToMoneyString(Eval("SunShiJinE"))%>
                        </td>--%>
                        <td align="center">
                            <%#Eval("ChengDanFang")%>
                        </td>
                        <td align="center">
                            <%#Eval("OperatorName")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YingTuiJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YiShenPiJinE"))%>
                        </td>
                        <td align="center">
                            <span class="fred">
                                <%#ToMoneyString((decimal)Eval("YingTuiJinE") - (decimal)Eval("YiShenPiJinE"))%></span>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_shoukuan">登记</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="15" style="height: 30px; text-align: center;">
                        暂无任何退票登记信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="6" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrTuiRenShuHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        
                    </td>
                    <td align="center">
                    </td>
                    <%--<td align="center">
                        <asp:Literal runat="server" ID="ltrSunShiJinEHeJi"></asp:Literal>
                    </td>--%>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrYingTuiJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrYiShenPiJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrWeiTuiJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <asp:PlaceHolder runat="server" ID="phPaging">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            openShouKuan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: "<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务退款 %>" };
                Boxy.iframeDialog({ title: "退票-收款登记", iframeUrl: "ShouKuan.aspx", width: "900px", height: "400px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            displayMx: function() {
                $('.i_youkemx').bt({
                    contentSelector: function() { return $(this).next("div").html(); },
                    positions: ['bottom'],
                    fill: '#effaff',
                    strokeStyle: '#2a9cd4',
                    noShadowOpts: { strokeStyle: "#2a9cd4" },
                    spikeLength: 5,
                    spikeGirth: 15,
                    width: 620,
                    overlap: 0,
                    centerPointY: 4,
                    cornerRadius: 4,
                    shadow: true,
                    shadowColor: 'rgba(0,0,0,.5)',
                    cssStyles: { color: '#1351a0', 'line-height': '200%' }
                });
            },
            paiXu: function(leiXing) {
                var _params = utilsUri.getUrlParams(["paixuleixing"]);
                _params["paixuleixing"] = leiXing;
                //window.location.href = utilsUri.createUri(window.location.pathname, _params);
                window.location.href = window.location.pathname + "?" + $.param(_params);
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".i_shoukuan").bind("click", function() { return iPage.openShouKuan(this); });
            iPage.displayMx();

            $("#a_paixu_desc").click(function() { iPage.paiXu(2); });
            $("#a_paixu_asc").click(function() { iPage.paiXu(3); });
        });
    </script>

</asp:Content>
