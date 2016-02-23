<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="Web.TeamPlan.OrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxy.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="../JS/table-toolbar.js" type="text/javascript"></script>
    <script src="../JS/jquery.boxy.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/bt.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 0 auto; margin-top:5px;">
        <tbody>
            <tr class="odd">
                <th height="30" align="center" width="85">
                    订单号
                </th>
                <th align="center">
                    线路名称
                </th>
                <th width="139" align="center">
                    客户单位
                </th>
                <th width="70" align="center">
                    对方操作人
                </th>
                <th width="44" align="center">
                    人数
                </th>
                <th width="35" align="center">
                    占位
                </th>
                <th width="100" align="center">
                    价格明细
                </th>
                <th width="51" align="center">
                    总金额
                </th>
                <th width="84" align="center">
                    订单状态
                </th>
                <th width="48" align="center">
                    下单人
                </th>
                <th width="70" align="center">
                    下单时间
                </th>
                <th width="48" align="center">
                    确认单
                </th>
                <th width="64" align="center">
                    变更历史
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rptList">
                <ItemTemplate>
                    <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-orderid='<%#Eval("OrderId") %>'
                        data-kongweiid='<%#Eval("TourId") %>' data-routeid='<%#Eval("RouteId") %>' data-type='<%#(int)Eval("BusinessType") %>'
                        style="<%#GetHangYangShi(Eval("BiaoShiYanSe"))%>">
                        <td height="30" align="center">
                            <a class="update_bar" href="javascript:;"><%#Eval("OrderCode") %></a>
                            <span style="display:none;">
                                下单人：<%#Eval("OperatorName") %>&nbsp;&nbsp;
                                下单时间：<%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}") %><br />
                                最后操作人：<%#Eval("LatestOperatorName") %>&nbsp;&nbsp;
                                最后操作时间：<%#Eval("LatestTime","{0:yyyy-MM-dd HH:mm}") %>
                            </span>                            
                        </td>
                        <td align="center">
                            <%#GetRouteName(Eval("RouteName"),Eval("BusinessType")) %>
                        </td>
                        <td align="center">
                            <%#Eval("BuyCompanyName")%>
                        </td>
                        <td align="center">
                            <%#Eval("BuyOperatorName")%>
                        </td>
                        <td align="center" title="<%#Eval("Adults")%>成人+<%#Eval("Childs")%>儿童+<%#Eval("YingErRenShu")%>婴儿+<%#Eval("Bears")%>全陪">
                            <%#Eval("Adults")%>+<%#Eval("Childs")%>+<%#Eval("YingErRenShu")%>+<%#Eval("Bears")%>
                        </td>
                        <td align="center">
                            <%#Eval("Accounts")%>
                        </td>
                        <td align="center" style="word-break: break-all; word-wrap: break-word;">
                            <%#Eval("JiaGeMingXi1")%>
                        </td>
                        <td align="center">
                            <%#EyouSoft.Common.Utils.GetDecimal(Convert.ToString(Eval("SumPrice"))).ToString("f2")%>
                        </td>
                        <td align="center">
                            <%#((EyouSoft.Model.EnumType.TourStructure.OrderStatus)Eval("OrderStatus")).ToString()%>
                        </td>
                        <td align="center">
                            <%#Eval("OperatorName")%>
                        </td>
                        <td align="center">
                            <%#Eval("IssueTime","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <a target="_blank" href="javascript:;" class="showprint">查看</a>
                        </td>
                        <td align="center">
                            <a class="historybox" href="javascript:void(0)">查看</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </form>
</body>
</html>

<script type="text/javascript">
    $(function() {
        OrderInfo.PageInit();

        $('.update_bar').bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['right'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
    })
    var OrderInfo = {
        reload: function() {
            window.location.href = window.location.href;
            return false;
        },
        ShowBoxy: function(data) {
            parent.Boxy.iframeDialog({
                iframeUrl: data.iframeUrl,
                title: data.title,
                modal: true,
                width: data.width,
                height: data.height,
                afterHide: function() { OrderInfo.reload(); }
            });
        },
        HistoryList: function(orderid, type) {
            //commonpage/biangenglist.aspx?bianId=主键编号&bianType=变更类型
            OrderInfo.ShowBoxy({ iframeUrl: "/commonpage/biangenglist.aspx?bianId=" + orderid + "&bianType=" + type, title: "变更历史", width: "370px", height: "230px" });
        },
        UpdateOrder: function(orderid, kongweiId) {
            OrderInfo.ShowBoxy({ iframeUrl: "/TeamPlan/PlanAdd.aspx?orderid=" + orderid + "&kongweiId=" + kongweiId, title: "收客预定修改", width: "970px", height: "600px" });
        },
        PageInit: function() {
            $(".historybox").click(function() {
                var orderId = $(this).closest("tr").attr("data-orderid");
                var biantype = '<%=(int)EyouSoft.Model.EnumType.TourStructure.BianType.订单变更 %>';
                OrderInfo.HistoryList(orderId, biantype);
                return false;
            });
            $(".update_bar").click(function() {
                var orderid = $(this).closest("tr").attr("data-orderid");
                var kongweiId = $(this).closest("tr").attr("data-kongweiId");
                OrderInfo.UpdateOrder(orderid, kongweiId);
                return false;
            });
            $(".showprint").click(function() {
                var _$tr = $(this).closest("tr");
                var _data = { orderId: _$tr.attr("data-orderid"), tourId: _$tr.attr("data-kongweiId") };
                var type = _$tr.attr("data-type");
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
                $(this).attr("href", url + $.param(_data));
            });
        }
    };
</script>

