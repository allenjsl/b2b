<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShangJiaXX.aspx.cs" Inherits="EyouSoft.PtWeb.ShangJia.ShangJiaXX" MasterPageFile="~/MP/QianTai.Master" Title="商家详情"%>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">

</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
<div class="mainbox fixed mt10">
       
       <div class="sj_leftbox">
       
       		<div class="basic_T">
                    <div class="title"><s class="icon12"></s>按站点分布</div>
       		</div>
       
            <div class="sj_Lbox">
               <ul>
                   <asp:Literal ID="ZhanDianList" runat="server"></asp:Literal>
               </ul>
            </div>
       </div>
       
       <div class="sj_rightbox">
       
           <div class="sj_xxbox">


             <div class="sj_head">
                  <a href="javascript:window.history.go(-1)" class="fanhui">返回</a>
                  <div class="L_img">
                   <img src="<%= ErpUrl+ imgurl %>" />
                  </div>
                  <p class="name bfont14">
                      <asp:Literal ID="ZhuanXianShangName" runat="server"></asp:Literal></p>
                  <p>联系人：<asp:Literal ID="ltrLxrName" runat="server"></asp:Literal> 电话：<asp:Literal ID="ltrLxrDianHua" runat="server"></asp:Literal> 手机：<asp:Literal ID="ltrLxrShouJi" runat="server"></asp:Literal> &nbsp;&nbsp;&nbsp;<strong>在线客服：</strong>
                    <asp:Literal runat="server" ID="ltrZxsXinXiQQ"></asp:Literal></p>
             </div>
                            
             <div class="sj_cont">
             
               <div class="jifen_bside">
                  <h3><span>商家简介</span></h3>
                  <div class="jifen_cont">
                      <asp:Literal ID="JieShao" runat="server"></asp:Literal>
                  </div>
               </div> 
               
               <div class="jifen_bside">
                  <h3><span>联系方式</span></h3>
                  <div class="jifen_cont">
                      <p>
                          <asp:Literal ID="LianXiFangShi" runat="server"></asp:Literal></p>
                      <a href="javascript:window.history.go(-1)" class="fanhui" style="margin-right:-10px;">返回</a>
                  </div>
               </div> 
                           
             
             </div>
               
           </div>
           
           
       </div>
    
    </div>
    
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
    $(document).ready(function() {
        master.setDH(6);
    });
</script>
</asp:Content>
