<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenDingDan.aspx.cs" Inherits="Web.PingTai.JiFenDingDan" MasterPageFile="~/MasterPage/Front.Master" Title="积分兑换订单管理-同行端口"%>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">同行端口</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 同行端口 >> 积分兑换订单管理
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
                    商品类型： <select id="txtLeiXing" class="inputselect" name="txtLeiXing">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenShangPingLeiXing)), "") %>
                    </select>
                    商品编码：
                    <input name="txtShangPinBianMa" type="text" class="inputtext"
                        id="txtShangPinBianMa" maxlength="50" style="width:100px;"/>             
                    商品名称：
                    <input name="txtShangPinMingCheng" type="text" class="inputtext"
                        id="txtShangPinMingCheng" maxlength="50" style="width:100px;"/>
                    订单号：
                    <input name="txtDingDanHao" type="text" class="inputtext"
                        id="Text1" maxlength="50" style="width:100px;"/>  <br />
                    订单状态：
                    <select id="txtDingDanStatus" class="inputselect" name="txtDingDanStatus">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus)), "") %>
                    </select>
                    下单时间：
                    <input name="txtXiaDanShiJian1" type="text" class="formsize80 inputtext" id="txtXiaDanShiJian1"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtXiaDanShiJian2" type="text" class="formsize80 inputtext" id="txtXiaDanShiJian2"
                        onfocus="WdatePicker()" />
                    支付状态：
                    <select id="txtFuKuanStatus" class="inputselect" name="txtFuKuanStatus">
                        <option value="">--请选择--</option>
                        <option value="0">未支付</option>
                        <option value="2">已支付</option>                        
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
    
    <div class="btnbox"></div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th align="center" style="width:9%;">
                    订单号
                </th>
                <th align="center" style="width:15%;">
                    客户单位|下单人
                </th>
                <th align="center">
                    商品名称
                </th>
                <%--<th align="center" style="width:7%;">
                    商品编码
                </th>--%>
                <th align="center" width="7%">
                    联系人
                </th>
                <th width="7%" align="center">
                    联系电话
                </th>
                <th width="7%" align="center">
                    联系手机
                </th>
                <th width="7%" align="center">
                    兑换数量
                </th>
                <th width="7%" align="center">
                    订单状态
                </th>
                <%--<th width="9%" align="center">
                    兑换时间
                </th>--%>
                <th width="7%" align="right">
                    支付金额&nbsp;
                </th>
                <th width="7%" align="center">
                    支付状态
                </th>
                <th width="6%" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-dingdanid="<%#Eval("DingDanId") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#Eval("JiaoYiHao")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="xiadanrenkehuname"><%#Eval("XiaDanRenKeHuName") %></a>                            
                            <span style="display:none;">
                            下单人客户单位：<%#Eval("XiaDanRenKeHuName") %><br />
                            下单人姓名：<%#Eval("XiaDanRenXingMing") %><br />
                            兑换时间：<%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}") %>
                            </span>
                        </td>
                        <td align="center">
                            <a class="shangpingmingcheng"><%#Eval("ShangPinMingCheng") %></a>
                            <span style="display:none;">
                            商品名称：<%#Eval("ShangPinMingCheng") %><br />
                            商品编码：<%#Eval("ShangPinBianMa") %>
                            </span>
                        </td>
                        <%--<td align="center">
                            <%#Eval("ShangPinBianMa") %>
                        </td>--%>
                        <td align="center">
                            <%#Eval("LxrXingMing")%>
                        </td>
                        <td align="center">
                            <%#Eval("LxrDianHua")%>
                        </td>
                        <td align="center">
                            <%#Eval("LxrShouJi")%>
                        </td>
                        <td align="center">
                            <%#Eval("ShuLiang")%>
                        </td>
                        <td align="center">
                            <%#Eval("Status")%>
                        </td>
                        <%--<td align="center">
                            <%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}")%>
                        </td>--%>
                        <td align="right">
                            <%#Eval("FuKuanJinE","{0:F2}")%>&nbsp;
                        </td>
                        <td align="center">
                            <%#GetFuKuanStatus(Eval("FuKuanStatus"))%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="15" style="height: 30px; text-align: center;">
                        暂无任何兑换订单信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                
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
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtDingDanId: _$tr.attr("data-dingdanid") };

                if (!confirm("兑换订单信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "jifendingdan.aspx?dotype=shanchu", dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });
            },
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-dingdanid") };
                var _title = "兑换订单管理";
                Boxy.iframeDialog({ title: _title, iframeUrl: "jifendingdanedit.aspx", width: "870px", height: "440px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".i_xiugai").click(function() { iPage.xiuGai(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });

            $('.xiadanrenkehuname').bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 400, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            $('.shangpingmingcheng').bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 400, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
        });
    </script>
</asp:Content>
