using System;
using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("NonStockItems")]
    public class IBMPNonStockItems : IBMPInventory
    {

        #region InventoryCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Inventory", Required = true)]
        [PXSelector(
            typeof(
                Search<IBMPInventory.inventoryCD,
                    Where<IBMPInventory.inventoryType.IsEqual<Constant.nonStockItem>>>
            ),
            typeof(IBMPInventory.inventoryCD),
            typeof(IBMPInventory.price)
        )]
        new public virtual string InventoryCD { get; set; }
        new public abstract class inventoryCD : PX.Data.BQL.BqlInt.Field<inventoryCD> { }
        #endregion

        #region PartType
        [PXDefault(Constant.PartType.NoPart)]
        [PXDBString(15, IsFixed = true)]
        new public virtual string PartType { get; set; }
        new public abstract class partType : PX.Data.BQL.BqlString.Field<partType> { }
        #endregion

        #region InventoryType
        [PXDefault(typeof(Constant.nonStockItem))]
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        new public virtual string InventoryType { get; set; }
        new public abstract class inventoryType : PX.Data.BQL.BqlString.Field<inventoryType> { }
        #endregion

    }
}