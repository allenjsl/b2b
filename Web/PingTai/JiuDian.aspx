<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiuDian.aspx.cs" Inherits="Web.PingTai.JiuDian" MasterPageFile="~/MasterPage/Front.Master" Title="平台酒店管理-同行端口"%>

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
                    <b>当前您所在位置：</b> >> 同行端口 >> 平台酒店管理
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
                    所在地： <select id="txtShengFen" class="inputselect" name="txtShengFen"></select>
                    <select id="txtChengShi" class="inputselect" name="txtChengShi"></select>        
                    酒店星级：<select id="txtXingJi" class="inputselect" name="txtXingJi">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi)), "") %>
                    </select>                   
                    酒店名称：
                    <input name="txtJiuDianMingCheng" type="text" class="inputtext"
                        id="txtJiuDianMingCheng" maxlength="50" style="width:150px;"/>          
                    房型名称：
                    <input name="txtFangXingMingCheng" type="text" class="inputtext"
                        id="txtFangXingMingCheng" maxlength="50" style="width:150px;"/>             
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
                    酒店名称
                </th>
                <th align="center" width="10%">
                    所在地
                </th>
                <th width="10%" align="center">
                    开业时间
                </th>
                <th width="10%" align="center">
                    楼层数量
                </th>
                <th width="10%" align="center">
                    酒店星级
                </th>
                <th width="10%" align="center">
                    酒店电话
                </th>
                <th width="10%" align="center">
                    酒店房型
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
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-jiudianid="<%#Eval("JiuDianId") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#Eval("MingCheng")%>
                        </td>
                        <td align="center">
                            <%#Eval("ShengFenName") %>-<%#Eval("ChengShiName") %>
                        </td>
                        <td align="center">
                            <%#Eval("KaiYeShiJian")%>
                        </td>
                        <td align="center">
                            <%#Eval("LouCengShuLiang")%>
                        </td>
                        <td align="center">
                            <%#Eval("XingJi")%>
                        </td>
                        <td align="center">
                            <%#Eval("DianHua")%>
                        </td>
                        <td align="center">
                            <%#GetFangXing(Eval("FangXings")) %>
                        </td>
                        <td align="center">
                            <%#Eval("PaiXuId")%>
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
                        暂无任何酒店信息。
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
                Boxy.iframeDialog({ title: "酒店新增", iframeUrl: "jiudianedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtJiuDianId: _$tr.attr("data-jiudianid") };

                if (!confirm("酒店信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "jiudian.aspx?dotype=shanchu", dataType: "json",
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
                var _data = { editid: _$tr.attr("data-jiudianid") };
                var _title = "酒店修改";
                if ($(obj).attr("data-chakan") == "1") _title = "查看酒店信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "jiudianedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            fangXing: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { jiudianid: _$tr.attr("data-jiudianid") };
                var _title = "酒店房型管理";

                Boxy.iframeDialog({ title: _title, iframeUrl: "jiudianfangxing.aspx", width: "960px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;                
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("#i_tianjia").click(function() { iPage.tianJia(this); });
            $(".i_xiugai").click(function() { iPage.xiuGai(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });

            pcToobar.init({ pID: "#txtShengFen", cID: "#txtChengShi", comID: '<%=this.SiteUserInfo.CompanyId %>', pSelect: '<%=Request.QueryString["txtShengFen"] %>', cSelect: '<%=Request.QueryString["txtChengShi"] %>' });
            $('.i_fangxing').bt({ contentSelector: function() { return $(this).next("span").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 760, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            $(".i_fangxing").click(function() { iPage.fangXing(this); });
        });
    </script>
</asp:Content>
