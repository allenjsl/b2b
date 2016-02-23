<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShengMing.aspx.cs" Inherits="EyouSoft.PtWeb.GuanYu.ShengMing"  MasterPageFile="~/MP/QianTai.Master" Title="免责声明" %>

<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox mt10">
    
        <div class="chakan_box">
        
             <div class="basic_T01 fixed">
                  <h3>
                      免责声明</h3>
                  <a href="javascript:window.history.go(-1)" class="fanhui">返回</a>
             </div>
             
             <div class="chakan_cont">
                 <asp:Literal ID="mianzeSM" runat="server"></asp:Literal>
               <p><a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
             </div>        
        </div>
             
         
             
    </div>
</asp:Content>