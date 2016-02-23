<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="HotelAdd.aspx.cs" Inherits="Web.ResourceManage.HotelAdd" %>

<%@ Register Src="../UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc3" %>
<%@ Register Src="../UserControl/Contact.ascx" TagName="Contact" TagPrefix="uc4" %>
<%@ Register Src="../UserControl/BankContact.ascx" TagName="BankContact" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/ValiDatorForm.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <table width="900" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top: 10px;">
            <tr class="odd">
                <th  width="95" height="30" align="center">
                    <span style="color: red">*</span> 省份：
                </th>
                <td width="330" align="left">
                    <select name="txtProvince" id="txtProvince" class="inputselect" valid="required"
                        errmsg="请选择省份!">
                    </select>
                </td>
                <th width="70" align="center">
                    城市：
                </th>
                <td width="330" align="left">
                    <select name="txtCity" id="txtCity" class="inputselect">
                    </select>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center">
                    <span style="color: red">*</span>单位名称：
                </th>
                <td align="left">
                    <input valid="required" errmsg="请输入单位名称！" type="text" id="unionname" name="unionname"
                        value="" runat="server" class="searchinput searchinput02" />
                </td>
                <th align="center">
                    星级：
                </th>
                <td align="left">
                    <asp:DropDownList ID="HotelStart" runat="server" CssClass="inputselect">
                        <asp:ListItem Text="--请选择酒店星级--" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    地址：
                </th>
                <td colspan="3" align="left">
                    <input type="text" id="TxtHotelAddress" name="TxtHotelAddress" value="" runat="server"
                        class="searchinput searchinput02" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center">
                    酒店简介：
                </th>
                <td colspan="3" align="left">
                    <textarea name="HotelIntroduction" id="HotelIntroduction" cols="45" rows="5" class="inputarea formsize600"
                        runat="server"></textarea>
                </td>
            </tr>
            
            <tr class="odd">
                <th height="30" align="center">
                    合作协议：
                </th>
                <td align="left" colspan="3">
                    <uc3:UploadControl ID="UploadHeZuoXieYi" runat="server" IsUploadMore="false" IsUploadSelf="true" />
                </td>
            </tr>
            
            <tr class="odd">
                <th height="30" align="center">
                    酒店图片：
                </th>
                <td colspan="3" align="left" class="updom">
                    <uc3:UploadControl ID="UploadControl1" runat="server" IsUploadMore="true" IsUploadSelf="true" FileTypes="*.jpg;*.jpeg;*.gif;*.png;*.bmp;" />
                    <div style="width: 450px; float: left; margin-left: 5px;">
                        <asp:Repeater ID="rplfile" runat="server">
                            <ItemTemplate>
                                <a target="_blank" href='<%#Eval("PicPath") %>' style="vertical-align: bottom">查看</a><span><img
                                    alt="" name="del" style="vertical-align: bottom; cursor: pointer;" src="/images/cha.gif"
                                    data-delimg="delimg" />
                                    <input type="hidden" name="hidefile" value="<%#Eval("Id") %>|<%#Eval("PicPath") %>" /></span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="center">
                    其它附件：
                </th>
                <td colspan="3" align="left" class="updom">
                    <uc3:uploadcontrol id="UploadControl2" runat="server" isuploadmore="true" isuploadself="true" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center">
                    导游词：
                </th>
                <td colspan="3" align="left">
                    <textarea name="TourGuids" id="TourGuids" cols="45" rows="5" class="inputarea formsize600"
                        runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th align="center">
                    联系人：
                </th>
                <td colspan="3" align="left">
                    <uc4:Contact ID="Contact1" runat="server" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="center">
                    价格：
                </th>
                <td colspan="3" align="left">
                    <table id="pricesList" width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
                        <tr class="odd">
                            <th width="20%" height="30" align="center">
                                房型
                            </th>
                            <th width="20%" align="center">
                                前台销售价
                            </th>
                            <th width="20%" align="center">
                                结算价
                            </th>
                            <th width="24%" align="center">
                                含早
                            </th>
                            <th width="120" align="center">
                                操作
                            </th>
                        </tr>
                        <%if (Hotelinfo.RoomTypes != null && Hotelinfo.RoomTypes.Count > 0)
                          {
                              int temp = 0;
                              foreach (EyouSoft.Model.CompanyStructure.SupplierHotelRoomType roomtype in Hotelinfo.RoomTypes)
                              {
                        %>
                        <tr class="<% =temp%2==0?"even":"odd" %>">
                            <th height="30" align="center">
                                <input name="Chamber" type="text" class="searchinput Chamber" value="<%= roomtype.Name %>" />
                            </th>
                            <th align="center">
                                <input name="SalaesPrices" type="text" class="searchinput SalaesPrices" value="<%=EyouSoft.Common.Utils.FilterEndOfTheZeroString(EyouSoft.Common.Utils.GetDecimal(roomtype.SellingPrice.ToString()).ToString("0.00")) %>" />
                            </th>
                            <th align="center">
                                <input name="SettlementPrice" type="text" class="searchinput SettlementPrice" value="<%=EyouSoft.Common.Utils.FilterEndOfTheZeroString(EyouSoft.Common.Utils.GetDecimal(roomtype.AccountingPrice.ToString()).ToString("0.00")) %>" />
                            </th>
                            <th align="center">
                                <input type='hidden' name='hd_rbtn' value="<%=roomtype.IsBreakfast?"1":"2"%>" /><input
                                    name="radiobutton<%=temp %>" class="radiobutton" <%=roomtype.IsBreakfast?"checked":"" %>
                                    type="radio" value="1" />
                                是
                                <input type="radio" name="radiobutton<%=temp %>" <%=roomtype.IsBreakfast?"":"checked" %>
                                    class="radiobutton" value="2" />否
                            </th>
                            <td align="center">
                                <%if (!show)
                                  { %>
                                <a href="javascript:void(0);" class="addprices">
                                    <img alt="" src="/images/addimg.gif" /></a> <a href="javascript:viod(0);" class="delprices">
                                        <img src="/images/delimg.gif" /></a><%} %>
                            </td>
                        </tr>
                        <% temp++;
                              }
                          }
                          else
                          { %>
                        <tr class="even">
                            <th height="30" align="center">
                                <input name="Chamber" type="text" class="searchinput Chamber" />
                            </th>
                            <th align="center">
                                <input name="SalaesPrices" type="text" class="searchinput SalaesPrices" />
                            </th>
                            <th align="center">
                                <input name="SettlementPrice" type="text" class="searchinput SettlementPrice" />
                            </th>
                            <th align="center">
                                <input type='hidden' name='hd_rbtn' value="1" /><input name="radiobutton" class="radiobutton"
                                    type="radio" value="1" checked="checked" />
                                是
                                <input type="radio" name="radiobutton" class="radiobutton" value="2" />否
                            </th>
                            <td align="center">
                                <%if (!show)
                                  { %><a href="javascript:void(0);" class="addprices">
                                      <img alt="" src="/images/addimg.gif" /></a> <a href="javascript:viod(0);" class="delprices">
                                          <img src="/images/delimg.gif" /></a><%} %>
                            </td>
                        </tr>
                        <%} %>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th height="60" align="center">
                    银行账户：
                </th>
                <td colspan="3">
                    <uc5:BankContact ID="BankContact1" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="60" align="center">
                    备注:
                </th>
                <td colspan="3">
                    <textarea name="HotelRemarks" id="HotelRemarks" cols="45" rows="5" class="inputarea formsize600"
                        runat="server"></textarea>
                </td>
            </tr>
        </table>
        <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="40" align="center">
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <%if (!show)
                      { %>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return checkForm();"
                        OnClick="LinkButton1_Click">保存</asp:LinkButton><%} %>
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">
                        关闭</a>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            $("img[name=del]").click(function() {
                var thisimg = $(this).parent();
                thisimg.prev("a").remove();
                thisimg.remove();
            });
        })


        $("#tblbank").autoAdd({ tempRowClass: "trbank", addButtonClass: "addbtn", delButtonClass: "delbtn", indexClass: "indexcontact" });

        function checkForm() {
            return ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
        };

        $(document).ready(function() {
            $(".radiobutton").click(function() {
                $(this).prevAll("[name='hd_rbtn']").val($(this).val());
            });

            var count = 1;
            //价格组成
            function getpriceinput() {
                var cls = $("#userlist").find("tr").length % 2 ? "even" : "odd";
                var html = "<tr class=\"" + cls + "\">" +
                                "<th height=\"30\" align=\"center\"><input name=\"Chamber\" type=\"text\" class=\"searchinput Chamber\"/></th>" +
                                "<th align=\"center\"><input name=\"SalaesPrices\" type=\"text\" class=\"searchinput SalaesPrices\"/></th>" +
                                "<th align=\"center\"><input name=\"SettlementPrice\" type=\"text\" class=\"searchinput SettlementPrice\" /></th>" +
                                "<th align=\"center\"><input type='hidden' value='1' name='hd_rbtn'/><input name=\"radiobutton" + (count + 1) + "\" class=\"radiobutton" + (count + 1) + "\" type=\"radio\"  value=\"1\" />是<input type=\"radio\" name=\"radiobutton" + (count + 1) + "\"  class=\"radiobutton" + (count + 1) + "\" value=\"2\"/>否</th>" +
                                "<td align=\"center\"><a href=\"javascript:;\" class=\"addprices\" ><img   alt=\"\" src=\"/images/addimg.gif\" /> </a> <a href=\"javascript:;\" class=\"delprices\" ><img src=\"/images/delimg.gif\"    /> </a></td>" +
                                "</tr>";
                return html;
            };
            function addprices() {
                var html = getpriceinput();
                $("#pricesList").append(html);

                $(".radiobutton" + (count + 1) + "").click(function() {
                    $(this).prevAll("[name='hd_rbtn']").val($(this).val());
                });
                count++;
                $("a.addprices").unbind().bind("click", function() {
                    addprices();
                    return false;
                });
                $("a.delprices").unbind().bind("click", function() {
                    var that = $(this);
                    delprices(that);
                    return false;
                });
            };
            function delprices(that) {
                var trlist = $("#pricesList").find("tr");
                if (trlist.length > 2) {
                    that.parent().parent().remove();
                }
            };
            $("a.addprices").bind("click", function() {
                addprices();
                return false;
            });
            $("a.delprices").bind("click", function() {
                var that = $(this);
                delprices(that);
                return false;
            });

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
