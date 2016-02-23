<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieSuanHuiZongBiao.aspx.cs"
    Inherits="Web.Fin.JieSuanHuiZongBiao" MasterPageFile="~/MasterPage/Front.Master"
    Title="结算汇总表-财务管理" %>


<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="PageBody" runat="server">
    <div class="lineprotitlebox">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%" nowrap="nowrap">
                    <span class="lineprotitle">财务管理</span>
                </td>
                <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                    <b>当前您所在位置：</b> >> 财务管理 >> 结算汇总表
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="#000000">
                </td>
            </tr>
        </table>
    </div>
    <div class="hr_10">
    </div>
    <form id="form1" method="get" action="">
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="10" valign="top">
                <img src="/images/yuanleft.gif" />
            </td>
            <td>
                <div class="searchbox">
                    出团日期：
                    <input name="txtSQuDate" type="text" class="searchinput formsize80 inputtext" id="txtSQuDate"
                        onfocus="WdatePicker()" />
                    -
                    <input name="txtEQuDate" type="text" class="searchinput formsize80 inputtext" id="txtEQuDate"
                        onfocus="WdatePicker()" />
                    线路区域：<select name="txtQuYu" class="inputselect" id="txtQuYu" valid="required" errmsg="请选择线路区域!">
                            <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                        </select>
                    去程交通：<select name="txtQuJiaoTong" class="inputselect"><%=GetQuJiaoTongOptions()%></select>
                    核算状态：<select name="txtKongWeiZhuangTai" id="txtKongWeiZhuangTai" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)), "", "-1", "-请选择-")%></select><br />
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
                    <input type="image" src="/images/searchbtn.gif" style="vertical-align: top;" />
                </div>
            </td>
            <td width="10" valign="top">
                <img src="/images/yuanright.gif" />
            </td>
        </tr>
    </table>
    </form>
    
    <div class="btnbox">
        <table border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td width="90" align="center">
                    <a href="javascript:void(0)" id="i_a_toxls">导出</a>
                </td>
            </tr>
        </table>
    </div>
    
    <div class="tablelist">
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr class="odd" style="height: 30px;">
                <th width="36" align="center">
                    序号
                </th>
                <th align="center">
                    控位号
                </th>
                <th width="11%" align="center">
                    出团日期
                </th>
                <th width="9%" align="center">
                    线路区域
                </th>
                <th align="center">
                    去程交通
                </th>
                <th width="8%" align="center">
                    去程出发地
                </th>
                <th width="8%" align="center">
                    去程目的地
                </th>
                <th width="5%" align="center">
                     数量
                </th>
                <th width="5%" align="center">
                    占位数
                </th>
                <th width="8%" align="center">
                    收入金额
                </th>
                <th width="8%" align="center">
                    支出金额
                </th>
                <th width="8%" align="center">
                    毛利
                </th>
                <th width="6%" align="center">
                    毛利率
                </th>
                <th width="50" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpts">
                <ItemTemplate>
                    <tr class="<%#Container.ItemIndex%2==0?"even":"odd" %>" i_kongweiid="<%#Eval("KongWeiId") %>"
                        i_kongweitype="<%#(int)Eval("KongWeiType") %>" style="height: 30px;">
                        <td align="center">
                            <%# Container.ItemIndex + 1+( this.pageIndex - 1) * this.pageSize%>
                        </td>
                        <td align="center">
                            <%#GetKongWeiCode(Eval("KongWeiCode"),Eval("KongWeiZhuangTai")) %>
                        </td>
                        <td align="center">
                            <%#ToDateTimeString(Eval("QuDate"))%>(<%#EyouSoft.Common.Utils.ConvertWeekDayToChinese(EyouSoft.Common.Utils.GetDateTime(Convert.ToString(Eval("QuDate"))))%>)
                        </td>
                        <td align="center">
                            <%#Eval("AreaName") %>
                        </td>
                        <td align="center">
                            <%#Eval("QuJiaoTongName") %>
                        </td>
                        <td align="center">
                            <%#Eval("QuDepCityName")%>
                        </td>
                        <td align="center">
                            <%#Eval("QuArrCityName")%>
                        </td>
                        <td align="center">
                            <%#Eval("ShuLiang") %>
                        </td>
                        <td align="center">
                            <%#Eval("ZhanWeiShuLiang") %>
                        </td>
                        <td align="center">
                            <%#ToMoneyString((decimal)Eval("ShouRuJinE") + (decimal)Eval("QiTaShouRuJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString((decimal)Eval("ZhiChuJinE") + (decimal)Eval("QiTaZhiChuJinE"))%>
                        </td>
                        <td align="center">
                            <%#ToMoneyString(Eval("MaoLiJinE")) %>
                        </td>
                        <td align="center">
                            <%#Eval("MaoLiLv")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)" class="i_a_chakan">查看</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr>
                    <td class="even" colspan="14" style="height: 30px; text-align: center;">
                        暂无任何团队结算信息。
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phHeJi" runat="server">
                <tr class="even">
                    <td height="30" colspan="7" align="right">
                        合计：
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrShuLiangHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrZhanWeiShuLiangHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrShouRuJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrZhiChuJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrMaoLiJinEHeJi"></asp:Literal>
                    </td>
                    <td align="center">
                        <asp:Literal runat="server" ID="ltrMaoLiLv"></asp:Literal>
                    </td>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
            </asp:PlaceHolder>
        </table>
        <asp:PlaceHolder runat="server" ID="phPaging">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <cc1:ExporPageInfoSelect ID="paging" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:PlaceHolder>
    </div>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //查看click
            chaKan: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _kongWeiType = _$tr.attr("i_kongweitype");
                var params = { tourid: _$tr.attr("i_kongweiid"), type: "tour", rurl: window.location.href };
                if (_kongWeiType == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店 %>") params.type = "hotel";
                window.location.href = utilsUri.createUri("/teamplan/teamaccounts.aspx", params);
                return false;
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
            toXls: function() {
                var params = { doType: "toxls_jiesuanhuizongbiao" };
                toXls1(utilsUri.createUri(null, params));
                return false;
            }
        };

        $(document).ready(function() {
            utilsUri.initSearch();
            $(".i_a_chakan").click(function() { iPage.chaKan(this); });
            iPage.initPC();
            $("#i_a_toxls").bind("click", function() { return iPage.toXls(); });
        });
    </script>

</asp:Content>
