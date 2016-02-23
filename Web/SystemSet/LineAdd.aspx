<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineAdd.aspx.cs" Inherits="Web.SystemSet.LineAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>
    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="../JS/table-toolbar.js" type="text/javascript"></script>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    
    <!--[if lt IE 7]>
    <script type="text/javascript" src="/js/json2.js"></script>
    <![endif]-->
    
    <style type="text/css">    
    .p1{float:left;width:20%;list-style: none;margin: 0px;padding: 0px;}
    .p1 li{line-height:22px;list-style: none;}
    .p1 li.p1title{font-weight:bold;line-height:24px;}    
    .p1 li.p1item{}
    .p2{clear:both;width:100%; height:10px;list-style: none;margin: 0px;padding: 0px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <textarea id="txtShengFenChengShi" name="txtShengFenChengShi" style="display:none;"></textarea>
    <div style="width:99%; margin:0px auto; margin-top:10px;">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 0px auto;">
        <tbody>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    区域名称：
                </th>
                <td bgcolor="#E3F1FC" class="pandl3">
                    <asp:TextBox CssClass="inputtext formsize150" ID="txtAreaName" name="txtAreaName"
                        runat="server" valid="required" errmsg="请输入区域名称"></asp:TextBox>
                    <span style="color:#ff0000;">提示：以出发地-目的地来命名,如海南专线的线路区域名称为:温州-三亚</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    专线类别：
                </th>
                <td bgcolor="#E3F1FC" class="pandl3">
                    <select name="txtZxlb" id="txtZxlb" class="inputselect" valid="required" errmsg="请选择专线类别"
                        data-v="<%=ZxlbId %>">
                        <option value="">请选择</option>
                        <asp:Literal runat="server" ID="ltrZxlbOption"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    去程出发地：
                </th>
                <td bgcolor="#E3F1FC" class="pandl3" id="td_quchengchufadi">
                    <asp:Literal runat="server" ID="ltrQuChengChuFaDi"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    去程目的地：
                </th>
                <td bgcolor="#E3F1FC" class="pandl3" id="td_quchengmudidi">
                    <asp:Literal runat="server" ID="ltrQuChengMuDiDi"></asp:Literal>
                </td>
            </tr>
                     
            <tr class="odd">
                <td height="30" bgcolor="#E3F1FC" align="left" colspan="2">
                    <table width="248" cellspacing="0" cellpadding="0" border="0" align="center">
                        <tbody>
                            <tr>
                                <td width="96" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0);" id="btn" hidefocus="true" runat="server">保存</a>
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

    <script type="text/javascript">
        var iPage = {
            close: function() {
                var _win = top || window;
                _win.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();
                return false;
            },
            baoCun: function(obj) {
                var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
                if (!validatorResult) return false;

                var validatorResult1 = iPage.shengFenChengShiHandler();
                if (!validatorResult1.lx0) { alert("请选择去程出发地"); return false; }
                if (!validatorResult1.lx1) { alert("请选择去程目的地"); return false; }

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
            },
            shengFenChengShiHandler: function() {
                var items = [];
                var retv = { lx0: false, lx1: false };
                $("#td_quchengchufadi").find("li.p1item input[type='checkbox']").each(function() {
                    if (!this.checked) return;
                    var item = { ShengFenId: 0, ChengShiId: 0, LeiXing: 0 };
                    item.ChengShiId = $(this).val();
                    item.ShengFenId = $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").val();
                    items.push(item);
                    retv.lx0 = true;
                });
                $("#td_quchengmudidi").find("li.p1item input[type='checkbox']").each(function() {
                    if (!this.checked) return;
                    var item = { ShengFenId: 0, ChengShiId: 0, LeiXing: 1 };
                    item.ChengShiId = $(this).val();
                    item.ShengFenId = $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").val();
                    items.push(item);
                    retv.lx1 = true;
                });
                $("#txtShengFenChengShi").val(JSON.stringify(items));
                return retv;
            },
            initShengFenChengShi: function() {
                if (typeof (shengFenChengShis) == "undefined") return;
                if (shengFenChengShis == null || shengFenChengShis.length == 0) return;
                for (var i = 0; i < shengFenChengShis.length; i++) {
                    $("#chk_s_" + shengFenChengShis[i].ShengFenId + "_" + shengFenChengShis[i].LeiXing).attr("checked", true);
                    $("#chk_c_" + shengFenChengShis[i].ChengShiId + "_" + shengFenChengShis[i].LeiXing).attr("checked", true);
                }
            }
        }

        $(function() {
            if (typeof JSON == 'undefined') $.getScript("/js/json2.js", function() { });

            $("#btn").click(function() { iPage.baoCun(this); });
            $("#txtZxlb").val($("#txtZxlb").attr("data-v"));
            $("#td_quchengchufadi input[type='checkbox']").each(function() {
                var _id = $(this).attr("id") + "_0";
                $(this).attr("id", _id);
                $(this).attr("name", _id);
                $(this).next().attr("for", _id);
            });
            $("#td_quchengmudidi input[type='checkbox']").each(function() {
                var _id = $(this).attr("id") + "_1";
                $(this).attr("id", _id);
                $(this).attr("name", _id);
                $(this).next().attr("for", _id);
            });

            $(".p1title input[type='checkbox']").bind("click", function() {
                $(this).closest("ul").find("input[type='checkbox']").attr("checked", this.checked);
            });

            $(".p1item input[type='checkbox']").bind("click", function() {
                if (!this.checked) {
                    if ($(this).closest("ul").find("li.p1item").find("input[type='checkbox']:checked").length == 0) {
                        $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").removeAttr("checked")
                    }
                    return;
                }
                $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").attr("checked", true);
            });

            iPage.initShengFenChengShi();
        })
    </script>
    
</body>
</html>
