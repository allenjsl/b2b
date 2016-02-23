<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuanGong.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.YuanGong"
    MasterPageFile="~/MP/HuiYuan.Master" Title="个人信息" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10">
    </div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">员工管理</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 系统配置 &gt;&gt; 员工管理
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="yg_bar mt15">
        <ul>
            <li><a href="javascript:void(0)" id="i_a_tianjia">添加员工</a></li>
        </ul>
    </div>
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <th align="center" style="width: 40px;">
                序号
            </th>
            <th align="center" style="width: 8%;">
                用户名
            </th>
            <th align="center" style="width: 8%;">
                员工姓名
            </th>
            <th align="center" style="width: 6%;">
                性别
            </th>
            <th align="center" style="width: 9%;">
                电话
            </th>
            <th align="center" style="width: 9%;">
                手机
            </th>
            <th align="center" style="width: 9%;">
                QQ
            </th>
            <th align="center" style="width: 13%;">
                邮箱
            </th>
            <th style="width: 9%;">
                微信号
            </th>
            <th style="width: 9%;">
                部门（门市部）
            </th>
            <th align="center" style="width: 9%;">
                职务
            </th>
            <th align="center">
                操作
            </th>
        </tr>
        
        <asp:Repeater runat="server" ID="rptYuanGong">
        <ItemTemplate>
        <tr data-yonghuid="<%#Eval("Id") %>" data-kehuid="<%#Eval("KeHuId") %>" data-kehulxrid="<%#Eval("KeHuLxrId") %>"
            class="table_tr_item">
            <td align="center">
                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
            </td>
            <td align="center">
                <%#Eval("UserName") %>
            </td>
            <td align="center">
                <%#Eval("PersonInfo.ContactName")%>
            </td>
            <td align="center">
                <%#Eval("PersonInfo.ContactSex")%>
            </td>
            <td align="center">
                <%#Eval("PersonInfo.ContactTel")%>
            </td>
            <td align="center" >
                <%#Eval("PersonInfo.ContactMobile")%>
            </td>
            <td align="center">
                <%#Eval("PersonInfo.QQ")%>
            </td>
            <td align="center" style="word-break: break-all; word-wrap: break-word;">
                <%#Eval("PersonInfo.ContactEmail")%>
            </td>
            <td align="center">
                <%#Eval("WeiXinHao")%>
            </td>
            <td align="center">
                <%#Eval("BuMenName")%>
            </td>
            <td align="center">
                <%#Eval("PersonInfo.JobName")%>
            </td>
            <td align="center">
                <%#GetCaoZuo(Eval("KeHuLxrStatus"))%>
            </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
            <tr>
                <td colspan="20" style="font-size: 30px; color: #666;">
                    <br />
                    <br />
                    <br />
                    抱歉，未找到任何员工信息！<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </asp:PlaceHolder>
    </table>
    
    <asp:PlaceHolder ID="phPaging" runat="server">
        <div class="page mt15">
            <cc1:exporpageinfoselect id="paging" runat="server" />
        </div>
    </asp:PlaceHolder>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            tianJia: function() {
                var _title = "添加员工";
                var _data = { txtYongHuId: 0, txtKeHuLxrId: 0 };

                top.Boxy.iframeDialog({ title: _title, iframeUrl: "yuangongedit.aspx", width: "770px", height: "500px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            xiuGai: function(obj) {
                var _title = "修改员工信息";
                var _$tr = $(obj).closest("tr");
                if ($(obj).attr("data-chakan") == "1") _title = "查看员工信息";
                var _data = { txtYongHuId: _$tr.attr("data-yonghuid"), txtKeHuLxrId: _$tr.attr("data-kehulxrid") };

                top.Boxy.iframeDialog({ title: _title, iframeUrl: "yuangongedit.aspx", width: "770px", height: "500px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            shanChu: function(obj) {
                if (!confirm("员工信息删除后不可恢复，你确定要删除吗？")) return false;
                var _$tr = $(obj).closest("tr");
                var _data = { txtKeHuId: _$tr.attr("data-kehuid"), txtYongHuId: _$tr.attr("data-yonghuid"), txtKeHuLxrId: _$tr.attr("data-kehulxrid") };
                var _self = this;

                $.ajax({ type: "post", url: "yuangong.aspx?dotype=shanchu", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") _self.reload();
                    }
                });
            }
        };

        $(document).ready(function() {
            $(".shanchu").click(function() { iPage.shanChu(this); });
            $(".xiugai").click(function() { iPage.xiuGai(this); });
            $("#i_a_tianjia").click(function() { iPage.tianJia(); });
        });
    </script>
</asp:Content>
