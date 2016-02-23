<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuanYuWoMen.aspx.cs" Inherits="EyouSoft.PtWeb.GuanYu.GuanYuWoMen" MasterPageFile="~/MP/QianTai.Master" Title="关于我们" %>

<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox mt10">
    
        <div class="chakan_box">
        
             <div class="basic_T01 fixed">
                  <h3>
                      关于我们</h3>
                  <a href="javascript:window.history.go(-1)" class="fanhui">返回</a>
             </div>
             
             <div class="chakan_cont">
                 <asp:Literal ID="JieShao" runat="server"></asp:Literal>
               <p><a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
             </div>        
        </div>
             
         
             
    </div>
</asp:Content>
