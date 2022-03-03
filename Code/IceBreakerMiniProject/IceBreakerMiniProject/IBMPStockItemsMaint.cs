using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPStockItemsMaint : PXGraph<IBMPStockItemsMaint, IBMPStockItems>
    {

        new public PXSave<IBMPStockItems> Save;
        new public PXCancel<IBMPStockItems> Cancel;

        #region Data Views
        public SelectFrom<IBMPStockItems>.View StockItems;

        public SelectFrom<IBMPLocationInventory>
           .InnerJoin<IBMPWarehouseLocation>
               .On<IBMPLocationInventory.locationID.IsEqual<IBMPWarehouseLocation.locationID>>
           .Where<IBMPLocationInventory.inventoryID.IsEqual<IBMPStockItems.inventoryID.FromCurrent>>
           .View InventoryLocations;

        #endregion





    }
}