<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YinHangZhangHu.aspx.cs"
    Inherits="Web.Fin.YinHangZhangHu" MasterPageFile="~/MasterPage/Front.Master"
    Title="银行账号表-财务管理" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 银行账号表
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
                    <input type="hidden" name="txtIsChaXun" value="1" />
                    账户性质：<select id="txtXingZhi" name="txtXingZhi" class="inputselect">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.AccountType)), "")%>
                    </select>
                    账户类型：<select id="txtLeiXing" name="txtLeiXing" class="inputselect">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.YinHangZhangHuLeiXing)), "")%>
                    </select>
                    账户状态：<select id="txtStatus" name="txtStatus" class="inputselect">
                        <option value="">-请选择-</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.AccountState)), "")%>
                    </select>
                    
                    账户名称：<input name="txtMingCheng" type="text" class="inputtext"
                        id="txtMingCheng" maxlength="50" />
                    开户银行：<input name="txtKaiHuYinHang" type="text" class="inputtext"
                        id="txtKaiHuYinHang" maxlength="50" />
                    <input type="submit" value=" 查询 " />
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
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th width="8%" align="center">
                    性质
                </th>
                <th width="8%" align="center">
                    类型
                </th>
                <th width="8%" align="center">
                    账户名称
                </th>
                <th width="8%" align="center">
                    开户银行
                </th>
                <th align="center">
                    银行账号
                </th>
                <th align="center">
                    状态
                </th>
                <th align="center">
                    原始金额
                </th>
                <th width="80" align="center">
                    附件下载
                </th>
                <th width="80" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_zhanghuid="<%#Eval("Id") %>"
                        i_status="<%#(int)Eval("AccountState") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1%>
                        </td>
                        <td align="center">
                            <%#Eval("AccountType")%>
                        </td>
                        <td align="center">
                            <%#Eval("LeiXing")%>
                        </td>
                        <td align="center">
                            <%#Eval("AccountName")%>
                        </td>
                        <td align="center">
                            <%#Eval("BankName")%>
                        </td>
                        <td align="center">
                            <%#Eval("BankNo")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_shenpi"><%#Eval("AccountState")%></a>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("AccountMoney"))%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_download" i_filepath="<%#Eval("FilePath") %>"><img src="/images/fujian_bg.gif" alt="" width="15" height="14" /></a>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("AccountState"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何银行账号信息。
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
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "银行账号登记", iframeUrl: "yinhangzhanghuedit.aspx", width: "670px", height: "300px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { zhanghuid: _$tr.attr("i_zhanghuid") };
                var _title = "银行账号修改";
                if ($(obj).attr("i_chakan") == "1") _title = "银行账号查看";
                Boxy.iframeDialog({ title: _title, iframeUrl: "yinhangzhanghuedit.aspx", width: "670px", height: "300px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { zhanghuid: _$tr.attr("i_zhanghuid"), tostatus: "-1" };
                _status = _$tr.attr("i_status");
                var _confirmmsg = "";

                switch (_status) {
                    case "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.AccountState.未审批 %>":
                        _confirmmsg = "你确定要审批该银行账号信息吗？";
                        _data.tostatus = "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 %>";
                        break;
                    case "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 %>":
                        _confirmmsg = "你确定要将该银行账号设置成不可用吗？";
                        _data.tostatus = "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.AccountState.不可用 %>";
                        break;
                    case "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.AccountState.不可用 %>":
                        _confirmmsg = "你确定要将该银行账号设置成可用吗？";
                        _data.tostatus = "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.AccountState.可用 %>";
                        break;
                    default: return false; break;
                }

                if (!confirm(_confirmmsg)) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "setstatus" }),
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
                            $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.shenPi(obj); }).css({ "color": "" });
                    }
                });

                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("银行账号信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { zhanghuid: _$tr.attr("i_zhanghuid") };

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
            download: function(obj) {
                var _$obj = $(obj);
                _filepath = _$obj.attr("i_filepath");
                if (_filepath.length == 0) { alert("暂无附件以供下载"); return false; }

                window.location.href = _filepath;
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });
            $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); return false; });
            $(".i_download").bind("click", function() { return iPage.download(this); return false; });
            $("#txtLeiXing").val("<%=CX_LeiXing %>");
            $("#txtStatus").val("<%=CX_Status %>");
        });
    </script>

</asp:Content>
