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

        #region Events

        /// <summary>
        /// Validate the Warehouse location's CDs by preventing having Same CD in purticular Warehouse
        /// </summary>
        /// <param name="e"></param> 
        protected void _(Events.FieldUpdated<IBMPWarehouseLocation, IBMPWarehouseLocation.locationCD> e)
        {
            IBMPWarehouseLocation row = e.Row;

            if (row == null) return;

            var allRows = WarehouseLocations.Select();

            foreach (IBMPWarehouseLocation item in allRows)
            {
                if (item.LocationCD == row.LocationCD)
                {
                    this.WarehouseLocations.Ask(WarehouseLocations.Current, "Warning", "Duplicated Warehouse Location added!", MessageButtons.OK);
                    e.Cache.Remove(row.LocationCD);
                    break;
                }
            }
        }
        #endregion

    }
}