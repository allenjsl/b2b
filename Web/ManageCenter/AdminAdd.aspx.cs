using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using EyouSoft.Common.Function;

namespace Web.ManageCenter
{
    public partial class AdminAdd : BackPage
    {
        protected string Province = "0";
        protected string City = "0";
        #region 基本数据
        protected string FileNo = string.Empty;
        protected string Name = string.Empty;
        protected string CardID = string.Empty;
        protected DateTime? Birthday;
        protected string WorkerPicture = string.Empty;
        protected string EntryDate = string.Empty;
        //protected string dpWorkLife = string.Empty;
        protected string LeftDate = string.Empty;
        protected string National = string.Empty;
        protected string Political = string.Empty;
        protected string Telephone = string.Empty;
        protected string Mobile = string.Empty;
        protected string QQ = string.Empty;
        protected string MSN = string.Empty;
        protected string Email = string.Empty;
        protected string Address = string.Empty;
        protected string Remark = string.Empty;
        protected string WeiXinHao = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ITitle = "人事档案_行政中心";
            int PersonnelID = Utils.GetInt(Utils.GetQueryStringValue("PersonnelID"), -1);//档案ID
            string Method = Utils.GetFormValue("hiddenMethod");             //执行方法
            EyouSoft.BLL.AdminCenterStructure.PersonnelInfo bllPersonnel;
            EyouSoft.Model.AdminCenterStructure.PersonnelInfo modelPersonnel;
            this.UploadControl1.CompanyID = this.SiteUserInfo.CompanyId;
            this.UploadControl1.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";
            this.UploadControl2.CompanyID = this.SiteUserInfo.CompanyId;
            this.UploadControl2.FileTypes = "*.jpg;*.jpeg;*.gif;*.png;*.bmp;";

            if (!IsPostBack)
            {
                DutyInit();
                this.hiddenID.Value = PersonnelID.ToString();
                if (PersonnelID != -1)
                {
                    if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_人事档案_修改))
                    {
                        Utils.ResponseNoPermit(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_人事档案_修改, true);
                    }

                    //绑定修改数据
                    bllPersonnel = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo();
                    modelPersonnel = bllPersonnel.GetModel(CurrentUserCompanyID, PersonnelID);

                    #region 基本信息
                    if (modelPersonnel != null)
                    {
                        FileNo = modelPersonnel.ArchiveNo;
                        Name = modelPersonnel.UserName;
                        this.dpSex.SelectedIndex = (int)modelPersonnel.ContactSex;        //性别
                        CardID = modelPersonnel.CardId;
                        Birthday = modelPersonnel.BirthDate;

                        if (modelPersonnel.PhotoPath != "")
                        {
                            var arr = modelPersonnel.PhotoPath.Split('|');
                            this.lbphoto.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>{1}</a><a href='javascript:void(0);' onclick=\"PersonFileEdit.delLatestAttach(this)\"> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' id='txtLatestAttach1' name='txtLatestAttach1' value='{2}'></span>", arr.Length > 1 ? arr[1] : arr[0], arr[0], modelPersonnel.PhotoPath);
                        }

                        if (modelPersonnel.CardPath != "")
                        {
                            var arr = modelPersonnel.CardPath.Split('|');
                            this.Label1.Text = string.Format("<span class='upload_filename'>&nbsp;<a href='{0}' target='_blank'>{1}</a><a href='javascript:void(0);' onclick=\"PersonFileEdit.delLatestAttach(this)\"> <img style='vertical-align:middle' src='/images/cha.gif'></a><input type='hidden' id='txtLatestAttach2' name='txtLatestAttach2' value='{2}'></span>", arr.Length > 1 ? arr[1] : arr[0], arr[0], modelPersonnel.CardPath);
                        }

                        if (modelPersonnel.DutyId != null)
                            this.ddlJobPostion.Text = modelPersonnel.DutyId.ToString();//职务
                        this.dpWorkerState.SelectedIndex = modelPersonnel.IsLeave ? 1 : 0;               //员工状态
                        this.dpWorkerType.SelectedIndex = (int)modelPersonnel.PersonalType;              //类型
                        EntryDate = modelPersonnel.EntryDate == null ? "" : Convert.ToDateTime(modelPersonnel.EntryDate).ToString("yyyy-MM-dd");
                        this.dpMarriageState.SelectedIndex = modelPersonnel.IsMarried ? 1 : 0;//婚姻状态
                        LeftDate = modelPersonnel.LeaveDate == null ? "" : Convert.ToDateTime(modelPersonnel.LeaveDate).ToString("yyyy-MM-dd");
                        National = modelPersonnel.National;

