<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SheZhiDaoYou.aspx.cs" Inherits="Web.TeamPlan.SheZhiDaoYou"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="60" height="40" align="right">
                    导游：
                </th>
                <td style="background: #E3F1FC">
                    <%--<uc1:SellsSelect runat="server" ID="txtDaoYou" ReadOnly="true" IsShowSelect="true"
                        SetTitle="导游" />--%>
                    <input type="text" id="txtDaoYouName" name="txtDaoYouName" class="inputtext" style="width: 250px;" runat="server" valid="required" errmsg="请重新输入导游信息" data-class="daoyouxuanzeautocomplete"/>
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height:40px;">说明：</th>
                <td style="color: #666; background: #E3F1FC">建议录入格式如：张姐 13812345678</td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>    

    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            save: function(obj) {
                var _data = { txtDaoYouId: 0, txtDaoYouName: $.trim($("#<%=txtDaoYouName.ClientID %>").val()) };

                //var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                //if (!validatorResult) return false;

                if (_data.txtDaoYouName.length < 1) { alert("请输入导游"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=shezhidaoyou",
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#<%=txtDaoYouName.ClientID %>").attr("data-dijiesheid", "<%=DiJieSheId %>");
        });
    </script>
    

    <script data-main="/js/daoyouxuanze.main" src="/js/require.2.1.14.minified.js"></script>
    <link href="/js/jquery-ui.1.11.1/themes/redmond/jquery-ui.css" rel="stylesheet" type="text/css" />
</asp:Content>
