<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuiJianXX.aspx.cs" Inherits="EyouSoft.PtWeb.TuiJian.TuiJianXX" MasterPageFile="~/MP/QianTai.Master" Title="推荐详情" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox mt10">
    
        <div class="chakan_box">
        
             <div class="basic_T01 fixed">
                  <h3>
                      <asp:Literal ID="TuiJianTitle" runat="server"></asp:Literal></h3>
                  <a href="javascript:window.history.go(-1)" class="fanhui">返回</a>
             </div>
             
             <div class="chakan_cont">
                 <asp:Repeater runat="server" ID="rptTuPian">
                     <ItemTemplate>
                         <p>
                             <img src="<%# ErpUrl+ Eval("Filepath") %>" /></p>
                     </ItemTemplate>
                 </asp:Repeater>
                 <asp:Literal ID="TuiJianNeiRong" runat="server"></asp:Literal>
               <p><a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
             </div>        
        </div>
             
         
             
    </div>
    
    
    
    <uc1:TuiJian ID="TuiJian1" runat="server" />
</asp:Content>