                        if (modelPersonnel.Birthplace != null && modelPersonnel.Birthplace.Split(',').Length >= 2)//籍贯
                        {
                            this.Province = modelPersonnel.Birthplace.Split(',')[0];
                            this.City = modelPersonnel.Birthplace.Split(',')[1];
                        }                       
                        
                        #region dept info
                        //this.SelectSection1.SectionName = GetDepartmentByID(modelPersonnel.DepartmentId);//所属部门
                        //this.SelectSection1.SectionID = modelPersonnel.DepartmentId;
                        if (modelPersonnel.DepartmentList != null && modelPersonnel.DepartmentList.Count > 0)
                        {
                            string deptNames = string.Empty;
                            string deptIds = string.Empty;

                            foreach (var item in modelPersonnel.DepartmentList)
                            {
                                deptIds += item.Id+",";
                                deptNames += item.DepartName + ",";
                            }

                            deptIds = deptIds.TrimEnd(',');
                            deptNames = deptNames.TrimEnd(',');

                            SelectSection1.SectionName = deptNames;
                            SelectSection1.SectionID = deptIds;
                        }
                        #endregion

                        Political = modelPersonnel.Politic;
                        Telephone = modelPersonnel.ContactTel;
                        Mobile = modelPersonnel.ContactMobile;
                        QQ = modelPersonnel.QQ;
                        Email = modelPersonnel.Email;
                        MSN = modelPersonnel.MSN;
                        Address = modelPersonnel.ContactAddress;
                        Remark = modelPersonnel.Remark;
                        WeiXinHao = modelPersonnel.WeiXinHao;
                        if (modelPersonnel.EntryDate != null)
                        {
                            if (modelPersonnel.LeaveDate == null)
                            {
                                TimeSpan ts = Utils.GetDateTime(modelPersonnel.EntryDate.ToString()) - DateTime.Now;
                                this.lbAge.Text = (ts.TotalDays / 365).ToString("f1");
                            }
                            else
                            {
                                TimeSpan ts = Utils.GetDateTime(modelPersonnel.LeaveDate.ToString()) - Utils.GetDateTime(modelPersonnel.EntryDate.ToString());
                                this.lbAge.Text = (ts.TotalDays / 365).ToString("f1");
                            }
                        }
                        #region 学历信息和履历信息
                        if (modelPersonnel.SchoolList != null && modelPersonnel.SchoolList.Count > 0)
                        {
                            this.rpt_Record.DataSource = modelPersonnel.SchoolList;
                            this.rpt_Record.DataBind();
                        }
                        if (modelPersonnel.HistoryList != null && modelPersonnel.HistoryList.Count > 0)
                        {
                            this.rpt_Resume.DataSource = modelPersonnel.HistoryList;
                            this.rpt_Resume.DataBind();
                        }
                        #endregion

