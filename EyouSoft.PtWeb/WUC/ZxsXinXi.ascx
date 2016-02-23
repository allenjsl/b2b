<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZxsXinXi.ascx.cs" Inherits="EyouSoft.PtWeb.WUC.ZxsXinXi" %>

<div class="msg_box mt15">
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td width="100" class="Rline">
                <span class="lianxi">供应商</span>
            </td>
            <td align="center" class="Rline" width="180" style="width:180px; text-align:left;">
                <strong class="fontred"><asp:Literal runat="server" ID="ltrZxsXinXiMingCheng"></asp:Literal></strong>
            </td>            
            <td class="Rline">
                <div class="qqlist fixed">
                    <strong>在线客服：</strong>
                    <ul>
                        <asp:Literal runat="server" ID="ltrZxsXinXiQQ"></asp:Literal>
                    </ul>
                </div>
            </td>
            <td width="190" align="right">
                <a class="lianxi" href="javascript:void(0)" id="i_a_lianxifangshi">联系方式</a><div style="display:none"><asp:Literal runat="server" ID="ltrLianXiFangShi">暂无联系方式信息</asp:Literal></div><a class="zhhao" href="javascript:void(0)" id="i_a_yinhangzhanghao">银行账号</a><div style="display: none"><asp:Literal runat="server" ID="ltrYinHangZhangHao">暂无银行账号信息</asp:Literal></div>
            </td>
        </tr>
    </table>
</div>

<script type="text/javascript">
    $(document).ready(function() {
        $('#i_a_lianxifangshi,#i_a_yinhangzhanghao').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 550, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
    });
</script>
