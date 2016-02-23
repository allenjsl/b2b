<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DengZhangXiaoZhangDaoHang.ascx.cs" Inherits="Web.UserControl.DengZhangXiaoZhangDaoHang" %>
<div style="width:99%; margin:0px auto; margin-top:5px;">
    <a id="i_xz_leixing_1" href="DengZhangXiaoZhangDingDanKuan.aspx?dzid=<%=Request.QueryString["dzid"] %>&iframeId=<%=Request.QueryString["iframeId"] %>&leixing=1">销订单款</a>
    <a id="i_xz_leixing_2" href="DengZhangXiaoZhangTuiPiaoKuan.aspx?dzid=<%=Request.QueryString["dzid"]  %>&iframeId=<%=Request.QueryString["iframeId"] %>&leixing=2">销退票款</a>
    <a id="i_xz_leixing_3" href="DengZhangXiaoZhangTuiHuiYaJin.aspx?dzid=<%=Request.QueryString["dzid"]  %>&iframeId=<%=Request.QueryString["iframeId"] %>&leixing=3">销退回押金</a>
    <a id="i_xz_leixing_4" href="DengZhangXiaoZhangJieSuanQiTaShouRu.aspx?dzid=<%=Request.QueryString["dzid"]  %>&iframeId=<%=Request.QueryString["iframeId"] %>&leixing=4">销团队结算其它收入</a>
    <script type="text/javascript">
        $(document).ready(function() {$("#i_xz_leixing_" + '<%=EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("leixing"),1) %>').css({ "color": "#ff0000" });});
    </script>
</div>