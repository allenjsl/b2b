<%@ Page Title="����-��Դ����" Language="C#" MasterPageFile="~/MasterPage/Front.Master"
    AutoEventWireup="true" CodeBehind="ScenicList.aspx.cs" Inherits="Web.ResourceManage.ScenicList" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="mainbody">
        <!-- InstanceBeginEditable name="EditRegion3" -->
        <div class="mainbody">
            <div class="lineprotitlebox">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">��Դ����</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            ����λ�� &gt;&gt; ��Դ���� &gt;&gt; ����
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
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="10" valign="top">
                        <img src="/images/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <div class="searchbox">
                            <label>
                                ʡ�ݣ�</label>
                            <select name="txtProvince" id="txtProvince" class="inputselect">
                            </select>
                            <label>
                                ���У�</label>
                            <select name="txtCity" id="txtCity" class="inputselect">
                            </select>
                            <label>
                                �������ƣ�</label>
                            <input type="text" class="searchinput" id="sight_name" name="sight_name" runat="server"
                                value="" />
                            <label>
                                �Ǽ���</label>
                            <asp:DropDownList ID="ddlscStar" runat="server" CssClass="inputselect">
                                <asp:ListItem Text="--��ѡ���Ǽ�--" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                            <a href="javascript:void(0);" id="searchbtn">
                                <img src="/images/searchbtn.gif" style="vertical-align: top;" /></a>
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/images/yuanright.gif" alt="" />
                    </td>
                </tr>
            </table>
            <div class="btnbox">
                <table border="0" align="left" cellpadding="0" cellspacing="0" style="width: 360px">
                    <tr>
                        <td width="90">
                            <%if (add)
                              { %>
                            <a href="javascript:;" class="add">�� ��</a><%} %>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablelist">
                <table width="100%" border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th width="5%" height="30" align="center" bgcolor="#BDDCF4">
                            ���
                        </th>
                        <th width="14%" align="center" bgcolor="#BDDCF4">
                            ���ڵ�
                        </th>
                        <th width="10%" align="center" bgcolor="#bddcf4">
                            ��������
                        </th>
                        <th width="8%" align="center" bgcolor="#bddcf4">
                            �Ǽ�
                        </th>
                        <th width="8%" align="center" bgcolor="#bddcf4">
                            �ŶӼ�
                        </th>
                        <th width="7%" align="center" bgcolor="#bddcf4">
                            ɢ�ͼ�
                        </th>
                        <th width="7%" align="center" bgcolor="#bddcf4">
                            ��ϵ��
                        </th>
                        <th width="7%" align="center" bgcolor="#bddcf4">
                            �绰
                        </th>
                        <th width="7%" align="center" bgcolor="#bddcf4">
                            ����
                        </th>
                        <th width="14%" align="center" bgcolor="#bddcf4">
                            ����
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptList">
                        <ItemTemplate>
                            <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                                <td height="30" align="center">
                                    <%# Container.ItemIndex + 1 + (this.pageIndex - 1) * this.pageSize%>
                                </td>
                                <td align="center">
                                    <%#Eval("ProvinceName")%><%#Eval("CityName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("UnitName")%>
                                </td>
                                <td align="center">
                                    <%#DisponseStar(Convert.ToString(Eval("Start")))%>
                                </td>
                                <td align="center">
                                    <%#EyouSoft.Common.Utils.FilterEndOfTheZeroString(EyouSoft.Common.Utils.GetDecimal(Eval("TeamPrice").ToString()).ToString("0.00"))%>
                                </td>
                                </td>
                                <td align="center">
                                    <%#EyouSoft.Common.Utils.FilterEndOfTheZeroString(EyouSoft.Common.Utils.GetDecimal(Eval("TravelerPrice").ToString()).ToString("0.00"))%>
                                </td>
                                <%#GetContactInfo(Eval("SupplierContact"))%>
                                <td align="center">
                                    <a class="show" id="<%#Eval("Id") %>" href="javascript:void(0);">�鿴</a>
                                    <%if (update)
                                      { %>
                                    <a class="update" id="<%#Eval("Id") %>" href="javascript:void(0)">�޸�</a>
                                    <%} %>
                                    <%if (del)
                                      { %>
                                    <a class="del" id="<%#Eval("Id") %>" href="javascript:void(0)">ɾ��</a><%} %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="30" align="right" class="pageup" colspan="13">
                            <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!-- InstanceEndEditable -->
    </div>
    </form>

    <script type="text/javascript">
        $(function() {
            $(".add").click(function() {
                var url = "/ResourceManage/ScenicAdd.aspx?type=add";
                Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "��������",
                    modal: true,
                    width: "920px",
                    height: "680px"
                });
                return false;
            });

            $("#searchbtn").click(function() {
                var proid = $("#txtProvince").val();
                var cityid = $("#txtCity").val();
                var star = $.trim($("#<%=ddlscStar.ClientID %>").val());
                var url = "ScenicList.aspx?cityId=" + cityid + "&proid=" + proid + "&sight_name=" + encodeURIComponent($("#<%=sight_name.ClientID %>").val()) + "&star=" + star;

                window.location.href = url;
                return false;
            });

            pcToobar.init({
                pID: "#txtProvince",
                cID: "#txtCity",
                pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("proid"),0) %>',
                cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("cityId"),0) %>',
                comID: '<%= this.SiteUserInfo.CompanyId %>',
                isCy: "0"
            });
        });
        //���½��浯��
        $(".update").click(function() {
            var url = "/ResourceManage/ScenicAdd.aspx?type=modify&sid=" + $(this).attr("id");
            Boxy.iframeDialog({
                iframeUrl: url,
                title: "�����޸�",
                modal: true,
                width: "920px",
                height: "680px"
            });
            return false;
        });
        //���½��浯��
        $(".show").click(function() {
            var url = "/ResourceManage/ScenicAdd.aspx?type=show&sid=" + $(this).attr("id");
            Boxy.iframeDialog({
                iframeUrl: url,
                title: "����鿴",
                modal: true,
                width: "920px",
                height: "680px"
            });
            return false;
        });
        //����ɾ��
        $(".del").click(function() {
            if (confirm("ȷ��Ҫɾ��ô")) {
                $.newAjax({
                    url: "ScenicAdd.aspx?type=dels&ids=" + $(this).attr("id"),
                    type: "GET",
                    cache: false,
                    success: function(result) {
                        if (result == "True") {
                            alert("ɾ���ɹ�");
                            window.location = location;
                        } else {
                            alert("ɾ��ʧ��")
                        }
                    }
                });
            }
            return false;
        })

    </script>

</asp:Content>
