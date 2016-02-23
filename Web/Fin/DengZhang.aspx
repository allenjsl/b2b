<%@ Page Title="出纳登帐" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="DengZhang.aspx.cs" Inherits="Web.Fin.DengZhang" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/SupperControl.ascx" TagName="SupperControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">财务管理</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0pt 10px 2px 0pt; color: rgb(19, 80, 159);">
                            <b>所在位置：</b>&gt;&gt;财务管理 &gt;&gt; 出纳登帐
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <form runat="server" id="form1">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/images/yuanleft.gif">
                    </td>
                    <td>
                        <div class="searchbox" style="height:75px;">
                            到款银行：
                            <asp:DropDownList runat="server" ID="ddlBank" CssClass="inputselect">
                            </asp:DropDownList>
                            <label>
                                到款时间：</label>
                            <input runat="server" name="txtStartDate" type="text" id="txtStartDate" onfocus="WdatePicker()"
                                class="searchinput inputtext" style="width:65px" />-<input runat="server" name="txtEndDate" type="text" id="txtEndDate" onfocus="WdatePicker()" class="searchinput inputtext" style="width: 65px;" />
                            <label>
                                状态:</label>
                            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="inputselect">
                            </asp:DropDownList>
                            <br />
                            到账金额：<select name="txtDaoZhangJinEOperator" id="txtDaoZhangJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator), new string[] { "0" }), EyouSoft.Common.Utils.GetQueryStringValue("txtDaoZhangJinEOperator"), "0", "-请选择-")%></select>&nbsp;<input
                                type="text" name="txtDaoZhangJinE" id="txtDaoZhangJinE" class="searchinput w50 inputtext"
                                value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtDaoZhangJinE") %>" />
                            未销账金额：<select name="txtWeiXiaoZhangJinEOperator" id="txtWeiXiaoZhangJinEOperator"
                                class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator), new string[] { "0" }), EyouSoft.Common.Utils.GetQueryStringValue("txtWeiXiaoZhangJinEOperator"), "0", "-请选择-")%></select>&nbsp;<input
                                    type="text" name="txtWeiXiaoZhangJinE" id="txtWeiXiaoZhangJinE" class="searchinput w50 inputtext"
                                    value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtWeiXiaoZhangJinE") %>" />
                            销账/冲抵金额：<select name="txtXiaoZhangJinEOperator" id="txtXiaoZhangJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator), new string[] { "0" }), EyouSoft.Common.Utils.GetQueryStringValue("txtXiaoZhangJinEOperator"), "0", "-请选择-")%></select>&nbsp;<input type="text" name="txtXiaoZhangJinE" id="txtXiaoZhangJinE" class="searchinput w50 inputtext" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaoZhangJinE") %>" />
                            <label>
                                销账/冲抵时间：</label>
                            <input name="txtXiaoZhangShiJian1" type="text" id="txtXiaoZhangShiJian1" onfocus="WdatePicker()" class="searchinput inputtext" style="width: 65px;" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaoZhangShiJian1") %>" />-<input name="txtXiaoZhangShiJian2" type="text" id="txtXiaoZhangShiJian2" onfocus="WdatePicker()" class="searchinput inputtext" style="width: 65px;" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtXiaoZhangShiJian2") %>" />
                            <br/>
                            对方单位：<select name="txtDuiFangDanWeiLeiXing" id="txtDuiFangDanWeiLeiXing" class="inputselect">
                                <option value="">-请选择-</option>
                                <option value="0">客户单位</option>
                                <option value="1">供应商</option>
                            </select>
                            <span id="span_kehu_xuanyong">
                                <uc1:KeHuXuanZe runat="server" ID="txtKeHu" isrequired="false" />
                            </span><span id="span_gys_xuanyong">
                                <uc1:SupperControl runat="server" ID="txtGys" AllType="1" SupplierType="地接" />
                            </span>
                            
                            <a href="javascript:void(0);" id="a_DengZhang_Search">
                                <img src="/images/searchbtn.gif" alt="查询" style="border-width: 0px; vertical-align: middle;" /></a>
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/images/yuanright.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
        <div class="hr_10">
        </div>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="left">
                            <asp:PlaceHolder runat="server" ID="plnAdd"><a id="a_DengZhang_Add" href="javascript:void(0);">
                                登 记</a></asp:PlaceHolder>
                        </td>
                        <td width="90" align="left">
                            <asp:PlaceHolder runat="server" ID="plnShenPi" Visible="false"><a id="a_DengZhang_ShenPi"
                                href="javascript:void(0);">审 批</a></asp:PlaceHolder>
                        </td>
                        <td width="90" align="left">
                            <a id="a_toExcel" href="javascript:void(0);">导 出</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="border-top: 2px solid rgb(0, 0, 0);" class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tr>
                    <th width="10%" bgcolor="#bddcf4" align="center" style="height: 30px;">
                        <input type="checkbox" id="ckbAll" name="ckbAll" /><label for="ckbAll">到款时间</label>
                    </th>
                    <th width="10%" bgcolor="#bddcf4" align="center">
                        到款金额
                    </th>
                    <th width="10%" bgcolor="#bddcf4" align="center">
                        已销账金额
                    </th>
                    <th width="10%" bgcolor="#bddcf4" align="center">
                        未销账金额
                    </th>
                    <th width="28%" bgcolor="#bddcf4" align="center">
                        到款银行
                    </th>
                    <th width="7%" bgcolor="#bddcf4" align="center">
                        状态
                    </th>
                    <th bgcolor="#bddcf4" align="center">
                        备注
                    </th>
                    <th width="10%" bgcolor="#bddcf4" align="center">
                        操作
                    </th>
                </tr>
                <tbody id="tblItem">
                    <asp:Repeater runat="server" ID="rptDengZhang">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>" data-dengzhangid="<%# Eval("DengZhangId") %>">
                                <td align="center" style="height: 30px;">
                                    <%# (int)Eval("Status") == 0 ? "<input type=\"checkbox\" name=\"ckbDengZhang\" />" : "" %>
                                    <%# this.ToDateTimeString(Eval("DaoKuanTime"))%>
                                </td>
                                <td align="center">
                                    <%# this.ToMoneyString(Eval("DaoKuanJinE"))%>
                                </td>
                                <td align="center">
                                    <a href="javascript:void(0)" class="i_a_yixiaozhang"><%# this.ToMoneyString(Eval("UnCheckMoney"))%></a>
                                </td>
                                <td align="center">
                                    <font class="fred">
                                        <%# this.ToMoneyString((decimal)Eval("DaoKuanJinE") - (decimal)Eval("UnCheckMoney"))%></font>
                                </td>
                                <td align="center">
                                    <%# Eval("DaoKuanBankName")%>
                                </td>
                                <td align="center">
                                    <%# (int)Eval("Status") == 0 ? "<a href=\"javascript:void(0);\" class=\"shenPiDengZhang\" >未审批</a>" : "<a href=\"javascript:void(0);\" class=\"shenPiDengZhang\" i_chakan=\"1\">已审批</a>"%>
                                </td>
                                <td align="center">
                                    <%# Eval("Remark")%>
                                </td>
                                <td align="center">
                                    <%# GetHandleColumn(Eval("Status"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="odd">
                        <th align="right" style="height: 30px;">
                            合计：
                        </th>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrZongDaoKuan"></asp:Literal>
                        </td>
                        <td align="center">
                            <asp:Literal runat="server" ID="ltrZongXiaoZhang"></asp:Literal>
                        </td>
                        <td align="center" style="color: #ff0000">
                            <asp:Literal runat="server" ID="ltrWeiXiaoZhangHeJi"></asp:Literal>
                        </td>
                        <th align="center" colspan="4">
                        </th>
                    </tr>
                    <tr style="background-color: White">
                        <td height="30" align="right" class="pageup" colspan="7">
                            <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">

        var DengZhang = {
            reload: function() {
                window.location.href = window.location.href;
            },
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            addDengZhang: function() {
                DengZhang.ShowBoxy({
                    iframeUrl: "/Fin/DengZhangEdit.aspx?doType=add",
                    title: "登记出纳登账信息",
                    width: "850px",
                    height: "350px"
                });
            },
            updateDengZhang: function(obj) {
                DengZhang.ShowBoxy({
                    iframeUrl: "/Fin/DengZhangEdit.aspx?doType=edit&dzid=" + $(obj).closest("tr").attr("data-dengzhangid"),
                    title: "修改出纳登账信息",
                    width: "850px",
                    height: "350px"
                });
            },
            showDengZhang: function(obj) {
                DengZhang.ShowBoxy({
                    iframeUrl: "/Fin/DengZhangEdit.aspx?doType=show&dzid=" + $(obj).closest("tr").attr("data-dengzhangid"),
                    title: "查看出纳登账信息",
                    width: "650px",
                    height: "350px"
                });
            },
            delDengZhang: function(obj) {
                var dzid = $(obj).closest("tr").attr("data-dengzhangid");
                tableToolbar.ShowConfirmMsg("确定要删除此数据吗？", function() {
                    var data = {};
                    data.doType = "del";
                    data.dzid = dzid;
                    $.newAjax({
                        type: "get",
                        cache: false,
                        url: "/Fin/DengZhang.aspx?" + $.param(data),
                        dataType: "json",
                        success: function(ret) {
                            if (ret.result == "1") {
                                tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                            }
                            else {
                                tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                            }
                        },
                        error: function() {
                            tableToolbar._showMsg(tableToolbar.errorMsg);
                        }
                    });
                });
            },
            shenPiDengZhang: function(obj) {
                var _$obj = $(obj);
                var _$tr = _$obj.closest("tr");
                var _data = { dzid: _$tr.attr("data-dengzhangid") };
                var _title = "审批出纳登账信息";
                if (_$obj.attr("i_chakan") == "1") _title = "查看出纳登账审批信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "/Fin/DengZhangShenPi.aspx", width: "670px", height: "250px", data: _data, afterHide: function() { DengZhang.reload(); } });
            },
            piLiangShenPi: function() {
                var dzids = new Array();
                $("#tblItem").find("input[type='checkbox']:checked").each(function() {
                    dzids.push($(this).closest("tr").attr("data-dengzhangid"));
                });
                if (dzids.length <= 0) {
                    tableToolbar._showMsg("至少选择一条要审批的登账信息！");
                    return false;
                }
                var _url = "/Fin/DengZhangShenPi.aspx?dzid=" + dzids.join(',');
                Boxy.iframeDialog({ title: "审批出纳登账信息", iframeUrl: _url, width: "670px", height: "250px", data: {}, afterHide: function() { DengZhang.reload(); } });
            },
            xiaoZhang: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _url = "/Fin/DengZhangXiaoZhangDingDanKuan.aspx";
                var _data = { dzid: _$tr.attr("data-dengzhangid") };

                Boxy.iframeDialog({ title: "出纳登账销账", iframeUrl: _url, width: "920px", height: "530px", data: _data, afterHide: function() { DengZhang.reload(); } });
            },
            search: function() {
                var data = {};
                data.bid = $("#<%= ddlBank.ClientID %>").val();
                data.sd = $("#<%= txtStartDate.ClientID %>").val();
                data.ed = $("#<%= txtEndDate.ClientID %>").val();
                data.sid = $("#<%= ddlStatus.ClientID %>").val();

                data["txtDaoZhangJinEOperator"] = $("#txtDaoZhangJinEOperator").val();
                data["txtDaoZhangJinE"] = $("#txtDaoZhangJinE").val();
                data["txtWeiXiaoZhangJinEOperator"] = $("#txtWeiXiaoZhangJinEOperator").val();
                data["txtWeiXiaoZhangJinE"] = $("#txtWeiXiaoZhangJinE").val();

                data["txtXiaoZhangJinEOperator"] = $("#txtXiaoZhangJinEOperator").val();
                data["txtXiaoZhangJinE"] = $("#txtXiaoZhangJinE").val();

                data["txtXiaoZhangShiJian1"] = $("#txtXiaoZhangShiJian1").val();
                data["txtXiaoZhangShiJian2"] = $("#txtXiaoZhangShiJian2").val();

                var _keHuType = $("#txtDuiFangDanWeiLeiXing").val();
                data["txtDuiFangDanWeiLeiXing"] = _keHuType;
                data["txtDuiFangDanWeiId"] = "";
                data["txtDuiFangDanWeiName"] = "";

                if (_keHuType == "0") {
                    data["txtDuiFangDanWeiId"] = $("#<%=txtKeHu.KeHuIdClientId %>").val();
                    data["txtDuiFangDanWeiName"] = $("#<%=txtKeHu.KeHuMingChengClientId %>").val();
                }

                if (_keHuType == "1") {
                    data["txtDuiFangDanWeiId"] = $("#<%=txtGys.ClientValue %>").val();
                    data["txtDuiFangDanWeiName"] = $("#<%=txtGys.ClientText %>").val();
                }

                window.location.href = "/Fin/DengZhang.aspx?" + $.param(data);
            },
            toXls: function() {
                toXls1(utilsUri.createUri(null, {}));
                return false;
            },
            yiXiaoZahng: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { dengzhangid: _$tr.attr("data-dengzhangid") };
                Boxy.iframeDialog({ title: "已销账信息", iframeUrl: "dengzhangyixiaozhang.aspx", width: "980px", height: "500px", data: _data, afterHide: function() { DengZhang.reload(); } });
                return false;
            },
            chongDi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { dengzhangid: _$tr.attr("data-dengzhangid") };
                Boxy.iframeDialog({ title: "出纳登账-冲抵", iframeUrl: "dengzhangchongdi.aspx", width: "720px", height: "360px", data: _data, afterHide: function() { DengZhang.reload(); } });
                return false;
            },
            setKeHuXuanYong: function() {
                var _v = $("#txtDuiFangDanWeiLeiXing").val();
                if (_v == "0") {
                    $("#span_kehu_xuanyong").show();
                    $("#span_gys_xuanyong").hide();

                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                } else if (_v == "1") {
                    $("#span_kehu_xuanyong").hide();
                    $("#span_gys_xuanyong").show();

                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled");
                } else {
                    $("#span_kehu_xuanyong").hide();
                    $("#span_gys_xuanyong").hide();
                    $("#span_kehu_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                    $("#span_gys_xuanyong").find("input").removeAttr("disabled").attr("disabled", "disabled");
                }
            }
        };

        $(document).ready(function() {
            tableToolbar.init({ tableContainerSelector: "#liststyle" });

            $("#a_DengZhang_Search").click(function() { DengZhang.search(); return false; });
            $("#a_toExcel").click(function() { DengZhang.toXls(); return false; });

            $("#a_DengZhang_Add").click(function() { DengZhang.addDengZhang(); return false; });

            $("#a_DengZhang_ShenPi").click(function() { DengZhang.piLiangShenPi(); return false; });

            $(".editDengZhang").each(function() {
                $(this).click(function() { DengZhang.updateDengZhang(this); return false; });
            });

            $(".showDengZhang").each(function() {
                $(this).click(function() { DengZhang.showDengZhang(this); return false; });
            });

            $(".delDengZhang").each(function() {
                $(this).click(function() { DengZhang.delDengZhang(this); return false; });
            });
            $(".shenPiDengZhang").each(function() {
                $(this).click(function() { DengZhang.shenPiDengZhang(this); return false; });
            });
            $(".xiaoZhangDengZhang").each(function() {
                $(this).click(function() { DengZhang.xiaoZhang(this); return false; });
            });

            $(".i_a_yixiaozhang").click(function() { DengZhang.yiXiaoZahng(this); });
            $(".i_a_chongdi").click(function() { DengZhang.chongDi(this); });

            $("#txtDuiFangDanWeiLeiXing").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("txtDuiFangDanWeiLeiXing") %>')

            $("#txtDuiFangDanWeiLeiXing").change(function() { DengZhang.setKeHuXuanYong(); });
            DengZhang.setKeHuXuanYong();
        });
    </script>

</asp:Content>
