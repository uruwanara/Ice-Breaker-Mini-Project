using System;
using PX.Data;

namespace IceBreakerMiniProject
{
  [Serializable]
  [PXCacheName("IBMPBOM")]
  public class IBMPBOM : IBqlTable
  {
    #region ManufacPartID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Manufac Part ID")]
    public virtual int? ManufacPartID { get; set; }
    public abstract class manufacPartID : PX.Data.BQL.BqlInt.Field<manufacPartID> { }
    #endregion

    #region ComponentID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Component ID")]
    public virtual int? ComponentID { get; set; }
    public abstract class componentID : PX.Data.BQL.BqlInt.Field<componentID> { }
    #endregion

    #region Qty
    [PXDBInt()]
    [PXUIField(DisplayName = "Qty")]
    public virtual int? Qty { get; set; }
    public abstract class qty : PX.Data.BQL.BqlInt.Field<qty> { }
    #endregion

    #region LineNbr
    [PXDBInt()]
    [PXUIField(DisplayName = "Line Nbr")]
    public virtual int? LineNbr { get; set; }
    public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
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