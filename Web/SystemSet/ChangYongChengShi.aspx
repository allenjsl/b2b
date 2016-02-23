<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangYongChengShi.aspx.cs"
    Inherits="Web.SystemSet.ChangYongChengShi" MasterPageFile="~/MasterPage/Front.Master"
    Title="常用城市-系统设置" %>
    
<%@ Register Src="~/UserControl/JiChuXinXi.ascx" TagName="JiChuXinXi" TagPrefix="uc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <style type="text/css">
    .chengshi_ul{ list-style-type:none;margin:0;padding:0;width:100%;}
    .chengshi_ul li{ list-style-type:none;margin:0;padding:0; float:left;width:20%; height:28px; line-height:28px;}
    .chengshi_ul li .chengshi_chk{ vertical-align:middle;}
    </style>

    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">系统设置</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 系统设置 >> 基础设置 >> 常用城市
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <uc1:jichuxinxi runat="server" id="JiChuXinXi1" highlightnav="11" />
    <!--<form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>-->
    <div class="btnbox">
        
    </div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">序号 </th>
                <th style="width:100px; text-align:center;">省份</th>
                <th style="text-align:left;">城市</th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
            <ItemTemplate>
            <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>">
                <td style="height: 30px; text-align:center;"><%#Container.ItemIndex+1 %></td>
                <td style="text-align:center;"><%#Eval("ShengFenName") %></td>
                <td style="text-align:left;"><%#GetChengShi(Eval("ChengShis")) %></td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            sheZhiChangYongChengShi: function(obj) {
                var _data = { txtChengShiId: $(obj).attr("data-chengshiid") };

                $.newAjax({ type: "POST", url: "changyongchengshi.aspx?doType=shezhichangyongchengshi", data: _data,
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        iPage.reload();
                    },
                    error: function() {
                    }
                });
            },
            initChangYongChengShi: function() {
                if (typeof changYongChengShis == "undefined") return;
                if (changYongChengShis == null || changYongChengShis.length == 0) return;

                for (var i = 0; i < changYongChengShis.length; i++) {
                    $("#chk_chengshi_" + changYongChengShis[i].ChengShiId).attr("checked", true);
                }
            }
        };

        $(document).ready(function() {
            $("input[name='chk_chengshi']").click(function() { iPage.sheZhiChangYongChengShi(this); });
            iPage.initChangYongChengShi();
        });
    </script>
    <form id="form1" runat="server"></form>
</asp:Content>
