<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuiJian.ascx.cs" Inherits="EyouSoft.PtWeb.WUC.TuiJian" %>
<div class="mainbox mt30">

         <div class="basic_T">
              <div class="title"><s class="icon05"></s>金芒果推荐</div>
              <a class="more" href="/tuijian/">更多 &gt;&gt;</a>

         </div>
         
         <div class="tuijian_list tuijian_img">
                <ul class="fixed">
                    <asp:Repeater ID="RepList" runat="server">
                    <ItemTemplate>
                    <li><a href="<%#Eval("XXUrl") %>"><img src="<%#GetTuiJianFengMian(Eval("FengMian")) %>" /></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
         </div>
         
         
    
    </div>