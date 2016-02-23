using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.TourStructure
{
    public class BBianGeng : BLLBase
    {
        private readonly EyouSoft.IDAL.TourStructure.IBianGeng dal = EyouSoft.Component.Factory.ComponentFactory.CreateDAL<EyouSoft.IDAL.TourStructure.IBianGeng>();

        #region IBianGeng 成员
        /// <summary>
        /// 添加变更信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertBianGeng(EyouSoft.Model.TourStructure.MBianGeng model)
        {
            if (string.IsNullOrEmpty(model.BianId) || !model.BianType.HasValue || model.OperatorId == 0)
            {
                return false;
            }
            return dal.InsertBianGeng(model);
        }


        /// <summary>
        /// 获取变更信息
        /// </summary>
        /// <param name="bianId"></param>
        /// <param name="bianType"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.TourStructure.MBianGeng> GetBianGengList(string bianId, EyouSoft.Model.EnumType.TourStructure.BianType? bianType)
        {
            if (string.IsNullOrEmpty(bianId) || !bianType.HasValue) return null;
            return dal.GetBianGengList(bianId, bianType);
        }

        #endregion

    }
}
