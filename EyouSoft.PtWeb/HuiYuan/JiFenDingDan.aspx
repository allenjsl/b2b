<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenDingDan.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.JiFenDingDan"
    MasterPageFile="~/MP/HuiYuan.Master" Title="我的兑换订单" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10">
    </div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">兑换订单</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 我的积分 &gt;&gt; 兑换订单
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
                <div class="searchbox">
                    <form method="get">
                    兑换时间：<span class="date_bk">
                                <input type="text" class="d_input" id="txtXiaDanShiJian1" name="txtXiaDanShiJian1"
                                    onfocus="WdatePicker()" style="width: 80px"><a class="ico" href="javascript:void(0)"
                                        onclick="WdatePicker({el:'txtXiaDanShiJian1'})"></a></span>
                    - <span class="date_bk">
                        <input type="text" class="d_input" id="txtXiaDanShiJian2" name="txtXiaDanShiJian2"
                            onfocus="WdatePicker()" style="width: 80px"><a class="ico" href="javascript:void(0)"
                                onclick="WdatePicker({el:'txtXiaDanShiJian2'})"></a></span>订单号：<input type="text" size="12" id="txtJiaoYiHao" class="formsize120 searchinput"
                                name="txtJiaoYiHao">
                    兑换状态：<select name="txtDingDanStatus" id="txtDingDanStatus">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenDingDanStatus)), "") %>
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
            <th align="center" style="width: 40px;">
                序号
            </th>
            <th align="center" style="width: 110px;">
                订单号
            </th>
            <th align="center" style="width: 70px;">
                状态
            </th>
            <th align="left">
                兑换商品
            </th>
            <th align="right" style="width: 70px;">
                兑换数量&nbsp;
            </th>
            <th align="right" style="width: 70px;">
                兑换积分&nbsp;
            </th>
            <th align="center" style="width: 70px;">
                联系人
            </th>
            <th align="center" style="width: 90px;">
                联系电话
            </th>
            <th align="center" style="width: 90px;">
                联系手机
            </th>
            <th align="center" style="width: 100px;">
                兑换时间
            </th>
            <th width="105" align="left">
                操作
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptDingDan">
            <ItemTemplate>
                <tr class="table_tr_item" data-dingdanid="<%#Eval("DingDanId") %>">
                    <td align="center">
                        <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                    </td>
                    <td align="center">
                        <%#Eval("JiaoYiHao")%>
                    </td>
                    <td align="center">
                        <%#GetJiFenDingDanStatus(Eval("Status"))%>
                    </td>
                    <td align="left">
                        <%#Eval("ShangPinMingCheng") %>
                    </td>
                    <td align="right">
                        <%#Eval("ShuLiang")%>&nbsp;
                    </td>
                    <td align="right">
                        <%#Eval("JiFen2")%>&nbsp;
                    </td>
                    <td style="text-align: center;">
                        <%#Eval("LxrXingMing")%>
                    </td>
                    <td align="center">
                        <%#Eval("LxrDianHua")%>
                    </td>
                    <td align="center">
                        <%#Eval("LxrShouJi")%>
                    </td>
                    <td style="text-align: center;">
                        <%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}")%>
                    </td>
                    <td align="left">
                        <%#GetCaoZuo(Eval("DingDanId"),Eval("Status")) %>
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
                    抱歉，未找到任何兑换订单信息！<br />
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

    };

    $(document).ready(function() {
        utilsUri.initSearch();
    });
    </script>

</asp:Content>
