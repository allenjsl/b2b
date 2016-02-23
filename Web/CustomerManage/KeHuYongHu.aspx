<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeHuYongHu.aspx.cs" Inherits="Web.CustomerManage.KeHuYongHu"
    MasterPageFile="~/MasterPage/Front.Master" Title="客户账号管理" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">客户管理</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            &nbsp;所在位置&gt;&gt; <a href="javascript:void(0)">客户管理</a>&gt;&gt; 客户账号管理
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <form id="form1" method="get" action="">
                    <div class="searchbox">
                        客户名称：<input type="text" id="txtKeHuName" class="searchinput inputtext formsize100"
                            name="txtKeHuName" />
                        用户姓名：
                        <input type="text" id="txtYongHuXingMing" class="searchinput inputtext formsize100"
                            name="txtYongHuXingMing" />
                        用户账号：
                        <input type="text" id="txtYongHuMing" class="searchinput inputtext formsize100" name="txtYongHuMing" />
                        用户状态：
                        <select name="txtYongHuStatus" id="txtYongHuStatus" class="inputselect">
                            <option value="">--请选择--</option>
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.UserStatus),new string[]{"0","2"}), "") %>
                        </select>
                        <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        <div class="btnbox">
            
        </div>
        <div class="tablelist">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
                <tr>
                    <th width="50" align="center" bgcolor="#BDDCF4" style="height: 30px;">
                        序号
                    </th>
                    <th align="center" bgcolor="#bddcf4">
                        客户单位
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        姓名
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        用户名
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        性别
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        电话
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        手机
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        邮箱
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        QQ
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        微信号
                    </th>
                    <th width="6%" align="center" bgcolor="#bddcf4">
                        状态
                    </th>
                    <th width="6%" align="center" bgcolor="#bddcf4">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptYongHu">
                    <ItemTemplate>
                        <tr data-yonghuid="<%#Eval("Id") %>">
                            <td width="50" align="center" bgcolor="#BDDCF4" style="height: 30px;">
                                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("KeHuName") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("PersonInfo.ContactName") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("UserName") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("PersonInfo.ContactSex") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("PersonInfo.ContactTel") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("PersonInfo.ContactMobile") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("PersonInfo.ContactEmail") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%#Eval("PersonInfo.QQ") %>
                            </td>
                            <td align="center" bgcolor="#bddcf4">
                                <%# Eval("WeiXinHao")%>
                            </td>
                            <td align="center" bgcolor="#bddcf4">                                
                                <%#Eval("UserStatus")%>
                            </td>
                            <td align="center" bgcolor="#bddcf4">                                
                                <%#GetCaoZuo(Eval("UserStatus"))%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                    <tr class="even">
                        <td style="height: 30px; text-align: center;" colspan="10">
                            暂无客户账号信息
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td height="30" colspan="11" align="right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="FenYe" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            sheZhiStatus: function(obj) {
                var _$obj = $(obj);
                var _$tr = _$obj.closest("tr");

                var _data = { txtFS: _$obj.attr("data-fs"), txtYongHuId: _$tr.attr("data-yonghuid") };

                var _confirmXiaoXi = "你确定要开启该用户账号吗？";
                if (_data.txtFS == "jinyong") _confirmXiaoXi = "禁用后该账号将不能登录客户平台，你确定要禁用吗？";

                if (!confirm(_confirmXiaoXi)) return;

                $.newAjax({ type: "POST", url: "kehuyonghu.aspx?doType=shezhiyonghustatus", data: _data,
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        iPage.reload();
                    },
                    error: function() {
                        iPage.reload();
                    }
                });

            }
        }

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".shezhistatus").click(function() { iPage.sheZhiStatus(this); });
        });
    </script>

</asp:Content>
