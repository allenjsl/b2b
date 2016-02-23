<%@ Page Title="城市管理" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="CityManage.aspx.cs" Inherits="Web.SystemSet.CityManage" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/JiChuXinXi.ascx" TagName="JiChuXinXi" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
                            所在位置&gt;&gt; <a href="#">系统设置</a>&gt;&gt; 基础设置
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <uc1:JiChuXinXi runat="server" ID="JiChuXinXi1" HighlightNav="-3" />
        <div class="btnbox-xt">
            <table cellspacing="0" cellpadding="0" border="0" align="left" style="margin-left: 8px;">
                <tbody>
                    <tr>
                        <td width="91">
                            <a href="javascript:;" onClick="return CityManage.openDialog('ProvinceAdd.aspx','添加省份');">添加省份</a>
                        </td>
                        <td width="91">
                            <a href="javascript:;" onClick="return CityManage.openDialog('CityAdd.aspx','添加省份');">添加城市</a>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="left" colspan="3">
                            <font color="#FF0000"><strong>注：点击地区名称可进行修改</strong></font>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="99%" cellspacing="1" cellpadding="0" border="0" align="left">
            <tbody>
                <tr>
                    <td width="36" height="30" bgcolor="#BDDCF4" align="center">
                        <strong>编号</strong>
                    </td>
                    <td bgcolor="#BDDCF4" align="center">
                        <strong>省份名称</strong>
                    </td>
                    <td width="30%" bgcolor="#BDDCF4" align="center">
                        <strong>城市名称</strong>
                    </td>
                    <td width="20%" bgcolor="#BDDCF4" align="center">
                        <strong>操作</strong>
                    </td>
                </tr>
                <%=proAndCityHtml%>
                <tr>
                    <td valign="middle" height="30" bgcolor="#FFFFFF" align="center" class="pageup" colspan="4">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

   <script type="text/javascript">
       var CityManage =
    {
        //打开弹窗
        openDialog: function(p_url, p_title, p_height) {
            Boxy.iframeDialog({ title: p_title, iframeUrl: p_url, width: "550px", height: p_height });
        },
        updateCity: function(cId) {
            CityManage.openDialog("/SystemSet/CityAdd.aspx?cId=" + cId, "修改城市", "150px");
            return false;
        },
        updatePro: function(pId) {
            CityManage.openDialog("/SystemSet/ProvinceAdd.aspx?proId=" + pId, "修改省份", "120px");
            return false;
        },
        //删除城市
        delCity: function(cityId, tar) {
            tableToolbar.ShowConfirmMsg("你是否确认要删除该城市？", function() {
                CityManage.doAjax("delCity", cityId);
            });

        },
        //删除省份
        delPro: function(proId, tar) {
            tableToolbar.ShowConfirmMsg("删除省份将会删除该省份下的所有城市，是否确认删除？", function() {
                CityManage.doAjax("delPro", proId);
            });

        },
        //统一Ajax调用
        doAjax: function(doType, cid, tarp) {
            $.newAjax(
              {
                  url: "/SystemSet/CityManage.aspx",
                  data: { method: doType, id: cid },
                  dataType: "json",
                  cache: false,
                  type: "get",
                  success: function(result) {
                      if (result.success == '1') {
                          if (doType == "True" || doType == "False") {
                              if (doType == "False") { tarp.attr("isFav", "True"); tableToolbar._showMsg("已取消常用城市！"); }
                              else { tarp.attr("isFav", "False"); tableToolbar._showMsg("已设置为常用城市！"); }
                          }
                          else {
                              if (doType == "delCity" || doType == "delPro") {
                                  tableToolbar._showMsg("删除成功！", function() { window.location = "CityManage.aspx"; });
                              }
                          }
                      }
                      else {
                          tableToolbar._showMsg(result.message);
                      }
                  }
              });
        },
        reload: function() {
            window.location.href = window.location.href;
        },
        sheZhiLeiXing: function(obj) {
            var _self = this;
            var _$obj = $(obj);
            var _fs = _$obj.attr("data-fs");
            var _chengShiId = _$obj.attr("data-chengshiid");

            var _confirmMessage = "你确定要显示该城市吗？";
            if (_fs == "yincang") _confirmMessage = "隐藏后将不会在常用城市中体现，你确定要隐藏该城市吗？";

            if (!confirm(_confirmMessage)) return false;
            var _data = { txtChengShiId: _chengShiId, txtFS: _fs };
            $.newAjax({ type: "POST", url: "citymanage.aspx?doType=shezhileixing", data: _data,
                cache: false, dataType: "json", async: false,
                success: function(response) {
                    alert(response.msg);
                    _self.reload();
                },
                error: function() { }
            });
        }
    }

    $(document).ready(function() {
        $(".shezhileixing").click(function() { CityManage.sheZhiLeiXing(this); });
    });
   </script>
</asp:Content>
