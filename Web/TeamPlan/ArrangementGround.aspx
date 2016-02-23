<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Boxy.Master" AutoEventWireup="true"
    CodeBehind="ArrangementGround.aspx.cs" Inherits="Web.TeamPlan.ArrangementGround" %>

<%@ Import Namespace="EyouSoft.Common" %>
<%@ Register Src="../UserControl/SupperControl.ascx" TagName="SupperControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/SellsSelect.ascx" TagName="SellsSelect" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">

    <script src="/JS/bt.min.js" type="text/javascript"></script>

    <script src="../JS/Newjquery.autocomplete.js" type="text/javascript"></script>

    <!--[if IE]><script src="/JS/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <form id="form1" runat="server">
    <input type="hidden" id="hideDotype" name="hideDotype" value='<%=Utils.GetQueryStringValue("type")==""?"add":Utils.GetQueryStringValue("type") %>' />
    <input type="hidden" name="areaID" id="areaID" value="<%=areaID %>" />
    <input type="hidden" name="anpaiD" id="anpaiD" value="<%=orderlist%>" />
    <input type="hidden" name="qanpaiD" id="qanpaiD" class="qanpaiD" value="<%=updateOrder %>" />
    <div style="width: 900px; margin: 10px auto;">
        <span class="formtableT">已安排地接</span>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" class="autoAdd">
            <tbody>
                <tr class="odd">
                    <th height="30">
                        <p>
                            团号</p>
                    </th>
                    <th>
                        地接社
                    </th>
                    <th>
                        人数
                    </th>
                    <th align="left" class="pandl3">
                        线路名称
                    </th>
                    <th align="center">
                        导游
                    </th>
                    <th>
                        接团方式
                    </th>
                    <th>
                        结算金额
                    </th>
                    <th>
                        已支付金额
                    </th>
                    <th>操作人</th>
                    <th width="170">
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptdijieList">
                    <ItemTemplate>
                        <tr class="odd tempRow" i_anpaiid="<%#Eval("PlanId") %>">
                            <td height="30" bgcolor="#E3F1FC" align="center">
                                <a href="javascript:void(0)" data-class="jiaoyihao"><%#Eval("KongWeiCode") %></a>
                                <div style="display: none;">安排地接时间：<%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}") %></div>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <a href="javascript:void(0)" data-class="dijiequerenxinxi"><%#Eval("GysName") %></a>
                                <div style="display:none"><%#GetDiJieQueRenXinXi(Eval("DiJieQueRenStatus"), Eval("DiJieQueRenRenId"), Eval("DiJieQueRenRenName"), Eval("DiJieQueRenTime"))%></div>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <span style="display: none;">
                                    <%#GetOrderList(Convert.ToString(Eval("PlanId")))%></span> <a class="number" href="javascript:void(0)"
                                        bt-xtitle="" title="">
                                        <%#Eval("ChengRenShu")%>+<%#Eval("ErTongShu") %>+<%#Eval("YingErShu") %>+<%#Eval("QuPeiShu") %></a>
                            </td>
                            <td bgcolor="#E3F1FC" align="left" class="pandl3">
                                <%#Eval("RouteName")%>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <%#Eval("DaoYouName")%>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <%#Eval("JieTuanFangShi")%>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <%#ToMoneyString(Eval("JieSuanAmount"))%>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <%#ToMoneyString(Eval("PayAmount"))%>
                            </td>
                            <td bgcolor="#E3F1FC" align="center"><%#Eval("OperatorName") %></td>
                            <td bgcolor="#E3F1FC" align="center">
                                <%if (isshow)
                                  { %>
                                 <a href="javascript:;" class="update_bar" id="<%#Eval("PlanId") %>">修改</a>|<a 
                                 id="<%#Eval("PlanId") %>" href="javascript:;" class="del_bar">删除</a>|<a target="_blank" 
                                 href="/PrintPage/RoutineLocal.aspx?tourId=<%#Eval("KongWeiId") %>&localId=<%#Eval("PlanId") %>">计划单</a>|<a 
                                 class="historybox" id="<%#Eval("PlanId") %>" data-class="" href="javascript:;">变更</a>|<a 
                                 href="javascript:void(0)" class="i_a_daoyou">导游</a> 
                                <%} %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <div style="width: 900px; margin: 0 auto;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        <span class="fred">*</span>地接社名称：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <uc1:SupperControl ID="SupperControl1" runat="server" IsMust="true" CallBack="CallBackFun" />
                    </td>
                </tr>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        联系人：
                    </th>
                    <td width="320" bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtContactName" CssClass="inputtext formsize100" runat="server"></asp:TextBox>
                    </td>
                    <th width="120" align="right">
                        联系电话：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtContactTel" CssClass="inputtext formsize100" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="even">
                    <td align="right" colspan="4">
                        <table id="tblist" width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#ffffff"
                            align="center">
                            <tbody>
                                <tr class="odd">
                                    <th height="22" align="left" class="pandl4" colspan="8">
                                        请选择此次地接安排的订单
                                    </th>
                                </tr>
                                <tr class="even">
                                    <td width="55" align="center">
                                        序号
                                    </td>
                                    <td height="30" align="center">
                                        订单号
                                    </td>
                                    <td align="center">
                                        性质
                                    </td>
                                    <td align="center" class="pandl3">
                                        线路名称
                                    </td>
                                    <td align="center" class="pandl3">
                                        客户单位
                                    </td>
                                    <td align="center">
                                        人数
                                    </td>
                                    <td align="center">
                                        价格明细
                                    </td>
                                    <td align="center">
                                        总金额
                                    </td>
                                </tr>
                                <asp:Repeater runat="server" ID="rptorderlist">
                                    <ItemTemplate>
                                        <tr class="odd" data-chengrenshu="<%#Eval("Adults")%>" data-ertongshu="<%#Eval("Childs")%>" data-yingershu="<%#Eval("YingErRenShu")%>" data-quanpeishu="<%#Eval("Bears")%>" data-dingdanid="<%#Eval("OrderId") %>">
                                            <td bgcolor="#E3F1FC" align="center">
                                                <input class="chk" order="<%#Eval("OrderId")%>" tclass="<%#Convert.ToString( Eval("BusinessNature"))=="散拼"?"single":"list"%>"
                                                    type="checkbox" id="orderid" name="orderid" value="<%#Eval("OrderId") %>|<%#Eval("RouteId") %>"
                                                    route="<%#Eval("RouteId") %>" data-class="chk_dingdan">
                                                <%# Container.ItemIndex + 1%>
                                            </td>
                                            <td height="30" bgcolor="#E3F1FC" align="center">
                                                <%#Eval("OrderCode")%>
                                            </td>
                                            <td bgcolor="#E3F1FC" align="center">
                                                <%#Eval("BusinessNature")%>
                                            </td>
                                            <td bgcolor="#E3F1FC" align="left" class="pandl3">
                                                <%#Eval("RouteName")%>
                                            </td>
                                            <td bgcolor="#E3F1FC" align="left" class="pandl3">
                                                <%#Eval("BuyCompanyName")%>
                                            </td>
                                            <td bgcolor="#E3F1FC" align="center">
                                                <%#Eval("Adults")%>+<%#Eval("Childs")%>+<%#Eval("YingErRenShu")%>+<%#Eval("Bears")%>
                                            </td>
                                            <td bgcolor="#E3F1FC" align="center" style="word-break: break-all; word-wrap: break-word;">
                                                <%#Eval("JiaGeMingXi1")%>
                                            </td>
                                            <td bgcolor="#E3F1FC" align="center">
                                                <%#ToMoneyString(Eval("SumPrice"))%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        成人数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtAdultCount" CssClass="formsize50 inputtext" runat="server" valid="required|isInt"
                            errmsg="请输入成人数!|请输入正确的成人数!"></asp:TextBox>
                    </td>
                    <th align="right">
                        儿童数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtChildCount" CssClass="formsize50 inputtext" runat="server" valid="isInt"
                            errmsg="请输入正确的儿童数!"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        婴儿数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" runat="server" id="txtYingErRenShu" class="formsize50 inputtext" valid="isInt" errmsg="请输入正确的婴儿数!"/>
                    </td>
                    <th align="right">
                        全陪数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtquanpeiCount" CssClass="formsize50 inputtext" runat="server"
                            valid="isInt" errmsg="请输入正确的全陪数!"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                       用餐：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtYongCanBiaoZhun" id="txtYongCanBiaoZhun" class="inputselect">
                            <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.用餐标准) %>
                        </select><asp:TextBox ID="txtDinner" CssClass="formsize120 inputtext" runat="server"></asp:TextBox>
                    </td>
                    <th align="right">
                     全陪：
                    </th>
                    <td bgcolor="#E3F1FC">
                    <asp:TextBox ID="txtquanpei" CssClass="formsize80 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        结算明细：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:TextBox ID="txtjiesuanDesc" CssClass="formsize450 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        结算金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtjiesuanMoney" CssClass="formsize50 inputtext" errmsg="结算金额 格式不正确!"
                            valid="isNumber" runat="server"></asp:TextBox>
                    </td>
                    <th align="right">
                        接团方式：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtjietuantype" CssClass="formsize120 inputtext" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        客人信息：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <a href="javascript:void(0)" id="a_daoruyouke">点击这里导入所选订单游客信息</a>&nbsp;&nbsp;<span style="color:#666">说明：导入所选订单有联系方式的客人姓名及电话，均无联系方式时，则导入第一个游客姓名。</span><br />
                        <asp:TextBox ID="txtYouKeXinXi" TextMode="MultiLine" Height="109px" CssClass="inputtext w700 h109"
                            Width="700" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        安排备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="109px" CssClass="inputtext w700 h109"
                            Width="700" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        内部备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <asp:TextBox ID="txtNeiBuBeiZhu" TextMode="MultiLine" Height="109px" CssClass="inputtext w700 h109"
                            Width="700" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <div style="width: 900px; margin: 10px auto;">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
                <tbody>
                    <tr class="odd">
                        <td height="30" bgcolor="#E3F1FC" align="left" colspan="14">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="100" height="40" align="center" class="tjbtn02">
                                            <asp:PlaceHolder runat="server" ID="phOperatorHtml">
                                            <a id="save" href="javascript:;">保存</a>
                                            </asp:PlaceHolder>
                                            <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </asp:PlaceHolder>
    </form>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //设置导游
            sheZhiDaoYou: function(obj) {
                var _win = top;
                var _$tr = $(obj).closest("tr");
                var _data = { anpaiid: _$tr.attr("i_anpaiid") };
                _win.Boxy.iframeDialog({ title: "设置导游", iframeUrl: "shezhidaoyou.aspx", width: "520px", height: "380px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            init: function() {
                $("#txtYongCanBiaoZhun").change(function() { $("#<%=txtDinner.ClientID %>").val($(this).val()); });
                $(".i_a_daoyou").bind("click", function() { iPage.sheZhiDaoYou(this); });
            },
            daoRuYouKe: function() {
                var _data = { txtDingDanId: [] };
                $('input[type="checkbox"][data-class="chk_dingdan"]:checked').each(function() {
                    if ($(this).attr("disabled")) { return true; }
                    _data.txtDingDanId.push($(this).closest("tr").attr("data-dingdanid"));
                });
                if (_data.txtDingDanId.length == 0) {
                    alert("当前安排未选择订单，不能导入游客信息"); return false;
                }

                var _self = this;
                $.ajax({ type: "post", url: window.location.href + "&dotype=getyouke", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        if (response.result == "1") {
                            $("#<%=txtYouKeXinXi.ClientID %>").val(response.obj);
                        } else {
                            alert(response.msg);
                        }
                    }
                });


            }
        };
    
        function CallBackFun(obj) {
            if (obj) {
                $("#<%=SupperControl1.ClientText %>").val(obj.name);
                $("#<%=SupperControl1.ClientValue %>").val(obj.id);
                $("#<%=txtContactName.ClientID %>").val(obj.contactname);
                $("#<%=txtContactTel.ClientID %>").val(obj.contacttel);
            }
        }

        $(function() {

            $('.number').bt({
                contentSelector: function() { return $(this).prev("span").html(); },
                positions: ['bottom'],
                fill: '#effaff',
                strokeStyle: '#2a9cd4',
                noShadowOpts: { strokeStyle: "#2a9cd4" },
                spikeLength: 5,
                spikeGirth: 15,
                width: 720,
                overlap: 0,
                centerPointY: 4,
                cornerRadius: 4,
                shadow: true,
                shadowColor: 'rgba(0,0,0,.5)',
                cssStyles: { color: '#1351a0', 'line-height': '200%' }
            });

            $(".historybox").click(function() {
                //id 为表示(待修改)
                var url = "/CommonPage/BianGengList.aspx?bianId=" + $(this).attr("id") + "&bianType=1";
                parent.Boxy.iframeDialog({
                    iframeUrl: url,
                    title: "变更历史",
                    modal: true,
                    width: "350px",
                    height: "250px"
                });
                return false;
            });

            $("#save").click(function() {
                if ($("input:checked").length > 0) {
                    var form = $(this).closest("form").get(0);
                    if (ValiDatorForm.validator(form, "parent")) {
                        form.submit();
                    }
                }
                else {
                    parent.tableToolbar._showMsg("请选择订单", function() { return false });
                }
                return false;
            }); //save

            $(".update_bar").click(function() {
                $("#hideDotype").val("update");
                var list = $("#anpaiD").val().split("|");

                var id = $(this).attr("id");
                if (id) {
                    window.location.href = "/TeamPlan/ArrangementGround.aspx?kongweiId=" + '<%=Utils.GetQueryStringValue("kongweiId") %>' + "&RoutID=" + '<%=Utils.GetQueryStringValue("RoutID") %>' + "&iframeId=" + '<%=Utils.GetQueryStringValue("iframeId") %>' + "&PlanID=" + id + "&type=update";
                }
            });

            $(".del_bar").click(function() {
                if (!confirm("已地接安排信息删除后不可恢复，你确定要删除吗？")) return false;

                var _Url = "/TeamPlan/ArrangementGround.aspx?kongweiId=" + $(this).attr("id") + "&RoutID=" + $("#areaID").attr("id");
                $.newAjax({
                    type: "post",
                    url: "/TeamPlan/ArrangementGround.aspx?type=del&kongweiId=" + $(this).attr("id"),
                    cache: false,
                    dataType: 'json',
                    success: function(data) {
                        if (data.result == "1") {
                            parent.tableToolbar._showMsg(data.msg, function() {
                                window.location.href = window.location.href;
                            });
                            return false;
                        }
                        else {
                            parent.tableToolbar._showMsg(data.msg, function() {
                                window.location.href = window.location.href;
                            });
                            return false;
                        }
                    },
                    error: function() {
                        parent.tableToolbar._showMsg(tableToolbar.errorMsg);
                        return false;
                    }
                });
            }); //del

            //获取成人数-3
            function getChkNum() {
                var crsum = 0;
                var etsum = 0;
                var qpsum = 0;
                var yingErSum = 0;
                $("input:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    crsum += tableToolbar.getInt(_$tr.attr("data-chengrenshu"));
                    etsum += tableToolbar.getInt(_$tr.attr("data-ertongshu"));
                    qpsum = tableToolbar.getInt(_$tr.attr("data-quanpeishu"));
                    yingErSum = tableToolbar.getInt(_$tr.attr("data-yingershu"));
                })
                $("#<%=txtAdultCount.ClientID %>").val(crsum);
                $("#<%=txtChildCount.ClientID %>").val(etsum);
                $("#<%=txtquanpeiCount.ClientID %>").val(qpsum);
                $("#<%=txtYingErRenShu.ClientID %>").val(yingErSum);
            }

            //  end-3
            //选中修改的订单-2
            $(function() {
                var chk = $("#qanpaiD").val().split("|");
                $("input[type=checkbox]").each(function() {
                    for (var i = 0; i < chk.length; i++) {
                        if (chk[i] == $(this).attr("order")) {
                            $(this).attr("checked", "checked");
                        }
                    }
                });
            });
            //end-2
            //判断订单是否安排过地接，安排过的禁用
            var list = $("#anpaiD").val().split("|");
            $("input[type=checkbox]").each(function() {
                for (var i = 0; i < list.length; i++) {
                    if (list[i] == $(this).attr("order")) {
                        $(this).attr("style", "visibility:hidden");
                    }
                }
            });
            //end

            /*--------------------处理团队选用，只能选单团-----------------*/
            $("input[type=checkbox]").click(function() {
                getChkNum(); //合计人数
                //选中
                if ($(this).attr("tclass") == 'list' && $(this).attr("checked") == true) {
                    $("input[type=checkbox]").removeAttr("checked");
                    $(this).attr("checked", true)
                    var order = $(this).attr("order")
                    var self = $(this);
                    $("input[type=checkbox]").each(function() {
                        if ($(this).attr("order") != order) {
                            $(this).attr("disabled", "disabled");
                        }
                    })
                } //end选中
                //取消
                if ($(this).attr("tclass") == 'list' && $(this).attr("checked") == false) {
                    $(this).removeAttr("checked")
                    $("input[type=checkbox]").each(function() {
                        $(this).removeAttr("disabled");
                    });
                } //end取消
            })
            /*-----------------团队选用------------------*/
            /*-----------------散拼选用------------------*/
            $("input[type=checkbox]").click(function() {
                getChkNum(); //合计人数
                //选中
                if ($(this).attr("tclass") == 'single' && $(this).attr("checked") == true) {

                    $("input[type=checkbox][tclass=list]").attr("disabled", "disabled");
                    $(this).attr("checked", true)
                    var order = $(this).attr("route")
                    var self = $(this);
                    $("input[type=checkbox]").each(function() {
                        if ($(this).attr("route") != order) {
                            $(this).attr("disabled", "disabled");
                        }
                    })
                } //end

                //取消
                if ($(this).attr("tclass") == 'single' && $(this).attr("checked") == false) {
                    var list = $("#anpaiD").val().split("|");
                    $("input[type=checkbox]").each(function() {
                        for (var i = 0; i < list.length; i++) {
                            if ($(this).attr("order") == list[i]) {
                                $(this).attr("disabled", "disabled")
                            }
                            else {
                                $(this).removeAttr("disabled")
                            }
                        }
                    });
                } //end
            })
            /*-----------------散拼选用------------------*/
            iPage.init();

            $('a[data-class="jiaoyihao"]').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 180, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            $('a[data-class="dijiequerenxinxi"]').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 180, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
            $("#a_daoruyouke").click(function() { iPage.daoRuYouKe(); });
        })
    </script>

</asp:Content>
