using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("ManufacturedItems")]
    [PXPrimaryGraph(typeof(IBMPBOMMaint))]
    //[PXBreakInheritance]
    public class IBMPManufacturedItems : IBMPInventory
    {
        #region InventoryCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Manufactured Products", Required = true)]
        [PXSelector(
            typeof(
                Search<IBMPInventory.inventoryCD,
                    Where<IBMPInventory.partType.IsEqual<Constant.manufacturedItem>>>
            ),
            typeof(IBMPInventory.inventoryCD),
            typeof(IBMPInventory.description)
        )]

        public new virtual string InventoryCD { get; set; }
        public new abstract class inventoryCD : PX.Data.BQL.BqlString.Field<inventoryCD> { }
        #endregion
    }
}
