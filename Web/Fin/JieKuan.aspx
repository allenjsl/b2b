<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieKuan.aspx.cs" Inherits="Web.Fin.JieKuan"
    MasterPageFile="~/MasterPage/Front.Master" Title="借款登记表-财务管理" %>

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
                    <b>当前您所在位置：</b> >> 财务管理 >> 借款登记表
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
                    借款日期：
                    <input name="txtSDate" type="text" class="searchinput formsize80 inputtext" id="txtSDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEDate" type="text" class="searchinput formsize80 inputtext" id="txtEDate"
                        onfocus="WdatePicker()" />
                    借款人：
                    <input name="txtJieKuanRenName" type="text" class="searchinput formsize80 inputtext"
                        id="txtJieKuanRenName" maxlength="50" />
                    借款金额：<select name="txtJieKuanJinEOperator" id="txtJieKuanJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtJieKuanJinE" id="txtJieKuanJinE" class="searchinput w50 inputtext" />
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
                    <a href="javascript:void(0)" id="i_insert">借款登记</a>
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
                    借款日期
                </th>
                <th width="8%" align="center">
                    借款金额
                </th>
                <th align="center">
                    借款原因
                </th>
                <th align="center">
                    借款人
                </th>
                <th align="center">
                    借款状态
                </th>
                <th align="center">
                    归还时间
                </th>
                <th align="center">
                    归还金额
                </th>
                <th width="100" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_jiekuanid="<%#Eval("JieKuanId") %>" i_status="<%#(int)Eval("Status") %>" style="height:30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("JieKuanRiQi"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td align="center">
                            <%#Eval("JieKuanYuanYin")%>
                        </td>
                        <td align="center">
                            <%#Eval("JieKuanRenName")%>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("Status")) %>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("GuiHuanTime"))%>
                        </td>
                        <td align="center">
                            <%#EyouSoft.Model.EnumType.FinStructure.JieKuanStatus .已归还== (EyouSoft.Model.EnumType.FinStructure.JieKuanStatus)Eval("Status")?ToMoneyString(Eval("JinE")):""%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="9" style="height: 30px; text-align: center;">
                        暂无任何借款信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="2" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJieKuanJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center" colspan="4">
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrGuiHuanJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
            </asp:PlaceHolder>
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
                return false;
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "借款登记", iframeUrl: "jiekuanedit.aspx", width: "650px", height: "238px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { jiekuanid: _$tr.attr("i_jiekuanid") };
                var _title = "借款修改";
                if ($(obj).attr("i_chakan") == "1") _title = "查看借款信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "jiekuanedit.aspx", width: "650px", height: "238px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { jiekuanid: _$tr.attr("i_jiekuanid") };
                _status = _$tr.attr("i_status");

                var _title = "借款审批";
                if (_status != "<%=(int)EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.未审批 %>") _title = "查看审批结果";

                Boxy.iframeDialog({ title: _title, iframeUrl: "jiekuanshenpiboxy.aspx", width: "650px", height: "200px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //支付
            zhiFu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { jiekuanid: _$tr.attr("i_jiekuanid") };
                Boxy.iframeDialog({ title: "借款支付", iframeUrl: "jiekuanshenpiboxy.aspx", width: "650px", height: "380px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //归还
            guiHuan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { jiekuanid: _$tr.attr("i_jiekuanid") };
                _status = _$tr.attr("i_status");

                var _title = "借款归还";
                if (_status == "<%=(int)EyouSoft.Model.EnumType.FinStructure.JieKuanStatus.已归还 %>") _title = "查看借款归还信息";

                Boxy.iframeDialog({ title: _title, iframeUrl: "jiekuanshenpiboxy.aspx", width: "650px", height: "570px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("借款登记删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { jiekuanid: _$tr.attr("i_jiekuanid") };

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
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();

            $("#i_insert").bind("click", function() { return iPage.insert(this); });
            $(".i_update").bind("click", function() { return iPage.update(this); });
            $(".i_delete").bind("click", function() { return iPage.del(this); return false; });
            $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); });
            $(".i_zhifu").bind("click", function() { return iPage.zhiFu(this); });
            $(".i_guihuan").bind("click", function() { return iPage.guiHuan(this); });
        });
    </script>

</asp:Content>
