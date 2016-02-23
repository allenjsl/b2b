<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.JingDian.Default" MasterPageFile="~/MP/QianTai.Master" Title="景点" %>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
<div id="n4Tab2" class="mt10">
  
         <div class="line_T fixed">
                <div class="title"><s class="icon10"></s>景区景点</div>
                
                <div class="jinqu_menu">
                     <ul class="jq_TabTitle">
                         <asp:Literal ID="ltrQuYu" runat="server"></asp:Literal>
                     </ul>
                     <a href="javascript:void(0)" class="more" id="i_a_gengduozhandian"> 全部区域</a> 
                </div>
                  
         </div>
     
         <div class="jq_TabContent">
             
           <div class="jinqu_list">
                   <ul>
                       <asp:Repeater ID="RepJingDian" runat="server">
                       <ItemTemplate>
                       <li>
                       <a href="/jingdian/jingdianxx.aspx?jingdianid=<%# Eval("JingDianId")%>">
                          <img src="<%#GetJingDianFengMian(Eval("FengMian")) %>" />
                          <p><%# Eval("MingCheng")%></p>
                       </a>
                       </li>
                       </ItemTemplate>
                       </asp:Repeater>
                   </ul>
                   <div class="clear"></div>
            </div> 
            <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
             <br /><br />
              <div style="text-align:center; font-size:16px; color:#424444;">抱歉，未找到该区域景点信息，请选择其它区域，谢谢！</div> 
              <br /><br />
        </asp:PlaceHolder>
         </div>
     
  </div>
  
  
  <div class="page" id="page">
    </div> <uc1:TuiJian ID="TuiJian1" runat="server" />
 
 <div id="i_div_zd_gengduo" class="citybox" style="display:none; position:absolute;z-index:1; background:#fff">

   <div class="city_title">
       <h2>全部区域</h2>
      <a href="javascript:void(0)" class="close" id="i_a_guanbigengduo">[关闭]</a>
   </div>
   
   <div class="city_name">
       <asp:Literal ID="ltrGengDuoQuYu" runat="server"></asp:Literal>
   </div>
</div>
<script type="text/javascript">
        var pagingConfig = { pageSize: <%=pageSize %>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
<script type="text/javascript">
    var luYouZhuanXian = {
        xianShiGengDuo: function(obj) {
            var _offset = $(obj).offset();
            $("#i_div_zd_gengduo").css({ "top": _offset.top + 25 + "px", "left": _offset.left + $(obj).width() + 8 - $("#i_div_zd_gengduo").width() + "px" });
            $("#i_div_zd_gengduo").show();
        },
        guanBiGengDuo: function() {
            $("#i_div_zd_gengduo").hide();
        }
    }

    $(document).ready(function() {
        master.setDH(4);
        $("#i_a_guanbigengduo").click(function() { luYouZhuanXian.guanBiGengDuo(); });
        $("#i_a_gengduozhandian").click(function() { luYouZhuanXian.xianShiGengDuo(this); });
    });
</script>
</asp:Content>
