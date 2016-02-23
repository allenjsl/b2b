<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuCeKeHu.aspx.cs" Inherits="Web.CustomerManage.ZhuCeKeHu" MasterPageFile="~/MasterPage/Front.Master" Title="注册客户管理-客户管理"%>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">客户管理</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            <b>当前您所在位置：</b> &gt;&gt; 客户管理 &gt;&gt; 客户资料
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
        <form method="get" id="form1">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="../images/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <div class="searchbox">
                            省份：
                            <select id="ddlProvice" class="inputselect" name="ddlProvice">
                            </select>
                            城市：
                            <select id="ddlCity" class="inputselect" name="ddlCity">
                            </select>
                            单位名称：
                            <input type="text" class="inputtext searchinput" name="txtKeHuName" id="txtKeHuName" />
                            <label>
                                联系人：</label>
                            <input type="text" id="txtLxrName" class="searchinput inputtext" name="txtLxrName"/>
                            审核状态：<select id="txtShenHeStatus" name="txtShenHeStatus" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.KeHuShenHeStatus)), EyouSoft.Common.Utils.GetQueryStringValue("txtShenHeStatus"), "", "-请选择-")%></select>
                            <br/>注册时间：<input type="text" class="inputtext" style="width:80px;" onfocus="WdatePicker()" id="txtZhuCeShiJian1" name="txtZhuCeShiJian1" />-<input id="txtZhuCeShiJian2" name="txtZhuCeShiJian2" type="text" class="inputtext"  style="width:80px;" onfocus="WdatePicker()" />
                            <input type="submit" value=" " class="search-btn" />
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="../images/yuanright.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
        <div class="btnbox">
            
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="36" bgcolor="#BDDCF4" align="center">
                            序号
                        </th>
                        <th width="11%" bgcolor="#BDDCF4" align="center">
                            所在地
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            单位名称
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            联系人
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            电话
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            传真
                        </th>
                        <th width="8%" bgcolor="#bddcf4" align="center">
                            责任销售
                        </th>
                        <th style="width: 8%; text-align: center; background: #bddcf4;">客户类型</th>
                        <th style="width: 8%; text-align: center; background: #bddcf4;">注册时间</th>
                        <th style="width: 8%; text-align: center; background: #bddcf4;">审核状态</th>
                        <th width="12%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>' data-kehuid="<%#Eval("Id") %>">
                                <td align="center">
                                    <span class="selector_index"><%# (Container.ItemIndex + 1+(this.pageIndex-1)*this.pageSize)%></span>
                                &nbsp;&nbsp;</td>
                                <td align="center">
                                    <%#Eval("ProvinceName")%> <%#Eval("CityName")%>
                                </td>
                                <td align="center">
                                    <a class="tool_update" href="javascript:void(0)" data-ischakan="1"><%#Eval("Name")%></a>
                                </td>
                                <td align="center">
                                    <%#Eval("ContactName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Phone")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Fax")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Saler")%>
                                </td>
                                <td style="text-align:center"><%#Eval("Type") %></td>
                                <td style="text-align:center"><%#Eval("IssueTime","{0:yyyy-MM-dd}") %></td>
                                <td style="text-align:center"><%#GetShenHeStatus(Eval("ShenHeStatus")) %></td>
                                <td align="left">
                                    &nbsp;<%#GetCaoZuoHtml(Eval("ShenHeStatus")) %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:repeater>
                    <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                        <tr>
                            <td colspan="9" align="center">
                                暂无数据。
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                </tbody>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right">
                             <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function() {
            pcToobar.init({ pID: "#ddlProvice", cID: "#ddlCity", comID: '<%=this.SiteUserInfo.CompanyId %>', pSelect: '<%=Request.QueryString["ddlProvice"] %>', cSelect: '<%=Request.QueryString["ddlCity"] %>' });
            $(".chakan").click(function() { iPage.update(this); return false; });
            $(".shanchu").click(function() { iPage.del(this); return false; });
            $(".shenhe").click(function() { iPage.shenHe(this); return false; });
            $(".yonghuguanli").click(function() { iPage.yongHuGuanLi(this); return false; });
            utilsUri.initSearch();
        })

        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { id: _$tr.attr("data-kehuid") };
                var _title = "修改客户资料";
                if ($(obj).attr("data-ischakan") == "1") _title = "查看客户资料";
                Boxy.iframeDialog({ title: _title, iframeUrl: "customeradd.aspx", width: "920px", height: "520px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            del: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtKeHuId: _$tr.attr("data-kehuid") };
                if (!confirm("客户资料删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "zhucekehu.aspx?dotype=delete", dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });
            },
            yongHuGuanLi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { kehuid: _$tr.attr("data-kehuid") };
                Boxy.iframeDialog({ title: "账号管理", iframeUrl: "kehulxryonghuedit.aspx", width: "920px", height: "520px", data: _data, afterHide: function() { iPage.reload(); } });
            },
            shenHe: function(obj) {
                if (!confirm("你确定要审核该注册客户信息吗？")) return false;
                var _$tr = $(obj).closest("tr");
                var _data = { txtKeHuId: _$tr.attr("data-kehuid") };
                $.newAjax({
                    type: "post", cache: false, url: "zhucekehu.aspx?dotype=shenhe", dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });
            }
        }
    </script>
</asp:Content>
