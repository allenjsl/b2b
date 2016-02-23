<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaPiao.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.FaPiao"
    MasterPageFile="~/MP/HuiYuanBoxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageMain" ID="PageMain1">
    <table cellspacing="0" cellpadding="0" border="0" class="tablelist" style="width: 99%;
        margin: 0px auto; margin-top: 5px;">
        <tr>
            <td style="width: 100px; text-align: right;">
                订单号：
            </td>
            <td style="width:35%">
                <asp:Literal runat="server" ID="ltrDingDanHao"></asp:Literal>
            </td>
            <td style="width: 100px; text-align: right;">
                出团日期：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrQuDate"></asp:Literal>
            </td>            
        </tr>
        <tr>
            <td style="text-align: right;">
                发票抬头：
            </td>
            <td >
                <asp:Literal runat="server" ID="ltrTaiTou"></asp:Literal>
            </td>
            <td style="text-align: right;">
                发票金额：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrJinE"></asp:Literal>
            </td>            
        </tr>
        <tr>
            <td style="text-align: right;">
                发票号：
            </td>
            <td >
                <asp:Literal runat="server" ID="ltrFaPiaoHao"></asp:Literal>
            </td>
            <td style="text-align: right;">
                开票单位：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrKaiPiaoDanWei"></asp:Literal>
            </td>            
        </tr>
        <tr>
            <td style="text-align: right;">
                发票明细：
            </td>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltrMingXi"></asp:Literal>
            </td>      
        </tr>
        <tr>
            <td style="text-align: right;">
                送出状态：
            </td>
            <td >
                <asp:Literal runat="server" ID="ltrFaSongStatus"></asp:Literal>
            </td>
            <td style="text-align: right;">
                送出时间：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrFaSongShiJian"></asp:Literal>
            </td>            
        </tr>   
        <tr>
            <td style="text-align: right;">
                送出方式：
            </td>
            <td >
                <asp:Literal runat="server" ID="ltrFaSongFangShi"></asp:Literal>
            </td>
            <td style="text-align: right;">
                邮寄公司：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrFaSongYouJiGongSi"></asp:Literal>
            </td>            
        </tr>  
        <tr>
            <td style="text-align: right;">
                邮寄单号：
            </td>
            <td >
                <asp:Literal runat="server" ID="ltrFaSongYouJiDanHao"></asp:Literal>
            </td>
            <td style="text-align: right;">
                签收人：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrQianShouRen"></asp:Literal>
            </td>            
        </tr>     
         <tr>
            <td style="text-align: right;">
                签收时间：
            </td>
            <td >
                <asp:Literal runat="server" ID="ltrQianShouShiJian"></asp:Literal>
            </td>
            <td style="text-align: right;">
                
            </td>
            <td>
                
            </td>            
        </tr>     
    </table>
</asp:Content>
