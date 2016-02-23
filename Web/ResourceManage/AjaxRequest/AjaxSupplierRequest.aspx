<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxSupplierRequest.aspx.cs"
    Inherits="Web.ResourceManage.AjaxRequest.AjaxSupplierRequest" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<style type="text/css">
    #tblList
    {
        border-collapse: collapse;
    }

    #tblList td
    {
        border: 1px #b8c5ce solid;
        padding: 0 3px;
    }
</style>
<!--paopao start-->

<script type="text/javascript">
    $(function() {
        $('#tblList').find("a[data-contact='contact']").bt({
            contentSelector: function() {
                return $(this).prev("span").html();
            },
            positions: ['right', 'left'],
            fill: '#FFFFFF',
            strokeStyle: '#85D0F4',
            noShadowOpts: { strokeStyle: "#85D0F4" },
            spikeLength: 5,
            spikeGirth: 15,
            width: 375,
            overlap: 0,
            centerPointY: 4,
            cornerRadius: 4,
            shadow: true,
            shadowColor: 'rgba(0,0,0,.5)',
            cssStyles: { color: '#00387E', 'line-height': '200%' }
        });
    });
</script>

<!--paopao end-->
<table width="100%" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" align="center"
    id="tblList" style="margin: 0 auto" class="tablelist">
    <tr class="">
        <asp:repeater runat="server" id="RptList">
             <ItemTemplate>
                <td align="left" height="30px" width="25%">
            <input name="1" type="radio" value="<%#Eval("Id") %>" data-show="<%#Eval("UnitName")%>" data-list='<%# GetContactList(Eval("SupplierContact"))%>' data-contactname="<%#GetContactInfo(Eval("SupplierContact"),"name")%>" data-fax="<%#GetContactInfo(Eval("SupplierContact"),"fax")%>" data-tel="<%#GetContactInfo(Eval("SupplierContact"),"tel")%>" <%#Eval("UnitName")==Request.QueryString["name"]?"checked=checked":"" %> /> 
                    <span style="cursor:pointer; z-index:9999; display:none;" bt-xtitle="" title=""><%#GetContactInfo(Eval("SupplierContact"), "list", Eval("Id").ToString(), Eval("UnitName").ToString())%></span>
                <a href="javascript:void(0);" data-contact="contact"><%#Eval("UnitName")%></a>
             <%#EyouSoft.Common.Utils.IsOutTrOrTd(Container.ItemIndex,recordCount,4) %>
            </ItemTemplate>  
        </asp:repeater>
        <asp:literal runat="server" id="lbemptymsg"></asp:literal>
        <tr>
            <td height="23" align="right" class="alertboxTableT" colspan="4">
                <div style="position: relative; z-index:1 height: 32px;">
                    <div class="pages" id="div_AjaxPage">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </div>
                </div>
            </td>
        </tr>
</table>
