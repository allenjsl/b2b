<%@ Page Title="交通信息管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="TrafficManage.aspx.cs" Inherits="Web.SystemSet.TrafficManage" %>
<%@ Register Src="~/UserControl/JiChuXinXi.ascx" TagName="JiChuXinXi" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <!-- InstanceBeginEditable name="EditRegion3" -->
        <div class="mainbody">
            <div class="lineprotitlebox">
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td width="15%" nowrap="nowrap">
                                <span class="lineprotitle">系统设置</span>
                            </td>
                            <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                                &nbsp;所在位置&gt;&gt; <a href="#">系统设置</a>&gt;&gt; 基础设置
                            </td>
                        </tr>
                        <tr>
                            <td height="2" bgcolor="#000000" colspan="2">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <uc1:JiChuXinXi runat="server" ID="JiChuXinXi1" HighlightNav="-1" />
            <div class="btnbox">
                <table cellspacing="0" cellpadding="0" border="0" align="left">
                    <tbody>
                        <tr>
                            <td width="90" align="center">
                                <a id="add_bar" href="javascript:;">新 增</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tablelist">
                <table width="100%" cellspacing="1" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <th width="36" bgcolor="#BDDCF4" align="center">
                                序号
                            </th>
                            <th bgcolor="#BDDCF4" align="center">
                                交通名称
                            </th>
                            <th width="17%" bgcolor="#bddcf4" align="center">
                                操作
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rptList">
                            <ItemTemplate>
                                <tr class="<%#Container.ItemIndex%2==0 ? "even":"odd" %>" data-id='<%#Eval("TrafficId") %>'>
                                    <td align="center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td align="center">
                                       <%#Eval("TrafficName")%>
                                    </td>
                                    <td align="center">
                                        <a class="update_bar" href="javascript:;">修改 </a>|<a href="javascript:;" class="delete_bar"> 删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="lbemptymsg" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>
        </div>
        <!-- InstanceEndEditable -->
    </div>
    <div class="clearboth">
    </div>

    <script type="text/javascript">
        $(function(){
            TrafficManageList.BindBtn();
        })
        var TrafficManageList={
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            BindBtn:function(){
                $("#add_bar").click(function(){
                    TrafficManageList.ShowBoxy({ iframeUrl: "/SystemSet/TrafficAdd.aspx?dotype=add", title: "新增线路区域", width: "550px", height: "120px" });
                    return false;
                })
                 $(".update_bar").click(function(){
                    var trafficid=$(this).closest("tr").attr("data-id");
                    TrafficManageList.ShowBoxy({ iframeUrl: "/SystemSet/TrafficAdd.aspx?dotype=update&trafficid="+trafficid, title: "修改线路区域", width: "550px", height: "120px" });
                    return false;
                })
                $(".delete_bar").click(function(){
                    var trafficid=$(this).closest("tr").attr("data-id");
                    var url="/SystemSet/TrafficManage.aspx?dotype=delete&trafficid="+trafficid;
                    TrafficManageList.GoAjax(url);
                    return false;
                })
            },
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            }
        }
    </script>

</asp:Content>
