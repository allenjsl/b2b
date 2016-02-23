<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiJieSheZhuTiEdit.aspx.cs" Inherits="Web.ResourceManage.DiJieSheZhuTiEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 99%; margin: 0px auto;margin-top:5px;">
        <form id="form1" runat="server">
    
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="130" height="30" align="right">
                    <font class="xinghao">*</font>地接社主体名称：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtGysName" runat="server" valid="required" errmsg="请输入地接社主体名称" style="width:280px;" />
                </td> 
            </tr>
            <tr class="even">
                <th height="30" align="right">
                   <font class="xinghao">*</font>所在省市：
                </th>
                <td align="left">
                    <select name="txtShengFen" id="txtShengFen" class="inputselect" valid="required" errmsg="请选择省份">
                    </select>
                    <select name="txtChengShi" id="txtChengShi" class="inputselect" valid="required" errmsg="请选择城市">
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    联系人姓名：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtLxrName" runat="server" style="width: 280px;" />
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height:30px;">
                    联系人电话：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtLxrDianHua" runat="server" style="width: 280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    联系人手机：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtLxrShouJi" runat="server" style="width: 280px;" />
                </td>
            </tr>
            <tr class="even">
                <th align="right" style="height: 30px;">
                    联系传真：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtFax" runat="server" style="width: 280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right" >
                   公司地址：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtDiZhi" style="width:280px;" runat="server" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    主体与地接社关系：
                </th>
                <td align="left">
                    <ul id="ul_guanxi">
                        <li>&nbsp;<a href="javascript:void(0)" id="a_xuanyongdijieshe">点击这里选择其他地接社</a>，以下为已选择的地接社信息，请根据需要进行调整：</li>
                    </ul>
                </td>
            </tr>
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02">
                                <asp:Literal runat="server" ID="ltrCaoZuo" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        </form>
    </div>
    
    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            reload: function() {
                window.location.href = window.location.href;
                return false;
            },
            xuanYongDiJieShe: function() {
                var _data = { RefererIframeId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>', gysZhuTiId: '<%=EyouSoft.Common.Utils.GetQueryStringValue("editid") %>' }
                top.Boxy.iframeDialog({ title: "选择完成后请直接关闭该窗口", iframeUrl: "xuanyongdijieshe.aspx", width: "800px", height: "500px", data: _data, afterHide: function() { } });
                return false;
            },
            setGuanXi: function(data) {
                if (typeof data == "undefined" || typeof data.gysid == "undefined" || typeof data.gysname == "undefined") return;
                var _$obj = $("#ul_guanxi").find('input[name="txtGuanXiGysId"][value="' + data.gysid + '"]');
                if (_$obj.length > 0) return;

                var s = [];
                s.push('<li class="guanxiitem">');
                s.push('<input name="txtGuanXiGysId" type="hidden" value="' + data.gysid + '"/>&nbsp;');
                s.push(data.gysname);
                s.push('&nbsp;<a href="javascript:void(0)" class=\"guanxishanchu\">删除</a>');
                s.push('</li>');
                var _$html = $(s.join(''));
                _$html.find("a.guanxishanchu").click(function() { iPage.shanChuGuanXi2(this); });

                $("#ul_guanxi").append(_$html);
            },
            shanChuGuanXi1: function(data) {
                if (typeof data == "undefined" || typeof data.gysid == "undefined" || typeof data.gysname == "undefined") return;
                var _$obj = $("#ul_guanxi").find('input[name="txtGuanXiGysId"][value="' + data.gysid + '"]');
                if (_$obj.length == 0) return;

                this.shanChuGuanXi2(_$obj);
            },
            shanChuGuanXi2: function(obj) {
                $(obj).closest("li").remove();
            },
            getGuanXis: function() {
                var r = [];
                $("#ul_guanxi").find('input[name="txtGuanXiGysId"]').each(function() {
                    r.push($(this).val());
                });
                return r;
            },
            initGuanXis: function() {
                if (typeof guanXiItems == "undefined" || guanXiItems.length == 0) return;

                for (var i = 0; i < guanXiItems.length; i++) {
                    this.setGuanXi({ gysid: guanXiItems[i].GysId, gysname: guanXiItems[i].GysName });
                }
            },
            baoCun: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
                    success: function(response) {
                        alert(response.msg);
                        if (response.result == "1") {
                            iPage.close();
                        } else {
                            $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.baoCun(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            $("#a_xuanyongdijieshe").click(function() { iPage.xuanYongDiJieShe(); });
            pcToobar.init({ pID: "#txtShengFen", cID: "#txtChengShi", pSelect: '<%= ShengFenId %>', cSelect: '<%=ChengShiId %>', comID: '<%= this.SiteUserInfo.CompanyId %>', isCy: "0" });
            iPage.initGuanXis();
            $("#a_baocun").click(function() { iPage.baoCun(this); });
        });
    </script>
</asp:Content>
