using System;
using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("Warehouse")]
    [PXPrimaryGraph(typeof(IBMPWarehouseMaint))]
    public class IBMPWarehouse : IBqlTable
    {
        #region WarehouseID
        [PXDBIdentity]
        public virtual int? WarehouseID { get; set; }
        public abstract class warehouseID : PX.Data.BQL.BqlInt.Field<warehouseID> {}
        #endregion

        #region WarehouseCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, IsKey =true, InputMask = ">aaaaaaaaaaaaaaa")]
        [PXUIField(DisplayName = "Warehouse")]
        [PXSelector(typeof(Search<IBMPWarehouse.warehouseCD>),
        typeof(IBMPWarehouse.warehouseCD),
        typeof(IBMPWarehouse.name))]
        public virtual string WarehouseCD { get; set; }
        public abstract class warehouseCD : PX.Data.BQL.BqlString.Field<warehouseCD> { }
        #endregion

    #region Name
    [PXDBString(50, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Name")]
    public virtual string Name { get; set; }
    public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
    #endregion

    #region LocationLineCntr
    [PXDBInt()]
    [PXDefault(0)]
    [PXUIField(DisplayName = "Location Line Cntr")]
    public virtual int? LocationLineCntr { get; set; }
    public abstract class locationLineCntr : PX.Data.BQL.BqlInt.Field<locationLineCntr> { }
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