using System;
using PX.Data;
namespace IceBreakerMiniProject
{
    [PXCacheName("SOParts")]
    [PXPrimaryGraph(typeof(IBMPSalesOrderMaint))]
    public class IBMPSOParts : IBMPSalesOrderLine
    {
        #region Partid
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPInventory.inventoryID))]
        [PXUIField(DisplayName = "Inventory")]
        [PXSelector(
              typeof(
                  Search<IBMPInventory.inventoryID,
                      Where<IBMPInventory.inventoryType.IsEqual<Constant.stockItem>>>
              ),
              typeof(IBMPInventory.inventoryCD),
              typeof(IBMPInventory.price)
            //,SubstituteKey =typeof(IBMPInventory.inventoryCD),
            //DescriptionField =typeof(IBMPInventory.description)

          )]
        public virtual int? Partid { get; set; }
        public abstract class partid : PX.Data.BQL.BqlInt.Field<partid> { }
        #endregion
    }
}
