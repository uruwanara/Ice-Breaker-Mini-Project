using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.ReferentialIntegrity.Attributes;

namespace IceBreakerMiniProject
{

    [PXCacheName("IBMPLocationInventory")]
    public class IBMPLocationInventory : IBqlTable
    {
        #region Keys
        public class PK : PrimaryKeyOf<IBMPLocationInventory>.By<locationID>
        {
            public static IBMPLocationInventory Find(PXGraph graph, int? locationID) => FindBy(graph, locationID);
        }
        #endregion

        #region LocationID
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPWarehouseLocation.locationID))]
        [PXUIField(DisplayName = "Location")]
        [PXSelector(
            typeof(Search<IBMPWarehouseLocation.locationID>),
            typeof(IBMPWarehouseLocation.locationCD),
            typeof(IBMPWarehouseLocation.description),
            SubstituteKey = typeof(IBMPWarehouseLocation.locationCD),
            DescriptionField = typeof(IBMPWarehouseLocation.description))]
        public virtual int? LocationID { get; set; }
        public abstract class locationID : PX.Data.BQL.BqlInt.Field<locationID> { }
        #endregion

        #region InventoryID
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPInventory.inventoryID))]
        [PXUIField(DisplayName = "Inventory ID")]
        [PXParent(typeof(
            SelectFrom<IBMPStockItems>
                .Where<IBMPStockItems.inventoryID
                    .IsEqual<IBMPLocationInventory.inventoryID.FromCurrent>>
        ))]

        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region QtyHand
        [PXDBInt()]
        [PXUIField(DisplayName = "Qty Hand")]
        [PXDefault(TypeCode.Int32, "0", PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual int? QtyHand { get; set; }
        public abstract class qtyHand : PX.Data.BQL.BqlInt.Field<qtyHand> { }
        #endregion

        #region QtyReserved
        [PXDBInt()]
        [PXUIField(DisplayName = "Qty Reserved")]
        [PXDefault(TypeCode.Int32, "0", PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual int? QtyReserved { get; set; }
        public abstract class qtyReserved : PX.Data.BQL.BqlInt.Field<qtyReserved> { }
        #endregion

        #region Sytem Fields

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

        #endregion

    }
}