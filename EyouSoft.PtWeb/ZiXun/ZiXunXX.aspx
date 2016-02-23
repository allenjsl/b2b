<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZiXunXX.aspx.cs" Inherits="EyouSoft.PtWeb.ZiXun.ZiXunXX" MasterPageFile="~/MP/QianTai.Master" Title="旅游资讯"%>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox fixed mt10">
       
       <div class="n_leftbox">
       
       		<div class="basic_T">
                    <div class="title"><s class="icon11"></s>热门旅游资讯</div>
                    <a href="/zixun/" class="more">更多</a>
       		</div>
            
            <div class="jinqu_Lbox new_Lbox">
               <ul>
                   <asp:Repeater ID="RepZiXunList" runat="server">
                   <ItemTemplate>
                   <li><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi")%></a><span class="date"><%#Eval("IssueTime","{0:yyyy-MM-dd}") %></span></li>
                   </ItemTemplate>
                   </asp:Repeater>
               </ul>
            </div>
       </div>
       
       <div class="n_rightbox">
       
           <div class="jinqu_Rbox">
               
             <div class="basic_T01 fixed">
                  <h3>
                      <asp:Literal ID="ZiXunTitle" runat="server"></asp:Literal></h3>
                  <a class="fanhui" href="javascript:window.history.go(-1)">返回</a>
             </div>               
               
               
             <div class="jinqu_cont">
                  <asp:Repeater runat="server" ID="rptTuPian"><ItemTemplate>
                  <p><img src="<%# ErpUrl+ Eval("Filepath") %>" /></p>
                  </ItemTemplate></asp:Repeater>
                  
                  <p style="text-align:center;">发布时间：<asp:Literal ID="ShiJian" runat="server"></asp:Literal></p>
                 
                 <asp:Literal ID="ZiXunNeiRong" runat="server"></asp:Literal>
               <p><a class="fanhui" href="javascript:window.history.go(-1)" style="margin-right:0px;">返回</a></p>
             </div>
               
           </div>
           
       </div>
    
    </div>
    <script type="text/javascript">
        $(document).ready(function() {
            master.setDH(7);
        });
    </script>
</asp:Content>
