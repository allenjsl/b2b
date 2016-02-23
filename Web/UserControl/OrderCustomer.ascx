<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderCustomer.ascx.cs"
    Inherits="Web.UserControl.OrderCustomer" %>
<div style="width: 99%; margin: 0 auto; margin-top:5px">
    <div>
    <span class="formtableT">游客信息</span> 
    <input type="button" id="btnYouKeDaoRu" value="从Excel导入游客名单" />
    <input type="button" id="btnYouKeLeiXing1" value="按游客身份证号码设置游客类型" />
    <input type="button" id="btnYouKeLeiXing2" value="按录入的游客人数设置游客类型" />
    </div>
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" id="tbl_Customer_AutoAdd">
        <tbody>
            <tr class="odd">
                <th width="36" height="30">
                    编号
                </th>
                <th>
                    姓名
                </th>
                <th>
                    类型
                </th>
                <th>
                    证件类型
                </th>
                <th>
                    证件号码
                </th>
                <th>
                    性别
                </th>
                <th>
                    联系电话
                </th>
                <th>
                    游客状态
                </th>
                <th>
                    出票状态
                </th>
                <th width="110">
                    操作
                </th>
            </tr>
            <asp:PlaceHolder runat="server" ID="plnAdd">
                <tr class="odd tempRow youkeitem" data-ticketstatus="<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>"
                    data-youkestatus="<%=(int)EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团 %>">
                    <td height="30" align="center">
                        <b class="index">1</b>
                    </td>
                    <td align="center">
                        <input type="hidden" name="hid_OrderCustomer_CustomerId" value="" />
                        <input type="text" class="formsize40 inputtext" name="txt_OrderCustomer_Name" />
                    </td>
                    <td align="center">
                        <%= GetCustomerType(string.Empty) %>
                    </td>
                    <td align="center">
                        <%= GetCustomerCard(string.Empty)%>
                    </td>
                    <td align="center">
                        <input type="text" class="formsize120 inputtext" name="txt_OrderCustomer_CardNo">
                    </td>
                    <td align="center">
                        <%= GetCustomerSex(string.Empty)%>
                    </td>
                    <td align="center">
                        <input type="text" class="formsize100 inputtext" name="txt_OrderCustomer_Tel">
                    </td>
                    <td align="center">
                        <%= GetCustomerStatus(-1) %>
                    </td>
                    <td align="center">
                        --
                    </td>
                    <td align="center">
                        <a href="javascript:void(0)">
                            <img src="/images/addimg.gif" class="addbtn" height="20" width="48"></a>&nbsp;
                        <a href="javascript:void(0)">
                            <img src="/images/delimg.gif" class="delbtn" height="20" width="48"></a>
                        <br>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:Repeater runat="server" ID="rptCustomer">
                <ItemTemplate>
                    <tr bgcolor="<%# Container.ItemIndex % 2 == 0 ? "#E3F1FC" : "#BDDCF4" %>" class="tempRow youkeitem"
                        data-ticketstatus="<%# (int)Eval("TicketType") %>" data-isedit="1" data-youkestatus="<%#(int)Eval("TravellerStatus") %>">
                        <td height="30" align="center">
                            <b class="index"><%#Container.ItemIndex+1 %> </b>
                        </td>
                        <td align="center">
                            <input type="hidden" name="hid_OrderCustomer_CustomerId" value="<%# Eval("TravellerId") %>" />
                            <input type="text" class="formsize40 inputtext" name="txt_OrderCustomer_Name" value="<%# Eval("TravellerName")  %>" />
                        </td>
                        <td align="center">
                            <%# GetCustomerType((int)Eval("TravellerType"))%>
                        </td>
                        <td align="center">
                            <%# GetCustomerCard((int)Eval("CardType"))%>
                        </td>
                        <td align="center">
                            <input type="text" class="formsize120 inputtext" name="txt_OrderCustomer_CardNo"
                                value="<%# Eval("CardNumber") %>">
                        </td>
                        <td align="center">
                            <%# GetCustomerSex((int)Eval("Sex"))%>
                        </td>
                        <td align="center">
                            <input type="text" class="formsize100 inputtext" name="txt_OrderCustomer_Tel" value="<%# Eval("Contact") %>">
                        </td>
                        <td align="center">
                            <%# GetCustomerStatus((int)Eval("TravellerStatus"))%>
                        </td>
                        <td align="center">
                            <%# Eval("TicketType")%>
                        </td>
                        <td align="center">
                            <a href="javascript:void(0)">
                                <img class="addbtn" src="/images/addimg.gif" height="20" width="48"></a>&nbsp;
                            <asp:PlaceHolder runat="server" ID="plnDel" Visible='<%# GetCustomerIsEdit((int)Eval("TicketType")) %>'>
                                <a href="javascript:void(0)">
                                    <img src="/images/delimg.gif" class="delbtn" height="20" width="48"></a>
                            </asp:PlaceHolder>
                            <br>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>

