<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerUnit.ascx.cs"
    Inherits="Web.UserControl.CustomerUnit" %>

<script type="text/javascript" src="/JS/json2.js"></script>

<input type="text" id="txtCustomerName" class="formsize120 inputtext" name="txtCustomerName"
    readonly="readonly" style="background-color: #dadada" value="<%= InitCustomerName %>"
    <%=IsRequired?" valid='required' errmsg='请选择客户单位!' ":" " %> />
<a href="javascript:void(0);" id="a_SelectCustomer">
    <img width="28" height="18" style="vertical-align: top;" src="/images/sanping_04.gif"
        alt="选用" />
</a>
<input type="hidden" name="<%= HidClientName %>" id="<%= HidClientId %>" value="<%= InitCustomerId %>" />
<input type="hidden" name="<%= HidContactClientName %>" id="<%= HidContactClientId %>" />
<input type="hidden" name="<%= HidNoContactClientName %>" id="<%= HidNoContactClientId %>" />

<script type="text/javascript">
    var CustomerUnit = {
        //初始化对方操作人
        InitCustomerContactControl: function(args) {
            if (args == null || args.length == 0) return;
            var controlId = "<%= CustomerContactControlClientId %>";
            if (controlId == "" || controlId.length <= 0) return;

            $("#" + controlId).html();
            var strHtml = '<option value="0">请选择</option>';
            for (var i = 0; i < args.length; i++) {
                if (args[i].cclist == "" || $.trim(args[i].cclist) == "" || $.trim(args[i].cclist).length <= 0) continue;
                var cclist = JSON.parse(args[i].cclist)
                if (cclist == null || cclist.length <= 0) continue;
                for (var j = 0; j < cclist.length; j++) {
                    strHtml += '<option value="' + cclist[j].ccId + '">' + cclist[j].ccname + '</option>'
                }
            }
            $("#" + controlId).html(strHtml);
        },
        SelectCallBack: function(args) {
            if (args == null || args.length == 0) return;
            if ("<%= IsMoreSelect %>" == "True") {//多选
                var cids = [], cnames = [], ccinfo = [], cclists = [];
                for (var i = 0; i < args.length; i++) {
                    cids.push(args[i].cid);
                    cnames.push(args[i].cname);
                    ccinfo.push(args[i].ccname + "," + args[i].cctel + "," + args[i].ccmobile);
                    cclists.push(args[i].cclist);
                }
                $("#<%= HidClientId %>").val(cids.join(','));
                $("#txtCustomerName").val(cnames.join(','));
                $("#<%= HidContactClientId %>").val(ccinfo.join('|'));
                $("#<%= HidNoContactClientId %>").val(cclists.join('|'));
            }
            else { // 单选
                $("#<%= HidClientId %>").val(args[0].cid);
                $("#txtCustomerName").val(args[0].cname);
                $("#<%= HidContactClientId %>").val(args[0].ccname + "," + args[0].cctel + "," + args[0].ccmobile);
                $("#<%= HidNoContactClientId %>").val(args[0].cclist);
            }

            CustomerUnit.InitCustomerContactControl(args);
        },
        SelectCustomr: function() {
            var url = "/CommonPage/CustomerUnitSelect.aspx?";
            var data = {};
            data.initId = $("#<%= HidClientId %>").val();
            data.callBack = "CustomerUnit.SelectCallBack";
            data.pIframeId = "<%= ParentIframeId %>";
            data.isMore = "<%= IsMoreSelect ? 1 : 0 %>";
            parent.Boxy.iframeDialog({
                iframeUrl: url + $.param(data),
                title: "选择客户单位",
                modal: true,
                width: "820",
                height: "378"
            });
        }
    };
    $(document).ready(function() {
        $("#txtCustomerName,#a_SelectCustomer").bind("click", function() {
            CustomerUnit.SelectCustomr();
            return false;
        });
    });
</script>

--%>