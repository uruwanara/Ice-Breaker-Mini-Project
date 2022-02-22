using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPProductionOrderMaint : PXGraph<IBMPProductionOrderMaint, IBMPProductionOrder>
    {
        #region Views
        public SelectFrom<IBMPProductionOrder>.View ProductionOrders;
        public SelectFrom<IBMPPOBOM>
            .Where<IBMPPOBOM.manufacPartID
                .IsEqual<IBMPProductionOrder.partid.FromCurrent>>
            .View ProductionBom;
        #endregion

        //#region Events
        //protected void _(Events.FieldUpdated<IBMPPOBOM, IBMPPOBOM.componentID> e)
        //{
        //    IBMPPOBOM row = e.Row;

        //    if (row.ComponentID != null)
        //    {
        //        IBMPInventory item = IBMPInventory.PK.Find(this, row.ComponentID);

        //        e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
        //    }
        //}
        //#endregion
    }
}