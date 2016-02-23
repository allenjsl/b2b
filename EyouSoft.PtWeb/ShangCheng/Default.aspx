<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.ShangCheng.Default" MasterPageFile="~/MP/QianTai.Master" Title="积分商城" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
<div class="mainbox mt10">
       <div class="jifen_tip">
            <ul>
               <li>
                  <h3>如何获取积分</h3>
                  <p class="txt">进入平台选择相应旅游目的地的专线，预订有显示积分信息的产品，预订成功， 团队已经结算完毕后即可获得相应积分。</p>
               </li>
               <li>
                  <h3>选择兑换商品</h3>
                  <p class="txt">进入平台选择"积分商城"栏目，点击进入积分礼品列表，根据可用积分，选择相应分值的积分产品进行兑换。</p>
               </li>
               <li>
                  <h3>填写兑换地址</h3>
                  <p class="txt">点击立即兑换后填写收货人相关信息：收货人姓名，联系电话、收货地址及邮编。点击提交订单，支付信息在此时会显示您的兑换单编号，所消减的积分以及商品的信息。</p>
               </li>
            </ul>
            <div class="clear"></div>
       </div>
    </div>
    
    <div class="mainbox mt10">
       <div class="line_T fixed">
        	<div class="title"><s class="icon09"></s>兑换商品展示</div>
            <div class="jifen_menu">
               <ul class="fixed">
                  <li><a href="/shangcheng/" class="<%= type==0 ?"on":""%>">全部商品</a></li>
                  <li><a href="/shangcheng/?type=1" class="<%= type==1 ?"on":""%>">数码产品</a></li>
                  <li><a href="/shangcheng/?type=2" class="<%= type==2 ?"on":""%>">生活用品</a></li>
                  <li><a href="/shangcheng/?type=3" class="<%= type==3 ?"on":""%>">家用电器</a></li>
                   <li><a href="/shangcheng/?type=4" class="<%= type==4 ?"on":""%>">食品</a></li>
               </ul>
               
               <div class="page" id="page1"></div>
               
            </div>

       </div>
    </div>
    
    <div class="jifen_list">
       <ul class="fixed">
           <asp:Repeater ID="RepJiFen" runat="server">
           <ItemTemplate>
           <li>
             <a href="shangpinxx.aspx?shangpinid=<%# Eval("ShangPinId")%>"><img src="<%# GetShangPinFengMian(Eval("FengMian"))%>" /></a>
             <dl>
                <dt><a href="shangpinxx.aspx?shangpinid=<%# Eval("ShangPinId")%>"><%# Eval("MingCheng")%></a></dt>
                <dd class="price fixed">
                    <span>所需积分：<em><%# Eval("JiFen")%></em></span>
                    <del>市场价：<%# Eval("JiaGe", "{0:f2}")%></del>
                </dd>
                <dd class="txtR"><a href="shangpinxx.aspx?shangpinid=<%# Eval("ShangPinId")%>" class="dh_btn">立即兑换 ></a></dd>
             </dl>
          </li>
           </ItemTemplate>
           </asp:Repeater>    
       </ul>
       <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
             <br /><br />
              <div class="tishi mt10"><img src="../images/sorry.png" />抱歉，该类别下暂无商品信息，请选择其它类别，谢谢！</div> 
              <br /><br />
        </asp:PlaceHolder>
    </div>
  
    

     <div class="page" id="page">
    </div>
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
    $(document).ready(function() {
        master.setDH(5);
        });
        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false,IsLong:false, cssClassName: 'page1' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page1", pagingConfig);
        });
    </script>
</asp:Content>