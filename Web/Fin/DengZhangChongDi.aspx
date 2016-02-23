<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DengZhangChongDi.aspx.cs"
    Inherits="Web.Fin.DengZhangChongDi" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/SupperControl.ascx" TagName="SupperControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 700px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <td style="width:100px; text-align:right; height:30px;">可冲抵金额：</td>
                <td><asp:Literal runat="server" ID="ltrKeChongDiJinE"></asp:Literal></td>
            </tr>
            <tr class="odd">
                <td style="text-align: right; height: 30px;">
                    冲抵金额：
                </td>
                <td>
                    <input type="text" name="txtJinE" id="txtJinE" class="formsize100 inputtext" maxlength="9"
                        valid="required|isNumber" errmsg="请填写冲抵金额|请填写正确的冲抵金额" />
                </td>
            </tr>
            <tr class="odd">
                <td style="text-align: right; height: 30px;">
                    冲抵备注：
                </td>
                <td>
                    <textarea name="txtBeiZhu" rows="3" class="formsize450 inputarea" id="txtBeiZhu"
                        valid="required" errmsg="请填写冲抵备注"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    收入项目：
                </th>
                <td>
                    <select name="txtXiangMuId" id="txtXiangMuId" class="inputselect" valid="required"
                        errmsg="请选择收入项目">
                        <asp:Literal runat="server" ID="ltrXiangMuIdOptions"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    单位类型：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <select name="txtKeHuType" id="txtKeHuType" class="inputselect">
                        <asp:Literal runat="server" ID="ltrKeHuTypeHtml"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    对方单位：<input type="hidden" id="txtKeHuId" name="txtKeHuId" />
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <div id="div_kehu_xuanyong">
                        <uc1:KeHuXuanZe runat="server" id="txtKeHu" />
                    </div>
                    <div id="div_gys_xuanyong">
                        <uc1:suppercontrol runat="server" id="txtGys" alltype="1" suppliertype="地接" />
                    </div>
                </td>
            </tr>
            
            <tr class="odd">
                <td style=" text-align: right; height: 30px;">
                    操作人：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltrOperatorName"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <td style="text-align: right; height: 30px;">
                    操作时间：
                </td>
                <td>
                    <asp:Literal runat="server" ID="ltrIssueTime"></asp:Literal>
                </td>
            </tr>
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" bgcolor="#E3F1FC">
                    <table border="0" align="center" cellpadding="0" cellspacing="0" visible="true">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
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
            chongDi: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return;

                var _keChongDiJinE = tableToolbar.getFloat("<%=KeChongDiJinE %>");
                var _data = { txtJinE: tableToolbar.getFloat($.trim($("#txtJinE").val())), txtBeiZhu: $.trim($("#txtBeiZhu").val()), txtKeHuType: $.trim($("#txtKeHuType").val()), txtKeHuId: "", txtXiangMuId: $("#txtXiangMuId").val() };

                if (_data.txtKeHuType == "0") {
                    _data.txtKeHuId = $.trim($("#<%=txtKeHu.KeHuIdClientId %>").val());
                } else {
                    _data.txtKeHuId = $.trim($("#<%=txtGys.ClientValue %>").val());
                }

                if (_data.txtJinE <= 0) { parent.tableToolbar._showMsg("请输入正确的冲抵金额：冲抵金额不能小于等于0。"); return; }
                if (_data.txtBeiZhu.length > 255) { $("#txtBeiZhu").focus(); parent.tableToolbar._showMsg("冲抵备注最多255个字符"); return; }
                if (_keChongDiJinE < _data.txtJinE) { parent.tableToolbar._showMsg("冲抵金额不能大于可冲抵金额！"); return; }
                if (_data.txtKeHuId.length == 0) { parent.tableToolbar._showMsg("请选择对方单位"); return; }
                if (!confirm("冲抵操作不可逆，你确定要进行冲抵操作吗？")) return;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=chongdi",
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
                            $(obj).bind("click", function() { iPage.chongDi(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.chongDi(obj); }).css({ "color": "" });
                    }
                });
            },
            setKeHuXuanYong: function() {
                var _v = $("#txtKeHuType").val();
                if (_v == "0") {
                    $("#div_kehu_xuanyong").show();
                    $("#div_gys_xuanyong").hide();
                } else {
                    $("#div_kehu_xuanyong").hide();
                    $("#div_gys_xuanyong").show();
                }
            }
        };

        $(document).ready(function() {
            $("#i_a_chongdi").click(function() { iPage.chongDi(this); });
            $("#txtKeHuType").bind("change", function() { iPage.setKeHuXuanYong(); });
            iPage.setKeHuXuanYong();
        });
    </script>

</asp:Content>
