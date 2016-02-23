//汪奇志 2014-09-15 平台验证码相关业务逻辑
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.PtStructure
{
    /// <summary>
    /// 平台验证码相关业务逻辑
    /// </summary>
    public class BYanZhengMa
    {
        private readonly EyouSoft.IDAL.PtStructure.IYanZhengMa dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.PtStructure.IYanZhengMa>();

        #region private members
        /// <summary>
        /// 设置验证码状态，返回1成功，其它失败
        /// </summary>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SetStatus(string yanZhengMaId, EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus status)
        {
            if (string.IsNullOrEmpty(yanZhengMaId)) return 0;

            int dalRetCode = dal.SetStatus(yanZhengMaId, status);

            return dalRetCode;
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入验证码信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.PtStructure.MYanZhengMaInfo info)
        {
            if (info == null || info.YongHuId<1 || string.IsNullOrEmpty(info.YanZhengMa)) return 0;
            info.IssueTime = DateTime.Now;
            info.YanZhengMaId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Insert(info);
            return dalRetCode;
        }

        /// <summary>
        /// 获取验证码信息
        /// </summary>
        /// <param name="yanZhengMaId">验证码编号</param>
        /// <param name="yanZhengMa">验证码</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public EyouSoft.Model.PtStructure.MYanZhengMaInfo GetInfo(string yanZhengMaId, string yanZhengMa, EyouSoft.Model.EnumType.PtStructure.YanZhengMaLeiXing leiXing)
        {
            if (string.IsNullOrEmpty(yanZhengMaId) || string.IsNullOrEmpty(yanZhengMa)) return null;

            return dal.GetInfo(yanZhengMaId, yanZhengMa, leiXing);
        }

        /// <summary>
        /// 设置验证码为已使用，返回1成功，其它失败
        /// </summary>
        /// <param name="yanZhengMaid">验证码编号</param>
        /// <returns></returns>
        public int SetYiShiYong(string yanZhengMaid)
        {
            return SetStatus(yanZhengMaid, EyouSoft.Model.EnumType.PtStructure.YanZhengMaStatus.已使用);
        }

        /// <summary>
        /// 随机生成验证码
        /// </summary>
        /// <param name="length">验证码长度（字符个数）</param>
        /// <returns></returns>
        public string CreateYanZhengMa(int length)
        {
            char[] items = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                int _index = rnd.Next(0, 10);
                s += items[_index];
            }

            return s;
        }
        #endregion
    }
}
