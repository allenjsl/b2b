<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenShouFuKuanMingXi.aspx.cs" Inherits="Web.TongJi.JiFenShouFuKuanMingXi" MasterPageFile="~/MasterPage/Front.Master" Title="积分收付款明细表-统计分析"%>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">统计分析</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 统计分析 >> 积分收付款明细表
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
                    登记日期：<input name="txtDengJiRiQi1" type="text" class="formsize80 inputtext" id="txtDengJiRiQi1"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtDengJiRiQi2" type="text" class="formsize80 inputtext" id="txtDengJiRiQi2"
                        onfocus="WdatePicker()" />
                    审批状态：<select name="txtStatus" id="txtStatus" class="inputselect">
                        <option value="">--请选择--</option>
                        <option value="0">未审批</option>
                        <option value="1">已审批</option>
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
                <th align="center" width="10%">
                    登记日期
                </th>
                <th width="10%" align="center">
                    类型
                </th>
                <th align="center">
                    银行账号
                </th>                
                <th width="10%" align="center">
                    往来单位
                </th>
                <th width="10%" align="right">
                    借方&nbsp;
                </th>
                <th width="10%" align="right">
                    贷方&nbsp;
                </th>
                <th width="10%" align="center">
                    备注
                </th>
                <th width="10%" align="center">
                    状态
                </th>
                <th width="10%" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-mxid="<%#Eval("MxId") %>" data-leixing="<%#(int)Eval("LeiXing") %>" data-zxsid="<%#Eval("ZxsId") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#Eval("DengJiRiQi","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%#Eval("LeiXing")%>
                        </td>
                        <td align="center">
                            <%#Eval("YinHangZhaoHao") %>
                        </td>                        
                        <td align="center">
                            <%#Eval("WangLaiDanWei")%>
                        </td>
                        <td align="right">
                            <%#GetJieFangJInE(Eval("JieFangJinE"),Eval("LeiXing"))%>&nbsp;
                        </td>
                        <td align="right">
                            <%#GetDaiFangJInE(Eval("DaiFangJinE"),Eval("LeiXing"))%>&nbsp;
                        </td>
                        <td align="center">
                            <%#Eval("BeiZhu") %>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("Status"),Eval("LeiXing")) %>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何积分收付款明细信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td colspan="5" style="text-align:right; height:30px;">合计：</td>
                    <td style="text-align:right;"><asp:Literal runat="server" ID="ltrJieFangJinEHeJi"></asp:Literal>&nbsp;</td>
                    <td style="text-align:right;"><asp:Literal runat="server" ID="ltrDaiFangJinEHeJi"></asp:Literal>&nbsp;</td>
                    <td colspan="3"></td>
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
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtMxId: _$tr.attr("data-mxid"), txtLeiXing: _$tr.attr("data-leixing"), txtZxsId: _$tr.attr("data-zxsid") };
                var _confirmMsg = "审批操作不可撤销，你确定要审批该兑换商品的支付款信息吗？";
                if (_data.txtLeiXing == "<%=(int)EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分 %>") {
                    _confirmMsg = "审批操作不可撤销，你确定要审批该积分结算收款信息吗？";
                }
                if (!confirm(_confirmMsg)) return false;

                $.newAjax({
                    type: "post", cache: false, url: "JiFenShouFuKuanMingXi.aspx?dotype=shenpi", dataType: "json",
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
            quXiaoShenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtMxId: _$tr.attr("data-mxid"), txtLeiXing: _$tr.attr("data-leixing"), txtZxsId: _$tr.attr("data-zxsid") };
                var _confirmMsg = "取消审批操作不可撤销，你确定要取消审批该兑换商品的支付款信息吗？";
                if (_data.txtLeiXing == "<%=(int)EyouSoft.Model.EnumType.PtStructure.JiFenShouFuKuanMxLeiXing.结算积分 %>") {
                    _confirmMsg = "取消审批操作不可撤销，你确定要取消审批该积分结算收款信息吗？";
                }
                if (!confirm(_confirmMsg)) return false;

                $.newAjax({
                    type: "post", cache: false, url: "JiFenShouFuKuanMingXi.aspx?dotype=quxiaoshenpi", dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".i_shenpi").click(function() { iPage.shenPi(this); });
            $(".i_quxiaoshenpi").click(function() { iPage.quXiaoShenPi(this); });
        });
    </script>
</asp:Content>
