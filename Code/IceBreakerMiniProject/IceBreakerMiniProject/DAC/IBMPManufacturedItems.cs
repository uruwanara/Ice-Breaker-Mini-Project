using PX.Data;

namespace IceBreakerMiniProject
{
    [PXCacheName("ManufacturedItems")]
    [PXPrimaryGraph(typeof(IBMPBOMMaint))]
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

        public new abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }

        public new abstract class description : PX.Data.BQL.BqlString.Field<description> { }

        public new abstract class partType : PX.Data.BQL.BqlString.Field<partType> { }

    }
}
