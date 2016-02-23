<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanAdd.aspx.cs" Inherits="Web.TeamPlan.PlanAdd"
    EnableEventValidation="false" %>

<%@ Register Src="../UserControl/CustomerRequiredControl.ascx" TagName="CustomerRequiredControl"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControl/RouteSelect.ascx" TagName="RouteSelect" TagPrefix="uc3" %>
<%@ Register Src="../UserControl/OrderCustomer.ascx" TagName="OrderCustomer" TagPrefix="uc4" %>
<%@ Register Src="~/UserControl/KeHuXuanZe.ascx" TagName="KeHuXuanZe" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>常规业务-剩余位置</title>
    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="/js/datepicker/wdatepicker.js"></script>
    <script type="text/javascript" src="/js/validatorform.js"></script>
    <script type="text/javascript" src="/js/table-toolbar.js"></script>
    <script type="text/javascript" src="/js/jquery.blockUI.js"></script>
    <script src="/js/swfupload/swfupload.js" type="text/javascript"></script>
    <link href="/css/sytle.css" rel="stylesheet" type="text/css" />
    <link href="/css/swfupload/default.css" rel="stylesheet" type="text/css" />
    <link href="/Css/boxy.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="txtXianLuLeiXing" name="txtXianLuLeiXing" value="jihuanei" runat="server" />
    <input type="hidden" id="txtXianLuId" runat="server" />
    
    <div style="width: 99%; margin: 0 auto; margin-top:5px">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tableform">
            <tbody>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        <span class="fred">*</span>业务类型：
                    </th>
                    <td width="350" bgcolor="#E3F1FC">
                        <select class="inputselect" id="sltYewutype" name="sltYewutype" errmsg="请选择业务类型!"
                            valid="required">
                            <option value="">请选择</option>
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.BusinessType), new string[] { "3" }), "") %>
                        </select>
                    </td>
                    <th width="120" align="right">
                        <span class="fred">*</span>性质：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select class="inputselect" id="sltxingzhi" name="sltxingzhi">
                            <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.BusinessNature)), "") %>
                        </select>
                    </td>
                </tr>
                <tr class="odd" data-class="route">
                    <th height="30" align="right">
                        <span class="fred">*</span>线路名称：
                    </th>
                    <td bgcolor="#E3F1FC" data-class="route" colspan="3">
                        <uc3:RouteSelect ID="RouteSelect1" runat="server" IsShowTitle="false" IsMoreSelect="false" />
                        
                        <div id="i_div_jihuaneixianlu">
                        <select id="txtJiHuaNeiXianLu" name="txtJiHuaNeiXianLu" class="inputselect" errmsg="请选择线路产品" valid="required">
                            <option value="">请选择线路产品</option>
                        </select>
                        <a href="javascript:void(0)" id="i_a_jihuawaixianlu" data-lx="jihuawai">选择计划外线路产品</a>
                        </div>
                    </td>
                </tr>
                <tr class="odd"  id="i_tr_jihuaneijiagexinxi" style="display:none;">
                    <th height="30" align="right">
                        价格信息：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3" id="i_td_jihuaneijiagexinxi">
                        
                    </td>
                </tr>    
                <tr class="odd">
                    <th height="30" align="right">
                        成人数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        人数：<asp:TextBox ID="txtAdultCount" CssClass="formsize50 inputtext" runat="server" valid="isInt|range" errmsg="人数必须是数字|人数必须大于0" min="0" data-renshu-txt="chengren"></asp:TextBox>
                        单价：<input type="text" id="txtChengRenJiaGe" runat="server" class="inputtext formsize50" />
                    </td>
                    <th align="right">
                        儿童数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        人数：<asp:TextBox ID="txtChildCount" valid="isInt|range" errmsg="人数必须是数字|人数必须大于0" CssClass="formsize50 inputtext" runat="server" min="0" data-renshu-txt="ertong"></asp:TextBox>
                        单价：<input type="text" id="txtErTongJiaGe" runat="server" class="inputtext formsize50" />
                    </td>
                </tr>
                 <tr class="odd">
                    <th height="30" align="right">
                        婴儿数：
                    </th>
                    <td bgcolor="#E3F1FC">
                        人数：<input type="text" id="txtYingErShu" runat="server" class="inputtext formsize50" valid="isInt|range" errmsg="人数必须是数字|人数必须大于0" min="0" data-renshu-txt="yinger" />
                        单价：<input type="text" id="txtYingErJiaGe" runat="server" class="inputtext formsize50" />
                    </td>
                    <th align="right">
                        全陪数：
                    </th>
                    <td bgcolor="#E3F1FC">
                       人数：<asp:TextBox ID="txtQuanPeiCount" valid="isInt|range" errmsg="人数必须是数字|人数必须大于0" CssClass="formsize50 inputtext" runat="server" min="0" data-renshu-txt="quanpei"></asp:TextBox>
                       单价：<input type="text" id="txtQuanPeiJiaGe" runat="server" class="inputtext formsize50" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        占位数量：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtSeatCount" valid="isInt|required" errmsg="人数必须是数字|人数不能为空"
                            CssClass="formsize50 inputtext" runat="server"></asp:TextBox>
                        <span class="errmsg"><asp:Literal ID="lbcount" runat="server"></asp:Literal></span>
                    </td>
                    <th align="right">
                        不占位数量：
                    </th>
                    <td bgcolor="#E3F1FC">
                         共计<span id="span_zongrenshu">0</span>人，其中<span id="span_buzhanweirenshu">0</span>人不占位
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>客户单位：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <uc1:KeHuXuanZe runat="server" id="txtKeHu" DuiFangCaoZuoRenClientId="txtDuiFangCaoZuoRen"></uc1:KeHuXuanZe>
                    </td>
                    <th align="right">
                        <span class="fred">*</span>对方操作人：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtDuiFangCaoZuoRen" id="txtDuiFangCaoZuoRen" errmsg="请选择对方操作人" valid="required" class="inputselect" data-v="<%=DuiFangCaoZuoRenId %>">
                            <option value="">请选择客户单位</option>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>客户联系人姓名：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="txtKeHuLxrName" runat="server" class="inputtext formsize50"
                            errmsg="请输入客户联系人姓名!" valid="required"  style="width:100px;"/>
                    </td>
                    <th align="right">
                        <span class="fred">*</span>客户联系人电话：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="txtKeHuLxrDianHua" runat="server" class="inputtext formsize50"
                            errmsg="请输入客户联系人电话!" valid="required"  style="width:100px;"/>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>客户联系人手机：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="txtKeHuLxrShouJi" runat="server" class="inputtext"
                            errmsg="请输入客户联系人手机!" valid="required" style="width:100px;" />
                    </td>
                    <th align="right">
                        客户联系人传真：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="txtKeHuLxrFax" runat="server" class="inputtext formsize50" style="width:100px;" />
                    </td>
                </tr>            
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>产品金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="txtDingDanJinE" runat="server" class="inputtext formsize50" errmsg="请输入产品金额!"
                            valid="required"/>
                    </td>
                    <th align="right">
                        发放积分：
                    </th>
                    <td bgcolor="#E3F1FC" style="vertical-alig:middle;">
                        单人积分：<input type="text" id="txtJiFen1" runat="server" class="inputtext formsize50" maxlength="3" />
                        总积分：<input type="text" id="txtJiFen2" runat="server" class="inputtext formsize50"
                            readonly="readonly" style="background: #dadada" />
                        <input type="checkbox" name="txtJiFenXianShiBiaoShi" id="txtJiFenXianShiBiaoShi"
                            style="vertical-align: middle;" value="1" title="勾选后该订单的发放积分在同行平台仅预订人可以查看" /><label for="txtJiFenXianShiBiaoShi" style="vertical-align: middle;" title="勾选后该订单的发放积分在同行平台仅预订人可以查看">仅对预订人显示</label>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        补单房差：
                    </th>
                    <td bgcolor="#E3F1FC">
                        单价：<input type="text" id="txtBuFangChaJiaGe" runat="server" class="inputtext formsize50" />
                        数量：<input type="text" id="txtBuFangChaShuLiang" runat="server" class="inputtext formsize50" />
                    </td>
                    <th height="30" align="right">
                        退单房差：
                    </th>
                    <td bgcolor="#E3F1FC">
                        单价：<input type="text" id="txtTuiFangChaJiaGe" runat="server" class="inputtext formsize50" />
                        数量：<input type="text" id="txtTuiFangChaShuLiang" runat="server" class="inputtext formsize50" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        增加费用：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input type="text" id="txtJiaJinE" runat="server" class="inputtext formsize50" />
                        备注：<input type="text" id="txtJiaBeiZhu" runat="server" class="inputtext" style="width:300px;" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        减少费用：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <input type="text" id="txtJianJinE" runat="server" class="inputtext formsize50" />
                        备注：<input type="text" id="txtJianBeiZhu" runat="server" class="inputtext" style="width:300px;" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        价格明细(自动)：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span id="i_span_jiagemingxi">
                            <asp:Literal runat="server" ID="ltrJiaGeMingXi"></asp:Literal></span><input type="hidden"
                                id="txtJiaGeMingXi" runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        价格明细：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <asp:TextBox ID="txtPriceDesc" MaxLength="200" CssClass="formsize260 inputtext" runat="server"></asp:TextBox>
                    </td>
                    <th align="right">
                        <span class="fred">*</span>总金额：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <input type="text" id="txtTotalMoney" class="formsize50 inputtext" runat="server" style="background:#dadada;" readonly="readonly" />
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        价格备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtPriceRemark" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        集合地点：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <select name="txtJiHeDiDian" id="txtJiHeDiDian" class="inputselect">
                            <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.集合地点) %>
                        </select>
                        <input type="text" id="txtJiHeDiDian1" runat="server" class="inputtext" style="width:250px;" maxlength="200" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        集合时间：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <select name="txtJiHeShiJian" id="txtJiHeShiJian" class="inputselect">
                                <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.集合时间) %>
                            </select>
                            <input type="text" id="txtJiHeShiJian1" runat="server" class="inputtext" style="width:250px;" maxlength="200" />
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        送团信息：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtSongTuanXinXi" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox><a id="i_a_songtuanxinxi_xuanyong" href="javascript:void(0);">
                            <img width="28" height="18" alt="选用" src="/images/sanping_04.gif" style="vertical-align: top;">
                        </a>                            
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        目的地接团方式：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtMuDiDiJieTuanFangShi" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox><a id="i_a_mudidijietuanfangshi_xuanyong" href="javascript:void(0);">
                            <img width="28" height="18" alt="选用" src="/images/sanping_04.gif" style="vertical-align: top;">
                        </a>                            
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        特殊要求说明：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtYaoqiuRemark" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        地接备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtGroundRemark" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        操作备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtOperatorRemark" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr class="odd">
                    <th align="right">
                        下单备注：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <span class="fblue">
                            <asp:TextBox ID="txtXiaDanBeiZhu" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputarea h75"
                                runat="server"></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <!--<tr class="odd">
                    <th align="right">
                        标识颜色：
                    </th>
                    <td bgcolor="#E3F1FC" colspan="3">
                        <select id="txtBiaoShiYanSe" name="txtBiaoShiYanSe">
                            <asp:Literal runat="server" ID="ltrBiaoShiYanSeOptions"></asp:Literal>
                        </select>
                    </td>
                </tr>-->
            </tbody>
        </table>
    </div>
    <uc4:OrderCustomer ID="OrderCustomer1" runat="server" />
    <uc1:CustomerRequiredControl ID="CustomerRequiredControl1" runat="server" />
    
    <asp:PlaceHolder runat="server" Visible="false" ID="ph_TiShiXinXi">
    <div style="width: 99%; margin: 0 auto;">        
        <asp:Literal runat="server" ID="ltrTiShiXinXi"></asp:Literal>
    </div>
    </asp:PlaceHolder>
    
    <div style="width: 99%; margin: 0 auto; margin-top:5px">        
        <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="left" colspan="14">
                        <asp:PlaceHolder ID="pdhAllBtns" runat="server">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <asp:PlaceHolder runat="server" ID="ph_ChengJiao">
                                            <td width="80" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:;" id="a_chengjiao" data-fs="chengjiao">确定成交</a>
                                            </td>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="ph_BaoCun" Visible="false">
                                            <td width="80" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:;" id="a_baocun" data-fs="baocun">保存</a>
                                            </td>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="ph_LiuWei">
                                            <td width="80" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:;" id="a_liuwei" data-fs="liuwei">确定留位</a>
                                            </td>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="ph_QuXiao" Visible="false">
                                            <td width="80" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:;" id="a_quxiao" data-fs="quxiao">取消订单</a>
                                            </td>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="ph_JuJue" Visible="false">
                                            <td width="80" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:;" id="a_jujue" data-fs="jujue">拒绝订单</a>
                                            </td>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="ph_HuiFu" Visible="false">
                                            <td width="80" height="40" align="center" class="tjbtn02">
                                                <a href="javascript:;" id="a_huifu" data-fs="huifu">恢复订单</a>
                                            </td>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="ph_HeSuanJieShu" Visible="false">
                                            <td>控位已核算结束</td>
                                        </asp:PlaceHolder>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:PlaceHolder>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>    
    </form>
    
    <script type="text/javascript">
        function songTuanXinXiXuanYong_callBack(_ret) {
            if (_ret.length == 0) return;

            var s = [];
            for (var i = 0; i < _ret.length; i++) {
                s.push(_ret[i]);
                s.push("\n");
            }

            var _$obj = $("#<%=txtSongTuanXinXi.ClientID %>");
            var _v = $.trim(_$obj.val());

            if (_v.length > 0) _v += "\n";

            _$obj.val(_v + s.join(""));
        }

        function muDiDiJieTuanFangShiXuanYong_callBack(_ret) {
            if (_ret.length == 0) return;

            var s = [];
            for (var i = 0; i < _ret.length; i++) {
                s.push(_ret[i]);
                s.push("\n");
            }

            var _$obj = $("#<%=txtMuDiDiJieTuanFangShi.ClientID %>");
            var _v = $.trim(_$obj.val());

            if (_v.length > 0) _v += "\n";

            _$obj.val(_v + s.join(""));
        }

        var PlanPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //验证表单
            yanZhengForm: function() {
                var _vForm = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!_vForm) return _vForm;

                var _vRenShu = this.yanZhengRenShu();
                if (!_vRenShu) return _vRenShu;

                var _jiFen1 = tableToolbar.getInt($("#<%=txtJiFen1.ClientID %>").val());
                if (_jiFen1 > 500) { alert("单人积分不能大于500分"); return false; }

                if ($.trim($("#<%=txtJiaGeMingXi.ClientID %>").val()).length < 1
                    && $.trim($("#<%=txtPriceDesc.ClientID %>").val()).length < 1) {
                    alert("请填写价格明细"); return false;
                }

                return true;
            },
            //获取表单录入的人数信息
            getYouKeRenShu: function() {
                var _data = { chengRen: 0, erTong: 0, yingEr: 0, quanPei: 0, zong: 0, zhanWei: 0, buZhanWei: 0, tuiFangCha: 0, buFangCha: 0 };
                _data.chengRen = tableToolbar.getInt($("#<%=txtAdultCount.ClientID %>").val());
                _data.erTong = tableToolbar.getInt($("#<%=txtChildCount.ClientID %>").val());
                _data.yingEr = tableToolbar.getInt($("#<%=txtYingErShu.ClientID %>").val());
                _data.quanPei = tableToolbar.getInt($("#<%=txtQuanPeiCount.ClientID %>").val());

                _data.zhanWei = tableToolbar.getInt($("#<%=txtSeatCount.ClientID %>").val());
                _data.zong = _data.chengRen + _data.erTong + _data.yingEr + _data.quanPei;
                _data.buZhanWei = _data.chengRen + _data.erTong + _data.yingEr + _data.quanPei - _data.zhanWei;

                _data.tuiFangCha = tableToolbar.getInt($("#<%=txtTuiFangChaShuLiang.ClientID %>").val());
                _data.buFangCha = tableToolbar.getInt($("#<%=txtBuFangChaShuLiang.ClientID %>").val());

                return _data;
            },
            //人数验证
            yanZhengRenShu: function() {
                var _data = this.getYouKeRenShu();
                var _yiChuPiaoRenShu = OrderCustomerControl.getYiChuPiaoRenShu();

                if (_data.zhanWei < _yiChuPiaoRenShu) {
                    alert("占位数量(" + _data.zhanWei + "人)不能小于已出票人数(" + _yiChuPiaoRenShu + "人)");
                    return false;
                }

                if (_data.zhanWei > _data.zong) {
                    if (_data.zhanWei > _yiChuPiaoRenShu) {
                        alert("占位数量(" + _data.zhanWei + "人)不能大于人数之和(" + _data.zong + "人)");
                        return false;
                    }
                }

                return true;
            },
            //根据录入人数信息计算统计信息：总人数、不占位数量
            initRenShuTongJi: function() {
                //$("#span_zongrenshu").html("0");
                //$("#span_buzhanweirenshu").html("0");

                //if (!this.yanZhengRenShu()) return;
                this.yanZhengRenShu();
                var _data = this.getYouKeRenShu();
                var _yiChuPiaoRenShu = OrderCustomerControl.getYiChuPiaoRenShu();

                $("#span_zongrenshu").html(_data.zong + "");

                if (_yiChuPiaoRenShu > _data.zong || _data.buZhanWei < 0) {
                    $("#span_buzhanweirenshu").html("0");
                } else {
                    $("#span_buzhanweirenshu").html(_data.buZhanWei + "");
                }
            },
            //统计占位人数
            heJiRenShu: function() {
                var _data = this.getYouKeRenShu();
                var _yiChuPiaoRenShu = OrderCustomerControl.getYiChuPiaoRenShu();
                if (_yiChuPiaoRenShu > _data.zong) $("#<%=txtSeatCount.ClientID %>").val(_yiChuPiaoRenShu);
                else $("#<%=txtSeatCount.ClientID %>").val(_data.zong);
                this.initRenShuTongJi();
                this.heJiDingDanJinE();
                this.initYouKe();
            },
            //按录入人数初始化名单录入信息
            initYouKe: function() {
                var _data = this.getYouKeRenShu();
                var _renshu = OrderCustomerControl.getYouKeRenShu();
                if (_data.zong == _renshu) return;

                if (_data.zong > _renshu) {
                    for (var i = 0; i < _data.zong - _renshu; i++) OrderCustomerControl.addCustomer(null);
                } else {
                    for (var i = 0; i < _renshu - _data.zong; i++) {
                        var _items = OrderCustomerControl.getYouKeItems();
                        if (_items.length == 1) break;
                        var _items1 = OrderCustomerControl.getKeShanChuYouKeItems();
                        if (_items1.length == 0) break;
                        _items1[_items1.length - 1].remove();
                    }
                }

                OrderCustomerControl.initIndex();
                //this.initYouKeLeiXing();
            },
            //按人数初始化人员类型（成人、儿童等）
            initYouKeLeiXing: function() {
                var _data = this.getYouKeRenShu();
                var _items = OrderCustomerControl.getYouKeItems();

                for (var i = 0; i < _data.chengRen; i++) {
                    _items.eq(i).find("select[name='ddl_OrderCustomer_CustomerType']").val("1");
                }

                for (var i = 0; i < _data.erTong; i++) {
                    _items.eq(_data.chengRen + i).find("select[name='ddl_OrderCustomer_CustomerType']").val("0");
                }

                for (var i = 0; i < _data.yingEr; i++) {
                    _items.eq(_data.chengRen + _data.erTong + i).find("select[name='ddl_OrderCustomer_CustomerType']").val("3");
                }

                for (var i = 0; i < _data.quanPei; i++) {
                    _items.eq(_data.chengRen + _data.erTong + _data.yingEr + i).find("select[name='ddl_OrderCustomer_CustomerType']").val("4");
                }

            },
            //送团信息选用
            songTuanXinXiXuanYong: function() {
                var _data = { jichuxinxitype: "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.送团信息 %>", callbackfn: "songTuanXinXiXuanYong_callBack", refereriframeid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                parent.Boxy.iframeDialog({ title: "选用送团信息", iframeUrl: "/systemset/JiChuXinXiXuanYong.aspx", width: "670px", height: "380px", data: _data, afterHide: function() { } });
                return false;
            },
            //目的地接团方式选用
            muDiDiJieTuanFangShiXuanYong: function() {
                var _data = { jichuxinxitype: "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.目的地接团方式 %>", callbackfn: "muDiDiJieTuanFangShiXuanYong_callBack", refereriframeid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                parent.Boxy.iframeDialog({ title: "选用送团信息", iframeUrl: "/systemset/JiChuXinXiXuanYong.aspx", width: "670px", height: "380px", data: _data, afterHide: function() { } });
                return false;
            },
            //提交表单
            baoCun: function(obj) {
                var _fs = $(obj).attr("data-fs");
                if (!PlanPage.yanZhengForm()) return false;
                var _url = window.location.href + "&dotype=" + _fs;
                var _renShuInfo = this.getYouKeRenShu();
                if (OrderCustomerControl.getYouXiaoYouKeRenShu() != _renShuInfo.zong) {
                    if (!confirm("总人数与填写的游客信息数量不相等,确定要继续吗？")) return false;
                }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: _url, data: $("#<%=form1.ClientID %>").serialize(), cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            PlanPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { PlanPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { PlanPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            },
            //线路类型切换
            changeXianLuLeiXing: function(obj) {
                var _data_lx = $(obj).attr("data-lx");

                $("#<%=txtXianLuLeiXing.ClientID %>").val(_data_lx);
                $("#<%=txtJiFen1.ClientID %>").val("0");
                this.initHS();
                this.heJiDingDanJinE();

                var _xianLuId = "", _routeId = "";
                if (_data_lx == "jihuawai") _routeId = $("#<%=RouteSelect1.HidClientId %>").val();
                if (_data_lx == "jihuanei") _xianLuId = $("#txtJiHuaNeiXianLu").val();
                this.initRouteXinXi(_routeId, _xianLuId);
            },
            //变更计划内线路
            changeJiHuaNeiXianLu: function() {
                this.initJiaGeXinXi();
                this.heJiDingDanJinE();
                var _xianLuId = $("#txtJiHuaNeiXianLu").val();
                this.initRouteXinXi("", _xianLuId);
            },
            //初始化计划内线路产品信息
            initJiHuaNeiXianLu: function() {
                if (typeof jiHuaNeiXianLu == "undefined") return;
                if (jiHuaNeiXianLu == null || jiHuaNeiXianLu.length == 0) return;
                var s = [];
                for (var i = 0; i < jiHuaNeiXianLu.length; i++) {
                    if (jiHuaNeiXianLu[i].LeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票 %>") continue;
                    s.push('<option value="' + jiHuaNeiXianLu[i].XianLuId + '">' + jiHuaNeiXianLu[i].RouteName + '&nbsp;&nbsp;[结算成人价：' + jiHuaNeiXianLu[i].JieSuanJiaGe1.toFixed(2) + ']</option>')
                }
                $("#txtJiHuaNeiXianLu").append(s.join(''));

                if (typeof dingDanJiaGe != "undefined" && dingDanJiaGe != null && dingDanJiaGe.XianLuId.length > 0) {
                    $("#txtJiHuaNeiXianLu").val(dingDanJiaGe.XianLuId);
                }
            },
            //业务类型变更
            changeYeWuLeiXing: function() {
                $("#<%=txtJiFen1.ClientID %>").val("0");
                this.initHS();
                this.heJiDingDanJinE();

                var _yeWuLeiXing = $("#sltYewutype").val();
                var _xianLuLeiXing = $("#<%=txtXianLuLeiXing.ClientID %>").val();
                var _xianLuId = "", _routeId = "";
                $("#<%=txtXianLuId.ClientID %>").val("");

                if (_yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游 %>"
                    || _yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制 %>"
                    || _yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行 %>") {
                    if (_xianLuLeiXing == "jihuawai") _routeId = $("#<%=RouteSelect1.HidClientId %>").val();
                    if (_xianLuLeiXing == "jihuanei") _xianLuId = $("#txtJiHuaNeiXianLu").val();
                }

                if (_yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票 %>" || _yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店 %>") {
                    if (typeof jiHuaNeiXianLu != "undefined" && jiHuaNeiXianLu != null && jiHuaNeiXianLu.length > 0) {
                        for (var i = 0; i < jiHuaNeiXianLu.length; i++) {
                            if (jiHuaNeiXianLu[i].LeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票 %>") $("#<%=txtXianLuId.ClientID %>").val(jiHuaNeiXianLu[i].XianLuId);
                        }
                    }
                }

                this.initRouteXinXi(_routeId, _xianLuId);
            },
            //显示、隐藏
            initHS: function() {
                var _yeWuLeiXing = $("#sltYewutype").val();
                var _xianLuLeiXing = $("#<%=txtXianLuLeiXing.ClientID %>").val();
                $("#<%=txtDingDanJinE.ClientID %>").removeAttr("readonly").css({ background: "#fff" });
                $("#txtRouteName").removeAttr("valid").removeAttr("errmsg");
                $("#txtJiHuaNeiXianLu").removeAttr("valid").removeAttr("errmsg");
                $("#tableform").find("tr[data-class='route']").hide();

                if (_yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游 %>"
                    || _yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制 %>"
                    || _yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行 %>") {
                    $("#tableform").find("tr[data-class='route']").show();
                    if (_xianLuLeiXing == "jihuanei") {
                        $("#divRouteSelect").hide();
                        $("#i_div_jihuaneixianlu").show();
                        $("#<%=txtDingDanJinE.ClientID %>").attr("readonly", "readonly").css({ background: "#dadada" });
                        $("#txtJiHuaNeiXianLu").attr("valid", "required").attr("errmsg", "请选择线路!");
                    }
                    if (_xianLuLeiXing == "jihuawai") {
                        $("#divRouteSelect").show();
                        $("#i_div_jihuaneixianlu").hide();
                        $("#txtRouteName").attr("valid", "required").attr("errmsg", "请选择线路!");
                    }
                }

                this.initJiaGeXinXi();
            },
            //合计订单金额（产品价格）
            heJiDingDanJinE: function() {
                var _self = this;
                function _heJi1() {
                    var _data = _self.getYouKeRenShu();
                    var _jiage = _self.getFormJiaGeXinXi();
                    if (_jiage == null) { $("#<%=txtDingDanJinE.ClientID %>").val(''); return; };

                    var _sum = 0;
                    var _cr = tableToolbar.calculate(_data.chengRen, _jiage.JieSuanJiaGe1, "*");
                    var _et = tableToolbar.calculate(_data.erTong, _jiage.JieSuanJiaGe2, "*");
                    var _yr = tableToolbar.calculate(_data.yingEr, _jiage.JieSuanJiaGe3, "*");
                    var _qp = tableToolbar.calculate(_data.quanPei, _jiage.QuanPeiJiaGe, "*");

                    _sum = tableToolbar.calculate(_sum, _cr, "+");
                    _sum = tableToolbar.calculate(_sum, _et, "+");
                    _sum = tableToolbar.calculate(_sum, _yr, "+");
                    _sum = tableToolbar.calculate(_sum, _qp, "+");

                    $("#<%=txtDingDanJinE.ClientID %>").val(_sum.toFixed(2));
                }

                _heJi1();
                this.heJiJieSuanJinE();
                this.heJiJiFen();
            },
            //合计结算金额（总金额）
            heJiJieSuanJinE: function() {
                var _data = this.getYouKeRenShu();
                var _tuiFangChaJiaGe = tableToolbar.getFloat($("#<%=txtTuiFangChaJiaGe.ClientID %>").val());
                var _buFangChaJiaGe = tableToolbar.getFloat($("#<%=txtBuFangChaJiaGe.ClientID %>").val());

                var _tuiFangChaJinE = tableToolbar.calculate(_data.tuiFangCha, _tuiFangChaJiaGe, "*");
                var _buFangChaJinE = tableToolbar.calculate(_data.buFangCha, _buFangChaJiaGe, "*");

                var _jia = tableToolbar.getFloat($("#<%=txtJiaJinE.ClientID %>").val());
                var _jian = tableToolbar.getFloat($("#<%=txtJianJinE.ClientID %>").val());
                var _dingdanjine = tableToolbar.getFloat($("#<%=txtDingDanJinE.ClientID %>").val());
                var _sum = 0;

                _sum = tableToolbar.calculate(_sum, _dingdanjine, "+");
                _sum = tableToolbar.calculate(_sum, _jia, "+");
                _sum = tableToolbar.calculate(_sum, _jian, "-");
                _sum = tableToolbar.calculate(_sum, _buFangChaJinE, "+");
                _sum = tableToolbar.calculate(_sum, _tuiFangChaJinE, "-");

                $("#<%=txtTotalMoney.ClientID %>").val(_sum.toFixed(2));
                this.initJiaGeMingXi();
            },
            //初始化线路类型
            initXianLuLeiXing: function() {
                if (typeof dingDanJiaGe == "undefined") return;
                if (typeof dingDanJiaGe == null) return;
                if ($.trim(dingDanJiaGe.XianLuId).length > 0) $("#<%=txtXianLuLeiXing.ClientID %>").val("jihuanei");
                else $("#<%=txtXianLuLeiXing.ClientID %>").val("jihuawai");
            },
            //取消订单
            quXiao: function(obj) {
                var _data = { dingDanId: "<%=DingDanId %>", refererIframeId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>', fs: $(obj).attr("data-fs") };
                var _title = "取消订单";
                if (_data.fs == "jujue") _title = "拒绝订单";
                top.Boxy.iframeDialog({ title: _title, iframeUrl: "DingDanQuXiao.aspx", width: "530px", height: "300px", data: _data, afterHide: function() { PlanPage.reload(); } });
            },
            //恢复订单
            huiFu: function(obj) {
                if (!confirm("你确定要恢复订单吗？")) return false;

                $(obj).unbind("click").css({ "color": "#999999" });
                var _url = window.location.href + "&dotype=huifu";

                $.newAjax({ type: "POST", url: _url, cache: false, dataType: "json", async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            PlanPage.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { PlanPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { PlanPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            },
            //价格明细（自动）
            initJiaGeMingXi: function() {
                $("#i_span_jiagemingxi").html('');
                $("#<%=txtJiaGeMingXi.ClientID %>").val('');

                var _data = this.getYouKeRenShu();
                var _jiage = null;
                var _tuiFangChaJiaGe = tableToolbar.getFloat($("#<%=txtTuiFangChaJiaGe.ClientID %>").val());
                var _buFangChaJiaGe = tableToolbar.getFloat($("#<%=txtBuFangChaJiaGe.ClientID %>").val());

                var _tuiFangChaJinE = tableToolbar.calculate(_data.tuiFangCha, _tuiFangChaJiaGe, "*");
                var _buFangChaJinE = tableToolbar.calculate(_data.buFangCha, _buFangChaJiaGe, "*");

                var _jiage = this.getFormJiaGeXinXi();

                if (_jiage == null) return;

                var _s = [];
                if (_data.chengRen > 0) {
                    _s.push("+");
                    _s.push(_jiage.JieSuanJiaGe1.toFixed(2) + "*" + _data.chengRen);
                }

                if (_data.erTong > 0) {
                    _s.push("+");
                    _s.push(_jiage.JieSuanJiaGe2.toFixed(2) + "*" + _data.erTong);
                }

                if (_data.yingEr > 0) {
                    _s.push("+");
                    _s.push(_jiage.JieSuanJiaGe3.toFixed(2) + "*" + _data.yingEr);
                }

                if (_data.quanPei > 0) {
                    _s.push("+");
                    _s.push(_jiage.QuanPeiJiaGe.toFixed(2) + "*" + _data.quanPei);
                }

                if (_data.buFangCha > 0) {
                    _s.push("+");
                    _s.push(_buFangChaJiaGe.toFixed(2) + "*" + _data.buFangCha);
                }

                if (_data.tuiFangCha > 0) {
                    _s.push("-");
                    _s.push(_tuiFangChaJiaGe.toFixed(2) + "*" + _data.tuiFangCha);
                }

                var _jia = tableToolbar.getFloat($("#<%=txtJiaJinE.ClientID %>").val());
                var _jian = tableToolbar.getFloat($("#<%=txtJianJinE.ClientID %>").val());
                if (_jia > 0) {
                    _s.push("+");
                    _s.push(_jia.toFixed(2));
                }

                if (_jian > 0) {
                    _s.push("-");
                    _s.push(_jian.toFixed(2));
                }

                if (_s.length > 0 && (_s[0] == "+" || _s[0] == "-")) _s[0] = "";

                $("#i_span_jiagemingxi").html(_s.join(''));
                $("#<%=txtJiaGeMingXi.ClientID %>").val(_s.join(''));
            },
            //补全游客
            buQuanYouKe: function() {
                var _data = this.getYouKeRenShu();
                var _renshu = OrderCustomerControl.getYouKeRenShu();
                if (_data.zong == _renshu) return;

                if (_data.zong > _renshu) {
                    for (var i = 0; i < _data.zong - _renshu; i++) OrderCustomerControl.addCustomer(null);
                }

                OrderCustomerControl.initIndex();
                //this.initYouKeLeiXing();
            },
            //合计积分
            heJiJiFen: function() {
                if ("<%=(int)ZxsJiFenStatus %>" == "<%=(int)EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用 %>") return;
                $("#<%=txtJiFen2.ClientID %>").val("0");
                var _data = this.getYouKeRenShu();
                var _jiFen1 = tableToolbar.getInt($("#<%=txtJiFen1.ClientID %>").val());
                var _jiFen2 = _jiFen1 * _data.chengRen;
                $("#<%=txtJiFen2.ClientID %>").val(_jiFen2);
            },
            //获取客户联系信息
            getKeHuLxrXinXi: function() {
                var _data = { txtKeHuLxrId: $.trim($("#txtDuiFangCaoZuoRen").val()), txtKeHuId: $.trim($("#<%=txtKeHu.KeHuIdClientId %>").val()) };

                function _callback(data) {
                    if (typeof data == "undefined" || data == null) {
                        data = { XingMing: "", DianHua: "", ShouJi: "", Fax: "" }
                    }

                    $("#<%=txtKeHuLxrName.ClientID %>").val(data.XingMing);
                    $("#<%=txtKeHuLxrDianHua.ClientID %>").val(data.DianHua);
                    $("#<%=txtKeHuLxrShouJi.ClientID %>").val(data.ShouJi);
                    $("#<%=txtKeHuLxrFax.ClientID %>").val(data.Fax);
                }

                if (_data.txtKeHuLxrId.length < 1 || _data.txtKeHuId.length < 1) {
                    _callback(null);
                    return;
                }

                $.ajax({ type: "post", url: "/ashx/Handler.ashx?doType=getkehulxrxinxi", cache: true, dataType: "json", async: true, data: _data,
                    success: function(response) {
                        _callback(response);
                    }
                });
            },
            //初始化线路信息
            initRouteXinXi: function(routeId, xianLuId) {
                var _data = { txtRouteId: routeId, txtXianLuId: xianLuId };
                function _callback(data) {
                    if (typeof data == "undefined" || data == null) {
                        data = { JiHeDiDian: "", JiHeShiJian: "", SongTuanXinXi: "", MuDiDiJieTuanFangShi: "" }
                    }

                    $("#<%=txtJiHeDiDian1.ClientID %>").val(data.JiHeDiDian);
                    $("#<%=txtJiHeShiJian1.ClientID %>").val(data.JiHeShiJian);
                    $("#<%=txtSongTuanXinXi.ClientID %>").val(data.SongTuanXinXi);
                    $("#<%=txtMuDiDiJieTuanFangShi.ClientID %>").val(data.MuDiDiJieTuanFangShi);

                }
                if (_data.txtRouteId.length < 1 && _data.txtXianLuId.length < 1) {
                    _callback(null);
                    return;
                }

                $.ajax({ type: "post", url: "/ashx/Handler.ashx?doType=getroutexinxi", cache: true, dataType: "json", async: true, data: _data,
                    success: function(response) {
                        _callback(response);
                    }
                });
            },
            //获取价格信息
            getJiaGeXinXi: function() {
                var _self = this;
                //获取订单价格
                function getJiaGe1() {
                    var _yeWuLeiXing = $("#sltYewutype").val();
                    var _xianLuId = $("#txtJiHuaNeiXianLu").val();
                    var _xianLuLeiXing = $("#<%=txtXianLuLeiXing.ClientID %>").val();

                    if (typeof dingDanJiaGe == "undefined" || dingDanJiaGe == null) return null;

                    var _info = { "XianLuId": "", "LeiXing": 0, "KongWeiId": "", "RouteId": "", "MenShiJiaGe1": 0, "MenShiJiaGe2": 0, "MenShiJiaGe3": 0, "JieSuanJiaGe1": 0, "JieSuanJiaGe2": 0, "JieSuanJiaGe3": 0, "QuanPeiJiaGe": 0, "BuFangChaJiaGe": 0, "TuiFangChaJiaGe": 0, "JiFen": 0, "XianLuCode": "", "PaiXuId": 0, "Status": 0, "RouteName": "" }
                    _info.XianLuId = dingDanJiaGe.XianLuId;
                    _info.JieSuanJiaGe1 = dingDanJiaGe.ChengRenJiaGe;
                    _info.JieSuanJiaGe2 = dingDanJiaGe.ErTongJiaGe;
                    _info.JieSuanJiaGe3 = dingDanJiaGe.YingErJiaGe;
                    _info.BuFangChaJiaGe = dingDanJiaGe.BuFangChaJiaGe;
                    _info.TuiFangChaJiaGe = dingDanJiaGe.TuiFangChaJiaGe;
                    _info.JiFen = dingDanJiaGe.JiFen1;
                    _info.RouteId = dingDanJiaGe.RouteId;
                    _info.QuanPeiJiaGe = dingDanJiaGe.QuanPeiJiaGe;

                    return _info;
                }

                //获取计划内价格
                function getJiaGe2() {
                    var _yeWuLeiXing = $("#sltYewutype").val();
                    var _xianLuId = $("#txtJiHuaNeiXianLu").val();
                    var _xianLuLeiXing = $("#<%=txtXianLuLeiXing.ClientID %>").val();

                    if (typeof jiHuaNeiXianLu == "undefined") return null;
                    if (jiHuaNeiXianLu == null || jiHuaNeiXianLu.length == 0) return null;
                    var _info = null;
                    for (var i = 0; i < jiHuaNeiXianLu.length; i++) {
                        if (_yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票 %>"
                        || _yeWuLeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店 %>") {
                            if (jiHuaNeiXianLu[i].LeiXing == "<%=(int)EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuLeiXing.单订票 %>") { _info = jiHuaNeiXianLu[i]; break; }
                        } else {
                            if (_xianLuLeiXing == "jihuanei" && jiHuaNeiXianLu[i].XianLuId == _xianLuId) { _info = jiHuaNeiXianLu[i]; break; }
                        }
                    }

                    return _info;
                }

                function getJiaGe3() {
                    var _info = { "XianLuId": "", "LeiXing": 0, "KongWeiId": "", "RouteId": "", "MenShiJiaGe1": 0, "MenShiJiaGe2": 0, "MenShiJiaGe3": 0, "JieSuanJiaGe1": 0, "JieSuanJiaGe2": 0, "JieSuanJiaGe3": 0, "QuanPeiJiaGe": 0, "BuFangChaJiaGe": 0, "TuiFangChaJiaGe": 0, "JiFen": 0, "XianLuCode": "", "PaiXuId": 0, "Status": 0, "RouteName": "" }
                    return _info;
                }

                var _info = getJiaGe1();
                if (_info == null) _info = getJiaGe2();
                if (_info == null) _info = getJiaGe3();

                return _info;
            },
            //获取表单价格信息
            getFormJiaGeXinXi: function() {
                var _info = { "XianLuId": "", "LeiXing": 0, "KongWeiId": "", "RouteId": "", "MenShiJiaGe1": 0, "MenShiJiaGe2": 0, "MenShiJiaGe3": 0, "JieSuanJiaGe1": 0, "JieSuanJiaGe2": 0, "JieSuanJiaGe3": 0, "QuanPeiJiaGe": 0, "BuFangChaJiaGe": 0, "TuiFangChaJiaGe": 0, "JiFen": 0, "XianLuCode": "", "PaiXuId": 0, "Status": 0, "RouteName": "" }
                _info.JieSuanJiaGe1 = tableToolbar.getFloat($("#<%=txtChengRenJiaGe.ClientID %>").val());
                _info.JieSuanJiaGe2 = tableToolbar.getFloat($("#<%=txtErTongJiaGe.ClientID %>").val());
                _info.JieSuanJiaGe3 = tableToolbar.getFloat($("#<%=txtYingErJiaGe.ClientID %>").val());
                _info.QuanPeiJiaGe = tableToolbar.getFloat($("#<%=txtQuanPeiJiaGe.ClientID %>").val());
                return _info;
            },
            //初始化价格信息
            initJiaGeXinXi: function() {
                var _info = this.getJiaGeXinXi();
                if (_info == null) return;

                $("#<%=txtChengRenJiaGe.ClientID %>").val(_info.JieSuanJiaGe1.toFixed(2));
                $("#<%=txtErTongJiaGe.ClientID %>").val(_info.JieSuanJiaGe2.toFixed(2));
                $("#<%=txtYingErJiaGe.ClientID %>").val(_info.JieSuanJiaGe3.toFixed(2));
                $("#<%=txtQuanPeiJiaGe.ClientID %>").val(_info.QuanPeiJiaGe.toFixed(2));
                $("#<%=txtBuFangChaJiaGe.ClientID %>").val(_info.BuFangChaJiaGe.toFixed(2));
                $("#<%=txtTuiFangChaJiaGe.ClientID %>").val(_info.TuiFangChaJiaGe.toFixed(2));
                $("#<%=txtJiFen1.ClientID %>").val(_info.JiFen);
            }
        }

        $(function() {
            $("#sltYewutype").val("<%=YeWuLeiXing %>");
            $("#sltxingzhi").val("<%=YeWuXingZhi %>");

            $("#i_a_songtuanxinxi_xuanyong").bind("click", function() { PlanPage.songTuanXinXiXuanYong(); });
            $("#i_a_mudidijietuanfangshi_xuanyong").bind("click", function() { PlanPage.muDiDiJieTuanFangShiXuanYong(); });

            $("#a_chengjiao,#a_baocun,#a_liuwei").click(function() { PlanPage.baoCun(this); });

            $("#txtJiHeDiDian").change(function() { $("#<%=txtJiHeDiDian1.ClientID %>").val($(this).val()); });
            $("#txtJiHeShiJian").change(function() { $("#<%=txtJiHeShiJian1.ClientID %>").val($(this).val()); });
            $("#sltYewutype").change(function() { PlanPage.changeYeWuLeiXing(); });

            if ("<%=YeWuLeiXing %>" != "") $("#sltYewutype").find("option").each(function() { if ($(this).attr("selected")) { return; } $(this).remove(); });

            $("#<%=txtAdultCount.ClientID %>,#<%=txtChildCount.ClientID %>,#<%=txtQuanPeiCount.ClientID %>,#<%=txtYingErShu.ClientID %>,#<%=txtChengRenJiaGe.ClientID %>,#<%=txtErTongJiaGe.ClientID %>,#<%=txtYingErJiaGe.ClientID %>,#<%=txtQuanPeiJiaGe.ClientID %>").change(function() { PlanPage.heJiRenShu(); });
            $("#<%=txtSeatCount.ClientID %>").change(function() { PlanPage.initRenShuTongJi(); });

            $("#i_a_jihuaneixianlu,#i_a_jihuawaixianlu").click(function() { PlanPage.changeXianLuLeiXing(this); });

            $("#<%=txtDingDanJinE.ClientID %>,#<%=txtJiaJinE.ClientID %>,#<%=txtJianJinE.ClientID %>,#<%=txtBuFangChaShuLiang.ClientID %>,#<%=txtTuiFangChaShuLiang.ClientID %>,#<%=txtBuFangChaJiaGe.ClientID %>,#<%=txtTuiFangChaJiaGe.ClientID %>").change(function() { PlanPage.heJiJieSuanJinE(); });

            $("#txtJiHuaNeiXianLu").change(function() { PlanPage.changeJiHuaNeiXianLu(); });

            $("#a_quxiao,#a_jujue").click(function() { PlanPage.quXiao(this); });
            $("#a_huifu").click(function() { PlanPage.huiFu(this); });

            $("#<%=txtJiFen1.ClientID %>").change(function() { PlanPage.heJiJiFen(); });
            $("#txtDuiFangCaoZuoRen").change(function() { PlanPage.getKeHuLxrXinXi(); });

            $("#<%=txtKeHu.KeHuMingChengClientId %>,#<%=txtKeHu.KeHuIdClientId %>").attr("valid", "required").attr("errmsg", "请选择客户单位!");

            PlanPage.initRenShuTongJi();
            PlanPage.initJiHuaNeiXianLu();
            PlanPage.initXianLuLeiXing();
            PlanPage.initHS();
            PlanPage.buQuanYouKe();

            if ("<%=(int)ZxsJiFenStatus %>" == "<%=(int)EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用 %>") $("#<%=txtJiFen1.ClientID %>").attr("readonly", "readonly").css({ "background": "#dadada" });
            if ("<%=(int)JiFenXianShiBiaoShi %>" == "<%=(int)EyouSoft.Model.EnumType.TourStructure.JiFenXianShiBiaoShi.不显示 %>") $("#txtJiFenXianShiBiaoShi").attr("checked", "checked");
        });
    </script>
</body>
</html>