<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiChanFuZhaiBiaoEdit.aspx.cs"
    Inherits="Web.Fin.ZiChanFuZhaiBiaoEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 850px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th style="width: 120px; text-align: right; height: 30px;">
                    年月：
                </th>
                <td colspan="3">
                    <select id="txtYear" name="txtYear" class="inputselect" valid="required" errmsg="请选择年份">
                        <asp:Literal runat="server" ID="ltrYearOptions"></asp:Literal>
                    </select>
                    <select id="txtMonth" name="txtMonth" class="inputselect" valid="required" errmsg="请选择月份">
                        <asp:Literal runat="server" ID="ltrMonthOptions"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <td style="text-align: center; height: 30px; background: #fff;" colspan="4">资产类</td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    货币资金：
                </th>
                <td colspan="3">
                    <input type="text" id="txtHuoBiZiJin" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写货币资金|请填写正确的货币资金" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    应收帐款：
                </th>
                <td colspan="3">
                    <input type="text" id="txtYingShouZhangKuan" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写应收帐款|请填写正确的应收帐款" hejioperator="+"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>            
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    应收团款：
                </td>
                <td>
                    <input type="text" id="txtYingShouTuanKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的应收团款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    应收押金退款：
                </td>
                <td>
                    <input type="text" id="txtYingShouYaJinTuiKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的应收押金退款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    应收酒店退款：
                </td>
                <td>
                    <input type="text" id="txtYingShouJiuDianTuiKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的应收酒店退款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    应收退票款：
                </td>
                <td>
                    <input type="text" id="txtYingShouTuiPiaoKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的应收退票款" hejioperator="+" />
                </td>
            </tr>            
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    其它：
                </td>
                <td colspan="3">
                    <input type="text" id="txtYingShouQiTa" runat="server" class="formsize100 inputtext i_txt_heji_field_1"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的应收帐款-其它" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtYingShouZhangKuanBeiZhu" rows="3" class="formsize450 inputarea"
                        runat="server"></textarea>
                </td>
            </tr> 
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    其他应收款：
                </th>
                <td colspan="3">
                    <input type="text" id="txtQiTaYingShouKuan" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写其他应收款|请填写正确的其他应收款" hejioperator="+"
                        readonly="readonly" disabled="disabled" />
                </td>                
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    质量保证金：
                </td>
                <td>
                    <input type="text" id="txtZhiLiangBaoZhengJin" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的质量保证金" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    个人借款：
                </td>
                <td>
                    <input type="text" id="txtGeRenJieKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的个人借款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    供应商押金：
                </td>
                <td>
                    <input type="text" id="txtGongYingShangYaJin" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的供应商押金" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    酒店押金：
                </td>
                <td>
                    <input type="text" id="txtJiuDianYaJin" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的酒店押金" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                 <td style="text-align: right; height: 30px;">
                    组团社押金：
                </td>
                <td>
                    <input type="text" id="txtZuTuanSheYaJin" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的组团社押金" hejioperator="+" />
                </td>
                <td style="text-align: right;">
                    其它：
                </td>
                <td>
                    <input type="text" id="txtQTYSQiTa" runat="server" class="formsize100 inputtext i_txt_heji_field_2"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的其它应收款-其它" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtQiTaYingShouKuanBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>            
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    预付帐款：
                </th>
                <td colspan="3">
                    <input type="text" id="txtYuFuZhangKuan" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写预付帐款|请填写正确的预付帐款" hejioperator="+"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    地接款：
                </td>
                <td>
                    <input type="text" id="txtYuFuDiJieKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的地接款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    机票款：
                </td>
                <td>
                    <input type="text" id="txtYuFuJiPiaoKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的机票款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    交通押金款：
                </td>
                <td>
                    <input type="text" id="txtYuFuJiaoTongYaJinKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的交通押金款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    酒店款：
                </td>
                <td>
                    <input type="text" id="txtYuFuJiuDianKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的酒店款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">                
                <td style="text-align: right; height: 30px;">
                    其它：
                </td>
                <td colspan="3">
                    <input type="text" id="txtQiTaYuFu" runat="server" class="formsize100 inputtext i_txt_heji_field_3"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的预付账款其它" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtYuFuZhangKuanBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
                        
            <tr class="odd">
                <td style="text-align: center; height: 30px; background:#fff;" colspan="4">
                    负债类
                </td>
            </tr>            
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    应付帐款：
                </th>
                <td colspan="3">
                    <input type="text" id="txtYingFuZhangKuan" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写其应付帐款|请填写正确的应付帐款" hejioperator="-"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    地接款：
                </td>
                <td>
                    <input type="text" id="txtYingFuDiJieKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_4"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的地接款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    机票款：
                </td>
                <td>
                    <input type="text" id="txtYingFuJiPiaoKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_4"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的机票款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    酒店款：
                </td>
                <td>
                    <input type="text" id="txtYingFuJiuDianKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_4"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的酒店款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    其它：
                </td>
                <td>
                    <input type="text" id="txtQiTaYingFuKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_4"
                        maxlength="11" valid="isNumber" errmsg="请填写正确应付账款-其它" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtYingFuZhangKuanBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    预收帐款：
                </th>
                <td colspan="3">
                    <input type="text" id="txtYuShouZhangKuan" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写其预收帐款|请填写正确的预收帐款" hejioperator="-"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    预收团款：
                </td>
                <td>
                    <input type="text" id="txtYuShouTuanKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_5"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的预收团款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    预收退票款：
                </td>
                <td>
                    <input type="text" id="txtYuShouTuiPiaoKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_5"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的预收退票款" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    暂时借款：
                </td>
                <td>
                    <input type="text" id="txtZanShiJieKuan" runat="server" class="formsize100 inputtext i_txt_heji_field_5"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的暂时借款" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    其它：
                </td>
                <td>
                    <input type="text" id="txtQiTaYuShou" runat="server" class="formsize100 inputtext i_txt_heji_field_5"
                        maxlength="11" valid="isNumber" errmsg="请填写正确预收账款-其它" hejioperator="+" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtYuShouZhangKuanBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>              
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    实收股本：
                </th>
                <td colspan="3">
                    <input type="text" id="txtShiShouGuBen" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写实收股本|请填写正确的实收股本" hejioperator="-" />
                </td>               
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注 ：
                </td>
                <td colspan="3">
                    <textarea id="txtShiShouGuBenBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    未分配利润：
                </th>
                <td colspan="3">
                    <input type="text" id="txtWeiFenPeiLiRun" runat="server" class="formsize100 inputtext i_txt_heji_field"
                        maxlength="11" valid="required|isNumber" errmsg="请填写未分配利润|请填写正确的未分配利润" hejioperator="-"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    累计未分配利润：
                </td>
                <td>
                    <input type="text" id="txtLeiJiWeiFenPeiLiRun" runat="server" class="formsize100 inputtext i_txt_heji_field_6"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的累计未分配利润" hejioperator="+" />
                </td>
                <td style="text-align: right; height: 30px;">
                    本月未分配利润：
                </td>
                <td>
                    <input type="text" id="txtBenYueWeiFenPeiLiRun" runat="server" class="formsize100 inputtext i_txt_heji_field_6"
                        maxlength="11" valid="isNumber" errmsg="请填写正确本月未分配利润" hejioperator="+" />
                </td>
            </tr>            
            <tr class="odd">
                <th style="text-align: right; height: 30px;">
                    差 额：
                </th>
                <td colspan="3">
                    <input type="text" id="txtChaE" runat="server" class="formsize100 inputtext" maxlength="11"
                        readonly="readonly" disabled="disabled" />
                </td>
            </tr>            
            <tr class="odd" style="background: #e3f1fc">
                <td style="text-align: right; height: 30px;">
                    备注：
                </td>
                <td colspan="3">
                    <textarea id="txtBeiZhu" rows="3" class="formsize450 inputarea" runat="server"></textarea>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phHistory">
                <tr>
                    <td colspan="4">
                        <br />
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#ffffff"
                            id="i_table_autoadd">
                            <tr class="odd">
                                <td width="36" height="30" align="center">
                                    编号
                                </td>
                                <td align="center">
                                    修改日期
                                </td>
                                <td align="center">
                                    修改项目
                                </td>
                                <td align="center">
                                    修改备注
                                </td>
                                <td align="center">
                                    操作
                                </td>
                            </tr>
                            <asp:Repeater runat="server" ID="rptHistorys">
                                <ItemTemplate>
                                    <tr class="even tempRow">
                                        <td height="30" align="center" class="index">
                                            <%# Container.ItemIndex + 1%>
                                        </td>
                                        <td align="center">
                                            <input name="txtHTime" type="text" class="formsize80 inputtext" onfocus="WdatePicker()"
                                                value="<%#Eval("Time","{0:yyyy-MM-dd}") %>" />
                                        </td>
                                        <td align="center">
                                            <input name="txtHXiangMu" type="text" class="formsize180 inputtext" maxlength="50"
                                                value="<%#Eval("XiangMu") %>" />
                                        </td>
                                        <td align="center">
                                            <textarea name="txtHNeiRong" rows="3" class="formsize180 inputarea" style="width: 250px;"><%#Eval("NeiRong")%></textarea>
                                        </td>
                                        <td align="center">
                                            <a href="javascript:void(0)" class="addbtn">
                                                <img src="/images/addimg.gif" width="48" height="20" /></a> <a href="javascript:void(0)"
                                                    class="delbtn">
                                                    <img src="/images/delimg.gif" width="48" height="20" /></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:PlaceHolder runat="server" ID="phEmptyHistory">
                                <tr class="even tempRow">
                                    <td height="30" align="center" class="index">
                                        1
                                    </td>
                                    <td align="center">
                                        <input name="txtHTime" type="text" class="formsize80 inputtext" onfocus="WdatePicker()" />
                                    </td>
                                    <td align="center">
                                        <input name="txtHXiangMu" type="text" class="formsize180 inputtext" maxlength="50" />
                                    </td>
                                    <td align="center">
                                        <textarea name="txtHNeiRong" rows="3" class="formsize180 inputarea" style="width: 250px;"></textarea>
                                    </td>
                                    <td align="center">
                                        <a href="javascript:void(0)" class="addbtn">
                                            <img src="/images/addimg.gif" width="48" height="20" /></a> <a href="javascript:void(0)"
                                                class="delbtn">
                                                <img src="/images/delimg.gif" width="48" height="20" /></a>
                                    </td>
                                </tr>
                            </asp:PlaceHolder>
                        </table>
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
                            </td>
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
            save: function(obj) {
                var _data = { txtYear: $.trim($("#txtYear").val())
                    , txtMonth: $.trim($("#txtMonth").val())
                    , txtHuoBiZiJin: $.trim($("#<%=txtHuoBiZiJin.ClientID %>").val())
                    , txtYingShouZhangKuan: $.trim($("#<%=txtYingShouZhangKuan.ClientID %>").val())
                    , txtQiTaYingShouKuan: $.trim($("#<%=txtQiTaYingShouKuan.ClientID %>").val())
                    , txtYuFuZhangKuan: $.trim($("#<%=txtYuFuZhangKuan.ClientID %>").val())
                    , txtQiTaYuFu: $.trim($("#<%=txtQiTaYuFu.ClientID %>").val())
                    , txtYingFuZhangKuan: $.trim($("#<%=txtYingFuZhangKuan.ClientID %>").val())
                    , txtQiTaYingFuKuan: $.trim($("#<%=txtQiTaYingFuKuan.ClientID %>").val())
                    , txtYuShouZhangKuan: $.trim($("#<%=txtYuShouZhangKuan.ClientID %>").val())
                    , txtQiTaYuShou: $.trim($("#<%=txtQiTaYuShou.ClientID %>").val())
                    , txtShiShouGuBen: $.trim($("#<%=txtShiShouGuBen.ClientID %>").val())
                    , txtWeiFenPeiLiRun: $.trim($("#<%=txtWeiFenPeiLiRun.ClientID %>").val())
                    , txtChaE: $.trim($("#<%=txtChaE.ClientID %>").val())
                    , txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID %>").val())
                    , txtYingShouTuanKuan: $.trim($("#<%=txtYingShouTuanKuan.ClientID %>").val())
                    , txtYingShouYaJinTuiKuan: $.trim($("#<%=txtYingShouYaJinTuiKuan.ClientID %>").val())
                    , txtYingShouJiuDianTuiKuan: $.trim($("#<%=txtYingShouJiuDianTuiKuan.ClientID %>").val())
                    , txtYingShouTuiPiaoKuan: $.trim($("#<%=txtYingShouTuiPiaoKuan.ClientID %>").val())
                    , txtYingShouQiTa: $.trim($("#<%=txtYingShouQiTa.ClientID %>").val())
                    , txtZhiLiangBaoZhengJin: $.trim($("#<%=txtZhiLiangBaoZhengJin.ClientID %>").val())
                    , txtGeRenJieKuan: $.trim($("#<%=txtGeRenJieKuan.ClientID %>").val())
                    , txtGongYingShangYaJin: $.trim($("#<%=txtGongYingShangYaJin.ClientID %>").val())
                    , txtJiuDianYaJin: $.trim($("#<%=txtJiuDianYaJin.ClientID %>").val())
                    , txtZuTuanSheYaJin: $.trim($("#<%=txtZuTuanSheYaJin.ClientID %>").val())
                    , txtQTYSQiTa: $.trim($("#<%=txtQTYSQiTa.ClientID %>").val())
                    , txtYuFuDiJieKuan: $.trim($("#<%=txtYuFuDiJieKuan.ClientID %>").val())
                    , txtYuFuJiPiaoKuan: $.trim($("#<%=txtYuFuJiPiaoKuan.ClientID %>").val())
                    , txtYuFuJiaoTongYaJinKuan: $.trim($("#<%=txtYuFuJiaoTongYaJinKuan.ClientID %>").val())
                    , txtYuFuJiuDianKuan: $.trim($("#<%=txtYuFuJiuDianKuan.ClientID %>").val())
                    , txtYingFuDiJieKuan: $.trim($("#<%=txtYingFuDiJieKuan.ClientID %>").val())
                    , txtYingFuJiPiaoKuan: $.trim($("#<%=txtYingFuJiPiaoKuan.ClientID %>").val())
                    , txtYingFuJiuDianKuan: $.trim($("#<%=txtYingFuJiuDianKuan.ClientID %>").val())
                    , txtYuShouTuanKuan: $.trim($("#<%=txtYuShouTuanKuan.ClientID %>").val())
                    , txtYuShouTuiPiaoKuan: $.trim($("#<%=txtYuShouTuiPiaoKuan.ClientID %>").val())
                    , txtZanShiJieKuan: $.trim($("#<%=txtZanShiJieKuan.ClientID %>").val())
                    , txtLeiJiWeiFenPeiLiRun: $.trim($("#<%=txtLeiJiWeiFenPeiLiRun.ClientID %>").val())
                    , txtBenYueWeiFenPeiLiRun: $.trim($("#<%=txtBenYueWeiFenPeiLiRun.ClientID %>").val())
                    , txtYingShouZhangKuanBeiZhu: $.trim($("#<%=txtYingShouZhangKuanBeiZhu.ClientID %>").val())
                    , txtQiTaYingShouKuanBeiZhu: $.trim($("#<%=txtQiTaYingShouKuanBeiZhu.ClientID %>").val())
                    , txtYuFuZhangKuanBeiZhu: $.trim($("#<%=txtYuFuZhangKuanBeiZhu.ClientID %>").val())
                    , txtYingFuZhangKuanBeiZhu: $.trim($("#<%=txtYingFuZhangKuanBeiZhu.ClientID %>").val())
                    , txtYuShouZhangKuanBeiZhu: $.trim($("#<%=txtYuShouZhangKuanBeiZhu.ClientID %>").val())
                    , txtShiShouGuBenBeiZhu: $.trim($("#<%=txtShiShouGuBenBeiZhu.ClientID %>").val())
                    , txtHTime: [], txtHXiangMu: [], txtHNeiRong: []
                };
                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return false;

                if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("备注内容不能超过255个字符。"); return; }

                $("input[name='txtHTime']").each(function() { _data.txtHTime.push($.trim($(this).val())); });
                $("input[name='txtHXiangMu']").each(function() { _data.txtHXiangMu.push($.trim($(this).val())); });
                $("textarea[name='txtHNeiRong']").each(function() { _data.txtHNeiRong.push($.trim($(this).val())); });

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST", data: _data, cache: false, dataType: "json", async: false,
                    url: window.location.href + "&doType=save",
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                });
            },
            heJi0: function(expr_0, expr_1) {
                var _sum = 0;
                $(expr_0).each(function() {
                    var _$obj = $(this);
                    var _operator = _$obj.attr("hejioperator");
                    _sum = tableToolbar.calculate(_sum, _$obj.val(), _operator);
                });
                $(expr_1).val(_sum + "");
            },
            heJi: function() {
                this.heJi0(".i_txt_heji_field", "#<%=txtChaE.ClientID %>");
            },
            heJi1: function() {
                this.heJi0(".i_txt_heji_field_1", "#<%=txtYingShouZhangKuan.ClientID %>");
                this.heJi();
            },
            heJi2: function() {
                this.heJi0(".i_txt_heji_field_2", "#<%=txtQiTaYingShouKuan.ClientID %>");
                this.heJi();
            },
            heJi3: function() {
                this.heJi0(".i_txt_heji_field_3", "#<%=txtYuFuZhangKuan.ClientID %>");
                this.heJi();
            },
            heJi4: function() {
                this.heJi0(".i_txt_heji_field_4", "#<%=txtYingFuZhangKuan.ClientID %>");
                this.heJi();
            },
            heJi5: function() {
                this.heJi0(".i_txt_heji_field_5", "#<%=txtYuShouZhangKuan.ClientID %>");
                this.heJi();
            },
            heJi6: function() {
                this.heJi0(".i_txt_heji_field_6", "#<%=txtWeiFenPeiLiRun.ClientID %>");
                this.heJi();
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            $(".i_txt_heji_field").change(function() { iPage.heJi() });
            $(".i_txt_heji_field_1").change(function() { iPage.heJi1() });
            $(".i_txt_heji_field_2").change(function() { iPage.heJi2() });
            $(".i_txt_heji_field_3").change(function() { iPage.heJi3() });
            $(".i_txt_heji_field_4").change(function() { iPage.heJi4() });
            $(".i_txt_heji_field_5").change(function() { iPage.heJi5() });
            $(".i_txt_heji_field_6").change(function() { iPage.heJi6() });

            $("#i_table_autoadd").autoAdd({});
        });
    </script>

</asp:Content>
