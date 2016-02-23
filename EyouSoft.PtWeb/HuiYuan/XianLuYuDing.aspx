<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XianLuYuDing.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.XianLuYuDing"
    MasterPageFile="~/MP/HuiYuan.Master" Title="线路预订" %>

<%@ Register Src="~/WUC/ZxsXinXi.ascx" TagName="ZxsXinXi" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10"></div>
    
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">线路预订</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 线路预订 &gt;&gt; 散客预订
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <uc1:zxsxinxi runat="server" id="ZxsXinXi1"></uc1:zxsxinxi>
    
    <asp:PlaceHolder runat="server" ID="phKuaiSuLianJie">
    <div class="yg_bar mt15">
        <ul>
            <li><a href="<%=XianLuXXUrl %>" target="_blank">线路详情</a></li>
            <li><a href="<%=XingChengDanUrl %>" target="_blank">打印行程</a></li>
        </ul>
    </div>
    <div style="clear:both; "></div>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder runat="server" ID="phGuanLianChanPin" Visible="false">
    <div class="tuanqi mt15">
        <ul class="fixed">
            <asp:Literal runat="server" ID="ltrGuanLianChanPin"></asp:Literal>            
        </ul>
    </div>
    <script type="text/javascript" src="/js/guanliankongweixianlu.rili.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#i_a_gengduoguanlianchanpin").click(function() {
                var _options = {};
                _options["obj"] = this;
                _options["qudate"] = '<%=QuDate.Value.ToString("yyyy-MM-dd") %>';
                _options["xianluid"] = '<%=XianLuId %>';
                glkwxlrili.init(_options);
            });
        });
    </script>    
    </asp:PlaceHolder>
    
    <form id="form1" runat="server">
    <div style="display:none;">
    <input type="hidden" id="txtKeHuLxrId" runat="server" />
    <input type="hidden" id="txtRouteLeiXing" runat="server" />
    <textarea id="txtJiaGeXinXi" runat="server" style="display:none;"></textarea>
    <input type="hidden" id="txtZxsId" runat="server" />
    </div>
    
    
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <td colspan="4" style="font-weight:bold; font-size:16px; text-align:center;">
                <asp:Literal runat="server" ID="ltrRouteName"></asp:Literal>
                <asp:Literal runat="server" ID="ltrChanPinBianMa"></asp:Literal>
                <asp:Literal runat="server" ID="ltrYuDingJiFen"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;" class="td_yuding_biaoti">出发地：</td>
            <td style="width:39%"><asp:Literal runat="server" ID="ltrQuChuFaDi"></asp:Literal></td>
            <td style="width: 120px; " class="td_yuding_biaoti">旅游天数：</td>
            <td><asp:Literal runat="server" ID="ltrTianShu"></asp:Literal></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">出团日期：</td>
            <td><asp:Literal runat="server" ID="ltrQuDate"></asp:Literal></td>
            <td class="td_yuding_biaoti">出发交通：</td>
            <td><asp:Literal runat="server" ID="ltrQuJiaoTong"></asp:Literal></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">返程日期：</td>
            <td><asp:Literal runat="server" ID="ltrHuiDate"></asp:Literal></td>
            <td class="td_yuding_biaoti">返程交通：</td>
            <td><asp:Literal runat="server" ID="ltrHuiJiaoTong"></asp:Literal></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">集合时间：</td>
            <td><asp:Literal runat="server" ID="ltrJiHeShiJian"></asp:Literal></td>
            <td class="td_yuding_biaoti">集合地点：</td>
            <td><asp:Literal runat="server" ID="ltrJiHeDiDian"></asp:Literal></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">送团信息：</td>
            <td><asp:Literal runat="server" ID="ltrSongTuanXinXi"></asp:Literal></td>
            <td class="td_yuding_biaoti">目的地接团方式：</td>
            <td><asp:Literal runat="server" ID="ltrMuDiDiJieTuanFangShi"></asp:Literal></td>
        </tr>
    </table>
    
    <asp:PlaceHolder runat="server" ID="phJiaGeXinXi">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <td style="width: 120px;" class="td_yuding_biaoti">门市价：</td>
            <td style="width: 39%;"><asp:Literal runat="server" ID="ltrMenShiJia"></asp:Literal></td>
            <td style="width: 120px;" class="td_yuding_biaoti">结算价：</td>
            <td><asp:Literal runat="server" ID="ltrJieSuanJia"></asp:Literal></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">全陪价：</td>
            <td><asp:Literal runat="server" ID="ltrQuanPeiJia"></asp:Literal></td>
            <td class="td_yuding_biaoti">单房差：</td>
            <td><asp:Literal runat="server" ID="ltrDanFangCha"></asp:Literal></td>
        </tr>
    </table>
    </asp:PlaceHolder>
    
    <div class="mt15" style="font-weight: bold; color: #2f2f2f;">以下预订信息请您填写&nbsp;&nbsp;<asp:Literal runat="server" ID="ltrXianDingRenShu"></asp:Literal></div>
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15">
        <tr>
            <td style="width: 120px;" class="td_yuding_biaoti"><span class="fred">*</span>成人数：</td>
            <td style="width: 39%;"><input type="text" class="input1" style="width: 150px;"  maxlength="2" id="txtChengRenShu" runat="server" /></td>
            <td style="width: 120px;" class="td_yuding_biaoti">儿童数：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="2"  id="txtErTongShu" runat="server"/></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">婴儿数：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="2" id="txtYingErShu" runat="server"/></td>
            <td class="td_yuding_biaoti">全陪数：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="2" id="txtQuanPeiShu" runat="server" /></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">不占位人数：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="20" id="txtBuZhanWeiShu" runat="server" /></td>
            <td class="td_yuding_biaoti">占位人数：</td>
            <td><span id="i_span_zhanweishu"><asp:Literal runat="server" ID="ltrZhanWeiShu" /></span></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">补房差数量：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="2" id="txtBuFangChaShu" runat="server"/></td>
            <td class="td_yuding_biaoti">退房差数量：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="2"  id="txtTuiFangChaShu" runat="server"/></td>
        </tr>
        
        <asp:PlaceHolder runat="server" ID="phJiaJinE" Visible="false">
        <tr>
            <td class="td_yuding_biaoti">增加费用：</td>
            <td><input type="text" class="input1 input_readonly" style="width: 150px;" maxlength="2" id="txtJiaJinE" runat="server" readonly="readonly"/></td>
            <td class="td_yuding_biaoti">增加备注：</td>
            <td><input type="text" class="input1 input_readonly" style="width: 250px;" maxlength="2"  id="txtJiaJinEBeiZhu" runat="server" readonly="readonly"/></td>
        </tr>
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="phJianJinE" Visible="false">
        <tr>
            <td class="td_yuding_biaoti">减少费用：</td>
            <td><input type="text" class="input1 input_readonly" style="width: 150px;" maxlength="2" id="txtJianJinE" runat="server" readonly="readonly"/></td>
            <td class="td_yuding_biaoti">减少备注：</td>
            <td><input type="text" class="input1 input_readonly" style="width: 250px;" maxlength="2"  id="txtJianJinEBeiZhu" runat="server"  readonly="readonly"/></td>
        </tr>
        </asp:PlaceHolder>
        
        <tr>
            <td class="td_yuding_biaoti">价格明细：</td>
            <td colspan="3"><span id="i_span_jiagemingxi"><asp:Literal runat="server" ID="ltrJiaGeMingXi"></asp:Literal></span><input type="hidden" id="txtJiaGeMingXi" runat="server" /></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">结算金额：</td>
            <td colspan="3"><span id="i_span_jine"><asp:Literal runat="server" ID="ltrJinE"></asp:Literal></span><input type="hidden" id="txtJinE" runat="server" /></td>
        </tr>
        <asp:PlaceHolder runat="server" ID="phJiFen">
        <tr>
            <td class="td_yuding_biaoti">积分：</td>
            <td colspan="3"><span id="i_span_jifen"><asp:Literal runat="server" ID="ltrJiFen"></asp:Literal></span></td>
        </tr>
        </asp:PlaceHolder>
        <tr>
            <td class="td_yuding_biaoti"><span class="fred">*</span>联系人姓名：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="10" id="txtDingDanLxrXingMing" runat="server"/></td>
            <td class="td_yuding_biaoti"><span class="fred">*</span>联系人手机：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="20" id="txtDingDanLxrShouJi" runat="server" /></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti"><span class="fred">*</span>联系人电话：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="20"  id="txtDingDanLxrDianHua" runat="server"/></td>
            <td class="td_yuding_biaoti">联系人传真：</td>
            <td><input type="text" class="input1" style="width: 150px;" maxlength="20"  id="txtDingDanLxrFax" runat="server"/></td>
        </tr>
        <tr>
            <td class="td_yuding_biaoti">下单备注：</td>
            <td colspan="3"><textarea class="input1" cols="100" rows="3" style="height:auto;" id="txtXiaDanBeiZhu" runat="server"></textarea></td>
        </tr>
        <tr id="i_tr_quxiaoyuanyin" style="display:none;">
            <td class="td_yuding_biaoti">取消原因：</td>
            <td colspan="3"><textarea class="input1" cols="100" rows="3" style="height:auto;" id="txtQuXiaoYuanYin" runat="server"></textarea></td>
        </tr>
    </table>
    
    <div class="mt15" style="font-weight: bold; color: #2f2f2f;">请您填写游客信息<span style="color:#ff0000;">（请务必提供准确名单及证件号，若因提供名单有误造成损失自负，谢谢支持！）</span></div>
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist mt15" style="text-align:center;" id="table_youke">
        <tr>
            <td class="td_yuding_biaoti" style="text-align:center;width:40px;">序号</td>
            <td class="td_yuding_biaoti" style="text-align:center;">姓名</td>
            <td class="td_yuding_biaoti" style="text-align: center; width: 60px;">类型</td>
            <td class="td_yuding_biaoti" style="text-align:center;width:110px;">性别</td>
            <td class="td_yuding_biaoti" style="text-align:center;width:110px;">证件类型</td>
            <td class="td_yuding_biaoti" style="text-align:center;">证件号码</td>
            <td class="td_yuding_biaoti" style="text-align:center;">联系方式</td>            
        </tr>        
    </table>
    
    <div style="margin-top: 10px; color: #2f2f2f;"><b><asp:Literal runat="server" ID="ltrXiaoXi"></asp:Literal></b></div>
    
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 0px auto;
        margin-top: 15px; margin-bottom: 15px;">
        <tr>
            <td style="text-align: left;">
                <asp:Literal runat="server" ID="ltrCaoZuo"></asp:Literal>
                <a href="javascript:history.back();" class="baocun">返 回</a>
            </td>
        </tr>
    </table>
    </form>
    
    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            getYouKeRenShu: function() {
                var _data = { chengRen: 0, erTong: 0, yingEr: 0, quanPei: 0, zong: 0, zhanWei: 0, buZhanWei: 0, tuiFangCha: 0, buFangCha: 0 };
                _data.chengRen = tableToolbar.getInt($("#<%=txtChengRenShu.ClientID %>").val());
                _data.erTong = tableToolbar.getInt($("#<%=txtErTongShu.ClientID %>").val());
                _data.yingEr = tableToolbar.getInt($("#<%=txtYingErShu.ClientID %>").val());
                _data.quanPei = tableToolbar.getInt($("#<%=txtQuanPeiShu.ClientID %>").val());

                _data.buZhanWei = tableToolbar.getInt($("#<%=txtBuZhanWeiShu.ClientID %>").val());
                _data.zong = _data.chengRen + _data.erTong + _data.yingEr + _data.quanPei;
                _data.zhanWei = _data.zong - _data.buZhanWei;

                _data.tuiFangCha = tableToolbar.getInt($("#<%=txtTuiFangChaShu.ClientID %>").val());
                _data.buFangCha = tableToolbar.getInt($("#<%=txtBuFangChaShu.ClientID %>").val());

                return _data;
            },
            getYouKeItems: function() {
                return $("#table_youke").find(".tr_youke_item");
            },
            getKeShanChuYouKeItems: function() {
                var _items = this.getYouKeItems();
                var _items1 = [];
                if (_items.length == 0) return _items1;
                for (var i = 0; i < _items.length; i++) {
                    var _item = $(_items[i]);
                    var _chuPiaoStatus = _item.attr("data-chupiaostatus");
                    var _youKeStatus = _item.attr("data-youkestatus");

                    if (_chuPiaoStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>"
                        && _youKeStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团 %>") {
                        _items1.push(_item);
                    }
                }

                return _items1;
            },
            tianJiaYouKe: function(data) {
                var _s = [];
                _s.push('<tr class="tr_youke_item" data-chupiaostatus="<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>" data-youkestatus="<%=(int)EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团 %>">');
                _s.push('<td><span class="youke_index">1</span></td>')
                _s.push('<td><input type="hidden" name="txtYouKeId"/><input type="text" class="input1" style="width: 150px;" name="txtYouKeXingMing" maxlength="20" /></td>');
                _s.push('<td><span class="youke_leixing">成人</span><input type="hidden" name="txtYouKeLeiXing" /></td>');
                _s.push('<td><select name="txtYongKeXingBie"><option value="">-请选择-</option><option value="1">女</option><option value="2">男</option></select></td>');
                _s.push('<td><select name="txtYouKeZhengJianLeiXing"><option value="0">-请选择-</option><option value="1">身份证</option><option value="2">军官证</option><option value="3">台胞证</option><option value="4">港澳通行证</option><option value="5">户口本</option><option value="6">护照</option></select></td>');
                _s.push('<td><input type="text" class="input1" style="width: 200px;" name="txtYongKeZhengJianHaoMa" maxlength="20" /></td>');
                _s.push('<td><input type="text" class="input1" style="width: 150px;" name="txtYongKeLianXiFangShi" maxlength="20" /></td>')

                var _$tr = $(_s.join(''));

                var _youKeLeiXing = ["儿童", "成人", "军残", "婴儿", "全陪"];

                if (typeof data != "undefined" && data != null) {
                    _$tr.find('input[name="txtYouKeId"]').val(data.TravellerId);
                    _$tr.find('input[name="txtYouKeXingMing"]').val(data.TravellerName);
                    _$tr.find('span.youke_leixing').html(_youKeLeiXing[data.TravellerType]);
                    _$tr.find('input[name="txtYouKeLeiXing"]').val(data.TravellerType);
                    _$tr.find('select[name="txtYongKeXingBie"]').val(data.Sex);
                    _$tr.find('select[name="txtYouKeZhengJianLeiXing"]').val(data.CardType);
                    _$tr.find('input[name="txtYongKeZhengJianHaoMa"]').val(data.CardNumber);
                    _$tr.find('input[name="txtYongKeLianXiFangShi"]').val(data.Contact);

                    _$tr.attr("data-chupiaostatus", data.TicketType);
                    _$tr.attr("data-youkestatus", data.TravellerStatus);
                }

                $("#table_youke").append(_$tr);
            },
            initYouKeLeiXing: function() {
                var _data = this.getYouKeRenShu();
                var _items = this.getYouKeItems();

                for (var i = 0; i < _data.chengRen; i++) {
                    _items.eq(i).find("span.youke_leixing").html("成人");
                    _items.eq(i).find("input[name='txtYouKeLeiXing']").val("1");
                }

                for (var i = 0; i < _data.erTong; i++) {
                    _items.eq(_data.chengRen + i).find("span.youke_leixing").html('儿童');
                    _items.eq(_data.chengRen + i).find("input[name='txtYouKeLeiXing']").val("0");
                }

                for (var i = 0; i < _data.yingEr; i++) {
                    _items.eq(_data.chengRen + _data.erTong + i).find("span.youke_leixing").html('婴儿');
                    _items.eq(_data.chengRen + _data.erTong + i).find("input[name='txtYouKeLeiXing']").val('3');
                }

                for (var i = 0; i < _data.quanPei; i++) {
                    _items.eq(_data.chengRen + _data.erTong + _data.yingEr + i).find("span.youke_leixing").html('全陪');
                    _items.eq(_data.chengRen + _data.erTong + _data.yingEr + i).find("input[name='txtYouKeLeiXing']").val('4')
                }
            },
            initYouKeIndex: function() {
                var _items = this.getYouKeItems();
                _items.each(function(i) {
                    $(this).find("span.youke_index").html(i + 1);
                });
            },
            initYouKe: function() {
                var _data = this.getYouKeRenShu();
                var _renshu = this.getYouKeItems().length;

                if (_data.zong > _renshu) {
                    for (var i = 0; i < _data.zong - _renshu; i++) this.tianJiaYouKe(null);
                } else {
                    for (var i = 0; i < _renshu - _data.zong; i++) {
                        var _items = this.getYouKeItems();
                        if (_items.length == 1) break;
                        var _items1 = this.getKeShanChuYouKeItems();
                        if (_items1.length == 0) break;
                        _items1[_items1.length - 1].remove();
                    }
                }
                this.initYouKeIndex();
                this.initYouKeLeiXing();
            },
            heJiRenShu: function() {
                var _data = this.getYouKeRenShu();
                $("#i_span_zhanweishu").html('共计' + _data.zong + '人，其中不占位' + _data.buZhanWei + '人，占位' + _data.zhanWei + '人');
                this.initYouKe();
            },
            initYouKeRpt: function() {
                if (typeof youKe == "undefined") { this.tianJiaYouKe(); return; }

                if (youKe != null && youKe.length > 0) {
                    for (var i = 0; i < youKe.length; i++) {
                        this.tianJiaYouKe(youKe[i]);
                    }
                }

                var _data = this.getYouKeRenShu();
                var _youKeItems = this.getYouKeItems();

                if (_youKeItems.length < _data.zong) {
                    for (var i = 0; i < _data.zong - _youKeItems.length; i++) this.tianJiaYouKe();
                }

                this.initYouKeIndex();
                this.initYouKeLeiXing();
            },
            heJiJinE: function() {
                var _data = this.getYouKeRenShu();
                var _s = [];
                var _jinE = 0;

                var _chengRenJinE = tableToolbar.calculate(_data.chengRen, jiaGeXinXi.JieSuanJiaGe1, "*");
                var _erTongJinE = tableToolbar.calculate(_data.erTong, jiaGeXinXi.JieSuanJiaGe2, "*");
                var _yingErJinE = tableToolbar.calculate(_data.yingEr, jiaGeXinXi.JieSuanJiaGe3, "*");
                var _quanPeiJinE = tableToolbar.calculate(_data.quanPei, jiaGeXinXi.QuanPeiJiaGe, "*");
                var _buFangChaJinE = tableToolbar.calculate(_data.buFangCha, jiaGeXinXi.BuFangChaJiaGe, "*");
                var _tuiFangChaJinE = tableToolbar.calculate(_data.tuiFangCha, jiaGeXinXi.TuiFangChaJiaGe, "*");

                var _jiFen = tableToolbar.calculate(_data.chengRen, jiaGeXinXi.JiFen1, "*");

                _jinE = tableToolbar.calculate(_jinE, _chengRenJinE, "+");
                _jinE = tableToolbar.calculate(_jinE, _erTongJinE, "+");
                _jinE = tableToolbar.calculate(_jinE, _yingErJinE, "+");
                _jinE = tableToolbar.calculate(_jinE, _buFangChaJinE, "+");
                _jinE = tableToolbar.calculate(_jinE, _quanPeiJinE, "+");
                _jinE = tableToolbar.calculate(_jinE, _tuiFangChaJinE, "-");
                _jinE = tableToolbar.calculate(_jinE, jiaGeXinXi.JiaJinE, "+");
                _jinE = tableToolbar.calculate(_jinE, jiaGeXinXi.JianJinE, "-");

                if (_data.chengRen > 0) {
                    _s.push("+");
                    _s.push(jiaGeXinXi.JieSuanJiaGe1.toFixed(2) + "*" + _data.chengRen);
                }
                if (_data.erTong > 0) {
                    _s.push("+");
                    _s.push(jiaGeXinXi.JieSuanJiaGe2.toFixed(2) + "*" + _data.erTong);
                }
                if (_data.yingEr > 0) {
                    _s.push("+");
                    _s.push(jiaGeXinXi.JieSuanJiaGe3.toFixed(2) + "*" + _data.yingEr);
                }
                if (_data.quanPei > 0) {
                    _s.push("+");
                    _s.push(jiaGeXinXi.QuanPeiJiaGe.toFixed(2) + "*" + _data.quanPei);
                }

                if (_data.buFangCha > 0) {
                    _s.push("+");
                    _s.push(jiaGeXinXi.BuFangChaJiaGe.toFixed(2) + "*" + _data.buFangCha);
                }

                if (_data.tuiFangCha > 0) {
                    _s.push("-");
                    _s.push(jiaGeXinXi.TuiFangChaJiaGe.toFixed(2) + "*" + _data.tuiFangCha);
                }

                if (jiaGeXinXi.JiaJinE > 0) {
                    _s.push("+");
                    _s.push(jiaGeXinXi.JiaJinE.toFixed(2));
                }

                if (jiaGeXinXi.JianJinE > 0) {
                    _s.push("-");
                    _s.push(jiaGeXinXi.JianJinE.toFixed(2));
                }

                if (_s.length > 0 && (_s[0] == "+" || _s[0] == "-")) _s[0] = "";

                $("#i_span_jiagemingxi").html(_s.join(''));
                $("#<%=txtJiaGeMingXi.ClientID %>").val(_s.join(''));
                $("#i_span_jine").html(_jinE.toFixed(2));
                $("#<%=txtJinE.ClientID %>").val(_jinE.toFixed(2));
                $("#i_span_jifen").html('此次预订成功结束后您将获得 <span class="yuding_jifen1">' + _jiFen + '</span> 个积分');
            },
            webForm_OnSubmit_Validate: function() {
                var _data = this.getYouKeRenShu();
                if (_data.zong < 1) { alert("请填写预订人数"); return false; }
                if (_data.buZhanWei > _data.zong) { alert("请正确填写不占位人数"); return false; }
                if (_data.tuiFangCha > _data.zong) { alert("请正确填写退房差人数"); return false; }

                if ($.trim($("#<%=txtDingDanLxrXingMing.ClientID%>").val()).length == 0) { alert("请填写联系人姓名"); return false; }
                if ($.trim($("#<%=txtDingDanLxrShouJi.ClientID%>").val()).length == 0) { alert("请填写联系人手机"); return false; }
                if (!RegExps.isMobile.test($.trim($("#<%=txtDingDanLxrShouJi.ClientID%>").val()))) { alert("请填写正确的联系人手机"); return false; }
                if ($.trim($("#<%=txtDingDanLxrDianHua.ClientID%>").val()).length == 0) { alert("请填写联系人电话"); return false; }
                if (!RegExps.isPhone.test($.trim($("#<%=txtDingDanLxrDianHua.ClientID%>").val()))) { alert("请填写正确的联系人电话"); return false; }
                if ($.trim($("#<%=txtDingDanLxrFax.ClientID%>").val()).length > 0 && !RegExps.isPhone.test($.trim($("#<%=txtDingDanLxrFax.ClientID%>").val()))) { alert("请填写正确的联系人传真"); return false; }

                return true;
            },
            submit: function(obj) {
                if (!this.webForm_OnSubmit_Validate()) return false;

                $(obj).unbind("click").text("正在处理");
                var _data = $("#<%=form1.ClientID %>").serialize();
                var _self = this;
                $.ajax({ type: "post", url: window.location.href + "&dotype=submit", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        $(obj).click(function() { return _self.submit(this); }).text("提 交");
                        if (response.result == "1") _self.reload();
                    }
                });
            },
            quXiao: function(obj) {
                $("#i_tr_quxiaoyuanyin").show();
                var _data = { txtQuXiaoYuanYin: $.trim($("#<%=txtQuXiaoYuanYin.ClientID %>").val()) };
                if (_data.txtQuXiaoYuanYin.length < 1) { alert("请输入取消原因"); $("#<%=txtQuXiaoYuanYin.ClientID %>").focus(); return false; }
                if (!confirm("你确定要取消该订单吗？")) return false;
                var _self = this;
                $(obj).unbind("click").text("正在处理");
                $.ajax({ type: "post", url: window.location.href + "&dotype=quxiao", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        $(obj).click(function() { return _self.quXiao(this); }).text("取 消");
                        if (response.result == "1") _self.reload();
                    }
                });
            },
            huiFu: function(obj) {
                if (!confirm("你确定要恢复该订单吗？")) return false;
                var _data = {};
                var _self = this;
                $(obj).unbind("click").text("正在处理");
                $.ajax({ type: "post", url: window.location.href + "&dotype=huifu", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        $(obj).click(function() { return _self.huiFu(this); }).text("恢 复");
                        if (response.result == "1") _self.reload();
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#<%=txtChengRenShu.ClientID %>,#<%=txtErTongShu.ClientID %>,#<%=txtYingErShu.ClientID %>,#<%=txtQuanPeiShu.ClientID %>,#<%=txtBuZhanWeiShu.ClientID %>").keyup(function() { iPage.heJiRenShu(); });
            $("#<%=txtChengRenShu.ClientID %>,#<%=txtErTongShu.ClientID %>,#<%=txtYingErShu.ClientID %>,#<%=txtQuanPeiShu.ClientID %>,#<%=txtBuZhanWeiShu.ClientID %>,#<%=txtBuFangChaShu.ClientID %>,#<%=txtTuiFangChaShu.ClientID %>").change(function() { iPage.heJiJinE(); iPage.heJiRenShu(); });
            iPage.initYouKeRpt();

            $("#i_a_submit").click(function() { iPage.submit(this); });
            $("#i_a_quxiao").click(function() { iPage.quXiao(this); });
            $("#i_a_huifu").click(function() { iPage.huiFu(this); });
        });
    </script>
</asp:Content>
