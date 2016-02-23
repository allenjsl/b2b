<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaPiao.aspx.cs" Inherits="Web.Fin.FaPiao"
    MasterPageFile="~/MasterPage/Front.Master" Title="发票管理-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 发票管理
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
                    客户单位：
                    <input name="txtKeHuName" type="text" class="searchinput formsize80 inputtext" id="txtKeHuName" />
                    出团日期：<input type="text" id="txtQuDate1" name="txtQuDate1" class="searchinput formsize80 inputtext"
                        onfocus="WdatePicker()" />-<input type="text" id="txtQuDate2" name="txtQuDate2" class="searchinput formsize80 inputtext"
                            onfocus="WdatePicker()" />
                    
                    订单号：<input type="text" id="txtDingDanHao" name="txtDingDanHao" class="searchinput formsize80 inputtext" />   
                    发票号：<input type="text" id="txtFaPiaoHao" name="txtFaPiaoHao" class="searchinput formsize80 inputtext" />   
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
                    <a href="javascript:void(0)" id="i_insert">登记</a>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    </div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" height="30" align="center">
                    序号
                </th>
                <th align="center">
                    客户单位
                </th>
                <th align="center">
                    出团日期
                </th>
                <th align="center">
                    开票总金额
                </th>
                <th align="center">
                    登记时间
                </th>
                <th align="center">
                    状态
                </th>
                <th align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("FaPiaoId") %>">
                        <td align="center" style="height: 30px;">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("KeHuName")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_mingxi"><%#ToDateTimeString(Eval("FirstChuTuanRiQi"))%></a>
                            <div style="display: none"><%#GetChuTuanRiQiHtml(Eval("Mxs"))%></div>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td align="center">
                            <%#Eval("IssueTime","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_fasong"><%#Eval("Status")%></a>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="7" style="height: 30px; text-align: center;">
                        暂无任何发票登记信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server"></asp:PlaceHolder>
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
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "登记发票信息", iframeUrl: "fapiaoedit.aspx", width: "920px", height: "480px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { fapiaoid: _$tr.attr("i_xmid") };
                var _title = "修改发票信息";
                if ($(obj).attr("i_chakan") == "1") _title = "查看发票信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "fapiaoedit.aspx", width: "920px", height: "480px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("发票信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { fapiaoid: _$tr.attr("i_xmid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "delete" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                    }
                });
            },
            faSong: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { fapiaoid: _$tr.attr("i_xmid") };
                var _title = "设置发票发送状态";
                Boxy.iframeDialog({ title: _title, iframeUrl: "fapiaofasong.aspx", width: "980px", height: "480px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            displayMx: function() {
                $('.i_mingxi').bt({
                    contentSelector: function() { return $(this).next("div").html(); },
                    positions: ['bottom'],
                    fill: '#effaff',
                    strokeStyle: '#2a9cd4',
                    noShadowOpts: { strokeStyle: "#2a9cd4" },
                    spikeLength: 5,
                    spikeGirth: 15,
                    width: 920,
                    overlap: 0,
                    centerPointY: 4,
                    cornerRadius: 4,
                    shadow: true,
                    shadowColor: 'rgba(0,0,0,.5)',
                    cssStyles: { color: '#1351a0', 'line-height': '200%' }
                });
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });
            $(".i_fasong").bind("click", function() { return iPage.faSong(this); });

            iPage.displayMx();
        });
    </script>

</asp:Content>
