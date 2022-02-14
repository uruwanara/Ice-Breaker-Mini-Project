using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPWarehouseMaint : PXGraph<IBMPWarehouseMaint, IBMPWarehouse>
    {
       // public PXSave<IBMPWarehouse> Save;
       //public PXCancel<IBMPWarehouse> Cancel;

        #region Data Views
        public SelectFrom<IBMPWarehouse>.View Warehouses;
        public SelectFrom<IBMPWarehouseLocation>.Where<IBMPWarehouseLocation.warehouseID.IsEqual<IBMPWarehouse.warehouseID.FromCurrent>>.View WarehouseLocations;
        #endregion

        /*
 public PXFilter<MasterTable> MasterView;
 public PXFilter<DetailsTable> DetailsView;

 [Serializable]
 public class MasterTable : IBqlTable
 {
     //Testing 123
 }

 [Serializable]
 public class DetailsTable : IBqlTable
 {

 }
    */

    }
}