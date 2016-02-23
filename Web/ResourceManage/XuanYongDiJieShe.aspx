<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XuanYongDiJieShe.aspx.cs" Inherits="Web.ResourceManage.XuanYongDiJieShe" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <form method="get">
        <input type="hidden" value="" name="RefererIframeId" id="RefererIframeId">
        <input type="hidden" value="" name="gysZhuTiId" id="gysZhuTiId">
        <input type="hidden" value="" name="iframeId" id="iframeId">
        
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/images/yuanleft.gif" />
                    </td>
                    <td>
                        <div style="height: 60px;" class="searchbox">
                            省份：<select class="inputselect" id="txtShengFen" name="txtShengFen">
                            </select>
                            城市：<select class="inputselect" id="txtChengShi" name="txtChengShi"><option value="">--请选择--</option>
                            </select>
                            地接社名称：
                            <input type="text" style="width: 250px;" name="txtGysName" id="txtGysName" class="inputtext" /><br /> 
                            所属专线商：<select name="txtZxs" id="txtZxs" class="inputselect"><option value="">-请选择-</option>
                                <asp:Literal runat="server" ID="ltrZxs"></asp:Literal></select>          
                            <input type="image" style="vertical-align: middle;" src="/images/searchbtn.gif" />
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/images/yuanright.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        </form>        
    
        <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
            <tr>
                <th width="50" align="center" bgcolor="#BDDCF4" style="height: 30px;">
                    选用
                </th>
                <th align="left" bgcolor="#bddcf4" width="20%">
                    &nbsp;地接社所在地
                </th>
                <th align="left" bgcolor="#bddcf4">
                    &nbsp;地接社名称
                </th>
                <th align="left" bgcolor="#bddcf4" width="40%">
                    &nbsp;所属专线商
                </th>
                <%--<th width="10%" align="center" bgcolor="#bddcf4">
                    联系人姓名
                </th>
                <th width="10%" align="center" bgcolor="#bddcf4">
                    联系人电话
                </th>
                <th width="10%" align="center" bgcolor="#bddcf4">
                    联系传真
                </th>--%>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr data-class="item" data-gysid="<%#Eval("GysId") %>" data-gysname="<%#Eval("GysName") %>" data-gyszhutiid="<%#Eval("GysZhuTiId") %>" class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                        <td width="50" align="center" style="height: 30px;">
                            <input type="checkbox" name="chk" id="chk_<%#Eval("GysId") %>" />
                        </td>                        
                        <td align="left">
                            &nbsp;<%#Eval("ShengFenName") %>-<%#Eval("ChengShiName") %>
                        </td>
                        <td align="left">
                            &nbsp;<%#Eval("GysName") %>
                        </td>
                        <td align="left">
                            &nbsp;<%#Eval("ZxsName") %>
                        </td>
                        <%--<td align="center" bgcolor="#bddcf4">
                            <%#Eval("LxrName") %>
                        </td>
                        <td align="center" bgcolor="#bddcf4">
                            <%#Eval("LxrDianHua") %>
                        </td>
                        <td align="center" bgcolor="#bddcf4">
                            <%#Eval("Fax") %>
                        </td>--%>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr class="even">
                    <td style="height: 30px; text-align: center;" colspan="10">
                        暂无地接社信息
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr>
                <td height="30" colspan="11" align="right" class="pageup">
                    <cc1:exporpageinfoselect id="FenYe" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            getWindow: function() {
                var _refererIframeId = '<%=EyouSoft.Common.Utils.GetQueryStringValue("RefererIframeId") %>';
                var _win = null;
                if (_refererIframeId.length == 0) {
                    _win = top.window;
                } else {
                    _win = top.Boxy.getIframeWindow(_refererIframeId);
                }
                return _win;
            },
            xuanZe: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _gysid = _$tr.attr("data-gysid");
                var _gysname = _$tr.attr("data-gysname");
                var _checked = $(obj).attr("checked");
                var _win = this.getWindow();
                if (_checked) {
                    _win.iPage.setGuanXi({ gysid: _gysid, gysname: _gysname });
                } else {
                    _win.iPage.shanChuGuanXi1({ gysid: _gysid, gysname: _gysname });
                }
            },
            initXuanZe: function() {
                var _win = this.getWindow();
                var _items = _win.iPage.getGuanXis();
                if (_items.length == 0) return;
                for (var i = 0; i < _items.length; i++) {
                    $("#chk_" + _items[i]).attr("checked", "checked");
                }
            },
            initKeXuan: function() {
                var _gysZhuTiId = '<%=EyouSoft.Common.Utils.GetQueryStringValue("gysZhuTiId") %>';
                $('tr[data-class="item"]').each(function() {
                    var _$tr = $(this);
                    _$tr.find("input[name='chk']").removeAttr("disabled");
                    var _tr_data_gyszhutiid = $.trim(_$tr.attr("data-gyszhutiid"));
                    if (_tr_data_gyszhutiid.length == 0) return true;

                    if (_gysZhuTiId != _tr_data_gyszhutiid) {
                        _$tr.find("input[name='chk']").attr("disabled", "disabled");
                        _$tr.css({ "color": "#666666" }).attr("title", "该地接社已被其它地接社主体选用");
                    }
                })
            }
        };

        $(document).ready(function() {
            $('input[name="chk"]').click(function() { iPage.xuanZe(this); });
            iPage.initXuanZe();
            iPage.initKeXuan();

            utilsUri.initSearch();
            pcToobar.ginit({ pID: "#txtShengFen", cID: "#txtChengShi", pSelect: '<%=Request.QueryString["txtShengFen"] %>', cSelect: '<%=Request.QueryString["txtChengShi"] %>', comID: '<%=this.SiteUserInfo.CompanyId %>' });
        });
    </script>
</asp:Content>

