<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.CuXiao.Default" MasterPageFile="~/MP/QianTai.Master" Title="促销" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
   <div class="mainbox mt10">
    
         <div class="basic_T">
              <div class="title"><s class="icon02"></s>促销专区</div>
              
              <div class="page" id="page1"></div>
              
              
         </div>
             
         <div class="cuxiao_box tuijian_box mt10">
            <ul>
                <asp:Repeater ID="rptCuXiao" runat="server">
                <ItemTemplate>
                
                <li class="<%# (Container.ItemIndex+1) == recordCount ?"last":""%>">
                  <a href="<%#Eval("XXUrl") %>"><img src="<%#GetCuXiaoFengMian(Eval("FengMian")) %>" /></a>
                  <dl>
                     <dt><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi") %></a></dt>
                     <dd class="cont"> <%#Eval("JianYaoJieShao")%>......</dd>
                     <dd class="fixed"><span class="font_date floatL">活动时间：
                     <%# Convert.ToDateTime(Eval("ShiJian2")) > DateTime.Now ? Eval("ShiJian1", "{0:yyyy-MM-dd}") + "至" + Eval("ShiJian2", "{0:yyyy-MM-dd}") : "已结束"%> 
                     </span><a href="<%#Eval("XXUrl") %>" class="floatR">查看详情</a></dd>
                  </dl>
               </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
      <br />
      <br />
       <div class="tishi mt10"><img src="../images/sorry.png" />&nbsp;抱歉，暂时还未有促销信息，谢谢！</div>
                <br />
                <br />
        </asp:PlaceHolder> 
         </div>
             
    </div>
    
    <div class="page" id="page">
    </div>
    
    <uc1:TuiJian ID="TuiJian1" runat="server" />
    
    
</div><script type="text/javascript">

    $(document).ready(function() {
        master.setDH(2);
    });

        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
        var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, IsLong:false,cssClassName: 'page1' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page1", pagingConfig);
        });
    </script>
</asp:Content>
