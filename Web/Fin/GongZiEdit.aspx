<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongZiEdit.aspx.cs" Inherits="Web.Fin.GongZiEdit"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
    <div style="width: 760px; margin: 0px auto; margin-top: 10px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th height="30" align="right">
                    发放日期：
                </th>
                <td>
                    <input name="txtRiQi" type="text" class="formsize80 inputtext" id="txtRiQi" runat="server"
                        onfocus="WdatePicker()" valid="required|isDate" errmsg="请填写发放日期|请填写正确的发放日期" />
                </td>
                <th align="right">
                    员工姓名：
                </th>
                <td colspan="2">
                    <uc1:SellsSelect runat="server" ID="txtYuanGong" ReadOnly="true" IsShowSelect="true"
                        SetTitle="员工姓名" />
                </td>
                <th align="right">
                    工资年月：
                </th>
                <td colspan="2">
                    <input name="txtNyf" type="text" class="formsize80 inputtext" id="txtNyf" runat="server"
                        onfocus="WdatePicker({dateFmt:'yyyy-MM'})" valid="required" errmsg="请填写所属月份" />
                </td>
            </tr>
            <tr class="odd">
                <th style="height:30px; text-align:right;">发放类型：</th>
                <td colspan="7"><select name="txtFaFangLeiXing" id="txtFaFangLeiXing">
                    <option value="0">工资</option>
                    <option value="1">奖金</option>
                </select></td>
            </tr>
            <tr class="odd">
                <th align="center" style="width: 12%">
                    基本工资
                </th>
                <th align="center" style="width: 12%">
                    工龄补贴
                </th>
                <th align="center" style="width: 12%">
                    生活费补助
                </th>
                <th align="center" style="width: 12%">
                    社保补贴
                </th>
                <th align="center" style="width: 12%">
                    岗位补贴
                </th>
                <th align="center" style="width: 12%">
                    季度奖金
                </th>
                <th align="center" style="width: 12%">
                    扣除社保
                </th>
                <th align="center" style="width: 12%">
                    工资合计
                </th>
            </tr>
            <tr class="even">
                <td align="center">
                    <asp:TextBox ID="txt_jbgz" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_glbz" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_shfbz" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_sbbt" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_gwbt" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_jdjj" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_kcsb" runat="server" CssClass="formsize70 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:TextBox ID="txt_gzhj" runat="server" ReadOnly="true" CssClass="formsize70 inputtext"
                        MaxLength="10" Style="background: #dadada;"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height: 30px;" colspan="2">
                    生活费扣除：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_shfkc" runat="server" CssClass="formsize80 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;" colspan="2">
                    生活费扣除明细：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_shfkcmx" runat="server" TextMode="MultiLine" CssClass="textareastyle inputarea"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height: 30px;" colspan="2">
                    上班迟到、早退、旷工、事假扣费金额：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_cdkc" runat="server" CssClass="formsize80 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;" colspan="2">
                    上班迟到、早退、旷工、事假扣费明细：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_cdkcmx" runat="server" TextMode="MultiLine" CssClass="textareastyle inputarea"></asp:TextBox>
                </td>
            </tr>
            <tr class="odd">
                <th align="right" style="height: 30px;" colspan="2">
                    其他扣费金额：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_qtkfje" runat="server" CssClass="formsize80 inputtext jisuan"
                        MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;" colspan="2">
                    其他扣费明细：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_qtkfmx" runat="server" TextMode="MultiLine" CssClass="textareastyle inputarea"></asp:TextBox>
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;" colspan="2">
                    季度奖金明细：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_jdjjmx" runat="server" TextMode="MultiLine" CssClass="textareastyle inputarea"></asp:TextBox>
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;" colspan="2">
                    实发工资总额：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txt_sfgz" runat="server" CssClass="formsize80 inputtext jisuan"
                        ReadOnly="true" Style="background: #dadada;"></asp:TextBox>
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;" colspan="2">
                    工资发放备注：
                </th>
                <td colspan="6">
                    &nbsp;<asp:TextBox ID="txtGongZiBeiZhu" runat="server" TextMode="MultiLine" CssClass="textareastyle inputarea"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
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
    </form>

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
                var _data = {
                    txtRiQi: $.trim($("#<%=txtRiQi.ClientID %>").val()),
                    txtYuanGongId: $.trim($("#<%=txtYuanGong.SellsIDClient %>").val()),
                    txtYuanGongName: $.trim($("#<%=txtYuanGong.SellsNameClient %>").val()),
                    Month: $.trim($("#<%=txtNyf.ClientID %>").val()),
                    JiBenGongZi: $.trim($("#<%=txt_jbgz.ClientID %>").val()),
                    GongLingBuTie: $.trim($("#<%=txt_glbz.ClientID %>").val()),
                    ShengHuoFeiBuTie: $.trim($("#<%=txt_shfbz.ClientID %>").val()),
                    SheBaoBuTie: $.trim($("#<%=txt_sbbt.ClientID %>").val()),
                    GangWeiBuTie: $.trim($("#<%=txt_gwbt.ClientID %>").val()),
                    JiDuJiangJin: $.trim($("#<%=txt_jdjj.ClientID %>").val()),
                    SheBaoKouChu: $.trim($("#<%=txt_kcsb.ClientID %>").val()),
                    GongZiHeJi: $.trim($("#<%=txt_gzhj.ClientID %>").val()),
                    ShengHuoFeiKouChu: $.trim($("#<%=txt_shfkc.ClientID %>").val()),
                    ShengHuoFeiBeiZhu: $.trim($("#<%=txt_shfkcmx.ClientID %>").val()),
                    ChiDaoKouChu: $.trim($("#<%=txt_cdkc.ClientID %>").val()),
                    ChiDaoBeiZhu: $.trim($("#<%=txt_cdkcmx.ClientID %>").val()),
                    QiTaKouChu: $.trim($("#<%=txt_qtkfje.ClientID %>").val()),
                    QiTaBeiZhu: $.trim($("#<%=txt_qtkfmx.ClientID %>").val()),
                    JiDuJiangJinBeiZhu: $.trim($("#<%=txt_jdjjmx.ClientID %>").val()),
                    ShiFaGongZi: $.trim($("#<%=txt_sfgz.ClientID %>").val()),
                    txtGongZiBeiZhu: $.trim($("#<%=txtGongZiBeiZhu.ClientID %>").val()),
                    txtFaFangLeiXing:$("#txtFaFangLeiXing").val()
                };
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

            $("#txtFaFangLeiXing").val("<%=FaFangLeiXing %>");

            $(".jisuan").change(function() {
                var JiBenGongZi = tableToolbar.getFloat($.trim($("#<%=txt_jbgz.ClientID %>").val()));
                var GongLingBuTie = tableToolbar.getFloat($.trim($("#<%=txt_glbz.ClientID %>").val()));
                var ShengHuoFeiBuTie = tableToolbar.getFloat($.trim($("#<%=txt_shfbz.ClientID %>").val()));
                var SheBaoBuTie = tableToolbar.getFloat($.trim($("#<%=txt_sbbt.ClientID %>").val()));
                var GangWeiBuTie = tableToolbar.getFloat($.trim($("#<%=txt_gwbt.ClientID %>").val()));
                var JiDuJiangJin = tableToolbar.getFloat($.trim($("#<%=txt_jdjj.ClientID %>").val()));
                var SheBaoKouChu = tableToolbar.getFloat($.trim($("#<%=txt_kcsb.ClientID %>").val()));
                var ShengHuoFeiKouChu = tableToolbar.getFloat($.trim($("#<%=txt_shfkc.ClientID %>").val()));
                var ChiDaoKouChu = tableToolbar.getFloat($.trim($("#<%=txt_cdkc.ClientID %>").val()));
                var QiTaKouChu = tableToolbar.getFloat($.trim($("#<%=txt_qtkfje.ClientID %>").val()));

                var gzhj = tableToolbar.calculate(JiBenGongZi, GongLingBuTie, "+");
                gzhj = tableToolbar.calculate(gzhj, ShengHuoFeiBuTie, "+");
                gzhj = tableToolbar.calculate(gzhj, SheBaoBuTie, "+");
                gzhj = tableToolbar.calculate(gzhj, GangWeiBuTie, "+");
                gzhj = tableToolbar.calculate(gzhj, JiDuJiangJin, "+");
                gzhj = tableToolbar.calculate(gzhj, SheBaoKouChu, "-");


                $("#<%=txt_gzhj.ClientID %>").val(gzhj);
                var sfgz = tableToolbar.calculate(gzhj, ShengHuoFeiKouChu, "-");
                sfgz = tableToolbar.calculate(sfgz, ChiDaoKouChu, "-");
                sfgz = tableToolbar.calculate(sfgz, QiTaKouChu, "-");

                $("#<%=txt_sfgz.ClientID %>").val(sfgz);
            });
        });
    </script>

</asp:Content>
