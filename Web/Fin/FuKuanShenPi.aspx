<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FuKuanShenPi.aspx.cs" Inherits="Web.Fin.FuKuanShenPi" MasterPageFile="~/MasterPage/Front.Master" Title="付款审批-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 付款审批
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
                <div class="searchbox">
                    类型：
                    <select name="txtKuanXiangType" id="txtKuanXiangType" class="inputselect">
                        <%=GetKuanXiangTypeOptionHtml() %>
                    </select>
                    交易号：
                    <input name="txtJiaoYiHao" type="text" class="searchinput formsize80 inputtext" id="txtJiaoYiHao"
                        maxlength="50" />
                    供应商：
                    <input name="txtGysName" type="text" class="searchinput formsize80 inputtext" id="txtGysName"
                        maxlength="50" />
                    付款金额：<select name="txtFuKuanJinEOperator" id="txtFuKuanJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtFuKuanJinE" id="txtFuKuanJinE" class="searchinput w50 inputtext" />
                    付款状态：<select name="txtFuKuanStatus" id="txtFuKuanStatus" class="inputselect">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus)), "")%>
                    </select><br />
                    付款时间：<input name="txtFuKuanShiJian1" type="text" class="searchinput formsize80 inputtext"
                        id="txtFuKuanShiJian1" onfocus="WdatePicker()" />
                    -
                    <input name="txtFuKuanShiJian2" type="text" class="searchinput formsize80 inputtext"
                        id="txtFuKuanShiJian2" onfocus="WdatePicker()" />
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
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" class="i_shenpi_piliang">批量审批</a>
                </td>
                <td width="90" align="center">
                    <a href="javascript:void(0)" class="i_zhifu_piliang">批量支付</a>
                </td>
            </tr>
        </table>
    </div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="7%" height="30" align="center">
                    <input type="checkbox" class="i_chk_0" />全选
                </th>
                <th align="center">
                    类型
                </th>
                <th align="center">
                    交易号
                </th>
                <th align="center">
                    供应商
                </th>
                <th align="center">
                    付款时间
                </th>
                <th align="center">
                    付款人
                </th>
                <th align="center">
                    付款金额
                </th>
                <th align="center">
                    支付方式
                </th>
                <th width="80" align="center">
                    备注
                </th>
                <th align="center">
                    状态
                </th>
                <th align="center">
                    银行账号
                </th>
                <th width="70" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_fukuanid="<%#Eval("DengJiId") %>"
                        i_xmid="<%#Eval("FuKuanXiangMuId") %>" i_status="<%#(int)Eval("Status") %>" i_kuanxiangtype="<%#(int)Eval("KuanXiangType") %>"
                        style="height: 30px;">
                        <td align="center">
                            <input type="checkbox" class="i_chk_1" /><%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#GetKuanXiangType(Eval("KuanXiangType"))%>
                        </td>
                        <td align="center">
                            <%#Eval("JiaoYiHao")%>
                        </td>
                        <td align="center">
                            <%#Eval("GysName")%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("FuKuanRiQi"))%>
                        </td>
                        <td align="center">
                            <%#Eval("FuKuanRenName")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td align="center">
                            <%#Eval("FangShi") %>
                        </td>
                        <td align="center">
                            <%#Eval("FuKuanBeiZhu")%>
                        </td>
                        <td align="center">
                            <%#Eval("Status")%>
                        </td>
                        <td align="center">
                            <%#Eval("ZhangHuName")%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="12" style="height: 30px; text-align: center;">
                        暂无任何付款审批信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="6" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJinEHeJi"></asp:Literal>
                    </td>
                    <td colspan="5" align="center">
                        &nbsp;
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
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
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: _$tr.attr("i_kuanxiangtype"), fukuanid: _$tr.attr("i_fukuanid"), refererWinId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                _status = _$tr.attr("i_status");

                var _title = "付款审批";

                Boxy.iframeDialog({ title: _title, iframeUrl: "fukuanshenpiboxy.aspx", width: "650px", height: "200px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //获取选中的项 status:状态
            getChks: function(status) {
                var _data = { FuKuanId: [], XiangMuId: [], KuanXiangType: [] };
                $(".i_chk_1").each(function() {
                    if (!this.checked) return;
                    _$tr = $(this).parent().parent();
                    if (_$tr.attr("i_status") == status) {
                        _data.FuKuanId.push(_$tr.attr("i_fukuanid"));
                        _data.XiangMuId.push(_$tr.attr("i_xmid"));
                        _data.KuanXiangType.push(_$tr.attr("i_kuanxiangtype"));
                    }
                });

                return _data;
            },
            //批量审批
            shenPiPiLiang: function(obj) {
                var _data = this.getChks("<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未审批 %>");

                if (_data.FuKuanId.length == 0) { alert("请选择需要审批的款项。"); return; }

                var _iframedata = { piLiangType: "shenpi", refererWinId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };

                Boxy.iframeDialog({ title: "批量审批", iframeUrl: "fukuanshenpiboxy.aspx", width: "650px", height: "200px", data: _iframedata, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //支付
            zhiFu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _title = "付款支付";
                if ($(obj).attr("i_chakan") == "1") _title = "查看支付信息";
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: _$tr.attr("i_kuanxiangtype"), fukuanid: _$tr.attr("i_fukuanid"), refererWinId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                Boxy.iframeDialog({ title: _title, iframeUrl: "fukuanshenpiboxy.aspx", width: "650px", height: "350px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //批量支付
            zhiFuPiLiang: function(obj) {
                var _data = this.getChks("<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangStatus.未支付 %>");

                if (_data.FuKuanId.length == 0) { alert("请选择需要支付的款项。"); return; }

                var _iframedata = { piLiangType: "zhifu", refererWinId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };

                Boxy.iframeDialog({ title: "批量支付", iframeUrl: "fukuanshenpiboxy.aspx", width: "650px", height: "240px", data: _iframedata, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //全选
            chkAll: function(obj) {
                $(".i_chk_1").attr("checked", obj.checked);
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); });
            $(".i_shenpi_piliang").bind("click", function() { return iPage.shenPiPiLiang(this); });
            $(".i_zhifu").bind("click", function() { return iPage.zhiFu(this); });
            $(".i_zhifu_piliang").bind("click", function() { return iPage.zhiFuPiLiang(this); });
            $(".i_chk_0").bind("click", function() { iPage.chkAll(this); });
        });
    </script>

</asp:Content>
