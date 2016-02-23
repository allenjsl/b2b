using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.CompanyStructure
{
    /// <summary>
    /// 公司常用城市数据层接口
    /// </summary>
    public interface ICity
    {
        /// <summary>
        /// 验证城市名是否已经存在
        /// </summary>
        /// <param name="cityName">城市名称</param>
        /// <param name="companyId">公司编号</param>
        /// <param name="cityId">城市编号</param>
        /// <returns>true:已存在 false:不存在</returns>
        bool IsExists(string cityName, int companyId, int cityId);
        /// <summary>
        /// 添加城市
        /// </summary>
        /// <param name="model">城市实体</param>
        /// <returns>true:成功 false:失败</returns>
        bool Add(Model.CompanyStructure.City model);
        /// <summary>
        /// 修改城市
        /// </summary>
        /// <param name="model">城市实体</param>
        /// <returns>true:成功 false:失败</returns>
        bool Update(Model.CompanyStructure.City model);
        /// <summary>
        /// 获取城市实体
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        Model.CompanyStructure.City GetModel(int id);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">城市编号</param>
        /// <returns>true:成功 false:失败</returns>
        bool Delete(int id);

        /// <summary>
        /// 设置常用城市，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="zxsId">专线商编号</param>
        /// <param name="chengShiId">城市编号</param>
        /// <returns></returns>
        int SheZhiChangYongChengShi(int companyId, string zxsId, int chengShiId);

        /// <summary>
        /// 获取省份信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MShengFenInfo> GetShengFens(int companyId, EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo chaXun);
        /// <summary>
        /// 获取城市信息集合
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.CompanyStructure.MChengShiInfo> GetChengShis(int companyId, EyouSoft.Model.CompanyStructure.MShengFenChengShiChaXunInfo chaXun);
        /// <summary>
        /// 设置城市类型，返回1成功，其它失败
        /// </summary>
        /// <param name="companyId">公司编号</param>
        /// <param name="chengShiId">城市编号</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        int SheZhiLeiXing(int companyId, int chengShiId, EyouSoft.Model.EnumType.CompanyStructure.ChengShiLeiXing leiXing);
    }
}
