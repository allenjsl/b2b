<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiChanFuZhaiBiao.aspx.cs"
    Inherits="Web.Fin.ZiChanFuZhaiBiao" Title="资产负债表-财务管理" MasterPageFile="~/MasterPage/Front.Master" %>


<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 资产负债表
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
                    年份：<select name="txtYear" id="txtYear" class="inputselect"><%=GetYearOptions(string.Empty)%></select>
                    月份：<select name="txtMonth" id="txtMonth" class="inputselect"><%=GetMonthOptions(string.Empty)%></select>
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
                        <a href="javascript:void(0)" id="i_insert">新增</a>
                    </td>
                    <td width="90" align="left">
                        <a id="i_a_toxls" href="javascript:void(0);">导 出</a>
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th align="center" rowspan="2" style="width: 40px">
                    序号
                </th>
                <th align="center" rowspan="2" style="width: 7%">
                    年月
                </th>
                <th align="center" colspan="4">
                    资 产 表
                </th>
                <th align="center" colspan="4">
                    负 债 表
                </th>
                <th rowspan="2" style="width:8%">
                    差额
                </th>
                <th rowspan="2">
                    操作
                </th>
            </tr>
            <tr class="odd" style="height: 30px;">
                
                <th style="width: 9%; text-align: center;">
                    货币资金
                </th>
                <th style="width: 9%; text-align: center;">
                    应收帐款
                </th>
                <th style="width: 9%; text-align: center;">
                    其他应收款
                </th>
                <th style="width: 9%; text-align: center;">
                    预付款
                </th>                
                <th style="width: 9%; text-align: center;">
                    应付帐款
                </th>                
                <th style="width: 9%; text-align: center;">
                    预收帐款
                </th>                
                <th style="width: 8%; text-align: center;">
                    实收股本
                </th>
                <th style="width: 8%; text-align: center;">
                    未分配利润
                </th>                
            </tr>
            
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_zichanfuzhaiid="<%#Eval("Id") %>"
                        style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#Eval("YMD","{0:yyyy-MM}")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("HuoBiZiJin"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YingShouZhangKuan"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("QiTaYingShouKuan"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YuFuZhangKuan"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YingFuZhangKuan"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YuShouZhangKuan"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("ShiShouGuBen"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("WeiFenPeiLiRun"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("ChaE"))%>
                        </td>
                        <td style="text-align: center">
                            <%#GetOperatorHtml()%>
                            <%#((bool)Eval("IsBianGeng"))?"<a href=\"javascript:void(0)\" class=\"i_a_biangeng\">变更历史</a>":"" %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="12" style="height: 30px; text-align: center;">
                        暂无任何资产负债表信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="2" align="right">
                        合计：
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrHuoBiZiJinHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrYingShouZhangKuanHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrQiTaYingShouKuanHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrYuFuZhangKuanHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrYingFuZhangKuanHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrYuShouZhangKuanHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrShiShouGuBenHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrWeiFenPeiLiRunHeJi"></asp:Literal>
                    </td>
                    <td style="text-align: center">
                        <asp:Literal runat="server" ID="ltrChaEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
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
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "新增资产负债表信息", iframeUrl: "zichanfuzhaibiaoedit.aspx", width: "870px", height: "450px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { zichanfuzhaiid: _$tr.attr("i_zichanfuzhaiid") };
                var _title = "修改资产负债表信息";
                if ($(obj).attr("i_chakan") == "1") _title = "查看资产负债表信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "zichanfuzhaibiaoedit.aspx", width: "870px", height: "450px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("资产负债表信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { txtZiChanFuZhaiId: _$tr.attr("i_zichanfuzhaiid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST", data: _data, cache: false, dataType: "json", async: false,
                    url: utilsUri.createUri(window.location.href, { doType: "delete" }),
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
            //打开变更历史窗口
            bianGeng: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { bianId: _$tr.attr("i_zichanfuzhaiid"), bianType: "<%=(int)EyouSoft.Model.EnumType.TourStructure.BianType.资产负债表 %>" };
                parent.Boxy.iframeDialog({ title: "查看变更信息", iframeUrl: "/commonpage/biangenglist.aspx", width: "370px", height: "200px", data: _data, afterHide: function() { } });
                return false;
            },
            toXls: function() {
                toXls1(utilsUri.createUri(null, {}));
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });

            $(".i_a_biangeng").bind("click", function() { return iPage.bianGeng(this); });
            $("#i_a_toxls").click(function() { iPage.toXls(); return false; });
        });
    </script>

</asp:Content>
