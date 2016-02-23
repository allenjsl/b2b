<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuanXianShangPrivsMoBanPrivsEdit.aspx.cs"
    Inherits="Web.PingTai.ZhuanXianShangPrivsMoBanPrivsEdit" MasterPageFile="~/MasterPage/Boxy.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <style type="text/css">
    .privs1{font-weight:bold;line-height:30px;font-size:14px; clear:both; margin-top:10px; background:#eee}
    .privs2{float:left;width:24%;list-style: none;margin: 0px;padding: 0px;}
    .privs2 li{line-height:22px;list-style: none;}
    .privs2 li.privs2title{font-weight:bold;line-height:24px;}
    .privs2space{clear:both;width:100%; height:10px;list-style: none;}
    .privs2space li{list-style: none;}
    .privs3{}
    .pcode{color:#ff0000; font-weight:normal;}
</style>
    <div style="width: 99%; margin: 0px auto; margin-top: 5px;">
        <form id="form1" runat="server">
        <asp:Literal runat="server" ID="ltrPrivs"></asp:Literal>
        </form>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
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
        save: function(obj) {
            var validatorResult = ValiDatorForm.validator($("#<%=form1.ClientID %>").get(0), "parent");
            if (!validatorResult) return false;

            $(obj).unbind("click").css({ "color": "#999999" });

            $.newAjax({
                type: "POST",
                url: window.location.href + "&doType=save",
                data: $("#<%=form1.ClientID %>").serialize(),
                cache: false,
                dataType: "json",
                async: false,
                success: function(response) {
                    if (response.result == "1") {
                        alert(response.msg);
                        iPage.close();
                    } else {
                        alert(response.msg);
                        $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                    }
                },
                error: function() {
                    $(obj).bind("click", function() { iPage.save(obj); }).css({ "color": "" });
                }
            });
        },
        initPrivs: function() {
        if (typeof moBanPrivs == "undefined") return;
        if (moBanPrivs.privs3 == "ALL") {
                $("input[type='checkbox']").attr("checked", true);
                return;
            }
            var _privs1 = [];
            var _privs2 = [];
            var _privs3 = [];
            if (moBanPrivs.privs1 != "") _privs1 = moBanPrivs.privs1.split(",");
            if (moBanPrivs.privs2 != "") _privs2 = moBanPrivs.privs2.split(",");
            if (moBanPrivs.privs3 != "") _privs3 = moBanPrivs.privs3.split(",");

            for (var i = 0; i < _privs1.length; i++) {
                $("#chk_p_1_" + _privs1[i]).attr("checked", true);
            }
            for (var i = 0; i < _privs2.length; i++) {
                $("#chk_p_2_" + _privs2[i]).attr("checked", true);
            }
            for (var i = 0; i < _privs3.length; i++) {
                $("#chk_p_3_" +_privs3[i]).attr("checked", true);
            }
        }
    };

    $(document).ready(function() {

        //一级栏目(1)checkbox添加事件，全选或取消子栏目及所有权限
        $(".privs1 input[type='checkbox']").bind("click", function() {
            $(this).closest(".privs123").find("input[type='checkbox']").attr("checked", this.checked);
        });

        //二级栏目(2)checkbox添加事件，全选或取消全选所有权限，选中后并选中栏目
        $(".privs2title input[type='checkbox']").bind("click", function() {
            $(this).closest("ul").find("input[type='checkbox']").attr("checked", this.checked);
            if (this.checked) {
                $(this).closest(".privs123").find(".privs1").find("input[type='checkbox']").attr("checked", true);
            } else {
                if ($(this).closest(".privs123").find(".privs2title").find("input[type='checkbox']:checked").length == 0) {
                    $(this).closest(".privs123").find(".privs1").find("input[type='checkbox']").attr("checked", false);
                }
            }
        });

        //权限(3)checkbox添加事件，选中后选中子栏目及栏目
        $(".privs3 input[type='checkbox']").bind("click", function() {
            if (this.checked) {
                $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").attr("checked", true);
                $(this).closest(".privs123").find(".privs1 input[type='checkbox']").attr("checked", true);
            } else {
                if ($(this).closest("ul").find(".privs3 input[type='checkbox']:checked").length == 0) {
                    $(this).closest("ul").find("li:eq(0) input[type='checkbox']").attr("checked", false);
                }
                if ($(this).closest(".privs123").find(".privs2title").find("input[type='checkbox']:checked").length == 0) {
                    $(this).closest(".privs123").find(".privs1").find("input[type='checkbox']").attr("checked", false);
                }
            }
        });

        iPage.initPrivs();
        $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
    });
    </script>

</asp:Content>
