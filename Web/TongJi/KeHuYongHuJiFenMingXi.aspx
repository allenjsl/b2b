<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeHuYongHuJiFenMingXi.aspx.cs"
    Inherits="Web.TongJi.KeHuYongHuJiFenMingXi" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <div style="height: 30px; line-height: 30px; border: 1px solid #BDDCF4; width:100%">
        <form id="from_chaxun">
        <input type="hidden" id="txtKeHuId" name="txtKeHuId" />
        <input type="hidden" id="txtYongHuId" name="txtYongHuId" />
        <input type="hidden" id="iframeId" name="iframeId" />
        <input type="hidden" id="refererLeiXing" name="refererLeiXing" />
        &nbsp;积分类型：<select name="txtJiFenLeiXing" id="txtJiFenLeiXing" class="inputselect">
            <option value="">-请选择-</option>
            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenLeiXing)), "") %>
        </select>
        积分状态：<select name="txtJiFenStatus" id="txtJiFenStatus" class="inputselect">
            <option value="">-请选择-</option>
            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiFenStatus),new string[]{"3"}), "") %>
        </select>
        积分时间：<input type="text" name="txtJiFenShiJian1" id="txtJiFenShiJian1" class="inputtext"
            style="width: 70px;" onfocus="WdatePicker()" />-<input type="text" name="txtJiFenShiJian2"
                id="txtJiFenShiJian2" class="inputtext" style="width: 70px;" onfocus="WdatePicker()" />
        <input type="submit" value=" 查 询 " />
        </form>
        </div>
        
        <div style="height: 30px; line-height: 30px; border: 1px solid #BDDCF4; width:100%; margin-top:5px;">
            &nbsp;<asp:Literal runat="server" ID="ltrYongHuJiFenXinXi"></asp:Literal>
        </div>
    
        <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#FFFFFF" style="margin-top:5px;">
            <tr class="odd" style="height:30px;">
                <th align="center" style="width: 40px;">
                    序号
                </th>
                <th style="width:180px; text-align:left;">发放专线商</th>
                <th align="left">
                    积分明细
                </th>
                <th align="center" style="width: 120px;">
                    积分时间
                </th>                
                <th align="right" style="width: 100px;">
                    积分&nbsp;
                </th>
                <th align="center" style="width: 100px;">
                    状态
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_ItemDataBound">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="left">
                            <%#Eval("FaFangZxsName") %>
                        </td>
                        <td align="left">
                            <asp:Literal runat="server" ID="ltrJiFenMingXi"></asp:Literal>
                        </td>
                        <td align="center">
                            <%#Eval("JiFenShiJian","{0:yyyy-MM-dd HH:mm}") %>
                        </td>
                        <td align="right">
                            <%#Eval("JiFen") %>&nbsp;
                        </td>
                        <td align="center">
                            <%#GetJiFenStatus(Eval("JiFenStatus"))%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr>
                    <td class="even" colspan="10" style="height: 30px; text-align: center;">
                        暂无任何积分明细信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server" Visible="false">
                <tr class="even">
                    <td colspan="4" style="text-align: right; height: 30px;">
                        合计：
                    </td>
                    <td style="text-align: right;">
                        <asp:Literal runat="server" ID="ltrJiFenHeJi"></asp:Literal>&nbsp;
                    </td>
                    <td>
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
        $(document).ready(function() {
            utilsUri.initSearch();
        });
    </script>

</asp:Content>
