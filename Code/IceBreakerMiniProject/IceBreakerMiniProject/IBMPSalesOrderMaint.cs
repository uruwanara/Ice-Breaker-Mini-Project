using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPSalesOrderMaint : PXGraph<IBMPSalesOrderMaint, IBMPSalesOrder>
    {

      //  public PXSave<IBMPSalesOrder> Save;
       // public PXCancel<IBMPSalesOrder> Cancel;

        #region View
        public SelectFrom<IBMPSalesOrder>.View SalesOrders;
        public SelectFrom<IBMPSalesOrderLine>.Where<IBMPSalesOrderLine.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>>.View SalesOrderLines;
        #endregion

    }
}