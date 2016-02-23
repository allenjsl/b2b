<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PiaoWuAnPaiEdit.aspx.cs"
    Inherits="Web.TeamPlan.PiaoWuAnPaiEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody" runat="server">

    <div style="width: 950px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="even">
                <td colspan="4" align="right">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#ffffff">
                        <tr class="odd">
                            <th height="22" colspan="7" align="left" class="pandl4">
                                代理商信息
                            </th>
                        </tr>
                        <tr class="even">
                            <td width="55" align="center">
                                序号
                            </td>
                            <td align="center">
                                代理商
                            </td>
                            <td height="30" align="center">
                                订单号或编号
                            </td>
                            <td align="center">
                                价格
                            </td>
                            <td align="center" class="pandl3">
                                数量
                            </td>
                            <td align="center" class="pandl3">
                                押金金额
                            </td>
                            <td align="center">
                                已出票数量
                            </td>
                        </tr>
                        <asp:Repeater runat="server" ID="daiLiRpts">
                        <ItemTemplate>
                        <tr class="even" i_dailiid="<%#Eval("DaiLiId") %>" i_gysid="<%#Eval("GysId") %>"
                            i_zongshuliang="<%#Eval("ShuLiang")%>" i_yichupiaoshuliang="<%#Eval("YiChuPiaoShuLiang")%>">
                            <td align="center">
                                <input type="radio" name="radDaiLi" id="radDaiLi_<%#Eval("DaiLiId") %>" value="<%#Eval("DaiLiId") %>" i_gysid="<%#Eval("GysId") %>" />
                                <%# Container.ItemIndex + 1%>
                            </td>
                            <td align="center">
                                <%#Eval("GysName")%>
                            </td>
                            <td height="30" align="center">
                                <%#Eval("GysOrderCode")%>
                            </td>
                            <td align="center">
                                <%#ToMoneyString(Eval("Price"))%>
                            </td>
                            <td align="center">
                                <%#Eval("ShuLiang")%>
                            </td>
                            <td align="center">
                                <%#ToMoneyString(Eval("YaJinAmount"))%>
                            </td>
                            <td align="center">
                                <%#Eval("YiChuPiaoShuLiang")%>
                            </td>
                        </tr>
                        </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr class="odd">
                <th width="120" align="right">
                    <span class="fred">*</span>出票数量：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtChuPiaoShuLiang" type="text" class="formsize50 inputtext" id="txtChuPiaoShuLiang"
                        maxlength="3" runat="server" valid="required|isInt" errmsg="请填写出票数量|请填写正确的出票数量" />
                </td>
                <th width="120" align="right">
                    结算明细：
                </th>
                <td style="background: #E3F1FC">
                    <textarea name="txtJieSuanMx" rows="2" class="formsize450 inputarea" id="txtJieSuanMx" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th width="120" align="right">
                    <span class="fred">*</span>结算金额：
                </th>
                <td style="background: #E3F1FC">
                    <input name="txtJieSuanJinE" type="text" class="formsize50 inputtext" id="txtJieSuanJinE"
                        runat="server" valid="required|isNumber" errmsg="请填写结算金额|请填写正确的结算金额" />
                </td>
                <th align="right">
                    备注：
                </th>
                <td style="background: #E3F1FC">
                    <textarea name="txtBeiZhu" rows="2" class="formsize450 inputarea" id="txtBeiZhu" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    确认件上传：
                </th>
                <td colspan="3" style="background: #E3F1FC">
                    <uc1:UploadControl ID="UploadFuJian" runat="server" />
                </td>
            </tr>
            
            <%=GetDingDanAndYouKeHtml()%>
            
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="even">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    
    <form runat="server" id="form1"></form>    
    
    <script type="text/javascript">
        var iPage = {
            _KongWeiId: "<%=KongWeiId %>",
            _AnPaiId: "<%=AnPaiId %>",
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
            },
            toInt: function(s) {
                s = $.trim(s);
                var _v = parseInt(s);
                if (isNaN(_v)) return 0;
                return _v;
            },
            toFloat: function(s) {
                s = $.trim(s);
                var _v = parseFloat(s);
                if (isNaN(_v)) return 0;
                return _v;
            },
            //初始化安排信息
            initAnPai: function() {
                //if (this._AnPaiId.length == 0) return;
                //选中安排的代理商
                $("#radDaiLi_" + anPaiDaiLiId).attr("checked", "checked");

                //已出票、已退票游客处理
                $(".i_tr_youke").each(function() {
                    var _$tr = $(this);
                    var _youKeChuPiaoStatus = _$tr.attr("i_youKeChuPiaoStatus");
                    var _youkeStatus = _$tr.attr("i_youkestatus");
                    var _$chk = _$tr.find("input[type='checkbox']");

                    //已出票、已退票游客的chk选中且不可用
                    if (_youKeChuPiaoStatus != "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>") _$chk.attr("checked", "checked").attr("disabled", "disabled");
                    //未出票、退团的游客chk设置成不可用
                    if (_youKeChuPiaoStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>"
                        && _youkeStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TravellerStatus.退团 %>") _$chk.attr("disabled", "disabled");
                });

                //此次安排的游客处理
                for (var i = 0; i < anPaiYouKes.length; i++) {
                    var _$chk = $("#chkYouKe_" + anPaiYouKes[i].YouKeId);
                    _$chk.removeAttr("disabled");
                    if (_$chk.attr("i_chupiaostatus") == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.已退票 %>") {
                        _$chk.bind("click", function() { this.checked = true; parent.tableToolbar._showMsg("已退票的游客不能操作"); return false; })
                    }
                }
            },
            //新增、修改
            save: function(obj) {
                var _data = {
                    txtDaiLiId: "",
                    txtGysId: "",
                    txtChuPiaoShuLiang: $.trim($("#<%=txtChuPiaoShuLiang.ClientID %>").val()),
                    txtJieSuanMx: $.trim($("#<%=txtJieSuanMx.ClientID %>").val()),
                    txtJieSuanJinE: $.trim($("#<%=txtJieSuanJinE.ClientID %>").val()),
                    txtBeiZhu: $.trim($("#<%=txtBeiZhu.ClientID %>").val()),
                    txtFilePath: $.trim($("input[name='<%=UploadFuJian.ClientHideID %>']").val()),
                    txtYFilePath: $.trim($("input[name='<%=UploadFuJian.YuanFilePathClientName %>']").val()),
                    txtYouKeId: [], txtOrderId: []
                };

                var _$radDaiLi = $("input[name='radDaiLi']:checked");
                _data.txtDaiLiId = $.trim(_$radDaiLi.val());
                _data.txtGysId = _$radDaiLi.attr("i_gysid");

                var _$trDaiLi = _$radDaiLi.closest("tr");
                var _zongShuLiang = this.toInt(_$trDaiLi.attr("i_zongshuliang"));
                var _yiChuPiaoShuLiang = this.toInt(_$trDaiLi.attr("i_yichupiaoshuliang"));

                //选中的游客信息处理
                $("input[name='chkYouKe']:enabled:checked").each(function() {
                    var _$tr = $(this).closest("tr");
                    _data.txtYouKeId.push(_$tr.attr("i_youkeid"));
                    _data.txtOrderId.push(_$tr.attr("i_orderid"));
                });

                var validatorResult = ValiDatorForm.validator($("#i_table_form").get(0), "parent");
                if (!validatorResult) return;

                _data.txtChuPiaoShuLiang = this.toInt(_data.txtChuPiaoShuLiang);
                _data.txtJieSuanJinE = this.toFloat(_data.txtJieSuanJinE);
                var _yuanChuPiaoShuLiang = this.toInt($("#<%=txtChuPiaoShuLiang.ClientID %>").attr("i_yuanchupiaoshuliang"));

                if (_data.txtDaiLiId.length == 0) { parent.tableToolbar._showMsg("请选择此次出票的代理商"); return false; }
                if (_data.txtChuPiaoShuLiang <= 0) { parent.tableToolbar._showMsg("请填写正确的出票数量"); return false; }
                if (_data.txtJieSuanJinE < 0) { parent.tableToolbar._showMsg("请填写正确的结算金额"); return false; }
                if (_data.txtJieSuanMx.length > 255) { parent.tableToolbar._showMsg("结算明细最多255个字符"); return false; }
                if (_data.txtBeiZhu.length > 255) { parent.tableToolbar._showMsg("安排备注最多255个字符"); return false; }
                if (_data.txtYouKeId.length == 0) { parent.tableToolbar._showMsg("请选择需要出票的游客"); return false; }
                if (_data.txtChuPiaoShuLiang != _data.txtYouKeId.length) { parent.tableToolbar._showMsg("出票数量与选中的游客个数不相等"); return false; }                
                if (_zongShuLiang < _yiChuPiaoShuLiang - _yiChuPiaoShuLiang + _data.txtChuPiaoShuLiang) { parent.tableToolbar._showMsg("出票数量超过代理商提供的总数量"); return false; }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=save",
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            iPage.initAnPai();
            $("#i_a_save").bind("click", function() { iPage.save(this); });

        });
    </script>
</asp:Content>
