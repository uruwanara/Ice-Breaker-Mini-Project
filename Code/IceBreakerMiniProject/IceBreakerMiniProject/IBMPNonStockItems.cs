using System;
using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("NonStockItems")]
    public class IBMPNonStockItems : IBMPInventory
    {

        #region Constant
        public const string nonStockItemConstant = "NONSTOCK";
        public class nonStockItem : PX.Data.BQL.BqlString.Constant<nonStockItem>
        {
            public nonStockItem()
            : base(nonStockItemConstant)
            {
            }
        }
        #endregion

        #region InventoryID
        [PXDBIdentity(IsKey = true)]
        //[PXUIField(DisplayName = "Inventory ID", Required = true)] // projections, cacheAttatched, pxMergeAttribute
        [PXSelector(
            typeof(
                Search<IBMPInventory.inventoryID,
                    Where<IBMPInventory.inventoryType.IsEqual<nonStockItem>>>
            ),
            typeof(IBMPInventory.inventoryCD),
            typeof(IBMPInventory.price),
            SubstituteKey = typeof(IBMPInventory.inventoryCD),
            DescriptionField = typeof(IBMPInventory.description)
        )]
        new public virtual int? InventoryID { get; set; }
        new public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

    }
}