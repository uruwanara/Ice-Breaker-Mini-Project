using System;
using PX.Data;

namespace IceBreakerMiniProject
{
  [Serializable]
  [PXCacheName("IBMPProductionOrder")]
  public class IBMPProductionOrder : IBqlTable
  {
    #region ProductionOrderID
    [PXDBIdentity(IsKey = true)]
    public virtual int? ProductionOrderID { get; set; }
    public abstract class productionOrderID : PX.Data.BQL.BqlInt.Field<productionOrderID> { }
    #endregion

    #region ProductionOrderCD
    [PXDBString(15, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Production Order CD")]
    public virtual string ProductionOrderCD { get; set; }
    public abstract class productionOrderCD : PX.Data.BQL.BqlString.Field<productionOrderCD> { }
    #endregion

    #region OrderDate
    [PXDBDate()]
    [PXUIField(DisplayName = "Order Date")]
    public virtual DateTime? OrderDate { get; set; }
    public abstract class orderDate : PX.Data.BQL.BqlDateTime.Field<orderDate> { }
    #endregion

    #region RequiredDate
    [PXDBDate()]
    [PXUIField(DisplayName = "Required Date")]
    public virtual DateTime? RequiredDate { get; set; }
    public abstract class requiredDate : PX.Data.BQL.BqlDateTime.Field<requiredDate> { }
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