<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="CustomerUnitSelect.aspx.cs" Inherits="Web.CommonPage.CustomerUnitSelect" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <div>
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox" style="height: 30px;">
                        省份：
                        <asp:DropDownList runat="server" ID="ddlProvince">
                        </asp:DropDownList>
                        城市：
                        <asp:DropDownList runat="server" ID="ddlCity">
                        </asp:DropDownList>
                        单位名称：
                        <input type="text" runat="server" class="searchinput inputtext" id="txtCustomer" />
                        联系人：
                        <input type="text" runat="server" class="searchinput inputtext" id="txtContact" />
                        客户类型：<select id="txtKeHuLeiXing" name="txtKeHuLeiXing" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.CustomerType)), EyouSoft.Common.Utils.GetQueryStringValue("txtKeHuLeiXing"), "", "-请选择-")%></select>
                        <label>
                            <a href="javascript:void(0);" id="a_search">
                                <img src="/images/searchbtn.gif" border="0" />
                            </a>
                        </label>
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        <div class="tablelist" style="margin-left: 5px">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" id="cTableList">
                <tr>
                    <th width="3%" align="center" bgcolor="#BDDCF4">
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
                            <td align="center">
                                <%# GetInputHtml(Eval("Id"), Eval("Name"), Eval("ContactName"), Eval("Phone"), Eval("Mobile"))%>
                                <div class="cclist" style="display: none">
                                    <%# GetContactList(Eval("CustomerContact")) %></div>
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
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                    </td>
                </tr>
            </table>
            <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="40" align="center">
                    </td>
                    <td height="40" align="center" class="tjbtn02">
                        <a id="btnSave" href="javascript:void(0);">确定</a>
                    </td>
                    <td height="40" align="center" class="tjbtn02">
                        <a href="javascript:void(0);" onclick="parent.Boxy.getIframeDialog('<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide()">
                            关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var CustomerUnitSelect = {
            _ccinfo: {
                ccId: "", //联系人编号
                ccname: ""//联系人名称
            },
            _data: {
                cid: "", //客户编号
                cname: "", //客户名称
                ccname: "", //主要联系人名称
                cctel: "", //主要联系人电话
                ccmobile: "", //只要联系人手机
                cclist: ""//所有非主要联系人信息(含名称和编号 格式为 _ccinfo 对象集合)
            },
            _rdata: [], //返回给父页面的对象 格式为 _data 对象的集合,
            SetValue: function() {
                var str = "";
                var index = 0;
                if ("<%= IsSelectMore %>" == "1") {//多选
                    $("#cTableList").find("input[type='checkbox']:checked").each(function() {
                        var tdata = {};
                        tdata.cid = $(this).val();
                        tdata.cname = $(this).attr("data-cname");
                        tdata.ccname = $(this).attr("data-ccname");
                        tdata.cctel = $(this).attr("data-tel");
                        tdata.ccmobile = $(this).attr("data-mobile");
                        tdata.cclist = $.trim($(this).closest("td").find("div[class='cclist']").text());

                        CustomerUnitSelect._rdata.push(tdata);
                    })
                }
                else {//单选
                    $("#cTableList").find("input[type='radio']:checked").each(function() {
                        var tdata = {};
                        tdata.cid = $(this).val();
                        tdata.cname = $(this).attr("data-cname");
                        tdata.ccname = $(this).attr("data-ccname");
                        tdata.cctel = $(this).attr("data-tel");
                        tdata.ccmobile = $(this).attr("data-mobile");
                        tdata.cclist = $.trim($(this).closest("td").find("div[class='cclist']").text());

                        CustomerUnitSelect._rdata.push(tdata);
                    })
                }
            },
            SelectValue: function() {
                var callBack = '<%= EyouSoft.Common.Utils.GetQueryStringValue("callBack") %>';
                var pIframeID = '<%= EyouSoft.Common.Utils.GetQueryStringValue("pIframeId") %>';

                //根据父级是否为弹窗传值
                if (pIframeID != "" && pIframeID.length > 0) {
                    //定义父级弹窗
                    var boxyParent = window.parent.Boxy.getIframeWindow(pIframeID) || window.parent.Boxy.getIframeWindowByID(pIframeID);
                    //判断是否存在回调方法
                    if (callBack != null && callBack.length > 0) {
                        if (callBack.indexOf('.') == -1) {
                            boxyParent[callBack](CustomerUnitSelect._rdata);
                        }
                        else {
                            boxyParent[callBack.split('.')[0]][callBack.split('.')[1]](CustomerUnitSelect._rdata);
                        }
                    }
                    //定义回调
                }
                else {
                    //判断是否存在回调方法
                    if (callBack != null && callBack.length > 0) {
                        if (callBack.indexOf('.') == -1) {
                            window.parent[callBack](CustomerUnitSelect._rdata);
                        }
                        else {
                            window.parent[callBack.split('.')[0]][callBack.split('.')[1]](CustomerUnitSelect._rdata);
                        }
                    }
                    //定义回调
                }
                parent.Boxy.getIframeDialog('<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
            },
            Search: function() {
                var data = { txtKeHuLeiXing: $("#txtKeHuLeiXing").val() };
                data.pid = $("#<%= ddlProvince.ClientID %>").val();
                data.cid = $("#<%= ddlCity.ClientID %>").val();
                data.cname = $("#<%= txtCustomer.ClientID %>").val();
                data.ccname = $("#<%= txtContact.ClientID %>").val();
                data.iframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
                //父页面传过来的参数 也要带上 
                data.initId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("initId") %>';
                data.callBack = '<%= EyouSoft.Common.Utils.GetQueryStringValue("callBack") %>';
                data.pIframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("pIframeId") %>';
                data.isMore = '<%= EyouSoft.Common.Utils.GetQueryStringValue("isMore") %>';
                
                window.location.href = "/CommonPage/CustomerUnitSelect.aspx?" + $.param(data);
            },
            ProvinceAndCityInit: function() {
                pcToobar.init({
                    pID: "#<%=ddlProvince.ClientID %>",
                    cID: "#<%=ddlCity.ClientID %>",
                    pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("pid"),0) %>',
                    cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("cid"),0) %>',
                    comID: '<%= this.SiteUserInfo.CompanyId %>',
                    isCy: "0"
                });
            }
        };

        $(document).ready(function() {
            CustomerUnitSelect.ProvinceAndCityInit();
            $("#a_search").bind("click", function() {
                CustomerUnitSelect.Search();
                return false;
            });
            $("#btnSave").bind("click", function() {
                CustomerUnitSelect.SetValue();
                CustomerUnitSelect.SelectValue();
                return false;
            });
        });
    </script>

    </form>
</asp:Content>
--%>
