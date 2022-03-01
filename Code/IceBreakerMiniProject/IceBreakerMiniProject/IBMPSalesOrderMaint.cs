using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPSalesOrderMaint : PXGraph<IBMPSalesOrderMaint, IBMPSalesOrder>
    {
        #region View
        public SelectFrom<IBMPSalesOrder>.View SalesOrders;

        public SelectFrom<IBMPSOParts>.InnerJoin<IBMPInventory>.On<IBMPInventory.inventoryID.IsEqual<IBMPSOParts.partid>>
            .Where<IBMPSOParts.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>.And<IBMPInventory.inventoryType.IsEqual<Constant.stockItem>>>
            .View Parts;
        public SelectFrom<IBMPSONoParts>.InnerJoin<IBMPInventory>.On<IBMPInventory.inventoryID.IsEqual<IBMPSONoParts.partid>>
            .Where<IBMPSONoParts.salesOrderID.IsEqual<IBMPSalesOrder.salesOrderID.FromCurrent>.And<IBMPInventory.inventoryType.IsEqual<Constant.nonStockItem>>>
            .View NoParts;

        #endregion

        #region Events
        /// <summary>
        /// This Event will be used to populate the Price column in the Part Tab from the inventory table
        /// </summary>
        /// <param name="e"></param>
        protected void _(Events.FieldUpdated<IBMPSOParts, IBMPSOParts.partid> e)
        {
            IBMPSOParts row = e.Row;

            if (row.Partid != null)
            {
                IBMPInventory item = IBMPInventory.PK.Find(this, row.Partid);

                e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
            }
        }

        /// <summary>
        /// This Event will be used to populate the Price column in No-Part Tab from the inventory table
        /// </summary>
        /// <param name="e"></param>
        protected void _(Events.FieldUpdated<IBMPSONoParts, IBMPSONoParts.partid> e)
        {
            IBMPSONoParts row = e.Row;

            if (row.Partid != null)
            {
                IBMPInventory item = IBMPInventory.PK.Find(this, row.Partid);

                e.Cache.SetValue<IBMPInventory.price>(row, item.Price);
            }
        }

        /// <summary>
        /// This event will be used to update the Delivery address of the sales order by setting the customers Address as the default value
        /// </summary>
        /// <param name="e"></param>
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

            #region Action Availability
            Release.SetEnabled(row.Status == Constant.SOStatus.Planned && salesOrderCacheStatus);
            Deliver.SetEnabled(row.Status == Constant.SOStatus.Released);
            CancelOrder.SetEnabled(salesOrderCacheStatus);
            CancelOrderLine.SetEnabled(row.Status == Constant.SOStatus.Released);

            PXResultset<IBMPSOParts> parts = Parts.Select();
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
            Parts.Cache.AllowSelect = salesOrderCacheStatus;
            NoParts.Cache.AllowSelect = salesOrderCacheStatus;
            #endregion
        }

        protected virtual void _(Events.RowSelected<IBMPSOParts> e)
        {
            IBMPSOParts row = e.Row;
            if (row == null) return;

            #region Action Availability
            Deliver.SetEnabled(row.Status != Constant.SOLineStatus.Delivered);
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
        [PXUIField(DisplayName = "Deliver", Enabled = true)]
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