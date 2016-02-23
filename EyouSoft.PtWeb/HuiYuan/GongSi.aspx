<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongSi.aspx.cs" Inherits="EyouSoft.PtWeb.HuiYuan.GongSi"
    MasterPageFile="~/MP/HuiYuan.Master" Title="公司信息" ValidateRequest="false" %>

<%@ Register Src="~/WUC/ShangChuan.ascx" TagName="ShangChuan" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="PageMain" runat="server" ID="PageMain1">
    <div class="hr_10"></div>
    <div class="lineprotitlebox">
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tbody>
                <tr>
                    <td width="15%" nowrap="nowrap">
                        <span class="lineprotitle">公司信息</span>
                    </td>
                    <td width="85%" nowrap="nowrap" align="right">
                        当前用您所在位置：&gt;&gt; 系统配置 &gt;&gt; 公司信息
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="hr_10"></div>
    <form runat="server" id="form1">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tablelist">
        <tr>
            <td style="width: 100px; text-align: right;">
                公司名称：
            </td>
            <td>
                <input type="text" class="input1 input_readonly" style="width: 250px;" id="txtGongSiName"
                    readonly="readonly" runat="server" maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                许可证号：
            </td>
            <td>
                <input type="text" class="input1 input_readonly" style="width: 250px;" id="txtXuKeZhengHao"
                    readonly="readonly" runat="server" maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                营业执照号：
            </td>
            <td>
                <input type="text" class="input1 input_readonly" style="width: 250px;" id="txtYingYeZhiZhaoHao"
                    readonly="readonly" runat="server" maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>所在省市：
            </td>
            <td>
                <select id="txtShengFen" name="txtShengFen" class="select1">
                    <option value="">--请选择--</option>
                </select>&nbsp;<select id="txtChengShi" name="txtChengShi" class="select1">
                    <option value="">--请选择--</option>
                </select>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>公司地址：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtDiZhi" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                公司法人：
            </td>
            <td>
                <input type="text" class="input1 input_readonly" style="width: 250px;" id="txtFaRenName"
                    readonly="readonly" runat="server" maxlength="10" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>公司电话：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtGongSiDianHua" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>公司传真：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtGongSiFax" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>联系人姓名：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtLxrName" runat="server"
                    maxlength="10" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>联系人电话：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtLxrDianHua" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <span class="fred">*</span>联系人手机：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtLxrShouJi" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                联系人QQ：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtLxrQQ" runat="server"
                    maxlength="20" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                联系人邮箱：
            </td>
            <td>
                <input type="text" class="input1" style="width: 250px;" id="txtLxrYouXiang" runat="server"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                公司LOGO：
            </td>
            <td>
                <uc1:ShangChuan runat="server" ID="txtLogo" ShuoMing="建议尺寸：263*91px。" XianShiClassName="uploadify_gongsi_logo_xianshi"></uc1:ShangChuan>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                单据打印模板：
            </td>
            <td>
                <uc1:ShangChuan runat="server" ID="txtDaYinMoBan" ShuoMing="文件格式.dot或.doc，设置后需要重新登录系统才会生效。<a target='_blank' href='/danju/单据打印模板样本.doc'>下载模板样本</a>"
                    FileTypeExts="*.dot;*.doc" FileTypeDesc="请选择模板" XianShiClassName="uploadify_danjudayinmoban_xianshi"></uc1:ShangChuan>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                公司介绍：
            </td>
            <td>
                <textarea id="txtJieShao" style="width: 90%; height: 150px;" runat="server"></textarea>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 0px auto; margin-top:15px; margin-bottom:15px;">
        <tr>
            <td style="text-align: center;">
                <a href="javascript:void(0)" id="i_a_submit" class="baocun">提 交</a>
            </td>
        </tr>
    </table>
    </form>

    <script src="/uploadify3_2_1/jquery.uploadify.js" type="text/javascript"></script>
    <link href="/uploadify3_2_1/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.all.js"></script>
    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>

    <script type="text/javascript">
        var iPage = {
            reload: function() {
                window.location.href = window.location.href;
            },
            webForm_OnSubmit_Validate: function() {
                var _v = true;

                if ($.trim($("#txtShengFen").val()).length == 0) { alert("请选择公司所在省份"); return false; }
                if ($.trim($("#txtChengShi").val()).length == 0) { alert("请选择公司所在城市"); return false; }
                if ($.trim($("#<%=txtDiZhi.ClientID%>").val()).length == 0) { alert("请输入公司地址"); return false; }
                if ($.trim($("#<%=txtGongSiDianHua.ClientID%>").val()).length == 0) { alert("请输入公司电话"); return false; }
                if (!RegExps.isPhone.test($.trim($("#<%=txtGongSiDianHua.ClientID%>").val()))) { alert("请输入正确的公司电话"); return false; }
                if ($.trim($("#<%=txtGongSiFax.ClientID%>").val()).length == 0) { alert("请输入公司传真"); return false; }
                if (!RegExps.isPhone.test($.trim($("#<%=txtGongSiFax.ClientID%>").val()))) { alert("请输入正确的公司传真"); return false; }
                if ($.trim($("#<%=txtLxrName.ClientID%>").val()).length == 0) { alert("请输入联系人姓名"); return false; }
                if ($.trim($("#<%=txtLxrDianHua.ClientID%>").val()).length == 0) { alert("请输入联系人电话"); return false; }
                if (!RegExps.isPhone.test($.trim($("#<%=txtLxrDianHua.ClientID%>").val()))) { alert("请输入正确的联系人电话"); return false; }
                if ($.trim($("#<%=txtLxrShouJi.ClientID%>").val()).length == 0) { alert("请输入联系人手机"); return false; }
                if (!RegExps.isMobile.test($.trim($("#<%=txtLxrShouJi.ClientID%>").val()))) { alert("请输入正确的联系人手机"); return false; }

                if ($.trim($("#<%=txtLxrYouXiang.ClientID%>").val()).length > 0 && !RegExps.isEmail.test($.trim($("#<%=txtLxrYouXiang.ClientID%>").val()))) { alert("请输入正确的联系人邮箱"); return false; }

                return _v;
            },
            submit: function(obj) {
                if (!this.webForm_OnSubmit_Validate()) return false;
                $(obj).unbind("click").text("正在处理");
                var _data = $("#<%=form1.ClientID %>").serialize();
                var _self = this;
                $.ajax({ type: "post", url: "gongsi.aspx?dotype=submit", dataType: "json", data: _data, cache: false, async: false
                    , success: function(response) {
                        alert(response.msg);
                        $(obj).click(function() { return _self.submit(this); }).text("提交");
                        if (response.result == "1") _self.reload();
                    }
                });
            }
        };
        
        $(document).ready(function() {
            UE.getEditor('<%=txtJieShao.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            $("#i_a_submit").click(function() { return iPage.submit(this); });

            gscx.init({ sid: "#txtShengFen", cid: "#txtChengShi", sv: "<%=ShengFenId %>", cv: "<%=ChengShiId %>", t: "0" });
        });
    </script>

</asp:Content>
