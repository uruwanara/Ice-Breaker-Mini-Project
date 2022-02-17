using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    [PXCacheName("IBMPProductionOrderLine")]
    public class IBMPProductionOrderLine : IBqlTable
    {
        #region ProductionOrderID
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPProductionOrder.productionOrderID))]
        [PXParent(typeof(SelectFrom<IBMPProductionOrder>.Where<IBMPProductionOrder.productionOrderID.IsEqual<IBMPProductionOrderLine.productionOrderID.FromCurrent>>))]
        public virtual int? ProductionOrderID { get; set; }
        public abstract class productionOrderID : PX.Data.BQL.BqlInt.Field<productionOrderID> { }
        #endregion

        #region InventoryID
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPInventory.inventoryID))]
        [PXUIField(DisplayName = "Inventory")]
        [PXSelector(
              typeof(
                  Search<IBMPInventory.inventoryID,
                      Where<IBMPInventory.partType.IsEqual<Constant.stockItem>>>
              ),
              typeof(IBMPInventory.inventoryCD),
              typeof(IBMPInventory.price)
          , SubstituteKey = typeof(IBMPInventory.inventoryCD),
          DescriptionField = typeof(IBMPInventory.description)

          )]
        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region Qty
        [PXDBInt()]
        [PXUIField(DisplayName = "Qty")]
        public virtual int? Qty { get; set; }
        public abstract class qty : PX.Data.BQL.BqlInt.Field<qty> { }
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