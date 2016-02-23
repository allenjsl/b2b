<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb._Default" MasterPageFile="~/MP/QianTai.Master" Title="首页" %>

<%@ Register Src="~/WUC/ChangYongGongJu.ascx" TagName="ChangYongGongJu" TagPrefix="uc1" %>
<%@ Register Src="~/WUC/LvYouZhuanXian.ascx" TagName="LvYouZhuanXian" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">    
    <uc1:LvYouZhuanXian runat="server" id="LvYouZhuanXian1"></uc1:LvYouZhuanXian>
    <div class="mainbox mt10">
        <div class="leftbox">
            <div class="line_T fixed">
                <div class="title">
                    <s class="icon02"></s>促销专区</div>
                <div class="line_menu line_menu02">
                    <a href="/cuxiao/" class="more">更多</a>
                </div>
            </div>
            <div class="cuxiao_box mt10">
                <ul>
                    <asp:Repeater runat="server" ID="rptCuXiao">
                    <ItemTemplate>
                    <li><a href="<%#Eval("XXUrl") %>">
                        <img alt="" src="<%#GetCuXiaoFengMian(Eval("FengMian")) %>" /></a>
                        <dl>
                            <dt><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi") %></a></dt>
                            <dd class="cont">
                                <%#Eval("JianYaoJieShao")%></dd>
                            <dd class="fixed">
                                <span class="font_date floatL"><%#GetCuXiaoShiJian(Eval("ShiJian1"),Eval("ShiJian2")) %></span><a href="<%#Eval("XXUrl") %>" class="floatR">查看详情</a></dd>
                        </dl>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>                    
                </ul>
            </div>
        </div>
        <div class="rightbox">
            <div class="R_news">
                <div class="basic_T">
                    <div class="title">
                        <s class="icon03"></s>旅游资讯</div>
                    <a href="/zixun/" class="more">更多</a>
                </div>
                <div class="news_list">
                    <ul>
                        <asp:Repeater runat="server" ID="rptZiXun">
                        <ItemTemplate>
                        <li><a href="<%#Eval("XXUrl") %>"><%#Eval("BiaoTi")%></a><span><%#Eval("IssueTime","{0:yyyy-MM-dd}") %></span></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="R_news mt10">
                <div class="basic_T">
                    <div class="title">
                        <s class="icon04"></s>金芒果推荐</div>
                    <a href="/tuijian/" class="more">更多</a>
                </div>
                <div class="tuijian_list">
                    <ul class="fixed">
                        <asp:Repeater runat="server" ID="rptTuiJian">
                        <ItemTemplate>
                        <li><a href="<%#Eval("XXUrl") %>"><img src="<%#GetTuiJianFengMian(Eval("FengMian")) %>" alt="" /></a></li>
                        </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="mainbox mt10">
        <uc1:ChangYongGongJu runat="server" id="ChangYongGongJu1"></uc1:ChangYongGongJu>
    </div>
    
    <script type="text/javascript">
        $(document).ready(function() {
            master.setDH(0);
        });        
    </script>
</asp:Content>