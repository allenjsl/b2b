<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhuanXianShangEdit.aspx.cs" Inherits="Web.PingTai.ZhuanXianShangEdit" MasterPageFile="~/MasterPage/Boxy.Master" ValidateRequest="false" %>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="PageBody" ID="PageBody">
    <div style="width: 98%; margin: 10px auto;">
        <form id="form1" runat="server">
        <textarea id="txtZhanDian" name="txtZhanDian" style="display:none;"></textarea>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr class="odd">
                <th width="120" height="30" align="right">
                    <font class="xinghao">*</font>专线商名称：
                </th>
                <td width="310" align="left">
                    <input type="text" class="inputtext"  id="txtMingCheng" runat="server"  valid="required" errmsg="请输入专线商名称"/>
                </td>
                <th width="120" align="right">
                    <font class="xinghao">*</font>注册号：
                </th>
                <td width="320" align="left">
                    <input type="text" class="inputtext"  id="txtZhuCeHao" runat="server" valid="required" errmsg="请输入注册号" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    <font class="xinghao">*</font>站点及专线类别：
                </th>
                <td align="left" colspan="3">
                    <asp:Literal runat="server" ID="ltrZxlb"></asp:Literal>
                </td>
            </tr>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    <font class="xinghao">*</font>管理员账号：
                </th>
                <td width="310" align="left">
                    <input type="text" class="inputtext"  id="txtGuanLiYuanUsername" runat="server"  valid="required" errmsg="请输入管理员账号"/>
                </td>
                <th width="100" align="right">
                    <font class="xinghao" id="fontMiMaXingHao">*</font>管理员密码：
                </th>
                <td width="320" align="left">
                    <input type="password" class="inputtext"  id="txtGuanLiYunPwd" runat="server" valid="required" errmsg="请输入管理员密码" />
                    <span style="color:#666;display:none;" id="spanMiMaTiShi">不填写将保留原密码</span>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    <font class="xinghao">*</font>税务号：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtShuiWuHao" runat="server"  valid="required" errmsg="请输入税务号"/>
                </td>
                <th align="right">
                    <font class="xinghao">*</font>许可证号：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtXuKeZhengHao" runat="server" valid="required" errmsg="请输入许可证号" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    <font class="xinghao">*</font>公司法人：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtFaRenName" runat="server" valid="required" errmsg="请填写公司法人" />
                </td>
                <th align="right">
                    <font class="xinghao">*</font>专线负责人：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtLxrName" runat="server" valid="required" errmsg="请填写联系人" />
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    专线负责人电话：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtLxrDianHua" runat="server" />
                </td>
                <th align="right">
                    专线负责人手机：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtLxrShouJi" runat="server" />
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    专线负责人QQ：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtLxrQQ" runat="server" />
                </td>
                <th align="right">
                    公司传真：
                </th>
                <td align="left">
                    <input type="text" class="inputtext"  id="txtFax" runat="server" />
                </td>
            </tr>            
            <tr class="even">
                <th height="30" align="right">
                    <font class="xinghao">*</font>所在省份：
                </th>
                <td align="left">
                    <select name="txtShengFenId" id="txtShengFenId" class="inputselect" valid="required" errmsg="请选择省份"></select>
                </td>
                <th align="right">
                    <font class="xinghao">*</font>所在城市：
                </th>
                <td align="left">
                    <select name="txtChengShiId" id="txtChengShiId" class="inputselect" valid="required" errmsg="请选择城市" ></select>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    公司地址：
                </th>
                <td align="left" colspan="3">
                    <input type="text" class="inputtext"  id="txtDiZhi" runat="server" style="width:400px" />
                </td>
            </tr>  
            <tr class="even">
                <th height="30" align="right">
                    logo：
                </th>
                <td align="left" colspan="3">
                    <uc1:UploadControl ID="UploadLogo" runat="server" TiShiXinXi="建议上传图片尺寸：184*128px" />
                </td>
            </tr>   
            <tr class="odd">
                <th height="30" align="right">
                    联系QQ：
                </th>
                <td align="left" colspan="3" id="td_qq" style="line-height:26px;">
                    <asp:Repeater runat="server" ID="rptQQ"><ItemTemplate>
                    <div>
                        描述：<input type="text" class="inputtext" name="txtQQMiaoShu" value="<%#Eval("MiaoShu") %>" /> 
                        号码：<input type="text" class="inputtext" name="txtQQHaoMa" value="<%#Eval("QQ") %>" /> 
                        <a href="javascript:void(0)" data-class="qq_insert">添加</a> 
                        <a href="javascript:void(0)" data-class="qq_delete">删除</a>
                    </div>
                    </ItemTemplate></asp:Repeater>
                    
                    <asp:PlaceHolder runat="server" ID="phQQ">
                    <div>
                        描述：<input type="text" class="inputtext" name="txtQQMiaoShu" /> 
                        号码：<input type="text" class="inputtext" name="txtQQHaoMa" /> 
                        <a href="javascript:void(0)" data-class="qq_insert">添加</a> 
                        <a href="javascript:void(0)" data-class="qq_delete">删除</a>
                    </div>
                    </asp:PlaceHolder>
                </td>
            </tr> 
            <tr class="odd">
                <th height="30" align="right">
                    联系方式：
                </th>
                <td align="left" colspan="3">
                    <textarea id="txtLianXiFangShi" style="width:99.9%; height:150px;" runat="server"></textarea>
                </td>
            </tr>   
            <tr class="odd">
                <th height="30" align="right">
                    银行账号：
                </th>
                <td align="left" colspan="3">
                    <textarea id="txtYinHangZhangHao" style="width:99.9%; height:150px;" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    公司介绍：
                </th>
                <td align="left" colspan="3">
                    <textarea id="txtJieShao" style="width:99.9%; height:150px;" runat="server"></textarea>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    排序值：
                </th>
                <td align="left" colspan="3">
                    <input type="text" class="inputtext" id="txtPaiXuId" runat="server" /><span style="color: #666">(按值升序排列)</span>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    可见状态：
                </th>
                <td colspan="3">
                    <select name="txtT2" id="txtT2" data-v="<%=T2 %>" class="inputselect">
                        <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.PtStructure.ZxsT2)),"")%>
                    </select>
                </td>
            </tr>
        </table>
        </form>
        <div style="width: 99%; margin: 0 auto; color: #666; line-height: 24px; margin-top:10px;">
            说明：可见状态[仅专线商系统]时在同行平台不展示该专线商信息。
        </div>
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
    
    <style type="text/css">    
    .zxlbul1{float:left;width:33%;list-style: none;margin: 0px;padding: 0px;}
    .zxlbul1 li{line-height:22px;list-style: none;}
    .zxlbul1 li.zxlbul1title{font-weight:bold;line-height:24px;}    
    .zxlbul1 li.zxlbul1item{}
    .zxlbul2{clear:both;width:100%; height:10px;list-style: none;margin: 0px;padding: 0px;}
    </style>
    
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
                var validatorResult1 = this.zhanDianHandler();
                if (!validatorResult1) { alert("请选择站点及专线类别"); return false; }

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
            insertQQ: function(obj) {
                var _div = $(obj).closest("div").clone(true);
                _div.find("input").val('');

                $("#td_qq").append(_div);
            },
            deleteQQ: function(obj) {
                if ($("#td_qq").find("div").length == 1) { alert("至少要保留一行"); return false; }
                $(obj).closest("div").remove();
            },
            initZhanDian: function() {
                if (typeof (zhanDians) == "undefined") return;
                if (zhanDians == null || zhanDians.length == 0) return;
                for (var i = 0; i < zhanDians.length; i++) {
                    $("#chk_zhandian_" + zhanDians[i].ZhanDianId).attr("checked", true);
                    $("#chk_zxlb_" + zhanDians[i].ZxlbId).attr("checked", true);
                }
            },
            zhanDianHandler: function() {
                var items = [];
                var retv = false;
                $("li.zxlbul1item input[type='checkbox']").each(function() {
                    if (!this.checked) return;
                    var item = { ZhanDianId: 0, ZxlbId: 0 };
                    item.ZxlbId = $(this).val();
                    item.ZhanDianId = $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").val();
                    items.push(item);
                    retv = true;
                });
                $("#txtZhanDian").val(JSON.stringify(items));
                return retv;
            }
        };

        $(document).ready(function() {
            $("#i_a_save").bind("click", function() { iPage.save(this); return false; });

            UE.getEditor('<%=txtLianXiFangShi.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            UE.getEditor('<%=txtYinHangZhangHao.ClientID %>', { toolbars: EnowUeditor.toolbars1 });
            UE.getEditor('<%=txtJieShao.ClientID %>', { toolbars: EnowUeditor.toolbars1 });

            $("a[data-class='qq_insert']").click(function() { iPage.insertQQ(this); });
            $("a[data-class='qq_delete']").click(function() { iPage.deleteQQ(this); });

            pcToobar.init({ pID: "#txtShengFenId", cID: "#txtChengShiId", pSelect: '<%=ShengFenId %>', cSelect: '<%=ChengShiId %>', comID: '<%=CurrentUserCompanyID %>' });

            if ("<%=EditId %>" != "") {
                $("#<%=txtGuanLiYuanUsername.ClientID %>").attr("readonly", "readonly");
                $("#<%=txtGuanLiYunPwd.ClientID %>").removeAttr("valid").removeAttr("errmsg");
                $("#spanMiMaTiShi").show();
                $("#fontMiMaXingHao").hide();
            }

            $(".zxlbul1title input[type='checkbox']").bind("click", function() {
                $(this).closest("ul").find("input[type='checkbox']:enabled").attr("checked", this.checked);
            });

            $(".zxlbul1item input[type='checkbox']").bind("click", function() {
                if (!this.checked) {
                    if ($(this).closest("ul").find("li.zxlbul1item").find("input[type='checkbox']:checked").length == 0) {
                        $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").removeAttr("checked")
                    }
                    return;
                }
                $(this).closest("ul").find("li:eq(0)").find("input[type='checkbox']").attr("checked", true);
            });

            iPage.initZhanDian();

            $("#txtT2").val("<%=T2 %>");
        });
    </script>

</asp:Content>
