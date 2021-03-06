using System;
using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("StockItems")]
    [PXPrimaryGraph(typeof(IBMPStockItemsMaint))]

    public class IBMPStockItems : IBMPInventory
    {
        #region InventoryCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Inventory", Required = true)]
        [PXSelector(
            typeof(
                Search<IBMPInventory.inventoryCD,
                    Where<IBMPInventory.inventoryType.IsEqual<Constant.stockItem>>>
            ),
            typeof(IBMPInventory.inventoryCD),
            typeof(IBMPInventory.price)
        )]

        new public virtual string InventoryCD { get; set; }
        new public abstract class inventoryCD : PX.Data.BQL.BqlString.Field<inventoryCD> { }
        #endregion

        #region PartType
        [PXDBString(15, IsFixed = true)]
        [PXStringList(
            new string[]
        { Constant.PartType.Manufactured ,
            Constant.PartType.Purchased
        },
            new string[]
        { Message.PartType.Manufactured,
            Message.PartType.Purchased
        })]
        [PXUIField(DisplayName = "Part Type")]
        new public virtual string PartType { get; set; }
        new public abstract class partType : PX.Data.BQL.BqlString.Field<partType> { }
        #endregion

        #region InventoryType
        [PXDefault(typeof(Constant.stockItem))]
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        new public virtual string InventoryType { get; set; }
        new public abstract class inventoryType : PX.Data.BQL.BqlString.Field<inventoryType> { }
        #endregion

    }
}
