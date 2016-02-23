<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZxsXuanZe.ascx.cs" Inherits="EyouSoft.PtWeb.WUC.ZxsXuanZe" %>

<input type="hidden" id="<%=ZxsIdClientId %>" name="<%=ZxsIdClientId %>" value="<%=ZxsId %>" />
<input type="text" data-class="zxsxuanzeautocomplete" class="<%=ClassName %>" style="width: <%=Width%>;"
    id="<%=ZxsNameClientId %>" name="<%=ZxsNameClientId %>" value="<%=ZxsName %>" />
    

<script type="text/javascript">
    $(document).ready(function() {
        var _options = {};
        _options["ZxsIdClientId"] = "<%=ZxsIdClientId %>";
        _options["ZxsNameClientId"] = "<%=ZxsNameClientId %>";

        $("#<%=ZxsNameClientId %>").data("options", _options);
    });
</script>

<script data-main="/js/zxsxuanzemain" src="/js/require.2.1.14.minified.js"></script>
<link href="/js/jquery-ui.1.11.1/themes/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />
