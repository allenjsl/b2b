<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiuDianFangXing.aspx.cs"
    Inherits="Web.PingTai.JiuDianFangXing" MasterPageFile="~/MasterPage/Boxy.Master"
    ValidateRequest="false" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <asp:PlaceHolder runat="server" ID="phTianJia">
            <div class="btnbox" style="width: 100%">
                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                    <tr>
                        <td align="left">
                            <a id="i_tianjia" href="javascript:void(0)">新增</a>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:PlaceHolder>
        <table cellspacing="1" cellpadding="0" border="0" style="width: 100%; margin: 0px auto;
            margin-top: 5px;">
            <tr class="odd">
                <th width="36" height="30">
                    序号
                </th>
                <th width="100">
                    房型名称
                </th>
                <th>
                    房型介绍
                </th>
                <th width="70">
                    数量
                </th>
                <th width="70">
                    面积
                </th>
                <th width="70">
                    所在楼层
                </th>
                <th width="70" style="text-align: right;">
                    挂牌价格&nbsp;
                </th>
                <th width="80">
                    入住日期
                </th>
                <th width="70" style="text-align:right;">
                    优惠价&nbsp;
                </th>
                <th width="70">
                    排序值
                </th>
                <th width="70">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-fangxingid="<%#Eval("FangXingId") %>" style="text-align:center;">
                        <td height="30">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td>
                            <%#Eval("MingCheng") %>
                        </td>
                        <td>
                            <%#Eval("JieShao") %>
                        </td>
                        <td>
                            <%#Eval("ShuLiang") %>
                        </td>
                        <td>
                            <%#Eval("MianJi") %>
                        </td>
                        <td>
                            <%#Eval("LouCeng") %>
                        </td>
                        <td style="text-align: right;">
                            <%#Eval("GuaPaiJiaGe","{0:F2}") %>&nbsp;
                        </td>
                        <td>
                            <%#Eval("RuZhuRiQi1","{0:yyyy-MM-dd}") %><br/>至<br/><%#Eval("RuZhuRiQi2","{0:yyyy-MM-dd}") %>
                        </td>
                        <td style="text-align:right;">
                            <%#Eval("YouHuiJiaGe","{0:F2}") %>&nbsp;
                        </td>
                        <td>
                            <%#Eval("PaiXuId") %>
                        </td>                        
                        <td>
                            <%#GetOperatorHtml()%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr class="even">
                    <td colspan="10" style="height: 30px;">
                        暂无房型信息
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            tianJia: function(obj) {
                var _data = { jiudianid: "<%=JiuDianId %>" };
                top.Boxy.iframeDialog({ title: "房型新增", iframeUrl: "jiudianfangxingedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-fangxingid"), jiudianid: "<%=JiuDianId %>" };
                var _title = "房型修改";
                if ($(obj).attr("data-chakan") == "1") _title = "查看房型";
                top.Boxy.iframeDialog({ title: _title, iframeUrl: "jiudianfangxingedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtFangXingId: _$tr.attr("data-fangxingid") };

                if (!confirm("房型信息删除后不可恢复，你确定要删除吗？")) return;
                $.newAjax({
                    type: "post", cache: false, url: "jiudianfangxing.aspx?dotype=shanchu&jiudianid=<%=JiuDianId %>", dataType: "json",
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
            $("#i_tianjia").click(function() { iPage.tianJia(this); });
            $(".i_xiugai").click(function() { iPage.xiuGai(this); });
            $(".i_shanchu").click(function() { iPage.shanChu(this); });
        });
    </script>
</asp:Content>
