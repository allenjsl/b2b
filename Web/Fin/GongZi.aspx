<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongZi.aspx.cs" Inherits="Web.Fin.GongZi"
    MasterPageFile="~/MasterPage/Front.Master" Title="工资登记表-财务管理" %>

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
                    <b>当前您所在位置：</b> >> 财务管理 >> 工资登记表
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
                    年月：<select name="txtSYear" id="txtSYear" class="inputselect"><%=GetYearOptions(string.Empty)%></select><select
                        name="txtSMonth" id="txtSMonth" class="inputselect"><%=GetMonthOptions(string.Empty)%></select> -
                    <select name="txtEYear" id="txtEYear" class="inputselect">
                        <%=GetYearOptions(string.Empty)%>
                    </select><select name="txtEMonth" id="txtEMonth" class="inputselect"><%=GetMonthOptions(string.Empty)%></select>
                    员工姓名：
                    <input name="txt_userName" type="text" class="searchinput formsize80 inputtext" id="txt_userName"
                        maxlength="50" />
                    发放类型：<select name="txtFaFangLeiXing" id="txtFaFangLeiXing">
                        <option value="">请选择</option>
                        <option value="0">工资</option>
                        <option value="1">奖金</option>
                    </select>
                    工资状态:<select name="txtStatus" id="txtStatus">
                        <option value="">请选择</option>
                        <option value="0">未审批</option>
                        <option value="1">未支付</option>
                        <option value="2">已支付</option>
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
                        <a href="javascript:void(0)" id="i_insert">工资登记</a>
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="5%" align="center">
                    年月
                </th>
                <th width="5%" align="center">
                    姓名
                </th>
                <th width="6%" align="center">
                    基本<br />
                    工资
                </th>
                <th width="6%" align="center">
                    工龄<br />
                    补贴
                </th>
                <th width="6%" align="center">
                    生活费<br />
                    补贴
                </th>
                <th width="6%" align="center">
                    社保<br />
                    补贴
                </th>
                <th width="6%" align="center">
                    岗位<br />
                    补贴
                </th>
                <th width="6%" align="center">
                    季度<br />
                    奖金
                </th>
                <th width="6%" align="center">
                    社保<br />
                    扣除
                </th>
                <th width="6%" align="center">
                    工资<br/>合计
                </th>
                <th width="6%" align="center">
                    生活费<br />
                    扣除
                </th>
                <th width="6%" align="center">
                    上班<br />
                    扣费
                </th>
                <th width="6%" align="center">
                    其他<br />
                    扣费
                </th>
                <th width="6%" align="center">
                    实发<br />
                    工资
                </th>
                <th align="center">
                    工资<br/>备注
                </th>
                <th width="5%" align="center">
                    工资<br />
                    状态
                </th>                
                <th width="60" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" style="height: 30px;" i_baoxiaoid="<%# Eval("GongZiId")%>">
                        <td align="center" <%#(int)Eval("FaFangLeiXing")==1?"style='font-weight:bold;' ":"" %>
                            title="<%#Eval("FaFangLeiXing") %>">
                            <%# Eval("YMD","{0:yyyy-MM}")%>
                        </td>
                        <td align="center" <%#(int)Eval("FaFangLeiXing")==1?"style='font-weight:bold;' ":"" %>
                            title="<%#Eval("FaFangLeiXing") %>">
                            <%# Eval("YuanGongName")%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("JiBenGongZi"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString(Eval("GongLingBuTie"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("ShengHuoFeiBuTie"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("SheBaoBuTie"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("GangWeiBuTie"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("JiDuJiangJin"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("SheBaoKouChu"))%>
                        </td>
                        <td align="center">
                            <%# this.ToMoneyString( Eval("GongZiHeJi"))%>
                        </td>
                        <td align="center">
                            <%#  this.ToMoneyString(Eval("ShengHuoFeiKouChu"))%>
                        </td>
                        <td align="center">
                            <%#  this.ToMoneyString(Eval("ChiDaoKouChu"))%>
                        </td>
                        <td align="center">
                            <%#  this.ToMoneyString(Eval("QiTaKouChu"))%>
                        </td>
                        <td align="center">
                            <%#  this.ToMoneyString(Eval("ShiFaGongZi"))%>
                        </td>
                        <td>
                            <%#Eval("BeiZhu") %>
                        </td>
                        <td align="center">
                            <%#GetStatus(Eval("Status")) %>
                        </td>                        
                        <td align="center">
                            <%# GetOperatorHtml(Eval("Status"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="20" style="height: 30px; text-align: center;">
                        暂无工资登记信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="2" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJiBenGongZiHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrGongLingBuTieHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrShengHuoFeiBuTieHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrSheBaoBuTieHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrGangWeiBuTieHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrJiDuJiangJinHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrSheBaoKouChuHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrGongZiHeJiHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrShengHuoFeiKouChuHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrChiDaoKouChuHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrQiTaKouChuHeJi"></asp:Literal>
                    </td>                    
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrShiFaGongZiHeJi"></asp:Literal>
                    </td>
                    <td align="center" colspan="3">
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
                Boxy.iframeDialog({ title: "工资登记", iframeUrl: "GongZiEdit.aspx", width: "770px", height: "650px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //修改、查看
            update: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { gongzi: _$tr.attr("i_baoxiaoid") };
                var _title = "工资修改";
                if ($(obj).attr("i_chakan") == "1") _title = "查看工资信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "GongZiEdit.aspx", width: "770px", height: "650px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //审批
            shenPi: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { gongzi: _$tr.attr("i_baoxiaoid") };
                _status = _$tr.attr("i_status");

                var _title = "工资审批";
                if (_status != "<%=(int)EyouSoft.Model.EnumType.FinStructure.GongZiStatus.未审批 %>") _title = "查看审批结果";

                Boxy.iframeDialog({ title: _title, iframeUrl: "GongZiShenPi.aspx", width: "650px", height: "200px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //支付
            zhiFu: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { gongzi: _$tr.attr("i_baoxiaoid") };
                _status = _$tr.attr("i_status");
                var _title = "工资支付";
                if (_status == "<%=(int)EyouSoft.Model.EnumType.FinStructure.GongZiStatus.已支付 %>") _title = "查看支付信息";
                Boxy.iframeDialog({ title: _title, iframeUrl: "GongZiShenPi.aspx", width: "650px", height: "380px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除
            del: function(obj) {
                if (!confirm("工资登记信息删除后不可恢复，你确定要删除吗？")) return;
                var _$tr = $(obj).closest("tr");
                var _data = { gongzi: _$tr.attr("i_baoxiaoid") };

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: "gongzi.aspx?dotype=delete",
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
        });
    </script>

</asp:Content>
