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

        //protected void _(Events.FieldUpdated<IBMPSOParts, IBMPSOParts.partid> e)
        //{
        //    IBMPSOParts row = e.Row;

        //    if (row.Partid != null)
        //    {
        //        Console.WriteLine("GFNBJNBFJSNFjs");
        //        IBMPInventory item = IBMPInventory.PK.Find(this, row.Partid);

        //        e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
        //    }
        //}
        //#endregion
    }
}