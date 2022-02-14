using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
  public class IBMPProductionOrderMaint : PXGraph<IBMPProductionOrderMaint,IBMPProductionOrder>
  {
        #region Views
        public SelectFrom<IBMPProductionOrder>.View ProductionOrders;
        public SelectFrom<IBMPProductionOrderLine>.Where<IBMPProductionOrderLine.productionOrderID.IsEqual<IBMPProductionOrder.productionOrderID.FromCurrent>>.View ProductionOrderLines;
        #endregion
    }
}