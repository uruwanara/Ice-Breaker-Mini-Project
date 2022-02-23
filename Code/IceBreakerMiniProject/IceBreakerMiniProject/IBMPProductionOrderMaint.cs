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
        #endregion

        [PX.Api.Export.PXOptimizationBehavior(IgnoreBqlDelegate = true)]
        public virtual IEnumerable productionBom()
        {
            if (ProductionOrders.Current.Partid == null || ProductionOrders.Current.Partid==null) return null;

            var query = new SelectFrom<IBMPBOM>
                            .InnerJoin<IBMPLocationInventory>.On<IBMPLocationInventory.inventoryID.IsEqual<IBMPBOM.componentID>>
                            .Where<IBMPPOBOM.manufacPartID.IsEqual<IBMPProductionOrder.partid.FromCurrent>>
                            .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>.View.ReadOnly(this);

            using (new PXFieldScope(query.View, typeof(IBMPLocationInventory.inventoryID), typeof(IBMPLocationInventory.qtyHand)))
            {
                int startRow = PXView.StartRow;
                int totalRows = 0;

                foreach (PXResult<IBMPBOM, IBMPLocationInventory> record in
                    query.View.Select(PXView.Currents, PXView.Parameters, PXView.Searches, PXView.SortColumns,
                PXView.Descendings, PXView.Filters, ref startRow, PXView.MaximumRows, ref totalRows))
                {

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



                //select IBMPLocationInventory.InventoryID, sum(IBMPLocationInventory.QtyHand) from
                //IBMPLocationInventory where IBMPLocationInventory.InventoryID=1 
                //group by IBMPLocationInventory.InventoryID

            }
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
                if (item.Available == false)
                {
                    flag = false;
                    break;
                }

            }

            if (flag == true)
            {
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


        }
        protected void _(Events.FieldUpdating<IBMPPOBOM.totalqty> e)
        {
            e.Cancel = true;
        }

        protected void _(Events.FieldUpdated<IBMPBOM, IBMPPOBOM.totalqty> e)
        {
            IBMPInventory item = IBMPInventory.PK.Find(this, e.Row.ManufacPartID);

        }



        //protected void _(Events.FieldDefaulting<IBMPPOBOM,IBMPPOBOM.totalqty> e)
        //{
        //  //  e.Cache.SetValue<IBMPPOBOM.totalqty>(e.Row, e.Row.Qty * ProductionOrders.Current.Qty);
        //    e.NewValue = e.Row.Qty * ProductionOrders.Current.Qty;
        //}


        //#endregion




    }



}