using System;
using PX.Data;

namespace IceBreakerMiniProject
{
  [Serializable]
  [PXCacheName("IBMPWarehouseLocation")]
  public class IBMPWarehouseLocation : IBqlTable
  {
    #region LocationID
    [PXDBIdentity]
    public virtual int? LocationID { get; set; }
    public abstract class locationID : PX.Data.BQL.BqlInt.Field<locationID> { }
    #endregion

    #region WarehouseID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Warehouse ID")]
    public virtual int? WarehouseID { get; set; }
    public abstract class warehouseID : PX.Data.BQL.BqlInt.Field<warehouseID> { }
    #endregion

    #region LocationCD
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Location CD")]
    public virtual string LocationCD { get; set; }
    public abstract class locationCD : PX.Data.BQL.BqlString.Field<locationCD> { }
    #endregion

    #region Description
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
    #endregion

    #region LineNbr
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Line Nbr")]
    public virtual int? LineNbr { get; set; }
    public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
    #endregion

    #region Address
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Address")]
    public virtual string Address { get; set; }
    public abstract class address : PX.Data.BQL.BqlString.Field<address> { }
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