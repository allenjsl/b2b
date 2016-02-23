<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.Default"
    MasterPageFile="~/MP/HuiYuan.Master" Title="旅游线路" %>

<%@ Register Src="~/WUC/HuiYuanLvYouZhuanXian.ascx" TagName="HuiYuanLvYouZhuanXian"
    TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10"></div>
    <uc1:HuiYuanLvYouZhuanXian runat="server" id="HuiYuanLvYouZhuanXian1">
    </uc1:HuiYuanLvYouZhuanXian>

    <h3 class="h3_title mt15">
        <span>平台推荐</span> <a class="more" href="/tuijian/">更多</a>
    </h3>
    
    <div class="tuijian_list mt15">
        <ul>
            <asp:Repeater runat="server" ID="rptTuiJian"><ItemTemplate>
            <li><a href="<%#Eval("XXUrl") %>">
                <img src="<%#GetTuiJianFengMian(Eval("FengMian")) %>" alt="" />
                </a></li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clearboth">
        </div>
    </div>
</asp:Content>