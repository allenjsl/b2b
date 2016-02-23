using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Common.Page;
using System.Text;
using EyouSoft.Common.Function;

namespace Web.SystemSet
{
    public partial class DepartAdd : BackPage
    {
        protected string pageHeader = string.Empty;//页眉
        protected string pageFooter = string.Empty;//页脚
        protected string pageModel = string.Empty;//模板
        protected string departSeal = string.Empty;//部门公章
        protected string parentD = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //判断权限
            if (!CheckGrant(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_部门管理栏目))
            {
                Utils.ResponseNoPermit(global::EyouSoft.Model.EnumType.PrivsStructure.Privs3.系统设置_组织机构_部门管理栏目, false);
                return;
            }
            int departId = Utils.GetInt(Utils.GetQueryStringValue("departId"));//报价Id
            string method = Utils.GetFormValue("hidMethod");//获取当前操作(保存/继续)
            string method2 = Utils.GetQueryStringValue("method2");//判断是否为新增或修改
            string showMess = "数据保存成功！";//提示消息
            EyouSoft.Model.CompanyStructure.Department departModel = null;
            EyouSoft.BLL.CompanyStructure.Department departBll = new EyouSoft.BLL.CompanyStructure.Department();//初始化bll
            EyouSoft.BLL.CompanyStructure.CompanyUser userBll = new EyouSoft.BLL.CompanyStructure.CompanyUser();//初始化bll
            IList<EyouSoft.Model.CompanyStructure.Department> departList = departBll.GetAllDept(this.SiteUserInfo.CompanyId, CurrentZxsId);

            var userChaXunInfo = new EyouSoft.Model.CompanyStructure.QueryCompanyUser();
            userChaXunInfo.ZxsId = CurrentZxsId;
            userChaXunInfo.LeiXing = EyouSoft.Model.EnumType.CompanyStructure.YongHuLeiXing.专线用户;
            IList<EyouSoft.Model.CompanyStructure.CompanyUser> userlist = userBll.GetList(this.SiteUserInfo.CompanyId, userChaXunInfo);
            //绑定部门列表
            if (departList != null && departList.Count > 0)
            {
                selParentDE.DataTextField = "DepartName";
                selParentDE.DataValueField = "Id";
                selParentDE.DataSource = departList;
                selParentDE.DataBind();

            }
            //绑定员工列表
            if (userlist != null && userlist.Count > 0)
            {
                foreach (EyouSoft.Model.CompanyStructure.CompanyUser user in userlist)
                {
                    selDepEmp.Items.Add(new ListItem(user.PersonInfo.ContactName, user.ID.ToString()));
                }
            }
            selParentDE.Items.Insert(0, new ListItem("请选择", ""));//上级部门
            selDepEmp.Items.Insert(0, new ListItem("请选择", ""));//部门主管
            //无操作方式则为获取数据
            if (method == "")
            {
                #region 初始化数据

                if (departId != 0)
                {
                    departModel = departBll.GetModel(departId);
                    if (method2 == "update")//修改
                    {
                        if (departModel != null)
                        {
                            txtDepName.Value = departModel.DepartName;//部门名称
                            selDepEmp.Value = departModel.DepartManger.ToString();//部门主管
                            selParentDE.Value = departModel.PrevDepartId.ToString();// 上级部门
                            parentD = departModel.PrevDepartId.ToString();
                            txtTel.Value = departModel.ContactTel;//联系电话
                            txtRemark.Value = departModel.Remark;//备注
                            txtFax.Value = departModel.ContactFax;//传真
                            if (parentD == "0")
                            {
                                selParentDE.Attributes.Remove("valid");
                            }
                        }
                    }
                    else
                    {
                        if (departModel != null)
                        {
                            selParentDE.Value = departModel.Id.ToString();//如果是添加操作则将部门ID设置上级部门

                        }

                    }
                    return;
                }
                #endregion
            }
            else
            {
                #region 保存操作

                bool result = true;
                departModel = new EyouSoft.Model.CompanyStructure.Department();

                if (result)
                {
                    departModel.CompanyId = this.SiteUserInfo.CompanyId;//公司ID
                    departModel.ContactFax = Utils.InputText(txtFax.Value);//传真
                    departModel.ContactTel = Utils.InputText(txtTel.Value);//电话
                    departModel.DepartName = Utils.InputText(txtDepName.Value);//部门名称
                    departModel.Remark = Utils.InputText(txtRemark.Value);//备注
                    departModel.IssueTime = DateTime.Now;//添加时间
                    departModel.OperatorId = SiteUserInfo.UserId;//操作人
                    departModel.PrevDepartId = Utils.GetInt(Utils.GetFormValue(selParentDE.UniqueID));//上级部门
                    departModel.DepartManger = Utils.GetInt(Utils.GetFormValue(selDepEmp.UniqueID));//部门主管
                    departModel.ZxsId = SiteUserInfo.ZxsId;
                    //if (departModel.DepartManger == 0)
                    //{
                    //    MessageBox.Show(this, "请填写完整数据！");
                    //    return;
                    //}
                    if (departId != 0)
                    {
                        if (method2 == "update")
                        {
                            departModel.Id = departId;
                            result = departBll.Update(departModel);//修改部门
                        }
                        else
                        {
                            result = departBll.Add(departModel);//添加部门
                        }

                    }
                    else
                    {
                        result = departBll.Add(departModel);//添加部门
                    }
                }
                if (!result)
                {
                    showMess = "数据保存失败！";
                }
                StringBuilder messBuilder = new StringBuilder();
                //如果是修改则回调父窗口的修改方法,否则回调新增方法
                if (method2 == "update")
                    messBuilder.AppendFormat(";window.parent.DM.callbackUpdateD('{0}','{1}','{3}');alert('{2}');", departId, Utils.InputText(txtDepName.Value), showMess, departModel.PrevDepartId.ToString() != Utils.GetFormValue("hidParentDE"));
                else
                    messBuilder.AppendFormat(";window.parent.DM.callbackAddD('{0}');alert('{1}');", departId, showMess);
                //如果是保存继续则刷新页面,否则关闭弹窗
                if (method == "continue")
                {
                    messBuilder.AppendFormat("window.location='/SystemSet/DepartAdd.aspx?method2=add&departId={0}", departId);
                }
                else
                {
                    messBuilder.AppendFormat("window.parent.Boxy.getIframeDialog('{0}').hide();", Utils.GetQueryStringValue("iframeId"));
                }
                MessageBox.ResponseScript(this, messBuilder.ToString());
                return;
                #endregion
            }
        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.PageType = EyouSoft.Common.Page.PageType.boxyPage;
        }
    }
}
