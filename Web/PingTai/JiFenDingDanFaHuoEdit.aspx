<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenDingDanFaHuoEdit.aspx.cs" Inherits="Web.PingTai.JiFenDingDanFaHuoEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>快递信息：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <input name="txtKuaiDi" type="text" class="inputtext" id="txtKuaiDi" runat="server"
                        valid="required" errmsg="请填写快递信息" maxlength="100" style="width:480px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>付款时间：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtFuKuanShiJian" type="text" class="inputtext" id="txtFuKuanShiJian" runat="server"
                        valid="required" errmsg="请填写付款时间" maxlength="100" style="width:280px;" onfocus="WdatePicker()" />
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>付款金额：
                </th>
                <td style="background:#E3F1FC">
                     <input name="txtFuKuanJinE" type="text" class="inputtext" id="txtFuKuanJinE" runat="server"
                        valid="required" errmsg="请填写付款金额" maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>付款方式：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtFuKuanFangShi" class="inputselect" name="txtFuKuanFangShi" valid="required" errmsg="请选择付款方式">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.ShouFuKuanFangShi)), "") %>
                    </select>
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>付款账号：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtFuKuanZhangHao" type="text" class="inputtext" id="txtFuKuanZhangHao" runat="server"
                        valid="required" errmsg="请填写付款账号" maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <span class="fred">*</span>对方单位：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <input name="txtDuiFangDanWei" type="text" class="inputtext" id="txtDuiFangDanWei" runat="server"
                        valid="required" errmsg="请填写对方单位" maxlength="100" style="width:480px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    付款备注：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <input name="txtFuKuanBeiZhu" type="text" class="inputtext" id="txtFuKuanBeiZhu" runat="server"
                       maxlength="100" style="width:480px;" />
                </td>
            </tr>     
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="40" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <asp:Literal runat="server" ID="ltrOperatorHtml" />
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.all.js"></script>
    
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
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
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
            quXiaoFaHuo: function(obj) {
                if (!confirm("你确定要取消发货吗？")) return false;
                $(obj).unbind("click").css({ "color": "#999999" });
                $.newAjax({ type: "POST", url: window.location.href + "&doType=quxiaofahuo",
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.queRenDingDan(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.queRenDingDan(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $("#i_a_quxiaofahuo").bind("click", function() { iPage.quXiaoFaHuo(this); return false; });
            $("#txtFuKuanFangShi").val("<%=FuKuanFangShi %>");
        });
    </script>
</asp:Content>
