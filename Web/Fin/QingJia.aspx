<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QingJia.aspx.cs" Inherits="Web.Fin.QingJia"
    MasterPageFile="~/MasterPage/Front.Master" Title="请假管理-财务管理" %>

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
                    <b>当前您所在位置：</b> >> 财务管理 >> 请假管理
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
                    请假时间：
                    <input name="txtSDate" type="text" class="searchinput formsize80 inputtext" id="txtSDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEDate" type="text" class="searchinput formsize80 inputtext" id="txtEDate"
                        onfocus="WdatePicker()" />
                    请假人：
                    <input name="txtQingJiaRenName" type="text" class="searchinput formsize80 inputtext"
                        id="txtQingJiaRenName" maxlength="50" />
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" height="30" align="center">
                    序号
                </th>
                <th align="center">
                    请假时间
                </th>
                <th align="center">
                    请假人
                </th>
                <th align="center" style="width:36%">
                    请假原因
                </th>
                <th align="center">
                    请假性质
                </th>
                <th align="center">
                    申请时间
                </th>
                <th align="center">
                    审批状态
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_qingjiaid="<%#Eval("LeaveId") %>"
                        i_status="<%#(int)Eval("State") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_chakan"><%#ToDateTimeString(Eval("StartDate"))%> ～ <%#ToDateTimeString(Eval("EndDate"))%></a>
                        </td>
                        <td align="center">
                            <%#Eval("UserContactName")%>
                        </td>
                        <td align="center">
                            <%#Eval("Reason")%>
                        </td>
                        <td align="center">
                            <%#Eval("Nature")%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("IssueTime"))%>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("State"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="9" style="height: 30px; text-align: center;">
                        暂无任何请假信息。
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
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { qingjiaid: _$tr.attr("i_qingjiaid") };
                _status = _$tr.attr("i_status");

                var _title = "请假审批";
                if (_status == "<%=(int)EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState.未通过 %>") _title = "查看审批结果";

                Boxy.iframeDialog({ title: _title, iframeUrl: "qingjiashenpiboxy.aspx", width: "650px", height: "180px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //作废
            zuoFei: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { qingjiaid: _$tr.attr("i_qingjiaid") };
                _status = _$tr.attr("i_status");

                var _title = "请假作废";
                if (_status == "<%=(int)EyouSoft.Model.EnumType.PersonalCenterStructure.LeaveState.作废 %>") _title = "查看请假审批信息";

                Boxy.iframeDialog({ title: _title, iframeUrl: "qingjiashenpiboxy.aspx", width: "650px", height: "280px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            chaKan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { id: _$tr.attr("i_qingjiaid"), "do": "_" };
                var _title = "查看请假申请信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "/usercenter/vacaadd.aspx", width: "600px", height: "350px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); });
            $(".i_zuofei").bind("click", function() { return iPage.zuoFei(this); });
            $(".i_chakan").bind("click", function() { return iPage.chaKan(this); });
        });
    </script>

</asp:Content>
