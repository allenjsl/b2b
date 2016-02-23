using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.TongJiStructure
{
    #region 统计分析-旅行社人头统计信息业务实体
    /// <summary>
    /// 统计分析-旅行社人头统计信息业务实体
    /// </summary>
    public class MLxsRenTouInfo
    {
        MLxsRenTouRenShuInfo _m1 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m2 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m3 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m4 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m5 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m6 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m7 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m8 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m9 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m10 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m11 = new MLxsRenTouRenShuInfo();
        MLxsRenTouRenShuInfo _m12 = new MLxsRenTouRenShuInfo();

        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 1月
        /// </summary>
        public MLxsRenTouRenShuInfo M1 { get { return _m1; } set { _m1 = value; } }
        /// <summary>
        /// 2月
        /// </summary>
        public MLxsRenTouRenShuInfo M2 { get { return _m2; } set { _m2 = value; } }
        /// <summary>
        /// 3月
        /// </summary>
        public MLxsRenTouRenShuInfo M3 { get { return _m3; } set { _m3 = value; } }
        /// <summary>
        /// 4月
        /// </summary>
        public MLxsRenTouRenShuInfo M4 { get { return _m4; } set { _m4 = value; } }
        /// <summary>
        /// 5月
        /// </summary>
        public MLxsRenTouRenShuInfo M5 { get { return _m5; } set { _m5 = value; } }
        /// <summary>
        /// 6月
        /// </summary>
        public MLxsRenTouRenShuInfo M6 { get { return _m6; } set { _m6 = value; } }
        /// <summary>
        /// 7月
        /// </summary>
        public MLxsRenTouRenShuInfo M7 { get { return _m7; } set { _m7 = value; } }
        /// <summary>
        /// 8月
        /// </summary>
        public MLxsRenTouRenShuInfo M8 { get { return _m8; } set { _m8 = value; } }
        /// <summary>
        /// 9月
        /// </summary>
        public MLxsRenTouRenShuInfo M9 { get { return _m9; } set { _m9 = value; } }
        /// <summary>
        /// 10月
        /// </summary>
        public MLxsRenTouRenShuInfo M10 { get { return _m10; } set { _m10 = value; } }
        /// <summary>
        /// 11月
        /// </summary>
        public MLxsRenTouRenShuInfo M11 { get { return _m11; } set { _m11 = value; } }
        /// <summary>
        /// 12月
        /// </summary>
        public MLxsRenTouRenShuInfo M12 { get { return _m12; } set { _m12 = value; } }
    }
    #endregion

    #region 统计分析-旅行社人头统计查询信息业务实体
    /// <summary>
    /// 统计分析-旅行社人头统计查询信息业务实体
    /// </summary>
    public class MLxsRenTourChaXunInfo
    {

    }
    #endregion

    #region 统计分析-旅行社人头统计人数信息业务实体
    /// <summary>
    /// 统计分析-旅行社人头统计人数信息业务实体
    /// </summary>
    public class MLxsRenTouRenShuInfo
    {
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRen { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTong { get; set; }
        /// <summary>
        /// 全陪数
        /// </summary>
        public int QuanPei { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int YingEr { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int MM { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int YYYY { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
    }
    #endregion

    #region 统计分析-旅行社人头统计明细信息业务实体
    /// <summary>
    /// 统计分析-旅行社人头统计明细信息业务实体
    /// </summary>
    public class MLxsRenTouXXInfo
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string KeHuId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string keHuName { get; set; }
        /// <summary>
        /// 订单明细信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> DingDans { get; set; }
        /// <summary>
        /// 常规旅游-订单信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> T0 { get { return GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType.常规旅游); } }
        /// <summary>
        /// 单订票-订单信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> T1 { get { return GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType.单订票); } }
        /// <summary>
        /// 票务酒店-订单信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> T2 { get { return GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType.票务酒店); } }
        /// <summary>
        /// 代订酒店-订单信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> T3 { get { return GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType.代订酒店); } }
        /// <summary>
        /// 私人订制(原特殊旅游)-订单信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> T4 { get { return GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType.私人订制); } }
        /// <summary>
        /// 自由行-订单信息集合
        /// </summary>
        public IList<MLxsRenTouXXOrderInfo> T5 { get { return GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType.自由行); } }
        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="yeWuLeiXing"></param>
        /// <returns></returns>
        IList<MLxsRenTouXXOrderInfo> GetDingDans(EyouSoft.Model.EnumType.TourStructure.BusinessType yeWuLeiXing)
        {
            if (DingDans == null || DingDans.Count == 0) return null;

            return DingDans.Where(i => i.YeWuLeiXing == yeWuLeiXing).ToList();
        }
    }
    #endregion

    #region 统计分析-旅行社人头统计明细查询信息业务实体
    /// <summary>
    /// 统计分析-旅行社人头统计明细查询信息业务实体
    /// </summary>
    public class MLxsRenTouXXChaXunInfo
    {
        /// <summary>
        /// 地区
        /// </summary>
        public EyouSoft.Model.EnumType.CompanyStructure.ChengShiDiQu DiQu { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int YYYY { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int MM { get; set; }
    }
    #endregion

    #region 统计分析-旅行社人头统计明细订单信息业务实体
    /// <summary>
    /// 统计分析-旅行社人头统计明细订单信息业务实体
    /// </summary>
    public class MLxsRenTouXXOrderInfo
    {
        /// <summary>
        /// 业务类型
        /// </summary>
        public EyouSoft.Model.EnumType.TourStructure.BusinessType YeWuLeiXing { get; set; }
        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime QuDate { get; set; }
        string _RouteName = string.Empty;
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName
        {
            get
            {
                if (string.IsNullOrEmpty(_RouteName)) return YeWuLeiXing.ToString();

                return _RouteName;
            }
            set { _RouteName = value; }
        }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRen { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTong { get; set; }
        /// <summary>
        /// 全部数
        /// </summary>
        public int QuanPei { get; set; }
        /// <summary>
        /// 对方操作人姓名
        /// </summary>
        public string DuiFangCaoZuoRenName { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        public int YingEr { get; set; }
    }
    #endregion
}
