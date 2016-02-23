<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiChuXinXiEdit.aspx.cs"
    Inherits="Web.SystemSet.JiChuXinXiEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <style type="text/css">  
    .p1{float:left;width:33%;list-style: none;margin: 0px;padding: 0px;}
    .p1 li{line-height:22px;list-style: none;}
    .p1 li.p1title{font-weight:bold;line-height:24px;}    
    .p1 li.p1item{}
    .p2{clear:both;width:100%; height:10px;list-style: none;margin: 0px;padding: 0px;}
    </style>
    
    <div style="width: 100%; margin: 0px auto; margin-top:10px;">
        <form id="form1" runat="server">
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="120" height="35" align="right">
                    <%=IJiChuXinXiType %>：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtName" type="text" class="formsize260 inputtext" id="txtName" runat="server" valid="required"  maxlength="255" />
                </td>
            </tr>
            
            <asp:PlaceHolder runat="server" ID="phQuYu" Visible="false">
            <tr class="odd">
                <th width="120" height="35" align="right">
                    线路区域：<input type="hidden" id="txtQuYu" name="txtQuYu" />
                </th>
                <td style="background: #E3F1FC">
                    <asp:Literal runat="server" ID="ltrQuYu"></asp:Literal>
                </td>
            </tr>
            </asp:PlaceHolder>
            
            <asp:PlaceHolder runat="server" ID="phT1" Visible="false">
            <tr class="odd">
                <th width="120" height="35" align="right">
                    属于：
                </th>
                <td style="background: #E3F1FC">
                    <select id="txtT1" name="txtT1" valid="required" errmsg="请选择属于">
                        <asp:Literal runat="server" ID="ltrT1"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd" id="i_tr_leibie">
                <th width="120" height="35" align="right">
                    类别：
                </th>
                <td style="background: #E3F1FC">
                    <select id="txtT2" name="txtT2">
                        <asp:Literal runat="server" ID="ltrT2"></asp:Literal>
                    </select>
                </td>
            </tr>
            </asp:PlaceHolder>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <a href="javascript:void(0)" id="i_a_save">保存</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </form>
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
                var _data = { txtName: $.trim($("#<%=txtName.ClientID %>").val()), txtT1: $.trim($("#txtT1").val()), txtT2: $.trim($("#txtT2").val()), txtQuYu: "" };

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                var validatorResult1 = this.quYuHandler();
                if (!validatorResult1) { alert("请选择线路区域"); return false; }

                _data.txtQuYu = $.trim($("#txtQuYu").val());

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
            changeT1: function() {
                var _t1 = $("#txtT1").val();
                if (_t1 == "<%=(int)EyouSoft.Model.EnumType.FinStructure.QiTaShouZhiT1.其它收支 %>") {
                    $("#i_tr_leibie").show();
                    $("#txtT2").attr("valid", "required").attr("errmsg", "请选择类别");
                }
                else {
                    $("#i_tr_leibie").hide();
                    $("#txtT2").removeAttr("valid").removeAttr("errmsg");
                }
            },
            initQuYus: function() {
                if (typeof (quYus) == "undefined") return;
                if (quYus == null || quYus.length == 0) return;
                for (var i = 0; i < quYus.length; i++) {
                    $("#chk_quyu_" + quYus[i].QuYuId).attr("checked", true);
                    $("#chk_quyu_" + quYus[i].QuYuId).closest("ul").find("li:eq(0)").find("input[type='checkbox']").attr("checked", true);
                }
            },
            quYuHandler: function() {
                var _items = [];
                $("input[name='chk_quyu']").each(function() {
                    var _$obj = $(this);
                    if (_$obj.attr("checked")) { _items.push(_$obj.val()) }
                });

                if (_items.length == 0) {
                    if ("<%=(int)IJiChuXinXiType %>" == "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次 %>"
                        || "<%=(int)IJiChuXinXiType %>" == "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程班次 %>") return false;
                }

                $("#txtQuYu").val(_items.join(','));

                return true;
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#txtT1").change(function() { iPage.changeT1(); });
            iPage.changeT1();

            $(".p1title input[type='checkbox']").bind("click", function() {
                $(this).closest("ul").find("input[type='checkbox']").attr("checked", this.checked);
            });

            $(".p1item input[type='checkbox']").bind("click", function() {
                if (!this.checked) {
                    if ($(this).closest("ul").find("li.p1item").find("input[type='checkbox']:checked").length == 0) {
                        $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").removeAttr("checked")
                    }
                    return;
                }
                $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").attr("checked", true);
            });

            iPage.initQuYus();
        });
    </script>

</asp:Content>
