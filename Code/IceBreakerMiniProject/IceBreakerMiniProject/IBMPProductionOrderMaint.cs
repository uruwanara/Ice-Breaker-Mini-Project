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
        public SelectFrom<IBMPProductionOrder>.View ProductionOrders;
        public SelectFrom<IBMPPOBOM>.Where<IBMPPOBOM.manufacPartID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>.View ProductionBom;
        public SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>.View Locations;

        public SelectFrom<IBMPReceiveShopOrder>.Where<IBMPReceiveShopOrder.inventoryID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>.View ReceiveShopOrder;

        public SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>.OrderBy<IBMPLocationInventory.qtyHand.Desc>.View MaxLocation;

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

        #region Check Material Action - Learning Purpose
        //public PXAction<IBMPProductionOrder> CheckMaterials;
        //[PXButton(CommitChanges = true)]
        //[PXUIField(DisplayName = "Check Material", Enabled = true)]
        //protected virtual void checkMaterials()
        //{
        //    var bomParts = ProductionBom.Select();

        //    foreach (IBMPPOBOM item in bomParts)
        //    {
        //        IBMPLocationInventory qty = SelectFrom<IBMPLocationInventory>
        //            .Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>
        //            .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>.View.Select(this, item.ComponentID);

        //        if (qty.QtyHand > item.TotalQty)
        //        {
        //            item.Available = true;
        //        }

        //        //select IBMPLocationInventory.InventoryID, sum(IBMPLocationInventory.QtyHand) from
        //        //IBMPLocationInventory where IBMPLocationInventory.InventoryID=1 
        //        //group by IBMPLocationInventory.InventoryID

        //    }
        //    ProductionBom.Update(bomParts);
        //    Actions.PressSave();
        //}

        #endregion

        #region Issue Material Event 
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


                    //var abc = SelectFrom<IBMPLocationInventory>.Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>
                    //    >.OrderBy<IBMPLocationInventory.qtyHand.Desc>.View.Select(this, inventory.ComponentID);


                    PXResultset<IBMPLocationInventory> abc = MaxLocation.Select(inventory.ComponentID);

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

                        MaxLocation.Update(i);

                        // this.Caches<IBMPLocationInventory>().Update(i);  //<---- Save the iterating objects 
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

        #region Recive Shop Order Not Working
        //public PXAction<IBMPProductionOrder> ReceiveShopOrder;
        //[PXButton(CommitChanges = true)]
        //[PXUIField(DisplayName = "Receive Shop Order", Enabled = true, MapEnableRights = PXCacheRights.Delete, MapViewRights = PXCacheRights.Delete)]
        //protected virtual IEnumerable receiveShopOrder(PXAdapter adapter)
        //{
        //    if (LocationSmartPanel.AskExt() != WebDialogResult.OK)
        //    {

        //    }

        //    return adapter.Get();
        //}


        #endregion

        #region Receive Shop Order
        public PXAction<IBMPProductionOrder> ReceiveShopOrders;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Receive Shop Orders", Enabled = true)]
        protected virtual void receiveShopOrders()
        {

            IBMPProductionOrder row = ProductionOrders.Current;

            var inventory = ReceiveShopOrder.Current;

            inventory.QtyHand = inventory.QtyHand + row.Qty;
            inventory.InventoryID = row.Partid;

            ReceiveShopOrder.Update(inventory);
            this.Caches<IBMPLocationInventory>().Update(inventory);

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





        #region POBOM Row Updated Event
        protected void _(Events.RowUpdated<IBMPPOBOM> e)
        {
            if (e.Row == null) return;

            #region Updated the Product Availability
            using (new PXConnectionScope())
            {
                IBMPLocationInventory location = Locations.Select(e.Row.ComponentID);
                if (location != null && location.QtyHand >= e.Row.TotalQty)
                {
                    e.Row.Available = true;
                }
            }

            #endregion
        }
        #endregion

        #region POBOM Field Defaulding Event
        protected void _(Events.FieldDefaulting<IBMPPOBOM, IBMPPOBOM.totalqty> e)
        {
            //  e.Cache.SetValue<IBMPPOBOM.totalqty>(e.Row, e.Row.Qty * ProductionOrders.Current.Qty);
            e.NewValue = e.Row.Qty * ProductionOrders.Current.Qty;
        }

        protected void _(Events.RowUpdated<IBMPProductionOrder> e)
        {
            foreach (IBMPPOBOM item in ProductionBom.Select())
            {
                item.TotalQty = e.Row.Qty * item.Qty;
            }


            SetQtyAvailability();

        }
        #endregion

        #region Production Order Row Selected Event
        protected virtual void _(Events.RowSelected<IBMPProductionOrder> e)
        {
            IBMPProductionOrder row = e.Row;
            if (row == null) return;

            #region Update the Total Qty and check availability 
            //PXResultset<IBMPPOBOM> boms = ProductionBom.Select();

            //foreach (IBMPPOBOM part in boms)
            //{
            //    part.TotalQty = row.Qty * part.Qty;

            //    using (new PXConnectionScope())
            //    {
            //        IBMPLocationInventory location = Locations.Select(part.ComponentID);
            //        if (location != null && location.QtyHand >= part.TotalQty)
            //        {
            //            part.Available = true;
            //        }
            //        else
            //        {
            //            part.Available = false;
            //        }

            //    }
            //}

            #endregion

            #region Enable/ Disable Buttons
            IssueMaterial.SetEnabled(row.Status == Constant.POStatus.Released);
            ReceiveShopOrders.SetEnabled(row.Status == Constant.POStatus.Reserved);
            #endregion


        }
        #endregion

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




    }



}