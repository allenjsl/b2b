using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace Web.UserControl.ucSystemSet
{
    /// <summary>
    /// 所有权限列表(用户控件用于角色管理,员工授权
    /// xuty 2011/01/15
    /// </summary>
    public partial class PermitList : System.Web.UI.UserControl
    {
        #region attributes
        /// <summary>
        /// 子系统一级栏目、二级栏目、明细权限信息业务实体
        /// </summary>
        EyouSoft.Model.SysStructure.MComPrivsInfo ComPrivsInfo = null;
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ComPrivsInfo = GetComPrivs();

            IList<EyouSoft.Model.SysStructure.MSysMenu1Info> permitList = new EyouSoft.BLL.SysStructure.BSys().GetPrivs1();
            for (int i = permitList.Count - 1; i >= 0; i--)
            {
                //if (ComPrivsInfo.Privs2.Contains(permitList[i].MenuId)) continue;
                if (ComPrivsInfo.Privs1.Contains(permitList[i].MenuId)) continue;
                permitList.RemoveAt(i);
            }

            //绑定所有权限
            if (permitList != null && permitList.Count > 0)
            {
                rptPerList.DataSource = permitList;
                rptPerList.DataBind();
            }
        }
        /// <summary>
        /// 绑定大类时获取子类及具体权限
        /// </summary>
        /// <param name="p2ListObj"></param>
        /// <returns></returns>
        protected string GetPermitHtml(object ClassListObj)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (ClassListObj != null)
            {
                IList<EyouSoft.Model.SysStructure.MSysMenu2Info> classList = ((IList<EyouSoft.Model.SysStructure.MSysMenu2Info>)ClassListObj);
                for (int i = classList.Count - 1; i >= 0; i--)
                {
                    if (ComPrivsInfo.Privs2.Contains(classList[i].MenuId)) continue;
                    classList.RemoveAt(i);
                }

                int classCount = classList.Count;//获取子类数
                if (classCount > 0)
                {
                    strBuilder.Append("<table width=\"850\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"1\" style=\"margin-bottom:10px;\">");
                    int row = (int)Math.Ceiling((decimal)(classCount / 4.0));//获取子类生成的行数按照4列1行
                    int bgRow = 1;
                    for (int rowIndex = 1; rowIndex <= row; rowIndex++)//按照行数生成行
                    {
                        IList<EyouSoft.Model.SysStructure.MSysMenu2Info> classListRow = classList.Skip((rowIndex - 1) * 4).Take(4).ToList<EyouSoft.Model.SysStructure.MSysMenu2Info>();//获取该行内的所拥有的子类集合
                        int perCols = 4;//改行内含有子类数4
                        int remain = 0;//还差几类成行0
                        if (rowIndex == row)//如果是最后一行则
                        {
                            perCols = classListRow.Count();
                            remain = 4 - perCols;
                        }
                        strBuilder.Append("<tr>");
                        //遍历类数生成类标题
                        for (int colIndex = 1; colIndex <= perCols; colIndex++)
                        {
                            strBuilder.AppendFormat("<th width=\"25%\" height=\"26\"  align=\"left\" bgcolor=\"{1}\" class=\"pandl3\"><input type=\"checkbox\" ca=\"{2}\" onclick=\"clChk('{3}',this);\"  />{0}</th>", classListRow[colIndex - 1].Name, bgRow % 2 == 1 ? "#BDDCF4" : "#e3f1fc", classListRow[0].FirstId, classListRow[colIndex - 1].MenuId);
                        }
                        //不足的生成空白列
                        for (int colIndex = 1; colIndex <= remain; colIndex++)
                        {
                            strBuilder.AppendFormat("<th width=\"25%\" height=\"26\"  align=\"left\" bgcolor=\"{0}\" class=\"pandl3\"></th>", bgRow % 2 == 1 ? "#BDDCF4" : "#e3f1fc");
                        }
                        strBuilder.Append("</tr>");

                        bgRow++;//行数做隔行变色用

                        int perMax = classListRow.Max(p => p.Privs == null ? 0 : p.Privs.Count);//获取该子类行权限要生成的行数
                        for (int rowIndex2 = 1; rowIndex2 <= perMax; rowIndex2++)
                        {
                            strBuilder.Append("<tr>");
                            for (int colIndex = 1; colIndex <= perCols; colIndex++)
                            {
                                IList<EyouSoft.Model.SysStructure.MSysPrivsInfo> permitList = classListRow[colIndex - 1].Privs;
                                for (int i = permitList.Count - 1; i >= 0; i--)
                                {
                                    if (ComPrivsInfo.Privs3.Contains(permitList[i].PrivsId)) continue;
                                    permitList.RemoveAt(i);
                                }

                                int permitCount = permitList.Count;
                                if (rowIndex2 > permitCount)
                                {
                                    strBuilder.AppendFormat("<td width=\"25%\" height=\"26\"  align=\"left\" bgcolor=\"{0}\" class=\"pandl3\"></td>", bgRow % 2 == 1 ? "#BDDCF4" : "#e3f1fc");
                                }
                                else
                                {
                                    strBuilder.AppendFormat("<td width=\"25%\" height=\"26\"  align=\"left\" bgcolor=\"{1}\" class=\"pandl3\"><input type=\"checkbox\" name=\"perItem\" value=\"{2}\" cl=\"{3}\" ca=\"{5}\" {4} />{0}</td>", permitList[rowIndex2 - 1].Name
                                        , bgRow % 2 == 1 ? "#BDDCF4" : "#e3f1fc"
                                        , permitList[rowIndex2 - 1].PrivsId
                                        , permitList[rowIndex2 - 1].SecondId
                                        , GetChecked(permitList[rowIndex2 - 1].PrivsId)
                                        , classList[rowIndex - 1].FirstId);
                                }

                            }
                            for (int colIndex = 1; colIndex <= remain; colIndex++)
                            {
                                strBuilder.AppendFormat("<td width=\"25%\" height=\"26\"  align=\"left\" bgcolor=\"{0}\" class=\"pandl3\"></td>", bgRow % 2 == 1 ? "#BDDCF4" : "#e3f1fc");
                            }
                            strBuilder.Append("</tr>");
                            bgRow++;
                        }


                    }
                    strBuilder.Append("</table>");
                }

            }
            return strBuilder.ToString();
        }

        public int SysId { get; set; }

        /// <summary>
        /// 拥有的权限
        /// </summary>
        public string[] SetPermitList
        {
            get;
            set;
        }
        /// <summary>
        /// 是否选中权限
        /// </summary>
        /// <param name="perId"></param>
        /// <returns></returns>
        protected string GetChecked(int perId)
        {
            if (SetPermitList != null)
            {
                return SetPermitList.Contains(perId.ToString()) ? "checked=\"checked\"" : "";
            }
            return "";
        }

        /// <summary>
        /// get comprivs
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.SysStructure.MComPrivsInfo GetComPrivs()
        {
            EyouSoft.Model.SysStructure.MComPrivsInfo info = null;
            var uinfo = EyouSoft.Security.Membership.UserProvider.GetUserInfo();
            var zxsInfo = new EyouSoft.BLL.PtStructure.BZhuanXianShang().GetInfo(uinfo.ZxsId);

            if (zxsInfo.Privs1 == "ALL" && zxsInfo.Privs2 == "ALL" && zxsInfo.Privs3 == "ALL")
            {
                info = new EyouSoft.BLL.SysStructure.BSys().GetComPrivsInfo(uinfo.CompanyId);
            }
            else
            {
                info = new EyouSoft.Model.SysStructure.MComPrivsInfo();

                if (string.IsNullOrEmpty(zxsInfo.Privs1))
                {
                    info.Privs1 = new int[] { -1 };
                }
                else
                {
                    string[] items = zxsInfo.Privs1.Split(',');

                    if (items != null && items.Length > 0)
                    {
                        info.Privs1 = new int[items.Length];

                        for (var i = 0; i < items.Length; i++)
                        {
                            info.Privs1[i] = Utils.GetInt(items[i], -1);
                        }
                    }
                    else info.Privs1 = new int[] { -1 };

                }

                if (string.IsNullOrEmpty(zxsInfo.Privs2))
                {
                    info.Privs2 = new int[] { -1 };
                }
                else
                {
                    string[] items = zxsInfo.Privs2.Split(',');

                    if (items != null && items.Length > 0)
                    {
                        info.Privs2 = new int[items.Length];

                        for (var i = 0; i < items.Length; i++)
                        {
                            info.Privs2[i] = Utils.GetInt(items[i], -1);
                        }
                    }
                    else info.Privs2 = new int[] { -1 };

                }

                if (string.IsNullOrEmpty(zxsInfo.Privs3))
                {
                    info.Privs3 = new int[] { -1 };
                }
                else
                {
                    string[] items = zxsInfo.Privs3.Split(',');

                    if (items != null && items.Length > 0)
                    {
                        info.Privs3 = new int[items.Length];

                        for (var i = 0; i < items.Length; i++)
                        {
                            info.Privs3[i] = Utils.GetInt(items[i], -1);
                        }
                    }
                    else info.Privs3 = new int[] { -1 };

                }
            }

            return info;
        }
    }

}