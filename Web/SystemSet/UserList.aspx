<%@ Page Title="人员管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="UserList.aspx.cs" Inherits="Web.SystemSet.UserManage" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">系统设置</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            &nbsp;所在位置&gt;&gt; <a href="#">系统设置</a>&gt;&gt; 组织机构
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <div class="lineCategorybox" style="height: 30px;">
            <table border="0" cellpadding="0" cellspacing="0" class="xtnav">
                <tr>
                    <asp:PlaceHolder ID="phBuMenLanMu" runat="server">
                        <td width="100" align="center">
                            <a href="/SystemSet/DepartManage.aspx">部门名称</a>
                        </td>
                    </asp:PlaceHolder>
                    <td width="100" align="center" class="xtnav-on">
                        <a>部门人员</a>
                    </td>
                    <asp:PlaceHolder ID="phPtJiuDianYongHuLanMu" runat="server">
                        <td width="100" align="center">
                            <a href="/systemset/pingtaijiudianyonghu.aspx?yhlx=2">平台酒店用户</a>
                        </td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phPtJingDianYongHuLanMu" runat="server">
                        <td width="100" align="center">
                            <a href="/systemset/pingtaijiudianyonghu.aspx?yhlx=3">平台景点用户</a>
                        </td>
                    </asp:PlaceHolder>
                </tr>
            </table>
        </div>    
            
        <form id="form1" method="get" action="">
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top:5px;">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox">
                        姓名：
                        <input type="text" id="txtContactName" class="searchinput inputtext formsize100" name="txtContactName" />
                        用户名：
                        <input type="text" id="txtUserName" class="searchinput inputtext formsize100" name="txtUserName" />
                        部门：<select name="txtBuMenId" id="txtBuMenId"><%=GetBuMenOptions() %></select>
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
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" onclick="return DepartEmp.add();">新 增</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" onclick="return DepartEmp.update();">修 改</a>
                    </td>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" onclick="return DepartEmp.del('');">删 除</a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
                <tr>
                    <th width="50" align="center" bgcolor="#BDDCF4">
                        全选
                        <input type="checkbox" name="checkbox" id="chkAll" onclick="DepartEmp.checkAll(this);" />
                    </th>
                    <th  align="center" bgcolor="#BDDCF4">
                        所属部门
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        姓名
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        用户名
                    </th>
                    <th width="4%" align="center" bgcolor="#bddcf4">
                        性别
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        电话
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        手机
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        QQ
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        微信号
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        状态
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
                        授权
                    </th>
                </tr>
                <asp:Repeater ID="rptEmployee" runat="server">
                    <ItemTemplate>
                        <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>">
                            <td height="35" align="center">
                                <%--checkbox isAllowDelete 是否允许删除 0:不可删除--%>
                                <%#(bool)Eval("IsAdmin") == true ? "<input type=\"checkbox\" isAllowDelete=\"0\" class=\"c1\" value='" + Eval("Id") + "'/>" : "<input type=\"checkbox\"  isAllowDelete=\"1\" class=\"c1\" value='" + Eval("Id") + "'/>"%>
                            </td>
                            <td height="35" align="center">
                                <%# Eval("DepartName") %>
                            </td>
                            <td height="35" align="center">
                                <%# ((EyouSoft.Model.CompanyStructure.ContactPersonInfo)Eval("PersonInfo")).ContactName%>
                            </td>
                            <td height="35" align="center">
                                <%#Eval("UserName")%>
                            </td>
                            <td height="35" align="center">
                                <%# ((EyouSoft.Model.CompanyStructure.ContactPersonInfo)Eval("PersonInfo")).ContactSex%>
                            </td>
                            <td align="center">
                                <%# ((EyouSoft.Model.CompanyStructure.ContactPersonInfo)Eval("PersonInfo")).ContactTel%>
                            </td>
                            <td align="center">
                                <%# ((EyouSoft.Model.CompanyStructure.ContactPersonInfo)Eval("PersonInfo")).ContactMobile%>
                            </td>
                            <td align="center">
                                <%# ((EyouSoft.Model.CompanyStructure.ContactPersonInfo)Eval("PersonInfo")).QQ%>
                            </td>
                            <td align="center">
                                <%# Eval("WeiXinHao")%>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" onclick="return DepartEmp.setState('<%# Eval("Id") %>',this)">
                                    <%#((EyouSoft.Model.EnumType.CompanyStructure.UserStatus)Eval("UserStatus"))== EyouSoft.Model.EnumType.CompanyStructure.UserStatus .正常 ? "√" : "×"%></a>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" target="_blank" onclick="return DepartEmp.setPermit('<%# Eval("ID") %>')">
                                    授权</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                <tr>
                    <td height="30" colspan="10" align="right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var DepartEmp = {
            reload: function() {
                window.location.href = window.location.href;
            },
            openDialog: function(p_url, p_title, p_width, p_height) {
                Boxy.iframeDialog({ title: p_title, iframeUrl: p_url, width: p_width, height: p_height });
            },
            update: function() {
                var chks = $("input:checked").not("#chkAll")
                var eId = "";
                if (chks.length != 1) {
                    tableToolbar._showMsg("请选择一位员工");
                    return false;
                }
                else
                    eId = chks.val();
                DepartEmp.openDialog("/SystemSet/UserAdd.aspx?empId=" + eId, "修改员工", "800px", "520px");
                return false;
            },
            add: function() {
                DepartEmp.openDialog("/SystemSet/UserAdd.aspx", "新增员工", "800px", "520px");
                return false;
            },
            del: function() {
                var txtUserId = [];
                $(".c1:checked").each(function() {
                    var _$obj = $(this);
                    txtUserId.push(_$obj.val());
                });

                if (txtUserId.length == 0) { tableToolbar._showMsg("请选择要删除的用户！"); return; }

                if (txtUserId.length > 1) { alert("一次只能删除一个员工账号"); return; }

                if (!confirm("员工账号删除后不可恢复，你确定要删除吗?")) return;
                var _data = { txtUserId: txtUserId[0] };
                $.newAjax({
                    type: "POST", cache: false, dataType: "json", async: false,
                    url: utilsUri.createUri(window.location.pathname, { doType: "delete" }),
                    data: _data,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            DepartEmp.reload();
                        } else {
                            alert(response.msg);
                        }
                    },
                    error: function() { }
                });
            },
            //授权
            setPermit: function(eId) {
                DepartEmp.openDialog("/SystemSet/SetPermit.aspx?empId=" + eId, "授权", "900px", "500px");
                return false;
            },
            //设置状态
            setState: function(v, obj) {
                var _$obj = $(obj);
                var _data = { txtStatus: "stop", txtUserId: v };
                alert($.trim(_$obj.html()))
                if ($.trim(_$obj.html()) == "×") _data.txtStatus = "start";

                $.newAjax({
                    type: "POST", dataType: "json", cache: false,
                    url: "UserList.aspx?doType=setuserstatus",
                    data: _data,
                    success: function(response) {
                        if (response.result == "1") {
                            if (_data.txtStatus == "stop") {
                                tableToolbar._showMsg("已关闭");
                                _$obj.html("×");
                            }
                            else {
                                tableToolbar._showMsg("已开启");
                                _$obj.html("√");
                            }
                        }
                        else {
                            tableToolbar._showMsg(response.msg);
                        }
                    }
                });
            },
            checkAll: function(chk) {
                var chked = $(chk).attr("checked");
                $(".c1:checkbox").attr("checked", chked);
            }
        };
    </script>

</asp:Content>
