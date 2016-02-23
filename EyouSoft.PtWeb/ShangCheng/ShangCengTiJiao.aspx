<%@ Page Title="" Language="C#" MasterPageFile="~/MP/QianTaiBoxy.Master" AutoEventWireup="true" CodeBehind="ShangCengTiJiao.aspx.cs" Inherits="EyouSoft.PtWeb.ShangCheng.ShangCengTiJiao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">

    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageMain" runat="server">
<form id="form1">
<div class="reg_form jf_form">
  <ul>
                 <li>可用积分：<asp:Literal ID="KeYongJiFen" runat="server"></asp:Literal></li>
                 <li>所需积分：<asp:Literal ID="SuoXuJIFen" runat="server"></asp:Literal></li>
                 <li><span class="name">兑换数量：</span><select id="DuiHuanNum" name="DuiHuanNum">
                   <%= ShuLiang%>
                   </select>
                   </li>
                 <li><span class="name">收货人姓名：</span><input type="text" id="ShouHuoRen" name="ShouHuoRen" class="input_bk formsize225" valid="required" errmsg="请填写收货人姓名!" /> <span class="fontred" >*</span></li>
                 <li><span class="name">省/市/区：</span> 
                 <select id="ddprovince" name="ddprovince" valid="required" errmsg="请选择省份!"></select>
                 <select id="ddlcity" name="ddlcity" valid="required" errmsg="请选择市区!"></select>
                 </li>
                 <li><span class="name">详细地址：</span><input type="text" id="XiangXiDiZhi" name="XiangXiDiZhi" class="input_bk formsize225" valid="required" errmsg="请填写详细地址!"  /> <span class="fontred" >*</span></li>
                 <li><span class="name">邮政编码：</span><input type="text" id="YouBian" name="YouBian" class="input_bk formsize225" /> <span class="fontred"  valid="required|isZip" errmsg="请填写邮政编码!|邮政编码格式有误！" >*</span></li>
                 <li><span class="name">手机号码：</span><input type="text" id="UserMobile" name="UserMobile" class="input_bk formsize225"  valid="required|isMobile" errmsg="请填写手机号码!|手机号码格式有误！"/> <span class="fontred" >*</span></li>
                 <li><span class="name">固定电话：</span><input type="text" id="UserTel" name="UserTel" class="input_bk formsize225" valid="isTel" errmsg="固定电话格式有误！"/></li>
                 <li><span class="name">邮箱：</span><input type="text" id="UserEmail" name="UserEmail" class="input_bk formsize225"  valid="isEmail" errmsg="邮箱格式有误！"/></li>
                 <li><span class="name">备注：</span>
                   <textarea class="input_bk" id="Beizhu" name="BeiZhu" style="width:420px; height:100px;"></textarea> 
                 </li>
             </ul>
    <input id="productid" name="productid" type="hidden" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("shangpinid")%>" />
             <div class="reg_btn pb10"><input type="button" id="tijiao" value="提交" /></div>
             
          </div>          </form><script type="text/javascript">
    var pageData = {
        CheckForm: function() {
            return ValiDatorForm.validator($("#tijiao").closest("form").get(0), "alert");
        },
        pageSave: function() {
            $.ajax({
                type: "post",
                url: "ShangCengTiJiao.aspx?save=save",
                dataType: "json",
                data: $("#tijiao").closest("form").serialize(),
                success: function(ret) {
                    if (ret.result == "1") {
                        alert(ret.msg);
                        window.parent.location.href = '/huiyuan/jifendingdan.aspx';
                    }
                    else {
                        alert(ret.msg);
                        window.parent.location.href = '/shangcheng/';
                    }

                },
                error: function() {
                    window.location.href = window.location.href;
                }
            });
        },
        initDDL: function() {
            pcToobar.init({
                pID: "#ddprovince",
                cID: "#ddlcity",
                pSelect: "<%= pSelect%>",
                cSelect: "<%= cSelect%>",
                comID: '1'
            });
        } //保存数据
    }
        $(function() {
        pageData.initDDL();
        $("#tijiao").click(function() {
                if (pageData.CheckForm()) {pageData.pageSave(); }
        })
        })
    </script>
</asp:Content>
