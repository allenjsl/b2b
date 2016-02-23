<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenDingDanXX.aspx.cs"
    Inherits="EyouSoft.PtWeb.HuiYuan.JiFenDingDanXX" MasterPageFile="~/MP/HuiYuan.Master"
    Title="兑换订单明细" %>

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
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <td colspan="4" style="font-weight: bold; font-size: 16px; text-align: center;">
                <asp:Literal runat="server" ID="ltrShangPinMingCheng"></asp:Literal>
                
            </td>
        </tr>
        <tr>
            <td style="width: 120px;" class="td_jifenxx_biaoti">
                商品类型：
            </td>
            <td style="width: 39%">
                <asp:Literal runat="server" ID="ltrShangPinLeiXing"></asp:Literal>
            </td>
            <td style="width: 120px;" class="td_jifenxx_biaoti">
                市场价格：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShangPinJiaGe"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_jifenxx_biaoti">
                所需积分：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShangPinJiFen"></asp:Literal>
            </td>
            <td class="td_jifenxx_biaoti">
                商品编码：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShangPinBianMa"></asp:Literal>
            </td>
        </tr>
    </table>
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <td style="width: 120px;" class="td_jifenxx_biaoti">
                订单号：
            </td>
            <td style="width: 39%">
                <asp:Literal runat="server" ID="ltrJiaoYiHao"></asp:Literal>
            </td>
            <td style="width: 120px;" class="td_jifenxx_biaoti">
                兑换数量：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShuLiang"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_jifenxx_biaoti">
                兑换积分(单)：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrJiFen1"></asp:Literal>
            </td>
            <td class="td_jifenxx_biaoti">
                兑换积分(总)：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrJiFen2"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_jifenxx_biaoti">
                收件人姓名：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShouJianRenName"></asp:Literal>
            </td>
            <td class="td_jifenxx_biaoti">
                收件人手机：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShouJianRenShouJi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_jifenxx_biaoti">
                收件人电话：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShouJianRenDianHua"></asp:Literal>
            </td>
            <td class="td_jifenxx_biaoti">
                收件人地址：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShouJianRenDiZhi"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_jifenxx_biaoti">
                收件人邮箱：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShouJianRenYouXiang"></asp:Literal>
            </td>
            <td class="td_jifenxx_biaoti">
                收件人邮编：
            </td>
            <td>
                <asp:Literal runat="server" ID="ltrShouJianRenYouBian"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="td_jifenxx_biaoti">
                下单备注：
            </td>
            <td colspan="3">
                <asp:Literal runat="server" ID="ltrXiaDanBeiZhu"></asp:Literal>
            </td>
        </tr>        
    </table>
    
    <div style="margin-top: 10px; color: #2f2f2f;">
        <b>
            <asp:Literal runat="server" ID="ltrTiShiXinXi"></asp:Literal></b>
    </div>
    
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 0px auto;
        margin-top: 15px; margin-bottom: 15px;">
        <tr>
            <td style="text-align: left;">
                <asp:Literal runat="server" ID="ltrCaoZuo"></asp:Literal>
                <a href="jifendingdan.aspx" class="baocun">返 回</a>
            </td>
        </tr>
    </table>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            quXiao: function(obj) {
                var _data = {  };
                if (!confirm("取消操作不可恢复，你确定要取消该兑换订单吗？")) return false;
                var _self = this;
                $(obj).unbind("click").text("正在处理");
                $.ajax({ type: "post", url: window.location.href + "&dotype=quxiao", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        $(obj).click(function() { return _self.quXiao(this); }).text("取 消");
                        if (response.result == "1") _self.reload();
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_quxiao").click(function() { iPage.quXiao(this); });
        });
    </script>
    
</asp:Content>
