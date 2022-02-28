using System;
using System.Collections;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPProductionOrderMaint : PXGraph<IBMPProductionOrderMaint, IBMPProductionOrder>
    {
        #region Views
        public SelectFrom<IBMPProductionOrder>.View ProductionOrders;
        public SelectFrom<IBMPPOBOM>.Where<IBMPPOBOM.manufacPartID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>.View ProductionBom;

        public SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>.View Locations;
        #endregion

        [PX.Api.Export.PXOptimizationBehavior(IgnoreBqlDelegate = true)]
        public virtual IEnumerable productionBom()
        {
            if (ProductionOrders.Current.Partid == null || ProductionOrders.Current.ProductionOrderID == null) return null;

            var query = new SelectFrom<IBMPBOM>
                            .InnerJoin<IBMPLocationInventory>.On<IBMPLocationInventory.inventoryID.IsEqual<IBMPBOM.componentID>>
                            .Where<IBMPBOM.manufacPartID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>
                            .AggregateTo<GroupBy<IBMPBOM.componentID>, GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>.View.ReadOnly(this);

            using (new PXFieldScope(query.View, typeof(IBMPLocationInventory.inventoryID), typeof(IBMPLocationInventory.qtyHand)))
            {

                int startRow = PXView.StartRow;
                int totalRows = 0;

                foreach (PXResult<IBMPBOM, IBMPLocationInventory> record in
                    query.View.Select(PXView.Currents, PXView.Parameters, PXView.Searches, PXView.SortColumns,
                PXView.Descendings, PXView.Filters, ref startRow, PXView.MaximumRows, ref totalRows))
                {
                    Locations.StoreResult((IBMPLocationInventory)record);

                }
            }

            return null;

        }


        #region Actions
        public PXAction<IBMPProductionOrder> CheckMaterials;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Check Material", Enabled = true)]
        protected virtual void checkMaterials()
        {
            var bomParts = ProductionBom.Select();

            foreach (IBMPPOBOM item in bomParts)
            {
                IBMPLocationInventory qty = SelectFrom<IBMPLocationInventory>
                    .Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>
                    .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>.View.Select(this, item.ComponentID);

                if (qty.QtyHand > item.TotalQty)
                {
                    item.Available = true;
                }

                //select IBMPLocationInventory.InventoryID, sum(IBMPLocationInventory.QtyHand) from
                //IBMPLocationInventory where IBMPLocationInventory.InventoryID=1 
                //group by IBMPLocationInventory.InventoryID

            }
            ProductionBom.Update(bomParts);
            Actions.PressSave();
        }


        public PXAction<IBMPProductionOrder> IssueMaterial;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Issue Material", Enabled = true)]
        protected virtual void issueMaterial()
        {
            IBMPProductionOrder row = ProductionOrders.Current;

            var bomParts = ProductionBom.Select();
            var flag = true;

            foreach (IBMPPOBOM item in bomParts)
            {
                if (item.Available == false || item.Available == null)
                {
                    flag = false;
                    break;
                }

            }

            if (flag == true)
            {
                foreach (IBMPPOBOM inventory in bomParts)
                {
                    int? tq = inventory.TotalQty;

                    var abc = SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>
                                             >.OrderBy<IBMPLocationInventory.qtyHand.Desc>.View.Select(this, inventory.ComponentID);
                    //qty !=0

                    foreach (IBMPLocationInventory i in abc)
                    {
                        if (i.QtyHand >= tq)
                        {
                            i.QtyHand = i.QtyHand - tq;
                            i.QtyReserved = i.QtyReserved + tq;
                            break;

                        }
                        else
                        {
                            tq = tq - i.QtyHand;
                            i.QtyReserved = i.QtyHand;
                            i.QtyHand = 0;
                        }
                        this.Caches<IBMPLocationInventory>().Update(i);
                    }


                }

                row.Status = Constant.POStatus.Reserved;
            }
            else
            {
                if (this.ProductionOrders.Ask(row, "Warning", "Do you want to cancel", MessageButtons.YesNo) == WebDialogResult.No) return;
                row.Status = Constant.POStatus.Cancelled;
            }

            ProductionOrders.Update(row);
            Actions.PressSave();
        }

        public PXAction<IBMPProductionOrder> ReceiveShopOrder;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Receive Shop Order", Enabled = true)]
        protected virtual void receiveShopOrder()
        {

        }


        #endregion

        // #region Events
        protected void _(Events.RowSelecting<IBMPPOBOM> e)
        {
            if (e.Row == null) return;

            e.Cache.SetValueExt<IBMPPOBOM.totalqty>(e.Row, e.Row.Qty * ProductionOrders.Current.Qty);
            using (new PXConnectionScope())
            {
                IBMPLocationInventory location = Locations.Select(e.Row.ComponentID);
                if (location != null && location.QtyHand >= e.Row.TotalQty)
                {
                    e.Row.Available = true;
                }
            }

        }

        protected void _(Events.RowUpdated<IBMPPOBOM> e)
        {
            if (e.Row == null) return;

            using (new PXConnectionScope())
            {
                IBMPLocationInventory location = Locations.Select(e.Row.ComponentID);
                if (location != null && location.QtyHand >= e.Row.TotalQty)
                {
                    e.Row.Available = true;
                }
            }

        }

        protected void _(Events.FieldDefaulting<IBMPPOBOM, IBMPPOBOM.totalqty> e)
        {
            //  e.Cache.SetValue<IBMPPOBOM.totalqty>(e.Row, e.Row.Qty * ProductionOrders.Current.Qty);
            e.NewValue = e.Row.Qty * ProductionOrders.Current.Qty;
        }

        protected void _(Events.RowUpdated<IBMPProductionOrder> e)
        {
            foreach (IBMPPOBOM item in ProductionBom.Select())
            {
              IBMPPOBOM newRow = PXCache<IBMPPOBOM>.CreateCopy(item);
              newRow.TotalQty = e.Row.Qty * newRow.Qty;
              ProductionBom.Cache.RaiseRowUpdated(newRow,item);
               // ProductionBom.Cache.SetValueExt<IBMPPOBOM.totalqty>(item, item.Qty * e.Row.Qty);
            }
            // this.Caches<IBMPPOBOM>().RaiseFieldSelecting(Row);

        }


        //#endregion




    }



}