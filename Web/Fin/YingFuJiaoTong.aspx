<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YingFuJiaoTong.aspx.cs"
    Inherits="Web.Fin.YingFuJiaoTong" MasterPageFile="~/MasterPage/Front.Master"
    Title="应付交通费-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 应付交通费
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
                    控位号：
                    <input name="txtKongWeiCode" type="text" class="searchinput formsize80 inputtext"
                        id="txtKongWeiCode" maxlength="50" />
                    交易号：
                    <input name="txtJiaoYiHao" type="text" class="searchinput formsize100 inputtext"
                        id="txtJiaoYiHao" maxlength="50" />
                    订单号或编码：
                    <input name="txtGysJiaoYiHao" type="text" class="searchinput formsize100 inputtext"
                        id="txtGysJiaoYiHao" maxlength="50" />
                    供应商：
                    <input name="txtGysName" type="text" class="searchinput formsize80 inputtext" id="txtGysName"
                        maxlength="50" /><br />
                    应付金额：<select name="txtYingFuJinEOperator" id="txtYingFuJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtYingFuJinE" id="txtYingFuJinE" class="searchinput w50 inputtext" />
                    结清状态：<select name="txtJieQingStatus" id="txtJieQingStatus" class="inputselect">
                        <option value="">请选择</option>
                        <option value="0">未结清</option>
                        <option value="1">已结清</option>
                    </select>
                    去程交通：<select name="txtQuJiaoTongId" id="txtQuJiaoTongId" class="inputselect"><%=GetQuJiaoTongOptions()%></select>
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
                    控位号
                </th>
                <th align="center">
                    交易号
                </th>
                <th align="left" class="pandl3">
                    代理商
                </th>
                <th align="center">
                    出票数
                </th>
                <th align="center">
                    游客
                </th>
                <th align="center">
                    结算明细
                </th>
                <th align="center">
                    结算金额
                </th>
                <th align="center">
                    已付金额
                </th>
                <th align="center">
                    未付金额
                </th>
                <th width="35" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("PlanId") %>">
                        <td height="30" align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("LDate"))%>
                        </td>
                        <td align="center">
                            <%#Eval("KongWeiCode")%>
                        </td>
                        <td align="center">
                            <%#Eval("JiaoYiHao") %>
                        </td>
                        <td align="left" class="pandl3">
                            <%#Eval("GysName")%>
                        </td>
                        <td align="center">
                            <%#Eval("ChuPiaoShu")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_youkemx">
                                <%#Eval("YouKeName")%></a>
                            <div style="display: none">
                                <%#GetYouKeMxHtml(Eval("YouKes"))%></div>
                        </td>
                        <td align="center">
                            <%#Eval("JieSuanMingXi")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JieSuanJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YiZhiFuJinE"))%>
                        </td>
                        <td align="center">
                            <span class="fred">
                                <%#ToMoneyString((decimal)Eval("JieSuanJinE") - (decimal)Eval("YiZhiFuJinE"))%></span>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_fukuan">登记</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="12" style="height: 30px; text-align: center;">
                        暂无任何应付交通信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="8" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJieSuanJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrYiZhiFuJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrWeiFuJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        &nbsp;
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
            openFuKuan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: "<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangType.票务安排付款 %>" };
                Boxy.iframeDialog({ title: "应付交通-付款登记", iframeUrl: "FuKuan.aspx", width: "930px", height: "400px", data: _data, afterHide: function() { iPage.reload(); } });
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
            $(".i_fukuan").bind("click", function() { return iPage.openFuKuan(this); });
            iPage.displayMx();

            $("#a_paixu_desc").click(function() { iPage.paiXu(2); });
            $("#a_paixu_asc").click(function() { iPage.paiXu(3); });
        });
    </script>

</asp:Content>
