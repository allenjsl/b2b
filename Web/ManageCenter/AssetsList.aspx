<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true" CodeBehind="AssetsList.aspx.cs" Inherits="Web.ManageCenter.AssetsManage" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %><%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="mainbody">
                <div class="lineprotitlebox">
                   <table width="100%" cellspacing="0" cellpadding="0" border="0">
                      <tbody><tr>
                        <td width="15%" nowrap="nowrap"><span class="lineprotitle">行政中心</span></td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding:0 10px 2px 0; color:#13509f;"><b>当前所在位置：</b>&gt;&gt;行政中心&gt;&gt;固定资产管理</td>
                      </tr>
                      <tr>
                        <td height="2" bgcolor="#000000" colspan="2"></td>
                      </tr>
                  </tbody></table>  
                </div>
				<div class="hr_10"></div>
				<form>
                <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
          <tbody><tr>
            <td width="10" valign="top"><img src="../images/yuanleft.gif"></td>
            <td height="50"><div class="searchbox">
			编号： <input type="text" size="5" id="txtAssetNo" class="inputtext formsize80" name="txtAssetNo" value="<%=Request.QueryString["txtAssetNo"] %>"/>
			资产名称：<input type="text" size="7" id="txtAssetName" class="inputtext formsize80" name="txtAssetName"value="<%=Request.QueryString["txtAssetName"] %>">
			购买时间：<input type="text" size="9" id="txtBuyDateF" class="inputtext formsize100" name="txtBuyDateF"value="<%=Request.QueryString["txtBuyDateF"] %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtBuyDateF\')}'})"/>-<input
                                type="text" size="9" id="txtBuyDateE" class="inputtext formsize100" name="txtBuyDateE"value="<%=Request.QueryString["txtBuyDateE"] %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'#F{$dp.$D(\'txtBuyDateE\')}'})" />
                <button type="submit" id="btnSubmit" class="search-btn" style="vertical-align: top;"></button>
              </div></td>
            <td width="10" valign="top"><img src="../images/yuanright.gif"></td>
          </tr>
        </tbody></table>
        </form>
              <div class="btnbox">
          <table cellspacing="0" cellpadding="0" border="0" align="left">
            <tbody><tr>
              <td width="90" align="center"><a id="link1" href="#" style='visibility:<%=IsAddGrant?"visible":"hidden" %>'>新增</a></td>
            </tr>
          </tbody></table>
        </div>
           	  <div class="tablelist">
            	<table width="100%" cellspacing="1" cellpadding="0" border="0">
                  <tbody><tr>
                    <th width="36" bgcolor="#BDDCF4" align="center">序号</th>
                    <th width="9%" bgcolor="#bddcf4" align="center"><strong>编号</strong></th>
                    <th bgcolor="#bddcf4" align="center"><strong>资产名称</strong></th>
                    <th width="10%" bgcolor="#bddcf4" align="center"><strong>购买时间</strong></th>
                    <th width="13%" bgcolor="#bddcf4" align="center"><strong>折旧费</strong></th>
                    <th width="13%" bgcolor="#bddcf4" align="center"><strong>备注</strong></th>
                    <th width="9%" bgcolor="#bddcf4" align="center"><strong>操作</strong></th>
                  </tr>
                  <asp:Repeater ID="RepList" runat="server">
                    <ItemTemplate>
                          <tr class='<%#Container.ItemIndex%2==0?"even":"odd" %>'>
                            <td align="center"> <%#Container.ItemIndex + 1+(this.pageIndex-1)*this.pageSize%></td>
                            <td align="center"><%#Eval("AssetNo")%></td>
                            <td align="center"><%#Eval("AssetName")%></td>
                            <td align="center"><%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("BuyDate"),ProviderToDate)%></td>
                            <td align="center"><%#EyouSoft.Common.UtilsCommons.GetMoneyString(Eval("Cost"), ProviderToMoney)%></td>
                            <td align="center"><%#Eval("Remark")%></td>
                            <td align="center"><a data-class="a_Upd" href="javascript:void;" data-id="<%#Eval("Id") %>">修改</a>|<a href="#" data-class="a_Del" data-id="<%#Eval("Id") %>">删除</a></td>
                          </tr>
                  </ItemTemplate>
                </asp:Repeater>
              </tbody></table>
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right">
                             <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
           	  </div>

			</div>
			
			<script type="text/javascript">
			    var AssetsList = {
			        DataBoxy: function() {
			            return {
			                url: "/ManageCenter",
			                title: "",
			                width: "600px",
			                height: "350px"
			            };
			        },
			        ShowBoxy: function(data) { /*显示弹窗*/
			            Boxy.iframeDialog({
			                iframeUrl: data.url,
			                title: data.title,
			                modal: true,
			                width: data.width,
			                height: data.height
			            });
			        },
			        GoAjax: function(url) {
			            $.newAjax({
			                type: "post",
			                cache: false,
			                url: url,
			                dataType: "json",
			                success: function(result) {
			                    if (result.result == "1") {
			                        tableToolbar._showMsg(result.msg, function() {
			                            $("#btnSubmit").click();
			                        });

			                    }
			                    else { tableToolbar._showMsg(result.msg); }
			                },
			                error: function() {
			                    tableToolbar._showMsg(tableToolbar.errorMsg);
			                }
			            });
			        },
			        Add: function() {
			            var data = this.DataBoxy();
			            data.url += '/AssetsAdd.aspx?';
			            data.title = '添加固定资产';
			            data.url += $.param({
			                doType: "add"
			            });
			            this.ShowBoxy(data);
			        },
			        Update: function(o) {
			            var data = this.DataBoxy();
			            data.url += '/AssetsAdd.aspx?';
			            data.title = '修改固定资产';
			            data.url += $.param({
			                doType: "update",
			                id: $(o).attr("data-id")
			            });
			            this.ShowBoxy(data);
			        },
			        Delete: function(o) {
			            var data = this.DataBoxy();
			            data.url += "/AssetsList.aspx?";
			            data.url += $.param({
			                doType: "delete",
			                id: $(o).attr("data-id")
			            });
			            this.GoAjax(data.url);
			        },
			        BindBtn: function() {
			            $("#link1").click(function() {
			                AssetsList.Add();
			                return false;
			            });
			            $("a[data-class='a_Upd']").click(function() {
			                AssetsList.Update(this);
			                return false;
			            });
			            $("a[data-class='a_Del']").click(function() {
			                AssetsList.Delete(this);
			                return false;
			            });
			        },
			        PageInit: function() {
			            //绑定功能按钮
			            this.BindBtn();
			            //当列表页面出现横向滚动条时使用以下方法 $("需要滚动最外层选择器").moveScroll();
			            //$('.tablelist-box').moveScroll();
			        } 
			    };

			    $(document).ready(function() {
			        AssetsList.PageInit();
			    });
    </script>
</asp:Content>
