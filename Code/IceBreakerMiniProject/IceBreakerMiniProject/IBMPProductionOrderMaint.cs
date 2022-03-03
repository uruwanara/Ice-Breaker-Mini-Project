using System;
using System.Collections;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using System.Linq;

namespace IceBreakerMiniProject
{
    public class IBMPProductionOrderMaint : PXGraph<IBMPProductionOrderMaint, IBMPProductionOrder>
    {
        #region Views
        //Master View
        public SelectFrom<IBMPProductionOrder>.View ProductionOrders;
        //Detail View
        public SelectFrom<IBMPPOBOM>.Where<IBMPPOBOM.manufacPartID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>.View ProductionBom;
        // Get the Inventory Locations regarding a Inventory ID
        public SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>.View Locations;
        // Get the Inventory Locations regarding a Inventory ID and order by Qty on hand
        public SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>.OrderBy<IBMPLocationInventory.qtyHand.Desc>.View MaxLocation;

        public SelectFrom<IBMPLocationInventory>.InnerJoin<IBMPWarehouseLocation>.On<IBMPWarehouseLocation.locationID.IsEqual<IBMPLocationInventory.locationID>>.View Inventory;

        #region Unwanted Views
        // public SelectFrom<IBMPLocationInventorySmartPanel>.Where<IBMPLocationInventorySmartPanel.inventoryID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>.View LocationSmartPanel;
        //public PXSelect<IBMPLocationInventorySmartPanel,Where<IBMPLocationInventorySmartPanel.inventoryID,Equal<Current<IBMPProductionOrder.partid>>>> LocationSmartPanel;
        //public PXFilter<IBMPLocationInventorySmartPanel> LocationSmartPanel1;
        #endregion

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

        #region Issue Material Button and Action
        public PXAction<IBMPProductionOrder> IssueMaterial;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Issue Material", Enabled = true)]
        protected virtual void issueMaterial()
        {
            IBMPProductionOrder row = ProductionOrders.Current;

            var bomParts = ProductionBom.Select();
            var flag = true;  // This flag will be used to identyfy whether the all BOM parts are available  

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

                    PXResultset<IBMPLocationInventory> abc = MaxLocation.Select(inventory.ComponentID);

                    foreach (IBMPLocationInventory i in abc)
                    {
                        if (i.QtyHand >= tq)
                        {
                            i.QtyHand = i.QtyHand - tq;
                            i.QtyReserved = i.QtyReserved + tq;
                            MaxLocation.Cache.Update(i);
                            break;
                        }
                        else
                        {
                            tq = tq - i.QtyHand;
                            i.QtyReserved = i.QtyReserved + i.QtyHand;
                            i.QtyHand = 0;
                            MaxLocation.Cache.Update(i);
                        }
                    }
                }
                row.Status = Constant.POStatus.Reserved;
            }
            else
            {
                this.ProductionOrders.Ask(row, "Warning", "Inventory are not Enough", MessageButtons.OK);
                // if (this.ProductionOrders.Ask(row, "Warning", "Do you want to cancel", MessageButtons.YesNo) == WebDialogResult.No) return;  <-----  Dialog Box with YES NO Buttom
            }
            ProductionOrders.Update(row);
            Actions.PressSave();
        }
        #endregion


        #region Receive Shop Order
        public PXAction<IBMPProductionOrder> ReceiveShopOrders;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Receive Shop Orders", Enabled = true)]
        protected virtual void receiveShopOrders()
        {
            IBMPProductionOrder row = ProductionOrders.Current;

            IBMPLocationInventory inventory = Inventory.Current;

            inventory.QtyHand = inventory.QtyHand + row.Qty;

          //  PXUpdate<Set<IBMPLocationInventory.qtyHand,5>Where<IBMPLocationInventory.locationID,Equal<5>>>.Update
            this.ProductionOrders.Ask(row, "Warning", $"Inventory Updated! {row.Qty} items Updated", MessageButtons.OK);

            this.ProductionOrders.SetValueExt<IBMPProductionOrder.status>(row, Constant.POStatus.Closed);
            
            ProductionOrders.Cache.Update(row);
            Inventory.Update(inventory);

            Actions.PressSave();
           }

        #endregion
        #endregion

        #region Events

        #region POBOM RowSelecting Event 
        protected void _(Events.RowSelecting<IBMPPOBOM> e)
        {
            if (e.Row == null) return;

            e.Row.TotalQty = e.Row.Qty * ProductionOrders.Current.Qty;
            //e.Cache.SetValue<IBMPPOBOM.totalqty>(e.Row, e.Row.Qty * ProductionOrders.Current.Qty);
            e.Row.Available = ProductionOrders.Current.Status != Constant.POStatus.Released;

            using (new PXConnectionScope())
            {
                IBMPLocationInventory location = Locations.Select(e.Row.ComponentID);
                if (location != null && location.QtyHand >= e.Row.TotalQty)
                {
                    e.Row.Available = true;
                }
            }

        }
        #endregion


        protected void _(Events.RowUpdated<IBMPProductionOrder> e)
        {
            foreach (IBMPPOBOM item in ProductionBom.Select())
            {
                item.TotalQty = e.Row.Qty * item.Qty;
            }


            SetQtyAvailability();

        }

        #region Production Order Row Selected Event
        protected virtual void _(Events.RowSelected<IBMPProductionOrder> e)
        {
            IBMPProductionOrder row = e.Row;
            if (row == null) return;

            #region Enable/ Disable Buttons
            IssueMaterial.SetEnabled(row.Status == Constant.POStatus.Released);
            ReceiveShopOrders.SetEnabled(row.Status == Constant.POStatus.Reserved);
            #endregion

            #region Enable/ Disable Feilds
            PXUIFieldAttribute.SetEnabled<IBMPProductionOrder.qty>(ProductionOrders.Cache, null, row.Status == Constant.POStatus.Released);
            PXUIFieldAttribute.SetEnabled<IBMPProductionOrder.partid>(ProductionOrders.Cache, null, row.Status == Constant.POStatus.Released);
            PXUIFieldAttribute.SetEnabled<IBMPProductionOrder.orderDate>(ProductionOrders.Cache, null, row.Status == Constant.POStatus.Released);
            PXUIFieldAttribute.SetEnabled<IBMPProductionOrder.requiredDate>(ProductionOrders.Cache, null, row.Status == Constant.POStatus.Released);
            #endregion

            #region Enable/ Disable Tabs

            #endregion

        }
        #endregion

        #region Set Availablity of Qty
        public void SetQtyAvailability()
        {
            var componentIds = ProductionBom.Select().ToList().Select(i => (i.GetItem<IBMPPOBOM>())).Select(e => e.ComponentID).ToArray();


            var result = new SelectFrom<IBMPLocationInventory>
                            .Where<IBMPLocationInventory.inventoryID.IsIn<@P.AsInt>>
                            .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>
                            .View.ReadOnly(this).Select(componentIds)
                            .ToDictionary(item => item.GetItem<IBMPLocationInventory>().InventoryID, item => item.GetItem<IBMPLocationInventory>().QtyHand);

            foreach (IBMPPOBOM item in ProductionBom.Select())
            {
                item.Available = result.ContainsKey(item.ComponentID) && item.TotalQty <= result[item.ComponentID];
            }

        }
        #endregion

        #endregion




    }



}