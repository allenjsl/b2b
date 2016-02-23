<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.GysWeb.dijie.Default" MasterPageFile="~/mp/DiJie.Master" Title="计划中心" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10">
    </div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">计划中心</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 计划中心 &gt;&gt; 计划中心
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
                <img src="/images/yuanleft.gif">
            </td>
            <td>
                <div class="searchbox" style="height: 60px; line-height: 30px;">
                    <form method="get">
                    出团日期： <span class="date_bk">
                        <input type="text" class="d_input" id="txtQuDate1" name="txtQuDate1" onfocus="WdatePicker()" style="width: 80px"><a class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate1'})"></a></span> - <span class="date_bk">
                            <input type="text" class="d_input" id="txtQuDate2" name="txtQuDate2" onfocus="WdatePicker()" style="width: 80px"><a class="ico" href="javascript:void(0)" onclick="WdatePicker({el:'txtQuDate2'})"></a></span>
                    线路名称：<input type="text" size="12" id="txtDiJieRouteName" class="searchinput" name="txtDiJieRouteName" style="width: 150px;">           
                    确认状态：<select id="txtQueRenStatus" name="txtQueRenStatus">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.QueRenStatus)), "")%>
                    </select>
                    结清状态：<select id="txtJieQingStatus" name="txtJieQingStatus">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.JieQingStatus)), "")%>
                    </select>
                    <br />
                    专线商：<input type="text" id="txtZxsName" name="txtZxsName" class="searchinput" style="width:150px;" />
                    <input type="image" src="/images/searchbtn.gif" />
                    </form>
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif">
            </td>
        </tr>
    </table>
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <th align="center" style="width: 40px;">
                序号
            </th>
            <th align="left" style="width: 95px;">
                出团日期/团号
            </th>
            <th align="left" style="width:150px;">
                专线商/专线商操作人
            </th>  
            <th align="left">
                线路名称
            </th>
            <th align="center" style="width: 60px;">
                人数
            </th> 
            <th align="left" style="width: 120px;">
                价格明细
            </th>
            <th style="width: 80px; text-align: right;">
                结算金额&nbsp;
            </th>
            <th align="center" style="width: 75px; text-align: right;">
                已收金额&nbsp;
            </th>
            <th align="center" style="width: 75px; text-align: right;">
                未收金额&nbsp;
            </th> 
            <th align="center" style="width:75px;">
                确认状态
            </th>           
            <th width="110" align="center">
                操作
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rpt" >
            <ItemTemplate>
                <tr class="table_tr_item" data-anpaiid="<%#Eval("AnPaiId") %>">
                    <td align="center">
                        <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                    </td>
                    <td align="left">
                        <%#Eval("QuDate","{0:yyyy-MM-dd}") %><br />
                        <%#Eval("ZxsTuanHao") %>
                    </td>                      
                    <td align="left">
                        <%#Eval("ZxsName") %><br />
                        <%#Eval("ZxsCaoZuoRenName") %>&nbsp;<%#Eval("ZxsCaoZuoTime","{0:yyyy-MM-dd HH:mm}") %>
                    </td>
                    <td align="left">
                         <%#Eval("DiJieRouteName") %>
                    </td>
                    <td align="center">
                        <%#Eval("RenShuCR") %>大
                        <%#Eval("RenShuET")%>小<br />
                        <%#Eval("RenShuYE")%>婴
                        <%#Eval("RenShuQP")%>陪
                    </td>
                    <td align="left">
                        <%#Eval("JieSuanMingXi") %>
                    </td>
                    <td style="text-align: right;">
                       <%#Eval("JinE","{0:F2}") %>
                    </td>
                    <td style="text-align: right;">
                       <%#Eval("YiShouJinE","{0:F2}") %>
                    </td>
                    <td style="text-align: right;">
                         <%#Eval("WeiShouJinE","{0:F2}") %>
                    </td>
                    <td style="text-align: center;">
                         <%#Eval("DiJieQueRenStatus") %>
                    </td>
                    <td align="left">
                        <%#GetCaoZuo(Eval("AnPaiId"),Eval("DiJieQueRenStatus"))%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:PlaceHolder runat="server" ID="phHeJi" Visible="false">
            <tr>
                <td colspan="4" style="color: #666; text-align:right;">合计：</td>
                <td style="text-align:center;"><asp:Literal runat="server" ID="ltrRenShuHeJi"></asp:Literal></td>
                <td></td>
                <td style="text-align:right;"><asp:Literal runat="server" ID="ltrJinEHeJi"></asp:Literal></td>
                <td style="text-align: right;"><asp:Literal runat="server" ID="ltrYiShouJinEHeJi"></asp:Literal></td>
                <td style="text-align: right;"><asp:Literal runat="server" ID="ltrWeiShouJinEHeJi"></asp:Literal></td>
                <td colspan="2"></td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
            <tr>
                <td colspan="20" style="font-size: 30px; color: #666;">
                    <br />
                    <br />
                    <br />
                    抱歉，未找到任何计划信息！<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </asp:PlaceHolder>
    </table>
    
    <asp:PlaceHolder ID="phFenYe" runat="server">
        <div class="page mt15">
            <cc1:ExporPageInfoSelect ID="fenYe" runat="server" />
        </div>
    </asp:PlaceHolder>
    
    
    <script type="text/javascript">
        var iPage = {
            caoZuo: function(obj) {
                var _fs = $(obj).attr("data-fs");
                var _$tr = $(obj).closest("tr");
                var _anPaiId = _$tr.attr("data-anpaiid");

                var _url = "jihuaxx.aspx?anpaiid=" + _anPaiId;
                if (_fs == "mingdan") _url += "#youkemingdan"

                window.location.href = _url;

                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("a[data-class='caozuo']").click(function() { return iPage.caoZuo(this); });
        });
    </script>
</asp:Content>
