<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XianLuXX.aspx.cs" Inherits="EyouSoft.PtWeb.XianLu.XianLuXX" MasterPageFile="~/MP/QianTai.Master" Title="旅游线路"%>

<%@ MasterType VirtualPath="~/MP/QianTai.Master" %>

<asp:Content ContentPlaceHolderID="PageWeiZhi" runat="server" ID="PageWeiZhi1">
    <div class="lineT_box">
        <div class="lineT_txt">
            旅游线路 > 线路详情</div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">   
    <div class="line_side01 mt20">
        <div class="line_biaoti">
            <h1><asp:Literal ID="Line_Title" runat="server"></asp:Literal></h1>
            <a class="fanhui" href="javascript:history.back();">返回</a>
        </div>
       
        <div class="mainbox fixed mt20">
        
            <div class="lineL">
            
                <div class="line_focus"> 
                    <span id="prev" class="btn prev"></span> 
                    <span id="next" class="btn next"></span> 
                    <span id="prevTop" class="btn prev"></span> 
                    <span id="nextTop" class="btn next"></span>
                
                    <div id="picBox" class="picBox">
                        <ul class="cf">
                            <asp:Repeater ID="RepImage" runat="server">
                            <ItemTemplate>
                            <li><img src="<%#ErpUrl+Eval("Filepath") %>" /></li>
                            </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                  
                    <div id="listBox" class="listBox">
                        <ul class="cf">
                        <asp:Repeater ID="picList" runat="server">
                            <ItemTemplate>
                            <%# Container.ItemIndex==0 ?"<li class=\"on\"><i class=\"arr2\"></i><img src=\""+ErpUrl+Eval("Filepath")+"\" /></li>":"<li><i class=\"arr2\"></i><img src=\""+ErpUrl+Eval("Filepath")+"\" /></li>"%>
                            <%--<li><img src="<%# ErpUrl+Eval("Filepath") %>" /></li>--%>
                            </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                  
                </div>            
