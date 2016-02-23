<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiJieSheZhuTi.aspx.cs" Inherits="Web.ResourceManage.DiJieSheZhuTi" MasterPageFile="~/MasterPage/Front.Master" Title="地接社主体管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">    
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">资源管理</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            &nbsp;所在位置&gt;&gt; <a href="javascript:void(0)">资源管理</a>&gt;&gt; 地接社主体管理
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <div style="height: 30px; margin-bottom: 5px;" class="lineCategorybox">
            <table cellspacing="0" cellpadding="0" border="0" class="xtnav">
                <tr>
                    <td width="100" align="center" class="xtnav-on">
                        <a href="javascript:void(0)">主体管理</a>
                    </td>
                    <td width="100" align="center">
                        <a href="dijieshezhutiyonghu.aspx">账号管理</a>
                    </td>
                </tr>
            </table>
        </div>
        
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <form id="form1" method="get" action="">
                    <div class="searchbox">                        
                        省份：<select name="txtShengFen" id="txtShengFen" class="inputselect"></select>
                        城市：<select name="txtChengShi" id="txtChengShi" class="inputselect"></select>    
                        主体名称：<input type="text" id="txtGysName" class="searchinput inputtext formsize100" name="txtGysName" />
                        联系人：<input type="text" id="txtLxrName" class="searchinput inputtext formsize100" name="txtLxrName" />
                        <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        
        <div class="btnbox">
            <table width="45%" border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <asp:PlaceHolder runat="server" ID="phTianJia">
                    <td width="90">
                        <a href="javascript:void(0);" id="a_tianjia">新增</a>
                    </td>
                    </asp:PlaceHolder>
                </tr>
            </table>
        </div>
        
        <div class="tablelist">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
                <tr>
                    <th width="50" align="center" bgcolor="#BDDCF4" style="height: 30px;">
                        序号
                    </th>
                    <th align="center" bgcolor="#bddcf4" width="10%">
                        所在地
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        地接社主体名称
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        联系人姓名
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        联系人电话
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        联系人手机
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        联系传真
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <tr data-gyszhutiid="<%#Eval("GysId") %>" class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                            <td width="50" align="center" style="height: 30px;">
                                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <%#Eval("ShengFenName") %>-<%#Eval("ChengShiName") %>
                            </td>
                            <td align="center">
                                <%#Eval("GysName") %>
                            </td>
                            <td align="center">
                                <%#Eval("LxrName") %>
                            </td>
                            <td align="center">
                                <%#Eval("LxrDianHua") %>
                            </td>
                            <td align="center">
                                <%#Eval("LxrShouJi") %>
                            </td>
                            <td align="center">
                                <%#Eval("Fax") %>
                            </td>
                            <td align="center">
                                <%#GetCaoZuo()%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr class="even">
                        <td style="height: 30px; text-align: center;" colspan="10">
                            暂无地接社主体信息
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td height="30" colspan="11" align="right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            tianJia: function() {
                var _data = {}
                Boxy.iframeDialog({ title: "地接社主体-添加", iframeUrl: "dijieshezhutiedit.aspx", width: "800px", height: "500px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-gyszhutiid") };
                Boxy.iframeDialog({ title: "地接社主体-修改", iframeUrl: "dijieshezhutiedit.aspx", width: "800px", height: "500px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                if (!confirm("地接社主体信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtGysZhuTiId: _$tr.attr("data-gyszhutiid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: "dijieshezhuti.aspx?dotype=shanchu", data: _data, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });
            },
            chaKan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-gyszhutiid") };
                Boxy.iframeDialog({ title: "地接社主体-查看", iframeUrl: "dijieshezhutiedit.aspx", width: "800px", height: "500px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            zhangHao: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { gysid: _$tr.attr("data-gyszhutiid") };
                Boxy.iframeDialog({ title: "地接社主体-账号管理", iframeUrl: "diJieshezhutiyonghuedit.aspx", width: "800px", height: "500px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        }

        $(document).ready(function() {
            utilsUri.initSearch();
            pcToobar.init({ pID: "#txtShengFen", cID: "#txtChengShi", pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtShengFen"),0) %>', cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtChengShi"),0) %>', comID: '<%= this.SiteUserInfo.CompanyId %>', isCy: "0" });

            $("#a_tianjia").click(function() { iPage.tianJia(); });
            $(".xiugai").click(function() { iPage.xiuGai(this); });
            $(".shanchu").click(function() { iPage.shanChu(this); });
            $(".chakan").click(function() { iPage.chaKan(this); });
            $(".zhanghao").click(function() { iPage.zhangHao(this); });
        });
    </script>

</asp:Content>
