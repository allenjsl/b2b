<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPlan.aspx.cs" Inherits="Web.TeamPlan.EditPlan"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    <link href="/css/boxynew.css" rel="stylesheet" type="text/css" />
    <script src="/Js/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="/Js/jquery.boxy.js" type="text/javascript"></script>
    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="/Js/table-toolbar.js" type="text/javascript"></script>
    <script src="/Js/ValiDatorForm.js" type="text/javascript"></script>
    <link href="/Css/swfupload/default.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="/Js/swfupload/swfupload.js"></script>
    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../Css/boxy.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]>
    <script type="text/javascript" src="/js/json2.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <textarea id="txtKongWeiRiQis" runat="server" style="display:none;"></textarea>
    
    <div style="width: 99%; margin: 10px auto;">
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
            <tbody>
                <tr class="odd">
                    <th width="120" height="30" align="right">
                        <span class="fred">*</span>线路区域：
                    </th>
                    <td bgcolor="#E3F1FC" width="370">
                        <select name="txtQuYu" class="inputselect" id="txtQuYu" valid="required" errmsg="请选择线路区域!">
                            <asp:Literal runat="server" ID="ltrQuYuOption"></asp:Literal>
                        </select>
                    </td>
                    <th width="120" align="right" id="i_td_tianshu_1">
                        <span class="fred">*</span>天数
                    </th>
                    <td bgcolor="#E3F1FC" id="i_td_tianshu_2">
                        <input type="text" id="txtTianShu" class="formsize40 inputtext" maxlength="2" valid="RegInteger|required" errmsg="天数必须大于等于0|请输入天数"  runat="server" />
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>出团日期：
                    </th>
                    <td bgcolor="#E3F1FC" id="i_td_chutuanriqi">
                        <a href="javascript:void(0)" id="i_a_riqi">当前已选择0个出团日期</a><input type="hidden" name="txtRiQi" id="txtRiQi" valid="required" errmsg="请选择出团日期">
                    </td>
                    <th align="right">
                        <span class="fred">*</span>去程交通：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select id="txtQuJiaoTongId" class="inputselect" name="txtQuJiaoTongId" valid="required" errmsg="请选择去程交通!">
                            <%=GetJiaoTongOptions()%>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        <span class="fred">*</span>去程出发地：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtQuChuFaDiShengFen" class="inputselect" id="txtQuChuFaDiShengFen" valid="required" errmsg="请选择去程出发地省份!">
                            <option value="">请选择</option>
                        </select>
                        <select name="txtQuChuFaDiChengShi" class="inputselect" id="txtQuChuFaDiChengShi" valid="required" errmsg="请选择去程出发地城市!">
                            <option value="">请选择</option>
                        </select>
                    </td>
                    <th align="right">
                        <span class="fred">*</span>去程目的地：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtQuMuDiDiShengFen" class="inputselect" id="txtQuMuDiDiShengFen" valid="required" errmsg="请选择去程目的地省份!">
                            <option value="">请选择</option>
                        </select>
                        <select name="txtQuMuDiDiChengShi" class="inputselect" id="txtQuMuDiDiChengShi" valid="required" errmsg="请选择去程目的地城市!">
                            <option value="">请选择</option>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        去程班次：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtQuChengBanCi" id="txtQuChengBanCi" class="inputselect"></select>
                        <asp:TextBox ID="txtGobanci" runat="server" CssClass="inputtext formsize120"></asp:TextBox>
                    </td>
                    <th align="right">
                        <%--去程时间：--%>
                    </th>
                    <td bgcolor="#E3F1FC">
                        <%--<select name="txtQuChengShiJian" id="txtQuChengShiJian" class="inputselect">
                            <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程时间) %>
                        </select>
                        <asp:TextBox ID="txtGoTime" runat="server" CssClass="inputtext formsize120"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        回程日期：
                    </th>
                    <td bgcolor="#E3F1FC" id="i_td_huichengriqi">
                        <span style="color:#999;">按选择的出团日期与天数自动计算</span>
                    </td>
                    <th align="right">
                        回程交通：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select id="txtHuiJiaoTongId" name="txtHuiJiaoTongId" class="inputselect">
                            <%=GetJiaoTongOptions()%>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        回程出发地：
                    </th>
                    <td bgcolor="#E3F1FC">                        
                        <select name="txtHuiChuFaDiShengFen" class="inputselect" id="txtHuiChuFaDiShengFen">
                            <option value="">请选择</option>
                        </select>
                        <select name="txtHuiChuFaDiChengShi" class="inputselect" id="txtHuiChuFaDiChengShi">
                            <option value="">请选择</option>
                        </select>
                    </td>
                    <th align="right">
                        回程目的地：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtHuiMuDiDiShengFen" class="inputselect" id="txtHuiMuDiDiShengFen">
                            <option value="">请选择</option>
                        </select>
                        <select name="txtHuiMuDiDiChengShi" class="inputselect" id="txtHuiMuDiDiChengShi">
                            <option value="">请选择</option>
                        </select>
                    </td>
                </tr>
                <tr class="odd">
                    <th height="30" align="right">
                        回程班次：
                    </th>
                    <td bgcolor="#E3F1FC">
                        <select name="txtHuiChengBanCi" id="txtHuiChengBanCi" class="inputselect"></select>
                        <asp:TextBox ID="txtBackBanci" CssClass="formsize120 inputtext" runat="server"></asp:TextBox>
                    </td>
                    <th align="right">
                        <%--回程时间：--%>
                    </th>
                    <td bgcolor="#E3F1FC">
                        <%--<select name="txtHuiChengShiJian" id="txtHuiChengShiJian" class="inputselect">
                            <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.回程时间) %>
                        </select>
                        <asp:TextBox ID="txtBackTime" CssClass="formsize120 inputtext" runat="server"></asp:TextBox>--%>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="width: 99%; margin: 0px auto; margin-top: 10px;">
        <span class="formtableT">中间航段信息</span>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="text-align: center;" id="table_hangduan">
            <tr class="odd" style="font-weight:bold;">
                <td style="height:30px; width:40px;">
                    序号
                </td>
                <td style="width:90px;">
                    日期
                </td>
                <td style="width:120px;">
                    交通
                </td>
                <td style="text-align:left;width:200px;">
                    班次
                </td>
                <td style="text-align:left;width:120px;">
                    出发地
                </td>
                <td style="text-align: left; width: 120px;">
                    目的地
                </td>
                <td>
                    备注
                </td>
                <td style="width: 80px;">
                    操作
                </td>
            </tr>
            <tr class="even hd_item">
                <td style="height: 30px;">
                    <span class="hd_index">1</span>
                </td>
                <td>
                    <input type="text" class="inputtext" name="txt_hd_riqi" style="width: 70px;" onfocus="WdatePicker()" />
                </td>
                <td>
                    <select name="txt_hd_jiaotong"><%=GetJiaoTongOptions()%></select>
                </td>
                <td style="text-align:left;line-height:25px; height:50px;">
                    <select name="txt_hd_banci_01" class="inputselect"><%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.去程班次) %></select><br />
                    <input type="text" class="inputtext" name="txt_hd_banci" style="width:180px;" />
                </td>
                <td style="text-align: left; line-height: 25px;">
                    <select name="txt_hd_chufadi_shengfen" class="inputselect" ><option value="">-请选择-</option></select><br />
                    <select name="txt_hd_chufadi_chengshi" class="inputselect"><option value="">-请选择-</option></select>
                </td>
                <td style="text-align: left; line-height: 25px;">
                    <select name="txt_hd_mudidi_shengfen" class="inputselect" ><option value="">-请选择-</option></select><br />
                    <select name="txt_hd_mudidi_chengshi" class="inputselect"><option value="">-请选择-</option></select>
                </td>
                <td>
                    <input type="text" class="inputtext" maxlength="255" name="txt_hd_beizhu" style="width:160px;"/>
                </td>
                <td>
                    <a href="javascript:void(0)" class="hd_tianjia">添加</a>
                    <a href="javascript:void(0)" class="hd_shanchu">删除</a>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 99%; margin: 0 auto; margin-top:10px;">
        <span class="formtableT">代理商信息</span>
        <asp:PlaceHolder runat="server" ID="phBuTongBuDaiLiShang" Visible="false">
        <span>
            <input type="checkbox" id="txtBuTongBuDaiLiShang" name="txtBuTongBuDaiLiShang" value="1"
                style="vertical-align: middle;" /><label for="txtBuTongBuDaiLiShang" style="vertical-align: middle;">不同步修改<asp:Literal runat="server" ID="ltrPiLiangXiuGaiJiHuaWeiShuLiang">0</asp:Literal>个计划位的代理商及平台收客数量信息<span style="color:#666;" >（注：勾选此选项此次批量修改的计划位的代理商信息、平台收客数量不做修改）</span></label>
        </span>
        </asp:PlaceHolder>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" class="autoAdd">
            <tbody>
                <tr class="odd">
                    <th width="36">
                        编号
                    </th>
                    <th height="30">
                        代理商
                    </th>
                    <th>
                        订单号或编码
                    </th>
                    <th>
                        联系人
                    </th>
                    <th>
                        联系电话
                    </th>
                    <th>
                        价格
                    </th>
                    <th>
                        控位数量
                    </th>
                    <th>
                        出票时限
                    </th>
                    <th>
                        备注
                    </th>
                    <th width="120">
                        操作
                    </th>
                </tr>
                <asp:PlaceHolder runat="server" ID="PHdefaultTr">
                    <tr class="odd tempRow">
                        <td bgcolor="#E3F1FC" align="center">
                            <span class="index">1</span>
                            <input type="hidden" value="" name="hidDaiLiId" />
                            <input type="hidden" value="" name="txtMoBanId" />
                        </td>
                        <td height="30" bgcolor="#E3F1FC" align="center">
                            <input type="hidden" name="ShowID" value='' />
                            <input name="SourceName" type="text" style="background-color: #dadada" readonly="readonly"
                                class="inputtext formsize80" value="" />
                            <a href="javascript:void(0);" class="Offers xuanyong"></a>
                            <input type="hidden" name="ContactName" value='' />
                            <input type="hidden" name="ContactPhone" value='' />
                            <input type="hidden" name="ContactFax" value='' />
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <input type="text" class="formsize80 inputtext" name="txtOrderNum" />
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <input type="text" size="10" class="formsize40 inputtext" name="txtContactName">
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <input type="text" size="15" class="formsize80 inputtext" name="txtContactTel">
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <input type="text" size="10" class="formsize40 inputtext" valid="isMoney" errmsg="价格格式不正确|请输入价格"
                                name="txtPrice">
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <input type="text" size="10" class="formsize40 inputtext" valid="isNumber" errmsg="数量必须是整数|请输入数量"
                                name="txtCount">
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <input type="text" class="formsize50 inputtext" name="txtTimeLemit">
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <textarea class="formsize120 inputtext" name="txtremark"></textarea>
                        </td>
                        <td bgcolor="#E3F1FC" align="center">
                            <a class="addbtn" href="javascript:void(0)">
                                <img width="48" height="20" src="../images/addimg.gif" alt="" /></a> <a class="delbtn"
                                    href="javascript:void(0)">
                                    <img width="48" height="20" src="../images/delimg.gif" alt="" /></a>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <asp:Repeater runat="server" ID="rptlist">
                    <ItemTemplate>
                        <tr class="odd tempRow" data-isedit='1'>
                            <td bgcolor="#E3F1FC" align="center">
                                <span class="index"><%# Container.ItemIndex + 1%></span>
                                <input type="hidden" value='<%#Eval("DaiLiId") %>' name="hidDaiLiId" />
                                <input type="hidden" value="<%#Eval("MoBanId") %>" name="txtMoBanId" />
                            </td>
                            <td height="30" bgcolor="#E3F1FC" align="center">
                                <input type="hidden" name="ShowID" value='<%#Eval("GysId") %>' />
                                <input name="SourceName" type="text" style="background-color: #dadada" readonly="readonly"
                                    class="inputtext formsize80" value='<%#Eval("GysName") %>' />
                                <input type="hidden" name="ContactName" value='' />
                                <input type="hidden" name="ContactPhone" value='' />
                                <input type="hidden" name="ContactFax" value='' />
                                <a href="javascript:void(0);" class="Offers xuanyong"></a>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <input type="text" class="formsize80 inputtext" name="txtOrderNum" value='<%#Eval("GysOrderCode") %>' />
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <input type="text" size="10" class="formsize40 inputtext" name="txtContactName" value='<%#Eval("LxrName") %>' />
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <input type="text" size="15" class="formsize80 inputtext" name="txtContactTel" value='<%#Eval("LxrTelephone") %>' />
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <input type="text" size="10" class="formsize40 inputtext" valid="isMoney|required"
                                    errmsg="价格格式不正确|请输入价格" name="txtPrice" value='<%#EyouSoft.Common.Utils.GetDecimal(Convert.ToString(Eval("Price"))).ToString("f2") %>'
                                    min="1" />
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <input type="text" size="10" class="formsize40 inputtext" valid="isInt|required"
                                    errmsg="数量必须是整数|请输入数量" name="txtCount" value='<%#Eval("ShuLiang") %>' />
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <input type="text" class="formsize50 inputtext" name="txtTimeLemit" value='<%#Eval("ShiXian") %>' />
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <textarea class="formsize120 inputtext" name="txtremark"><%#Eval("Remark") %></textarea>
                            </td>
                            <td bgcolor="#E3F1FC" align="center">
                                <a class="addbtn" href="javascript:void(0)">
                                    <img width="48" height="20" src="../images/addimg.gif" alt="" /></a> <a class="delbtn"
                                        href="javascript:void(0)">
                                        <img width="48" height="20" src="../images/delimg.gif" alt="" /></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>     
        <table width="100%" border="0" bgcolor="#FFFFFF" cellspacing="0" cellpadding="0">
            <tr>
                <td style="color:#666">
                    注：未选择代理商、未输入数量的代理商信息视为无效信息。
                </td>
            </tr>
        </table> 
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin-top:5px;">
            <tr class="odd">                
                <th height="30" align="right" width="120">
                   平台收客数量：
                </th>
                <td style="background: #E3F1FC">
                    <input type="text" id="txtPingTaiShuLiang" class="formsize120 inputtext" maxlength="2"
                        valid="RegInteger|required" errmsg="平台收客数量必须大于等于0|请输入平台收客数量" runat="server" />
                    <span style="color:#666;">平台收客数量以控制同行平台的收客数，超过指定数量同行客户自行下单状态为申请中。</span>
                </td>
            </tr>
        </table>
    </div>
    
    
    
    <div style="width:99%;margin:0px auto; margin-top:10px;">
        <span class="formtableT">单订票信息</span>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="text-align: center;" id="table_ddp">
            <%--<tr class="odd">
                <th colspan="3" style="height:20px">
                    门市价
                </th>
                <th colspan="3">
                    结算价
                </th>
            </tr>
            <tr class="odd">
                <td style="height:20px;">
                    成人
                </td>
                <td>
                    儿童
                </td>
                <td>
                    婴儿
                </td>
                <td>
                    成人
                </td>
                <td>
                    儿童
                </td>
                <td>
                    婴儿
                </td>
            </tr>--%>
            <tr class="odd" style="font-weight:bold;">
                <td style="height:30px;">
                    门市成人价
                </td>
                <td>
                    门市儿童价
                </td>
                <td>
                    门市婴儿价
                </td>
                <td>
                    结算成人价
                </td>
                <td>
                    结算儿童价
                </td>
                <td>
                    结算婴儿价
                </td>
                <td>
                    状态
                </td>
            </tr>
            <tr class="even">
                <td style="height: 30px;">
                    <input type="text" class="inputtext formsize80" maxlength="8" name="txt_ddp_menshijiage1" maxlength="8" />
                </td>
                <td>
                    <input type="text" class="inputtext formsize80" maxlength="8" name="txt_ddp_menshijiage2" maxlength="8"/>
                </td>
                <td>
                    <input type="text" class="inputtext formsize80" maxlength="8" name="txt_ddp_menshijiage3" maxlength="8"/>
                </td>
                <td>
                    <input type="text" class="inputtext formsize80" maxlength="8" name="txt_ddp_jiesuanjiage1" maxlength="8"/>
                </td>
                <td>
                    <input type="text" class="inputtext formsize80" maxlength="8" name="txt_ddp_jiesuanjiage2" maxlength="8"/>
                </td>
                <td>
                    <input type="text" class="inputtext formsize80" maxlength="8" name="txt_ddp_jiesuanjiage3" maxlength="8"/>
                </td>
                <td>
                    <select class="inputselect" name="txt_ddp_status">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus)),"")%>
                    </select>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" bgcolor="#FFFFFF" cellspacing="0" cellpadding="0">
            <tr>
                <td style="color:#666">
                    注：未填写结算成人价（或结算成人价<=0）的单订票信息视为无效信息。
                </td>
            </tr>
        </table>
    </div>
    
    <div style="width:99%;margin:0px auto; margin-top:10px;">
        <span class="formtableT">线路产品信息</span>
        <table width="100%" border="0" align="center" cellspacing="1" cellpadding="0" style="text-align:center;" id="table_xl">
            <tr class="odd">
                <th style="width:36px;height:30px;">序号</th>
                <th>线路产品信息</th>
                <th style="width:80px;">操作</th>
            </tr>
            <tr class="even xlitem">
                <td><span class="xlindex">1</span><textarea name="txt_xl_riqi" style="display:none;"></textarea></td>
                <td style="background:#fff">
                    <table width="100%" border="0" align="center" cellspacing="1" cellpadding="0" style="text-align: left;">
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px; text-align:right;">线路名称：</th>
                            <td colspan="3"><input type="hidden" name="txt_xl_routeid" /><input type="text" class="inputtext formsize100" style="width:300px;background:#dadada" name="txt_xl_routename" readonly="readonly"  /><a class="xuanyong xuanzexl" href="javascript:void(0);"></a>&nbsp;&nbsp;<span class="span_xianlucode"></span></td>
                            <th style="height: 30px;text-align:right;">适用日期：</th>
                            <td><a href="javascript:void(0)" class="a_xl_riqi">共0个日期，点击查看</a></td>
                        </tr>
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px;width:110px;text-align:right;">门市成人价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_menshijiage1"  maxlength="8"/></td>
                            <th style="width:110px;text-align:right;">门市儿童价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_menshijiage2"  maxlength="8"/></td>
                            <th style="width:110px;text-align:right;">门市婴儿价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_menshijiage3"  maxlength="8"/></td>
                        </tr>
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px;text-align:right;">结算成人价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_jiesuanjiage1" maxlength="8"/></td>
                            <th style="text-align:right;">结算儿童价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_jiesuanjiage2" maxlength="8" /></td>
                            <th style="text-align:right;">结算婴儿价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_jiesuanjiage3" maxlength="8" /></td>
                        </tr>
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px; text-align:right;">全陪价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_quanpeijiage" maxlength="8" /></td>
                            <th style="text-align:right;">补单房差价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_bufangchajiage" maxlength="8" /></td>
                            <th style="text-align:right;">退单房差价：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_tuifangchajiage" maxlength="8" /></td>
                        </tr>
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px;text-align:right;">单人积分：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_jifen" maxlength="3" /></td>
                            <th style="text-align:right;">状态：</th>
                            <td><select class="inputselect" name="txt_xl_status"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiXianLuStatus)),"")%></select></td>
                            <th style="text-align:right;">排序值：</th>
                            <td><input type="text" class="inputtext formsize100" name="txt_xl_paixuid" /></td>
                        </tr>
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px;text-align:right;">
                                每单不超过人数：</th>
                            <td colspan="5"><input type="text" class="inputtext formsize100" name="txt_xl_xiandingrenshu" maxlength="3" /><span style="color:#666;">&nbsp;说明：客户平台下单总人数大于指定人数的下单状态默认为申请中，不填写或填写0时不限定。</span></td>
                        </tr>
                        <tr style="background: #E3F1FC">
                            <th style="height: 30px;text-align:right;">
                                每单至少人数：</th>
                            <td colspan="5"><input type="text" class="inputtext formsize100" name="txt_xl_zuixiaorenshu" maxlength="3" /><span style="color:#666;">&nbsp;说明：客户平台下单成人数小于指定人数的下单状态默认为申请中，不填写或填写0时不限定。</span></td>
                        </tr>
                        <tr style="background: #E3F1FC">                            
                            <td colspan="6" style="height:30px;"></td>
                        </tr>
                    </table>                
                </td>
                <td><a href="javascript:void(0)" class="insertxl">添加</a> <a href="javascript:void(0)" class="deletexl">删除</a></td>
            </tr>            
        </table>
        <table width="100%" border="0" bgcolor="#FFFFFF" cellspacing="0" cellpadding="0">
            <tr>
                <td style="color:#666">
                    注：未选择线路产品、未填写结算成人价（或结算成人价<=0）的线路信息视为无效信息。
                </td>
            </tr>
        </table>
    </div>
    
    <div style="width:99%;margin:0px auto">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" align="center" style="margin: 10px auto;">
            <tbody>
                <tr class="odd">
                    <td height="30" bgcolor="#E3F1FC" align="left" colspan="14">
                        <table cellspacing="0" cellpadding="0" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td width="100" height="40" align="center" class="tjbtn02">
                                        <asp:PlaceHolder runat="server" ID="phOperatorHtml">
                                        <a href="javascript:;" id="btn" runat="server">保存</a>
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
    
    
    </form>
    <%--document.ready:$("#txtQuChengShiJian").change(function() { $("#<%=txtGoTime.ClientID %>").val($(this).val()); });
    $("#txtHuiChengShiJian").change(function() { $("#<%=txtBackTime.ClientID %>").val($(this).val()); });--%>
    <script type="text/javascript" src="/js/rili.js?v=201501070001"></script>
    <script type="text/javascript" src="/js/kongweixianlurili.js?v=201501070001"></script>
    <script type="text/javascript">
        $(function() {
            if (typeof JSON == 'undefined') { $.ajax({ url: "/js/json2.js", dataType: "script", async: false, success: function() { } }); }
            PlanEdit.PageInit();
            $("#txtQuChengBanCi").change(function() { $("#<%=txtGobanci.ClientID %>").val($(this).val()); });
            $("#txtHuiChengBanCi").change(function() { $("#<%=txtBackBanci.ClientID %>").val($(this).val()); });

            $("#i_a_riqi").click(function() { rili.init(this, '<%=DateTime.Now.ToString("yyyy-MM-dd") %>'); });
            $(".a_xl_riqi").click(function() { kongweixianlurili.init(this, '<%=DateTime.Now.ToString("yyyy-MM-dd") %>'); });

            $("#txtQuYu").val("<%=QuYuId %>");
            $("#txtQuJiaoTongId").val("<%=QuJiaoTongId %>");
            $("#txtHuiJiaoTongId").val("<%=HuiJiaoTongId %>");

            if ("<%=CZFS %>" == "UPDATE") $("#txtRiQi").removeAttr("valid").removeAttr("errmsg");

            $(".insertxl").click(function() { iPage.insertXL(this); });
            $(".deletexl").click(function() { iPage.deleteXL(this); });
            $(".xuanzexl").click(function() { iPage.xuanZeXL(this); });

            rili.intKongWeisRiQis();
            kongweixianlurili.initXlItems();

            $("#txtQuYu").change(function() {
                iPage.initQuYuShengFenChengShi({ txtShengFen: "txtQuChuFaDiShengFen", txtChengShi: "txtQuChuFaDiChengShi", leiXing: 0, shengFenId: "<%=QuChuFaDiShengFenId%>", chengShiId: "<%=QuChuFaDiChengShiId%>" });
                iPage.initQuYuShengFenChengShi({ txtShengFen: "txtQuMuDiDiShengFen", txtChengShi: "txtQuMuDiDiChengShi", leiXing: 1, shengFenId: "<%=QuMuDiDiShengFenId%>", chengShiId: "<%=QuMuDiDiChengShiId%>" });

                iPage.initQuBanCi();
                iPage.initHuiBanCi();
            });

            $("#txtQuYu").change();

            $("input[name='txtCount']").change(function() { $("#<%=txtPingTaiShuLiang.ClientID %>").val(iPage.getKongWeiShuLiang()); });

            iPage.initHDS();
        });

        //回调函数 给供应商赋值(hideid,showid)
        function CallBackSource(obj) {
            if (obj) {
                $("#" + obj.aid).closest("tr").find("input[name='txtContactName']").val(obj.contactname);
                $("#" + obj.aid).closest("tr").find("input[name='txtContactTel']").val(obj.contacttel);
                $("#" + obj.aid).closest("tr").find("input[name='ShowID']").val(obj.id);
                $("#" + obj.aid).closest("tr").find("input[name='SourceName']").val(obj.name); //valid="isMoney"
                $("#" + obj.aid).closest("tr").find("input[name='txtPrice']").attr("valid", "isMoney|required");
                $("#" + obj.aid).closest("tr").find("input[name='txtPrice']").attr("errmsg", "价格格式不正确|请输入价格");
                $("#" + obj.aid).closest("tr").find("input[name='txtCount']").attr("valid", "isInt|required");
                $("#" + obj.aid).closest("tr").find("input[name='txtCount']").attr("errmsg", "数量必须是整数|请输入数量");
            }
        }

        var PlanEdit = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            PageInit: function() {
                pcToobar.ginit({ pID: "#txtHuiChuFaDiShengFen", cID: "#txtHuiChuFaDiChengShi", pSelect: '<%=HuiChuFaDiShengFenId %>', cSelect: '<%=HuiChuFaDiChengShiId %>', comID: '<%=this.SiteUserInfo.CompanyId %>', isCy: "1" });
                pcToobar.ginit({ pID: "#txtHuiMuDiDiShengFen", cID: "#txtHuiMuDiDiChengShi", pSelect: '<%=HuiMuDiDiShengFenId %>', cSelect: '<%=HuiMuDiDiChengShiId %>', comID: '<%=this.SiteUserInfo.CompanyId %>', isCy: "1" });
                $("#<%=btn.ClientID %>").click(function() { PlanEdit.save(this); });

                $(".Offers").live("click", function() {
                    $(this).attr("id", "btn_" + parseInt(Math.random() * 100000));
                    var url = "/CommonPage/UserSupper.aspx?aid=" + $(this).attr("id") + "&";
                    var hideObj = $(this).parent().find("input[name='ShowID']");
                    var showObj = $(this).parent().find("input[name='SourceName']");
                    if (!hideObj.attr("id")) {
                        hideObj.attr("id", "hideID_" + parseInt(Math.random() * 10000000));
                    }
                    if (!showObj.attr("id")) {
                        showObj.attr("id", "ShowID_" + parseInt(Math.random() * 10000000));
                    }
                    url += $.param({ suppliertype: 2, hideID: $("#" + hideObj.attr("id")).val(), callBack: "CallBackSource", isall: 1 })
                    Boxy.iframeDialog({ iframeUrl: url, title: "选择供应商", modal: true, width: "880", height: "350" });
                });
            },
            save: function(obj) {
                if (!PlanEdit.CheckForm()) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "post", cache: false, url: window.location.href + "&dotype=save", dataType: "json",
                    data: $("#<%=form1.ClientID %>").serialize(),
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            PlanEdit.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { PlanEdit.save(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { PlanEdit.save(obj); }).css({ "color": "" });
                    }
                });
            },
            CheckForm: function() {
                var _v1 = ValiDatorForm.validator($("#<%=btn.ClientID %>").closest("form").get(0), "parent");
                if (!_v1) return false;
                var _daiLiShangShuLiang = 0;
                $("input:[name='SourceName']").each(function() { if ($.trim($(this).val()).length > 0) _daiLiShangShuLiang++; })
                if (_daiLiShangShuLiang == 0) { tableToolbar._showMsg("请至少添加一条代理商信息!"); return false; }

                var _vJiFen = true;
                $("#table_xl tr.xlitem").find("input[name='txt_xl_jifen']").each(function() {
                    if (tableToolbar.getInt($(this).val()) > 500) _vJiFen = false;
                });

                if (!_vJiFen) {
                    alert("线路单人积分不能大于500分"); return false;
                }

                if ("<%=(int)ZxsJiFenStatus %>" == "<%=(int)EyouSoft.Model.EnumType.PtStructure.ZhuanXianShangJiFenStatus.禁用 %>") {
                    alert("您的账号已被禁止发放积分，为线路产品设置的积分将不会发放。");
                }

                if (iPage.getKongWeiShuLiang() < tableToolbar.getInt($("#<%=txtPingTaiShuLiang.ClientID %>").val())) {
                    alert("平台收客数量不能大于控位数量合计。"); return false;
                }

                if (!iPage.yanZhengXianDingRenShu()) {
                    alert("线路【每单至少人数】不能大于【每单不超过人数】。"); return false;
                }

                return true;
            }
        };

        var iPage = {
            insertXL: function(obj) {
                var _$tr = $(obj).closest("tr").clone(true);
                _$tr.find("input").val("");
                var _riqis = rili.getRiQis();
                _$tr.find("textarea").val(JSON.stringify(_riqis));
                _$tr.find("a.a_xl_riqi").text('共' + _riqis.length + '个日期，点击查看');
                _$tr.find("span.span_xianlucode").html('');
                $("#table_xl").append(_$tr);

                $("#table_xl").find(".xlindex").each(function(i) { $(this).html(i + 1) });
            },
            deleteXL: function(obj) {
                if ($("#table_xl").find("tr.xlitem").length == 1) { alert("至少要保留一行"); return; }
                var _$tr = $(obj).closest("tr");
                _$tr.remove();
                $("#table_xl").find(".xlindex").each(function(i) { $(this).html(i + 1) });
            },
            xuanZeXL: function(obj) {
                var _data = {};
                _data["RefererIframeId"] = '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>';
                _data["rowindex"] = $(".xuanzexl").index($(obj));

                top.Boxy.iframeDialog({ iframeUrl: "xuanzexianlu.aspx", title: "选择线路", modal: true, data: _data, width: "860", height: "380" });
            },
            initQuYuShengFenChengShi: function(options) {
                //options:{txtShengFen:"省份selectid",txtChengShi:"城市selectid",leiXing:"类型：去程出发地 去程目的地",shengFenId:"选中的省份编号",chengShiId:"选中的城市编号"}
                if (typeof zxsQuYu == "undefined") return;
                if (zxsQuYu.length == 0) return;
                var _quYuId = $("#txtQuYu").val();
                var _shengFenChengShiItems = [];
                for (var i = 0; i < zxsQuYu.length; i++) {
                    if (_quYuId == zxsQuYu[i].Id) {
                        _shengFenChengShiItems = zxsQuYu[i].ShengFenChengShis;
                        break;
                    }
                }

                $("#" + options.txtShengFen).unbind("change").change(function() { _initChengShi(); });

                _initShengFen();
                _initChengShi();

                function _initShengFen() {
                    var _items = [];
                    _items.push({ ShengFenId: "", ShengFenMingCheng: "--请选择--" });
                    for (var i = 0; i < _shengFenChengShiItems.length; i++) {
                        var _shengFenChengShiItem = _shengFenChengShiItems[i];
                        if (_shengFenChengShiItem.LeiXing != options.leiXing) continue;
                        var _isPush = true;
                        for (var j = 0; j < _items.length; j++) {
                            if (_items[j].ShengFenId == _shengFenChengShiItem.ShengFenId) { _isPush = false; break; }
                        }
                        if (_isPush) {
                            var _item = { ShengFenId: _shengFenChengShiItem.ShengFenId, ShengFenMingCheng: _shengFenChengShiItem.ShengFenMingCheng };
                            _items.push(_item);
                        }
                    }

                    $("#" + options.txtShengFen).empty();
                    var _s = [];
                    for (var i = 0; i < _items.length; i++) {
                        _s.push('<option value="' + _items[i].ShengFenId + '">' + _items[i].ShengFenMingCheng + '</option>');
                    }
                    $("#" + options.txtShengFen).append(_s.join(''));
                    //data-isinit:是否初始化过选中值
                    if (options.shengFenId.length > 0 && $("#" + options.txtShengFen).attr("data-isinit") != "1") {
                        $("#" + options.txtShengFen).val(options.shengFenId).attr("data-isinit", "1");

                    } else {
                        if (_items.length > 1) $("#" + options.txtShengFen)[0].selectedIndex = 1;
                    }
                }

                function _initChengShi() {
                    var _items = [];
                    _items.push({ ChengShiId: "", ChengShiMingCheng: "--请选择--" });
                    var _shengFenId = $("#" + options.txtShengFen).val();
                    for (var i = 0; i < _shengFenChengShiItems.length; i++) {
                        var _shengFenChengShiItem = _shengFenChengShiItems[i];
                        if (_shengFenChengShiItem.LeiXing != options.leiXing) continue;
                        if (_shengFenChengShiItem.ShengFenId != _shengFenId) continue;
                        var _item = { ChengShiId: _shengFenChengShiItem.ChengShiId, ChengShiMingCheng: _shengFenChengShiItem.ChengShiMingCheng }
                        _items.push(_item);
                    }

                    $("#" + options.txtChengShi).empty();
                    var _s = [];
                    for (var i = 0; i < _items.length; i++) {
                        _s.push('<option value="' + _items[i].ChengShiId + '">' + _items[i].ChengShiMingCheng + '</option>');
                    }
                    $("#" + options.txtChengShi).append(_s.join(''));
                    //data-isinit:是否初始化过选中值
                    if (options.chengShiId.length > 0 && $("#" + options.txtChengShi).attr("data-isinit") != "1") {
                        $("#" + options.txtChengShi).val(options.chengShiId).attr("data-isinit", "1");
                    } else {
                        if (_items.length > 1) $("#" + options.txtChengShi)[0].selectedIndex = 1;
                    }
                }
            },
            //获取控位数量
            getKongWeiShuLiang: function() {
                var _shuLiang = 0;
                $("input[name='txtCount']").each(function() {
                    var _daiLiShuLiang = tableToolbar.getInt($(this).val());
                    _shuLiang = tableToolbar.calculate(_shuLiang, _daiLiShuLiang, "+");
                });
                return _shuLiang;
            },
            getHDItems: function() {
                return $("#table_hangduan").find(".hd_item");
            },
            initHDS: function() {
                $(".hd_tianjia").click(function() { iPage.insertHD(this, true); });
                $(".hd_shanchu").click(function() { iPage.deleteHD(this); });
                $("select[name='txt_hd_banci_01']").change(function() { $(this).closest("td").find("input").val($(this).val()); });

                if (typeof hangDuans == "undefined" || hangDuans.length == 0) {
                    _$tr = this.getHDItems().eq(0);
                    this.initHD(_$tr, null);
                    return;
                }

                for (var i = 0; i < hangDuans.length; i++) {
                    var _$tr = null;
                    if (i == 0) { _$tr = this.getHDItems().eq(0); }
                    else { _$tr = this.insertHD(null, false); }
                    this.initHD(_$tr, hangDuans[i]);
                }
            },
            initHD: function($tr, data) {
                var _sf1 = "txt_hd_chufadi_shengfen_" + parseInt(Math.random() * 10000);
                var _cs1 = "txt_hd_chufadi_chengshi_" + parseInt(Math.random() * 10000);
                var _sf2 = "txt_hd_mudidi_shengfen_" + parseInt(Math.random() * 10000);
                var _cs2 = "txt_hd_mudidi_chengshi_" + parseInt(Math.random() * 10000);

                $tr.find("select[name='txt_hd_chufadi_shengfen']").unbind("change").attr("id", _sf1);
                $tr.find("select[name='txt_hd_chufadi_chengshi']").unbind("change").attr("id", _cs1);
                $tr.find("select[name='txt_hd_mudidi_shengfen']").unbind("change").attr("id", _sf2);
                $tr.find("select[name='txt_hd_mudidi_chengshi']").unbind("change").attr("id", _cs2);

                var _sf1_v = "", _cs1_v = "", _sf2_v = "", _cs2_v = "";

                if (data != null) {
                    $tr.find("input[name='txt_hd_riqi']").val(this.formatJsonDateTime(data.RiQi));
                    $tr.find("select[name='txt_hd_jiaotong']").val(data.JiaoTongId);
                    $tr.find("input[name='txt_hd_banci']").val(data.BanCi);
                    $tr.find("input[name='txt_hd_beizhu']").val(data.BeiZhu);

                    _sf1_v = data.ChuFaShengFenId;
                    _cs1_v = data.ChuFaChengShiId;
                    _sf2_v = data.MuDiDiShengFenId;
                    _cs2_v = data.MuDiDiChengShiId;

                }

                pcToobar.ginit({ pID: "#" + _sf1, cID: "#" + _cs1, pSelect: _sf1_v, cSelect: _cs1_v, comID: '<%=this.SiteUserInfo.CompanyId %>', isCy: "1" });
                pcToobar.ginit({ pID: "#" + _sf2, cID: "#" + _cs2, pSelect: _sf2_v, cSelect: _cs2_v, comID: '<%=this.SiteUserInfo.CompanyId %>', isCy: "1" });
            },
            insertHD: function(obj, isInit) {
                var _$tr = this.getHDItems().eq(0).clone(true);
                _$tr.find("input").val("");
                $("#table_hangduan").append(_$tr);
                $("#table_hangduan").find(".hd_index").each(function(i) { $(this).html(i + 1) });

                if (isInit) this.initHD(_$tr, null);

                return _$tr;
            },
            deleteHD: function(obj) {
                if (this.getHDItems().length == 1) { alert("至少要保留一个航段信息"); return; }
                $(obj).closest("tr").remove();
                $("#table_hangduan").find(".hd_index").each(function(i) { $(this).html(i + 1) });
            },
            formatJsonDateTime: function(jsonDateTime) {
                var _rgExp = /-?\d+/;
                var _matchResult = _rgExp.exec(jsonDateTime);
                var d = new Date(parseInt(_matchResult[0]));
                return d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
            },
            initQuBanCi: function() {
                $("#txtQuChengBanCi").empty();
                $("#txtQuChengBanCi").append('<option value="">-请选择-</options>')
                if (typeof quBanCi == "undefined") return;
                if (quBanCi == null || quBanCi.length == 0) return;
                var _quYuId = $("#txtQuYu").val();
                if (_quYuId.length == 0) return;

                var _s = [];
                for (var i = 0; i < quBanCi.length; i++) {
                    if (quBanCi[i].QuYus == null || quBanCi[i].QuYus.length == 0) continue;
                    var _isFind = false;
                    for (var j = 0; j < quBanCi[i].QuYus.length; j++) {
                        if (quBanCi[i].QuYus[j].QuYuId == _quYuId) { _isFind = true; break; }
                    }
                    if (_isFind)
                        _s.push('<option value="' + quBanCi[i].Name + '">' + quBanCi[i].Name + '</option>');
                }

                $("#txtQuChengBanCi").append(_s.join(''));
            },
            initHuiBanCi: function() {
                $("#txtHuiChengBanCi").empty();
                $("#txtHuiChengBanCi").append('<option value="">-请选择-</option>')
                if (typeof huiBanCi == "undefined") return;
                if (huiBanCi == null || huiBanCi.length == 0) return;
                var _quYuId = $("#txtQuYu").val();
                if (_quYuId.length == 0) return;

                var _s = [];
                for (var i = 0; i < huiBanCi.length; i++) {
                    if (huiBanCi[i].QuYus == null || huiBanCi[i].QuYus.length == 0) continue;
                    var _isFind = false;
                    for (var j = 0; j < huiBanCi[i].QuYus.length; j++) {
                        if (huiBanCi[i].QuYus[j].QuYuId == _quYuId) { _isFind = true; break; }
                    }
                    if (_isFind)
                        _s.push('<option value="' + huiBanCi[i].Name + '">' + huiBanCi[i].Name + '</option>');
                }

                $("#txtHuiChengBanCi").append(_s.join(''));
            },
            yanZhengXianDingRenShu: function() {
                var _$items = $("#table_xl tr.xlitem");
                var _v = true;

                _$items.each(function() {
                    var _$item = $(this);
                    var _zuiDaRenShu = tableToolbar.getInt(_$item.find("input[name='txt_xl_xiandingrenshu']").val());
                    var _zuiXiaoRenShu = tableToolbar.getInt(_$item.find("input[name='txt_xl_zuixiaorenshu']").val());

                    if (_zuiDaRenShu > 0 && _zuiXiaoRenShu > _zuiDaRenShu) _v = false;
                });

                return _v;
            }
        };
    </script>
</body>
</html>



