<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoXiao.aspx.cs" Inherits="Web.Fin.BaoXiao"
    MasterPageFile="~/MasterPage/Front.Master" Title="报销登记表-财务管理" %>

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
                    <b>当前您所在位置：</b> >> 财务管理 >> 报销登记表
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
                    报销日期：
                    <input name="txtSDate" type="text" class="searchinput formsize80 inputtext" id="txtSDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEDate" type="text" class="searchinput formsize80 inputtext" id="txtEDate"
                        onfocus="WdatePicker()" />
                    报销人：
                    <input name="txtBaoXiaoRenName" type="text" class="searchinput formsize80 inputtext"
                        id="txtBaoXiaoRenName" maxlength="50" />
                    报销类型：
                    <select name="txtBaoXiaoType" id="txtBaoXiaoType" class="inputselect">
                        <%=GetBaoXiaoTypeOptionHtml() %>
                    </select>
                    报销金额：<select name="txtBaoXiaoJinEOperator" id="txtBaoXiaoJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtBaoXiaoJinE" id="txtBaoXiaoJinE" class="searchinput w50 inputtext" />
                    报销状态：<select name="txtBaoXiaoStatus" id="txtBaoXiaoStatus" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus)), "", "", "-请选择-")%>
                    </select>
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
                    <a href="javascript:void(0)" id="i_insert">报销登记</a>
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
                    报销日期
                </th>
                <th width="8%" align="center">
                    报销人
                </th>
                <th width="8%" align="center">
                    报销金额
                </th>
                <th align="center">
                    报销状态
                </th>
                <th align="center">
                    支付时间
                </th>
                <th align="center">
                    支付账号
                </th>
                <th width="80" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_baoxiaoid="<%#Eval("BaoXiaoId") %>"
                        i_status="<%#(int)Eval("Status") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("BaoXiaoRiQi"))%>
                        </td>
                        <td align="center">
                            <%#Eval("BaoXiaoRenName")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_xiaofeimx"><%#ToMoneyString(Eval("JinE"))%></a>
                            <div style="display:none"><%#GetXiaoFeiMxHtml(Eval("XiaoFeis")) %></div>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("Status")) %>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("ZhiFuTime"))%>
                        </td>
                        <td align="center">
                            <%#Eval("ZhangHuName")%>
                        </td>
                        <td align="center">
                            <%#GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="8" style="height: 30px; text-align: center;">
                        暂无任何报销登记信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="3" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrBaoXiaoJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center" colspan="4">
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

    <script type="text/javascript" src="/js/bt.min.js"></script>
    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" ></script><![endif]-->
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "报销登记", iframeUrl: "baoxiaoedit.aspx", width: "770px", height: "300px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { baoxiaoid: _$tr.attr("i_baoxiaoid") };
                var _title = "报销修改";
                if ($(obj).attr("i_chakan") == "1") _title = "查看报销信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "baoxiaoedit.aspx", width: "770px", height: "300px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { baoxiaoid: _$tr.attr("i_baoxiaoid") };
                _status = _$tr.attr("i_status");

                var _title = "报销审批";
                if (_status != "<%=(int)EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.未审批 %>") _title = "查看审批结果";

                Boxy.iframeDialog({ title: _title, iframeUrl: "baoxiaoshenpiboxy.aspx", width: "650px", height: "200px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //支付
            zhiFu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { baoxiaoid: _$tr.attr("i_baoxiaoid") };
                _status = _$tr.attr("i_status");
                var _title = "报销支付";
                if (_status == "<%=(int)EyouSoft.Model.EnumType.FinStructure.BaoXiaoStatus.已支付 %>") _title = "查看支付信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "baoxiaoshenpiboxy.aspx", width: "650px", height: "380px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("报销登记删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { baoxiaoid: _$tr.attr("i_baoxiaoid") };

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
            displayMx: function() {
                $('.i_xiaofeimx').bt({
                    contentSelector: function() {return $(this).next("div").html();},
                    positions: ['bottom'],
                    fill: '#effaff',
                    strokeStyle: '#2a9cd4',
                    noShadowOpts: { strokeStyle: "#2a9cd4" },
                    spikeLength: 5,
                    spikeGirth: 15,
                    width: 620,
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
            $(".i_shenpi").bind("click", function() { return iPage.shenPi(this); });
            $(".i_zhifu").bind("click", function() { return iPage.zhiFu(this); });

            iPage.displayMx();
        });
    </script>

</asp:Content>
