<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaPiaoFaSong.aspx.cs" Inherits="Web.Fin.FaPiaoFaSong"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 10px auto;" id="i_div_form">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <td width="36" height="30" align="center">
                    编号
                </td>
                <th align="center" style="width:130px;">
                    出团日期
                </th>
                <th align="center" style="width:200px;">
                    开票信息
                </th>
                <th align="center">
                    送出状态
                </th>
                <th align="center">
                    发票送出时间
                </th>
                <th align="center">
                    发票送出方式
                </th>
                <th align="center">
                    邮寄公司名称
                </th>
                <th align="center">
                    邮寄单号
                </th>
                <th align="center">
                    签收人
                </th>
                <th align="center">
                    签收时间
                </th>
                <th align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
            <ItemTemplate>
            <tr class="even">
                <td height="30" align="center" class="index">
                    <%# Container.ItemIndex + 1%>
                </td>
                <td align="left">
                    单号：<%#Eval("DingDanHao") %><br />
                    日期：<%#ToDateTimeString(Eval("ChuTuanRiQi")) %><br />
                    金额：<%#ToMoneyString(Eval("JinE")) %>
                </td>
                <td align="left">
                    抬头：<%#Eval("TaiTou") %><br />
                    开票：<%#Eval("KaiPiaoDanWei") %><br />
                    票号：<%#Eval("FaPiaoHao") %>
                </td>
                <td align="center">
                    <select name="txtStatus" class="inputselect">
                        <%#GetStatusOptionHtml(Eval("Status"))%>
                    </select>
                </td>
                <td align="center">
                    <input type="hidden" name="txtMxId" value="<%#Eval("MXId") %>" />
                    <input name="txtFaSongTime" type="text" class="inputtext" value="<%#Eval("FaSongTime","{0:yyyy-MM-dd}") %>"
                        onfocus="WdatePicker()" style="width: 70px;" />
                </td>
                <td align="center">
                    <input name="txtFaSongFangShi" type="text" class="formsize80 inputtext" value="<%#Eval("FaSongFangShi") %>"
                        maxlength="50" />
                </td>
                <td align="center">
                    <input name="txtYouJiGongSiName" type="text" class="formsize80 inputtext" value="<%#Eval("YouJiGongSiName") %>"
                        maxlength="50" />
                </td>
                <td align="center">
                    <input name="txtYouJiDanHao" type="text" class="formsize80 inputtext" value="<%#Eval("YouJiDanHao") %>"
                        maxlength="50" />
                </td>
                <td align="center">
                    <input name="txtQianShouRenName" type="text" class="inputtext" value="<%#Eval("QianShouRenName") %>"
                        maxlength="50" style="width: 70px;" />
                </td>
                <td align="center">
                    <input name="txtQianShouTime" type="text" class="inputtext" style="width:70px;" value="<%#Eval("QianShouTime","{0:yyyy-MM-dd}") %>"
                        onfocus="WdatePicker()" />
                </td>
                <td style="text-align:center;">
                    <a href="javascript:void(0)" class="fs_tongbu">↓</a>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>             
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left">
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
            //关闭窗口
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            save: function(obj) {
                var _data = { txtMxId: [], txtStatus: [], txtFaSongTime: [], txtFaSongFangShi: [], txtYouJiGongSiName: [], txtYouJiDanHao: [], txtQianShouRenName: [], txtQianShouTime: [] };

                $("input[name='txtMxId']").each(function() { _data.txtMxId.push($.trim($(this).val())); });
                $("select[name='txtStatus']").each(function() { _data.txtStatus.push($.trim($(this).val())); });
                $("input[name='txtFaSongTime']").each(function() { _data.txtFaSongTime.push($.trim($(this).val())); });
                $("input[name='txtFaSongFangShi']").each(function() { _data.txtFaSongFangShi.push($.trim($(this).val())); });
                $("input[name='txtYouJiGongSiName']").each(function() { _data.txtYouJiGongSiName.push($.trim($(this).val())); });
                $("input[name='txtYouJiDanHao']").each(function() { _data.txtYouJiDanHao.push($.trim($(this).val())); });
                $("input[name='txtQianShouRenName']").each(function() { _data.txtQianShouRenName.push($.trim($(this).val())); });
                $("input[name='txtQianShouTime']").each(function() { _data.txtQianShouTime.push($.trim($(this).val())); });

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=setstatus",
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
            tongBuMx: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _txtStatus = $.trim(_$tr.find("select[name='txtStatus']").val());
                var _txtFaSongTime = $.trim(_$tr.find("input[name='txtFaSongTime']").val());
                var _txtFaSongFangShi = $.trim(_$tr.find("input[name='txtFaSongFangShi']").val());
                var _txtYouJiGongSiName = $.trim(_$tr.find("input[name='txtYouJiGongSiName']").val());
                var _txtYouJiDanHao = $.trim(_$tr.find("input[name='txtYouJiDanHao']").val());
                var _txtQianShouRenName = $.trim(_$tr.find("input[name='txtQianShouRenName']").val());
                var _txtQianShouTime = $.trim(_$tr.find("input[name='txtQianShouTime']").val());

                _$tr.nextAll("tr").each(function() {
                    var __$tr = $(this);
                    __$tr.find("select[name='txtStatus']").val(_txtStatus);
                    __$tr.find("input[name='txtFaSongTime']").val(_txtFaSongTime);
                    __$tr.find("input[name='txtFaSongFangShi']").val(_txtFaSongFangShi);
                    __$tr.find("input[name='txtYouJiGongSiName']").val(_txtYouJiGongSiName);
                    __$tr.find("input[name='txtYouJiDanHao']").val(_txtYouJiDanHao);
                    __$tr.find("input[name='txtQianShouRenName']").val(_txtQianShouRenName);
                    __$tr.find("input[name='txtQianShouTime']").val(_txtQianShouTime);                    
                });
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            $(".fs_tongbu").click(function() { iPage.tongBuMx(this); });
        });
    </script>

</asp:Content>