<script type="text/javascript">

    var OrderCustomerControl = {
        clearTr: function() {
            $("#tbl_Customer_AutoAdd").find(".tempRow").remove();
        },
        selectDropDownList: function(cId, text) {
            var ddl = document.getElementById("ddl_" + cId);
            if (ddl.length == 0) return;
            for (var i = 0; i < ddl.length; i++) {
                if (ddl.options[i].text == text)
                    ddl.options[i].selected = true;
            }
        },
        deleteTr: function(obj) {
            var trCount = $("#tbl_Customer_AutoAdd").find("input[name='hid_OrderCustomer_CustomerId']").length;
            if (trCount > 1) {
                $(obj).closest("tr").remove();
            }
            else {
                tableToolbar._showMsg("至少要保留一行！");
            }
            this.initIndex();
        },
        ControlCustomer: function() {
            return false; //已出票游客信息控制成可以修改，以下脚本暂不执行 WANG20130124
            if ("<%= IsEditOrderCustomer %>" == "True") return false;
            $("#tbl_Customer_AutoAdd").find("tr[data-isedit='1']").each(function() {
                var ts = $(this).attr("data-ticketstatus");
                if (ts != "0") {
                    $(this).find("input[type='text']").attr("readonly", "readonly").css({ "background-color": "#dadada" });
                    $(this).find("select[data-isEdit!='1']").css({ "background-color": "#dadada" }).find("option").each(function() {
                        if ($(this).attr("selected")) {
                            return;
                        }
                        $(this).remove();
                    })
                }
            });
        },
        addCustomer: function(args) {
            if (!args) {
                args = ['', '成人', '身份证', '', '未知', ''];
            }
            var s1 = Math.round(Math.random() * new Date().getTime());
            var s2 = Math.round(Math.random() * new Date().getTime());
            var s3 = Math.round(Math.random() * new Date().getTime());
            var s4 = Math.round(Math.random() * new Date().getTime());
            var s5 = Math.round(Math.random() * new Date().getTime());
            var trCount = $("#tbl_Customer_AutoAdd").find("input[name='hid_OrderCustomer_CustomerId']").length;
            var trTemplate = "";

            trTemplate += '<tr class="odd tempRow youkeitem" data-ticketstatus="<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>" data-youkestatus="<%=(int)EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团 %>">';
            //索引
            trTemplate += '<td height="30" align="center">';
            trTemplate += ('<b class="index">' + (trCount + 1) + '</b>');
            trTemplate += '</td>';
            //姓名
            trTemplate += '<td align="center">';
            trTemplate += ('<input type="hidden" name="hid_OrderCustomer_CustomerId" value="" />');
            trTemplate += ('<input type="text" class="formsize40 inputtext" name="txt_OrderCustomer_Name" value="' + args[0] + '" />');
            trTemplate += '</td>';
            //类型
            trTemplate += '<td align="center">';
            trTemplate += ('<select class="inputselect" name="ddl_OrderCustomer_CustomerType" id="ddl_' + s1 + '">  <option value="0">儿童</option>  <option value="1" selected="selected">成人</option>  <option value="3">婴儿</option><option value="4">全陪</option>  </select> ');
            trTemplate += '</td>';
            //证件类型
            trTemplate += '<td align="center">';
            trTemplate += ('<select class="inputselect" name="ddl_OrderCustomer_CustomerCard" id="ddl_' + s2 + '">  <option value="0">未知</option>  <option value="1" selected="selected">身份证</option>  <option value="2">军官证</option>  <option value="3">台胞证</option>  <option value="4">港澳通行证</option>  <option value="5">户口本</option> <option value="6">护照</option> </select> ');
            trTemplate += '</td>';
            //证件号码
            trTemplate += '<td align="center">';
            trTemplate += ('<input type="text" class="formsize120 inputtext" name="txt_OrderCustomer_CardNo" value="' + args[3] + '" />');
            trTemplate += '</td>';
            //性别
            trTemplate += '<td align="center">';
            trTemplate += ('<select class="inputselect" name="ddl_OrderCustomer_CustomerSex" id="ddl_' + s3 + '">  <option value="0"  selected="selected">未知</option>  <option value="1">女</option>  <option value="2">男</option>  </select> ');
            trTemplate += '</td>';
            //电话
            trTemplate += '<td align="center">';
            trTemplate += ('<input type="text" class="formsize100 inputtext" name="txt_OrderCustomer_Tel" value="' + args[5] + '" />');
            trTemplate += '</td>';
            //游客状态
            trTemplate += '<td align="center">';
            trTemplate += ('<select data-isEdit="1" class="inputselect" name="ddl_OrderCustomer_Status" id="ddl_' + Math.round(Math.random() * new Date().getTime()) + '">  <option value="0" selected="selected">在团</option>  <option value="1">退团</option>  </select>');
            trTemplate += '</td>';
            //游客出票状态
            trTemplate += '<td align="center">';
            trTemplate += ('--');
            trTemplate += '</td>';
            //操作
            trTemplate += '<td align="center">';
            trTemplate += '<a href="javascript:void(0);" id="a_' + s4 + '"><img src="/images/addimg.gif" class="addbtn" height="20" width="48"></a>&nbsp;&nbsp;<a href="javascript:void(0);" id="a_' + s5 + '"><img src="/images/delimg.gif" class="delbtn" height="20" width="48"></a><br>';
            trTemplate += '</td>';
            trTemplate += '</tr>';

            $("#tbl_Customer_AutoAdd").append(trTemplate);
            OrderCustomerControl.selectDropDownList(s1, args[1]);
            OrderCustomerControl.selectDropDownList(s2, args[2]);
            OrderCustomerControl.selectDropDownList(s3, args[4]);
            $("#a_" + s4).click(function() {
                OrderCustomerControl.addCustomer(null);
                return false;
            });
            $("#a_" + s5).click(function() {
                OrderCustomerControl.deleteTr(this);
                return false;
            });
        },
        //获取游客录入表单人数
        getYouKeRenShu: function() {
            return this.getYouKeItems().length;
        },
        //获取游客录入表单items
        getYouKeItems: function() {
            return $("#tbl_Customer_AutoAdd").find("tr.youkeitem");
        },
        //获取有效的游客信息
        getYouXiaoYouKeRenShu: function() {
            var _items = this.getYouKeItems();
            var _jishu = 0;
            _items.each(function() { if ($.trim($(this).find("input[name='txt_OrderCustomer_Name']").val()).length > 0) _jishu++; });

            return _jishu;
        },
        //初始化游客序号
        initIndex: function() {
            var _items = this.getYouKeItems();
            _items.each(function(i) {
                $(this).find("b.index").html(i + 1);
            });
        },
        //获取可以删除的游客录入表单items
        getKeShanChuYouKeItems: function() {
            var _items = this.getYouKeItems();
            var _items1 = [];
            if (_items.length == 0) return _items1;
            for (var i = 0; i < _items.length; i++) {
                var _item = $(_items[i]);
                var _ticketStatus = _item.attr("data-ticketstatus");
                var _youKeStatus = _item.attr("data-youkestatus");
                var _youKeName = $.trim(_item.find("input[name='txt_OrderCustomer_Name']").val());
                var _youKeZhengJianLeiXing = _item.find("select[name='ddl_OrderCustomer_CustomerCard']").val();
                var _youKeXingBie = _item.find("select[name='ddl_OrderCustomer_CustomerSex']").val();
                var _youKeZhengJianHaoMa = $.trim(_item.find("input[name='txt_OrderCustomer_CardNo']").val());
                var _youKeLianXiHaoMa = $.trim(_item.find("input[name='txt_OrderCustomer_Tel']").val());

                if (_ticketStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>"
                    && _youKeStatus == "<%=(int)EyouSoft.Model.EnumType.TourStructure.TravellerStatus.在团 %>"
                    && _youKeName.length == 0
                    && _youKeZhengJianHaoMa.length == 0
                    && _youKeLianXiHaoMa.length == 0
                    && _youKeXingBie == "0") {
                    _items1.push(_item);
                }
            }

            return _items1;
        },
        //获取已出票人数
        getYiChuPiaoRenShu: function() {
            var _items = this.getYouKeItems();
            var _yiChuPiaoRenShu = 0;

            for (var i = 0; i < _items.length; i++) {
                var _item = $(_items[i]);
                var _ticketStatus = _item.attr("data-ticketstatus");
                if (_ticketStatus != "<%=(int)EyouSoft.Model.EnumType.TourStructure.TicketType.未出票 %>") _yiChuPiaoRenShu++;
            }

            return _yiChuPiaoRenShu;
        },
        //按身份证号码初始化游客类型
        initYouKeLeiXing1: function() {
            var _items = this.getYouKeItems();
            var _self = this;
            _items.each(function() {
                var _$zhengJianLeiXing = $(this).find("select[name='ddl_OrderCustomer_CustomerCard']");
                var _$zhengJianHaoMa = $(this).find("input[name='txt_OrderCustomer_CardNo']");
                var _zhengJianHaoMa = $.trim(_$zhengJianHaoMa.val());
                if (_$zhengJianLeiXing.val() != "1" && _zhengJianHaoMa.length != 15 && _$zhengJianHaoMa != 18) return true;
                var _youKeLeiXing = _self.getYouKeLeiXing(_zhengJianHaoMa);
                $(this).find("select[name='ddl_OrderCustomer_CustomerType']").val(_youKeLeiXing);
            });
        },
        //按录入人数初始化游客类型
        initYouKeLeiXing2: function() {
            var _data = {};
            _data.chengRen = tableToolbar.getInt($("input[data-renshu-txt='chengren']").val());
            _data.erTong = tableToolbar.getInt($("input[data-renshu-txt='ertong']").val());
            _data.yingEr = tableToolbar.getInt($("input[data-renshu-txt='yinger']").val());
            _data.quanPei = tableToolbar.getInt($("input[data-renshu-txt='quanpei']").val());
            var _items = this.getYouKeItems();

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
        //按证件号码获取游客类型 12岁以上为成人 2-12岁为儿童 2岁以下为婴儿
        getYouKeLeiXing: function(hm) {
            var _lx = "1";
            if (hm.length != 15 && hm.length != 18) return _lx;
            var _sr = "";
            if (hm.length == 18) {
                _sr = hm.substr(6, 4) + "-" + hm.substr(10, 2) + "-" + hm.substr(12, 2);
            }

            if (hm.length == 15) {
                _sr = "19" + hm.substr(6, 2) + "-" + hm.substr(8, 2) + "-" + hm.substr(10, 2);
            }

            var _zs = this.getZhouSui(_sr);

            if (_zs < 2) { _lx = "3" }
            else if (_zs < 12) { _lx = "0" }
            else _lx = "1";

            return _lx;
        },
        //根据生日获取周岁
        getZhouSui: function(sr) {
            if (sr.length != 10) return 0;
            var _arr = sr.split("-");
            if (_arr.length != 3) return 0;
            var _yyyy = tableToolbar.getInt(_arr[0]);
            var _mm = tableToolbar.getInt(_arr[1]);
            var _dd = tableToolbar.getInt(_arr[2]);

            var _today = new Date();
            var _yyyy1 = _today.getFullYear();
            var _mm1 = _today.getMonth() + 1;
            var _dd1 = _today.getDate();


            var _nianCha = _yyyy1 - _yyyy;
            var _yueCha = _mm1 - _mm;
            var _riCha = _dd1 - _dd;

            if (_nianCha <= 0) return 0;

            if (_yueCha == 0) {
                if (_riCha < 0) return _nianCha - 1;
                return _nianCha;
            }

            if (_yueCha < 0) return _nianCha - 1;

            return _nianCha;
        }
    };

    $(document).ready(function() {
        $("#tbl_Customer_AutoAdd").find(".addbtn").bind("click", function() {
            OrderCustomerControl.addCustomer();
            return false;
        });
        $("#tbl_Customer_AutoAdd").find(".delbtn").bind("click", function() {
            OrderCustomerControl.deleteTr(this);
            return false;
        });

        //控制游客是否可编辑
        OrderCustomerControl.ControlCustomer();

        $("#btnYouKeDaoRu").bind("click", function() {
            parent.Boxy.iframeDialog({
                iframeUrl: "/CommonPage/LoadVisitors.aspx",
                width: "853px",
                height: "514px",
                async: false,
                title: "导入游客信息",
                modal: true,
                data: {
                    topId: '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>',
                    type: "customerLoad"
                }
            });
            return false;
        });

        $("#btnYouKeLeiXing1").click(function() { OrderCustomerControl.initYouKeLeiXing1(); });
        $("#btnYouKeLeiXing2").click(function() { OrderCustomerControl.initYouKeLeiXing2(); });
    });
</script>

