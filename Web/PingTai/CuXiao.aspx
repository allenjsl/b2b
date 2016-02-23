<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuXiao.aspx.cs" Inherits="Web.PingTai.CuXiao" MasterPageFile="~/MasterPage/Front.Master" Title="促销信息管理-同行端口"%>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">同行端口</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 同行端口 >> 促销信息管理
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
                    促销标题：
                    <input name="txtBiaoTi" type="text" class="inputtext"
                        id="txtBiaoTi" maxlength="50" style="width:150px;"/>                    
                    发布日期：
                    <input name="txtShiJian1" type="text" class="formsize80 inputtext" id="txtShiJian1"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtShiJian2" type="text" class="formsize80 inputtext" id="txtShiJian2"
                        onfocus="WdatePicker()" />
                    促销状态： <select id="txtStatus" name="txtStatus" class="inputselect">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.CuXiaoStatus)), "") %>
                    </select>
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
    <asp:PlaceHolder runat="server" ID="phInsert">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_tianjia">新增</a>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    </div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th align="center">
                    标题
                </th>
                <th align="center" width="20%">
                    封面
                </th>
                <th width="15%" align="center">
                    起止日期
                </th>
                <th width="10%" align="center">
                    排序值
                </th>
                <th width="10%" align="center">
                    发布时间
                </th>
                <th width="10%" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-cuxiaoid="<%#Eval("cuxiaoid") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#Eval("BiaoTi")%>
                        </td>
                        <td align="center">
                            <%#GetFengMian(Eval("FengMian"))%>
                        </td>
                        <td align="center">
                            <%#Eval("ShiJian1","{0:yyyy-MM-dd}")%>至<%#Eval("ShiJian2","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%#Eval("PaiXuId")%>
                        </td>
                        <td align="center">
                            <%#Eval("IssueTime","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="8" style="height: 30px; text-align: center;">
                        暂无任何促销信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                
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
            },
            tianJia: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "促销信息新增", iframeUrl: "cuxiaoedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtCuXiaoId: _$tr.attr("data-cuxiaoid") };

                if (!confirm("促销信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "cuxiao.aspx?dotype=shanchu", dataType: "json",
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
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-cuxiaoid") };
                var _title = "促销信息修改";
                if ($(obj).attr("data-chakan") == "1") _title = "查看促销信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "cuxiaoedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            sheZhiStatus: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtCuXiaoId: _$tr.attr("data-cuxiaoid"), txtFS: $(obj).attr("data-fs") };
                var _confirmMessage = "你确定要启用吗？";
                if (_data.txtFS == "tingyong") _confirmMessage = "你确定要停用吗？";
                if (!confirm(_confirmMessage)) return false;

                $.newAjax({
                    type: "post", cache: false, url: "cuxiao.aspx?dotype=shezhistatus", dataType: "json",
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
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("#i_tianjia").click(function() { iPage.tianJia(this); });
            $(".i_xiugai").click(function() { iPage.xiuGai(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });
            $(".i_shezhistatus").click(function() { iPage.sheZhiStatus(this); });
        });
    </script>
</asp:Content>