<script src="/js/ad.js"></script>
               
               
               <div class="rili_box">
               <table width="100%" border="0">
                  <tr>
                    <th width="15" align="center"><a href="javascript:void(0)" id="rili_nianyue_qian"><img src="/images/date_pre.gif" /></a></th>
                    <th id="rili_nianyue" data-date="<%= datetime %>" data-nian="<%= nian%>" data-yue="<%= yue %>"><%= nian%>年<%= yue%>月</th>
                    <th width="15" align="center"><a href="javascript:void(0)" id="rili_nianyue_hou"><img src="/images/date_next.gif" /></a></th>
                  </tr>
                  <tr>
                    <td colspan="3">
                    <ul class="calendar_t">
                      <li>星期日</li>
                      <li>星期一</li>
                      <li>星期二</li>
                      <li>星期三</li>
                      <li>星期四</li>
                      <li>星期五</li>
                      <li>星期六</li>
                    </ul>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="3">
                    <ul class="calendar_d" id="rili_xingcheng">
                        <asp:Literal ID="RiLiDay" runat="server"></asp:Literal>
                    </ul>
                    </td>
                  </tr>
                </table>
               </div>
            
          </div>
            
            <div class="lineR">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <th>线路名称</th>
                  <td colspan="3" style="font-size:14px; font-weight:bold;">
                      <asp:Literal ID="Line_Name" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>产品编号</th>
                  <td colspan="3">
                      <asp:Literal ID="ChanPin_BIanHao" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>门市价</th>
                  <td colspan="3">成人<span class="linexx_price"><dfn>¥</dfn><asp:Literal ID="ChengRenJia"
                      runat="server"></asp:Literal></span> 起/人&nbsp;&nbsp;&nbsp;&nbsp;儿童<span class="linexx_price"><dfn>¥</dfn><asp:Literal
                          ID="ErTongJia" runat="server"></asp:Literal></span> 起/人</td>
                </tr>
                <tr>
                  <th>去程出发地</th>
                  <td>
                      <asp:Literal ID="ChuFaDi" runat="server"></asp:Literal></td>
                  <td align="right" class="bfont14">去程目的地</td>
                  <td align="left">
                      <asp:Literal ID="MuDiDi" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>去程交通</th>
                  <td colspan="3">
                      <asp:Literal ID="QuChengJiaoTong" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>天数</th>
                  <td colspan="3">
                      <asp:Literal ID="TianShu" runat="server"></asp:Literal>天</td>
                </tr>
                <tr>
                  <th>出发日期</th>
                  <td>
                      <asp:Literal ID="ChuFaRiQi" runat="server"></asp:Literal></td>
                  <td align="right" class="bfont14">回程日期</td>
                  <td>
                      <asp:Literal ID="HuiChengRiQi" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>回程出发地</th>
                  <td>
                      <asp:Literal ID="HuiChengChuFaDi" runat="server"></asp:Literal></td>
                  <td align="right" class="bfont14">回程目的地</td>
                  <td>
                      <asp:Literal ID="HuiChengMuDiDi" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>回程交通</th>
                  <td colspan="3">
                      <asp:Literal ID="HuiChengJiaoTong" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>集合时间</th>
                  <td colspan="3">
                      <asp:Literal ID="JiHeShiJian" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>集合地点</th>
                  <td colspan="3">
                      <asp:Literal ID="JiHeDiDian" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>送团信息</th>
                  <td colspan="3">
                      <asp:Literal ID="SongTuanXinXi" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>接团方式</th>
                  <td colspan="3">
                      <asp:Literal ID="JieTuanFangShi" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                  <th>&nbsp;</th>
                  <td colspan="3"><a class="yudin-btn" id="link01" href="javascript:void(0);">立即预定</a></td>
                </tr>
                <tr>
                  <th>&nbsp;</th>
                  <td colspan="3" class="padd">已有<em><asp:Literal ID="GouMaiShu" runat="server"></asp:Literal></em>人购买</td>
                </tr>
                <tr>
                  <th>&nbsp;</th>
                  <td colspan="3" class="padd"><a href="/danju/xingchengdan.aspx?xianluid=<%=EyouSoft.Common.Utils.GetQueryStringValue("xlid") %>" class="xc_btn" target="_blank">行程下载</a></td>
                </tr>
              </table>
            </div>
        
        </div>
       
    </div>
    
    <div class="line_side02">
     
            <div class="basic_T">
              <div class="title"><s class="icon06"></s>行程安排</div>
            </div>
            
            <div class="basic_box">
               <ul class="xc_list">
                   <asp:Repeater ID="XingCheng" runat="server">
                   <ItemTemplate>
                    <li>
                      <div class="day">Day <%#Eval("Days")%></div>
                      <dl>
                         <dd><%#Eval("Content")%></dd>
                      </dl>
                  </li>
                   </ItemTemplate>
                   </asp:Repeater>
               </ul>
            </div>        
                
    </div>
    
    <div class="line_side03">

            <div class="basic_T">
              <div class="title"><s class="icon07"></s>服务标准</div>
            </div>
            
            <div class="basic_box">
               <dl>
                  <dt>交通标准： </dt>
                  <dd>
                      <asp:Literal ID="JiaoTongBiaoZhun" runat="server"></asp:Literal>
</dd>
               </dl>
               
              <dl>
                  <dt>住宿标准： </dt>
                  <dd>
                      <asp:Literal ID="ZhuSuBiaoZhun" runat="server"></asp:Literal></dd>
               </dl>

               <dl>
                  <dt>餐饮标准： </dt>
                  <dd>
                      <asp:Literal ID="CanYinBiaoZhun" runat="server"></asp:Literal><br /></dd>
               </dl>

               <dl>
                 <dt>景点标准： </dt>
                 <dd>
                     <asp:Literal ID="JingDianBiaoZhun" runat="server"></asp:Literal></dd>
              </dl>

               <dl>
                 <dt>导游服务： </dt>
                 <dd>
                     <asp:Literal ID="DaoYouFuWu" runat="server"></asp:Literal> </dd>
              </dl>

               <dl>
                 <dt>购物说明： </dt>
                 <dd>
                     <asp:Literal ID="GouWuShuoMing" runat="server"></asp:Literal></dd>
              </dl>

               <dl>
                 <dt>儿童标准： </dt>
                 <dd>
                     <asp:Literal ID="ErTongBiaoZhun" runat="server"></asp:Literal></dd>
              </dl>

               <dl>
                  <dt>保险说明： </dt>
                  <dd>
                      <asp:Literal ID="BaoXianShuoMing" runat="server"></asp:Literal></dd>
               </dl>

               <dl>
                 <dt>自费推荐： </dt>
                  <dd>
                      <asp:Literal ID="ZiFeiTuiJian" runat="server"></asp:Literal></dd>
              </dl>

      </div>

    
    </div>
    
    <div class="line_side04">

            <div class="basic_T">
              <div class="title"><s class="icon08"></s>报名须知</div>
            </div>
            
            <div class="basic_box">
               <dl>
                  <dd>
                      <asp:Literal ID="BaoMingXuZhi" runat="server"></asp:Literal></dd>
               </dl>
            </div>
    
    </div>
    <script type="text/javascript">
        var PageOrder = {
        Init: function() {
            location.href = '/huiyuan/xianluyuding.aspx?xianluid=<%=EyouSoft.Common.Utils.GetQueryStringValue("xlid") %>';  
            }
        }

        $(function() {
            $("#link01").click(function() {
                var _m = THYH.getYH();
                if (_m.isLogin) {
                    PageOrder.Init();
                }
                else {
                    alert("请登录后再预定！");
                }
            });
        })
