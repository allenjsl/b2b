<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QiTaZhiChu.aspx.cs" Inherits="Web.Fin.QiTaZhiChu" MasterPageFile="~/MasterPage/Front.Master" Title="其它支出-财务管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 其它支出
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
                    支出时间：
                    <input name="txtSDate" type="text" class="searchinput formsize80 inputtext" id="txtSDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEDate" type="text" class="searchinput formsize80 inputtext" id="txtEDate"
                        onfocus="WdatePicker()" />
                    支出项目：
                    <select name="txtXiangMuId" id="txtXiangMuId" class="inputselect">
                        <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.其它支出项目,string.Empty) %>
                    </select>
                    <input name="txtXiangMu" type="text" class="searchinput formsize80 inputtext" id="txtXiangMu"
                        maxlength="50" />
                    对方单位：
                    <input name="txtKeHuName" type="text" class="searchinput formsize100 inputtext" id="txtKeHuName"
                        maxlength="50" /><br />
                    支出金额：<select name="txtJinEOperator" id="txtJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtJinE" id="txtJinE" class="searchinput w50 inputtext" />
                    未付金额：<select name="txtWeiFuJinEOperator" id="txtWeiFuJinEOperator" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.FinStructure.QueryOperator),new string[]{"0"}), "", "0", "-请选择-")%></select>&nbsp;<input
                        type="text" name="txtWeiFuJinE" id="txtWeiFuJinE" class="searchinput w50 inputtext" />
                    结清状态：<select name="txtJieQingStatus" id="txtJieQingStatus" class="inputselect">
                        <option value="">请选择</option>
                        <option value="0">未结清</option>
                        <option value="1">已结清</option>
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
                    <a href="javascript:void(0)" id="i_insert">添加支出</a>
                </td>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="a_QiTaZhiChu_ToExcel">导 出</a>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" align="center" style="height: 30px;">
                    序号
                </th>
                <th width="8%" align="center">
                    支出时间
                </th>
                <th width="8%" align="center">
                    支出项目
                </th>
                <th width="8%" align="center">
                    支出金额
                </th>
                <th align="center">
                    支出备注
                </th>
                <th align="center">
                    对方单位
                </th>
                <th align="center">
                    已付金额
                </th>
                <th width="80" align="center">
                    未付金额
                </th>
                <th width="110" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_xmid="<%#Eval("ZhiChuId") %>"
                        i_kongweiid="<%#Eval("KongWeiId") %>">
                        <td align="center" style="height: 30px;">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("ShiJian"))%>
                        </td>
                        <td align="center">
                           <%#Eval("XiangMu")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("JinE"))%>
                        </td>
                        <td align="center">
                            <%#Eval("BeiZhu")%>
                        </td>
                        <td align="center">
                            <%#Eval("KeHuName")%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("YiZhiFuJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString((decimal)Eval("JinE") - (decimal)Eval("YiZhiFuJinE"))%>
                        </td>
                        <td align="center">
                            <%#OperatorHtml%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="9" style="height: 30px; text-align: center;">
                        暂无任何其它支出信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="3" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center" colspan="2">
                        &nbsp;
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrYiFuJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrWeiFuJinEHeJi"></asp:Literal>
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
                return false;
            },
            //新增
            insert: function(obj) {
                var _data = {}
                Boxy.iframeDialog({ title: "新增其它支出", iframeUrl: "qitazhichuedit.aspx", width: "670px", height: "300px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { zhichuid: _$tr.attr("i_xmid"), kongweiid: $.trim(_$tr.attr("i_kongweiid")) };
                var _title = "修改其它支出";
                if ($(obj).attr("i_chakan") == "1") _title = "查看其它支出信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "qitazhichuedit.aspx", width: "670px", height: "300px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { zhichuid: _$tr.attr("i_xmid") };

                var _confirmMessage = "其它支出删除后不可恢复，你确定要删除吗？";
                if ($.trim(_$tr.attr("i_kongweiid")).length > 0) _confirmMessage = "该其它支出在团队结算时添加，删除后相关团队结算的其它支出同步删除且不可恢复，你确定要删除吗？";

                if (!confirm(_confirmMessage)) return;

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
            //付款
            fuKuan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { xmid: _$tr.attr("i_xmid"), kxtype: "<%=(int)EyouSoft.Model.EnumType.FinStructure.KuanXiangType.其它支出付款 %>" };
                Boxy.iframeDialog({ title: "其它支出付款", iframeUrl: "fukuan.aspx", width: "900px", height: "400px", data: _data, afterHide: function() { iPage.reload(); } });
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
            $(".i_fukuan").bind("click", function() { return iPage.fuKuan(this); });
            $("#a_QiTaZhiChu_ToExcel").bind("click", function() { return iPage.toXls(); });
        });
    </script>

</asp:Content>
