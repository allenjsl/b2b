<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuanXianLeiBieEdit.aspx.cs" Inherits="Web.PingTai.ZhuanXianLeiBieEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="100" height="30" align="right">
                    所属站点：
                </th>
                <td>
                    <select name="txtZhanDianId" id="txtZhanDianId" data-v="<%=ZhanDianId %>" valid="required" errmsg="请选择所属站点" class="inputselect">
                        <option value="">请选择</option>
                        <asp:Literal runat="server" ID="ltrZhanDianOption"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    专线类别名称：
                </th>
                <td>
                    <input name="txtMingCheng" type="text" class="formsize120 inputtext" id="txtMingCheng" runat="server"
                        valid="required" errmsg="请填写专线类别名称" maxlength="20" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    排序值：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtPaiXuId" type="text" class="inputtext" id="txtPaiXuId" runat="server" value="0" maxlength="5" style="width:100px;" />
                    <span style="color:#666">(按值升序排列)</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    状态：
                </th>
                <td>
                    <select name="txtStatus" id="txtStatus" data-v="<%=ZhuangTai %>" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.ZhuanXianLeiBieStatus)),"")%>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    可见状态：
                </th>
                <td>
                    <select name="txtT2" id="txtT2" data-v="<%=T2 %>" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.ZxsT2)),"")%>
                    </select>
                </td>
            </tr>
        </table>
        <div style="width: 99%; margin: 0 auto; color:#666; line-height:24px; margin-top:10px;">
            说明：可见状态[仅专线商系统]时在同行平台不展示该专线类别。
        </div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02" >
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
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
                var _data = { txtMingCheng: $.trim($("#<%=txtMingCheng.ClientID %>").val()), txtZhanDianId: $("#txtZhanDianId").val(), txtStatus: $("#txtStatus").val(), txtPaiXuId: $("#<%=txtPaiXuId.ClientID %>").val(), txtT2: $("#txtT2").val() };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=save",
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
            $("select").each(function() { $(this).val($(this).attr("data-v")); });
        });
    </script>

</asp:Content>