</script>
<script type="text/javascript">
    $(document).ready(function() {
        master.setDH(1);
        $("#rili_nianyue_qian").click(function() { iPage.QianRiLi(); });
        $("#rili_nianyue_hou").click(function() { iPage.HouRiLi(); });
    });

    var iPage = {
        QianRiLi: function() {
            var nian = $('#rili_nianyue').attr("data-nian"); //当前显示的年份
            var yue = $('#rili_nianyue').attr("data-yue"); //当前显示的年份
            var nianyue = $('#rili_nianyue').attr("data-date"); //当前显示的日期时间
            var url = "XianLuXX.aspx?dotype=qianrili&xlid=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("xlid") %>';
            var mydate = new Date();
            if ((nian > mydate.getFullYear()) || (nian == mydate.getFullYear() && yue > mydate.getMonth() + 1)) {
                $.ajax({
                    type: "post",
                    url: url,
                    dataType: "text",
                    data: { rilinianyue: nianyue },
                    success: function(response) {
                        $("#rili_xingcheng").html(response);
                        if (yue != 1) {
                            $('#rili_nianyue').attr("data-date", nian + "-" + (parseInt(yue) - 1) + "-" + "01");
                            $('#rili_nianyue').attr("data-yue", (parseInt(yue) - 1));
                            $('#rili_nianyue').attr("data-nian", nian);
                            $('#rili_nianyue').html(nian + "年" + (parseInt(yue) - 1) + "月");
                        }
                        else {
                            $('#rili_nianyue').attr("data-date", (parseInt(nian) - 1) + "-12-" + "01");
                            $('#rili_nianyue').attr("data-yue", "12");
                            $('#rili_nianyue').attr("data-nian", (parseInt(nian) - 1));
                            $('#rili_nianyue').html((parseInt(nian) - 1) + "年12月");
                        }
                    }
                });
            }
        },
        HouRiLi: function() {
            var nian = $('#rili_nianyue').attr("data-nian"); //当前显示的年份
            var yue = $('#rili_nianyue').attr("data-yue"); //当前显示的年份
            var nianyue = $('#rili_nianyue').attr("data-date"); //当前显示的日期时间
            var url = "XianLuXX.aspx?dotype=hourili&xlid=" + '<%=EyouSoft.Common.Utils.GetQueryStringValue("xlid") %>';
            var mydate = new Date();
            $.ajax({
                type: "post",
                url: url,
                dataType: "text",
                data: { rilinianyue: nianyue },
                success: function(response) {
                    $("#rili_xingcheng").html(response);
                    if (yue != 12) {
                        $('#rili_nianyue').attr("data-date", nian + "-" + (parseInt(yue) + 1) + "-" + "01");
                        $('#rili_nianyue').attr("data-yue", (parseInt(yue) + 1));
                        $('#rili_nianyue').attr("data-nian", nian);
                        $('#rili_nianyue').html(nian + "年" + (parseInt(yue) + 1) + "月");
                    }
                    else {
                        $('#rili_nianyue').attr("data-date", (parseInt(nian) + 1) + "-01-" + "01");
                        $('#rili_nianyue').attr("data-yue", "01");
                        $('#rili_nianyue').attr("data-nian", (parseInt(nian) + 1));
                        $('#rili_nianyue').html((parseInt(nian) + 1) + "年1月");
                    }
                }
            });

        }
    };</script>
</asp:Content>
