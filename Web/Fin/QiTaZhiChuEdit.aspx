<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QiTaZhiChuEdit.aspx.cs" Inherits="Web.Fin.QiTaZhiChuEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/SupperControl.ascx" TagName="SupperControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 630px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="120" height="30" align="right">
                    <%=StrShiJian%>：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtShiJian" type="text" class="formsize80 inputtext" id="txtShiJian"
                        runat="server" onfocus="WdatePicker()"/>
                </td>
                <th width="120" align="right">
                    支出项目：
                </th>
                <td bgcolor="#E3F1FC">
                    <select name="txtXiangMuId" id="txtXiangMuId" class="inputselect" valid="required"
                        errmsg="请选择支出项目">
                        <asp:Literal runat="server" ID="ltrXiangMuIdOptions"></asp:Literal>
                    </select>
                    <input name="txtXiangMu" type="text" class="formsize120 inputtext" id="txtXiangMu"
                        runat="server" maxlength="50" valid="required" errmsg="请填写支出项目" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    支出金额：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <input name="txtJinE" type="text" class="formsize80 inputtext" id="txtJinE" runat="server"
                        maxlength="11" valid="required|isNumber" errmsg="请填写支出金额|请填写正确的支出金额" />
                </td>
            </tr>
            <tr class="odd">
                <th align="right">
                    支出备注：
                </th>
                <td colspan="3" align="left" bgcolor="#E3F1FC">
                    <textarea name="txtBeiZhu" rows="3" class="formsize260 inputarea" id="txtBeiZhu" runat="server"></textarea>
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
                    对方单位：
                </th>
                <td colspan="3" bgcolor="#E3F1FC">
                    <div id="div_kehu_xuanyong">
                        <uc1:KeHuXuanZe runat="server" ID="txtKeHu" />
                    </div>
                    <div id="div_gys_xuanyong">
                        <uc1:SupperControl runat="server" ID="txtGys" AllType="1" SupplierType="地接" />
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" bgcolor="#E3F1FC">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
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
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //关闭窗口
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            save: function(obj) {
                var _data = { txtShiJian: $.trim($("#<%=txtShiJian.ClientID %>").val()),
                    txtXiangMu: $.trim($("#<%=txtXiangMu.ClientID %>").val()),
                    txtJinE: $.trim($("#<%=txtJinE.ClientID %>").val()),
                    txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID %>").val()),
                    txtKeHuType: $.trim($("#txtKeHuType").val()),
                    txtKeHuId: "",
                    txtXiangMuId: $.trim($("#txtXiangMuId").val())
                };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return;

                if (_data.txtKeHuType == "0") {
                    _data.txtKeHuId = $.trim($("#<%=txtKeHu.KeHuIdClientId %>").val());
                } else {
                    _data.txtKeHuId = $.trim($("#<%=txtGys.ClientValue %>").val());
                }

                if (_data.txtKeHuId.length == 0) { parent.tableToolbar._showMsg("请选择对方单位"); return; }

                if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("支出备注最多可输入255个字符"); return; }

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
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            $("#txtKeHuType").bind("change", function() { iPage.setKeHuXuanYong(); });
            $("#<%=txtShiJian.ClientID %>").attr("valid", "required|isDate").attr("errmsg", "请填写<%=StrShiJian %>|请填写正确的<%=StrShiJian %>");
            iPage.setKeHuXuanYong();
            $("#txtXiangMuId").change(function() { var _$obj = $(this); var _v = ""; if (_$obj.val().length > 0) _v = _$obj.find("option:selected").text(); $("#<%=txtXiangMu.ClientID %>").val(_v); });
        });
    </script>

</asp:Content>
