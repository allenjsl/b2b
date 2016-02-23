<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingDian.aspx.cs" Inherits="Web.PingTai.JingDian"  MasterPageFile="~/MasterPage/Front.Master" Title="平台景点管理-同行端口"%>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/PingTaiJingDianDaoHang.ascx" TagName="PingTaiJingDianDaoHang"
    TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">同行端口</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 同行端口 >> 平台景点管理
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    
    <uc1:PingTaiJingDianDaoHang runat="server" ID="PingTaiJingDianDaoHang1" />
    
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
                    区域： <select id="txtJingDianQuYu" class="inputselect" name="txtJingDianQuYu">
                        <option value="">--请选择--</option>
                        <%=GetJingDianQuYu() %>
                    </select>
                    景点名称：
                    <input name="txtMingCheng" type="text" class="inputtext"
                        id="txtMingCheng" maxlength="50" style="width:150px;"/>             
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
                <th align="center" width="10%">
                    区域
                </th>
                <th align="center" >
                    景点名称
                </th>
                <th width="20%" align="center">
                    封面
                </th>
                <th width="10%" align="center">
                    排序值
                </th>
                <th width="10%" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-jingdianid="<%#Eval("JingDianId") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#Eval("QuYuMingCheng")%>
                        </td>
                        <td align="center">
                            <%#Eval("MingCheng") %>
                        </td>
                        <td align="center">
                            <%#GetFengMian(Eval("FengMian")) %>
                        </td>
                        <td align="center">
                            <%#Eval("PaiXuId") %>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml()%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何景点信息。
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
                Boxy.iframeDialog({ title: "景点新增", iframeUrl: "jingdianedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtJingDianId: _$tr.attr("data-jingdianid") };

                if (!confirm("景点信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "jingdian.aspx?dotype=shanchu", dataType: "json",
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
                var _data = { editid: _$tr.attr("data-jingdianid") };
                var _title = "景点修改";
                if ($(obj).attr("data-chakan") == "1") _title = "查看景点信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "jingdianedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("#i_tianjia").click(function() { iPage.tianJia(this); });
            $(".i_xiugai").click(function() { iPage.xiuGai(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });
            setPingTaiJingDianDaoHang(1)
        });
    </script>
</asp:Content>
