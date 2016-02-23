<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="ScenicAdd.aspx.cs" Inherits="Web.ResourceManage.ScenicAdd" %>

<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/Contact.ascx" TagName="Contact" TagPrefix="uc3" %>
<%@ Register src="../UserControl/BankContact.ascx" tagname="BankContact" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <input type="hidden" id="hid_linkmanCount" value="<%=linkman_row %>" />
    <input type="hidden" name="hid_img" />
    <table cellspacing="1" cellpadding="0" border="0" align="center" width="900" style="margin-top: 10px;">
        <tbody>
            <tr class="odd">
                <th  width="95" height="30" align="center" class="style1">
                    <span style="color: Red">*</span>省份：
                </th>
                <td align="left" width="330">
                    <select name="txtProvince" id="txtProvince" class="inputselect" valid="required"
                        errmsg="请选择省份!">
                    </select>
                </td>
                <th align="center" width="70">
                    城市：
                </th>
                <td align="left" width="330">
                    <select name="txtCity" id="txtCity" class="inputselect">
                    </select>
                </td>
            </tr>
            <tr class="even">
                <th align="center" class="style2">
                    <span style="color: Red">*</span>景点名称：
                </th>
                <td align="left" class="style3">
                    <input type="text" id="companyName" class="searchinput" name="companyName" style="width: 150px"
                        valid="required" errmsg="请输入景点名称" runat="server" />
                    <span id="errMsg_companyName" class="errmsg"></span>
                </td>
                <th align="center" class="style2">
                    星级：
                </th>
                <td align="left" width="330" class="style3">
                    <asp:DropDownList ID="sel_star" runat="server" CssClass="inputselect">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center" class="style1">
                    地址：
                </th>
                <td align="left" colspan="3">
                    <input type="text" id="companyAddress" name="companyAddress" style="width: 150px"
                        class="searchinput" runat="server" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center" class="style1">
                    合作协议：
                </th>
                <td align="left" colspan="3">
                    <uc1:UploadControl ID="UploadControl2" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center" class="style1">
                    景点图片：
                </th>
                <td align="left" colspan="3">
                    <uc1:UploadControl ID="UploadControl1" runat="server" IsUploadMore="true" IsUploadSelf="true"  FileTypes="*.jpg;*.jpeg;*.gif;*.png;*.bmp;"/>
                    <asp:Repeater ID="rplfile" runat="server">
                        <ItemTemplate>
                            <span><a target="_blank" href='<%#Eval("PicPath") %>' style="vertical-align: bottom">
                                查看</a><img onclick="RemoveFile(this)" alt="" name="del" style="vertical-align: bottom;
                                    cursor: pointer;" src="/images/cha.gif" data-delimg="delimg" />
                                <input type="hidden" name="hidefilePIC" value="<%#Eval("Id") %>|<%#Eval("PicPath") %>" /></span>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    其它附件：
                </th>
                <td colspan="3" align="left" class="updom">
                    <uc1:UploadControl ID="UploadControl3" runat="server" IsUploadMore="true" IsUploadSelf="true" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center" class="style1">
                    导游词：
                </th>
                <td align="left" colspan="3">
                    <textarea class="inputarea formsize600" name="guideworld" rows="5" cols="45" id="guideworld"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th align="center">
                    联系人：
                </th>
                <td colspan="3" align="left">
                    <uc3:Contact ID="Contact1" runat="server" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center" class="style1">
                    价格：
                </th>
                <td align="left" colspan="3">
                    散客价:<input type="text" id="single_price" valid="isNumber" errmsg="请输入数字" class="searchinput"
                        name="single_price" runat="server" />
                    <span id="errMsg_single_price" class="errmsg"></span>团队价:<input type="text" id="rl_price"
                        class="searchinput" name="rl_price" runat="server" valid="isNumber" errmsg="请输入数字" />
                    <span id="errMsg_rl_price" class="errmsg"></span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center" class="style1">
                    政策：
                </th>
                <td align="left" colspan="3">
                    <textarea class="inputarea formsize600" rows="5" cols="45" name="txt_zc" id="txt_zc"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="even">
                <th height="60" align="center">
                    银行账户：
                </th>
                <td colspan="3">
                    
                    <uc4:BankContact ID="BankContact1" runat="server" />
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="60" align="center" class="style1">
                    备注：
                </th>
                <td colspan="3">
                    <textarea class="inputarea formsize600" rows="5" cols="45" id="txt_remark" name="txt_remark"
                        runat="server"></textarea>
                </td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="0" cellpadding="0" border="0" align="center" width="320">
        <tbody>
            <tr>
                <td height="40" align="center">
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <asp:LinkButton ID="btnSave" runat="server" OnClientClick="return checkForm()" OnClick="btnSave_Click"
                        Text="保存" />
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()"
                        id="linkCancel" href="javascript:;">关闭</a>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="livemargins_control" style="position: absolute; display: none; z-index: 9999;">
        <img height="5" width="77" style="position: absolute; left: -77px; top: -5px;" src="chrome://livemargins/skin/monitor-background-horizontal.png" />
        <img style="position: absolute; left: 0pt; top: -5px;" src="chrome://livemargins/skin/monitor-background-vertical.png" />
        <img style="position: absolute; left: 1px; top: 0pt; opacity: 0.5; cursor: pointer;"
            onmouseout="this.style.opacity=0.5" onmouseover="this.style.opacity=1" src="chrome://livemargins/skin/monitor-play-button.png"
            id="monitor-play-button" />
    </div>
    <input type="hidden" id="hideContactCount" value="" />
    </form>

    <script type="text/javascript">
        function RemoveFile(obj) {
            $(obj).parent().remove();
        };

        $("#tblbank").autoAdd({ tempRowClass: "trbank", addButtonClass: "addbtn", delButtonClass: "delbtn", indexClass: "indexcontact" });
        var link_count = $("#hideContactCount").val();
        //判断是添加还是更新
        var type = $("#hid_type").val();
        //验证事件
        function checkForm() {
            return ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
        };

        $(document).ready(function() {
            pcToobar.init({
                pID: "#txtProvince",
                cID: "#txtCity",
                pSelect: '<%= ProvinceId %>',
                cSelect: '<%= CityId %>',
                comID: '<%= this.SiteUserInfo.CompanyId %>',
                isCy: "0"
            });
        });
    
    </script>

</asp:Content>
