<%@ Page Title="出纳登帐销账页面" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master"
    AutoEventWireup="true" CodeBehind="DengZhangXiaoZhangDingDanKuan.aspx.cs" Inherits="Web.Fin.DengZhangXiaoZhangDingDanKuan" %>

<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/DengZhangXiaoZhangDaoHang.ascx" TagName="DengZhangXiaoZhangDaoHang" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <uc1:DengZhangXiaoZhangDaoHang runat="server" id="DengZhangXiaoZhangDaoHang1"></uc1:DengZhangXiaoZhangDaoHang>    
    <form runat="server" id="form1">
    <table cellspacing="1" cellpadding="0" border="0" align="center" style="width:99%; margin:0px auto; margin-top:5px;">
        <tbody>
            <tr>
                <td>
                    <div class="searchbox" style="width: 100%;">
                        出团日期：
                        <input name="txtLSDate" type="text" class="searchinput formsize80 inputtext" id="txtLSDate"
                            onfocus="WdatePicker()" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtLSDate") %>" />
                        -
                        <input name="txtLEDate" type="text" class="searchinput formsize80 inputtext" id="txtLEDate"
                            onfocus="WdatePicker()" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("txtLEDate") %>" />
                        <label>客户单位：</label>
                        <uc1:KeHuXuanZe runat="server" ID="txtKeHu" />                        
                        <a href="javascript:void(0);" id="a_XiaoZhang_Search">
                            <img alt="点击查询" src="/images/searchbtn.gif" style="border-width: 0px; vertical-align: middle;" /></a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 可以销账金额：<font
                            color="red"><asp:Literal runat="server" ID="ltrKeyi"></asp:Literal></font>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="1" cellpadding="0" border="0" align="center" id="liststyle" style="width:99%; margin:0px auto; margin-top:5px;">
        <tr class="odd">
            <td width="70px" height="30" bgcolor="#bddcf4" align="center">
                <input type="checkbox" id="chkAll" name="chkAll" />
                <label for="chkAll">全选</label>
            </td>
            <th style="width: 9%" bgcolor="#bddcf4">
                销账金额
            </th>
            <th style="width: 9%" bgcolor="#bddcf4">
                团号
            </th>
            <th bgcolor="#bddcf4">
                线路名称
            </th>
            <th style="width: 9%" bgcolor="#bddcf4">
                出团时间
            </th>
            <th style="width: 10%" bgcolor="#bddcf4">
                订单号
            </th>
            <th style="width: 12%" bgcolor="#bddcf4">
                客户单位
            </th>
            <th style="width: 9%" bgcolor="#bddcf4">
                应收金额
            </th>
            <th style="width: 9%" bgcolor="#bddcf4">
                已登记金额
            </th>
            <th style="width:9%" bgcolor="#bddcf4">
                未登记金额
            </th>
        </tr>
        <tbody id="tblXiaoZhangOrder">
            <asp:Repeater runat="server" ID="rptOrder">
                <ItemTemplate>
                    <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                        <td height="30" align="center">
                            <input type="checkbox" name="ckbOrder" value="<%# Eval("OrderId") %>" />
                        </td>
                        <td align="center">
                            <input type="text" class="searchinput inputtext formsize50" name="txt_XiaoZhang_Money" value="<%# Eval("WeiDengJiJinE","{0:F2}") %>" maxlength="9" />
                        </td>
                        <td align="center">
                            <%# Eval("KongWeiCode")%>
                        </td>
                        <td align="center">
                            <%# Eval("RouteName")%>
                        </td>
                        <td align="center">
                            <%# Eval("QuDate") == null ? string.Empty : this.ToDateTimeString(Eval("QuDate"))%>
                        </td>
                        <td align="center">
                            <%# Eval("OrderCode")%>
                        </td>
                        <td align="center">
                            <%# Eval("BuyCompanyName")%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString(Eval("SumPrice"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString((decimal)Eval("YiShenPiJinE") + (decimal)Eval("WeiShenPiJinE") - (decimal)Eval("TuiYiShenPiJinE") - (decimal)Eval("TuiWeiShenPiJinE"))%>
                        </td>
                        <td align="center">
                            <font class="fred"><%# this.ToMoneyString(Eval("WeiDengJiJinE"))%></font>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr class="even" style="background-color: White">
                <td height="30" align="right" class="pageup" colspan="10">
                    <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                </td>
            </tr>
        </tbody>
    </table>
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center" class="tjbtn02">
                    <a id="a_XiaoZhang_Save" href="javascript:void(0)">销账</a>
                </td>
            </tr>
        </tbody>
    </table>
    </form>

    <script type="text/javascript">
        var XiaoZhang = {
            _data: [],
            _money: 0,
            reload: function() {
                window.location.href = window.location.href;
            },
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            search: function() {
                var data = {};
                data.cid = $("#<%= txtKeHu.KeHuIdClientId %>").val();
                data.cname = $("#<%=txtKeHu.KeHuMingChengClientId %>").val();
                data.iframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
                data.dzid = '<%= EyouSoft.Common.Utils.GetQueryStringValue("dzid") %>';
                data["txtLEDate"] = $("#txtLEDate").val(); ;
                data["txtLSDate"] = $("#txtLSDate").val(); ;

                window.location.href = "/Fin/DengZhangXiaoZhangDingDanKuan.aspx?" + $.param(data);
            },
            GetValus: function() {
                XiaoZhang._data = [];
                XiaoZhang._money = 0;
                $("#tblXiaoZhangOrder").find("input[type='checkbox']:checked").each(function() {
                    var _$obj = $(this);
                    var _$tr = _$obj.closest("tr");

                    var tmp = { name: "ckbOrder", value: "" };
                    tmp.value = _$obj.val();

                    XiaoZhang._data.push(tmp);

                    var tmp1 = { name: "txt_XiaoZhang_Money", value: "" };
                    tmp1.value = tableToolbar.getFloat(_$tr.find("input[name='txt_XiaoZhang_Money']").val());

                    XiaoZhang._data.push(tmp1);

                    XiaoZhang._money = tableToolbar.calculate(XiaoZhang._money, tmp1.value, "+");
                });
            },
            saveData: function(obj) {
                XiaoZhang.GetValus();
                if (XiaoZhang._data.length <= 0) {
                    tableToolbar._showMsg("至少要选择一条要销账的订单！");
                    return false;
                }
                var keyi = tableToolbar.getFloat("<%= KeYiXiaoZhangJinE %>");
                if (XiaoZhang._money > keyi) {
                    tableToolbar._showMsg("已经选择的销账金额超过了可以销账的金额！");
                    return false;
                }
                if (!confirm("此次销账合计金额：" + XiaoZhang._money.toFixed(2) + "，你确定要进行销账吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                var p = { iframeId: "", dzid: "", save: "1" };
                p.iframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
                p.dzid = '<%= EyouSoft.Common.Utils.GetQueryStringValue("dzid") %>';
                $.newAjax({
                    type: "post", dataType: "json", cache: false, async: false,
                    url: "/Fin/DengZhangXiaoZhangDingDanKuan.aspx?" + $.param(p),
                    data: XiaoZhang._data,
                    success: function(ret) {
                        if (ret.result == "1") {
                            alert(ret.msg);
                            XiaoZhang.reload();
                        }
                        else {
                            alert(ret.msg);
                            $(obj).bind("click", function() { XiaoZhang.saveData(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { XiaoZhang.saveData(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            tableToolbar.init({ tableContainerSelector: "#liststyle" });
            $("#a_XiaoZhang_Search").click(function() { XiaoZhang.search(); return false; });
            $("#a_XiaoZhang_Save").click(function() { XiaoZhang.saveData(); return false; }).html("销账").css({ "color": "" });
        });
    </script>

</asp:Content>
