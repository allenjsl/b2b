<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerRequiredControl.ascx.cs"
    Inherits="Web.UserControl.CustomerRequiredControl" %>

<script type="text/javascript" src="/JS/json2.js"></script>

<style type="text/css">
    .progressWrapper
    {
        width: 270px;
    }
</style>

<script type="text/javascript">

    var RouteEdit = {
        CreateFlashUpload: function(flashUpload, idNo) {
            flashUpload = new SWFUpload({
                upload_url: "/CommonPage/upload.aspx",
                file_post_name: "Filedata",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                file_size_limit: "2 MB",
                file_types: "<%=EyouSoft.Common.Utils.UploadFileExtensions %>",
                file_types_description: "附件上传",
                file_upload_limit: 100,
                swfupload_loaded_handler: function() { },
                file_dialog_start_handler: uploadStart,
                upload_start_handler: uploadStart,
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_placeholder_id: "spanButtonPlaceholder_" + idNo,
                button_image_url: "/images/swfupload/XPButtonNoText_92_24.gif",
                button_width: 92,
                button_height: 24,
                button_text: '<span ></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,
                button_cursor: SWFUpload.CURSOR.HAND,
                flash_url: "/js/swfupload/swfupload.swf",
                custom_settings: {
                    upload_target: "divFileProgressContainer_" + idNo,
                    HidFileNameId: "hide_Route_file_" + idNo,
                    HidFileName: "hide_Route_file_Old",
                    ErrMsgId: "errMsg_" + idNo,
                    UploadSucessCallback: function() { RouteEdit.UploadOverCallBack(idNo); }
                },
                debug: false,
                minimum_flash_version: "9.0.28",
                swfupload_pre_load_handler: swfUploadPreLoad,
                swfupload_load_failed_handler: swfUploadLoadFailed
            });
        },
        UploadArgsList: [],
        InitSwfUpload: function(tr, no) {
            var $box = tr || $("#tbl_Route_AutoAdd");
            $box.find("div[data-class='Route_upload_swfbox']").each(function() {
                var idNo = no || parseInt(Math.random() * 100000);

                $(this).find("[data-class='Route_upload']").each(function() {
                    if ($(this).attr("id") == "") {
                        $(this).attr("id", $(this).attr("data-id") + "_" + idNo);
                    }
                })
                var swf = null;
                RouteEdit.CreateFlashUpload(swf, idNo);
                if (swf) {
                    RouteEdit.UploadArgsList.push(swf);
                }
            })
        },
        AddRowCallBack: function(tr) {
            var $tr = tr;
            $tr.find("div[data-class='Route_upload_swfbox']").html($("#divRouteUploadTemp").html());
            $tr.find("span[class='errmsg']").html("");
            $tr.find("span[data-class='fontblue']").html("");
            $tr.find("div[data-class='span_Route_file']").remove();
            $tr.find("td.i_td_querendan").html("-");
            if ($tr.next().attr("i_jiange") != "1")
                $tr.after('<tr i_jiange="1"><td clospan="2" style="height:10px;font-size:10px; line-height:10px;">&nbsp;</td></tr>');
            $tr.find("input[name='txtIsRpt']").val("0");
            RouteEdit.InitSwfUpload($tr);
        },
        MoveRowCallBack: function(tr) {
            var eqFrist = tr.find("div[data-class='Route_upload']").eq(0);
            try {
                //处理IE 9 下移除FLASH 异常
                tr.find("object").remove();
            } catch (e) {
                eqFrist.prev().html('<input type="hidden" data-class="Route_upload" data-id="hide_Route_file" name="hide_Route_file" /><span data-class="Route_upload" data-id="errMsg" class="errmsg"></span>');
            }
            var no = eqFrist.attr("id").split('_')[1];
            eqFrist.prev().append('<span data-class="Route_upload" data-id="spanButtonPlaceholder"></span>');
            RouteEdit.InitSwfUpload(tr, no);
        },
        UploadOverCallBack: function(idNo) {
            var $div = $("#divFileProgressContainer_" + idNo);
            if ($div.length > 0) {
                if ($div.find("div[class='progressWrapper']").length > 1) {
                    $div.find("div[class='progressWrapper']").eq(0).remove();
                }
            }
        },
        //删除附件
        RemoveFile: function(obj) {
            $(obj).closest("td").find("input[name='hide_Route_file_require']").val("");
            $(obj).closest("div[class='upload_filename']").remove();
            return false;
        }
    };

    var gysAnPai = {
        isAnPai: function() {
            var _isAnPai = false;
            $("table[data-id='table_gys_anpai']").find("input[name='ShowID_require']").each(function() {
                if ($(this).val().length > 0) _isAnPai = true;
            });
            return _isAnPai;
        }
    };
