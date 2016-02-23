<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuiKuanDan.aspx.cs" Inherits="Web.Fin.CuiKuanDan" MasterPageFile="~/MasterPage/Front.Master" Title="催款单生成-财务管理"%>
<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 催款单生成
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
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox" style="height:100px; line-height:25px;">
                    客户单位：<uc1:KeHuXuanZe runat="server" ID="txtKeHu" DuiFangCaoZuoRenClientId="txtDuiFangCaoZuoRen" /><br />
                    对方操作人：<select class="inputselect" id="txtDuiFangCaoZuoRen"><option value="">请选择客户单位</option></select><br />
                    出团日期：<input type="text" class="inputtext" style="width:80px;" onfocus="WdatePicker()" id="txtQuDate1" />-<input id="txtQuDate2" type="text" class="inputtext"  style="width:80px;" onfocus="WdatePicker()" /><br />
                    <input type="button" value="生成催款单" id="btn_shengcheng" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    
    <div class="btnbox"></div>

    <div style="margin-top:10px; display:none;" id="i_div_xiaoxi">
    客户单位：<span id="i_span_kehuname"></span>&nbsp;&nbsp;对方操作人：<span id="i_span_kehulxrname"></span>&nbsp;&nbsp;出团日期：<span id="i_span_qudate"></span><br />
    <a id="i_a_cuikuandan" target="_blank">生成的催款单已在新窗口打开，如果弹出窗口被阻止，您可以点击这里重新打开</a>
    </div>

    <script type="text/javascript">
        var iPage = {
            shengCheng: function() {
                $("#i_div_xiaoxi").hide();
                var _data = {};
                _data["keHuId"] = $("#<%=txtKeHu.KeHuIdClientId %>").val();
                _data["duiFangCaoZuoRenId"] = $("#txtDuiFangCaoZuoRen").val()
                _data["quDate1"] = $("#txtQuDate1").val();
                _data["quDate2"] = $("#txtQuDate2").val();

                if (_data.keHuId.length < 1) { alert("请选择客户单位"); return false; }
                //if (_data.duiFangCaoZuoRenId.length < 1) { alert("请选择对方操作人"); return false; }
                if (_data.quDate1.length < 1) { alert("请选择出团开始时间"); return false; }
                if (_data.quDate2.length < 1) { alert("请选择出团截止时间"); return false; }

                $("#i_span_kehuname").html($("#<%=txtKeHu.KeHuMingChengClientId %>").val());
                $("#i_span_kehulxrname").html($("#txtDuiFangCaoZuoRen").find("option:selected").text());
                $("#i_span_qudate").html(_data.quDate1 + "至" + _data.quDate2);
                
                var _url="cuikuandanxx.aspx?" + $.param(_data);

                $("#i_a_cuikuandan").attr("href", _url);

                //$("#i_div_xiaoxi").show();

                window.open(_url);
                return false;
            }
        };


        $(document).ready(function() {
            $("#btn_shengcheng").click(function() {return iPage.shengCheng(this); });
        });
    
    </script>
</asp:Content>
