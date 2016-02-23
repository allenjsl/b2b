<%@ Page Title="代订酒店" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="ScheduleHotelList.aspx.cs" Inherits="Web.TeamPlan.ScheduleHotel" %>

<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">收客计划</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            <b>所在位置：</b> &gt;&gt; 收客计划 &gt;&gt; 代订酒店
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <form method="get" id="form1">
        <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="10" valign="top">
                        <img src="/images/yuanleft.gif">
                    </td>
                    <td>
                        <div class="searchbox">
                            出团日期：
                            <input type="text" size="12" id="sd" class="searchinput inputtext" name="sd" onfocus="WdatePicker()" />
                            -
                            <input type="text" size="12" id="ed" class="searchinput inputtext" name="ed" onfocus="WdatePicker()" />
                            订单号：
                            <input type="text" size="12" id="ono" class="searchinput inputtext" name="ono" />
                            交易号：
                            <input type="text" size="12" id="txtJiaoYiHao" class="searchinput inputtext" name="txtJiaoYiHao" />
                            酒店名称：
                            <input type="text" size="12" id="hName" class="searchinput inputtext" name="hName" />
                            游客姓名：
                            <input type="text" size="12" id="cName" class="searchinput inputtext" name="cName" /><br />
                            核算状态：<select name="txtKongWeiZhuangTai" id="txtKongWeiZhuangTai" class="inputselect"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.KongWeiZhuangTai)), "", "-1", "-请选择-")%></select>
                            <input type="image" src="/images/searchbtn.gif" style="vertical-align: middle;" />
                        </div>
                    </td>
                    <td width="10" valign="top">
                        <img src="/images/yuanright.gif" alt="" />
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
        <div class="btnbox">
            <table cellspacing="0" cellpadding="0" border="0" align="left">
                <tbody>
                    <tr>
                        <td width="90" align="center">
                            <a id="addbox" class="toolbar_add" href="javascript:void(0)">新 增</a>
                        </td>
                        <td width="90" align="center">
                            <a id="updatebox" class="toolbar_update" href="javascript:void(0)">修 改</a>
                        </td>
                        <td width="90" align="center">
                            <a id="deletebox" class="toolbar_delete" href="javascript:void(0)">删 除</a>
                        </td>
                        <asp:PlaceHolder runat="server" ID="phHeSuanJieShu">
                            <td width="90" align="center">
                                <a href="javascript:void(0)" id="i_a_hesuanjieshu">核算结束</a>
                            </td>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="phQuXiaoHeSuanJieShu">
                            <td width="90" align="center">
                                <a href="javascript:void(0)" id="i_a_quxiaohesuanjieshu">取消核算</a>
                            </td>
                        </asp:PlaceHolder>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="tablelist">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
                <tbody>
                    <tr>
                        <th width="7%" height="30" bgcolor="#BDDCF4" align="center">
                            <input type="checkbox" id="ckbAll" name="ckbAll" />
                            全选
                        </th>
                        <th width="10%" bgcolor="#bddcf4" align="center">
                            订单号
                        </th>
                        <th width="23%" bgcolor="#bddcf4" align="left" class="pandl3">
                            客户单位
                        </th>
                        <th width="11%" bgcolor="#bddcf4" align="center">
                            对方操作人
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            <p>
                                酒店名称</p>
                        </th>
                        <th bgcolor="#bddcf4" align="center">
                            操作人
                        </th>
                        <th width="23%" bgcolor="#bddcf4" align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptHotel">
                        <ItemTemplate>
                            <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                                <td height="30" align="center">
                                    <input type="checkbox" id="ckb<%# Container.ItemIndex %>" name="ckb<%# Container.ItemIndex %>"
                                        value="<%# Eval("KongWeiId") %>" />
                                    <%# GetIndex(Container.ItemIndex)%>
                                </td>
                                <td align="center">
                                    <%# GetOrderCode(Eval("OrderCode"),Eval("KongWeiZhuangTai"))%>
                                </td>
                                <td align="left" class="pandl3">
                                    <%# Eval("BuyCompanyName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("BuyOperatorName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("HotelName")%>
                                </td>
                                <td align="center">
                                    <%# Eval("OperatorName")%>
                                </td>
                                <td align="center">
                                    <a href="javascript:void(0)" class="showorderinfo" data-tourid="<%# Eval("KongWeiId") %>">
                                        查看</a> | <a target="_blank" href="/PrintPage/ScheduleHotel.aspx?tourId=<%# Eval("KongWeiId") %>"
                                            class="qurendan">确认单</a> | <a href="javascript:void(0)" class="teamAccount" data-tourid="<%# Eval("KongWeiId") %>">
                                                团队结算</a> | <a class="historybox" href="javascript:void(0)" data-orderid="<%# Eval("OrderId") %>">
                                                    变更历史</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right">
                            <cc1:ExporPageInfoSelect runat="server" ID="page1" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        var HotelList = {
            //ajax执行文件路径,默认为本页面
            ajaxurl: "/TeamPlan/ScheduleHotelList.aspx",            
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            //添加
            Add: function() {
                if ("<%= IsAdd %>" == "True") {
                    HotelList.ShowBoxy({ iframeUrl: "/TeamPlan/ScheduleHotelAdd.aspx?dotype=add", title: "新增酒店代订", width: "970px", height: "600px" });
                }
                else {
                    tableToolbar._showMsg("您没有新增权限！");
                }
            },
            //修改(弹窗)---objsArr选中的TR对象
            Update: function(ObjsArr) {
                if ("<%= IsEdit %>" == "True") {
                    HotelList.ShowBoxy({ iframeUrl: "/TeamPlan/ScheduleHotelAdd.aspx?dotype=edit&id=" + ObjsArr[0].find("input[type='checkbox']").val(), title: "修改代订酒店", width: "970px", height: "600px" });
                }
                else {
                    tableToolbar._showMsg("您没有修改权限！");
                }
            },
            GetCheckBox: function(objArr) {
                //定义数组对象
                var list = new Array();
                //遍历按钮返回数组对象
                for (var i = 0; i < objArr.length; i++) {
                    //从数组对象中找到数据所在，并保存到数组对象中
                    if (objArr[i].find("input[type='checkbox']").val() != "on") {
                        list.push(objArr[i].find("input[type='checkbox']").val());
                    }
                }
                return list.join(',');
            },
            //删除(可多行)
            DelAll: function(objArr) {
                if ("<%= IsDel %>" == "True") {
                    /*tableToolbar.ShowConfirmMsg("确定要删除所选择的数据吗？", function() {
                    //获取默认路径并重新拼接url（注：全局变量劲量不要改变，当常量就行）
                    HotelList.ajaxurl += "?doType=del&hid=" + HotelList.GetCheckBox(objArr);
                    //执行ajax
                    HotelList.GoAjax(HotelList.ajaxurl);
                    });*/
                    HotelList.ajaxurl += "?doType=del&hid=" + HotelList.GetCheckBox(objArr);
                    HotelList.GoAjax(HotelList.ajaxurl);
                }
                else {
                    tableToolbar._showMsg("您没有删除权限！");
                }

            },
            //Ajax请求
            GoAjax: function(url) {
                $.newAjax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { location.reload(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg);
                    }
                });
            },
            //显示弹窗
            ShowBoxy: function(data) {
                Boxy.iframeDialog({
                    iframeUrl: data.iframeUrl,
                    title: data.title,
                    modal: true,
                    width: data.width,
                    height: data.height
                });
            },
            //查看订单
            ShowInfo: function(tourid) {
                HotelList.ShowBoxy({ iframeUrl: "/TeamPlan/ScheduleHotelAdd.aspx?dotype=show&id=" + tourid, title: "查看代订酒店", width: "970px", height: "600px" });
            },
            ShowHistory: function(orderId) {
                HotelList.ShowBoxy({
                    iframeUrl: "/commonpage/biangenglist.aspx?bianId=" + orderId + "&bianType=<%= (int)EyouSoft.Model.EnumType.TourStructure.BianType.代订酒店 %>",
                    title: "变更历史",
                    width: "320px",
                    height: "200px"
                });
            },
            BindBtn: function() {
                //绑定Add事件
                $(".toolbar_add").click(function() {
                    HotelList.Add();
                    return false;
                })

                $(".showorderinfo").click(function() {
                    //绑定的团号
                    var tourid = $(this).attr("data-tourid");
                    HotelList.ShowInfo(tourid);
                    return false;
                })
                $(".historybox").click(function() {
                    var _orderId = $(this).attr("data-orderid");
                    HotelList.ShowHistory(_orderId);
                    return false;
                })

                $(".teamAccount").click(function() {
                    //绑定的团号
                    if ("<%=Privs_TuanDuiJieSuan %>" == "0") {
                        tableToolbar._showMsg("你没有团队结算的权限！");
                        return false;
                    }
                    var tourid = $(this).attr("data-tourid");
                    location.href = "/TeamPlan/TeamAccounts.aspx?type=hotel&tourId=" + tourid + "&rurl=" + encodeURIComponent(window.location.href);
                    return false;
                });

                tableToolbar.init({
                    tableContainerSelector: "#liststyle", //表格选择器
                    objectName: "行", //

                    //修改-删除-取消-复制 为默认按钮，按钮class对应  toolbar_update  toolbar_delete  toolbar_cancel  toolbar_copy即可
                    updateCallBack: function(obj) {
                        //修改
                        HotelList.Update(obj);
                    },
                    deleteCallBack: function(objsArr) {
                        //删除(批量)
                        HotelList.DelAll(objsArr);
                    }
                })
            },
            //核算结束
            heSuanJieShu: function(obj) {
                var _data = { txtKongWeiId: [] };
                $("input[type='checkbox'][name!='ckbAll']:checked").each(function() {
                    _data.txtKongWeiId.push($(this).val());
                });

                if (_data.txtKongWeiId.length == 0) {
                    tableToolbar._showMsg("请选择要核算结束的控位信息！");
                    return;
                }

                if (!confirm("核算结束后，不能进行修改操作！\n你确定要核算结束吗？")) return;

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "hesuanjieshu" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            HotelList.reload();
                        } else {
                            alert(response.msg);
                        }
                    }
                });
            },
            //取消核算结束
            quXiaoHeSuanJieShu: function(obj) {
                var _data = { txtKongWeiId: [] };
                $("input[type='checkbox'][name!='ckbAll']:checked").each(function() {
                    _data.txtKongWeiId.push($(this).val());
                });

                if (_data.txtKongWeiId.length == 0) {
                    tableToolbar._showMsg("请选择要取消核算结束的控位信息！");
                    return;
                }

                if (!confirm("取消核算结束后，能进行修改操作！\n你确定要取消核算结束吗？")) return;

                $.newAjax({
                    type: "POST",
                    url: utilsUri.createUri(window.location.href, { doType: "quxiaohesuanjieshu" }),
                    data: _data,
                    cache: false,
                    dataType: "json",
                    async: false,
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            HotelList.reload();
                        } else {
                            alert(response.msg);
                        }
                    }
                });
            }
        };

        $(function() {
            utilsUri.initSearch();
            HotelList.BindBtn();

            $("#i_a_hesuanjieshu").bind("click", function() { HotelList.heSuanJieShu(this); });
            $("#i_a_quxiaohesuanjieshu").bind("click", function() { HotelList.quXiaoHeSuanJieShu(this); });
        });
    </script>

</asp:Content>
