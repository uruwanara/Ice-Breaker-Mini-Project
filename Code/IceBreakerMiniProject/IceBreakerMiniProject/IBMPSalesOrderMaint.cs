using System;
using PX.Data;
using PX.Data.BQL.Fluent;

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

    }
}