<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KeHuXuanZe.ascx.cs" Inherits="Web.UserControl.KeHuXuanZe" %>

<input type="hidden" id="<%=KeHuIdClientId %>" name="<%=KeHuIdClientName %>" value="<%=KeHuId %>" />
<input type="text" data-class="kehuxuanzeautocomplete" class="inputtext" style="width:<%=Width%>;"  id="<%=KeHuMingChengClientId %>" name="<%=KeHuMingChengClientName %>" value="<%=KeHuMingCheng %>" />
<a href="javascript:void(0);" id="<%=AClinetId %>"><img width="28" height="18" style="vertical-align:middle;" src="/images/sanping_04.gif" alt="选用" /></a>

<script type="text/javascript">
    $(document).ready(function() {
        var _options = {};
        _options["KeHuIdClientId"] = "<%=KeHuIdClientId %>";
        _options["KeHuMingChengClientId"] = "<%=KeHuMingChengClientId %>";
        _options["RefererIframeId"] = '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
        _options["CallbackFn"] = "<%=CallbackFn %>";
        _options["DuiFangCaoZuoRenClientId"] = "<%=DuiFangCaoZuoRenClientId %>";

        $("#<%=AClinetId %>").click(function() { wuc.keHuXuanZe(_options); });

        wuc.keHuXuanZe_InitDuiFangCaoZuoRen("<%=DuiFangCaoZuoRenClientId %>", "<%=KeHuIdClientId %>");

        $("#<%=KeHuMingChengClientId %>").data("options", _options);
    });
</script>

<script data-main="/js/kehuxuanzemain" src="/js/require.2.1.14.minified.js"></script>
<link href="/js/jquery-ui.1.11.1/themes/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />
