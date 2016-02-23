<%@ Page Title="酒店-资源管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="HotelList.aspx.cs" Inherits="Web.ResourceManage.HotelList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">资源管理</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                        所在位置 >> 资源管理 >> 酒店
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
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox">
                        <label>
                            省份：</label>
                        <select name="txtProvince" id="txtProvince" class="inputselect">
                        </select>
                        <label>
                            城市：</label>
                        <select name="txtCity" id="txtCity" class="inputselect">
                        </select>
                        <label>
                            酒店名称：</label><input name="HotelName" type="text" class="searchinput" id="HotelName"
                                value="<%=TxtHotelName %>" />
                        <label>
                            星级：</label>
                        <asp:DropDownList ID="HotelStartList" runat="server" CssClass="inputselect">
                            <asp:ListItem Text="--请选择星级--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <label>
                            <a href="javascript:void(0);" id="Searchbtn">
                                <img src="/images/searchbtn.gif" style="vertical-align: top;" alt="查询" /></a></label>
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        <div class="btnbox">
            <table width="45%" border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <%if (add)
                      { %>
                    <td width="90">
                        <a href="javascript:viod(0);" class="add">新 增</a>
                    </td>
                    <%} %>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <th width="3%" height="30" align="center" bgcolor="#BDDCF4">
                        序号
                    </th>
                    <th width="9%" align="center" bgcolor="#BDDCF4">
                        所在地
                    </th>
                    <th width="11%" align="center" bgcolor="#bddcf4">
                        单位名称
                    </th>
                    <th width="9%" align="center" bgcolor="#bddcf4">
                        星级
                    </th>
                    <th width="9%" align="center" bgcolor="#bddcf4">
                        联系人
                    </th>
                    <th width="9%" align="center" bgcolor="#bddcf4">
                        电话
                    </th>
                    <th width="9%" align="center" bgcolor="#bddcf4">
                        传真
                    </th>
                    <th width="9%" align="center" bgcolor="#bddcf4">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="RepList" runat="server">
                    <ItemTemplate>
                        <tr tid="<%# Eval("Id") %>" bgcolor="<%# Container.ItemIndex%2==0?"#e3f1fc":"#BDDCF4" %>">
                            <td height="30" align="center">
                                <%# Container.ItemIndex + 1 + (this.PageIndex - 1) * this.PageSize%>
                            </td>
                            <td align="center">
                                <%# Eval("ProvinceName")%><%# Eval("CityName")%>
                            </td>
                            <td align="center">
                                <%# Eval("UnitName")%>
                            </td>
                            <td align="center">
                                <%# GetStarValue(Eval("Star").ToString())%>
                            </td>
                            <td align="center">
                                <%# Eval("SupplierContact") ==null?"":(Eval("SupplierContact") as System.Collections.Generic.List<EyouSoft.Model.CompanyStructure.SupplierContact>)[0].ContactName%>
                            </td>
                            <td align="center">
                                <%# Eval("SupplierContact") ==null?"":(Eval("SupplierContact") as System.Collections.Generic.List<EyouSoft.Model.CompanyStructure.SupplierContact>)[0].ContactTel%>
                            </td>
                            <td align="center">
                                <%# Eval("SupplierContact") ==null?"":(Eval("SupplierContact") as System.Collections.Generic.List<EyouSoft.Model.CompanyStructure.SupplierContact>)[0].ContactFax%>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0);" class="show">查看 </a>
                                <% if (update)
                                   { %><a href="javascript:viod(0);" class="modify">修改</a><%} if (del)
                                   { %>
                                <a href="javascript:;" class="del">删除</a><%} %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" LinkType="4" PageStyleType="NewButton"
                            CurrencyPageCssClass="RedFnt" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        var Hotel = {
            Search: function() {
                var province = $("#txtProvince").val();
                var city = $("#txtCity").val();
                var HotelName = $.trim($("#HotelName").val());
                var HotelStartValue = $.trim($("#<%=HotelStartList.ClientID %>").val());
                //参数
                var para = { province: "", city: "", HotelName: "", HotelStartValue: "" };
                para.province = province;
                para.city = city;
                para.HotelName = HotelName;
                para.HotelStartValue = HotelStartValue;
                window.location.href = "/ResourceManage/HotelList.aspx?" + $.param(para);
            }
        };
        //查询
        $("#Searchbtn").click(function() {
            Hotel.Search();
            return false;
        });
        //新增
        $("a.add").click(function() {
            var url = "/ResourceManage/HotelAdd.aspx";
            Boxy.iframeDialog({
                iframeUrl: url,
                title: "新增酒店信息",
                modal: true,
                width: "920px",
                height: "670px"
            });
            return false;
        });
        //删除
        $("a.del").click(function() {
            if (confirm("确认删除所选项?")) {
                var that = $(this);
                var tid = that.parent().parent().attr("tid");
                $.newAjax({
                    type: "POST",
                    data: { "tid": tid },
                    url: "/ResourceManage/HotelList.aspx?action=hoteldel",
                    dataType: 'json',
                    success: function(msg) {
                        if (msg.res) {
                            switch (msg.res) {
                                case 1:
                                    alert("删除成功!");
                                    location.reload();
                                    break;
                                default:
                                    alert("删除失败!");
                            }
                        }
                    },
                    error: function() {
                        alert("服务器繁忙!");
                    }
                });
            }
            return false;
        });
        //修改
        $("a.modify").click(function() {
            var that = $(this);
            var url = "/ResourceManage/HotelAdd.aspx?type=modify&";
            var tid = that.parent().parent().attr("tid");
            Boxy.iframeDialog({
                iframeUrl: url + "tid=" + tid,
                title: "修改",
                modal: true,
                width: "920px",
                height: "670px"
            });
            return false;
        });
        $("a.show").click(function() {
            var that = $(this);
            var url = "/ResourceManage/HotelAdd.aspx?type=show&";
            var tid = that.parent().parent().attr("tid");
            Boxy.iframeDialog({
                iframeUrl: url + "tid=" + tid,
                title: "查看",
                modal: true,
                width: "920px",
                height: "670px"
            });
            return false;
        });


        $(document).ready(function() {
            pcToobar.init({
                pID: "#txtProvince",
                cID: "#txtCity",
                pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("province"),0) %>',
                cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("city"),0) %>',
                comID: '<%= this.SiteUserInfo.CompanyId %>',
                isCy: "0"
            });
        });
    </script>

</asp:Content>
