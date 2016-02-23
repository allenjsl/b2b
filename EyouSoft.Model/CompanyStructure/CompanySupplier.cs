using System;
using System.Collections.Generic;

namespace EyouSoft.Model.CompanyStructure
{
    #region 供应商基本信息

    /// <summary>
    /// 供应商基本信息
    /// </summary>
    public class SupplierBasic
    {
        /// <summary>
        /// 供应商信息编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 省份编号
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 交易次数
        /// </summary>
        public int TradeNum { get; set; }
        /// <summary>
        /// 单位类型
        /// </summary>
        public EnumType.CompanyStructure.SupplierType SupplierType { get; set; }

        /// <summary>
        /// 许可证号
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        /// 合作协议
        /// </summary>
        public string AgreementFile { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string UnitAddress { get; set; }

        /// <summary>
        /// 政策
        /// </summary>
        public string UnitPolicy { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public int OperatorId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 供应商联系人
        /// </summary>
        public IList<SupplierContact> SupplierContact { get; set; }
        /// <summary>
        /// 供应商图片信息
        /// </summary>
        public IList<SupplierPic> SupplierPic { get; set; }

        /// <summary>
        /// 供应商账户信息
        /// </summary>
        public IList<SupplierBank> SupplierBank { get; set; }
        /// <summary>
        /// 附件信息集合
        /// </summary>
        public IList<CompanyFile> Annexs { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    #endregion

    #region 供应商联系人

    /// <summary>
    /// 供应商联系人
    /// </summary>
    public class SupplierContact
    {
        /// <summary>
        /// 联系人编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string ContactFax { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string Qq { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string YongHuMing { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int YongHuId { get; set; }
    }

    #endregion

    #region 供应商图片信息实体

    /// <summary>
    /// 供应商图片信息实体
    /// </summary>
    public class SupplierPic
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierId
        {
            get;
            set;
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string PicName
        {
            get;
            set;
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicPath
        {
            get;
            set;
        }
    }

    #endregion

    #region 供应商账户信息

    /// <summary>
    /// 供应商账户信息
    /// </summary>
    public class SupplierBank : CompanyAccountBase
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierId { get; set; }
    }

    #endregion

    #region 供应商地接实体

    /// <summary>
    /// 供应商地接信息
    /// </summary>
    public class SupplierLocal : SupplierBasic
    {

    }

    #endregion

    #region 供应商票务实体

    /// <summary>
    /// 供应商票务实体
    /// </summary>
    public class SupplierTicket : SupplierBasic
    {

    }

    #endregion

    #region 酒店

    #region 供应商酒店信息业务实体
    /// <summary>
    /// 供应商酒店信息业务实体
    /// </summary>
    public class SupplierHotel : SupplierBasic
    {
        /// <summary>
        /// 星级
        /// </summary>
        public EnumType.CompanyStructure.HotelStar Star { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduce { get; set; }

        /// <summary>
        /// 导游词
        /// </summary>
        public string TourGuide { get; set; }

        /// <summary>
        /// 房型信息业务实体
        /// </summary>
        public IList<SupplierHotelRoomType> RoomTypes { get; set; }
    }
    #endregion

    #region 供应商酒店房型信息业务实体
    /// <summary>
    /// 供应商酒店房型信息业务实体
    /// </summary>
    public class SupplierHotelRoomType
    {
        /// <summary>
        /// 房型编号
        /// </summary>
        public int RoomTypeId { get; set; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 前台销售价
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// 结算价
        /// </summary>
        public decimal AccountingPrice { get; set; }

        /// <summary>
        /// 是否含早
        /// </summary>
        public bool IsBreakfast { get; set; }
    }
    #endregion

    #endregion

    #region 景点

    /// <summary>
    /// 供应商景点[景点]
    /// </summary>
    public class SupplierSpot : SupplierBasic
    {
        /// <summary>
        /// 星级
        /// </summary>
        public EnumType.CompanyStructure.ScenicSpotStar Start
        {
            get;
            set;
        }
        /// <summary>
        /// 导游词
        /// </summary>
        public string TourGuide
        {
            get;
            set;
        }
        /// <summary>
        /// 团队价
        /// </summary>
        public decimal TeamPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 散客价
        /// </summary>
        public decimal TravelerPrice
        {
            get;
            set;
        }
    }


    #endregion

    #region 其他

    /// <summary>
    /// 其他供应商信息
    /// </summary>
    public class SupplierOther : SupplierBasic
    {

    }

    #endregion

    #region 供应商查询信息业务实体

    /// <summary>
    /// 供应商查询信息业务实体
    /// </summary>
    public class QuerySupplierBasic
    {
        /// <summary>
        /// 省份编号
        /// </summary>
        public int[] ProvinceId { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public int[] CityId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序方式  0\1  添加时间升\降序
        /// </summary>
        public int OrderByIndex { get; set; }
        /// <summary>
        /// 专线商编号
        /// </summary>
        public string ZxsId { get; set; }
    }

    /// <summary>
    /// 地接查询实体
    /// </summary>
    public class QuerySupplierLocal : QuerySupplierBasic
    {
        
    }

    /// <summary>
    /// 票务查询实体
    /// </summary>
    public class QuerySupplierTicket : QuerySupplierBasic
    {

    }

    /// <summary>
    /// 酒店查询实体
    /// </summary>
    public class QuerySupplierHotel : QuerySupplierBasic
    {
        /// <summary>
        /// 星级
        /// </summary>
        public EnumType.CompanyStructure.HotelStar? Star { get; set; }
    }

    /// <summary>
    /// 景点查询实体
    /// </summary>
    public class QuerySupplierSpot : QuerySupplierBasic
    {
        /// <summary>
        /// 星级
        /// </summary>
        public EnumType.CompanyStructure.ScenicSpotStar? Star { get; set; }
    }

    /// <summary>
    /// 其他查询实体
    /// </summary>
    public class QuerySupplierOther : QuerySupplierBasic
    {

    }

    #endregion
}
