<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuiKuanDanXX.aspx.cs" Inherits="Web.Fin.CuiKuanDanXX" MasterPageFile="~/MasterPage/Print.Master" Title="催款单-财务管理" ValidateRequest="false"%>


<asp:Content ID="Content2" ContentPlaceHolderID="PrintC1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="40" align="center">
                <b class="font24"> <asp:Literal runat="server" ID="ltrZxsName1"></asp:Literal>应收款账单</b>
            </td>
        </tr>
    </table>
    
    <table width="696" border="0" align="center" cellpadding="0" cellspacing="0" class="toptable">
        <tr>
            <td align="left">
                (TO)：<asp:Literal runat="server" ID="ltrKeHuName1"></asp:Literal>
            </td>
            <td align="left">
                自(From)：<asp:Literal runat="server" ID="ltrZxsName2"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                (Fax)：<asp:Literal runat="server" ID="ltrKeHuFax"></asp:Literal>
            </td>
            <td align="left">
                传真(Fax)：<asp:Literal runat="server" ID="ltrZxsFax"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td width="45%" align="left">
                收件人：<asp:Literal runat="server" ID="ltrKeHuLxrName1"></asp:Literal>
            </td>
            <td align="left">
                发件人：<asp:Literal runat="server" ID="ltrZxsCaoZuoRenName"></asp:Literal>
            </td>
        </tr>
        <tr>
        <td colspan="2" style="line-height:20px;">
            <b>致：<asp:Literal runat="server" ID="ltrKeHuName2"></asp:literal>旅行社：</b><br />
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrKeHuLxrName2"></asp:Literal>您好！多谢支持！贵社的开发票户名和地址，一起传真确认回传给我社，以便贵社汇款后，我社及时将相关发票快递给您。
            <b>温馨提示：发票在团回来后贰个月内有效，过期作废，谢谢！以下是我社<asp:Literal runat="server" ID="ltrQuDate1"></asp:Literal>至<asp:Literal runat="server" ID="ltrQuDate2"></asp:Literal>的应收款账单，感谢贵社的支持，请回传确认。</b>
        </td>
        </tr>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <th align="center" width="35">序号</th>
            <th width="80" align="center">出团日期</th>
            <th width="60" align="center">订单号</th>
            <th width="50" align="center">预订人</th>
            <th width="80" align="center">线路名称</th>
            <th width="80" align="center">游客信息</th>
            <th align="center">应收款明细</th>
            <th width="65"  style="text-align:right;">应收金额&nbsp;</th>
            <th width="65" style="text-align:right;">未收金额&nbsp;</th>
        </tr>        
        <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
        <tr>
            <td align="center" widtd="40"><%# Container.ItemIndex + 1%></td>
            <td widtd="80" align="center"><%#Eval("QuDate","{0:yyyy-MM-dd}") %></td>
            <td widtd="60" align="center"><%#Eval("DingDanHao") %></td>
            <td widtd="60" align="center"><%#Eval("KeHuLxrName") %></td>
            <td widtd="80" align="center"><%#GetRouteName(Eval("RouteName") ,Eval("YeWuLeiXing"))%></td>
            <td widtd="80" align="center"><%#Eval("YouKeName") %><br/>(<%#Eval("ChengRenShu") %>+<%#Eval("ErTongShu") %>+<%#Eval("YingErShu") %>+<%#Eval("QuanPeiShu") %>)</td>
            <td align="left" style="word-break: break-all; word-wrap: break-word;"><%#Eval("JiaGeMingXi2") %></td>
            <td widtd="60" style="text-align:right;"><%#Eval("JinE","{0:F2}") %>&nbsp;</td>
            <td widtd="60" style="text-align:right;"><%#Eval("WeiShouJinE","{0:F2}") %>&nbsp;</td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <asp:PlaceHolder runat="server" ID="phHeJi" Visible="false">
        <tr>
            <td colspan="7" style="text-align:right;">合计：</td>
            <td style="text-align:right;"><asp:Literal runat="server" ID="ltrJinEHeJi"></asp:Literal>&nbsp;</td>
            <td style="text-align:right;"><asp:Literal runat="server" ID="ltrWeiShouJinEHeJi"></asp:Literal>&nbsp;</td>
        </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
        <tr>
            <td colspan="9" style="text-align:center;">暂无收款信息</td>
        </tr>
        </asp:PlaceHolder>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list">
        <tr>
            <td style="width:120px; height:30px;"><b>贵社发票的户名</b></td>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td style="height:30px;"><b>申请开具发票种类</b></td>
            <td style="width:250px;">旅游业专用发票 〇</td>
            <td style="width:120px;"><b>开票金额</b></td>
            <td></td>
        </tr>
        <tr>
            <td style="height:30px;"><b>邮寄发票地址</b></td>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td style="height:30px;"><b>收件人</b></td>
            <td></td>
            <td><b>联系手机/电话</b></td>
            <td></td>
        </tr>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list" >
        <tr>
            <td style="border:0px">
                请您核对,并确认回传。如核对无误，敬请您将上列款项汇入以下我社指定汇款账户，如有疑问，请致电查询,谢谢支持!
            </td>
        </tr>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="0"
        class="list i_yinhangzhanghao">
        <tr>
            <th width="47" style="text-align:center" class="unprint">&nbsp;</th>
            <th width="200" align="center">
                开户行
            </th>
            <th width="92" align="center">
                户名
            </th>
            <th width="200" align="center">
                卡号
            </th>
        </tr>
        <asp:Repeater runat="server" ID="rptYinHangZhangHu">
            <ItemTemplate>
                <tr id="tr_yinhangzhanghao_<%#Container.ItemIndex %>">
                    <td style="text-align: center;" class="unprint"><input type="checkbox" id="chk_yinhangzhanghao_<%#Container.ItemIndex %>" /></td>
                    <td align="center">
                        <%# Eval("BankName")%>
                    </td>
                    <td align="center">
                        <%# Eval("AccountName")%>
                    </td>
                    <td align="center">
                        <%# Eval("BankNo")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" height="150" align="center">
                组团社确认盖章<br/><br />
                <div style="text-align:left; margin-left:200px;">经手人：</div>
                <div style="text-align:left;margin-left:200px;">日期：<%=DateTime.Now.ToString("yyyy年") %>&nbsp;&nbsp;月&nbsp;&nbsp;日</div>
            </td>
            <td width="50%" align="center">
                <asp:Literal runat="server" ID="ltrZxsName3"></asp:Literal> 签章<br/><br />
                <div style="text-align:left;margin-left:200px;">日期：<%=DateTime.Now.ToString("yyyy年MM月dd日") %></div>
            </td>
        </tr>
    </table>


    <script type="text/javascript">
        var iPage = {
            bindChkClick: function(chkExpr, shExpr) {
                $(chkExpr).bind("click", function() {
                    var _$chkTr = $(chkExpr).closest("tr");
                    if ($(this).attr("checked")) {
                        _$chkTr.removeClass("unprint")
                        //$(shExpr).show();
                    }
                    else {
                        _$chkTr.addClass("unprint");
                        //$(shExpr).hide();
                    }
                });
            }
        }

        $(document).ready(function() {
            //银行账号打印处理
            $(".i_yinhangzhanghao").find("input[type='checkbox']").attr("checked", false);
            var _yinHangZhangHaoCount = $(".i_yinhangzhanghao").find("tr").length;
            for (var i = 0; i < _yinHangZhangHaoCount; i++) {
                $("#tr_yinhangzhanghao_" + i).addClass("unprint");
                iPage.bindChkClick("#chk_yinhangzhanghao_" + i, "#tr_yinhangzhanghao_" + i);
            }
        });
    </script>
</asp:Content>
