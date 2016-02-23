<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DengZhangXiaoZhangJieSuanQiTaShouRu.aspx.cs" Inherits="Web.Fin.DengZhangXiaoZhangJieSuanQiTaShouRu" MasterPageFile="~/MasterPage/Boxy.Master" %>

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
                        对方单位：<input type="text" name="txtDuiFangDanWeiName" id="txtDuiFangDanWeiName" class="inputtext" style="width:80px;" />
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
                <th style="width: 8%" bgcolor="#bddcf4">
                    销账金额
                </th>
                <th style="width: 8%" bgcolor="#bddcf4">
                    出团日期
                </th>
                <th style="width: 8%" bgcolor="#bddcf4">
                    控位号
                </th>
                <th style="width: 9%" bgcolor="#bddcf4">
                    收入时间
                </th>
                <th bgcolor="#bddcf4">
                    收入项目
                </th>
                <th style="width: 7%" bgcolor="#bddcf4">
                    收入备注 
                </th>
                <th bgcolor="#bddcf4" style="width:10%">
                    对方单位
                </th>
                <th style="width: 11%" bgcolor="#bddcf4">
                    收入金额 
                </th>
                <th style="width: 11%" bgcolor="#bddcf4">
                    已登记金额
                </th>
                <th style="width: 11%" bgcolor="#bddcf4">
                    未登记金额
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd" %>">
                        <td height="30" align="center">
                            <input type="checkbox" name="chk" value="<%# Eval("QiTaShouRuId") %>" />
                        </td>
                        <td align="center">
                            <input name="txtXiaoZhangJinE" type="text" class="inputtext formsize50" value="<%# Eval("WeiDengJiJinE","{0:F2}") %>" maxlength="9" data-max="<%# Eval("WeiDengJiJinE","{0:F2}") %>" />
                        </td>
                        <td align="center">
                            <%# Eval("QuDate","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# Eval("KongWeiCode")%>
                        </td>
                        <td align="center">
                            <%# Eval("ShouRuShiJian","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# Eval("ShouRuXiangMu")%>
                        </td>
                        <td align="center">
                            <%# Eval("ShouRuBeiZhu")%>
                        </td>
                        <td align="center">
                            <%# Eval("DuiFangDanWeiName")%>
                        </td>
                        <td align="center">
                            <%# Eval("JinE","{0:F2}")%>
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
                <td height="30" align="center" class="pageup" colspan="10">
                    暂未找到需要销账的团队结算其它收入款信息
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
                var _data = { txtQiTaShouRuId: [], txtXiaoZhangJinE: [] };
                var _yz = true;

                $("input[name='chk']:checked").each(function() {
                    var _qiTaShouRuId = $(this).val();
                    var _inputJinE = $(this).closest("tr").find("input[name='txtXiaoZhangJinE']");
                    var _xiaoZhangJinE = tableToolbar.getFloat(_inputJinE.val());
                    var _maxJinE = tableToolbar.getFloat(_inputJinE.attr("data-max"));

                    if (_xiaoZhangJinE > _maxJinE) {
                        alert("销账金额不能大于未登记金额");
                        _inputJinE.focus();
                        _yz = false;
                        return false;
                    }

                    _data.txtQiTaShouRuId.push(_qiTaShouRuId);
                    _data.txtXiaoZhangJinE.push(_xiaoZhangJinE);
                });

                if (!_yz) return false;

                if (_data.txtQiTaShouRuId.length == 0) {
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
            $("#chkAll").click(function() { iPage.quanXuan(); });
            $("#i_a_xiaozhang").click(function() { iPage.xiaoZhang(this); });
        });
    </script>
</asp:Content>