                        if (modelPersonnel.YinHangZhangHus != null && modelPersonnel.YinHangZhangHus.Count >0)
                        {
                            txtAccountName.Value = modelPersonnel.YinHangZhangHus[0].AccountName;                            
                            txtBankName.Value = modelPersonnel.YinHangZhangHus[0].BankName;
                            txtBankNo.Value = modelPersonnel.YinHangZhangHus[0].BankNo;
                        }
                    }
                    #endregion


                }
                else
                {
                    if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_人事档案_新增))
                    {
                        Utils.ResponseNoPermit(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.行政中心_人事档案_新增, true);
                    }
                }
            }

            if (Method != "")//保存和修改
            {
                GetAddOrUpdatePersonnelInfo(out bllPersonnel, out modelPersonnel);
                string msg = string.Empty;
                if (modelPersonnel.ArchiveNo == "")
                {
                    msg += "档案编号不能回空!<br/>";
                }
                if (modelPersonnel.UserName == "")
                {
                    msg += "姓名不能为空!";
                }
                if (modelPersonnel.ArchiveNo == "" || modelPersonnel.UserName == "")
                {
                    MessageBox.Show(this.Page, msg);
                    return;
                }
                if (Method == "Save" && PersonnelID == -1)//保存 
                {
                    if (bllPersonnel.Add(modelPersonnel))
                    {
                        MessageBox.ShowAndRedirect(this.Page, "保存成功！", "/ManageCenter/AdminFileList.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this.Page, "保存失败！");
                    }
                }
                //else if (Method == "SaveAndAdd" && PersonnelID == -1) //保存并继续添加
                //{
                //    if (bllPersonnel.Add(modelPersonnel))
                //    {
                //        MessageBox.ShowAndRedirect(this.Page, "保存成功！", this.Request.Url.ToString());
                //    }
                //    else
                //    {
                //        MessageBox.Show(this.Page, "保存失败！");
                //    }
                //}
                else if (Method == "Update" && PersonnelID != -1) //修改
                {
                    modelPersonnel.Id = PersonnelID;
                    if (bllPersonnel.Update(modelPersonnel))
                    {
                        MessageBox.ShowAndRedirect(this.Page, "修改成功！", "/ManageCenter/AdminFileList.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this.Page, "修改失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 得到保存或者修改的对象
        /// </summary>
        private void GetAddOrUpdatePersonnelInfo(out EyouSoft.BLL.AdminCenterStructure.PersonnelInfo bllPersonnel, out EyouSoft.Model.AdminCenterStructure.PersonnelInfo modelPersonnel)
        {
            #region "基本信息"
            FileNo = Utils.GetFormValue("txt_FileNo");//档案编号
            Name = Utils.GetFormValue("txt_Name");    //姓名
            CardID = Utils.GetFormValue("txt_CardID");  //身份证号码
            Birthday = Utils.GetDateTimeNullable(Request.Form["txt_Birthday"]);  //生日

            EntryDate = Utils.GetFormValue("txt_EntryDate"); //入职日期
            //dpWorkLife = Utils.GetFormValue("dpWorkLife");           //工龄
            LeftDate = Utils.GetFormValue("txt_LeftDate");               //离职日期
            National = Utils.GetFormValue("txt_National");           //民族
            Political = Utils.GetFormValue("txt_Political"); //政治面貌
            Telephone = Utils.GetFormValue("txt_Telephone");    //联系电话
            Mobile = Utils.GetFormValue("txt_Mobile");          //手机
            QQ = Utils.GetFormValue("txt_QQ");
            MSN = Utils.GetFormValue("txt_MSN");
            Email = Utils.GetFormValue("txt_Email");
            Address = Utils.GetFormValue("txt_Address");
            Remark = Utils.GetFormValue("txt_Remark");
            #endregion

            #region "学历信息"
            string[] keysGrade = Utils.GetFormValues("EducationGrade");//学历
            string[] keysState = Utils.GetFormValues("EducationState");//状态
            string[] RecordStartDate = Utils.GetFormValues("txt_RecordStartDate");//开始时间
            string[] RecordEndDate = Utils.GetFormValues("txt_RecordEndDate");//结束时间
            string[] Profession = Utils.GetFormValues("txt_Profession");    //专业
            string[] Graduation = Utils.GetFormValues("txt_Graduation");      //毕业院校
            string[] RecordRemark = Utils.GetFormValues("txt_RecordRemark");//备注
            #endregion

            #region "履历信息"
            string[] ResumeStartDate = Utils.GetFormValues("txt_ResumeStartDate");//开始时间
            string[] ResumeEndDate = Utils.GetFormValues("txt_ResumeEndDate");//结束时间
            string[] WorkPlace = Utils.GetFormValues("txt_WorkPlace");  //工作地点
            string[] WorkUnit = Utils.GetFormValues("txt_WorkUnit");    //工作单位
            string[] Job = Utils.GetFormValues("txt_Job");      //职业
            string[] ResumeRemark = Utils.GetFormValues("txt_ResumeRemark");//备注
            #endregion

            bllPersonnel = new EyouSoft.BLL.AdminCenterStructure.PersonnelInfo();
            modelPersonnel = new EyouSoft.Model.AdminCenterStructure.PersonnelInfo();

            modelPersonnel.WeiXinHao = Utils.GetFormValue("txtWeiXinHao");

            #region 保存修改
            modelPersonnel.CompanyId = CurrentUserCompanyID;
            modelPersonnel.ArchiveNo = FileNo;
            modelPersonnel.UserName = Name;
            modelPersonnel.ContactSex = (EyouSoft.Model.EnumType.CompanyStructure.Sex)this.dpSex.SelectedIndex;
            modelPersonnel.CardId = CardID;
            modelPersonnel.BirthDate = Birthday;
            modelPersonnel.DepartmentId = Utils.GetFormValue(SelectSection1.SelectIDClient);


            HttpPostedFile hpf = this.Request.Files["FileEmployeePicture"];
            #region 员工照片/身份证上传
            string UserPhoto = Utils.GetFormValue(UploadControl1.ClientHideID);
            if (!string.IsNullOrEmpty(UserPhoto))
            {
                modelPersonnel.PhotoPath = UserPhoto;
            }
            else
            {
                modelPersonnel.PhotoPath = Utils.GetFormValue("txtLatestAttach1");
            }

            string card = Utils.GetFormValue(UploadControl2.ClientHideID);
            if (!string.IsNullOrEmpty(card))
            {
                modelPersonnel.CardPath = card;
            }
            else
            {
                modelPersonnel.CardPath = Utils.GetFormValue("txtLatestAttach2");
            }
            #endregion
            modelPersonnel.DutyName = ddlJobPostion.SelectedValue;
            string m = this.ddlJobPostion.Text;
            modelPersonnel.DutyId = Utils.GetIntNull(Utils.GetFormValue(this.ddlJobPostion.UniqueID));//职务ID

            modelPersonnel.IsLeave = this.dpWorkerState.Value == "1" ? true : false;
            modelPersonnel.PersonalType = (EyouSoft.Model.EnumType.AdminCenterStructure.PersonalType)Utils.GetInt(this.dpWorkerType.Value);
            //modelPersonnel.WorkYear = Utils.GetInt(dpWorkLife);
            modelPersonnel.EntryDate = Utils.GetDateTimeNullable(EntryDate);

            modelPersonnel.IsMarried = this.dpMarriageState.Value == "1" ? true : false;
            modelPersonnel.LeaveDate = Utils.GetDateTimeNullable(LeftDate);
            modelPersonnel.National = National;
            modelPersonnel.Birthplace = Utils.GetFormValue(this.ddlProvice.UniqueID) + "," + Utils.GetFormValue(this.ddlCity.UniqueID);
            modelPersonnel.DutyName = ddlJobPostion.SelectedValue;
            modelPersonnel.DutyId = Utils.GetIntNull(Utils.GetFormValue(this.ddlJobPostion.UniqueID));//职务ID
            modelPersonnel.Politic = Political;
            modelPersonnel.ContactTel = Telephone;
            modelPersonnel.ContactMobile = Mobile;
            modelPersonnel.QQ = QQ;
            modelPersonnel.Email = Email;
            modelPersonnel.MSN = MSN;
            modelPersonnel.ContactAddress = Address;
            modelPersonnel.Remark = Remark;

            #region 学历信息
            IList<EyouSoft.Model.AdminCenterStructure.SchoolInfo> listSchool = new List<EyouSoft.Model.AdminCenterStructure.SchoolInfo>();
            EyouSoft.Model.AdminCenterStructure.SchoolInfo modelSchool = null;
            if (RecordStartDate != null && RecordStartDate.Length > 0)
            {
                for (int index = 0; index < RecordStartDate.Length; index++)
                {
                    if (!string.IsNullOrEmpty(RecordStartDate[index].Trim()))
                    {
                        modelSchool = new EyouSoft.Model.AdminCenterStructure.SchoolInfo();
                        modelSchool.StartDate = Utils.GetDateTimeNullable(RecordStartDate[index].Trim());
                        modelSchool.EndDate = Utils.GetDateTimeNullable(RecordEndDate[index].Trim());
                        modelSchool.Degree = (EyouSoft.Model.EnumType.AdminCenterStructure.DegreeType)Utils.GetInt(keysGrade[index]);
                        modelSchool.Professional = Utils.InputText(Profession[index].Trim());
                        modelSchool.SchoolName = Utils.InputText(Graduation[index].Trim());
                        modelSchool.StudyStatus = Convert.ToBoolean(Utils.GetInt(keysState[index]));
                        modelSchool.Remark = Utils.InputText(RecordRemark[index].Trim());
                        listSchool.Add(modelSchool);
                    }
                }
                if (listSchool.Count > 0)
                {
                    modelPersonnel.SchoolList = listSchool;
                }
            }
            #endregion

            #region 履历信息
            IList<EyouSoft.Model.AdminCenterStructure.PersonalHistory> listHistory = new List<EyouSoft.Model.AdminCenterStructure.PersonalHistory>();
            EyouSoft.Model.AdminCenterStructure.PersonalHistory modelHistory = null;
            if (ResumeStartDate != null && ResumeStartDate.Length > 0)
            {
                for (int index = 0; index < ResumeStartDate.Length; index++)
                {
                    if (!string.IsNullOrEmpty(ResumeStartDate[index].Trim()))
                    {
                        modelHistory = new EyouSoft.Model.AdminCenterStructure.PersonalHistory();
                        modelHistory.StartDate = Utils.GetDateTimeNullable(ResumeStartDate[index].Trim());
                        modelHistory.EndDate = Utils.GetDateTimeNullable(ResumeEndDate[index].Trim());
                        modelHistory.WorkPlace = Utils.InputText(WorkPlace[index].Trim());
                        modelHistory.WorkUnit = Utils.InputText(WorkUnit[index].Trim());
                        modelHistory.TakeUp = Utils.InputText(Job[index].Trim());
                        modelHistory.Remark = Utils.InputText(ResumeRemark[index].Trim());
                        listHistory.Add(modelHistory);
                    }
                }
                if (listHistory != null && listHistory.Count > 0)
                {
                    modelPersonnel.HistoryList = listHistory;
                }
            }
            #endregion

            #endregion

            modelPersonnel.YinHangZhangHus = new List<EyouSoft.Model.CompanyStructure.CompanyAccountBase>();
            var yinHangZhangHuInfo = new EyouSoft.Model.CompanyStructure.CompanyAccountBase();
            yinHangZhangHuInfo.AccountName = Utils.GetFormValue(txtAccountName.UniqueID);
            yinHangZhangHuInfo.BankName = Utils.GetFormValue(txtBankName.UniqueID);
            yinHangZhangHuInfo.BankNo = Utils.GetFormValue(txtBankNo.UniqueID);
            modelPersonnel.YinHangZhangHus.Add(yinHangZhangHuInfo);
        }

        /*/// <summary>
        /// 得到部门名称
        /// </summary>
        public string GetDepartmentByID(object DepartmentId)
        {
            string result = "";
            if (DepartmentId != null && DepartmentId.ToString() != "")
            {
                string[] ids = DepartmentId.ToString().Split(',');
                EyouSoft.BLL.CompanyStructure.Department bllDepartment = new EyouSoft.BLL.CompanyStructure.Department();
                if (ids != null && ids.Length > 0)
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        var m = bllDepartment.GetModel(Utils.GetInt(ids[i]));
                        if (m==null)continue;
                        result += m.DepartName + ",";
                    }
                    if (!string.IsNullOrEmpty(result))
                    {
                        result = result.Substring(0, result.Length - 1);
                    }
                }
            }
            return result;
        }*/

        /// <summary>
        /// 初始话职务信息
        /// </summary>
        private void DutyInit()
        {
            EyouSoft.BLL.AdminCenterStructure.DutyManager bllDuty = new EyouSoft.BLL.AdminCenterStructure.DutyManager();
            this.ddlJobPostion.Items.Clear();
            this.ddlJobPostion.Items.Add(new ListItem("--请选择--", "0"));

            IList<EyouSoft.Model.AdminCenterStructure.DutyManager> listDuty = bllDuty.GetList(CurrentUserCompanyID);
            if (listDuty != null && listDuty.Count != 0)
            {
                foreach (EyouSoft.Model.AdminCenterStructure.DutyManager modelDuty in listDuty)
                {
                    this.ddlJobPostion.Items.Add(new ListItem(modelDuty.JobName, modelDuty.Id.ToString()));
                }
            }
        }

        ///// <summary>
        ///// 绑定学历和状态选项
        ///// </summary>
        //protected void rpt_Record_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    (e.Item.FindControl("EducationGrade") as System.Web.UI.HtmlControls.HtmlSelect).Items.FindByValue(((int)(e.Item.DataItem as EyouSoft.Model.AdminCenterStructure.SchoolInfo).Degree).ToString()).Selected = true;
        //    (e.Item.FindControl("EducationState") as System.Web.UI.HtmlControls.HtmlSelect).Items.FindByValue(Convert.ToByte((e.Item.DataItem as EyouSoft.Model.AdminCenterStructure.SchoolInfo).StudyStatus).ToString()).Selected = true;
        //}

        /// <summary>
        /// 初始化学历状态
        /// </summary>
        protected string GetEducationGrade(int gradeInt)
        {
            string returnStr = "";
            string Grade = "";
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        Grade = "初中";
                        break;
                    case 1:
                        Grade = "中专";
                        break;
                    case 2:
                        Grade = "高中";
                        break;
                    case 3:
                        Grade = "专科";
                        break;
                    case 4:
                        Grade = "本科";
                        break;
                    case 5:
                        Grade = "硕士";
                        break;
                    case 6:
                        Grade = "博士";
                        break;
                    default: break;
                }
                if (i == gradeInt)
                {
                    returnStr += "<option value='" + i + "' selected='selected'>" + Grade + "</option>";
                }
                else
                {
                    returnStr += "<option value='" + i + "'>" + Grade + "</option>";
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 初始话毕业状态
        /// </summary>
        protected string GetEducationState(bool stateBool)
        {
            string returnStr = "";
            if (!stateBool)
            {
                returnStr = "<option value='1'>毕业</option><option value='0' selected='selected' >在读</option>";
            }
            else
            {
                returnStr = "<option value='1' selected='selected' >毕业</option><option value='0'>在读</option>";
            }
            return returnStr;
        }

    }
}
