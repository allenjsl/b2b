<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiuDianFangXingEdit.aspx.cs" Inherits="Web.PingTai.JiuDianFangXingEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>房型名称：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtMingCheng" type="text" class="inputtext" id="txtMingCheng" runat="server"
                        valid="required" errmsg="请填写房型名称" maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>房间数量：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtShuLiang" type="text" class="inputtext" id="txtShuLiang" runat="server"
                        valid="required" errmsg="请填写房间数量" maxlength="10" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    房间面积：
                </th>
                <td style="background:#E3F1FC">
                   <input name="txtMianJi" type="text" class="inputtext" id="txtMianJi" runat="server"
                       maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    所在楼层：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtLouCeng" type="text" class="inputtext" id="txtLouCeng" runat="server"
                       maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    挂牌价格：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <input name="txtGuaPaiJiaGe" type="text" class="inputtext" id="txtGuaPaiJiaGe" runat="server"
                       maxlength="10" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>入住日期：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtRuZhuRiQi1" type="text" class="inputtext" id="txtRuZhuRiQi1" runat="server"
                        maxlength="10" style="width: 80px;" valid="required" errmsg="请填写入住日期" onfocus="WdatePicker()" />-<input
                            name="txtRuZhuRiQi2" type="text" class="inputtext" id="txtRuZhuRiQi2" runat="server"
                            maxlength="10" style="width: 80px;" valid="required" errmsg="请填写入住日期" onfocus="WdatePicker()" />
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>优惠价格：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtYouHuiJiaGe" type="text" class="inputtext" id="txtYouHuiJiaGe" runat="server"
                        maxlength="10" style="width: 280px;" valid="required" errmsg="请填写优惠价格" />
                </td>                
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    房型封面：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fengmian" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    房型图片：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：760*320px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    排序值：
                </th>
                <td style="background: #E3F1FC" colspan="3">
                    <input name="txtPaiXuId" type="text" class="inputtext" id="txtPaiXuId" runat="server"
                        value="0" maxlength="5" style="width: 100px;" />
                    <span style="color: #666">(按值升序排列)</span>
                </td>
            </tr>
            <%--<tr class="odd">
                <th height="30" align="right">
                   床位配置：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtChuangWeiPeiZhi" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   客房设施：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtKeFangSheShi" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>   --%>
            <tr class="odd">
                <th height="30" align="right">
                   房型介绍：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtJieShao" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>          
        </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin: 10px auto;">
            <tr class="odd">
                <td height="30" colspan="14" align="left" style="background: #e3f1fc">
                    <table border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" align="center" class="tjbtn02" >
                                <asp:Literal runat="server" ID="ltrOperatorHtml" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.all.js"></script>
    
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

                if ($("#<%=txtJieShao.ClientID %>").val().length > 255) {
                    alert("房型介绍输入内容不能超过255个字符"); return false;
                }

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({ type: "POST", url: window.location.href + "&doType=baocun", data: $("#<%=form1.ClientID %>").serialize(),
                    cache: false, dataType: "json", async: false,
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
            }
        };

        $(document).ready(function() {            
            //UE.getEditor('<%=txtJieShao.ClientID %>', { toolbars: EnowUeditor.toolbars1 });

            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
        });
    </script>
</asp:Content>
