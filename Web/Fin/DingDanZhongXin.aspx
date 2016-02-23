<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDanZhongXin.aspx.cs"
    Inherits="Web.Fin.DingDanZhongXin" MasterPageFile="~/MasterPage/Front.Master"
    Title="订单中心-财务管理" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 订单中心
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
                <div class="searchbox" style="height:80px;">
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
                    状态：
                    <select name="txtStatus" id="txtStatus" class="inputselect">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.OrderStatus),new string[]{"2"}), "")%>
                    </select>
                    操作人：
                    <input name="txtOperatorName" type="text" class="searchinput formsize80 inputtext"
                        id="txtOperatorName" maxlength="10" />
                    业务类型：<select name="txtYeWuLeiXing" id="txtYeWuLeiXing" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.BusinessType)), EyouSoft.Common.Utils.GetQueryStringValue("txtYeWuLeiXing"), "-1", "-请选择-")%></select><br />
                    线路名称：<input name="txtRouteName" type="text" class="inputtext"
                        id="txtRouteName" maxlength="50" style="width:100px;"/>
                    线路区域：<select name="txtQuYu" class="inputselect" id="txtQuYu" valid="required" errmsg="请选择线路区域!">
                            <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                    </select>
                    去程交通：<select name="txtQuJiaoTong" class="inputselect"><%=GetQuJiaoTongOptions()%></select>
                    
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
                <%--<th align="center">
                    出团日期
                </th>--%>
                <th align="center">
                    <a href="javascript:void(0)" title="按出团日期倒序排列" id="a_paixu_desc">↓</a>订单号<a href="javascript:void(0)" title="按出团日期升序排列" id="a_paixu_asc">↑</a>
                </th>
                <th align="left" class="pandl3">
                    客户单位
                </th>
                <th align="center">
                    对方操作人
                </th>
                <th align="left" class="pandl3">
                    线路名称
                </th>
                <th align="center">
                    人数
                </th>
                <th align="center">
                    占位
                </th>
                <th align="center">
                    价格明细
                </th>
                <th align="center">
                    总金额
                </th>
                <th align="center">
                    订单状态
                </th>
                <th align="center">
                    下单人
                </th>
                <th width="90" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("OrderId") %>"
                        i_kongweiid="<%#Eval("KongWeiId") %>" i_yewuleixing="<%#(int)Eval("YeWuLeiXing") %>"
                        style="<%#GetHangYangShi(Eval("BiaoShiYanSe"))%>">
                        <td height="30" align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <%--<td align="center">
                            <%#ToDateTimeString(Eval("LDate"))%>
                        </td>--%>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_dingdanhao"><%#Eval("OrderCode")%></a>
                            <span style="display:none;">
                                出团日期：<%#ToDateTimeString(Eval("LDate"))%><br />
                                下单人：<%#Eval("OperatorName") %>&nbsp;&nbsp;
                                下单时间：<%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}") %><br />
                                最后操作人：<%#Eval("LatestOperatorName") %>&nbsp;&nbsp;
                                最后操作时间：<%#Eval("LatestTime","{0:yyyy-MM-dd HH:mm}") %><br />
                                <%#GetFaPiaoXinXi(Eval("FaPiaoMxId"),Eval("FaPiaoJinE")) %>
                            </span>
                        </td>
                        <td align="left" class="pandl3">
                            <%#Eval("KeHuName")%>
                        </td>
                        <td align="center">
                            <%#Eval("KeHuLxrName")%>
                        </td>
                        <td align="left" class="pandl3" style="word-break: break-all; word-wrap: break-word;">
                            <%#Eval("RouteName")%>
                        </td>
                        <td align="center" title="<%#Eval("ChengRenShu")%>成人+<%#Eval("ErTongShu") %>儿童+<%#Eval("YingErRenShu") %>婴儿+<%#Eval("QuanPeiShu")%>全陪">
                            <%#Eval("ChengRenShu")%>+<%#Eval("ErTongShu") %>+<%#Eval("YingErRenShu") %>+<%#Eval("QuanPeiShu")%>
                        </td>
                        <td align="center">
                            <%#Eval("ZhanWeiShu")%>
                        </td>
                        <td align="center" style="word-break: break-all; word-wrap: break-word;">
                            <%#Eval("JiaGeMingXi2")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("Status"),Eval("LiuWeiDaoQiTime")) %>
                        </td>
                        <td align="center">
                            <%#Eval("OperatorName") %>
                        </td>
                        <td align="center">
                            <a target="_blank" href="javascript:void(0)"  class="anpai_dj">确认单</a> 
                            <a href="javascript:void(0)" class="i_biangeng">变更历史</a><br />
                            <a class="showOrder" href="javascript:void(0)">查看订单</a> 
                            <a href="javascript:void(0)" class="i_huifang">回访</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="13" style="height: 30px; text-align: center;">
                        暂无任何订单信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="5" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrRenShuHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrZhanWeiShuHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJinEHeJi"></asp:Literal>
                    </td>
                    <td colspan="3" align="center">
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
            //打开回访窗口
            huiFang: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { orderid: _$tr.attr("i_xmid") };
                Boxy.iframeDialog({ title: "回访", iframeUrl: "DingDanHuiFang.aspx", width: "670px", height: "300px", data: _data });
                return false;
            },
            //打开变更历史窗口
            bianGeng: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { bianId: _$tr.attr("i_xmid"), bianType: "<%=(int)EyouSoft.Model.EnumType.TourStructure.BianType.订单变更 %>" };
                if (_$tr.attr("i_yewuleixing") == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店 %>") {
                    _data.bianType = "<%=(int)EyouSoft.Model.EnumType.TourStructure.BianType.代订酒店 %>";
                }
                parent.Boxy.iframeDialog({ title: "查看变更信息", iframeUrl: "/commonpage/biangenglist.aspx", width: "370px", height: "200px", data: _data, afterHide: function() { } });
                return false;
            },
            //省份城市初始化
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
            //确认单
            queRenDan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { orderId: _$tr.attr("i_xmid"), tourId: _$tr.attr("i_kongweiid") };
                var type = _$tr.attr("i_yewuleixing");
                var url = "/PrintPage/RoutineOrderCustomer.aspx?";
                switch (type) {
                    case "1":
                    case "2":
                        url = "/PrintPage/RoutineTicketHotel.aspx?";
                        break;
                    case "3":
                        url = "/PrintPage/ScheduleHotel.aspx?";
                        break;
                    default:
                        break;
                }
                $(obj).attr("href", url + $.param(_data));
            },
            showOrder: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _yeWuLeiXing = _$tr.attr("i_yewuleixing");
                var _data = { orderid: _$tr.attr("i_xmid"), kongweiId: _$tr.attr("i_kongweiid"), isshow: 0 };
                var _url = "/TeamPlan/PlanAdd.aspx";

                if (_yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店 %>") {
                    _url = "/TeamPlan/ScheduleHotelAdd.aspx";
                    _data = { id: _$tr.attr("i_kongweiid"), dotype: "show" };
                }

                Boxy.iframeDialog({ title: "查看订单", iframeUrl: _url, width: "970px", height: "600px", data: _data });
                return false;
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

            $(".i_huifang").bind("click", function() { return iPage.huiFang(this); });
            $(".i_biangeng").bind("click", function() { return iPage.bianGeng(this); });
            $(".anpai_dj").each(function() { iPage.queRenDan(this); });
            $(".showOrder").bind("click", function() { return iPage.showOrder(this) });
            iPage.initPC();

            $(".i_dingdanhao").bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['right'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });

            $("#a_paixu_desc").click(function() { iPage.paiXu(2); });
            $("#a_paixu_asc").click(function() { iPage.paiXu(3); });
        });
    </script>

</asp:Content>
