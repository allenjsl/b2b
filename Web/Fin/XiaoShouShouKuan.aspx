<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XiaoShouShouKuan.aspx.cs"
    Inherits="Web.Fin.XiaoShouShouKuan" MasterPageFile="~/MasterPage/Front.Master"
    Title="销售收款-财务管理" %>


<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:content contentplaceholderid="ContentPlaceHolder1" id="PageBody" runat="server">

    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 销售收款
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    
    <div class="hr_10"></div>
    
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox" style="height:75px;">
                    出团日期：
                    <input name="txtLSDate" type="text" class="searchinput formsize80 inputtext" id="txtLSDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtLEDate" type="text" class="searchinput formsize80 inputtext" id="txtLEDate"
                        onfocus="WdatePicker()" />
                    订单号：
                    <input name="txtOrderCode" type="text" class="searchinput formsize80 inputtext" id="txtOrderCode"
                        maxlength="50" />
                    省份：
                    <select name="txtProvince" id="txtProvince" class="inputselect">
                    </select>
                    城市：
                    <select name="txtCity" id="txtCity" class="inputselect">
                    </select>
                    <br />
                    客户单位：
                    <input name="txtKeHuName" type="text" class="searchinput formsize100 inputtext" id="txtKeHuName"
                        maxlength="50" />
                    游客姓名：
                    <input name="txtYouKeName" type="text" class="searchinput formsize80 inputtext" id="txtYouKeName"
                        maxlength="10" />                    
                    操作人：
                    <input name="txtOperatorName" type="text" class="searchinput formsize80 inputtext"
                        id="txtOperatorName" maxlength="10" />
                    应收金额：<select name="txtYingShouJinEOperator" id="txtYingShouJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtYingShouJinE" id="txtYingShouJinE" class="searchinput w50 inputtext" /><br />
                    结清状态：<select name="txtJieQingStatus" id="txtJieQingStatus" class="inputselect">
                        <option value="">请选择</option>
                        <option value="0">未结清</option>
                        <option value="1">已结清</option>
                    </select>
                    单笔收款：<select name="txtDanBiShouKuanJinEOperator" id="txtDanBiShouKuanJinEOperator"
                        class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                            type="text" name="txtDanBiShouKuanJinE" id="txtDanBiShouKuanJinE" class="searchinput w50 inputtext" />
                    未收金额：<select name="txtWeiShouJinEOperator" id="txtWeiShouJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtWeiShouJinE" id="txtWeiShouJinE" class="searchinput w50 inputtext" />
                    退款金额：<select name="txtTuiKuanJinEOperator" id="txtTuiKuanJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtTuiKuanJinE" id="txtTuiKuanJinE" class="searchinput w50 inputtext" />
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
                    <a href="javascript:void(0)" title="按出团日期倒序排列" id="a_paixu_desc">↓</a>订单号<a href="javascript:void(0)" title="按出团日期升序排列" id="a_paixu_asc">↑</a>
                </th>
                <%--<th align="center">
                    出团日期
                </th>--%>
                <th align="left" class="pandl3">
                    线路名称
                </th>
                <th align="left" class="pandl3">
                    客户单位
                </th>
                <th align="center">
                    对方操作人
                </th>
                <th align="center">
                    人数
                </th>
                <th align="center">
                    游客姓名
                </th>
                <th align="center">
                    价格明细
                </th>
                <th align="center">
                    总金额
                </th>
                <th align="center">
                    下单人
                </th>
                <th align="center">
                    已收金额
                </th>
                <th align="center">
                    未收金额
                </th>
                <th align="center">
                    已登待审
                </th>
                <th align="center">
                    退款待审
                </th>
                <th width="65" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
            <ItemTemplate>
            <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("OrderId") %>"
                style="<%#GetHangYangShi(Eval("BiaoShiYanSe"))%>">
                <td height="30" align="center">
                    <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                </td>
                <td align="center">
                    <a href="javascript:void(0)" class="i_dingdanhao"><%#Eval("OrderCode")%></a>
                    <span style="display:none;">
                        出团日期：<%#ToDateTimeString(Eval("LDate"))%><br />
                        下单人：<%#Eval("OperatorName") %>&nbsp;&nbsp;
                        下单时间：<%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}") %><br />
                        最后操作人：<%#Eval("LatestOperatorName") %>&nbsp;&nbsp;
                        最后操作时间：<%#Eval("LatestTime","{0:yyyy-MM-dd HH:mm}") %>
                    </span>
                </td>
                <%--<td align="center">
                    <%#ToDateTimeString(Eval("LDate"))%>
                </td>--%>
                <td align="left" class="pandl3">
                    <%#Eval("RouteName") %>
                </td>
                <td align="left" class="pandl3">
                    <%#Eval("KeHuName")%>
                </td>
                <td align="center">
                    <%#Eval("KeHuLxrName")%>
                </td>
                <td align="center" title="<%#Eval("ChengRenShu")%>成人+<%#Eval("ErTongShu") %>儿童+<%#Eval("YingErRenShu") %>婴儿+<%#Eval("QuanPeiShu")%>全陪">
                    <%#Eval("ChengRenShu")%>+<%#Eval("ErTongShu") %>+<%#Eval("YingErRenShu") %>+<%#Eval("QuanPeiShu")%>
                </td>
                <td align="center">
                    <%#Eval("YouKeName")%>
                </td>
                <td align="center" style="word-break: break-all; word-wrap: break-word;">
                    <%#Eval("JiaGeMingXi2")%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("JinE"))%>
                </td>
                <td align="center">
                    <%#Eval("OperatorName")%>
                </td>
                <td align="center">
                    <%#ToMoneyString((decimal)Eval("ShouYiShenHeJinE") - (decimal)Eval("TuiYiShenHeJinE"))%>
                </td>
                <td align="center">
                    <span class="fred"><%#ToMoneyString((decimal)Eval("JinE") - (decimal)Eval("ShouYiShenHeJinE") + (decimal)Eval("TuiYiShenHeJinE"))%></span>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("ShouWeiShenHeJinE"))%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("TuiWeiShenHeJinE"))%>
                </td>
                <td align="center">
                    <a href="javascript:void(0)" class="i_shoukuan">收款</a>
                    <a href="javascript:void(0)" class="i_fukuan">退款</a>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
            <tr>
                <td class="even" colspan="16" style="height: 30px; text-align: center;">
                    暂无任何订单信息。
                </td>
            </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
            <tr class="even">
                <td height="30" colspan="8" align="right">
                    合计：
                </td>
                <td align="center">
                    <asp:Literal runat="server" ID="ltrJinEHeJi"></asp:Literal>
                </td>
                <td align="center">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Literal runat="server" ID="ltrYiShouJinEHeJi"></asp:Literal>                    
                </td>
                <td align="center">
                    <asp:Literal runat="server" ID="ltrWeiShouJinEHeJi"></asp:Literal>
                </td>
                <td align="center">
                    <asp:Literal runat="server" ID="ltrWeiShenHeJinEHeJi"></asp:Literal>
                </td>
                <td align="center">
                    <asp:Literal runat="server" ID="ltrTuiWeiShenHeJinEHeJi"></asp:Literal>
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
            openShouKuan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: "<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangType.订单收款 %>" };
                Boxy.iframeDialog({ title: "销售收款", iframeUrl: "ShouKuan.aspx", width: "900px", height: "400px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            openFuKuan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: "<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangType.订单退款 %>" };
                Boxy.iframeDialog({ title: "销售退款", iframeUrl: "FuKuan.aspx", width: "930px", height: "400px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            initPC: function() {
                pcToobar.init({
                    pID: "#txtProvince",
                    cID: "#txtCity",
                    pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtProvince"),0) %>',
                    cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtCity"),0) %>',
                    comID: '<%= this.SiteUserInfo.CompanyId %>',
                    isCy: "0"
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
            $(".i_fukuan").bind("click", function() { return iPage.openFuKuan(this); });

            iPage.initPC();

            $(".i_dingdanhao").bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['right'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });

            $("#a_paixu_desc").click(function() { iPage.paiXu(2); });
            $("#a_paixu_asc").click(function() { iPage.paiXu(3); });
        });
    </script>
</asp:content>
