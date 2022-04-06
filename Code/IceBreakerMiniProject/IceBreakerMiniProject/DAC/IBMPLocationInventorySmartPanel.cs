using PX.Data;
using PX.Data.BQL.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBreakerMiniProject
{
    [PXCacheName("LocationInventorySmartPanel")]
    public class IBMPLocationInventorySmartPanel : IBqlTable
    {
        #region LocationID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Location")]
        [PXDBDefault(typeof(IBMPWarehouseLocation.locationID))]
        [PXSelector(typeof(Search<IBMPWarehouseLocation.locationID>),
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
        [PXParent(typeof(SelectFrom<IBMPProductionOrder>.Where<IBMPProductionOrder.partid.IsEqual<IBMPLocationInventorySmartPanel.inventoryID.FromCurrent>>))]

        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion
    }
}
