<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.JiuDian.Default" MasterPageFile="~/MP/QianTai.Master" Title="酒店"%>
<%@ Register Src="~/WUC/TuiJian.ascx" TagName="TuiJian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageHead" runat="server" ID="PageHead1">
    <script src="/js/ajaxpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
  <div class="search_box mt10">
  <form id="form1">
      目的地：<span class="h_fm">             <input type="text" id="MuDiDi" name="MuDiDi" class="s_input formsize140" value="目的地" onfocus="javascript:if(this.value=='目的地')this.value='';" onblur="javascript:if(this.value=='')this.value='目的地';" />
             <div class="h_sub" style="display:none">

             </div>             </span>
  <input id="ChengShiId" name="ChengShiId" type="hidden" />
      <input type="text" id="searchkey" name="searchkey" class="s_input" style="width:550px;"/>
      <input type="submit" id="search-btn" class="s_btn" value="确定" />
      </form>
    </div>
    <div class="mainbox mt10 fixed">

        <div class="n_leftbox">
            
             <div class="h_leftimg">
                 <asp:Literal ID="GuangGao" runat="server"></asp:Literal></div>
            
             <div class="R_news mt10">
             
                 <div class="basic_T">
                        <div class="title"><s class="icon03"></s>旅游资讯</div>
                        <a href="/zixun/" class="more"> 更多</a> 
                 </div>
                 
                 <div class="news_list h_news">
                    <ul>
                        <asp:Repeater ID="RepZiXun" runat="server">
                        <ItemTemplate>
                        <li><a href="<%#Eval("XXUrl") %>"><%# EyouSoft.Common.Utils.GetText2(Eval("BiaoTi").ToString(),15,true)%></a><span><%#Eval("IssueTime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                 </div>
    
             </div> 
        
        </div>
        
        <div class="n_rightbox">
           
           <div class="h_title">热门酒店推荐</div>
        
           <div class="hotel_Rbox">
               <asp:Repeater ID="RepHotelList" runat="server">
               <ItemTemplate>
               <div class="hotel_list fixed">
                    <div class="h_pic"><a href="/jiudian/JiuDianXX.aspx?jiudianid=<%# Eval("JiuDianId")%>"><img src="<%# GetJiuDianFengMian(Eval("FengMian"))%>" /></a></div>
                    <div class="h_txt">
                        <dl>
                          <dt><a href="/jiudian/JiuDianXX.aspx?jiudianid=<%# Eval("JiuDianId")%>"><%# Eval("MingCheng")%></a><span><%# GetJiuDianXingJi(Eval("XingJi"))%></span></dt>
                          <dd style="padding-top:10px;">地址：<%# Eval("DiZhi")%>&nbsp;&nbsp;电话：<%#Eval("DianHua")%></dd>
                          <dd class="cont" style="height:40px; padding-top:5px;"><%#EyouSoft.Common.Utils.GetText(Eval("JianYaoJieShao").ToString(),55,true) %></dd>
                        </dl>
                    </div>
                    <div class="h_btn">
                            <a href="/jiudian/JiuDianXX.aspx?jiudianid=<%# Eval("JiuDianId")%>" class="h_chkan">查看详情</a>
                            <span class="diqu"><%# Eval("ShengFenName")%>-<%# Eval("ChengShiName")%></span>
                    </div>
               </div>
               </ItemTemplate>
               </asp:Repeater>
               <asp:PlaceHolder runat="server" ID="phEmpty" Visible="false">
      <br />
      <br />
       <div class="tishi mt10"><img src="../images/sorry.png" />&nbsp;抱歉，没有找到酒店信息，谢谢！</div>
                <br />
                <br />
        </asp:PlaceHolder> 
               <div class="page" id="page">
               </div>
 
           </div>
            
        </div>
         
    </div>
    
    <uc1:TuiJian ID="TuiJian1" runat="server" /><script type="text/javascript">
        var pagingConfig = { pageSize:<%= pageSize%>, pageIndex:<%=pageIndex %> , recordCount: <%=recordCount %>, showPrev: true, showNext: true, showDisplayText: false, cssClassName: 'page' };
        $(function() {
            if (pagingConfig.recordCount > 0) AjaxPageControls.replace("page", pagingConfig);
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function() {
            var serchword = '<%=EyouSoft.Common.Utils.GetQueryStringValue("searchkey") %>';
            if (serchword != "") $("#searchkey").val(serchword);
            var mudi = '<%=EyouSoft.Common.Utils.GetQueryStringValue("MuDiDi") %>';
            if (mudi != "") $("#MuDiDi").val(mudi);
            $("#ChengShiId").val('<%=EyouSoft.Common.Utils.GetQueryStringValue("ChengShiId") %>');

            $("#MuDiDi").bind("keyup", function() { pageData.InputChange(); });
            $(".cityname").bind("click", function() { alert("22"); });
            
            master.setDH(3);
        });
        
        var pageData = {
            InputChange: function() {
                var keyword = $("#MuDiDi").val();
                $.ajax({ type: "post", url: "/ashx/handler.ashx?dotype=getjiudianchengshi&keyword=" + keyword, cache: false, dataType: "json",
                    success: function(response) {
                        if (response.length == 0) {
                            $(".h_sub").html("<span style='color:red;'>  对不起，找不到" + keyword + "</span>");
                            $(".h_sub").css('display', 'block');
                            return;
                        }
                        
                        var s = [];
                        s.push('<ul>');
                        for (var i = 0; i < response.length; i++) {
                            s.push('<li data-cityid=' + response[i].ChengShiId + ' data-name=' + response[i].ChengShiName + '><a class="cityname" href="javascript:void(0)">' + response[i].ChengShiName + '</a></li>');
                        }
                        s.push('</ul>');

                        var _$tr1 = $(s.join(''));
                        _$tr1.find('a[class="cityname"]').click(function() { pageData.InToText(this); });
                        $(".h_sub").html(_$tr1);
                        $(".h_sub").css('display', 'block');
                    }
                });
            },
            InToText: function(obj) {
                var _$tr = $(obj).closest("li");

                var _cityId = _$tr.attr("data-cityid");
                var _cityname = _$tr.attr("data-name");
                $("#MuDiDi").val(_cityname);
                $("#ChengShiId").val(_cityId);
                $(".h_sub").css('display', 'none');
            }
        }
    </script>
</asp:Content>