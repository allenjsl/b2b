<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaPiaoEdit.aspx.cs" Inherits="Web.Fin.FaPiaoEdit"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
    <div style="width: 99%; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="150" height="30" align="right">
                    海南开票申请日期：
                </th>
                <td bgcolor="#E3F1FC">
                    <input name="txtShenQingRiQi" type="text" class="formsize80 inputtext" id="txtShenQingRiQi"
                        runat="server" onfocus="WdatePicker()" valid="required|isDate" errmsg="请填写海南开票申请日期|请填写正确的海南开票申请日期" />
                </td>
                <th width="120" align="right">
                    客户单位：
                </th>
                <td bgcolor="#E3F1FC">
                    <uc1:KeHuXuanZe runat="server" ID="txtKeHu" />
                </td>
            </tr>
        </table>        
    </div>
    
    <div style="width: 99%; margin: 0px auto; margin-top: 10px;">
        <span class="formtableT">开票信息</span>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="text-align: center;"
            id="table_fapiaomx" >
            <tr class="odd">
                <th width="36" height="30" align="center">编号</th>
                <th>订单号</th>
                <th align="center">出团日期</th>
                <th align="center">发票金额</th>
                <th align="center">发票抬头</th>
                <th align="center">开票单位</th>
                <th align="center">发票号</th>
                <th align="center">明细</th>
                <th align="center">操作</th>
            </tr>
            <tr class="even mx_item" data-fasongstatus="0">
                <td height="30" align="center">
                    <span class="mx_index">1</span>
                    <input type="hidden" name="txt_mx_id" />
                    <input type="hidden" name="txt_mx_mingxiid" />
                </td>
                <td><input name="txt_mx_dingdanid" type="hidden"><input name="txt_mx_dingdanhao" type="text" class="inputtext" style="width:100px;"/></td>
                <td align="center"><input name="txt_mx_qudate" type="text" class="inputtext" style="width:70px;"/></td>
                <td align="center"><input name="txt_mx_jine" type="text" class="inputtext" style="width:70px;"/></td>
                <td align="center"><input name="txt_mx_taitou" type="text" class="inputtext" style="width:120px;"/></td>
                <td align="center"><input name="txt_mx_kaipiaodanwei" type="text" class="inputtext" style="width:120px;"/></td>
                <td align="center"><input name="txt_mx_fapiaohao" type="text" class="inputtext" style="width:80px;"/></td>
                <td align="center"><textarea name="txt_mx_mingxi" rows="3" class="inputarea" style="width:150px;"></textarea></td>
                <td align="center">
                    <a href="javascript:void(0)" class="mx_tianjia">添加</a>
                    <a href="javascript:void(0)" class="mx_shanchu">删除</a>
                    <a href="javascript:void(0)" class="mx_tongbu">↓</a>
                </td>
            </tr>
        </table>
    </div>
    
    <div style="width: 99%; margin: 0px auto; margin-top: 10px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr class="odd">
                <td height="30" colspan="14" align="left" bgcolor="#E3F1FC">
                    <table border="0" align="center" cellpadding="0" cellspacing="0" visible="true">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        var iPage = {
            //关闭窗口
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            save: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return;

                if ($.trim($("#<%=txtKeHu.KeHuIdClientId %>").val()).length == 0) { alert("请选择客户单位"); return; }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "POST",
                    url: window.location.href + "&doType=save",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.close();
                        } else {
                            $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                });
            },
            getMXItems: function() {
                return $("#table_fapiaomx").find(".mx_item");
            },
            initMXS: function() {
                $(".mx_tianjia").click(function() { iPage.insertMX(this, true); });
                $(".mx_shanchu").click(function() { iPage.deleteMX(this); });
                $(".mx_tongbu").click(function() { iPage.tongBuMX(this); });

                if (typeof faPiaoMxs == "undefined" || faPiaoMxs.length == 0) {
                    _$tr = this.getMXItems().eq(0);
                    this.initMX(_$tr, null);
                    return;
                }

                for (var i = 0; i < faPiaoMxs.length; i++) {
                    var _$tr = null;
                    if (i == 0) { _$tr = this.getMXItems().eq(0); }
                    else { _$tr = this.insertMX(null, false); }
                    this.initMX(_$tr, faPiaoMxs[i]);
                }
            },
            initMX: function($tr, data) {
                $tr.find("input[name='txt_mx_dingdanhao']").unbind();
                var _txtDingDanHaoInputId = "txt_mx_dingdanhao_" + parseInt(Math.random() * 10000);
                var _txtDingDanIdInputId = "txt_mx_dingdanid_" + parseInt(Math.random() * 10000);
                $tr.find("input[name='txt_mx_dingdanhao']").attr("id", _txtDingDanHaoInputId);
                $tr.find("input[name='txt_mx_dingdanid']").attr("id", _txtDingDanIdInputId);

                require(["fapiaoxuanzedingdan"], function(fapiaoxuanzedingdan) {
                    fapiaoxuanzedingdan.init({ inputId: _txtDingDanHaoInputId, keHuIdInputId: "<%=txtKeHu.KeHuIdClientName %>" });
                });

                if (data != null) {
                    $tr.attr("data-fasongstatus", data.Status);
                    $tr.find("input[name='txt_mx_id']").val(data.MXId);
                    $tr.find("input[name='MingXiId']").val(data.MingXiId);
                    $tr.find("input[name='txt_mx_dingdanid']").val(data.DingDanId);
                    $tr.find("input[name='txt_mx_dingdanhao']").val(data.DingDanHao);
                    $tr.find("input[name='txt_mx_qudate']").val(this.formatJsonDateTime(data.ChuTuanRiQi));
                    $tr.find("input[name='txt_mx_jine']").val(data.JinE.toFixed(2));
                    $tr.find("input[name='txt_mx_taitou']").val(data.TaiTou);
                    $tr.find("input[name='txt_mx_kaipiaodanwei']").val(data.KaiPiaoDanWei);
                    $tr.find("input[name='txt_mx_fapiaohao']").val(data.FaPiaoHao);
                    $tr.find("textarea[name='txt_mx_mingxi']").val(data.MingXi);
                }
            },
            insertMX: function(obj, isInit) {
                var _$tr = this.getMXItems().eq(0).clone(true);
                _$tr.find("input").val("");
                _$tr.attr("data-fasongstatus", "<%=(int)EyouSoft.Model.EnumType.FinStructure.FaPiaoFaSongStatus.未送出 %>");

                $("#table_fapiaomx").append(_$tr);
                $("#table_fapiaomx").find(".mx_index").each(function(i) { $(this).html(i + 1) });

                if (isInit) this.initMX(_$tr, null);

                return _$tr;
            },
            deleteMX: function(obj) {
                if (this.getMXItems().length == 1) { alert("至少要保留一个开票信息"); return; }
                var _$tr = $(obj).closest("tr");
                if (_$tr.attr("data-fasongstatus") == "<%=(int)EyouSoft.Model.EnumType.FinStructure.FaPiaoFaSongStatus.已送出 %>") { alert("该发票已送出，不能删除"); return; }
                _$tr.remove();
                $("#table_fapiaomx").find(".mx_index").each(function(i) { $(this).html(i + 1) });
            },
            tongBuMX: function(obj) {
                var _$tr = $(obj).closest("tr");
                var _taiTou = $.trim(_$tr.find("input[name='txt_mx_taitou']").val());
                var _kaiPiaoDanWei = $.trim(_$tr.find("input[name='txt_mx_kaipiaodanwei']").val());
                var _faPiaoHao = $.trim(_$tr.find("input[name='txt_mx_fapiaohao']").val());
                var _mingXi = $.trim(_$tr.find("textarea[name='txt_mx_mingxi']").val());

                _$tr.nextAll("tr").each(function() {
                    var __$tr = $(this);
                    __$tr.find("input[name='txt_mx_taitou']").val(_taiTou);
                    __$tr.find("input[name='txt_mx_kaipiaodanwei']").val(_kaiPiaoDanWei);
                    __$tr.find("input[name='txt_mx_fapiaohao']").val(_faPiaoHao);
                    __$tr.find("textarea[name='txt_mx_mingxi']").val(_mingXi);
                });
            },
            formatJsonDateTime: function(jsonDateTime) {
                var _rgExp = /-?\d+/;
                var _matchResult = _rgExp.exec(jsonDateTime);
                var d = new Date(parseInt(_matchResult[0]));
                return d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); });
            $("#<%=txtKeHu.KeHuMingChengClientId %>,#<%=txtKeHu.KeHuIdClientId %>").attr("valid", "required").attr("errmsg", "请选择客户单位!");
            iPage.initMXS();            
        });
    </script>

</asp:Content>
