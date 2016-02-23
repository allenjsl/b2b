<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.TuiJian.Default" MasterPageFile="~/MP/QianTai.Master" Title="推荐" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
   <div class="mainbox mt10">
    
         <div class="basic_T">
              <div class="title"><s class="icon05"></s>金芒果推荐</div>
         </div>
             
         <div class="cuxiao_box tuijian_box mt10">
            <ul>
            <asp:Repeater ID="rptTuiJian" runat="server">
                <ItemTemplate>
                <li class="<%# (Container.ItemIndex+1) == recordCount ?"last":""%>">
                  <a href="<%#Eval("XXUrl") %>"><img src="<%#GetTuiJianFengMian(Eval("FengMian")) %>" /></a>
                  <dl>
                     <dt><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi") %></a></dt>
                     <dd class="cont"> <%#Eval("JianYaoJieShao")%>......</dd>
                     <dd class="fixed"><span class="font_date floatL"><%#Eval("IssueTime","{0:yyyy-MM-dd}")%></span><a href="<%#Eval("XXUrl") %>" class="floatR">查看详情</a></dd>
                  </dl>
               </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
      <br />
      <br />
       <div class="tishi mt10"><img src="../images/sorry.png" />&nbsp;抱歉，暂时还未有金芒果推荐，谢谢！</div>
                <br />
                <br />
        </asp:PlaceHolder> 
         </div>
             
    </div>
    
    <div class="page" id="page">
    </div>
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
</asp:Content>
