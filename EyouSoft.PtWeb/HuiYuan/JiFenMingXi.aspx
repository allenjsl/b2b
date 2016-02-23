<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenMingXi.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.JiFenMingXi"
    MasterPageFile="~/MP/HuiYuan.Master" Title="积分记录" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10">
    </div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">积分明细</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 我的积分 &gt;&gt; 积分明细
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="yg_bar mt15">
        <ul>
            <li><a href="jifenmingxi.aspx" id="i_li_jifenmingxi">全部记录</a></li>
            <li><a href="jifenmingxi.aspx?txtStatus=0" id="i_li_jifenmingxi_0">冻结积分</a></li>
            <li style="line-height:28px;"> 您当前的可用积分为：<b> <asp:Literal runat="server" ID="ltrKeYongJiFen">0</asp:Literal> </b>分，冻结积分为：<b style="color:#ff0000"> <asp:Literal
                runat="server" ID="ltrDongJieJiFen">0</asp:Literal> </b>分</li>
        </ul>
        <div style="clear:both;"></div>
    </div> 
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <th align="center" style="width: 40px;">
                序号
            </th>
            <th align="center" >
                操作内容
            </th>
            <th align="center" style="width: 120px;">
                时间
            </th>
            <th align="right" style="width: 100px;">
                积分&nbsp;
            </th>
            <th align="center" style="width: 100px;">
                状态
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptJiFenMingXi" OnItemDataBound="rptJiFenMingXi_ItemDataBound">
            <ItemTemplate>
                <tr class="table_tr_item">
                    <td align="center">
                        <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                    </td>
                    <td align="left">
                        <asp:Literal runat="server" ID="ltrJiFenMingXi"></asp:Literal>
                    </td>
                    <td align="center">
                        <%#Eval("JiFenShiJian","{0:yyyy-MM-dd HH:mm}") %>
                    </td>                    
                    <td align="right">
                        <%#Eval("JiFen") %>&nbsp;
                    </td>
                    <td align="center">
                        <%#GetJiFenStatus(Eval("JiFenStatus"))%>
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
                    抱歉，未找到任何积分记录！<br />
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
        $(document).ready(function() {
            if ('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtStatus") %>' == '0')$("#i_li_jifenmingxi_0").addClass("current");
            else  $("#i_li_jifenmingxi").addClass("current");
        })
    </script>
</asp:Content>
