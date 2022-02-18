using System;
using PX.Data;
namespace IceBreakerMiniProject
{
    [PXCacheName("SONoParts")]
    public class IBMPSONoParts : IBMPSalesOrderLine
    {
        #region Partid
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPInventory.inventoryID))]
        [PXUIField(DisplayName = "Inventory")]
        [PXSelector(
              typeof(
                  Search<IBMPInventory.inventoryID,
                      Where<IBMPInventory.inventoryType.IsEqual<Constant.nonStockItem>>>
              ),
              typeof(IBMPInventory.inventoryCD),
              typeof(IBMPInventory.price),
          SubstituteKey = typeof(IBMPInventory.inventoryCD),
          DescriptionField = typeof(IBMPInventory.description)

          )]
        public new virtual int? Partid { get; set; }
        public new abstract class partid : PX.Data.BQL.BqlInt.Field<partid> { }
        #endregion
    }
}
