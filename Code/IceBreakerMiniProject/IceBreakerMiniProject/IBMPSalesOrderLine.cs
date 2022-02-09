using System;
using PX.Data;

namespace IceBreakerMiniProject
{
  [Serializable]
  [PXCacheName("IBMPSalesOrderLine")]
  public class IBMPSalesOrderLine : IBqlTable
  {
    #region SalesOrderID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Sales Order ID")]
    public virtual int? SalesOrderID { get; set; }
    public abstract class salesOrderID : PX.Data.BQL.BqlInt.Field<salesOrderID> { }
    #endregion

    #region LineNbr
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Line Nbr")]
    public virtual int? LineNbr { get; set; }
    public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
    #endregion

    #region Partid
    [PXDBInt()]
    [PXUIField(DisplayName = "Partid")]
    public virtual int? Partid { get; set; }
    public abstract class partid : PX.Data.BQL.BqlInt.Field<partid> { }
    #endregion

    #region ServiceID
    [PXDBInt()]
    [PXUIField(DisplayName = "Service ID")]
    public virtual int? ServiceID { get; set; }
    public abstract class serviceID : PX.Data.BQL.BqlInt.Field<serviceID> { }
    #endregion

    #region Qty
    [PXDBInt()]
    [PXUIField(DisplayName = "Qty")]
    public virtual int? Qty { get; set; }
    public abstract class qty : PX.Data.BQL.BqlInt.Field<qty> { }
    #endregion

    #region Price
    [PXDBDecimal()]
    [PXUIField(DisplayName = "Price")]
    public virtual Decimal? Price { get; set; }
    public abstract class price : PX.Data.BQL.BqlDecimal.Field<price> { }
    #endregion

    #region Status
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Status")]
    public virtual string Status { get; set; }
    public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
    #endregion

    #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion

    #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion

    #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion

    #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion

    #region Tstamp
    [PXDBTimestamp()]
    [PXUIField(DisplayName = "Tstamp")]
    public virtual byte[] Tstamp { get; set; }
    public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
    #endregion

    #region Noteid
    [PXNote()]
    public virtual Guid? Noteid { get; set; }
    public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
    #endregion
  }
}