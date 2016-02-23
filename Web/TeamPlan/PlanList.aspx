<%@ Page Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="PlanList.aspx.cs" Inherits="Web.TeamPlan.changguiList" Title="收客计划" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td nowrap="nowrap" width="15%">
                        <span class="lineprotitle">收客计划</span>
                    </td>
                    <td align="right" nowrap="nowrap" style="padding: 0 10px 2px 0; color: #13509f;"
                        width="85%">
                        <b>当前您所在位置：</b> &gt;&gt; 收客计划 &gt;&gt; 常规业务
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#000000" colspan="2" height="2">
                    </td>
                </tr>
            </table>
        </div>
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="../images/yuanleft.gif" alt="" />
                    </td>
                    <td>
                        <div class="searchbox" style="height: 100px;">
                            <form id="form1" method="get">
                            <input type="hidden" name="txtIsChaXun" value="1" />
                            出团日期：
                            <input id="txtstartdate" class="inputtext" name="txtstartdate" size="9" type="text"
                                onfocus="WdatePicker()" value='<%=Request.QueryString["txtstartdate"] %>' />
                            -
                            <input id="txtenddate" class="inputtext" name="txtenddate" size="9" type="text" onfocus="WdatePicker()"
                                value='<%=Request.QueryString["txtenddate"] %>' />
                            控位号：
                            <input type="text" size="12" id="txtkongwei" class="searchinput inputtext" name="txtkongwei"
                                value='<%=Request.QueryString["txtkongwei"] %>' />
                            订单号：
                            <input type="text" size="12" id="txtordernum" class="searchinput inputtext" name="txtordernum"
                                value='<%=Request.QueryString["txtordernum"] %>' />
                            交易号：
                            <input type="text" size="12" id="txtjiaoyinum" class="searchinput inputtext" name="txtjiaoyinum"
                                value='<%=Request.QueryString["txtjiaoyinum"] %>' />
                            订单号或编码：
                            <input type="text" size="12" id="txtbianma" class="searchinput inputtext" name="txtbianma"
                                value='<%=Request.QueryString["txtbianma"] %>' />
                            <br>
                            单位名称：
                            <input type="text" size="12" id="txtunitname" class="searchinput inputtext" name="txtunitname"
                                value='<%=Request.QueryString["txtunitname"] %>' />
                            游客姓名：
                            <input type="text" size="12" id="txtcustomer" class="searchinput inputtext" name="txtcustomer"
                                value='<%=Request.QueryString["txtcustomer"] %>' />
                            线路区域：<select name="txtQuYu" class="inputselect" id="txtQuYu" valid="required" errmsg="请选择线路区域!">
                            <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                        </select>
                            核算状态：<select name="txtKongWeiZhuangTai" id="txtKongWeiZhuangTai" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)), "", "-1", "-请选择-")%></select>
                            去程交通：<select name="txtQuJiaoTong" class="inputselect"><%=GetQuJiaoTongOptions()%></select><br />
                            去程出发地：
                            <select name="txtQuDepProvince" id="txtQuDepProvince" class="inputselect">
                            </select>
                            <select name="txtQuDepCity" id="txtQuDepCity" class="inputselect">
                            </select>
                            去程目的地：
                            <select name="txtQuArrProvince" id="txtQuArrProvince" class="inputselect">
                            </select>
                            <select name="txtQuArrCity" id="txtQuArrCity" class="inputselect">
                            </select>
                            收客状态：<select name="txtShouKeStatus" id="txtShouKeStatus" class="inputselect">
                                <option value="">请选择</option>
                                <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiStatus)), Request.QueryString["txtShouKeStatus"])%>
                            </select>
                            平台收客状态：<select name="txtPingTaiShouKeStatus" id="txtPingTaiShouKeStatus" class="inputselect">
                                <option value="">请选择</option>
                                <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.PingTaiShouKeStatus)), Request.QueryString["txtPingTaiShouKeStatus"])%>
                            </select>
                            <br />
                            批次代码：<input type="text" class="searchinput inputtext" name="txtPiCiCode" id="txtPiCiCode" value="<%=Request.QueryString["txtPiCiCode"] %>" />
                            产品编码：<input type="text" class="searchinput inputtext" name="txtXianLuCode" id="txtXianLuCode" value="<%=Request.QueryString["txtXianLuCode"] %>" />
                            显示状态：<select name="txtXianShiStatus" id="txtXianShiStatus" class="inputselect">
                                <option value="">请选择</option>
                                <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiXianShiStatus)), "")%>
                            </select>
                            <input type="submit" class="search-btn" value="" />
                            </form>
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="../images/yuanright.gif" alt="" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a id="add_jihuaw" href="javascript:;">上传计划位</a>
                        </td>
                        <td width="90" align="center">
                            <a id="update_jihuaw" href="javascript:;">修改计划位</a>
                        </td>
                        <td width="90" align="center">
                            <a id="copy_jihuaw" href="javascript:;">复制计划位</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:;" class="toolbar_delete">删除计划位</a>
                        </td>
                        
                        <td width="90" align="center">
                            <a href="javascript:void(0)" id="i_a_shouke_tingshou" data-status="tingshou">系统停收</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:void(0)" id="i_a_shouke_zhengchang" data-status="zhengchang">系统正常收客</a>
                        </td>
                        
                        <asp:PlaceHolder runat="server" ID="phHeSuanJieShu">
                            <td width="90" align="center">
                                <a href="javascript:void(0)" id="i_a_hesuanjieshu">核算结束</a>
                            </td>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="phQuXiaoHeSuanJieShu">
                            <td width="90" align="center">
                                <a href="javascript:void(0)" id="i_a_quxiaohesuanjieshu">取消核算</a>
                            </td>
                        </asp:PlaceHolder>                        
                        <td width="90" align="center">
                            <a href="javascript:void(0)" id="i_a_pingtaishouke_tingshou" data-status="tingshou">平台停收</a>
                        </td>
                        <td width="90" align="center">
                            <a href="javascript:void(0)" id="i_a_pingtaishouke_zhengchang" data-status="zhengchang">平台正常收客</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <th width="5%" height="30" bgcolor="#BDDCF4" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3" />全选
                    </th>
                    <th bgcolor="#bddcf4" align="center">
                        控位号
                    </th>
                    <th width="10%" bgcolor="#BDDCF4" align="center">
                        出团日期
                    </th>
                    <th width="6%" bgcolor="#BDDCF4" align="center">
                        批次代码
                    </th>
                    <th width="9%" bgcolor="#bddcf4" align="center">
                        线路区域
                    </th>
                    <th width="7%" bgcolor="#bddcf4" align="center">
                        <p>交通信息</p>
                    </th>
                    <%--<th bgcolor="#bddcf4" align="center">
                        <p>去程交通</p>
                    </th>
                    <th width="8%" bgcolor="#bddcf4" align="center">
                        <p>去程出发地</p>
                    </th>
                    <th width="8%" bgcolor="#bddcf4" align="center">
                        <p>去程目的地</p>
                    </th>--%>
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>控位数量</p>
                    </th>
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>平台数量</p>
                    </th>
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>实收</p>
                    </th>
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>预留</p>
                    </th>
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>名单不全</p>
                    </th>    
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>未确认</p>
                    </th>                             
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>剩余</p>
                    </th>
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>申请</p>
                    </th>        
                    <th width="5%" bgcolor="#bddcf4" align="center">
                        <p>出票</p>
                    </th>
                    <th width="125" bgcolor="#bddcf4" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>" data-kongweiid="<%#Eval("KongWeiId") %>" data-mobanid="<%#Eval("MoBanId") %>" data-picicode="<%#Eval("PiCiCode") %>">
                            <td height="30" align="center">
                                <input type="checkbox" id="checkbox" name="checkbox" value='<%#Eval("KongWeiId") %>' data-class="chk_kongweiid">
                                <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                            </td>
                            <td align="center">
                                <%#GetKongWeiCode(Eval("KongWeiCode"),Eval("KongWeiZhuangTai"))%><%# GetShouKeStatus(Eval("KongWeiStatus"),Eval("PingTaiShouKeStatus"))%>
                            </td>
                            <td align="center">
                                <%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("QuDate"), "yyyy-MM-dd")%>&nbsp;(<%#EyouSoft.Common.Utils.ConvertWeekDayToChinese(EyouSoft.Common.Utils.GetDateTime(Convert.ToString(Eval("QuDate"))))%>)
                            </td>
                            <td align="center">
                                <%#Eval("PiCiCode") %>
                            </td>
                            <td align="center">
                                <%#Eval("AreaName")%>
                            </td>
                            <td align="center" style="word-break: break-all; word-wrap: break-word;">
                                <a href="javascript:void(0)" class="jiaotong"><%#Eval("QuJiaoTongName")%></br><%#Eval("QuBanCi")%></a>                                
                                <div style="display:none;">
                                    去程交通：<%#Eval("QuJiaoTongName")%><br />
                                    去程班次：<%#Eval("QuBanCi")%><br />
                                    去程出发地：<%#Eval("QuDepCityName")%><br />
                                    去程目的地：<%#Eval("QuArrCityName")%><br />
                                    
                                    回程交通：<%#Eval("HuiJiaoTongName")%><br />
                                    回程班次：<%#Eval("HuiBanCi")%><br />
                                    回程出发地：<%#Eval("HuiDepCityName")%><br />
                                    回程目的地：<%#Eval("HuiArrCityName")%>
                                </div>
                            </td>
                            <%--<td align="center">
                                <%#Eval("TrafficName")%>
                            </td>
                            <td align="center">
                                <%#Eval("QuDepCityName")%>
                            </td>
                            <td align="center">
                                <%#Eval("QuArrCityName")%>
                            </td>--%>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <span style="display: none;">
                                    <%#GetChuPiaoList(Convert.ToString(Eval("KongWeiId")))%></span> <a class="number"
                                        href="###" bt-xtitle="" title="">
                                        <%#Eval("ShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a href="javascript:void(0)" class="pingtaishuliang"><%#Eval("PingTaiShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a class="chakan_dingdan" data-class="shishou" href="javascript:void(0)" style="color: #e42ee2;">
                                    <%#Eval("ShiShouShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a class="chakan_dingdan" data-class="yuliu" href="javascript:void(0)" style="color: #049C92;">
                                    <%#Eval("YuLiuShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a class="chakan_dingdan" data-class="mingdanbuquan" href="javascript:void(0)" style="color: #049C92;">
                                <%#Eval("MingDanBuQuanShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a class="chakan_dingdan" data-class="weiqueren" href="javascript:void(0)" style="color: #049C92;">
                                <%#Eval("WeiQueRenShuLiang")%></a>
                            </td>                            
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a class="shouke" href="javascript:void(0)" style="color:#ff0000;">
                                    <%#Eval("ShengYuShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <a class="chakan_dingdan" data-class="shenqing" href="javascript:void(0)" style="color: green;">
                                <%#Eval("ShenQingShuLiang")%></a>
                            </td>
                            <td align="center" style="font-size: 16px; font-weight: bold;">
                                <%#Eval("ShiJiChuPiaoShuLiang") %>
                            </td>
                            <td align="center">
                                <a class="anpai_dj" routid="<%#Eval("AreaId") %>" href="javascript:void(0)">安排地接</a>
                                | <a class="anpai_pw" href="javascript:void(0)">安排票务</a><br>
                                <a target="_parent" href="javascript:void(0)" class="tour_jiesuan">团队结算</a> | <a
                                    class="chakan_dingdan" data-class="showinfo" href="javascript:void(0)">查看订单</a><br />
                                <a href="javascript:void(0)" class="caozuobeizhu">操作备注</a><%#GetXianShiStatus(Eval("XianShiStatus")) %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
                <asp:PlaceHolder runat="server" ID="phHeJi">
                <tr class="even">
                    <td colspan="8" style="text-align:right;"><b>合计：</b></td>
                    
                    <td style="text-align:center; font-size:16px;"><b><asp:Literal runat="server" ID="ltrShiShouShuLiang"></asp:Literal></b></td>
                    <td colspan="5"></td>
                    <td style="text-align: center; font-size: 16px;"><b><asp:Literal runat="server" ID="ltrShiJiChuPiaoShuLiang"></asp:Literal></b></td>
                    <td></td>
                </tr>
                </asp:PlaceHolder>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="ExporPageInfoSelect1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
        var PlanList = {
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //ajax执行文件路径,默认为本页面
            ajaxurl: "/TeamPlan/PlanList.aspx",
            GetCheckBox: function(objArr) {
                //定义数组对象
                var list = new Array();
                //遍历按钮返回数组对象
                for (var i = 0; i < objArr.length; i++) {
                    //从数组对象中找到数据所在，并保存到数组对象中
                    if (objArr[i].find("input[type='checkbox']").val() != "on") {
                        list.push(objArr[i].find("input[type='checkbox']").val());
                    }
                }
                return list.join(',');
            },
            //删除(可多行)
            DelAll: function(objArr) {
                if (objArr.length > 1) { alert("一次只能删除一个计划位"); return; }
                //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                PlanList.ajaxurl = "/TeamPlan/PlanList.aspx?dotype=delete&id=" + PlanList.GetCheckBox(objArr);
                //执行/ajax
                PlanList.GoAjax(PlanList.ajaxurl);
            },
            //Ajax请求
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            },
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height,
                    afterHide: function() { PlanList.reload(); }
                });
            },
            //安排地接
            AnPaiGround: function(kongweiId, routID) {
                PlanList.ShowBoxy({ iframeUrl: "/TeamPlan/ArrangementGround.aspx?kongweiId=" + kongweiId + "&RoutID=" + routID, title: "安排地接", width: "920px", height: "520px" });
            },
            AnPaiTicket: function(kongweiId) {
                PlanList.ShowBoxy({ iframeUrl: "/teamplan/piaowuanpai.aspx?kongweiid=" + kongweiId, title: "安排票务", width: "980px", height: "550px" });
            },
            ShowOrderInfo: function(kongweiId, orderstatus) {
                var _title = "查看订单-";
                switch (orderstatus) {
                    case "yuliu": _title += "已预留"; break;
                    case "shishou": _title += "已成交"; break;
                    case "mingdanbuquan": _title += "名单不全"; break;
                    case "weiqueren": _title += "未确认"; break;
                    case "shenqing": _title += "申请中"; break;
                    default: _title += "全部"; break;
                }

                PlanList.ShowBoxy({ iframeUrl: "/TeamPlan/OrderInfo.aspx?kongweiId=" + kongweiId + "&orderstatus=" + orderstatus, title: _title, width: "980px", height: "350px" });
            },
            ShouKe: function(kongweiId) {
                PlanList.ShowBoxy({ iframeUrl: "/TeamPlan/PlanAdd.aspx?kongweiId=" + kongweiId, title: "收客预定", width: "970px", height: "600px" });
            },
            BindBtn: function() {
                $(".anpai_dj").click(function() {
                    //绑定的控位编号
                    var kongeweiId = $(this).closest("tr").attr("data-kongweiid");
                    var areaid = $(this).attr("routid");
                    PlanList.AnPaiGround(kongeweiId, areaid);
                    return false;
                });
                $(".anpai_pw").click(function() {
                    //绑定的控位编号
                    var kongeweiId = $(this).closest("tr").attr("data-kongweiid");
                    PlanList.AnPaiTicket(kongeweiId);
                    return false;
                });
                $(".chakan_dingdan").click(function() {
                    //绑定的控位编号
                    var kongeweiId = $(this).closest("tr").attr("data-kongweiid");
                    var orderstatus = $(this).attr("data-class");
                    PlanList.ShowOrderInfo(kongeweiId, orderstatus);
                    return false;
                });
                $(".tour_jiesuan").click(function() {
                    //绑定的控位编号
                    if ("<%=Privs_TuanDuiJieSuan %>" == "0") {
                        tableToolbar._showMsg("你没有团队结算的权限！");
                        return false;
                    }

                    var kongeweiId = $(this).closest("tr").attr("data-kongweiid");
                    location.href = "/TeamPlan/TeamAccounts.aspx?type=tour&tourid=" + kongeweiId + "&rurl=" + encodeURIComponent(window.location.href);
                    return false;
                });
                $(".shouke").click(function() {
                    var kongeweiId = $(this).closest("tr").attr("data-kongweiid");
                    PlanList.ShouKe(kongeweiId);
                    return false;
                });
                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行", //
                    copyCallBack: function(obj) {
                        PlanList.Copy(obj);
                    },
                    deleteCallBack: function(objsArr) {
                        //删除(批量)
                        PlanList.DelAll(objsArr);
                    },
                    otherButtons: []
                });
            },
            //省份城市初始化
            initPC: function() {
                pcToobar.init({
                    pID: "#txtQuDepProvince",
                    cID: "#txtQuDepCity",
                    pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtQuDepProvince"),0) %>',
                    cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtQuDepCity"),0) %>',
                    comID: '<%= this.SiteUserInfo.CompanyId %>',
                    isCy: "1"
                });
                pcToobar.init({
                    pID: "#txtQuArrProvince",
                    cID: "#txtQuArrCity",
                    pSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtQuArrProvince"),0) %>',
                    cSelect: '<%= EyouSoft.Common.Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("txtQuArrCity"),0) %>',
                    comID: '<%= this.SiteUserInfo.CompanyId %>',
                    isCy: "1"
                });
            },
            //核算结束
            heSuanJieShu: function(obj) {
                var _data = { txtKongWeiId: [] };
                $("input[type='checkbox'][name='checkbox']:checked").each(function() {
                    _data.txtKongWeiId.push($(this).val());
                });

                if (_data.txtKongWeiId.length == 0) {
                    tableToolbar._showMsg("请选择要核算结束的控位信息！");
                    return;
                }

                if (!confirm("核算结束后，不能进行修改、预订、安排地接、安排机票等操作！\n你确定要核算结束吗？")) return;

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "hesuanjieshu" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            PlanList.reload();
                        } else {
                            alert(response.msg);
                        }
                    }
                });
            },
            //取消核算结束
            quXiaoHeSuanJieShu: function(obj) {
                var _data = { txtKongWeiId: [] };
                $("input[type='checkbox'][name='checkbox']:checked").each(function() {
                    _data.txtKongWeiId.push($(this).val());
                });

                if (_data.txtKongWeiId.length == 0) {
                    tableToolbar._showMsg("请选择要取消核算结束的控位信息！");
                    return;
                }

                if (!confirm("取消核算结束后，能进行修改、预订、安排地接、安排机票等操作！\n你确定要取消核算结束吗？")) return;

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "quxiaohesuanjieshu" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            PlanList.reload();
                        } else {
                            alert(response.msg);
                        }
                    }
                });
            },
            caoZuoBeiZhu: function(obj) {
                var _data = { kongweiid: $(obj).closest("tr").attr("data-kongweiid") };
                Boxy.iframeDialog({ title: "操作备注", iframeUrl: "kongweibeizhu.aspx", width: "850px", height: "580px", data: _data, afterHide: function() { PlanList.reload(); } });
                return false;
            },
            openU: function() {
                var kongWeiIds = []; var moBanIds = []; var piCodes = [];
                $("input[data-class='chk_kongweiid']:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    kongWeiIds.push(_$tr.attr("data-kongweiid"));
                    if ($.inArray(_$tr.attr("data-mobanid"), moBanIds) == -1) moBanIds.push(_$tr.attr("data-mobanid"));
                    if ($.inArray(_$tr.attr("data-picicode"), piCodes) == -1) piCodes.push(_$tr.attr("data-picicode"));
                });
                if (kongWeiIds.length == 0) { alert("请选择你要修改的计划位"); return; }
                if (kongWeiIds.length > 1 && (moBanIds.length > 1 || moBanIds[0].length == 0)) { alert("已选择的计划位不是相同批次发布，不能批量修改"); return; }
                if (kongWeiIds.length > 1 && (piCodes.length > 1 || piCodes[0].length == 0)) { alert("已选择的计划位不是相同批次发布，不能批量修改"); return; }

                var _data = { kongweiids: kongWeiIds.join(","), id: kongWeiIds[0], czfs: "UPDATE" };
                var _title = "修改计划位";
                if (kongWeiIds.length > 1) _title += "（批量）";
                Boxy.iframeDialog({ title: _title, iframeUrl: "editplan.aspx", width: "930px", height: "600px", data: _data, afterHide: function() { PlanList.reload(); } });
                return false;
            },
            openC: function() {
                var _data = { czfs: "INSERT" };
                Boxy.iframeDialog({ title: "新增计划位", iframeUrl: "editplan.aspx", width: "930px", height: "600px", data: _data, afterHide: function() { PlanList.reload(); } });
            },
            openCopy: function() {
                var kongWeiIds = []; var moBanIds = []; var piCodes = [];
                $("input[data-class='chk_kongweiid']:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    kongWeiIds.push(_$tr.attr("data-kongweiid"));
                    if ($.inArray(_$tr.attr("data-mobanid"), moBanIds) == -1) moBanIds.push(_$tr.attr("data-mobanid"));
                    if ($.inArray(_$tr.attr("data-picicode"), piCodes) == -1) piCodes.push(_$tr.attr("data-picicode"));
                });
                if (kongWeiIds.length == 0) { alert("请选择你要复制的计划位"); return; }
                if (kongWeiIds.length > 1 && (moBanIds.length > 1 || moBanIds[0].length == 0)) { alert("已选择的计划位不是相同批次发布，不能复制"); return; }
                if (kongWeiIds.length > 1 && (piCodes.length > 1 || piCodes[0].length == 0)) { alert("已选择的计划位不是相同批次发布，不能批量修改"); return; }

                var _data = { kongweiids: kongWeiIds.join(","), id: kongWeiIds[0], czfs: "COPY" };
                Boxy.iframeDialog({ title: "复制计划位", iframeUrl: "editplan.aspx", width: "930px", height: "600px", data: _data, afterHide: function() { PlanList.reload(); } });
                return false;
            },
            //设置平台收客状态
            sheZhiPingTaiShouKeStatus: function(obj) {
                var _data = { txtKongWeiId: [], txtStatus: $(obj).attr("data-status") };
                $("input[type='checkbox'][name='checkbox']:checked").each(function() {
                    _data.txtKongWeiId.push($(this).val());
                });
                var _s1 = "请选择需要停收的控位";
                var _s2 = "停收后，该控位将不提供预订功能（对外平台），你确定要停收吗？";
                if (_data.txtStatus == "zhengchang") {
                    _s1 = "请选择需要正常收客的控位";
                    _s2 = "正常收客后，控位将开放预订功能（对外平台），你确定要正常收客吗？";
                }

                if (_data.txtKongWeiId.length == 0) { alert(_s1); return; }

                if (!confirm(_s2)) return;

                $.ajax({
                    type: "post", cache: false, url: utilsUri.createUri(window.location.href, { doType: "shezhipingtaishoukestatus" }), dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        PlanList.reload();
                    },
                    error: function() {
                        PlanList.reload();
                    }
                });
            },
            //设置平台收客状态
            sheZhiShouKeStatus: function(obj) {
                var _data = { txtKongWeiId: [], txtStatus: $(obj).attr("data-status") };
                $("input[type='checkbox'][name='checkbox']:checked").each(function() {
                    _data.txtKongWeiId.push($(this).val());
                });
                var _s1 = "请选择需要停收的控位";
                var _s2 = "系统停收后，该控位将不提供预订功能（系统+对外平台），你确定要停收吗？";
                if (_data.txtStatus == "zhengchang") {
                    _s1 = "请选择需要正常收客的控位";
                    _s2 = "正常收客后，控位将开放预订功能（系统+对外平台），你确定要正常收客吗？";
                }

                if (_data.txtKongWeiId.length == 0) { alert(_s1); return; }
                if (!confirm(_s2)) return;

                $.ajax({
                    type: "post", cache: false, url: utilsUri.createUri(window.location.href, { doType: "shezhishoukestatus" }), dataType: "json",
                    data: _data,
                    success: function(ret) {
                        alert(ret.msg);
                        PlanList.reload();
                    },
                    error: function() {
                        PlanList.reload();
                    }
                });
            },
            xiuGaiPingTaiShuLiang: function(obj) {
                var _data = { editid: $(obj).closest("tr").attr("data-kongweiid") };
                Boxy.iframeDialog({ title: "修改平台控位数量", iframeUrl: "KongWeiPingTaiShuLiangEdit.aspx", width: "500px", height: "200px", data: _data, afterHide: function() { PlanList.reload(); } });
            },
            shiZhiXianShiStatus: function(obj) {
                var _$obj = $(obj);
                var _$tr = _$obj.closest("tr");

                var _data = { txtFS: _$obj.attr("data-fs"), txtKongWeiId: _$tr.attr("data-kongweiid") };

                var _confirmXiaoXi = "你确定要显示该控位吗？";
                if (_data.txtFS == "yincang") _confirmXiaoXi = "隐藏控位后该控位将不会默认显示在计划位列表，你确定要隐藏吗？";

                if (!confirm(_confirmXiaoXi)) return;

                $.newAjax({ type: "POST", url: "planlist.aspx?doType=shezhixianshistatus", data: _data,
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        PlanList.reload();
                    },
                    error: function() {
                        PlanList.reload();
                    }
                });
            }
        };

        $(function() {
            $('.number').bt({ contentSelector: function() { return $(this).prev("span").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 720, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            PlanList.BindBtn();
            PlanList.initPC();

            $("#i_a_hesuanjieshu").bind("click", function() { PlanList.heSuanJieShu(this); });
            $("#i_a_quxiaohesuanjieshu").bind("click", function() { PlanList.quXiaoHeSuanJieShu(this); });

            $(".caozuobeizhu").bind("click", function() { PlanList.caoZuoBeiZhu(this); });
            $('.caozuobeizhu').bt({ contentSelector: function() { return "<div>正在加载操作备注</div>" }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 520, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%' }, ajaxCache: false, ajaxPath: function() { return "planlist.aspx?dotype=getcaozuobeizhu&kongweiid=" + $(this).closest("tr").attr("data-kongweiid") } });

            $("#update_jihuaw").click(function() { PlanList.openU(); });
            $("#add_jihuaw").click(function() { PlanList.openC(); });
            $("#copy_jihuaw").click(function() { PlanList.openCopy(); });

            $('.jiaotong').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 320, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });

            $("#i_a_pingtaishouke_tingshou,#i_a_pingtaishouke_zhengchang").click(function() { PlanList.sheZhiPingTaiShouKeStatus(this); });
            $("#i_a_shouke_tingshou,#i_a_shouke_zhengchang").click(function() { PlanList.sheZhiShouKeStatus(this); });

            $(".pingtaishuliang").click(function() { PlanList.xiuGaiPingTaiShuLiang(this); });
            $("#txtXianShiStatus").val("<%=CX_XianShiStatus %>");
            $(".xianshistatus").click(function() { PlanList.shiZhiXianShiStatus(this); });
        });
    </script>

</asp:Content>
