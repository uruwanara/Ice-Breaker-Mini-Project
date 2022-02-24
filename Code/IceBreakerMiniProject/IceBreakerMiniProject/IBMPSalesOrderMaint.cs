using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;
using System.Linq;
using PX.Objects.CT;
using PX.Objects.CN.CacheExtensions;

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

            Release.SetEnabled(row.Status == Constant.SOStatus.Planned);
            Deliver.SetEnabled(row.Status == Constant.SOStatus.Released);

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
            Actions.PressSave();
        }
        #endregion


    }
}