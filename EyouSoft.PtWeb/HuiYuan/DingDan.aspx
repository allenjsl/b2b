<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDan.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.DingDan"
    MasterPageFile="~/MP/HuiYuan.Master" Title="订单中心" %>

<%@ Register Src="~/WUC/ZxsXuanZe.ascx" TagName="ZxsXuanZe" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10"></div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">订单中心</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 订单管理 &gt;&gt; 订单中心
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="hr_10">
    </div>
    <table width="100%" align="center" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td width="10" valign="top">
                <img src="/huiyuan/images/yuanleft.gif">
            </td>
            <td>
                <div class="searchbox" style="height:60px; line-height:30px;">
                    <form method="get">
                    出团日期： <span class="date_bk">
                        <input type="text" class="d_input" id="txtQuDate1" name="txtQuDate1" onfocus="WdatePicker()"
                            style="width: 80px"><a class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate1'})"></a></span>
                    - <span class="date_bk">
                        <input type="text" class="d_input" id="txtQuDate2" name="txtQuDate2" onfocus="WdatePicker()"
                            style="width: 80px"><a class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate2'})"></a></span>
                    供应商：<select name="txtZxs" id="txtZxs"><option value="">-请选择-</option><asp:Literal runat="server" ID="ltrZxs"></asp:Literal></select><uc1:ZxsXuanZe runat="server" id="txtZxs"></uc1:ZxsXuanZe>
                    游客姓名：<input type="text" size="12" id="txtYouKeName" class="formsize120 searchinput"
                        name="txtYouKeName" style="width: 80px;">
                    <br />
                    订单状态：<select name="txtDingDanStatus" id="txtDingDanStatus">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.OrderStatus),new string[]{"2"}), "")%>
                    </select>
                    业务类型：<select name="txtYeWuLeiXing" id="txtYeWuLeiXing">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.BusinessType)), "")%>
                    </select>
                    结清状态：<select name="txtJieQingStatus" id="txtJieQingStatus">
                        <option value="">-请选择-</option>
                        <option value="0">未结清</option>
                        <option value="1">已结清</option>
                    </select>
                    <input type="image" src="/huiyuan/images/searchbtn.gif" />
                    </form>
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/huiyuan/images/yuanright.gif">
            </td>
        </tr>
    </table>
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <th align="center" style="width:40px;">
                序号
            </th>
            <th align="center" style="width:80px;">
                订单号/状态
            </th>
            <th align="center" style="width:80px;">
                预订人/时间
            </th>
            <th align="center" style="width: 80px;">
                出团日期
            </th>
            <th align="left">
                线路名称
            </th>
            <th align="center" style="width:75px;">
                人数
            </th>
            <th style="width:80px; text-align:right;">
                应付金额&nbsp;
            </th>
            <th align="center" style="width: 75px; text-align: right;">
                已付金额&nbsp;
            </th>
            <th align="center" style="width: 75px; text-align: right;">
                未付金额&nbsp;
            </th>
            <th align="left">
                供应商
            </th>
            <th align="center" style="width: 100px;">
                对方操作人/时间
            </th>
            <th width="105" align="center">
                操作
            </th>
        </tr>
        
        <asp:Repeater runat="server" ID="rptDingDan" onitemdatabound="rptDingDan_ItemDataBound">
        <ItemTemplate>
        <tr class="table_tr_item" data-dingdanid="<%#Eval("DingDanId") %>">
            <td align="center">
                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
            </td>
            <td align="left">
                <asp:Literal runat="server" ID="ltrDingDanStatus"></asp:Literal><br />
                <%#Eval("JiaoYiHao") %>                
            </td>
            <td align="left">
                <%#Eval("KeHuLxrName") %><br />
                <%#Eval("XiaDanShiJian","{0:yyyy-MM-dd}") %>
            </td>
            <td align="center">
                <%#Eval("QuDate","{0:yyyy-MM-dd}") %>
            </td>
            <td align="left">
                <asp:Literal runat="server" ID="ltrRouteName"></asp:Literal>
                <asp:Literal runat="server" ID="ltrJiFen"></asp:Literal>
            </td>
            <td align="center">
                <%#Eval("ChengRenShu") %>大
                <%#Eval("ErTongShu") %>小<br />
                <%#Eval("YingErShu") %>婴
                <%#Eval("QuanPeiShu") %>陪
            </td>
            <td style="text-align:right;">
                <%#Eval("JinE","{0:F2}") %>&nbsp;
            </td>
            <td style="text-align: right;">
                <%#Eval("YiZhiFuJinE","{0:F2}") %>&nbsp;
            </td>
            <td style="text-align: right;">
                <%#Eval("WeiZhiFuJinE","{0:F2}") %>&nbsp;
            </td>
            <td align="left">
                <%#Eval("ZxsName") %>
            </td>
            <td align="left">
                <asp:Literal runat="server" ID="ltrZxsCaoZuoRenXinXi"></asp:Literal>
            </td>
            <td align="left">
                <asp:Literal runat="server" ID="ltrCaoZuo"></asp:Literal>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        
        <asp:PlaceHolder runat="server" ID="phHeJi" Visible="false">
            <tr>
                <td colspan="20" style="font-size: 30px; color: #666;">
                    
                </td>
            </tr>
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
            <tr>
                <td colspan="20" style="font-size: 30px; color: #666;">
                    <br />
                    <br />
                    <br />
                    抱歉，未找到任何订单信息！<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </asp:PlaceHolder>
    </table>
    
    <asp:PlaceHolder ID="phPaging" runat="server">
        <div class="page mt15">
            <cc1:ExporPageInfoSelect ID="paging" runat="server" />
        </div>
    </asp:PlaceHolder>
    
    <script type="text/javascript">
        var iPage = {
            caoZuo: function(obj) {
                var _fs = $(obj).attr("data-fs");
                var _$tr = $(obj).closest("tr");
                var _dingDanId = _$tr.attr("data-dingdanid");
                switch (_fs) {
                    case "chakan":
                    case "quxiao":
                    case "huifu":
                        window.location.href = "xianluyuding.aspx?dingdanid=" + _dingDanId;
                        break;
                    case "mingdan":
                        window.location.href = "/danju/youkemingdan.aspx?dingdanid=" + _dingDanId;
                        break;
                    case "fapiao":
                        var _data = { dingdanid: _dingDanId };
                        top.Boxy.iframeDialog({ title: "查看发票信息", iframeUrl: "fapiao.aspx", width: "770px", height: "340px", data: _data, afterHide: function() {  } });
                        return false;
                        break;
                }

                return false;
            }
        };

        $(document).ready(function() {
            $("a[data-class='caozuo']").click(function() { return iPage.caoZuo(this); });
            $("a[data-class='caozuo'][data-fs='yuanyin']").bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            utilsUri.initSearch();
        });
    </script>
</asp:Content>
