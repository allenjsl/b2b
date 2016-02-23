<%@ Page Title="线路选用页面" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="SelectRoute.aspx.cs" Inherits="Web.CommonPage.SelectRoute" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div style="width:99%; margin:0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="10" valign="top">
                    <img src="/images/yuanleft.gif" />
                </td>
                <td>
                    <div class="searchbox" style="line-height:30px;height:60px;">
                        线路区域：<select name="txtQuYu" class="inputselect" id="txtQuYu">
                            <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                        </select>
                        线路名称：
                        <input name="txtRouteName" type="text" id="txtRouteName" class="inputtext searchinput"
                            value="<%= EyouSoft.Common.Utils.GetQueryStringValue("txtRouteName") %>" />
                        发布时间：<input name="txtTime1" type="text" id="txtTime1" class="searchinput inputtext"
                            onfocus="WdatePicker()" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("txtTime1") %>"
                            style="width: 65px;" />-<input name="txtTime2" type="text" id="txtTime2" class="searchinput inputtext"
                                onfocus="WdatePicker()" value="<%= EyouSoft.Common.Utils.GetQueryStringValue("txtTime2") %>"
                                style="width: 65px;" />
                        <br/>线路状态：
                        <select id="txtZhengCeStatus" name="txtZhengCeStatus" class="inputselect">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)), "", "-1", "-请选择-") %>
                        </select>
                        线路类型：<select class="inputselect" id="txtLeiXing" name="txtLeiXing"><option value="">
                            -请选择-</option>
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing)),"")%></select>
                        <a href="javascript:void(0);" id="a_search">
                            <img alt="点击查询" src="/images/searchbtn.gif" style="border-width: 0px;" /></a>
                    </div>
                </td>
                <td width="10" valign="top">
                    <img src="/images/yuanright.gif" />
                </td>
            </tr>
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="cTableList">
            <tr class="odd">
                <asp:Repeater runat="server" ID="rptRoute">
                    <ItemTemplate>
                        <%# GetTrHtml(Container.ItemIndex)%>
                        <td style="width:25%; line-height:24px;">
                            <%# GetInputHtml(Eval("RouteId"), Eval("RouteName"), Container.ItemIndex,Eval("Status"))%>
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
            <tr>
                <td height="30" align="right" class="pageup" colspan="3">
                    <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                </td>
            </tr>
        </table>
        <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="40" align="center">
                </td>
                <td height="40" align="center" class="tjbtn02">
                    <a href="javascript:void(0);" id="selectxl">选用线路</a>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">

        var SelectRoutePage = {
            _data: {
                rid: "",    //线路Id
                rname: ""   //线路名称
            },
            _rdata: [], //返回给父页面的对象 格式为 _data 对象的集合,
            SetValue: function() {
                var str = "";
                var index = 0;
                var _retVal = true;
                if ("<%= IsSelectMore %>" == "1") {//多选
                    $("#cTableList").find("input[type='checkbox']:checked").each(function() {
                        var tdata = {};
                        var _$obj = $(this);
                        if (_$obj.attr("i_status") == "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.已过期 %>") return true;
                        tdata.rid = _$obj.val();
                        tdata.rname = _$obj.attr("data-name")

                        SelectRoutePage._rdata.push(tdata);
                    });
                } else {//单选
                    $("#cTableList").find("input[type='radio']:checked").each(function() {
                        var tdata = {};
                        var _$obj = $(this);

                        if (_$obj.attr("i_status") == "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus.已过期 %>") {
                            alert("选中的线路已过期，请重新选择！");
                            _retVal = false;
                        }

                        tdata.rid = _$obj.val();
                        tdata.rname = _$obj.attr("data-name")

                        SelectRoutePage._rdata.push(tdata);
                    });
                }

                return _retVal;
            },
            SelectValue: function() {

                var callBack = '<%= EyouSoft.Common.Utils.GetQueryStringValue("callBack") %>';
                var pIframeID = '<%= EyouSoft.Common.Utils.GetQueryStringValue("pIframeId") %>';
                //根据父级是否为弹窗传值
                if (pIframeID != "" && pIframeID.length > 0) {
                    //定义父级弹窗
                    var boxyParent = window.parent.Boxy.getIframeWindow(pIframeID) || window.parent.Boxy.getIframeWindowByID(pIframeID);
                    //判断是否存在回调方法
                    if (callBack != null && callBack.length > 0) {
                        if (callBack.indexOf('.') == -1) {
                            boxyParent[callBack](SelectRoutePage._rdata);
                        }
                        else {
                            boxyParent[callBack.split('.')[0]][callBack.split('.')[1]](SelectRoutePage._rdata);
                        }
                    }
                    //定义回调
                }
                else {
                    //判断是否存在回调方法
                    if (callBack != null && callBack.length > 0) {
                        if (callBack.indexOf('.') == -1) {
                            window.parent[callBack](SelectRoutePage._rdata);
                        }
                        else {
                            window.parent[callBack.split('.')[0]][callBack.split('.')[1]](SelectRoutePage._rdata);
                        }
                    }
                    //定义回调
                }
                parent.Boxy.getIframeDialog('<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
            },
            search: function() {
                var data = {};
                data["txtQuYu"] = $("#txtQuYu").val();
                data["txtRouteName"] = $("#txtRouteName").val();
                data["txtTime1"] = $("#txtTime1").val();
                data["txtTime2"] = $("#txtTime2").val();
                data["txtZhengCeStatus"] = $("#txtZhengCeStatus").val();
                data["txtLeiXing"] = $("#txtLeiXing").val();
                data["iscx"] = "1";

                //父页面传过来的参数 也要带上 
                data["iframeId"] = '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';                
                data.initId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("initId") %>';
                data.callBack = '<%= EyouSoft.Common.Utils.GetQueryStringValue("callBack") %>';
                data.pIframeId = '<%= EyouSoft.Common.Utils.GetQueryStringValue("pIframeId") %>';
                data.isMore = '<%= EyouSoft.Common.Utils.GetQueryStringValue("isMore") %>';

                window.location.href = "/CommonPage/SelectRoute.aspx?" + $.param(data);
            }
        };

        $(document).ready(function() {
            $("#a_search").click(function() { SelectRoutePage.search(); return false; });

            $("#selectxl").click(function() {
                if (SelectRoutePage.SetValue()) {
                    SelectRoutePage.SelectValue();
                }
                return false;
            });

            $("#txtZhengCeStatus").val("<%=ZhuangTai %>");
            $("#txtLeiXing").val("<%=LeiXing %>");
            $("#txtQuYu").val("<%=QuYuId %>");
        });        
    </script>

</asp:Content>
