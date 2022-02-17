using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("ManufacturedItems")]
    [PXPrimaryGraph(typeof(IBMPBOMMaint))]
    public class IBMPManufacturedItems: IBMPInventory
    {
        #region InventoryCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Manufactured Product", Required = true)]
        [PXSelector(
            typeof(
                Search<IBMPInventory.inventoryCD,
                    Where<IBMPInventory.partType.IsEqual<Constant.manufacturedItem>>>
            ),
            typeof(IBMPInventory.inventoryCD)
        )]

        new public virtual string InventoryCD { get; set; }
        new public abstract class inventoryCD : PX.Data.BQL.BqlString.Field<inventoryCD> { }
        #endregion
    }
}
