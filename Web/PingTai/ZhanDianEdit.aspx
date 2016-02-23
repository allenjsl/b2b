<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhanDianEdit.aspx.cs" Inherits="Web.PingTai.ZhanDianEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 98%; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="100" height="30" align="right">
                    站点名称：
                </th>
                <td>
                    <input name="txtMingCheng" type="text" class="formsize120 inputtext" id="txtMingCheng" runat="server"
                        valid="required" errmsg="请填写站点名称" maxlength="10" />
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
                    行政区划代码：
                </th>
                <td style="background:#E3F1FC">
                    <a href="http://www.stats.gov.cn/tjsj/tjbz/xzqhdm/201401/t20140116_501070.html" target="_blank">行政区划代码详见《中华人民共和国国家统计局-行政区划代码》</a>
                </td>
            </tr>
            <tr class="odd">
                <td style="background:#E3F1FC" colspan="2">
                    <textarea id="txtXzqhdm" style="width: 99.3%; height: 100px;" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <td style="background:#E3F1FC;color:#666; height:30px;" colspan="2">
                    注1：系统根据来访者IP自动识别来访者行政区划，按照来访者行政区划定义来访者默认站点。<br />
                    注2：多个行政区划代码用,或，或|间隔。<br />
                    注3：请填写6位或前4位或前2位的行政区划代码。
                </td>
            </tr>
        </table>
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
                var _data = { txtMingCheng: $.trim($("#<%=txtMingCheng.ClientID %>").val()), txtPaiXuId: $.trim($("#<%=txtPaiXuId.ClientID %>").val()), txtXzqhdm: $.trim($("#<%=txtXzqhdm.ClientID %>").val()) };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                _data.txtXzqhdm = _data.txtXzqhdm.replace("，", ",").replace("|", ",");

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
        });
    </script>

</asp:Content>
