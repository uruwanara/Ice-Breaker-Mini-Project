using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;
using System.Linq;
using PX.Objects.CT;
using PX.Objects.CN.CacheExtensions;

namespace IceBreakerMiniProject
{
    public class IBMPSalesOrderMaint : PXGraph<IBMPSalesOrderMaint, IBMPSalesOrder>
    {
        #region View
        public SelectFrom<IBMPSalesOrder>.View SalesOrders;

        public SelectFrom<IBMPSOParts>.Where<IBMPSOParts.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>>.View Parts;
        public SelectFrom<IBMPSONoParts>.Where<IBMPSONoParts.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>>.View NoParts;

        //public SelectFrom<IBMPSalesOrderLine>.
        //    InnerJoin<IBMPNonStockItems>.On<IBMPSalesOrderLine.partid.IsEqual<IBMPNonStockItems.inventoryID>>.
        //    Where<IBMPSalesOrderLine.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>.
        //    And<IBMPNonStockItems.inventoryType.IsEqual<Constant.nonStockItem>>>.View NoParts;
        #endregion

        #region Events

        protected void _(Events.FieldUpdated<IBMPSOParts, IBMPSOParts.partid> e)
        {
            IBMPSOParts row = e.Row;

            if (row.Partid != null)
            {
                Console.WriteLine("GFNBJNBFJSNFjs");
                IBMPInventory item = IBMPInventory.PK.Find(this, row.Partid);

                e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
            }
        }
        #endregion



    }
}