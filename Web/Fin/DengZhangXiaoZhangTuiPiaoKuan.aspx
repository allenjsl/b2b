<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DengZhangXiaoZhangTuiPiaoKuan.aspx.cs"
    Inherits="Web.Fin.DengZhangXiaoZhangTuiPiaoKuan" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/DengZhangXiaoZhangDaoHang.ascx" TagName="DengZhangXiaoZhangDaoHang"
    TagPrefix="uc1" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <uc1:DengZhangXiaoZhangDaoHang runat="server" id="DengZhangXiaoZhangDaoHang1">
    </uc1:DengZhangXiaoZhangDaoHang>
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <table cellspacing="1" cellpadding="0" border="0" align="center" style="width: 100%;
            margin: 0px auto;">
            <tr>
                <td>
                    <form id="form_chaxun">
                    <input type="hidden" name="dzid" id="dzid" />
                    <input type="hidden" name="iframeId" id="iframeId"  />
                    <input type="hidden" name="leixing" id="leixing"  />
                    <div class="searchbox" style="width: 100%;">
                        出团日期：
                        <input name="txtQuDate1" type="text" class="inputtext" id="txtQuDate1"
                            onfocus="WdatePicker()"  style="width:70px;" />
                        -<input name="txtQuDate2" type="text" class="inputtext" id="txtQuDate2"
                            onfocus="WdatePicker()" style="width:70px;" />
                        交易号：<input type="text" name="txtJiaoYiHao" id="txtJiaoYiHao" class="inputtext" style="width:80px;" />
                        订单号或编码：<input type="text" name="txtGysJiaoYiHao" id="txtGysJiaoYiHao" class="inputtext" style="width:80px;" />
                        代理商：<input type="text" name="txtDaiLiShangName" id="txtDaiLiShangName" class="inputtext" style="width:80px;" />
                        <input type="image" src="/images/searchbtn.gif" value="查询"  style="border-width: 0px; vertical-align: middle;" />
                        <br />可以销账金额：<font color="red"><%=KeYiXiaoZhangJinE.ToString("F2") %></font>
                    </div>
                    </form>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="0" border="0" align="center" style="width: 100%;
            margin: 0px auto; margin-top: 5px;">
            <tr class="odd">
                <td width="50px" height="30" bgcolor="#bddcf4" align="center">
                    <input type="checkbox" id="chkAll" name="chkAll" />
                    <label for="chkAll">全选</label>
                </td>
                <th style="width: 9%" bgcolor="#bddcf4">
                    销账金额
                </th>
                <th style="width: 9%" bgcolor="#bddcf4">
                    出团日期
                </th>
                <th style="width: 10%" bgcolor="#bddcf4">
                    代理商 
                </th>
                <th style="width: 7%" bgcolor="#bddcf4">
                    退票人数 
                </th>
                <th bgcolor="#bddcf4">
                    损失明细 
                </th>
                <th style="width: 8%" bgcolor="#bddcf4">
                    承担方 
                </th>
                <th style="width: 10%" bgcolor="#bddcf4">
                    退票时间
                </th>
                <th style="width: 9%" bgcolor="#bddcf4">
                    应退金额
                </th>
                <th style="width: 9%" bgcolor="#bddcf4">
                    已登记金额
                </th>
                <th style="width: 9%" bgcolor="#bddcf4">
                    未登记金额
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                        <td height="30" align="center">
                            <input type="checkbox" name="chk" value="<%# Eval("TuiPiaoId") %>" />
                        </td>
                        <td align="center">
                            <input name="txtXiaoZhangJinE" type="text" class="inputtext formsize50" value="<%# Eval("WeiDengJiJinE","{0:F2}") %>" maxlength="9" data-max="<%# Eval("WeiDengJiJinE","{0:F2}") %>" />
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_qudate"><%# Eval("QuDate","{0:yyyy-MM-dd}")%></a>
                            <span style="display:none;">
                                控位号：<%# Eval("KongWeiCode")%><br />
                                订单号：<%# Eval("DingDanHao")%><br />
                                退票交易号：<%# Eval("JiaoYiHao")%><br />
                                订单号或编码：<%# Eval("GysJiaoYiHao")%><br />
                                经手人：<%#Eval("JingShouRenName") %>
                            </span>
                        </td>
                        <td align="center">
                            <%# Eval("DaiLiShangName")%>
                        </td>
                        <td align="center">
                            <%# Eval("TuiPiaoRenShu")%>
                        </td>
                        <td align="center">
                            <%# Eval("SunShiMingXi")%>
                        </td>
                        <td align="center">
                            <%# Eval("ChengDanFang")%>
                        </td>
                        <td align="center">
                            <%# Eval("TuiPiaoShiJian","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString(Eval("YingTuiJinE"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString((decimal)Eval("YiShenPiJinE") + (decimal)Eval("WeiShenPiJinE"))%>
                        </td>
                        <td align="center">
                            <font class="fred">
                                <%# this.ToMoneyString(Eval("WeiDengJiJinE"))%></font>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            
            <asp:PlaceHolder runat="server" ID="phEmpty">
            <tr class="even" style="background-color: White">
                <td height="30" align="right" class="pageup" colspan="10">
                    暂未找到需要销账的退票款信息
                </td>
            </tr>
            </asp:PlaceHolder>
            
            <asp:PlaceHolder runat="server" ID="phPaging">
            <tr class="even" style="background-color: White">
                <td height="30" align="right" class="pageup" colspan="11">
                    <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                </td>
            </tr>
            </asp:PlaceHolder>
        </table>
        <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td height="40" align="center" class="tjbtn02">
                        <a id="i_a_xiaozhang" href="javascript:void(0)">销账</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            quanXuan: function() {
                if ($("#chkAll").attr("checked")) $("input[name='chk']").attr("checked", "checked");
                else $("input[name='chk']").removeAttr("checked");
            },
            xiaoZhang: function(obj) {
                var _data = { txtTuiPiaoId: [], txtXiaoZhangJinE: [] };
                var _yz = true;

                $("input[name='chk']:checked").each(function() {
                    var _tuiPiaoId = $(this).val();
                    var _inputJinE = $(this).closest("tr").find("input[name='txtXiaoZhangJinE']");
                    var _xiaoZhangJinE = tableToolbar.getFloat(_inputJinE.val());
                    var _maxJinE = tableToolbar.getFloat(_inputJinE.attr("data-max"));

                    if (_xiaoZhangJinE > _maxJinE) {
                        alert("销账金额不能大于未登记金额");
                        _inputJinE.focus();
                        _yz = false;
                        return false;
                    }

                    _data.txtTuiPiaoId.push(_tuiPiaoId);
                    _data.txtXiaoZhangJinE.push(_xiaoZhangJinE);
                });

                if (!_yz) return false;

                if (_data.txtTuiPiaoId.length == 0) {
                    alert("至少要选择一个需要销账的信息"); return false;
                }

                var _sum = 0;
                $(_data.txtXiaoZhangJinE).each(function() {
                    _sum = tableToolbar.calculate(_sum, this, "+");
                });

                if (_sum > tableToolbar.getFloat("<%=KeYiXiaoZhangJinE %>")) {
                    alert("销账金额(" + _sum.toFixed(2) + ")不能大于可以销账金额("+'<%=KeYiXiaoZhangJinE.ToString("F2") %>)'); return false;
                }

                if (!confirm("此次销账合计金额：" + _sum.toFixed(2) + "，你确定要进行销账吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.ajax({ type: "POST", url: window.location.href + "&doType=xiaozhang", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.xiaoZhang(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.xiaoZhang(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".i_qudate").bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['right'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 220, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            $("#chkAll").click(function() { iPage.quanXuan(); });
            $("#i_a_xiaozhang").click(function() { iPage.xiaoZhang(this); });
        });
    </script>
</asp:Content>
