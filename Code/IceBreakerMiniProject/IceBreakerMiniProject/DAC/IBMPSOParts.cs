using System;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

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
                      Where<IBMPInventory.inventoryType
                          .IsEqual<Constant.stockItem>>>
              ),
              typeof(IBMPInventory.inventoryCD),
              typeof(IBMPInventory.price),
              SubstituteKey = typeof(IBMPInventory.inventoryCD),
              DescriptionField = typeof(IBMPInventory.description)
        )]
        new public virtual int? Partid { get; set; }
        new public abstract class partid : PX.Data.BQL.BqlInt.Field<partid> { }
        #endregion

        public new abstract class salesOrderID : PX.Data.BQL.BqlInt.Field<salesOrderID> { }

        public new abstract class qty : PX.Data.BQL.BqlInt.Field<qty> { }
    }
}
