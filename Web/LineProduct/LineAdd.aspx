<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front.Master" AutoEventWireup="true"
    CodeBehind="LineAdd.aspx.cs" Inherits="Web.LineProduct.LineAdd" ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPage/Front.Master" %>
<%@ Register Src="~/UserControl/UploadControl.ascx" TagName="UploadControl" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="form1">
    <div class="mainbody">
        <div class="lineprotitlebox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td width="15%" nowrap="nowrap">
                            <span class="lineprotitle">线路产品</span>
                        </td>
                        <td width="85%" nowrap="nowrap" align="right" style="padding: 0 10px 2px 0; color: #13509f;">
                            所在位置&gt;&gt; 线路产品&gt;&gt;
                            <asp:Literal runat="server" ID="ltrWZ"></asp:Literal>
                            线路
                        </td>
                    </tr>
                    <tr>
                        <td height="2" bgcolor="#000000" colspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="hr_10">
        </div>
        <div class="addlinebox">
            <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4"
                align="center">
                <tbody>
                    <tr>
                        <th width="13%" height="30" bgcolor="#e3f1fc" align="right">
                            <font class="xinghao">*</font>线路名称：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <input runat="server" type="text" name="txtRouteName" id="txtRouteName" class="inputtext" style="width:400px"
                                valid="required" errmsg="请填写线路名称!" maxlength="50">
                        </td>
                    </tr>
                    <tr>
                        <th height="30" align="right" bgcolor="#e3f1fc">
                           <font class="xinghao">*</font>线路类型：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <select class="inputselect" id="txtLeiXing" name="txtLeiXing" valid="required" errmsg="请选择线路类型!"><option value="">请选择</option><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuLeiXing)),"")%></select>
                        </td>
                    </tr>
                    <tr>
                        <th height="30" align="right" bgcolor="#e3f1fc">
                            <font class="xinghao">*</font>政策状态：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <select name="txtStatus" class="inputselect" id="txtStatus">
                                <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.CompanyStructure.ZhengCeStatus)),"")%>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">自动过期时间：</th>
                        <td  bgcolor="#FAFDFF" class="pandl3"><input type="text" id="txtGuoQiShiJian" runat="server" class="inputtext" onfocus="WdatePicker()" /><span style="color:#666">指定日期零点后线路政策状态自动变更为已过期</span></td>
                    </tr>
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            <font class="xinghao">*</font>线路区域：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <%--<asp:DropDownList runat="server" ID="ddlArea" CssClass="inputselect" valid="isNo"
                                errmsg="请选择线路区域!" noValue="0">
                            </asp:DropDownList>--%>
                            <select name="txtQuYu" class="inputselect" id="txtQuYu" valid="required" errmsg="请选择线路区域!">
                                <asp:Literal runat="server" ID="ltrQuYuOption"><option value="">请选择</option></asp:Literal>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">线路标准：</th>
                        <td  bgcolor="#FAFDFF" class="pandl3"><select class="inputselect" id="txtBiaoZhun" name="txtBiaoZhun"><%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.EnumType.TourStructure.XianLuBiaoZhun)),"")%></select></td>
                    </tr>
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            集合时间：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <select name="txtJiHeShiJian1" id="txtJiHeShiJian1" class="inputselect">
                                <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.集合时间) %>
                            </select><input type="text" class="inputtext" id="txtJiHeShiJian" runat="server" style="width:180px;" />
                        </td>
                    </tr> 
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            集合地点：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <select name="txtJiHeDiDian1" id="txtJiHeDiDian1" class="inputselect">
                            <%=GetJiChuXinXiOptions(EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.集合地点) %>
                        </select><input type="text"  class="inputtext" id="txtJiHeDiDian" runat="server"  style="width:180px;"   />
                        </td>
                    </tr>                    
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            送团信息：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea runat="server" id="txtSongTuanXinXi" class="inputarea formsize600" style="height:40px;"></textarea><a id="i_a_songtuanxinxi_xuanyong" href="javascript:void(0);">
                            <img width="28" height="18" alt="选用" src="/images/sanping_04.gif" style="vertical-align: top;">
                        </td>
                    </tr>                       
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            目的地接团方式：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea runat="server" id="txtMuDiDiJieTuanFangShi" class="inputarea formsize600" style="height:40px;"></textarea><a id="i_a_mudidijietuanfangshi_xuanyong" href="javascript:void(0);">
                            <img width="28" height="18" alt="选用" src="/images/sanping_04.gif" style="vertical-align: top;">
                        </td>
                    </tr>  
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            线路页眉：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <cc1:UploadControl runat="server" ID="UploadXLYM" FileTypes="*.jpg;*.jpeg;*.gif;*.png;*.bmp;" />
                        </td>
                    </tr> 
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            线路封面：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <cc1:UploadControl runat="server" ID="UploadXLFM" FileTypes="*.jpg;*.jpeg;*.gif;*.png;*.bmp;" TiShiXinXi="建议上传图片尺寸：209*113px" />
                        </td>
                    </tr> 
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            <font class="xinghao">*</font>线路描述：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtXLMS" style="width:99%; height:200px;" runat="server" data-iseditor="1" valid="required" errmsg="请填写线路描述"></textarea>
                        </td>
                    </tr>                    
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            <font class="xinghao">*</font>行程天数：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <input runat="server" type="text" id="txtTS" class="searchinput searchinput03 inputtext"
                                name="txtTS" errmsg="请输入天数!|请输入正确的天数!|天数必须大于0!" valid="required|isInt|range"
                                min="1">
                        </td>
                    </tr>
                    <tr>
                        <%--<th bgcolor="#e3f1fc" align="right">
                            行程安排：
                        </th>--%>
                        <td bgcolor="#FAFDFF" style="padding: 4px 0px;"  colspan="2">
                            <table width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4"
                                align="center" id="tbl_Route_AutoAdd">
                                <tbody>
                                    <tr>
                                        <th width="13%" height="30" bgcolor="#e3f1fc">
                                            日期
                                        </th>
                                        <th bgcolor="#e3f1fc" align="left" class="pandl3">
                                            行程内容
                                        </th>
                                        <th width="150" bgcolor="#e3f1fc" align="left" class="pandl3">
                                            操作
                                        </th>
                                    </tr>
                                    <% if (!IsRoutePlan)
                                       { %>
                                    <tr class="tempRow">
                                        <td bgcolor="#ffffff" align="center">
                                            D<b class="index">1</b>
                                        </td>
                                        <td bgcolor="#ffffff" align="left" style="padding: 4px;">
                                            <textarea name="txtXCNR" style="width:99%; height:200px;"></textarea>
                                        </td>
                                        <td align="center" bgcolor="#e3f1fc">
                                            <a href="javascript:void(0)">
                                                <img src="/images/shangyiimg.gif" class="moveupbtn" height="20" width="48"></a><br>
                                            <br>
                                            <a href="javascript:void(0)">
                                                <img src="/images/charuimg.gif" class="insertbtn" height="20" width="48"></a>&nbsp;
                                            <a href="javascript:void(0)">
                                                <img src="/images/delimg.gif" class="delbtn" height="20" width="48"></a><br>
                                            <br>
                                            <a href="javascript:void(0)">
                                                <img src="/images/xiayiimg.gif" class="movedownbtn" height="20" width="48"></a>
                                        </td>
                                    </tr>
                                    <% } %>
                                    <asp:Repeater runat="server" ID="rptRoutePlan">
                                        <ItemTemplate>
                                            <tr class="tempRow">
                                                <td bgcolor="#ffffff" align="center">
                                                    D<b class="index"><%# Eval("Days")%></b>
                                                </td>
                                                <td bgcolor="#ffffff" align="left" style="padding: 4px;">
                                                    <textarea name="txtXCNR" style="width:99%; height: 200px;"><%# Eval("Content") %></textarea>                                                    
                                                </td>
                                                <td align="center" bgcolor="#e3f1fc">
                                                    <a href="javascript:void(0)">
                                                        <img src="/images/shangyiimg.gif" class="moveupbtn" height="20" width="48"></a><br>
                                                    <br>
                                                    <a href="javascript:void(0)">
                                                        <img src="/images/charuimg.gif" class="insertbtn" height="20" width="48"></a>&nbsp;
                                                    <a href="javascript:void(0)">
                                                        <img src="/images/delimg.gif" class="delbtn" height="20" width="48"></a><br>
                                                    <br>
                                                    <a href="javascript:void(0)">
                                                        <img src="/images/xiayiimg.gif" class="movedownbtn" height="20" width="48"></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th height="30" bgcolor="#e3f1fc" align="right">
                            线路图片：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <cc1:UploadControl runat="server" ID="UploadXLTP" FileTypes="*.jpg;*.jpeg;*.gif;*.png;*.bmp;"
                                IsUploadMore="true" TiShiXinXi="建议上传图片尺寸：428*279px" />
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            交通标准：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtJTBZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            住宿标准：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtZSBZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>                        
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            餐饮标准：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtCYBZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            景点标准：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtJDBZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            导游服务：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtDYFW" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            购物标准：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtGWBZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            儿童标准：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtETBZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            保险说明：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtBXSM" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            自费推荐：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtZFTJ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            温馨提示：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtWXTS" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>                   
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            报名须知：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtBMXZ" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="#e3f1fc" align="right">
                            内部信息：
                        </th>
                        <td bgcolor="#FAFDFF" class="pandl3">
                            <textarea id="txtNBXX" style="width:99%; height:200px;" runat="server" data-iseditor="1"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="right" colspan="2">
                            <table cellspacing="0" cellpadding="0" border="0" align="center">
                                <tbody>
                                    <tr>
                                        <td width="85" align="center" class="tjbtn02">
                                            <asp:LinkButton runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
                                        </td>
                                        <%--<td width="85" align="center" class="tjbtn02">
                                            <asp:LinkButton runat="server" ID="btrReturn" Text="返回" OnClick="btrReturn_Click"></asp:LinkButton>
                                        </td>--%>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor1_4_3/ueditor.all.js"></script>
    <script type="text/javascript">

        var RouteEdit = {
            //创建编辑器
            CreateEdit: function(obj) {
                var _self = $(obj);
                var _id = $.trim(_self.attr("id"));
                if (_id == "") _id = "txtRemark" + parseInt(Math.random() * 1000);
                _self.attr("id", _id);
                enowUEditor.destroy(_id);
                var _ue = enowUEditor.init(_id);
                _ue.ready(function() { _ue.focus(); });
            },
            AddRowCallBack: function(tr) {
                var $tr = tr;
                $tr.find("span[class='errmsg']").html("");
                $tr.find("span[data-class='fontblue']").html("");
                $tr.find("div[data-class='span_Route_file']").remove();
                tr.find("textarea[name='txtXCNR']").show();
            },
            MoveRowCallBack: function(tr) {
                return;
                var txt = tr.find("textarea[name='txtXCNR']");
                //RouteEdit.CreateEdit(txt);
            },
            //按钮绑定事件
            BindBtn: function() {
                $("#<%= btnSave.ClientID %>").unbind("click").click(function() {
                    enowUEditor.sync();
                    if (ValiDatorForm.validator($("#<%= btnSave.ClientID %>").closest("form").get(0), "alert")) {
                        $("#<%= btnSave.ClientID %>").unbind("click");
                        $("#<%= btnSave.ClientID %>").html("正在提交");
                        return true;
                    }
                    return false;
                })
            },
            //送团信息选用
            songTuanXinXiXuanYong: function() {
                var _data = { jichuxinxitype: "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.送团信息 %>", callbackfn: "songTuanXinXiXuanYong_callBack", refereriframeid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                parent.Boxy.iframeDialog({ title: "选用送团信息", iframeUrl: "/systemset/JiChuXinXiXuanYong.aspx", width: "670px", height: "380px", data: _data, afterHide: function() { } });
                return false;
            },
            //目的地接团方式选用
            muDiDiJieTuanFangShiXuanYong: function() {
                var _data = { jichuxinxitype: "<%=(int)EyouSoft.Model.EnumType.CompanyStructure.JiChuXinXiType.目的地接团方式 %>", callbackfn: "muDiDiJieTuanFangShiXuanYong_callBack", refereriframeid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
                parent.Boxy.iframeDialog({ title: "选用送团信息", iframeUrl: "/systemset/JiChuXinXiXuanYong.aspx", width: "670px", height: "380px", data: _data, afterHide: function() { } });
                return false;
            }
        };

        function songTuanXinXiXuanYong_callBack(_ret) {
            if (_ret.length == 0) return;

            var s = [];
            for (var i = 0; i < _ret.length; i++) {
                s.push(_ret[i]);
                s.push("\n");
            }

            var _$obj = $("#<%=txtSongTuanXinXi.ClientID %>");
            var _v = $.trim(_$obj.val());

            if (_v.length > 0) _v += "\n";

            _$obj.val(_v + s.join(""));
        }

        function muDiDiJieTuanFangShiXuanYong_callBack(_ret) {
            if (_ret.length == 0) return;

            var s = [];
            for (var i = 0; i < _ret.length; i++) {
                s.push(_ret[i]);
                s.push("\n");
            }

            var _$obj = $("#<%=txtMuDiDiJieTuanFangShi.ClientID %>");
            var _v = $.trim(_$obj.val());

            if (_v.length > 0) _v += "\n";

            _$obj.val(_v + s.join(""));
        }

        $(document).ready(function() {
            //初始化编辑器
            $("textarea[data-iseditor='1']").each(function() {
                //RouteEdit.CreateEdit(this);
                $(this).unbind().click(function() {
                    RouteEdit.CreateEdit(this);
                })
            });

            //初始化编辑器(点击后加载)
            $("#tbl_Route_AutoAdd").find("textarea[name='txtXCNR']").each(function() {
                var _self = $(this);
                _self.unbind().click(function() {
                    RouteEdit.CreateEdit(this);
                })
                /*if ($.trim(_self.val()) != "") {
                $(this).click();
                }*/
            })

            //初始化添加删除形成内容
            $("#tbl_Route_AutoAdd").autoAdd({ changeInput: $("#<%=txtTS.ClientID %>"), addCallBack: RouteEdit.AddRowCallBack, upCallBack: RouteEdit.MoveRowCallBack, downCallBack: RouteEdit.MoveRowCallBack });

            RouteEdit.BindBtn();

            $("#txtQuYu").val("<%=QuYuId %>");
            $("#txtStatus").val("<%=Status %>");
            $("#txtLeiXing").val("<%=LeiXing %>");
            $("#txtBiaoZhun").val("<%=BiaoZhun %>");

            $("#txtJiHeDiDian1").change(function() { $("#<%=txtJiHeDiDian.ClientID %>").val($(this).val()); });
            $("#txtJiHeShiJian1").change(function() { $("#<%=txtJiHeShiJian.ClientID %>").val($(this).val()); });
            $("#i_a_songtuanxinxi_xuanyong").bind("click", function() { RouteEdit.songTuanXinXiXuanYong(); });
            $("#i_a_mudidijietuanfangshi_xuanyong").bind("click", function() { RouteEdit.muDiDiJieTuanFangShiXuanYong(); });
        });
    </script>

    </form>
</asp:Content>
