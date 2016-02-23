<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PiaoWuAnPai.aspx.cs" Inherits="Web.TeamPlan.PiaoWuAnPai"
    MasterPageFile="~/MasterPage/Boxy.Master" %>
    
<asp:Content ContentPlaceHolderID="PageBody" ID="PageBody" runat="server">
    <div style="width: 940px; margin: 10px auto;">
        <span class="formtableT">押金登记</span>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="36" height="30">
                    编号
                </th>
                <th>
                    代理商
                </th>
                <th width="50">
                    价格
                </th>
                <th width="40">
                    数量
                </th>
                <th>
                    订单号或编码
                </th>
                <th width="70">
                    押金金额
                </th>
                <th>
                    已付金额
                </th>
                <th>
                    押金备注
                </th>
                <th width="70">
                    退回金额
                </th>
                <th>
                    已退金额
                </th>
                <th width="80">
                    退回时间
                </th>
                <th>
                    退回备注
                </th>
                <th width="60">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="RptsYaJin">
            <ItemTemplate>
            <tr class="even" i_xmid="<%#Eval("DaiLiId") %>" i_yifujine="<%#Eval("CheckMoney") %>"
                i_yituijine="<%#Eval("ReturnMoney") %>">
                <td height="30" align="center">
                    <%# Container.ItemIndex + 1%>                    
                </td>
                <td align="center">
                    <%#Eval("GysName")%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("Price"))%>
                </td>
                <td align="center">
                    <%#Eval("ShuLiang")%>
                </td>
                <td align="center">
                    <%#Eval("GysOrderCode")%>
                </td>
                <td align="center">
                    <input name="txtYaJinJinE" type="text" class="formsize50 inputtext" maxlength="11"
                        value="<%#Eval("YaJinAmount","{0:F2}") %>" />
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("CheckMoney"))%>
                </td>
                <td align="center">
                    <input name="txtYaJinBeiZhu" type="text" class="formsize100 inputtext" value="<%#Eval("YaJinBeiZhu") %>"
                        maxlength="255"  />
                </td>
                <td align="center">
                    <input name="txtTuiYaJinJinE" type="text" class="formsize50 inputtext" value="<%#Eval("TuiYaJinAmount","{0:F2}") %>"
                        maxlength="11" valid="isNumber" errmsg="请填写正确的退回金额" />
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("ReturnMoney"))%>
                </td>
                <td align="center">
                    <input name="txtTuiYaJinTime" type="text" class="formsize80 inputtext" value="<%#Eval("TuiTime","{0:yyyy-MM-dd}") %>"
                        onfocus="WdatePicker()" valid="isDate" errmsg="请填写正确的退回时间" />
                </td>
                <td align="center">
                    <input name="txtTuiYaJinBaiZhu" type="text" class="formsize100 inputtext" value="<%#Eval("TuiYaJinBeiZhu") %>" maxlength="255" />
                </td>
                <td align="center">
                    <a href="javascript:void(0)" class="i_yajin_save"><img src="/images/baocunimg.gif" width="48" height="20" /></a>
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div style="width: 940px; margin: 0 auto 10px;">
        <span class="formtableT">已安排出票</span> <a href="javascript:void(0)" id="i_chupiao"><span
            class="fred">出票安排</span></a>&nbsp;<a href="javascript:void(0)" id="i_a_ToXlsYouKe"><span class="fred">导出已安排出票游客名单</span></a>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_YiAnPaiLieBiao">
            <tr class="odd">
                <th width="36" height="30">
                    编号
                </th>
                <th width="80">
                    交易号
                </th>
                <th>
                    代理商
                </th>
                <th>
                    订单号或编码
                </th>
                <th>
                    价格
                </th>
                <th>
                    出票数量
                </th>
                <th>
                    结算明细
                </th>
                <th>
                    结算金额
                </th>
                <th>
                    已支付金额
                </th>
                <th>
                    备注
                </th>
                <th>操作人</th>
                <th width="120">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="RptsYiAnPaiChuPiao">
            <ItemTemplate>
            <tr class="even" i_anpaiid="<%#Eval("PlanId") %>" i_filepath="<%#Eval("FilePath") %>">
                <td height="30" align="center">
                    <%# Container.ItemIndex + 1%>
                </td>
                <td align="center">
                    <a href="javascript:void(0)" data-class="jiaoyihao"><%#Eval("JiaoYiHao")%></a>
                    <div style="display: none;">安排出票时间：<%#Eval("IssueTime","{0:yyyy-MM-dd HH:mm}") %></div>
                </td>
                <td align="center">
                    <%#Eval("DaiLiName")%>
                </td>
                <td align="center">
                    <%#Eval("GysOrderCode")%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("Price"))%>
                </td>
                <td align="center">
                    <%#Eval("ShuLiang")%>
                </td>
                <td align="center">
                    <%#Eval("JieSuanMX")%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("JieSuanAmount"))%>
                </td>
                <td align="center">
                    <%#ToMoneyString(Eval("PayMoney"))%>
                </td>
                <td align="center">
                    <%#Eval("Remark")%>
                </td>
                <td style="text-align:center;"><%#Eval("OperatorName") %></td>
                <td align="center">
                    <%#YiAnPaiOperatorHtml%>                    
                </td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phEmpty">
                <tr class="i_tr_yianpai_empty"><td colspan="12" style="text-align:center; height:30px;" class="even">暂无出票安排信息</td></tr>
            </asp:PlaceHolder>
        </table>
    </div>    
    
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            //押金保存
            yaJinSave: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtXiangMuId: _$tr.attr("i_xmid"),
                    txtYaJinJinE: $.trim(_$tr.find("input[name='txtYaJinJinE']").val()),
                    txtYaJinBeiZhu: $.trim(_$tr.find("input[name='txtYaJinBeiZhu']").val()),
                    txtTuiYaJinJinE: $.trim(_$tr.find("input[name='txtTuiYaJinJinE']").val()),
                    txtTuiYaJinTime: $.trim(_$tr.find("input[name='txtTuiYaJinTime']").val()),
                    txtTuiYaJinBaiZhu: $.trim(_$tr.find("input[name='txtTuiYaJinBaiZhu']").val())
                };
                var validatorResult = ValiDatorForm.validator(_$tr.get(0), "parent");
                if (!validatorResult) return false;

                _data.txtYaJinJinE = parseFloat(_data.txtYaJinJinE);
                _data.txtTuiYaJinJinE = parseFloat(_data.txtTuiYaJinJinE);

                if (_data.txtYaJinJinE <= 0) { parent.tableToolbar._showMsg("押金金额不能小于等于0"); return false; }
                if (_data.txtTuiYaJinJinE < 0) { parent.tableToolbar._showMsg("退回金额不能小于0"); return false; }
                if (_data.txtTuiYaJinJinE > _data.txtYaJinJinE) { parent.tableToolbar._showMsg("退回金额不能大于押金金额"); return false; }
                if (parseFloat(_$tr.attr("i_yifujine")) > _data.txtYaJinJinE) { parent.tableToolbar._showMsg("押金金额不能小于已付金额"); return false; }
                if (parseFloat(_$tr.attr("i_yituijine")) > _data.txtTuiYaJinJinE) { parent.tableToolbar._showMsg("退回金额不能小于已退金额"); return false; }

                if (!confirm("你确定要保存押金登记信息吗？")) return false;

                $(obj).unbind("click").text("保存中").css({ "color": "#999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "yajinsave" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.yaJinSave(obj); }).css({ "color": "" }).html('<img src="/images/baocunimg.gif" width="48" height="20" />');
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.yaJinSave(obj); }).css({ "color": "" }).html('<img src="/images/baocunimg.gif" width="48" height="20" />');
                    }
                });
            },
            //打开出票安排窗口
            chuPiao: function(obj) {
                var _title = "出票安排";
                var _data = { kongweiid: "<%=KongWeiId %>" };
                parent.Boxy.iframeDialog({ title: _title, iframeUrl: "piaowuanpaiedit.aspx", width: "980px", height: "550px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //打开修改出票窗口
            updateChuPiao: function(obj) {
                var _title = "修改出票";
                var _$obj = $(obj);
                var _$tr = _$obj.closest("tr");
                var _data = { kongweiid: "<%=KongWeiId %>", anpaiid: _$tr.attr("i_anpaiid") };
                if (_$obj.attr("i_chakan") == "1") _title = "查看出票信息";

                parent.Boxy.iframeDialog({ title: _title, iframeUrl: "piaowuanpaiedit.aspx", width: "980px", height: "550px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            //删除出票
            del: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _data = { txtAnPaiId: _$tr.attr("i_anpaiid") };

                if (!confirm("出票信息删除后不可恢复，你确定要删除吗？")) return;
                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "anpaidelete" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            iPage.reload();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.del(obj); }).css({ "color": "" });
                    }
                });

            },
            //打开变更历史窗口
            bianGeng: function(obj) {
                var _title = "查看变更历史";
                var _$tr = $(obj).closest("tr");
                var _data = { bianId: _$tr.attr("i_anpaiid"), bianType: "<%=(int)EyouSoft.Model.EnumType.TourStructure.BianType.票务安排变更 %>" };
                parent.Boxy.iframeDialog({ title: _title, iframeUrl: "/commonpage/biangenglist.aspx", width: "400px", height: "200px", data: _data, afterHide: function() { } });
                return false;
            },
            //附件下载
            download: function(obj) {
                var _$tr = $(obj).closest("tr");
                _filepath = _$tr.attr("i_filepath");
                if (_filepath.length == 0) { alert("暂无附件以供下载"); return false; }
                parent.window.location.href = _filepath;
                return false;
            },
            //打开退票窗口
            tuiPiao: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _title = "退票";
                var _data = { kongweiid: "<%=KongWeiId %>", anpaiid: _$tr.attr("i_anpaiid") };
                parent.Boxy.iframeDialog({ title: _title, iframeUrl: "piaowuanpaituipiao.aspx", width: "980px", height: "550px", data: _data, afterHide: function() { iPage.reload(); } });
                return false;
            },
            toXlsYouKe: function() {
                if ($("#i_table_YiAnPaiLieBiao").find("tr.i_tr_yianpai_empty").length == 1) {
                    alert("暂未做任何出票安排，不能导出任何数据。"); return false;
                }

                var params = { doType:"toxls_youke" };
                toXls2(utilsUri.createUri(null, params));
                return false;
            }
        };

        $(document).ready(function() {
            $(".i_yajin_save").bind("click", function() { iPage.yaJinSave(this); return false; });
            $("#i_chupiao").bind("click", function() { iPage.chuPiao(this); });
            $(".i_yianpai_update").bind("click", function() { iPage.updateChuPiao(this); });
            $(".i_yianpai_delete").bind("click", function() { iPage.del(this); return false; });
            $(".i_yianpai_biangeng").bind("click", function() { iPage.bianGeng(this); });
            $(".i_yianpai_download").bind("click", function() { iPage.download(this); });
            $(".i_yianpai_tuipiao").bind("click", function() { iPage.tuiPiao(this); });
            $("#i_a_ToXlsYouKe").bind("click", function() { iPage.toXlsYouKe(this); });

            $('a[data-class="jiaoyihao"]').bt({ contentSelector: function() { return $(this).next("div").html(); }, positions: ['bottom'], fill: '#effaff', strokeStyle: '#2a9cd4', noShadowOpts: { strokeStyle: "#2a9cd4" }, spikeLength: 5, spikeGirth: 15, width: 180, overlap: 0, centerPointY: 4, cornerRadius: 4, shadow: true, shadowColor: 'rgba(0,0,0,.5)', cssStyles: { color: '#1351a0', 'line-height': '200%'} });
        });
    </script>
    
</asp:Content>
    