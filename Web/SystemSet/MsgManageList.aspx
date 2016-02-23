<%@ Page Title="信息管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="MsgManageList.aspx.cs" Inherits="Web.SystemSet.MsgManage" %>

<%@ Register Assembly="ControlLibrary" Namespace="ControlLibrary" TagPrefix="cc2" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">系统设置</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;
                        text-align: right;">
                        所在位置：系统设置>> 信息管理
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="2" bgcolor="#000000">
                    </td>
                </tr>
            </table>
        </div>
        <div class="lineCategorybox" style="height: 30px;">
        </div>
        <div class="btnbox">
            <table border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="90" align="center">
                        <a href="/SystemSet/MsgAdd.aspx">新 增</a>
                    </td>
                </tr>
            </table>
        </div>
        <form runat="server" id="form1">
        <div class="tablelist">
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr class="odd">
                    <th width="8%">
                        编号
                    </th>
                    <th width="39%">
                        标题
                    </th>
                    <th width="9%">
                        浏览数
                    </th>
                    <th width="9%">
                        发布人
                    </th>
                    <th width="17%">
                        发布时间
                    </th>
                    <th width="10%">
                        操作
                    </th>
                </tr>
                <cc2:CustomRepeater ID="rptInfo" runat="server">
                    <ItemTemplate>
                        <tr class="even">
                            <td class="pandl3">
                                <%# itemIndex++%>
                            </td>
                            <td class="pandl3">
                                <%# Eval("Title")%>
                            </td>
                            <td class="pandl3">
                                <%# Eval("Clicks")%>
                            </td>
                            <td class="pandl3">
                                <%# Eval("OperatorName")%>
                            </td>
                            <td class="pandl3">
                                <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                            </td>
                            <td class="pandl3">
                                <a href="MsgAdd.aspx?infoId=<%# Eval("Id") %>">修改 </a>|<a href="javascript:;" onclick="return InfoList.del('<%# Eval("Id") %>')">
                                    删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="odd">
                            <td class="pandl3">
                                <%# itemIndex++%>
                            </td>
                            <td class="pandl3">
                                <%# Eval("Title")%>
                            </td>
                            <td class="pandl3">
                                <%# Eval("Clicks")%>
                            </td>
                            <td class="pandl3">
                                <%# Eval("OperatorName")%>
                            </td>
                            <td class="pandl3">
                                <%# Convert.ToDateTime(Eval("IssueTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                            </td>
                            <td class="pandl3">
                                <a href="MsgAdd.aspx?infoId=<%# Eval("Id") %>">修改 </a>|<a href="javascript:;" onclick="return InfoList.del('<%# Eval("Id") %>')">
                                    删除</a>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </cc2:CustomRepeater>
                <tr>
                    <td height="30" colspan="7" style="text-align: right" class="pageup">
                        <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>

    <script type="text/javascript">
        var InfoList =
			  {

			      //删除信息
			      del: function(cid) {
			          if (cid == "") {
			              var cidArr = [];
			              var chkAllObj = $("#chkAll");
			              $(".c1:checked").each(function() {
			                  cidArr.push($(this).val());
			              });

			              if (cidArr.length < 1) {
			                  alert("请选择要删除的信息！");
			                  return false;
			              }
			              else {
			                  if (!confirm("你确定要删除所选信息？"))
			                      return false;
			                  cid = cidArr.toString();
			              }
			          }
			          else {
			              if (!confirm("你确定要删除该信息吗？"))
			                  return false;
			          }

			          window.location = "/systemset/MsgManageList.aspx?method=del&ids=" + cid


			      },
			      selAll: function(tar) {
			          $(":checkbox").attr("checked", $(tar).attr("checked"));
			      }
			  }
			  
    </script>

</asp:Content>
