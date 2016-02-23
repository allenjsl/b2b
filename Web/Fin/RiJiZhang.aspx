<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiJiZhang.aspx.cs" Inherits="Web.Fin.RiJiZhang"
    MasterPageFile="~/MasterPage/Front.Master" Title="出纳日记账-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/SupperControl.ascx" TagName="SupperControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 出纳日记账
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <div class="hr_10">
    </div>
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox" style="height:70px;">
                    登记日期：
                    <input name="txtSRiQi" type="text" class="searchinput formsize80 inputtext" id="txtSRiQi"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtERiQi" type="text" class="searchinput formsize80 inputtext" id="txtERiQi"
                        onfocus="WdatePicker()" />
                    业务日期：
                    <input name="txtSYeWuRiQi" type="text" class="searchinput formsize80 inputtext" id="txtSYeWuRiQi"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEYeWuRiQi" type="text" class="searchinput formsize80 inputtext" id="txtEYeWuRiQi"
                        onfocus="WdatePicker()" /><br />
                    银行账户：<select name="txtYinHangZhangHu" id="txtYinHangZhangHu" class="inputselect"><%=GetYinHangZhangHuOptions()%></select>
                    往来单位：<select name="txtKeHuType" id="txtKeHuType" class="inputselect">
                        <%=GetKeHuTypeOptions("") %>
                    </select>
                    <span id="span_kehu_xuanyong">
                        <uc1:KeHuXuanZe runat="server" id="txtKeHu" isrequired="false" />
                    </span>
                    <span id="span_gys_xuanyong">
                        <uc1:suppercontrol runat="server" id="txtGys" alltype="1" suppliertype="地接" />
                    </span>
                    <span id="span_yuangong_xuanyong">
                        <uc1:sellsselect runat="server" id="txtYuanGong" readonly="true" isshowselect="true"  settitle="员工" isnotvalid="false" />
                    </span>
                    <span id="span_txtwanglaidanweiname">
                        <input type="text" name="txtWangLaiDanWeiName" id="txtWangLaiDanWeiName" class="searchinput formsize120 inputtext" />
                    </span>
                    <br />
                    项目：<select name="txtXiangMu" id="txtXiangMu" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.RiJiZhangXiangMu)), "", "", "-请选择-")%></select>
                    凭证号：<input name="txtPingZhengHao" type="text" class="searchinput formsize80 inputtext"
                        id="txtPingZhengHao" />
                    借方金额：<select name="txtJieFangJinEOperator" id="txtJieFangJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtJieFangJinE" id="txtJieFangJinE" class="searchinput w50 inputtext" />
                    贷方金额：<select name="txtDaiFangJinEOperator" id="txtDaiFangJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtDaiFangJinE" id="txtDaiFangJinE" class="searchinput w50 inputtext" />
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    <div class="btnbox">
        <asp:PlaceHolder runat="server" ID="phInsert">
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" id="i_insert">登 记</a>
                    </td>
                    <%--<td width="90" align="center">
                        <a href="javascript:void(0)" id="a_div_print">打 印</a>
                    </td>--%>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" id="i_a_toxls">导 出</a>
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>
    <div class="tablelist">
        <div id="div_Print">
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr class="odd">
                    <th width="36" height="30" align="center">
                        序号
                    </th>
                    <th width="8%" align="center">
                        登记日期
                    </th>
                    <th width="8%" align="center">
                        项目
                    </th>
                    <th width="8%" align="center">
                        业务日期
                    </th>
                    <th align="center">
                        凭证编号
                    </th>
                    <th align="center">
                        银行账号
                    </th>
                    <th align="center">
                        往来单位
                    </th>
                    <th align="center">
                        明细
                    </th>
                    <th align="center">
                        借方
                    </th>
                    <th align="center">
                        贷方
                    </th>
                    <th align="center">
                        余额
                    </th>
                    <th style="text-align: center; width: 50px;" class="unprint">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpts">
                    <ItemTemplate>
                        <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_rijiid="<%#Eval("RiJiId") %>">
                            <td align="center" style="height: 30px;">
                                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <%#ToDateTimeString(Eval("DengJiRiQi"))%>
                            </td>
                            <td align="center">
                                <%#Eval("XiangMu")%>
                            </td>
                            <td align="center">
                                <%#Eval("YeWuRiQi")%>
                            </td>
                            <td align="center">
                                <%#Eval("PingZhengHao")%>
                            </td>
                            <td align="center">
                                <span class="pandl3">
                                    <%#Eval("ZhangHuName")%></span>
                            </td>
                            <td align="center">
                                <%#Eval("WangLaiDanWei")%>
                            </td>
                            <td align="center" style="word-break: break-all; word-wrap: break-word;">
                                <%#Eval("MingXi")%>
                            </td>
                            <td align="center">
                                <%#ToMoneyString(Eval("JieFangJinE"))%>
                            </td>
                            <td align="center">
                                <%#ToMoneyString(Eval("DaiFangJinE"))%>
                            </td>
                            <td align="center">
                                <%#ToMoneyString(Eval("YuE"))%>
                            </td>
                            <td style="text-align: center"  class="unprint">
                                <a href="javascript:void(0)" class="i_update">修改</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty">
                    <tr>
                        <td class="even" colspan="12" style="height: 30px; text-align: center;">
                            暂无任何出纳日记账信息。
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phHeJi" runat="server"></asp:PlaceHolder>
            </table>
        </div>
        <asp:PlaceHolder runat="server" ID="phPaging">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "新增出纳日记账", iframeUrl: "rijizhangedit.aspx", width: "720px", height: "359px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            toXls: function() {
                var params = { doType: "toxls_rijizhang" };
                toXls1(utilsUri.createUri(null, params));
                return false;
            },
            //修改
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { rijizhangid: _$tr.attr("i_rijiid") };
                Boxy.iframeDialog({ title: "修改出纳日记账", iframeUrl: "rijizhangedit.aspx", width: "720px", height: "359px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //打印
            pirnt: function() {
                var data = { printDivId: "div_Print", title: "打印出纳日记账" };
                window.open("/PrintPage/PublicPrint.aspx?" + $.param(data), "newWindow");
                return false;
            },
            setKeHuXuanYong: function() {
                var _v = $("#txtKeHuType").val();
                if (_v == "0") {
                    $("#span_kehu_xuanyong").show();
                    $("#span_gys_xuanyong").hide();
                    $("#span_yuangong_xuanyong").hide();
                    $("#span_txtwanglaidanweiname").hide();

                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_yuangong_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_txtwanglaidanweiname").find("input").removeAttr("disabled").attr("disabled", "disabled");
                } else if (_v == "1") {
                    $("#span_kehu_xuanyong").hide();
                    $("#span_gys_xuanyong").show();
                    $("#span_yuangong_xuanyong").hide();
                    $("#span_txtwanglaidanweiname").hide();

                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled");
                    $("#span_yuangong_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_txtwanglaidanweiname").find("input").removeAttr("disabled").attr("disabled", "disabled");
                } else if (_v == "2") {
                    $("#span_kehu_xuanyong").hide();
                    $("#span_gys_xuanyong").hide();
                    $("#span_yuangong_xuanyong").show();
                    $("#span_txtwanglaidanweiname").hide();

                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_yuangong_xuanyong").find("input").removeAttr("disabled");
                    $("#span_txtwanglaidanweiname").find("input").removeAttr("disabled").attr("disabled", "disabled");
                } else {
                    $("#span_kehu_xuanyong").hide();
                    $("#span_gys_xuanyong").hide();
                    $("#span_yuangong_xuanyong").hide();
                    $("#span_txtwanglaidanweiname").show();

                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_yuangong_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_txtwanglaidanweiname").find("input").removeAttr("disabled");
                }
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $("#i_a_toxls").bind("click", function() { return iPage.toXls(); });
            $(".i_update").bind("click", function() { iPage.update(this); });
            $("#a_div_print").bind("click", function() { return iPage.pirnt(); });
            $("#txtKeHuType").bind("change", function() { iPage.setKeHuXuanYong(); });
            iPage.setKeHuXuanYong();
        });
    </script>

</asp:Content>
