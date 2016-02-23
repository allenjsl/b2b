<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuXiaoXX.aspx.cs" Inherits="EyouSoft.PtWeb.CuXiao.CuXiaoXX" MasterPageFile="~/MP/QianTai.Master" Title="促销详情"%>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox mt10">
    
        <div class="chakan_box">
        
             <div class="basic_T01 fixed">
                  <h3>
                      <asp:Literal ID="CuXiaoTitle" runat="server"></asp:Literal></h3>
                  <a href="javascript:window.history.go(-1)" class="fanhui">返回</a>
             </div>
             
             <div class="chakan_cont">
                 <asp:Repeater runat="server" ID="rptTuPian">
                     <ItemTemplate>
                         <p>
                             <img src="<%# ErpUrl+ Eval("Filepath") %>" /></p>
                     </ItemTemplate>
                 </asp:Repeater>
                  <p style="text-align:center;">活动时间：
                      <asp:Literal ID="ShiJian" runat="server"></asp:Literal></p>
                 <asp:Literal ID="CuXiaoNeiRong" runat="server"></asp:Literal>
               <p><a href="javascript:window.history.go(-1)" class="fanhui">返回</a></p>
             </div>        
        </div>
             
         
             
    </div>
    
    
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
    $(document).ready(function() {
        master.setDH(2);
    });
</script>
</asp:Content>

