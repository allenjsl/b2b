<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSupper.aspx.cs" Inherits="Web.CommonPage.UserSupper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>供应商选用</title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="../JS/bt.min.js" type="text/javascript"></script>

    <script src="../JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="../JS/table-toolbar.js" type="text/javascript"></script>

    <!--[if IE]><script src="/js/excanvas.js" type="text/javascript" charset="utf-8"></script><![endif]-->
</head>
<body>
    <form id="form1" method="get">
    <div>
        <table width="99%" align="center" cellpadding="0" cellspacing="0" bgcolor="#e9f4f9"
            style="margin: 0 auto">
            <tr>
                <td width="90%" align="left">
                    供应商：
                    <input name="txtName" type="text" class="inputtext formsize100" id="txtName" value='<%=Request.QueryString["txtName"]%>' />
                    省份：
                    <select name="ddlProvice" id="ddlProvice" class="inputselect">
                    </select>
                    城市：
                    <select name="ddlCity" id="ddlCity" class="inputselect">
                    </select>
                    <select name="slttype" id="slttype" class="inputselect" style="display: none">
                        <%=strsuppertype %>
                    </select>
                    <input type="hidden" name="suppliertype" id="suppliertype" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("suppliertype") %>" />
                    <input type="hidden" name="callback" id="callback" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("callBack") %>" />
                    <input type="hidden" name="iframeid" id="iframeid" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeid") %>" />
                    <input type="hidden" name="pIframeID" id="pIframeID" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("pIframeID") %>" />
                    <input type="hidden" name="hideID" id="hideID" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("hideID") %>" />
                    <input type="hidden" name="aid" id="aid" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("aid") %>" />
                    <input type="hidden" name="isall" id="isall" value="<%=EyouSoft.Common.Utils.GetQueryStringValue("isall") %>" />
                    <input type="submit" value="" class="search_btn" id="search" style="cursor: pointer;
                        height: 21px; width: 62px; background: url(/images/searchbtn.gif) no-repeat center center;
                        border: 0 none; margin-left: 5px;" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <div style="margin: 0 auto 0 auto; width: 99%;">
        <div id="AjaxDataList" style="width: 100%; padding-top: 10px">
        </div>
        <table cellspacing="0" cellpadding="0" border="0" align="center">
            <tbody>
                <tr>
                    <td width="76" height="40" align="center" class="tjbtn02">
                        <a href="javascript:;" id="a_btn" runat="server">选用</a>
                    </td>
                    <td width="76" height="40" align="center" class="tjbtn02">
                        <a href="javascript:;" onclick="window.parent.Boxy.getIframeDialog('<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>').hide();">
                            关闭</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</body>
</html>

