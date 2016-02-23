<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShangPinXX.aspx.cs" Inherits="EyouSoft.PtWeb.ShangCheng.ShangPinXX" MasterPageFile="~/MP/QianTai.Master" Title="积分商品详情" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
<div class="mainbox fixed mt10">
       
       <div class="n_leftbox">
       
       		<div class="basic_T">
                    <div class="title"><s class="icon02"></s>积分规则</div>
       		</div>
            
            <div class="jifen_Lbox">
               <dl>
                   <dt>如何获取积分</dt>
                   <dd>进入平台选择相应旅游目的地的专线，预订有显示积分信息的产品，预订成功， 团队已经结算完毕后即可获得相应积分。</dd>
               </dl>
               <dl>
                   <dt>选择兑换商品</dt>
                   <dd>进入平台选择"积分商城"栏目，点击进入积分礼品列表，根据可用积分，选择相应分值的积分产品进行兑换。</dd>
               </dl>
               <dl>
                   <dt>填写兑换地址</dt>
                   <dd>点击立即兑换后填写收货人相关信息：收货人姓名，联系电话、收货地址及邮编。点击提交订单，支付信息在此时会显示您的兑换单编号，所消减的积分以及商品的信息。</dd>
               </dl>
            </div>
       
       </div>
       
       <div class="n_rightbox">
       
            <div class="jifen_Rbox">
               
               <h1>
                   <asp:Literal ID="ShangPinName" runat="server"></asp:Literal></h1>
               
               <div class="jifen_side">
                  <asp:Literal runat="server" ID="ltrTuPian"></asp:Literal>
                  <p>礼品编号：<asp:Literal ID="ShangPinBianHao" runat="server"></asp:Literal></p>
                  <p>市场价格：<del><asp:Literal ID="ShiChangJia" runat="server"></asp:Literal></del></p>
                  <P>兑换积分：<strong class="fontred"><asp:Literal ID="DuiHuanJIFen" runat="server"></asp:Literal></strong></P>
                  <p>可用积分：<asp:Literal ID="KeYongJiFen" runat="server"></asp:Literal></p>
                  <asp:PlaceHolder runat="server" ID="phEmpty">
                  <p><a href="javascript:void(0);" id="link01" class="yudin-btn">立即兑换</a></p>
                  </asp:PlaceHolder>
                  <asp:PlaceHolder runat="server" ID="IsNotDui"  Visible="false">
                  <p><a href="javascript:void(0);" class="yudin-btn">积分不够</a></p>
                  </asp:PlaceHolder>
                  <asp:PlaceHolder runat="server" ID="IsNotLogin"  Visible="false">
                  <p><a href="javascript:void(0);" id="gotologin" class="yudin-btn">登录后兑换</a></p>
                  </asp:PlaceHolder>
                  <p><a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
               </div>
               
               <div class="jifen_bside">
                  <h3><span>商品详情</span></h3>
                  <div class="jifen_cont">
                      <asp:Literal ID="ShangPinXiangQing" runat="server"></asp:Literal>
                  </div>
               </div>

                <asp:PlaceHolder runat="server" ID="phPeiSongShuMing" Visible="false">
               <div class="jifen_bside">
                  <h3><span>配送说明</span></h3>
                  <div class="jifen_cont">
                      <asp:Literal ID="PeiSongShuoMing" runat="server"></asp:Literal>
                      <p><a href="javascript:window.history.go(-1)" class="fanhui" style="margin-right:0px;">返回</a></p>
                  </div>
               </div>
                </asp:PlaceHolder>
            
            </div>
                 
       </div>
           
    </div>
    
    
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
var PageOrder = {
    Init: function() {
        var url = 'ShangCengTiJiao.aspx?shangpinid=<%=EyouSoft.Common.Utils.GetQueryStringValue("shangpinid") %>';
		parent.Boxy.iframeDialog({
			iframeUrl:url,
			title:"收货人信息",
			modal:true,
			width:"660px",
			height:"550px"
		});
		return false;
    } 
}

$(function() {
    master.setDH(5);
    $("#link01").click(function() {
        var _m = THYH.getYH();
        if (_m.isLogin) {
            PageOrder.Init();
        }
        else {
            alert("请登录后再兑换！");
            $("#txt_login_u").focus();
        }
    });
    $("#gotologin").click(function() {
        $("#txt_login_u").focus();
    }); ;

    $('#newsSlider').loopedSlider({
        autoStart: 5000
    });
    $('.validate_Slider').loopedSlider({
        autoStart: 5000
    });
})

    </script>

    <script src="/js/jfspfoucs.js" type="text/javascript"></script>

</asp:Content>
