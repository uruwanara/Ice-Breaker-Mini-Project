using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPSalesOrderMaint : PXGraph<IBMPSalesOrderMaint, IBMPSalesOrder>
    {
        #region View
        public SelectFrom<IBMPSalesOrder>.View SalesOrders;

        public SelectFrom<IBMPSOParts>
            .InnerJoin<IBMPInventory>
            .On<IBMPInventory.inventoryID.IsEqual<IBMPSOParts.partid>>
            .Where<IBMPSOParts.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>
                .And<IBMPInventory.inventoryType.IsEqual<Constant.stockItem>>>
            .View Parts;

        public SelectFrom<IBMPSONoParts>
            .InnerJoin<IBMPInventory>
            .On<IBMPInventory.inventoryID.IsEqual<IBMPSONoParts.partid>>
            .Where<IBMPSONoParts.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>
                .And<IBMPInventory.inventoryType.IsEqual<Constant.nonStockItem>>>
            .View NoParts;

        public SelectFrom<IBMPLocationInventory>
            .Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>>
            .View LocationInventory;

        public SelectFrom<IBMPLocationInventory>
            .Where<IBMPLocationInventory.inventoryID.IsEqual<@P.AsInt>
                .And<IBMPLocationInventory.locationID.IsEqual<@P.AsInt>>>
            .View LocationInventorySpecificLoc;

        public SelectFrom<IBMPInventoryReserved>.View InventoryReserved;

        public SelectFrom<IBMPInventoryReserved>
            .Where<IBMPInventoryReserved.orderNbr.IsEqual<@P.AsInt>
                .And<IBMPInventoryReserved.inventoryID.IsEqual<@P.AsInt>>
                .And<IBMPInventoryReserved.orderType.IsEqual<Constant.salesOrderType>>>
            .View InventoryReservedSalesOrders;
        #endregion

        #region Events
        protected void _(Events.FieldUpdated<IBMPSOParts, IBMPSOParts.partid> e)
        {
            IBMPSOParts row = e.Row;

            if (row.Partid != null)
            {
                IBMPInventory item = IBMPInventory.PK.Find(this, row.Partid);

                e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
            }
        }

        protected void _(Events.FieldUpdated<IBMPSONoParts, IBMPSONoParts.partid> e)
        {
            IBMPSONoParts row = e.Row;

            if (row.Partid != null)
            {
                IBMPInventory item = IBMPInventory.PK.Find(this, row.Partid);

                e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
            }
        }

        protected void _(Events.FieldUpdated<IBMPSalesOrder, IBMPSalesOrder.customerID> e)
        {
            IBMPSalesOrder row = e.Row;

            if (row.SalesOrderID != null)
            {
                IBMPCustomer customer = IBMPCustomer.PK.Find(this, row.CustomerID);
                e.Cache.SetValue<IBMPSalesOrder.deliveryAddress>(row, customer.Address);
            }
        }

        protected virtual void _(Events.RowSelected<IBMPSalesOrder> e)
        {
            IBMPSalesOrder row = e.Row;
            if (row == null) return;

            bool salesOrderCacheStatus = SalesOrders.Cache.GetStatus(row) != PXEntryStatus.Inserted;
            PXResultset<IBMPSOParts> parts = Parts.Select();

            #region Action Availability
            Release.SetEnabled(row.Status == Constant.SOStatus.Planned && salesOrderCacheStatus && parts.Count > 0);
            Deliver.SetEnabled(row.Status == Constant.SOStatus.Released);
            CancelOrder.SetEnabled(salesOrderCacheStatus);
            CancelOrderLine.SetEnabled(row.Status == Constant.SOStatus.Released);

            bool allCancelled = true;

            foreach (IBMPSOParts part in parts)
            {
                if (part.Status != Constant.SOLineStatus.Cancelled)
                {
                    allCancelled = false;
                    break;
                }
            }

            CancelOrder.SetEnabled(allCancelled && row.Status != Constant.SOStatus.Cancelled);
            #endregion

            #region Field Availability
            PXUIFieldAttribute.SetEnabled<IBMPSalesOrder.orderDate>(SalesOrders.Cache, null, row.Status == Constant.SOStatus.Planned);
            PXUIFieldAttribute.SetEnabled<IBMPSalesOrder.requiredDate>(SalesOrders.Cache, null, row.Status == Constant.SOStatus.Planned);
            PXUIFieldAttribute.SetEnabled<IBMPSalesOrder.customerID>(SalesOrders.Cache, null, row.Status == Constant.SOStatus.Planned);
            PXUIFieldAttribute.SetEnabled<IBMPSalesOrder.deliveryAddress>(SalesOrders.Cache, null, row.Status == Constant.SOStatus.Planned);
            #endregion

            #region Tab Availability
            Parts.Cache.AllowInsert = salesOrderCacheStatus && row.Status == Constant.SOStatus.Planned;
            NoParts.Cache.AllowInsert = salesOrderCacheStatus && row.Status == Constant.SOStatus.Planned;
            #endregion
        }

        protected virtual void _(Events.RowSelected<IBMPSOParts> e)
        {
            IBMPSOParts row = e.Row;
            if (row == null) return;

            #region Action Availability
            Deliver.SetEnabled(row.Status != Constant.SOLineStatus.Delivered && SalesOrders.Current.Status == Constant.SOStatus.Released);
            CancelOrderLine.SetEnabled(
                row.Status != Constant.SOLineStatus.Delivered &&
                row.Status != Constant.SOLineStatus.Cancelled
                );
            #endregion

            #region Field Availability
            PXUIFieldAttribute.SetEnabled<IBMPSOParts.qty>(Parts.Cache, null, SalesOrders.Current.Status == Constant.SOStatus.Planned);
            #endregion

        }

        protected virtual void _(Events.RowSelected<IBMPSONoParts> e)
        {
            IBMPSONoParts row = e.Row;
            if (row == null) return;

            #region Field Availability
            PXUIFieldAttribute.SetEnabled<IBMPSONoParts.qty>(Parts.Cache, null, SalesOrders.Current.Status == Constant.SOStatus.Planned);
            #endregion

        }

        protected virtual void _(Events.FieldUpdated<IBMPSOParts, IBMPSOParts.qty> e)
        {
            IBMPSOParts row = e.Row;
            if (row == null) return;

            IBMPLocationInventory currentInventoryWithQtyHandSum = new SelectFrom<IBMPLocationInventory>
                 .Where<IBMPLocationInventory.inventoryID.IsIn<@P.AsInt>>
                 .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>
                 .View.ReadOnly(this).Select(row.Partid);

            if (row.Qty > currentInventoryWithQtyHandSum.QtyHand)
            {
                this.Parts.Ask(Parts.Current, "Warning", "Not enough quantity on stocks. Maximum quantity is set", MessageButtons.OK);
                Parts.Cache.SetValueExt<IBMPSOParts.qty>(row, currentInventoryWithQtyHandSum.QtyHand);
            }
        }

        #endregion

        #region Actions
        public PXAction<IBMPSalesOrder> Release;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Release", Enabled = true)]
        protected virtual void release()
        {
            IBMPSalesOrder row = SalesOrders.Current;
            row.Status = Constant.SOStatus.Released;
            SalesOrders.Update(row);

            PXResultset<IBMPSONoParts> noParts = NoParts.Select();

            foreach (IBMPSONoParts noPart in noParts)
            {
                noPart.Status = Constant.SOLineStatus.Delivered;
                NoParts.Update(noPart);
            }

            //  update the invetory to qty reserved traversing all the sales order lines
             
            // 1. traversing all the SO lines
            PXResultset<IBMPSOParts> currentSOLines = Parts.Select();

            foreach (IBMPSOParts SOLine in currentSOLines)
            {
                // 1.1 getting all the inventory locations for inventory id
                PXResultset<IBMPLocationInventory> locationInventories = LocationInventory.Select(SOLine.Partid);

                int? qtyNeed = SOLine.Qty;
                // 1.2 traversing each inventory in order and update
                foreach (IBMPLocationInventory locationInventory in locationInventories)
                {
                    if (qtyNeed == 0) break;

                    IBMPInventoryReserved newInventoryReserved = new IBMPInventoryReserved
                    {
                        OrderNbr = row.SalesOrderID,
                        LocationID = locationInventory.LocationID,
                        InventoryID = locationInventory.InventoryID,
                        OrderType = Constant.InventoryReservedOrderType.SalesOrder
                    };

                    if (locationInventory.QtyHand >= qtyNeed)
                    {
                        newInventoryReserved.QtyReserved = qtyNeed;

                        locationInventory.QtyHand -= qtyNeed;
                        locationInventory.QtyReserved += qtyNeed;
                        LocationInventory.Cache.Update(locationInventory);

                        InventoryReserved.Cache.Insert(newInventoryReserved);

                        break;
                    }

                    newInventoryReserved.QtyReserved = locationInventory.QtyHand;

                    qtyNeed -= locationInventory.QtyHand;
                    locationInventory.QtyReserved += locationInventory.QtyHand;
                    locationInventory.QtyHand = 0;
                    LocationInventory.Cache.Update(locationInventory);

                    InventoryReserved.Cache.Insert(newInventoryReserved);
                }

            }

            Actions.PressSave();
        }

        public PXAction<IBMPSalesOrder> CancelOrder;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Cancel", Enabled = true)]
        protected virtual void cancelOrder()
        {
            IBMPSalesOrder row = SalesOrders.Current;
            row.Status = Constant.SOStatus.Cancelled;
            SalesOrders.Update(row);
            Actions.PressSave();
        }

        public PXAction<IBMPSOParts> Deliver;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Deliver", Enabled = false)]
        protected virtual void deliver()
        {
            IBMPSOParts row = Parts.Current;
            row.Status = Constant.SOLineStatus.Delivered;
            Parts.Update(row);

            PXResultset<IBMPSOParts> parts = Parts.Select();

            bool allDelivered = true;

            foreach (IBMPSOParts part in parts)
            {
                if (part.Status != Constant.SOLineStatus.Delivered)
                {
                    allDelivered = false;
                    break;
                }
            }

            if (allDelivered)
            {
                SalesOrders.Current.Status = Constant.SOStatus.Closed;
            }

            PXResultset<IBMPInventoryReserved> inventoryReservedItems = InventoryReservedSalesOrders.Select(row.SalesOrderID, row.Partid);

            foreach (IBMPInventoryReserved item in inventoryReservedItems)
            {
                IBMPLocationInventory locationInventory = LocationInventorySpecificLoc.Select(row.Partid, item.LocationID);
                locationInventory.QtyReserved -= item.QtyReserved;
                LocationInventorySpecificLoc.Cache.Update(locationInventory);
                InventoryReservedSalesOrders.Cache.Delete(item);
            }

            Actions.PressSave();
        }

        public PXAction<IBMPSOParts> CancelOrderLine;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Cancel", Enabled = true)]
        protected virtual void cancelOrderLine()
        {
            IBMPSOParts row = Parts.Current;
            row.Status = Constant.SOLineStatus.Cancelled;
            Parts.Update(row);

            Actions.PressSave();
        }

        #endregion

    }
}