</script>

<div style="width: 99%; margin: 0px auto; margin-top:5px;" id="DivCustomerRequire">
    <span class="formtableT"><s></s>客人要求及安排</span><span style="color:#333;">&nbsp;注：未选择供应商的安排信息将不会保存</span>
    <table id="tbl_Route_AutoAdd" width="100%" cellspacing="0" cellpadding="0" border="0"
        align="center" data-id="table_gys_anpai">
        <asp:PlaceHolder runat="server" ID="PhDefaultTr">
            <tr class="remp_row_jd_anpai" style="margin-top: 10px;">
                <th>
                    <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="border-bottom: 1px solid #ccc;">
                        <tbody>
                            <tr class="odd">
                                <th width="100" height="30" align="right">
                                    入住时间：
                                </th>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="text" name="txtInroomTime_require" class="formsize80 inputtext" value=""
                                        onfocus="WdatePicker()" />
                                    <input type="hidden" name="hidId_require" value="" />
                                </td>
                                <td width="100" align="right">
                                    退房时间：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="text" name="txtbackroomTime_require" class="formsize80 inputtext" value=""
                                        onfocus="WdatePicker()" />
                                </td>
                                <td width="100" align="right">
                                    房型：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="text" name="txtroomtype_require" class="formsize80 inputtext" value="" />
                                </td>
                            </tr>
                            <tr class="odd">
                                <td align="right">
                                    组团社要求：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <textarea name="txtreqremark_require" class="inputtext" style="width: 180px; height: 70px;"></textarea>
                                </td>
                                <td align="right">
                                    间夜：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="text" name="txtNight_require" class="formsize80 inputtext"
                                        value="" />
                                </td>
                                <td align="right">
                                    取房方式：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <textarea name="txtqufang_require" class="inputtext" style="width: 180px; height: 70px;"></textarea>
                                </td>
                            </tr>
                            <tr class="odd">
                                <td height="30" align="right">
                                    酒店名称：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="text" name="txtHotelName_require" class="formsize140 inputtext" value="" />
                                    <textarea name="txtAnPaiMx" style="display:none;" cols="10" rows="10"></textarea>
                                    <input type="hidden" name="txtIsRpt" value="0" />
                                    <a href="javascript:void(0)" class="i_a_gengduoanpai">更多</a>
                                </td>
                                <td align="right">
                                    供应商：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="hidden" name="ShowID_require" value="" />
                                    <input name="SourceName_require" style="background-color: #dadada" readonly="readonly"
                                        type="text" class="inputtext formsize80 Offers" value="" />
                                    <a href="javascript:void(0);" class="Offers xuanyong"></a>
                                </td>
                                <th align="right">
                                    对方操作人：
                                </th>
                                <td bgcolor="#E3F1FC" align="left">
                                    <select class="inputselect" name="sltdfoperater">
                                        <%=GetOperator("","")%>
                                    </select>
                                </td>
                            </tr>
                            <tr class="odd">
                                <td align="right">
                                    结算明细：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <textarea name="txtMoneyDesc_require" class="inputtext" style="width: 180px; height: 70px;"></textarea>
                                </td>
                                <td align="right">
                                    结算金额：
                                </td>
                                <td bgcolor="#E3F1FC" align="left">
                                    <input type="text" name="txtMoney_require" class="formsize140 inputtext" value="" />
                                </td>
                                <th align="right">
                                    安排备注：
                                </th>
                                <td bgcolor="#E3F1FC" align="left">
                                    <textarea name="txtremark_require" class="inputtext" style="width: 180px; height: 70px;"></textarea>
                                </td>
                            </tr>
                            <tr class="odd">
                                <td height="30" align="right">
                                    具体安排：
                                </td>
                                <td bgcolor="#E3F1FC" align="left" colspan="5">
                                    <textarea name="txtDesc_require" class="inputtext" style="width: 600px; height: 70px;"></textarea>
                                </td>
                            </tr>
                            <tr class="odd">
                                <td height="30" align="right">
                                    附件上传：
                                </td>
                                <td bgcolor="#E3F1FC" align="left" colspan="5">
                                    <div style="margin: 0px 10px;" data-class="Route_upload_swfbox" data-swfupload="1">
                                        <div>
                                            <input type="hidden" data-class="Route_upload" data-id="hide_Route_file" name="hide_Route_file_require" />
                                            <span data-class="Route_upload" data-id="spanButtonPlaceholder"></span><span data-class="Route_upload"
                                                data-id="errMsg" class="errmsg"></span>
                                        </div>
                                        <div data-class="Route_upload" data-id="divFileProgressContainer">
                                        </div>
                                        <div data-class="Route_upload" data-id="thumbnails">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </th>
                <th width="102" bgcolor="#E3F1FC" style="border-bottom: 1px solid #ccc;">
                    <a href="javascript:void(0)">
                        <img class="addbtn" width="48" height="20" src="../images/addimg.gif" alt="" /></a>
                    <a href="javascript:void(0)">
                        <img class="delbtn" width="48" height="20" src="../images/delimg.gif" alt="" /></a>
                </th>
            </tr>
            <tr i_jiange="1">
                <td clospan="2" style="height: 10px; font-size: 10px; line-height: 10px;">
                    &nbsp;
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:Repeater runat="server" ID="rptList">
            <ItemTemplate>
                <tr class="remp_row_jd_anpai" data-isedit='<%#Convert.ToInt32(Eval("IsShouZhi")) %>'
                    style="margin-top: 20px;">
                    <th>
                        <table width="100%" cellspacing="1" cellpadding="0" border="0" align="center" style="border-bottom: 1px solid #ccc;">
                            <tbody>
                                <tr class="odd">
                                    <th width="100" height="30" align="right">
                                        入住时间：
                                    </th>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="text" name="txtInroomTime_require" class="formsize80 inputtext" value='<%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("CheckInDate"),"yyyy-MM-dd") %>' onfocus="WdatePicker()" data-class="datetime" />
                                        <input type="hidden" name="hidId_require" value='<%#Eval("Id") %>' />
                                    </td>
                                    <td width="100" align="right">
                                        退房时间：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="text" name="txtbackroomTime_require" data-class="datetime" class="formsize80 inputtext"
                                            value='<%#EyouSoft.Common.UtilsCommons.GetDateString(Eval("CheckOutDate"),"yyyy-MM-dd") %>'
                                            data-class="datetime" onfocus="WdatePicker()" />
                                    </td>
                                    <td width="100" align="right">
                                        房型：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="text" name="txtroomtype_require" class="formsize80 inputtext" value='<%#Eval("Room") %>' />
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td align="right">
                                        组团社要求：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <textarea name="txtreqremark_require" class="inputtext" style="width: 180px; height: 70px;"><%#Eval("Remark")%></textarea>
                                    </td>
                                    <td align="right">
                                        间夜：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="text" name="txtNight_require" class="formsize80 inputtext" value='<%#Eval("RoomNights") %>' />
                                    </td>
                                    <td align="right">
                                        取房方式：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <textarea name="txtqufang_require" class="inputtext" style="width: 180px; height: 70px;"><%#Eval("HumorWas")%></textarea>
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td height="30" align="right">
                                        酒店名称：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="text" name="txtHotelName_require" class="formsize140 inputtext" value='<%#Eval("HotelName") %>' />
                                        <textarea name="txtAnPaiMx" style="display: none;" cols="10" rows="10"><%#Newtonsoft.Json.JsonConvert.SerializeObject(Eval("AnPaiMxs"))%></textarea>
                                        <input type="hidden" name="txtIsRpt" value="1" />
                                        <a href="javascript:void(0)" class="i_a_gengduoanpai">更多</a>
                                    </td>
                                    <td align="right">
                                        供应商：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="hidden" name="ShowID_require" value='<%#Eval("GYSId") %>' />
                                        <input name="SourceName_require" style="background-color: #dadada" readonly="readonly"
                                            type="text" class="inputtext formsize80 Offers" value='<%#Eval("GYSName") %>' />
                                        <a href="javascript:void(0);" class="Offers xuanyong"></a>
                                    </td>
                                    <th align="right">
                                        对方操作人：
                                    </th>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <select class="inputselect" name="sltdfoperater">
                                            <%#GetOperator(Convert.ToString(Eval("SideOperatorId")),Convert.ToString(Eval("GYSId")))%>
                                        </select>
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td align="right">
                                        结算明细：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <textarea name="txtMoneyDesc_require" class="inputtext" style="width: 180px; height: 70px;"><%#Eval("SettleDetail")%></textarea>
                                    </td>
                                    <td align="right">
                                        结算金额：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <input type="text" name="txtMoney_require" class="formsize140 inputtext" value='<%#EyouSoft.Common.Utils.GetDecimal(Convert.ToString(Eval("SettleAmount"))).ToString("f2") %>' />
                                    </td>
                                    <th align="right">
                                        安排备注：
                                    </th>
                                    <td bgcolor="#E3F1FC" align="left">
                                        <textarea name="txtremark_require" class="inputtext" style="width: 180px; height: 70px;"><%#Eval("PlanRemark")%></textarea>
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td height="30" align="right">
                                        具体安排：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left" colspan="5">
                                        <textarea name="txtDesc_require" class="inputtext" style="width: 600px; height: 70px;"><%#Eval("PlanDetail")%></textarea>
                                    </td>
                                </tr>
                                <tr class="odd">
                                    <td height="30" align="right">
                                        附件上传：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="left" colspan="2">
                                        <div style="margin: 0px 10px;" data-class="Route_upload_swfbox">
                                            <div>
                                                <input type="hidden" data-class="Route_upload" data-id="hide_Route_file" name="hide_Route_file_require"
                                                    value='<%#Eval("FileInfo") %>' />
                                                <span data-class="Route_upload" data-id="spanButtonPlaceholder"></span><span data-class="Route_upload"
                                                    data-id="errMsg" class="errmsg"></span>
                                            </div>
                                            <div data-class="Route_upload" data-id="divFileProgressContainer">
                                            </div>
                                            <div data-class="Route_upload" data-id="thumbnails">
                                            </div>
                                        </div>
                                        <%#Eval("FileInfo").ToString().Trim() != "" ? "<div data-class='span_Route_file' class='upload_filename'><a target='_blank' href='" + Eval("FileInfo").ToString().Split('|')[1].ToString() + "'>查看附件</a><a href='javascript:void(0);' title='删除附件' onclick='RouteEdit.RemoveFile(this);'><img src='/images/cha.gif' border='0'></a> </div>" : ""%>
                                    </td>
                                    <td bgcolor="#E3F1FC">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        酒店预订单：
                                    </td>
                                    <td bgcolor="#E3F1FC" align="center" class="i_td_querendan">
                                        <a target="_blank" href='/PrintPage/SupplierHotel.aspx?tourId=<%#Eval("TourId") %>&hpId=<%#Eval("Id") %>&orderid=<%#Eval("OrderId") %>
