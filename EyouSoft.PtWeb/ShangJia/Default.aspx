<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.ShangJia.Default" MasterPageFile="~/MP/QianTai.Master" Title="商家"%>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">  
<div class="mainbox fixed mt10">
       
       <div class="sj_leftbox">
           <asp:Literal ID="ltrGuanGao" runat="server"></asp:Literal>
           
       		<div class="basic_T mt10">
                    <div class="title"><s class="icon12"></s>按站点分布</div>
       		</div>
       
            <div class="sj_Lbox">
               <ul>
                   <asp:Literal ID="ZhanDianList" runat="server"></asp:Literal>
               </ul>
            </div>
       </div>
       
       <div class="sj_rightbox">
       
           <div class="jinqu_Rbox">


             <div class="basic_T01">
                  <h3>
                      <asp:Literal ID="ZhanDianName" runat="server"></asp:Literal><em>（<%=recordCount %>家）</em></h3>
             </div>
                            
             <div class="sj_list">
                <ul>
                    <asp:Repeater ID="RepShangJia" runat="server">
                    <ItemTemplate>
                    <li class="<%# (Container.ItemIndex+1) == recordCount || (Container.ItemIndex+1)%4==0 ?"last":""%>"><a data-class="shangjiaxx" href="/shangjia/shangjiaxx.aspx?shangjiaid=<%# Eval("ZxsId")%>&zhuanxianid=<%= zhuanxianid%>"><img src="<%# GetZxsFengMian(Eval("Logo"))%>" /><p><%# EyouSoft.Common.Utils.GetText2(Eval("MingCheng").ToString(),13,true)%></p></a></li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
      <br />
      <br />
       <div class="tishi mt10"><img src="../images/sorry.png" />&nbsp;抱歉，该站点下没有找到商家，请选择其它站点，谢谢！</div>
                <br />
                <br />
        </asp:PlaceHolder> 
                <div class="clear"></div>
             </div>
               
           </div>
           
           <div class="page" id="page">
           </div>
           
       </div>
    
    </div>
    
<uc1:TuiJian ID="TuiJian1" runat="server" />    <script type="text/javascript">
        $(document).ready(function() {
            master.setDH(6);
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);

            if (!THYH.isLogin()) {
                $("a[data-class='shangjiaxx']").attr("href", "javascript:void(0)").click(function() { alert("本内容仅对旅行社同行开放,请登陆后继续查看!"); return false; });
            }
        });
</script>
    
    <script type="text/javascript">
    var pagingConfig = { pageSize: <%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
    </script>
</asp:Content>
