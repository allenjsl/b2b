<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchExamine.aspx.cs" Inherits="Web.ManageCenter.BatchExamine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/jquery-1.4.4.js"></script>
    <script src="/Js/datepicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/Js/ValiDatorForm.js" type="text/javascript"></script>
    <script src="/Js/jquery.boxy.js" type="text/javascript"></script>
    <script src="/Js/table-toolbar.js" type="text/javascript"></script>
    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="600" cellspacing="1" cellpadding="0" border="0" align="center" style="margin: 20px;">
        <tbody>
            <tr>
                <td height="26" bgcolor="#bddcf4" align="left" class="pandl10">
                    考勤时间：
                    <asp:TextBox runat="server" ID="tbStime" valid="required" class="inputtext formsize120"
                        errmsg="考勤开始时间不能为空！" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'tbEtime\')}',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                    至
                    <asp:TextBox runat="server" ID="tbEtime" valid="required" errmsg="考勤结束时间不能为空！" class="inputtext formsize120"
                        onfocus="WdatePicker({minDate:'#F{$dp.$D(\'tbStime\')}',dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td height="26" align="left" bgcolor="#e3f1fc" class="pandl10">
                    考勤人员：
                    <asp:Label runat="server" ID="attendNames"></asp:Label>
                    <asp:HiddenField runat="server" ID="hdattenIds" />
                    <asp:HiddenField runat="server" ID="hdattenNames" />
                </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                    <asp:RadioButton runat="server" ID="rbquanqing" Text="准点" GroupName="attendance" data-value="0" data-class="radioBtn" />
                    <asp:RadioButton runat="server" ID="rbchidao" Text="迟到" GroupName="attendance" data-value="1" data-class="radioBtn" />
                    <asp:RadioButton runat="server" ID="rbzaotui" Text="早退" GroupName="attendance" data-value="2" data-class="radioBtn" />
                    <asp:RadioButton runat="server" ID="rbkuanggong" Text="旷工" GroupName="attendance" data-value="3" data-class="radioBtn" />
                    <asp:RadioButton runat="server" ID="rbxiujia" Text="休假" GroupName="attendance" data-value="4" data-class="radioBtn" />
                    <asp:RadioButton runat="server" ID="rbwaichu" Text="外出" GroupName="attendance" data-value="5" data-class="radioBtn" />
                    <asp:RadioButton runat="server" ID="rbchutuan" Text="出团" GroupName="attendance" data-value="6" data-class="radioBtn" />
                </td>
            </tr>
            <tr class="tr_sub">
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                    <asp:RadioButton runat="server" ID="rbqingjia" Text="请假" GroupName="attendance" data-value="7" data-class="radioBtn" />
                </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10" data-class="td_radioBtn">
                    请假原因：
                    <asp:TextBox runat="server" ID="qjyuanyin" data-class="subject" class="inputtext formsize470" MaxLength="1000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10" data-class="td_radioBtn">
                    请假时间：
                    <asp:TextBox runat="server" ID="tbqjStime" ReadOnly="true" errmsg="请假开始时间不能为空！" class="inputtext formsize100"
                        onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'tbqjEtime\')}',dateFmt:'yyyy-MM-dd HH:mm',opposite:true})"></asp:TextBox>
                                        至
                    <asp:TextBox runat="server" ID="tbqjEtime" ReadOnly="true" errmsg="请假结束时间不能为空！" class="inputtext formsize100"
                        onfocus="WdatePicker({minDate:'#F{$dp.$D(\'tbqjStime\')}',dateFmt:'yyyy-MM-dd HH:mm',opposite:true})"></asp:TextBox>
                                    </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10" data-class="td_radioBtn">
                    请假天数：
                    <asp:TextBox runat="server" ID="qjTianshu" class="inputtext formsize50" Style="width: 34px" valid="isNumber" errmsg="请假天数为数字！"></asp:TextBox>
                                    </td>
            </tr>
            <tr class="tr_sub">
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10">
                    <asp:RadioButton runat="server" ID="rbjiaban" Text="加班" GroupName="attendance" data-value="8" data-class="radioBtn" />
                </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10" data-class="td_radioBtn">
                    加班内容：
                    <asp:TextBox runat="server" ID="jbyuanyin" data-class="subject" class="inputtext formsize470" MaxLength="1000"></asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10" data-class="td_radioBtn">
                    加班时间：
                                        <asp:TextBox runat="server" ID="tbjbStime" ReadOnly="true" errmsg="加班开始时间不能为空！" class="inputtext formsize100"
                        onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'tbqjEtime\')}',dateFmt:'yyyy-MM-dd HH:mm',opposite:true})"></asp:TextBox>
                    
                    至
                                        <asp:TextBox runat="server" ID="tbjbEtime" ReadOnly="true" errmsg="加班结束时间不能为空！" class="inputtext formsize100"
                        onfocus="WdatePicker({minDate:'#F{$dp.$D(\'tbqjStime\')}', dateFmt:'yyyy-MM-dd HH:mm',opposite:true})"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td height="26" bgcolor="#e3f1fc" align="left" class="pandl10" data-class="td_radioBtn">
                    加班时数：
                    <asp:TextBox runat="server" ID="jbShishu" class="inputtext formsize50" Style="width: 34px" valid="isNumber" errmsg="加班时数为数字！"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="40" bgcolor="#bddcf4" align="center">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td width="86" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0);" hidefocus="true" id="btnSave" style='visibility:<%=this.IsSaveGrant?"visible":"hidden" %>'>确认</a>
                                </td>
                                <td width="86" height="40" align="center" class="tjbtn02">
                                    <a href="javascript:void(0);" onclick="PageJsData.ResetForm()" hidefocus="true">取消</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:HiddenField runat="server" ID="attType" />
    <asp:HiddenField runat="server" ID="sTime" />
    <asp:HiddenField runat="server" ID="eTime" />
    <asp:HiddenField runat="server" ID="timeCount" />
    <asp:HiddenField runat="server" ID="subject" />
    </form>
    <script type="text/javascript">
        var PageJsData = {
            //重置
            ResetForm: function() {
                parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
            },
            //处理数字保留小数
            FormatNum: function(num, n) {
                //参数说明：num 要格式化的数字 n 保留小数位
                num = String(num.toFixed(n));
                // var re = /(-?\d+)(\d{3})/;//每三位用逗号分隔
                //while (re.test(num)) num = num.replace(re, "$1,$2")
                return num;
            },
            //得到天数或者小时数
            GetDays: function(startID, endID, showID, num, n) {
                var start = $("#" + startID).val();
                var end = $("#" + endID).val();
                if (start != "" && end != "") {
                    //v为毫秒数
                    var v = new Date(end.replace(/\-/g, '/')).getTime() - new Date(start.replace(/\-/g, '/')).getTime();
                    $("#" + showID).val(this.FormatNum(v / num, n)); //v为毫秒数
                }
            },
            Form: null,
            FormCheck: function() {
                this.Form = $("#btnSave").closest("form").get(0)
                FV_onBlur.initValid(this.Form);
                return ValiDatorForm.validator(this.Form, "parent");
            },
            Save: function() {
                var that = this;
                if (that.FormCheck()) {
                    $("#btnSave").unbind("click").addClass("alertbox-btn_a_active").html("<s class=\"baochun\"></s> 提交中...");
                    var url = "/ManageCenter/BatchExamine.aspx?";
                    url += $.param({
                        save: "save"
                    });
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: url,
                        data: $(that.Form).serialize().replace(),
                        dataType: "json",
                        success: function(result) {
                            if (result.result == "1") {
                                parent.tableToolbar._showMsg(result.msg, function() {
                                    parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide();
                                    parent.window.document.getElementById("btnSubmit").click();
                                });

                            }
                            else {
                                parent.tableToolbar._showMsg(result.msg, function() {
                                    PageJsData.BindBtn();
                                });
                            }
                            return false;
                        },
                        error: function() {
                            parent.tableToolbar._showMsg(tableToolbar.errorMsg, function() {
                                PageJsData.BindBtn();
                            });
                        }
                    });
                }
            },
            BindBtn: function() {
                $("#btnSave").click(function() {
                    $("#<%=attType.ClientID %>").val($("span[data-class='radioBtn']").find(":radio:checked").parent("span").attr("data-value"));
                    var arry = $("input[type='text']:not([disabled])");
                    //考勤开始时间
                    $("#<%=sTime.ClientID %>").val($(arry[0]).val());
                    //考勤结束时间
                    $("#<%=eTime.ClientID %>").val($(arry[1]).val());
                    //缘由
                    $("#<%=subject.ClientID %>").val($(arry[2]).val());
                    if (arry.length > 3) {
                        //天数或者时数
                        $("#<%=timeCount.ClientID %>").val($(arry[3]).val());
                    }
                    PageJsData.Save();
                    return false;
                })
                $("#btnSave").attr("class", "").html("<s class=\"baochun\"></s>保 存");
            }
        }
        $(function() {
        	//灰掉radio后边的文本框
        	$("td[data-class='td_radioBtn'] :text").attr("disabled", "disabled");
        	//控制显示
        	$("span[data-class='radioBtn']").click(function() {
        		$("td[data-class='td_radioBtn'] :text").attr("disabled", "disabled");
        		$(this).closest("tr").nextUntil(".tr_sub").find(":text").removeAttr("disabled");
        	});
        	PageJsData.BindBtn();
        	//页面赋值
        	var attType = $("#<%=attType.ClientID %>").val();
        	var sub = $("#<%=subject.ClientID %>").val();
        	var stime = $("#<%=sTime.ClientID %>").val();
        	var etime = $("#<%=eTime.ClientID %>").val();
        	var timeCount = $("#<%=timeCount.ClientID %>").val();
        	//全勤
        	if (attType == 0) {
        		$("#<%=rbquanqing.ClientID %>").attr("checked", "checked");
        	}
        	//迟到
        	if (attType == 1) {
        		$("#<%=rbchidao.ClientID %>").attr("checked", "checked");
        	}
        	//早退
        	if (attType == 2) {
        		$("#<%=rbzaotui.ClientID %>").attr("checked", "checked");
        	}
        	//旷工
        	if (attType == 3) {
        		$("#<%=rbkuanggong.ClientID %>").attr("checked", "checked");
        	}
        	//休假
        	if (attType == 4) {
        		$("#<%=rbxiujia.ClientID %>").attr("checked", "checked");
        	}
        	//外出
        	if (attType == 5) {
        		$("#<%=rbwaichu.ClientID %>").attr("checked", "checked");
        	}
        	//出团
        	if (attType == 6) {
        		$("#<%=rbchutuan.ClientID %>").attr("checked", "checked");
        	}
        	//请假
        	if (attType == 7) {
        		$("#<%=rbqingjia.ClientID %>").attr("checked", "checked");
        		$("#<%=tbqjStime.ClientID %>").val(stime);
        		$("#<%=tbqjEtime.ClientID %>").val(etime);
        		$("#<%=qjTianshu.ClientID %>").val(timeCount);
        		$("#<%=qjyuanyin.ClientID %>").val(sub);
        	}
        	//加班
        	if (attType == 8) {
        		$("#<%=rbjiaban.ClientID %>").attr("checked", "checked");
        		$("#<%=tbjbStime.ClientID %>").val(stime);
        		$("#<%=tbjbEtime.ClientID %>").val(etime);
        		$("#<%=jbShishu.ClientID %>").val(timeCount);
        		$("#<%=jbyuanyin.ClientID %>").val(sub);
        	}
        	//加载时选中的内容为显示
        	//alert($("span[data-class='radioBtn']").find(":radio").attr("checked"));
        	$("span[data-class='radioBtn']").find(":radio:checked").click();
        });
    </script>
</body>
</html>
