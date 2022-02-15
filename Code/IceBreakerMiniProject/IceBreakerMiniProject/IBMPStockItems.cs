using System;
using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("StockItems")]
    [PXPrimaryGraph(typeof(IBMPStockItemsMaint))]

    public class IBMPStockItems : IBMPInventory
    {

        #region Constant
        public const string stockItemConstant = "STOCK";
        public class stockItem : PX.Data.BQL.BqlString.Constant<stockItem>
        {
            public stockItem()
            : base(stockItemConstant)
            {
            }
        }
        #endregion

        #region InventoryCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Inventory ID", Required = true)]
        [PXSelector(
            typeof(
                Search<IBMPInventory.inventoryCD,
                    Where<IBMPInventory.inventoryType.IsEqual<stockItem>>>
            ),
            typeof(IBMPInventory.inventoryCD),
            typeof(IBMPInventory.price)
        )]

        new public virtual string InventoryCD { get; set; }
        new public abstract class inventoryCD : PX.Data.BQL.BqlString.Field<inventoryCD> { }
        #endregion


    }
}
