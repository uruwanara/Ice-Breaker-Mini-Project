using System;
using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("IBMPProductionOrder")]
    [PXPrimaryGraph(typeof(IBMPProductionOrderMaint))]
    public class IBMPProductionOrder : IBqlTable
    {
        #region ProductionOrderID
        [PXDBIdentity]
        public virtual int? ProductionOrderID { get; set; }
        public abstract class productionOrderID : PX.Data.BQL.BqlInt.Field<productionOrderID> { }
        #endregion

        #region ProductionOrderCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, IsKey = true, InputMask = ">aaaaaaaa")]
        [PXUIField(DisplayName = "Production Order")]
        [PXSelector(typeof(Search<IBMPProductionOrder.productionOrderCD>),
        typeof(IBMPProductionOrder.productionOrderCD),
        typeof(IBMPProductionOrder.status))]
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

        #region Partid
        [PXDBInt]
        [PXDefault(typeof(IBMPInventory.inventoryID))]
        [PXUIField(DisplayName = "Manufactured Product")]
        [PXSelector(
              typeof(
                  Search<IBMPManufacturedItems.inventoryID,
                      Where<IBMPManufacturedItems.partType
                          .IsEqual<Constant.manufacturedItem>>>
              ),
              typeof(IBMPManufacturedItems.inventoryCD),
              typeof(IBMPManufacturedItems.price),
              SubstituteKey = typeof(IBMPManufacturedItems.inventoryCD),
              DescriptionField = typeof(IBMPManufacturedItems.description)
          )]
        public virtual int? Partid { get; set; }
        public abstract class partid : PX.Data.BQL.BqlInt.Field<partid> { }
        #endregion

        #region Qty
        [PXDBInt]
        [PXDefault(0)]
        [PXUIField(DisplayName = "Quantity")]
        public virtual int? Qty { get; set; }
        public abstract class qty : PX.Data.BQL.BqlInt.Field<qty> { }
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