using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPWarehouseMaint : PXGraph<IBMPWarehouseMaint, IBMPWarehouse>
    {

        #region Data Views
        public SelectFrom<IBMPWarehouse>.View Warehouses;
        public SelectFrom<IBMPWarehouseLocation>.Where<IBMPWarehouseLocation.warehouseID.IsEqual<IBMPWarehouse.warehouseID.FromCurrent>>.View WarehouseLocations;
        #endregion

    }
}