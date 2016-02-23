<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JingDianXX01.aspx.cs" Inherits="EyouSoft.PtWeb.JingDian.JingDianXX01" MasterPageFile="~/MP/QianTai.Master" Title="景点" %>
<asp:Content ContentPlaceHolderID="PageWeiZhi" runat="server" ID="PageWeiZhi1">
 <div class="lineT_box">
   <div class="lineT_txt">景点 > 
       <asp:Literal ID="JingDianName" runat="server"></asp:Literal></div>
</div>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   

 <div class="mainbox fixed mt10">
       
       <div class="n_leftbox">
       
       		<div class="basic_T">
                    <div class="title"><s class="icon10"></s>热门景点</div>
       		</div>
       
            <div class="jinqu_Lbox">
               <ul>
                   <asp:Repeater ID="RepReMen" runat="server">
                   <ItemTemplate>
                   <li class="<%# (Container.ItemIndex+1) == Count ?"noborder":""%>"><a href="/jingdian/JingDianXX.aspx?jingdianid=<%# Eval("JingDianId")%>"><%# Eval("MingCheng")%></a></li>
                   </ItemTemplate>
                   </asp:Repeater>
               </ul>
            </div>
       </div>
       
       <div class="n_rightbox">
       
           <div class="jinqu_Rbox">
               
             <div class="basic_T01 fixed">
                  <h3><asp:Literal ID="JingDianTitle" runat="server"></asp:Literal></h3>
                  <a class="fanhui" href="javascript:window.history.go(-1)">返回</a>
             </div>               
               
             <div class="jinqu_cont">
                 <asp:Repeater runat="server" ID="rptTuPian">
                     <ItemTemplate>
                         <p>
                             <img src="<%# ErpUrl+ Eval("Filepath") %>" /></p>
                     </ItemTemplate>
                 </asp:Repeater>
               
                 <asp:Literal ID="JingDianJIeShao" runat="server"></asp:Literal>
               <a class="fanhui" style="margin-right:0px;" href="javascript:window.history.go(-1)">返回</a>
             </div>
               
           </div>
           
       </div>
    
    </div>
    <script type="text/javascript">
        $(document).ready(function() {

            master.setDH(4);
        });
    </script>
</asp:Content>