<script type="text/javascript">
    var UseSupplier = {
        AjaxURLg: null,
        isall: '<%=Request.QueryString["isall"] %>',
        type: '<%=(int)type %>',
        tourid: '<%=Request.QueryString["tourid"] %>',
        aid: '<%=Request.QueryString["aid"] %>',
        PageInit: function() {
            pcToobar.init({
                pID: "#ddlProvice",
                cID: "#ddlCity",
                comID: '<%=this.SiteUserInfo.CompanyId %>',
                pSelect: '<%=Request.QueryString["ddlProvice"]??"0" %>',
                cSelect: '<%=Request.QueryString["ddlCity"]??"0" %>',
                isCy: "1"
            })
            //var isall = '<%=Request.QueryString["pIframeID"] %>';
            var param = $.param({ name: $("#txtName").val() });
            switch (UseSupplier.type) {
                case "1":
                    this.GetUrl("ground");
                    break;
                case "4":
                    this.GetUrl("scenicspots");
                    break;
                case "3":
                    this.GetUrl("wineshop");
                    break;
                case "2":
                    this.GetUrl("ticket");
                    break;
                case "5":
                    this.GetUrl("other");
                    break;
            }
        },
        GetUrl: function(type) {
            this.AjaxURLg = "/ResourceManage/AjaxRequest/AjaxSupplierRequest.aspx?type=" + type;
        },
        GetAjaxData: function(pageIndex, url) {
            //AJAX 加载数据
            $("#AjaxDataList").html("<div style='width:100%; text-align:center;'><img src='/images/loadingnew.gif' border='0' align='absmiddle'/>&nbsp;正在加载,请等待....&nbsp;</div>");

            var para = { name: $("#txtName").val(), callback: $("#callback").val(), iframeId: $("#iframeid").val(), piframeId: $("#pIframeID").val(), aid: UseSupplier.aid, ShowID: $("#hideID").val(), tourid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("tourid") %>', provice: '<%=Request.QueryString["ddlProvice"]??"0" %>', city: '<%=Request.QueryString["ddlCity"]??"0" %>', isall: '<%=Request.QueryString["isall"] %>' };
            var url = UseSupplier.AjaxURLg + "&" + $.param(para);
            var suppliertype = "";
            if (UseSupplier.isall == "1") {
                suppliertype = '<%=Request.QueryString["slttype"] %>';
            }
            else {
                suppliertype = Boxy.queryString("suppliertype");
            }
            $.newAjax({
                type: "Get",
                url: url + "&Page=" + pageIndex + "&suppliertype=" + suppliertype,
                cache: false,
                success: function(result) {
                    $("#AjaxDataList").html(result);
                    //初始化选中
                    var boxyParentWin = window.parent.Boxy.getIframeWindowByID('<%=Request.QueryString["pIframeID"] %>') || parent;

                    boxyParentWin.$('.Offers').each(function() {
                        var sourceId = $(this).parent().find("input[type='hidden']:eq(0)").val();
                        if (sourceId != null && sourceId != "") {
                            $("#AjaxDataList").find("input[type='radio'][value='" + sourceId + "']").attr("checked", "checked");
                            return false;
                        }

                    })
                    var data = {
                        id: '<%=EyouSoft.Common.Utils.GetQueryStringValue("hideID") %>'
                    }
                    //报账页面 团队支出 选用 2次选中功能
                    //选中单选钮
                    $(":radio[value='" + data.id + "']").attr("checked", "checked");
                    $("#div_AjaxPage a").click(function() {
                        var str = $(this).attr("href").match(/&[^&]+$/);
                        pageIndex = str.toString().replace("&Page=", "");
                        UseSupplier.GetAjaxData(pageIndex, url);
                        return false;
                    });
                    $("#div_AjaxPage select").removeAttr("onchange").change(function() {
                        pageIndex = $(this).val();
                        UseSupplier.GetAjaxData(pageIndex, url);
                        return false;
                    });
                }
            });
        }
    }
    //请求供应商选用
    function Requestgys(tableid) {
        UseSupplier.GetAjaxData(tableid == 1 ? 1 : Boxy.queryString("Page"), UseSupplier.AjaxURLg);
    }
    $("#search").click(function() {
        UseSupplier.type = $("#slttype").val();
    })
    $(function() {
        UseSupplier.PageInit();
        Requestgys();
        $("#a_btn").click(function() {
            if($("#tblList").find("input[type='radio']:checked").length>0){
                useSupplierPage.SetValue();
                useSupplierPage.SelectValue();
            }
            return false;
        })

        $("#tblList").find("input[type='radio']").click(function() {
            if ($("#sModel").val() != "2") {
                $("#tblList").find("input[type='radio']").attr("checked", "");
                $(this).attr("checked", "checked");
            }
        });
        if (UseSupplier.isall == "1") {
            $("#slttype").show();
        }
    })
    var useSupplierPage = {
        _dataObj: {},
        selectValue: "",
        selectTxt: "",
        selecttype: "",
        contactname: "",
        contacttel: "",
        contactfax: "",
        controlNum: "",
        useNum: "",
        ContactList: "",
        SetValue: function() {
            var valueArray = [], txtArray = [], contactname = [], fax = [], tel = [], ContactList = [];
            $("#tblList").find("input[type='radio']:checked").each(function() {
                valueArray.push($(this).val());
                txtArray.push($(this).attr("data-show"));
                contactname.push($(this).attr("data-contactname"));
                tel.push($(this).attr("data-tel"));
                fax.push($(this).attr("data-fax"));
                ContactList.push($(this).attr("data-list"));
            })

            this.selectValue = valueArray.join(',');
            this.selectTxt = txtArray.join(',');
            this.contactname = contactname.join(',');
            this.contacttel = tel.join(',');
            this.contactfax = fax.join(',');
            this.ContactList = ContactList.join(',');
        },
        RadioClickFun: function(args) {
            var rdo = $(args);
            var data = rdo.val().split(',');
            this.selectValue = data[0];
            this.selectTxt = data[1];
            this.contactname = data[2];
            this.contacttel = data[3];
            this.contactfax = data[4];
            this.ContactList = data[5];
            this.SelectValue();
        },
        SelectValue: function() {
            var data = {
                callBack: Boxy.queryString("callBack"),
                hideID: Boxy.queryString("hideID"),
                iframeID: Boxy.queryString("iframeId"),
                pIframeID: '<%=Request.QueryString["pIframeID"] %>'
            }

            var args = {
                aid: '<%=Request.QueryString["aid"] %>',
                id: useSupplierPage.selectValue,
                name: useSupplierPage.selectTxt,
                type: UseSupplier.isall == "1" ? '<%=Request.QueryString["slttype"] %>' : '<%=Request.QueryString["suppliertype"] %>',
                contactname: useSupplierPage.contactname,
                contacttel: useSupplierPage.contacttel,
                contactfax: useSupplierPage.contactfax,
                ContactList: useSupplierPage.ContactList
            }
            //根据父级是否为弹窗传值
            if (data.pIframeID != "" && data.pIframeID.length > 0) {
                //定义父级弹窗
                var boxyParent = window.parent.Boxy.getIframeWindow(data.pIframeID) || window.parent.Boxy.getIframeWindowByID(data.pIframeID);
                //判断是否存在回调方法
                if (data.callBack != null && data.callBack.length > 0) {
                    if (data.callBack.indexOf('.') == -1) {
                        boxyParent[data.callBack](args);
                    }
                    else {
                        boxyParent[data.callBack.split('.')[0]][data.callBack.split('.')[1]](args);
                    }
                }
                //定义回调
            }
            else {
                //判断是否存在回调方法
                if (data.callBack != null && data.callBack.length > 0) {
                    if (data.callBack.indexOf('.') == -1) {
                        window.parent[data.callBack](args);
                    }
                    else {
                        window.parent[data.callBack.split('.')[0]][data.callBack.split('.')[1]](args);
                    }
                }
                //定义回调
            }
            parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
        }
    }
    

</script>

