<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PingTaiJiuDianYongHu.aspx.cs"
    Inherits="Web.SystemSet.PingTaiJiuDianYongHu" MasterPageFile="~/MasterPage/Front.Master"
    Title="平台酒店管理用户管理" %>

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
                    <asp:PlaceHolder ID="phYongHuLanMu" runat="server">
                    <td width="100" align="center" >
                        <a href="/systemset/userlist.aspx">部门人员</a>
                    </td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phPtJiuDianYongHuLanMu" runat="server">
                        <td width="100" align="center" id="td_caozuolan_yhlx_2">
                            <a href="/systemset/pingtaijiudianyonghu.aspx?yhlx=2">平台酒店用户</a>
                        </td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phPtJingDianYongHuLanMu" runat="server">
                        <td width="100" align="center" id="td_caozuolan_yhlx_3">
                            <a href="/systemset/pingtaijiudianyonghu.aspx?yhlx=3">平台景点用户</a>
                        </td>
                    </asp:PlaceHolder>                    
                </tr>
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
                        姓名：
                        <input type="text" id="txtXingMing" class="searchinput inputtext formsize100" name="txtXingMing" />
                        用户名：
                        <input type="text" id="txtYongHuMing" class="searchinput inputtext formsize100" name="txtYongHuMing" />
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
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="javascript:void(0)" id="i_a_tianjia">新 增</a>
                    </td>
                </tr>
            </table>
        </div>
        
        <div class="tablelist">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" id="liststyle">
                <tr>
                    <th width="50" align="center" bgcolor="#BDDCF4" style="height:30px;">
                        序号
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        姓名
                    </th>
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        用户名
                    </th>
                    <th width="8%" align="center" bgcolor="#bddcf4">
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
                    <th width="10%" align="center" bgcolor="#bddcf4">
                        状态
                    </th>
                    <th width="" align="center" bgcolor="#bddcf4">
                        操作
                    </th>
                </tr>
                
                <asp:Repeater runat="server" ID="rptYongHu">
                <ItemTemplate>
                <tr data-yonghuid="<%#Eval("Id") %>">
                    <td width="50" align="center" bgcolor="#BDDCF4" style="height:30px;">
                        <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%#Eval("PersonInfo.ContactName") %>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%#Eval("UserName") %>
                    </td>
                    <td width="8%" align="center" bgcolor="#bddcf4">
                        <%#Eval("PersonInfo.ContactSex") %>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%#Eval("PersonInfo.ContactTel") %>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%#Eval("PersonInfo.ContactMobile") %>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%#Eval("PersonInfo.QQ") %>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%# Eval("WeiXinHao")%>
                    </td>
                    <td width="10%" align="center" bgcolor="#bddcf4">
                        <%#((EyouSoft.Model.EnumType.CompanyStructure.UserStatus)Eval("UserStatus"))== EyouSoft.Model.EnumType.CompanyStructure.UserStatus .正常 ? "√" : "×"%>
                    </td>
                    <td width="" align="center" bgcolor="#bddcf4">
                        <a href="javascript:void(0)" data-class="xiugai">修改</a> <a href="javascript:void(0)" data-class="shanchu">删除</a>
                    </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>     
                
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
                <tr class="even">
                   <td style="height: 30px; text-align: center;" colspan="10">暂无用户信息</td>
                </tr>
                </asp:PlaceHolder>
                <tr>
                    <td height="30" colspan="10" align="right" class="pageup">
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
            tianJia: function() {
                var _data = { yhlx: "<%=(int)YHLX %>" };
                var _title = "平台酒店用户新增";
                if (_data.yhlx == "3") _title = "平台景点用户新增";
                Boxy.iframeDialog({ title: _title, iframeUrl: "pingtaijiudianyonghuedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            xiuGai: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { editid: _$tr.attr("data-yonghuid"), yhlx: "<%=(int)YHLX %>" };
                var _title = "平台酒店用户修改";
                if (_data.yhlx == "3") _title = "平台景点用户修改";
                Boxy.iframeDialog({ title: "平台酒店用户修改", iframeUrl: "pingtaijiudianyonghuedit.aspx", width: "870px", height: "540px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {

            }
        }

        $(document).ready(function() {
            $("#i_a_tianjia").click(function() { iPage.tianJia(); });
            $('a[data-class="xiugai"]').click(function() { iPage.xiuGai(this); });
            $('a[data-class="shanchu"]').click(function() { iPage.shanChu(this); });

            $("#td_caozuolan_yhlx_" + "<%=(int)YHLX %>").addClass("xtnav-on");
        });
    </script>
</asp:Content>
