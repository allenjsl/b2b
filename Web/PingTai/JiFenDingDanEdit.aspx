<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenDingDanEdit.aspx.cs" Inherits="Web.PingTai.JiFenDingDanEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
     <div style="width: 99%; margin: 0 auto; margin-top:5px;">
        <span class="formtableT">兑换商品信息</span>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="100" height="30" align="right">
                    商品名称：
                </th>
                <td style="background:#E3F1FC;width:350px;">
                    <asp:Literal runat="server" ID="ltrShangPinMingCheng"></asp:Literal>
                </td>
                <th width="100" align="right">
                    商品类型：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShangPinLeiXing"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    市场价格：
                </th>
                <td style="background:#E3F1FC">
                   <asp:Literal runat="server" ID="ltrShangPinJiaGe"></asp:Literal> 
                </td>
                <th align="right">
                    兑换所需积分：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShangPinJiFen"></asp:Literal> 
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    商品编码：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShangPinBianMa"></asp:Literal> 
                </td>
                <th align="right">
                    
                </th>
                <td style="background:#E3F1FC">
                    
                </td>
            </tr>           
        </table>
     </div>   
     
     <div style="width: 99%; margin: 0 auto; margin-top:5px">
        <span class="formtableT">兑换订单信息</span>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="100" height="30" align="right">
                    订单号：
                </th>
                <td style="background:#E3F1FC;width:350px;">
                    <asp:Literal runat="server" ID="ltrJiaoYiHao"></asp:Literal> 
                </td>
                <th width="100" align="right">
                    兑换数量：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShuLiang"></asp:Literal> 
                </td>
            </tr>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    兑换积分(单)：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrJiFen1"></asp:Literal> 
                </td>
                <th width="100" align="right">
                    兑换积分(总)：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrJiFen2"></asp:Literal> 
                </td>
            </tr>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    收件人姓名：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShouJianRenName"></asp:Literal> 
                </td>
                <th width="100" align="right">
                    收件人手机：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShouJianRenShouJi"></asp:Literal> 
                </td>
            </tr>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    收件人电话：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShouJianRenDianHua"></asp:Literal> 
                </td>
                <th width="100" align="right">
                    收件人地址：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShouJianRenDiZhi"></asp:Literal> 
                </td>
            </tr>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    收件人邮编：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShouJianRenYouBian"></asp:Literal> 
                </td>
                <th width="100" align="right">
                    收件人邮箱：
                </th>
                <td style="background:#E3F1FC">
                    <asp:Literal runat="server" ID="ltrShouJianRenYouXiang"></asp:Literal> 
                </td>
            </tr>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    下单备注：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <asp:Literal runat="server" ID="ltrXiaDanBeiZhu"></asp:Literal> 
                </td>
            </tr>
        </table>
     </div>  
     
     <asp:PlaceHolder runat="server" Visible="false" ID="ph_TiShiXinXi">
    <div style="width: 99%; margin: 0 auto; margin-top:5px;">        
        <asp:Literal runat="server" ID="ltrTiShiXinXi"></asp:Literal>
    </div>
    </asp:PlaceHolder>   
     
    <div style="width: 99%; margin: 0 auto;">  
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <asp:PlaceHolder runat="server" ID="ph_QueRen" Visible="false">
                                <td width="80" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0)" id="a_QueRen" data-fs="querendingdan">确认订单</a>
                                </td>
                            </asp:PlaceHolder>  
                            <asp:PlaceHolder runat="server" ID="ph_FaHuo" Visible="false">
                                <td width="80" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0)" id="a_FaHuo" data-fs="querenfahuo">确认发货</a>
                                </td>
                            </asp:PlaceHolder>   
                            <asp:PlaceHolder runat="server" ID="ph_QuXiao" Visible="false">
                                <td width="80" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0)" id="a_QuXiao" data-fs="quxiao">取消订单</a>
                                </td>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder runat="server" ID="ph_XiaoXi" Visible="false">
                                <td height="40" align="center">
                                    <asp:Literal runat="server" ID="ltrXiaoXi"></asp:Literal>
                                </td>
                            </asp:PlaceHolder>                          
                        </tr>
                    </table>
                </td>
            </tr>
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
            queRenDingDan: function(obj) {
                if (!confirm("你确定要确认该兑换订单吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });
                $.newAjax({ type: "POST", url: window.location.href + "&doType=querendingdan",
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.queRenDingDan(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.queRenDingDan(obj); }).css({ "color": "" });
                    }
                });
            },
            queRenFaHuo: function(obj) {
                var _data = { dingdanid: "<%=DingDanId %>" }
                var _title = "兑换订单-确认发货";
                var _fs = $(obj).attr("data-fs");
                if (_fs == "chakanfahuo") _title = "兑换订单-查看发货信息"

                top.Boxy.iframeDialog({ title: _title, iframeUrl: "jifendingdanfahuoedit.aspx", width: "870px", height: "340px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            quXiaoDingDan: function(obj) {
                if (!confirm("取消订单操作不可恢复，你确定要取消该兑换订单吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });
                $.newAjax({ type: "POST", url: window.location.href + "&doType=quxiaodingdan",
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.queRenDingDan(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.queRenDingDan(obj); }).css({ "color": "" });
                    }
                });
            },
            chaKanYongHuJiFenMingXi: function(obj) {
                var _$obj = $(obj);
                var _data = { txtKeHuId: _$obj.attr("data-kehuid"), txtYongHuId: _$obj.attr("data-yonghuid"), refererLeiXing: "jifendingdanchakanyonghujifenmingxi" };

                top.Boxy.iframeDialog({ title: "查看用户积分明细", iframeUrl: "/tongji/kehuyonghujifenmingxi.aspx", width: "920px", height: "600px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            $("#a_QueRen").click(function() { iPage.queRenDingDan(this); });
            $("#a_FaHuo,#i_a_fahuo").click(function() { iPage.queRenFaHuo(this); });
            $("#a_QuXiao").click(function() { iPage.quXiaoDingDan(this); });

            $("a[data-class='yonghujifenmingxi']").click(function() { iPage.chaKanYongHuJiFenMingXi(this); });
        });
    </script>
</asp:Content>
