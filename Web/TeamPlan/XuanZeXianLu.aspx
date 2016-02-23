<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XuanZeXianLu.aspx.cs" Inherits="Web.TeamPlan.XuanZeXianLu"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox" style="line-height: 30px; height: 60px;">
                        线路区域：<select name="txtQuYu" class="inputselect" id="txtQuYu">
                            <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                        </select>
                        线路名称：
                        <input name="txtRouteName" type="text" id="txtRouteName" class="inputtext searchinput"
                            value="<%= EyouSoft.Common.Utils.GetQueryStringValue("txtRouteName") %>" />
                        发布时间：<input name="txtTime1" type="text" id="txtTime1" class="searchinput inputtext"
                            onfocus="WdatePicker()" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("txtTime1") %>"
                            style="width: 65px;" />-<input name="txtTime2" type="text" id="txtTime2" class="searchinput inputtext"
                                onfocus="WdatePicker()" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("txtTime2") %>"
                                style="width: 65px;" />
                        <br />
                        线路状态：
                        <select id="txtZhengCeStatus" name="txtZhengCeStatus" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)), "", "-1", "-请选择-") %>
                        </select>
                        线路类型：<select class="inputselect" id="txtLeiXing" name="txtLeiXing"><option value="">
                            -请选择-</option>
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing)),"")%></select>
                        <a href="javascript:void(0);" id="chaxunxl">
                            <img alt="点击查询" src="/images/searchbtn.gif" style="border-width: 0px;" /></a>
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="tableitems">
            <tr class="odd">
                <asp:Repeater runat="server" ID="rptRoute">
                    <ItemTemplate>
                        <%# GetTrHtml(Container.ItemIndex)%>
                        <td style="width: 25%; line-height: 24px;">
                            <%# GetInputHtml(Eval("RouteId"), Eval("RouteName"), Container.ItemIndex,Eval("Status"))%>
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
            <tr>
                <td height="30" align="right" class="pageup" colspan="3">
                    <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                </td>
            </tr>
        </table>
        <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:void(0);" id="xuanzexl">选择线路</a>
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
            chaXun: function() {
                var data = {};
                data["txtQuYu"] = $("#txtQuYu").val();
                data["txtRouteName"] = $("#txtRouteName").val();
                data["txtTime1"] = $("#txtTime1").val();
                data["txtTime2"] = $("#txtTime2").val();
                data["txtZhengCeStatus"] = $("#txtZhengCeStatus").val();
                data["txtLeiXing"] = $("#txtLeiXing").val();

                data["iscx"] = "1";
                data["iframeId"] = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
                data["RefererIframeId"] = '<%= EyouSoft.Common.Utils.GetQueryStringValue("RefererIframeId") %>';
                data["rowindex"] = '<%= EyouSoft.Common.Utils.GetQueryStringValue("rowindex") %>';

                window.location.href = "XuanZeXianLu.aspx?" + $.param(data);
            },
            xuanZe: function() {
                if ($("#tableitems").find("input[type='radio']:checked").length == 0) {
                    alert("请选择线路！"); return false;
                }

                var _data = { routeid: "", routename: "", routestatus: "", rowindex: 0 };

                _data.rowindex = parseInt('<%= EyouSoft.Common.Utils.GetQueryStringValue("rowindex") %>');
                $("#tableitems").find("input[type='radio']:checked").each(function() {
                    var _$obj = $(this);
                    _data.routeid = _$obj.val();
                    _data.routename = _$obj.attr("data-name");
                    _data.routestatus = _$obj.attr("i_status");
                });

                if (_data.routestatus == "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.已过期 %>") { alert("选中的线路已过期，请重新选择！"); return false; }
                if (_data.routeid.length == 0) { alert("请选择线路！"); return false; }

                var setRetCode = this.setXL(_data);

                if (setRetCode.success == 1) this.close();
                else { alert(setRetCode.msg); }

            },
            getWindow: function() {
                var _RefererIframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("RefererIframeId") %>';
                var _window = top.Boxy.getIframeWindow(_RefererIframeId);
                return _window;
            },
            setXL: function(obj) {
                var _window = this.getWindow();
                var _xlitems = $(_window.document).find("#table_xl tr.xlitem");
                var _isexists = false;

                _xlitems.each(function(i) {
                    if (i == obj.rowindex) return true;
                    var routeid = $(this).find("input[name='txt_xl_routeid']").val();
                    if (routeid == obj.routeid) { _isexists = true; return false; }
                });

                if (_isexists) return { success: 0, msg: "不能选择相同的线路" }

                var _xlitem = $(_xlitems[obj.rowindex]);
                _xlitem.find("input[name='txt_xl_routeid']").val(obj.routeid);
                _xlitem.find("input[name='txt_xl_routename']").val(obj.routename);

                return { success: 1, msg: "" }
            },
            initXL: function() {
                var _rowindex = parseInt('<%= EyouSoft.Common.Utils.GetQueryStringValue("rowindex") %>');
                var _window = this.getWindow();
                var _xlitems = $(_window.document).find("#table_xl tr.xlitem");
                var _xlitem = $(_xlitems[_rowindex]);
                var _xlid = _xlitem.find("input[name='txt_xl_routeid']").val();

                if (_xlid.length == 0) return;

                $("#tableitems").find("input[type='radio'][value='" + _xlid + "']").attr("checked", "checked");
            }
        };

        $(document).ready(function() {
            $("#chaxunxl").click(function() { iPage.chaXun(); return false; });
            $("#xuanzexl").click(function() { iPage.xuanZe(); return false; })

            $("#txtZhengCeStatus").val("<%=ZhuangTai %>");
            $("#txtLeiXing").val("<%=LeiXing %>");
            $("#txtQuYu").val("<%=QuYuId %>");

            iPage.initXL();
        });
    </script>

</asp:Content>
