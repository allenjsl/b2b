<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RouteSelect.ascx.cs"
    Inherits="Web.UserControl.RouteSelect" %>
<div id="divRouteSelect" style="display:none;">
    <asp:Literal runat="server" ID="ltrRoute">线路名称：</asp:Literal>
    <input name="txtRouteName" type="text" class="inputtext" id="txtRouteName"
        readonly="readonly" style="background-color: #dadada; width:300px;" value="<%= InitRouteName %>" <%if(IsMust){ %><%=NoticeHTML %><%} %> />
    <input type="hidden" id="<%= HidClientId %>" name="<%= HidClientName %>" value="<%= InitRouteId %>" />
    <a title="选用线路" href="javascript:void(0);" id="a_SelectRoute">
        <img src="/images/sanping_04.gif" width="28" height="18" style="vertical-align: top;"
            alt="选用" /></a>
    
    <a href="javascript:void(0)" id="i_a_jihuaneixianlu" data-lx="jihuanei">选择计划内线路产品</a>
</div>

<script type="text/javascript">
    var RouteSelect = {
        SelectCallBack: function(args) {
            if (args == null || args.length == 0) return;
            if ("<%= IsMoreSelect %>" == "True") {//多选
                var rids = [], rnames = [];
                for (var i = 0; i < args.length; i++) {
                    rids.push(args[i].rid);
                    rnames.push(args[i].rname);
                }
                $("#<%= HidClientId %>").val(rids.join(','));
                $("#txtCustomerName").val(rnames.join(','));
            }
            else { // 单选
                $("#<%= HidClientId %>").val(args[0].rid);
                $("#txtRouteName").val(args[0].rname);
                PlanPage.initRouteXinXi(args[0].rid, "");
            }
        },
        SelectRoute: function() {
            var url = "/CommonPage/SelectRoute.aspx?";
            var data = {};
            data.initId = $("#<%= HidClientId %>").val();
            data.callBack = "RouteSelect.SelectCallBack";
            data.pIframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
            data.isMore = "<%= IsMoreSelect ? 1 : 0 %>";
            parent.Boxy.iframeDialog({
                iframeUrl: url + $.param(data),
                title: "选择线路",
                modal: true,
                width: "860",
                height: "378"
            });
        }
    };

    $(document).ready(function() {
        $("#txtRouteName").bind("click", function() {
            RouteSelect.SelectRoute();
            return false;
        });
        $("#a_SelectRoute").bind("click", function() {
            RouteSelect.SelectRoute();
            return false;
        });
    });
</script>

