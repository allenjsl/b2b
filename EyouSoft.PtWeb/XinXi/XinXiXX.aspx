<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XinXiXX.aspx.cs" Inherits="EyouSoft.PtWeb.XinXi.XinXiXX"  MasterPageFile="~/MP/QianTai.Master" Title="信息详情" %>

<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox mt10">
    
        <div class="chakan_box">
        
             <div class="basic_T01 fixed">
                  <h3>
                      <asp:Literal ID="XinXiTitle" runat="server"></asp:Literal></h3>
                  <a href="javascript:window.history.go(-1)" class="fanhui">返回</a>
             </div>
             
             <div class="chakan_cont">
                 <asp:Repeater runat="server" ID="rptTuPian">
                     <ItemTemplate>
                         <p>
                             <img src="<%# ErpUrl+ Eval("Filepath") %>" /></p>
                     </ItemTemplate>
                 </asp:Repeater>
                 <asp:Literal ID="XiangXiNeiRong" runat="server"></asp:Literal>
               <p><a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
             </div>        
        </div>
             
         
             
    </div>
</asp:Content>