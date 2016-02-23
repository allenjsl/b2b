<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.ZiXun.Default" MasterPageFile="~/MP/QianTai.Master" Title="旅游资讯"%>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div class="mainbox mt10">
    
        <div class="basic_T">
           <div class="title"><s class="icon03"></s>旅游资讯</div>
        </div> 
        
        <div class="new_box">
            <asp:Literal ID="ZiXunOne" runat="server"></asp:Literal>
            <ul class="zixunlist">
                <asp:Repeater ID="RepZiXunList" runat="server">
                <ItemTemplate>
                <li data-num="<%# Container.ItemIndex%>" style="display:block;" class="<%# (Container.ItemIndex+1) == recordCount ?"last":""%>"><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi")%></a><span class="date"><%#Eval("IssueTime","{0:yyyy-MM-dd}") %></span></li>
                <dl  style="display:none;"><dt><a href="<%#Eval("XXUrl") %>"><img src="<%# GetZiXunFengMian(Eval("FengMian"))%>" /></a></dt>
                 <dd class="name"><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi")%></a></dd>
                 <dd class="cont"><%# Eval("JianYaoJieShao")%>... </dd>
                 <dd class="txtR"><a href="<%#Eval("XXUrl") %>">查看详情</a></dd></dl>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
                  <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
      <br />
      <br />
       <div class="tishi mt10"><img src="../images/sorry.png" />&nbsp;抱歉，暂时还未有相关资讯，谢谢！</div>
                <br />
                <br />
        </asp:PlaceHolder> 
        </div>   
    
    </div>    
    
    
  
    

    <div class="page" id="page"></div>
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
        $(document).ready(function() {
            master.setDH(7);
            $("ul[class=zixunlist]").find("li").eq(0).css('display','none');
            $("ul[class=zixunlist]").find("dl").eq(0).css('display','block');
            $("ul[class=zixunlist]").find("li").mouseover(function(obj){
            var totalnum =$("ul[class=zixunlist]").find("li").length;
            var num = $(this).attr("data-num");
            for(var i=0;i<totalnum;i++)
            {
              if(i == num)
              {
                 $("ul[class=zixunlist]").find("li").eq(i).css('display','none');
                 $("ul[class=zixunlist]").find("dl").eq(i).css('display','block');
              }
              else
              {
                 $("ul[class=zixunlist]").find("li").eq(i).css('display','block');
                 $("ul[class=zixunlist]").find("dl").eq(i).css('display','none');
              }
            }
            });
        });
        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</asp:Content>

