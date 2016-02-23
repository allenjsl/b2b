<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenFaFangMingXi.aspx.cs" Inherits="Web.TongJi.JiFenFaFangMingXi" MasterPageFile="~/MasterPage/Front.Master" Title="积分发放明细表-统计分析"%>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">统计分析</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 统计分析 >> 积分发放明细表
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
                    出团日期：<input name="txtQuDate1" type="text" class="formsize80 inputtext" id="txtQuDate1"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtQuDate2" type="text" class="formsize80 inputtext" id="txtQuDate2"
                        onfocus="WdatePicker()" />
                    积分状态：<select id="txtJiFenStatus" class="inputselect" name="txtJiFenStatus">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenStatus),new string[]{"3"}), "") %>
                    </select>
                    积分时间：<input name="txtJiFenShiJian1" type="text" class="formsize80 inputtext" id="txtJiFenShiJian1"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtJiFenShiJian2" type="text" class="formsize80 inputtext" id="txtJiFenShiJian2"
                        onfocus="WdatePicker()" /><br />
                    客户单位：<uc1:KeHuXuanZe runat="server" id="txtKeHu" DuiFangCaoZuoRenClientId="txtKeHuLxrId">
                    </uc1:KeHuXuanZe>
                    对方操作人：<select name="txtKeHuLxrId" id="txtKeHuLxrId" class="inputselect" data-v="<%=KeHuLxrId %>">
                        <option value="">请选择客户单位</option>
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
    
    <div class="btnbox"></div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="40" align="center">
                    序号
                </th>
                <th align="center" width="8%">
                    订单号
                </th>
                <th width="8%" align="center">
                    出团日期
                </th>
                <th align="center">
                    线路名称
                </th>                
                <th width="8%" align="center">
                    成人数
                </th>
                <th align="center" width="18%">
                    积分客户单位
                </th>
                <th width="8%" align="center">
                    积分用户姓名
                </th>
                <th width="8%" align="right">
                    积分&nbsp;
                </th>
                <th width="8%" align="center">
                    状态
                </th>
                <th width="8%" align="center">
                    积分时间
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" data-dingdanid="<%#Eval("DingDanId") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>                            
                        </td>
                        <td align="center">
                            <%#Eval("JiaoYiHao")%>
                        </td>                        
                        <td align="center">
                            <%#Eval("QuDate","{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%#GetRouteName(Eval("RouteName"),Eval("YeWuLeiXing")) %>
                        </td>                        
                        <td align="center">
                            <%#Eval("ChengRenShu")%>
                        </td>
                        <td align="center">
                            <%#Eval("KeHuName")%>
                        </td>
                        <td align="center">
                            <%#Eval("YongHuXingMing")%>
                        </td>
                        <td align="right">
                            <%#Eval("JiFen")%>&nbsp;
                        </td>
                        <td align="center">
                            <%#GetJiFenStatus(Eval("JiFenStatus"))%>
                        </td>
                        <td align="center">
                            <%#Eval("JiFenShiJian","{0:yyyy-MM-dd}") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何积分发放明细信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td colspan="7" style="text-align:right; height:30px;">合计：</td>
                    <td style="text-align:right;"><asp:Literal runat="server" ID="ltrJiFenHeJi"></asp:Literal>&nbsp;</td>
                    <td colspan="2"></td>
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
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
        });
    </script>
</asp:Content>
