using System;
using PX.Data;

namespace IceBreakerMiniProject
{
  [PXCacheName("IBMPInventoryReserved")]
  public class IBMPInventoryReserved : IBqlTable
  {
    #region OrderNbr
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Order Nbr")]
    public virtual int? OrderNbr { get; set; }
    public abstract class orderNbr : PX.Data.BQL.BqlInt.Field<orderNbr> { }
    #endregion

    #region LocationID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Location ID")]
    public virtual int? LocationID { get; set; }
    public abstract class locationID : PX.Data.BQL.BqlInt.Field<locationID> { }
    #endregion

    #region InventoryID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Inventory ID")]
    public virtual int? InventoryID { get; set; }
    public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
    #endregion

    #region OrderType
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Order Type")]
    public virtual string OrderType { get; set; }
    public abstract class orderType : PX.Data.BQL.BqlString.Field<orderType> { }
    #endregion

    #region QtyReserved
    [PXDBInt()]
    [PXUIField(DisplayName = "Qty Reserved")]
    public virtual int? QtyReserved { get; set; }
    public abstract class qtyReserved : PX.Data.BQL.BqlInt.Field<qtyReserved> { }
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