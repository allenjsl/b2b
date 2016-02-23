<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanHotelMX.aspx.cs" Inherits="Web.TeamPlan.PlanHotelMX"
    MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 950px; margin: 10px auto;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="even">
                <td width="36" height="30" align="center">
                    编号
                </td>
                <td align="center" style="width:100px;">
                    入住时间
                </td>
                <td align="center" style="width: 100px;">
                    退房时间
                </td>
                <td align="center" style="width: 100px;">
                    房型
                </td>
                <td align="center">
                    组团社要求
                </td>
                <td align="center" style="width: 100px;">
                    间夜
                </td>
                <td align="center" style="width: 100px;">
                    取房方式
                </td>
                <td align="center" style="width: 100px;">
                    酒店名称
                </td>                
                <td align="center" style="width:110px;">
                    操作
                </td>
            </tr>
            <tr class="even tempRow">
                <td width="36" height="30" align="center" class="index">
                    1
                </td>
                <td align="center">
                    <input type="text" name="txtRuZhuTime" class="formsize80 inputtext" onfocus="WdatePicker()" />
                </td>
                <td align="center">
                    <input type="text" name="txtTuiFangTime" class="formsize80 inputtext" onfocus="WdatePicker()" />
                </td>
                <td align="center">
                    <input type="text" name="txtFangXing" class="formsize80 inputtext" />
                </td>
                <td align="center">
                    <input type="text" name="txtYaoQiuBeiZhu" class="formsize180 inputtext" />
                </td>
                <td align="center">
                    <input type="text" name="txtJianYe" class="formsize80 inputtext" />
                </td>
                <td align="center">
                    <input type="text" name="txtQuFangFangShi" class="formsize80 inputtext" />
                </td>
                <td align="center">
                    <input type="text" name="txtJiuDianName" class="formsize80 inputtext" />
                </td>
                <td align="center">
                    <a href="javascript:void(0)" class="addbtn">
                        <img src="/images/addimg.gif" width="48" height="20" /></a> <a href="javascript:void(0)"
                            class="delbtn">
                            <img src="/images/delimg.gif" width="48" height="20" /></a>
                </td>
            </tr>            
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <a href="javascript:void(0)" id="i_a_queding">确定</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript" src="/js/json2.js"></script>
    <script type="text/javascript">
        var iPage = {
            txtid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtid") %>',
            refereriframeid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("refereriframeid") %>',
            txtisrptid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("txtisrptid") %>',
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            isRpt: function() {
                var _win = top.Boxy.getIframeDocument(this.refereriframeid);
                if (!_win) _win = parent.window.document;
                var s = $(_win).find("#" + this.txtisrptid).val();
                return s == "1";
            },
            //获取引用窗体值
            getPV: function() {
                var _win = top.Boxy.getIframeDocument(this.refereriframeid);
                if (!_win) _win = parent.window.document;
                var s = $(_win).find("#" + this.txtid).val();
                if (typeof (s) == "undefined") s = null;
                if (s == "undefined" || s == null || s == "null" || s.length == 0 || s == "[]") return [];
                return JSON.parse(s);
            },
            //设置引用窗体值
            setPV: function(_v) {
                var _win = top.Boxy.getIframeDocument(this.refereriframeid);
                if (!_win) _win = parent.window.document;
                var s = JSON.stringify(_v);
                $(_win).find("#" + this.txtid).val(s);
            },
            //初始化
            init: function() {
                var _v = this.getPV();
                if (_v.length == 0) return;
                var i1 = this.isRpt() ? 1 : 0;
                for (var i = i1; i < _v.length; i++) {
                    var _$addbtnobjs = $("#i_table_form a.addbtn");
                    var _$addbtnobj = $(_$addbtnobjs[_$addbtnobjs.length - 1]);
                    var _$trobj = _$addbtnobj.closest("tr");
                    var _data = _v[i];

                    _$trobj.find("input[name='txtRuZhuTime']").val(_data.RuZhuTime);
                    _$trobj.find("input[name='txtTuiFangTime']").val(_data.TuiFangTime);
                    _$trobj.find("input[name='txtFangXing']").val(_data.FangXing);
                    _$trobj.find("input[name='txtYaoQiuBeiZhu']").val(_data.YaoQiuBeiZhu);
                    _$trobj.find("input[name='txtJianYe']").val(_data.JianYe);
                    _$trobj.find("input[name='txtQuFangFangShi']").val(_data.QuFangFangShi);
                    _$trobj.find("input[name='txtJiuDianName']").val(_data.JiuDianName);

                    _$addbtnobj.click();
                }
            },
            //确认按钮click
            queDing: function() {
                var _$trobjs = $("#i_table_form tr.tempRow");
                var _data = [];

                if (this.isRpt()) {
                    var _pv = this.getPV();
                    if (_pv.length > 0) _data.push(_pv[0]);
                }

                for (var i = 0; i < _$trobjs.length; i++) {
                    var _$trobj = $(_$trobjs[i]);
                    var _v = { "RuZhuTime": "", "TuiFangTime": "", "FangXing": "", "YaoQiuBeiZhu": "", "JianYe": "", "QuFangFangShi": "", "JiuDianName": "" };
                    _v.RuZhuTime = $.trim(_$trobj.find("input[name='txtRuZhuTime']").val());
                    _v.TuiFangTime = $.trim(_$trobj.find("input[name='txtTuiFangTime']").val());
                    _v.FangXing = $.trim(_$trobj.find("input[name='txtFangXing']").val());
                    _v.YaoQiuBeiZhu = $.trim(_$trobj.find("input[name='txtYaoQiuBeiZhu']").val());
                    _v.JianYe = $.trim(_$trobj.find("input[name='txtJianYe']").val());
                    _v.QuFangFangShi = $.trim(_$trobj.find("input[name='txtQuFangFangShi']").val());
                    _v.JiuDianName = $.trim(_$trobj.find("input[name='txtJiuDianName']").val());

                    if (_v.RuZhuTime.length == 0 && _v.TuiFangTime.length == 0
                    && _v.FangXing.length == 0 && _v.YaoQiuBeiZhu.length == 0
                    && _v.JianYe.length == 0 && _v.QuFangFangShi.length == 0
                    && _v.JiuDianName.length == 0) continue;

                    _data.push(_v);
                }

                this.setPV(_data);
                this.close();
            }
        };
        $(document).ready(function() {
            $("#i_table_form").autoAdd({});
            iPage.init();
            $("#i_a_queding").click(function() { iPage.queDing(); });
        });        
    </script>
</asp:Content>