'>(<%#Eval("JiaoYiHao") %>)</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </th>
                    <th width="102" bgcolor="#E3F1FC" style="border-bottom: 1px solid #ccc;">
                        <a href="javascript:void(0)">
                            <img class="addbtn" width="48" height="20" src="/images/addimg.gif" alt="" /></a>
                        <a href="javascript:void(0)">
                            <img class="delbtn" width="48" height="20" src="/images/delimg.gif" alt="" /></a>
                    </th>
                </tr>
                <tr i_jiange="1">
                    <td clospan="2" style="height: 10px; font-size: 10px; line-height: 10px;">
                        &nbsp;
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="margin: 0px 10px; display: none;" id="divRouteUploadTemp">
        <div>
            <input type="hidden" data-class="Route_upload" data-id="hide_Route_file" name="hide_Route_file_require" />
            <span data-class="Route_upload" data-id="spanButtonPlaceholder"></span><span data-class="Route_upload"
                data-id="errMsg" class="errmsg"></span>
        </div>
        <div data-class="Route_upload" data-id="divFileProgressContainer">
        </div>
        <div data-class="Route_upload" data-id="thumbnails">
        </div>
    </div>
</div>

<script type="text/javascript">
    var anPaiIndex = 0;
    $(function() {
        RouteEdit.InitSwfUpload(null, null);
        $("#tbl_Route_AutoAdd").autoAdd({ addCallBack: RouteEdit.AddRowCallBack, upCallBack: RouteEdit.MoveRowCallBack, downCallBack: RouteEdit.MoveRowCallBack, isEnable: false,tempRowClass:"remp_row_jd_anpai" });
        $(".Offers").live("click", function() {
            $(this).attr("id", "btn_" + parseInt(Math.random() * 100000));
            var url = "/CommonPage/UserSupper.aspx?aid=" + $(this).attr("id") + "&";
            var hideObj = $(this).parent().find("input[name='ShowID_require']");
            var showObj = $(this).parent().find("input[name='SourceName_require']");
            if (!hideObj.attr("id")) {
                hideObj.attr("id", "hideID_" + parseInt(Math.random() * 10000000));
            }
            if (!showObj.attr("id")) {
                showObj.attr("id", "ShowID_" + parseInt(Math.random() * 10000000));
            }
            url += $.param({ suppliertype: 3, hideID: $("#" + hideObj.attr("id")).val(), callBack: "CallBackSource", isall: 1, pIframeId: '<%= EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' })
            top.Boxy.iframeDialog({
                iframeUrl: url,
                title: "选择供应商",
                modal: true,
                width: "880",
                height: "350"
            });
        });
        $("input[name='txtMoney_require']").change(function() {
            //"valid=\"required\"errmsg=\"供应商不能为空！\"";
            if ($(this).val() != "") {
                $(this).closest("tbody").find("input[name='SourceName_require']").attr("valid", "required");
                $(this).closest("tbody").find("input[name='SourceName_require']").attr("errmsg", "供应商不能为空!");
            }
        });

        //酒店名称后面更多click
        $(".i_a_gengduoanpai").bind("click", function() {
            var _$obj = $(this);
            var _aid = "i_a_gengduoanpai_" + anPaiIndex;
            var _txtmxid = "i_t_gengduoanpai_" + anPaiIndex;
            var _txtisrptid = "i_t_isrpt_" + anPaiIndex;
            var _$parenttdobj = _$obj.closest("td");
            var _$txtmxobj = _$parenttdobj.find("textarea[name='txtAnPaiMx']");
            var _$txtisrptobj = _$parenttdobj.find("input[name='txtIsRpt']");

            _$obj.removeAttr("id").attr("id", _aid);
            _$txtmxobj.removeAttr("id").attr("id", _txtmxid);
            _$txtisrptobj.removeAttr("id").attr("id", _txtisrptid);
            anPaiIndex++;

            var _data = { aid: _aid, txtid: _txtmxid, txtisrptid: _txtisrptid, refereriframeid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("iframeId") %>' };
            var _win = top || window;
            _win.Boxy.iframeDialog({ title: "更多酒店安排", iframeUrl: "/teamplan/planhotelmx.aspx", width: "970px", height: "300px", data: _data });
            return false;
        })
    })
    //回调函数 给供应商赋值(hideid,showid)
    function CallBackSource(obj) {
        if (obj) {
            $("#" + obj.aid).closest("tr").find("input[name='SourceName_require']").val(obj.name);
            $("#" + obj.aid).closest("tr").find("input[name='ShowID_require']").val(obj.id);
            if(obj.name!=""){
                $("#" + obj.aid).closest("tbody").find("input[name='txtMoney_require']").attr("valid","required");
                $("#" + obj.aid).closest("tbody").find("input[name='txtMoney_require']").attr("errmsg","结算金额不能为空!");
            }
            var strHtml = '<option value="-1">请选择</option>';
            var cclist = JSON.parse(obj.ContactList);
            for (var j = 0; j < cclist.length; j++) {
                strHtml += '<option value="' + cclist[j].ccId + '">' + cclist[j].ccname + '</option>'
            }
            $("#" + obj.aid).closest("tr").find("select[name='sltdfoperater']").html(strHtml);
        }
    }
</script>

