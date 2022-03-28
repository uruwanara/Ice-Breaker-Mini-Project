using PX.Data;
using PX.Data.BQL.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBreakerMiniProject
{
    [PXCacheName("IBMPReceiveShopOrder")]
    public class IBMPReceiveShopOrder : IBMPLocationInventory
    {
        #region LocationID
        [PXUIField(DisplayName = "Location")]
        [PXSelector(
            typeof(Search<IBMPWarehouseLocation.locationID>),
            typeof(IBMPWarehouseLocation.locationCD),
            typeof(IBMPWarehouseLocation.description),
            SubstituteKey = typeof(IBMPWarehouseLocation.locationCD),
            DescriptionField = typeof(IBMPWarehouseLocation.description)
        )]
        public new virtual int? LocationID { get; set; }
        public new abstract class locationID : PX.Data.BQL.BqlInt.Field<locationID> { }
        #endregion

        #region InventoryID
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPInventory.inventoryID))]
        [PXUIField(DisplayName = "Inventory ID")]
        [PXParent(typeof(
            SelectFrom<IBMPProductionOrder>
                .Where<IBMPProductionOrder.partid
                    .IsEqual<IBMPLocationInventory.inventoryID.FromCurrent>>)
        )]

        public new virtual int? InventoryID { get; set; }
        public new abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region QtyHand
        [PXDBInt()]
        [PXUIField(DisplayName = "Qty Hand")]
        public virtual int? QtyHand { get; set; }
        public abstract class qtyHand : PX.Data.BQL.BqlInt.Field<qtyHand> { }
        #endregion

    }
}
