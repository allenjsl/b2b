<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeHuXuanZe.aspx.cs" Inherits="Web.CommonPage.KeHuXuanZe" MasterPageFile="~/MasterPage/Boxy.Master"%>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width:99%; margin:0px auto;">
        <form method="get">
        <input type="hidden" id="KeHuIdClientId" name="KeHuIdClientId" value="<%=Request.QueryString["KeHuIdClientId"] %>" />
        <input type="hidden" id="KeHuMingChengClientId" name="KeHuMingChengClientId" value="<%=Request.QueryString["KeHuMingChengClientId"] %>" />
        <input type="hidden" id="RefererIframeId" name="RefererIframeId" value="<%=Request.QueryString["RefererIframeId"] %>" />
        <input type="hidden" id="CallbackFn" name="CallbackFn" value="<%=Request.QueryString["CallbackFn"] %>" />
        <input type="hidden" id="iframeId" name="iframeId"  value="<%=Request.QueryString["iframeId"] %>"/>
        <input type="hidden" id="DuiFangCaoZuoRenClientId" name="DuiFangCaoZuoRenClientId" value="<%=Request.QueryString["DuiFangCaoZuoRenClientId"] %>" />
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox" style="height: 30px;">
                        省份：<select name="txtShengFen" id="txtShengFen" class="inputselect">
                            </select>
                        城市：<select name="txtChengShi" id="txtChengShi" class="inputselect">
                            </select>
                        单位名称：
                        <input type="text" class="inputtext" id="txtMingCheng" name="txtMingCheng" style="width:100px;" />
                        联系人：
                        <input type="text" class="inputtext" id="txtLxrName" name="txtLxrName" style="width:60px;" />
                        客户类型：<select id="txtKeHuLeiXing" name="txtKeHuLeiXing" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.CustomerType)), EyouSoft.Common.Utils.GetQueryStringValue("txtKeHuLeiXing"), "", "-请选择-")%></select>
                        
                        <input type="image" src="/images/searchbtn.gif" style="vertical-align:middle;" />
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        </form>
    
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <th width="3%" align="center" bgcolor="#BDDCF4" style="height:25px;">
                        &nbsp;
                    </th>
                    <th width="16%" align="center" bgcolor="#bddcf4">
                        单位名称
                    </th>
                    <th width="10%" align="center" bgcolor="#BDDCF4">
                        所在地
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        联系人
                    </th>
                    <th width="9%" align="center" bgcolor="#bddcf4">
                        电话
                    </th>
                    <th style="width: 9%; background: #bddcf4;text-align:center;">客户类型</th>
                </tr>
                <asp:Repeater runat="server" ID="rptCustomer">
                    <ItemTemplate>
                        <tr style="background-color: <%# Container.ItemIndex % 2 == 0 ? "#e3f1fc" : "#BDDCF4" %>">
                            <td align="center" style="height:25px;">
                                <input type="radio" name="txtKeHuId" value="<%#Eval("Id") %>" id="txtKeHuId_<%#Eval("Id") %>" />
                                <span data-id="kehuid" style="display:none;"><%#Eval("Id") %></span>
                                <span data-id="kehuname" style="display:none;"><%#Eval("Name") %></span>
                                <span data-id="lxr" style="display:none;"><%#GetLxr(Eval("CustomerContact")) %></span>
                            </td>
                            <td align="center">
                                <%# Eval("Name")%>
                            </td>
                            <td align="center">
                                <%# Eval("ProvinceName")%>&nbsp;<%# Eval("CityName")%>
                            </td>
                            <td align="center">
                                <%# Eval("ContactName")%>
                            </td>
                            <td align="center" class="tel">
                                <%# Eval("Phone")%>
                            </td>
                            <td style="text-align: center;"><%#Eval("Type") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr class="even"><td colspan="20" style="height:25px">暂无任何客户资料信息</td></tr>
                </asp:PlaceHolder>
                
            </table>
            
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right" style="height:25px;">
                        <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                    </td>
                </tr>
            </table>
            
            <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="40" align="center" class="tjbtn02">
                        <a id="i_a_xuanze" href="javascript:void(0);">选择</a>
                    </td>
                </tr>
            </table>
    </div>


<script type="text/javascript">
    var iPage = {
        close: function() {
            var _win = top || window;
            var _iframeId = $("#iframeId").val();
            _win.Boxy.getIframeDialog(_iframeId).hide();
            return false;
        },
        getWindow: function() {
            var _refererIframeId = $("#RefererIframeId").val();
            var _win = null;
            if (_refererIframeId.length == 0) {
                _win = top.window;
            } else {
                _win = top.Boxy.getIframeWindow(_refererIframeId);
            }
            return _win;
        },
        xuanZe: function() {
            var _$obj = $("input[name='txtKeHuId']:checked");
            if (_$obj.length == 0) { alert("请选择客户单位"); return; }

            var _data = { keHuId: "", keHuName: "", lxrs: [] };
            var _$td = _$obj.closest("td");

            _data.keHuId = _$td.find("span[data-id='kehuid']").html();
            _data.keHuName = _$td.find("span[data-id='kehuname']").html();

            var _lxr = _$td.find("span[data-id='lxr']").html();
            _data.lxrs = JSON.parse(_lxr);

            var _win = this.getWindow();

            var _options = {};
            _options["KeHuIdClientId"] = $("#KeHuIdClientId").val();
            _options["KeHuMingChengClientId"] = $("#KeHuMingChengClientId").val();
            _options["CallbackFn"] = $("#CallbackFn").val();
            _options["DuiFangCaoZuoRenClientId"] = $("#DuiFangCaoZuoRenClientId").val();
            _options["data"] = _data;
            _win["wuc"]["keHuXuanZe_callback"](_options);

            iPage.close();
        },
        initXuanZe: function() {
            var _win = this.getWindow();
            var _KeHuIdClientId = $("#KeHuIdClientId").val();
            var _keHuId = $(_win.document).find("#" + _KeHuIdClientId).val();

            $("#txtKeHuId_" + _keHuId).attr("checked", "checked");
        }
    };

    $(document).ready(function() {
        utilsUri.initSearch();
        pcToobar.ginit({ pID: "#txtShengFen", cID: "#txtChengShi", pSelect: '<%=Request.QueryString["txtShengFen"] %>', cSelect: '<%=Request.QueryString["txtChengShi"] %>', comID: '<%=this.SiteUserInfo.CompanyId %>' });

        $("#i_a_xuanze").click(function() { iPage.xuanZe(); });
        iPage.initXuanZe();
    });
</script>
</asp:Content>