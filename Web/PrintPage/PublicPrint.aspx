<%@ Page Language="C#" MasterPageFile="~/MasterPage/Print.Master" AutoEventWireup="true"
    CodeBehind="PublicPrint.aspx.cs" Inherits="Web.PrintPage.PublicPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <div id="div_PublicPrint">
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            var win = window.opener;
            var printDivId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("printDivId") %>';
            if (win) {
                $("#div_PublicPrint").html($(win.document.getElementById(printDivId)).html());
                $("#div_PublicPrint").find(".unprint").replaceWith("");
            }
        });
    </script>

</asp:Content>
