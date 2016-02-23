<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAdd.aspx.cs" Inherits="Web.CustomerManage.CustomerAdd" EnableEventValidation="false" %>
<%@ Import Namespace="EyouSoft.Common" %>
<%@ Import Namespace="EyouSoft.Model.EnumType.CompanyStructure" %>

<%@ Register src="../UserControl/UploadControl.ascx" tagname="UploadControl" tagprefix="uc1" %>

<%@ Register Src="~/UserControl/SellsSelect.ascx" TagName="Seller" TagPrefix="Uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/sytle.css" rel="stylesheet" type="text/css" />
    <link href="../Css/swfupload/default.css" rel="stylesheet" type="text/css" />

    <script src="/Js/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="/Js/jquery.boxy.js" type="text/javascript"></script>
    <script src="/Js/datepicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/Js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="/Js/table-toolbar.js" type="text/javascript"></script>
    <script src="/Js/Newjquery.autocomplete.js" type="text/javascript"></script>
    <script src="/Js/swfupload/swfupload.js" type="text/javascript"></script>
    <script src="/Js/ValiDatorForm.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" method="post" runat="server" enctype="multipart/form-data">
    <input type="hidden" name="txtLaiYuan" value="<%=(int)LaiYuan %>" />
    <div style="width:99%; margin:0px auto; margin-top:5px;">
    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center">
        <tbody>
            <tr class="odd">
                <th width="100" height="30" align="right">
                    <span class="fred">*</span>所在省份：
                </th>
                <td width="350" align="left">
                    <select name="txtShengFen" class="inputselect" id="txtShengFen" valid="required" errmsg="请选择省份!">
                        <option value="">请选择</option>
                    </select>
                </td>
                <th width="100" align="right">
                   <span class="fred">*</span>所在城市：
                </th>
                <td align="left">
                    <select name="txtChengShi" class="inputselect" id="txtChengShi" valid="required" errmsg="请选择城市!">
                        <option value="">请选择</option>
                    </select>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    <span class="fred">*</span>公司名称：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" style="width:270px;" id="txtName" name="txtName" runat="server" valid="required" errmsg="请填写公司名称"/>
                </td>
                <th align="right">
                    许可证号：
                </th>
                <td align="left">
                    <input type="text" id="txtLicense" class="inputtext" name="txtLicense" runat="server"/>
                </td>
            </tr>            
            <tr class="odd">
                <th height="30" align="right">
                    公司法人：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtFaRen" name="txtFaRen" runat="server"/>
                </td>
                <th align="right">
                    营业执照号：
                </th>
                <td align="left">
                    <input type="text" id="txtYingYeZhiZhaoHao" class="inputtext" name="txtYingYeZhiZhaoHao" runat="server"/>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    公司电话：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtGongSiDianHua" name="txtGongSiDianHua" runat="server"/>
                </td>
                <th align="right">
                    公司传真：
                </th>
                <td align="left">
                    <input type="text" id="txtGongSiFax" class="inputtext" name="txtGongSiFax" runat="server"/>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    公司地址：
                </th>
                <td align="left">
                    <input type="text" class="inputtext" id="txtAddress" name="txtAddress" runat="server" style="width:270px;"/>
                </td>
                <th align="right">
                    邮编：
                </th>
                <td align="left">
                    <input type="text" id="txtPostalCode" class="inputtext" name="txtPostalCode" runat="server"/>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    责任销售：
                </th>
                <td align="left">
                    <Uc1:Seller ID="Seller1" runat="server" CssClass="formsize180 inputtext"></Uc1:Seller>
                </td>
                <th align="right">客户类型：</th>
                <td align="left"><select name="txtKeHuLeiXing" class="inputselect"><asp:Literal runat="server" ID="ltrKeHuLeiXingOptions"></asp:Literal></select></td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    公司简码：
                </th>
                <td align="left">
                    <input type="text" runat="server" id="txtJianMa" class="inputtext" style="width:100px;" />
                </td>
                <th align="right"></th>
                <td align="left"></td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    主要联系人：
                </th>
                <td align="left" colspan="3">
                    <input type="text" id="txtContactName" class="inputtext" name="txtContactName" runat="server" style="width:60px;"/>
                    <b>电话：</b>
                    <input type="text" id="txtPhone" class="inputtext" name="txtPhone" runat="server" style="width:70px;"/>
                    <b>手机：</b>
                    <input type="text" id="txtMobile" class="inputtext" name="txtMobile" runat="server" style="width:70px;"/>
                    <b>传真：</b>
                    <input type="text" id="txtFax" class="inputtext" name="txtFax" runat="server" style="width:70px;"/>
                    <b>QQ：</b>
                    <input type="text" id="txtQQ" class="inputtext" name="txtQQ" runat="server" style="width:70px;"/>
                    <b>邮箱：</b>
                    <input type="text" id="txtEmail" class="inputtext" name="txtEmail" runat="server" style="width:140px;"/>
                </td>
            </tr>
            <tr class="odd">
                <th height="30" align="right">
                    合作协议：
                </th>
                <td colspan="3">
                    <uc1:UploadControl ID="UploadControl1" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="even">
                <th height="30" align="right">
                    其它附件：
                </th>
                <td colspan="3">
                    <Uc1:uploadcontrol id="UploadControl2" runat="server" isuploadmore="true" isuploadself="true" />
                </td>
            </tr>
            <tr class="odd">
                <th height="60" align="right">
                    备注：
                </th>
                <td colspan="3">
                     <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="70px" CssClass="formsize450 inputtext" runat="server"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
    
        
    </div>
    
    <div style="width:99%; margin:0px auto; margin-top:5px;">
        <span class="formtableT">联系人信息</span>
        <table id="tab_lxr" width="100%" cellspacing="1" cellpadding="0" border="0" bgcolor="#FFFFFF"
            class="autoAdd">
            <tbody>
                <tr class="odd">
                    <th height="30" align="center">
                        姓名
                    </th>
                    <th align="center">
                        性别
                    </th>                    
                    <th align="center">
                        部门/职务
                    </th>
                    <th align="center">
                        手机
                    </th>
                    <th align="center">
                        电话
                    </th>
                    <th align="center">
                        传真
                    </th>
                    <th align="center">
                        QQ/微信号
                    </th>
                    <th align="center">
                        状态
                    </th>
                    <th width="120" align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rptLianXiRen" runat="server">
                    <ItemTemplate>
                        <tr class="even">
                            <td height="30" align="center">
                                <%#Eval("Name") %>
                            </td>
                            <td align="center">
                                <%#Eval("Sex") %>
                            </td>
                            <td align="left">
                                部门:<%# Eval("DepartId") %>
                                <br>
                                职务:<%#Eval("Job") %>
                            </td>
                            <td align="center">
                                <%#Eval("Mobile") %>
                            </td>
                            <td align="center">
                                <%#Eval("Tel") %>
                            </td>
                            <td align="center">
                                <%#Eval("Fax") %>
                            </td>
                            <td align="left">
                                QQ:<%#Eval("qq") %><br />
                                WX:<%#Eval("WeiXinHao") %>
                            </td>
                            <td align="left">
                                <%#Eval("Status") %>
                            </td>
                            <td align="center">
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
                <tr class="even tempRow">
                    <td height="30" align="center">
                        <input type="text" class="inputtext" style="width: 55px" name="txt_lxr_name">
                    </td>
                    <td align="center">
                        <select name="txt_lxr_xingbie" class="inputselect">
                            <option value="0">请选择</option>
                            <option value="1">女</option>
                            <option value="2">男</option>
                        </select>
                    </td>
                    <td align="left">
                        部门:
                        <input type="text" class="inputtext" name="txt_lxr_bumen" style="width: 50px;">
                        <br>
                        职务:
                        <input type="text" class="inputtext" name="txt_lxr_zhiwu" style="width: 50px">
                    </td>
                    <td align="center">
                        <input type="text" class="inputtext" name="txt_lxr_shouji" style="width: 75px">
                    </td>
                    <td align="center">
                        <input type="text" class="inputtext" name="txt_lxr_dianhua" style="width: 75px">
                    </td>
                    <td align="center">
                        <input type="text" class="inputtext" name="txt_lxr_fax" style="width: 75px">
                    </td>
                    <td align="left">
                        QQ:<input type="text" class="inputtext" name="txt_lxr_qq" style="width: 65px"><br />
                        WX:<input type="text" class="inputtext" name="txt_lxr_weixin" style="width: 65px">
                    </td>
                    <td align="left">
                        <select name="txt_lxr_status" class="inputselect">
                            <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.不可修改不可删除 %>">不可修改不可删除</option>
                            <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改不可删除 %>">可修改不可删除</option>
                            <option value="<%=(int)EyouSoft.Model.EnumType.CompanyStructure.KeHuLxrStatus.可修改可删除 %>">可修改可删除</option>
                        </select>
                    </td>
                    <td align="center">
                        <a class="addbtn" href="javascript:void(0)">
                            <img width="48" height="20" src="../images/addimg.gif"></a> <a class="delbtn" href="javascript:void(0)">
                                <img width="48" height="20" src="../images/delimg.gif"></a>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF">
            <tr>
                <td style="color:#666">
                    注：1.联系人状态可以控制客户登录平台后可否对联系人信息进行相应操作；2.不填写姓名的联系人不会保存。
                </td>
            </tr>
        </table>
    </div>
    
    <div style="width:99%; margin:0px auto; margin-top:5px;">
        <span class="formtableT">银行账户信息</span>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" class="autoAdd" bgcolor="#FFFFFF">
            <tbody>
                <tr class="odd">
                    <th align="center" style="height:30px;">
                        账户名称
                    </th>
                    <th align="center">
                        开户银行
                    </th>
                    <th align="center">
                        银行账号
                    </th>
                    <th align="center" style="width:120px">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rptYinHangZhangHu" runat="server">
                    <ItemTemplate>
                        <tr class="tempRow even">
                            <td height="30" align="center">
                                <input type="text" id="txtAccountName" class="formsize80 inputtext" name="txtAccountName"
                                    value='<%#Eval("AccountName") %>'>
                            </td>
                            <td align="center">
                                <input type="text" id="txtBankName" class="formsize80 inputtext" name="txtBankName"
                                    value='<%#Eval("BankName") %>'>
                            </td>
                            <td align="center">
                                <input type="text" id="txtBankAccount" class="inputtext" name="txtBankAccount"
                                    value='<%#Eval("BankNo") %>' style="width:200px;">
                            </td>
                            <td align="center">
                                <a class="addbtn" href="javascript:void(0)">
                                    <img width="48" height="20" src="../images/addimg.gif" alt="" /></a> <a class="delbtn"
                                        href="javascript:void(0)">
                                        <img width="48" height="20" src="../images/delimg.gif" alt /></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    
    <table width="320" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td height="40" align="center" class="tjbtn02">
                    <asp:Literal runat="server" ID="ltrOperatorHtml" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    
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
            }
            //提交表单
            , submit: function(obj) {
                var _self = this;

                var validatorResult = ValiDatorForm.validator($("#btnSave").closest("form").get(0), "alert");
                if (!validatorResult) return;

                $(obj).unbind("click").css({ "color": "#999999" });

                $.newAjax({
                    type: "post", cache: false, url: window.location.href + "&dotype=save", data: $("#<%=form1.ClientID %>").serialize(), dataType: "json",
                    success: function(response) {
                        if (response.result == "1") {
                            alert(response.msg);
                            _self.close();
                        } else {
                            alert(response.msg);
                            $(obj).bind("click", function() { iPage.submit(obj); }).css({ "color": "" });
                        }
                    },
                    error: function() {
                        $(obj).bind("click", function() { iPage.submit(obj); }).css({ "color": "" });
                    }
                });
            }
        };

        $(document).ready(function() {
            pcToobar.init({ pID: "#txtShengFen", cID: "#txtChengShi", pSelect: '<%=ShengFenId %>', cSelect: '<%=ChengShiId %>', comID: '<%=this.SiteUserInfo.CompanyId %>' });

            $("input[readonly='readonly']").css({ "background-color": "#dadada" });

            $("#btnSave").click(function() { iPage.submit(this); });
        });
    </script>
</body>
</html>

