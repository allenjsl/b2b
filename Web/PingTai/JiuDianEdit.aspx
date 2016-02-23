<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiuDianEdit.aspx.cs" Inherits="Web.PingTai.JiuDianEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false"%>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <form runat="server" id="form1">
     <div style="width: 99%; margin: 0px auto; margin-top:5px;">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" id="i_table_form">
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>酒店名称：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtMingCheng" type="text" class="inputtext" id="txtMingCheng" runat="server"
                        valid="required" errmsg="请填写酒店名称" maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>酒店星级：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtXingJi" class="inputselect" name="txtXingJi" valid="required" errmsg="请选择酒店星级">
                        <option value="">--请选择--</option>
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.JiuDianXingJi)), "") %>
                    </select>
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    <span class="fred">*</span>所在省份：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtShengFen" class="inputselect" name="txtShengFen" valid="required" errmsg="请选择所在省份"></select>
                </td>
                <th width="80" align="right">
                    <span class="fred">*</span>所在城市：
                </th>
                <td style="background:#E3F1FC">
                    <select id="txtChengShi" class="inputselect" name="txtChengShi" valid="required" errmsg="请选择所在城市"></select>
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    详细地址：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <input name="txtDiZhi" type="text" class="inputtext" id="txtDiZhi" runat="server"
                        maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    开业时间：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtKaiYeShiJian" type="text" class="inputtext" id="txtKaiYeShiJian" runat="server"
                        maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    楼层数量：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtLouCengShuLiang" type="text" class="inputtext" id="txtLouCengShuLiang" runat="server"
                        maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <tr class="odd">
                <th width="80" height="30" align="right">
                    装修时间：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtZhuangXiuShiJian" type="text" class="inputtext" id="txtZhuangXiuShiJian" runat="server"
                        maxlength="100" style="width:280px;" />
                </td>
                <th width="80" align="right">
                    酒店电话：
                </th>
                <td style="background:#E3F1FC">
                    <input name="txtDianHua" type="text" class="inputtext" id="txtDianHua" runat="server"
                        maxlength="100" style="width:280px;" />
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phJiuDianYongHu" Visible="false">
            <tr class="odd">
                <th height="30" align="right">
                    酒店账号：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <select name="txtJiuDianYongHu" id="txtJiuDianYongHu">
                        <option value="0">-请选择-</option>
                        <asp:Literal runat="server" ID="ltrJiuDianYongHu"></asp:Literal>
                    </select>
                    <span style="color:#666">选中的账号可登录系统维护该酒店信息</span>
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr class="odd">
                <th height="30" align="right">
                    酒店封面：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fengmian" runat="server" TiShiXinXi="建议上传图片尺寸：182*124px" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    酒店图片：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                    <uc1:UploadControl ID="up_fujian" runat="server" TiShiXinXi="建议上传图片尺寸：778*353px" />
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
            <tr class="odd">
                <th height="30" align="right">
                   简要介绍：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtJianYaoJieShao" style="width: 99.9%; height: 100px;" runat="server"></textarea>
                </th>
            </tr>      
            <tr class="odd">
                <th height="30" align="right">
                   交通信息：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtJiaoTong" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   网络设施：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtWangLuo" style="width:99.9%; height:150px;" runat="server"></textarea>
                </th>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                   酒店介绍：
                </th>
                <td style="background:#E3F1FC" colspan="3">
                </td>
            </tr>
            <tr class="odd">
                <th height="30" colspan="4" style="text-align:left;">
                    <textarea id="txtJieShao" style="width:99.9%; height:300px;" runat="server"></textarea>
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

                if ($("#<%=txtJianYaoJieShao.ClientID %>").val().length > 255) {
                    alert("简要介绍输入内容不能超过255个字符"); return false;
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
            UE.getEditor('<%=txtJieShao.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            UE.getEditor('<%=txtJiaoTong.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            UE.getEditor('<%=txtWangLuo.ClientID %>', { toolbars: EnowUeditor.toolbars1 });

            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });
            pcToobar.init({ pID: "#txtShengFen", cID: "#txtChengShi", comID: '<%=this.SiteUserInfo.CompanyId %>', pSelect: '<%=ShengFenId %>', cSelect: '<%=ChengShiId %>' });
            $("#txtXingJi").val("<%=XingJi %>");
            $("#txtJiuDianYongHu").val("<%=JiuDianYongHuId %>");
        });
    </script>
</asp:Content>
