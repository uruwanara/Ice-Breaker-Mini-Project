using System;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    [PXCacheName("SOParts")]
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
            , SubstituteKey = typeof(IBMPInventory.inventoryCD),
            DescriptionField = typeof(IBMPInventory.description)

          )]
        new public virtual int? Partid { get; set; }
        new public abstract class partid : PX.Data.BQL.BqlInt.Field<partid> { }
        #endregion

        //#region Available Qty
        //[PXInt]
        //[PXDefault(typeof(
        //    SelectFrom<IBMPLocationInventory>
        //         .Where<IBMPLocationInventory.inventoryID.IsIn<@P.AsInt>>
        //         .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>
        //         .View.Select(23))]
        //public virtual int? AvailableQty { get; set; }
        //#endregion

        //SelectFrom<IBMPLocationInventory>
        //         .Where<IBMPLocationInventory.inventoryID.IsIn<@P.AsInt>>
        //         .AggregateTo<GroupBy<IBMPLocationInventory.inventoryID>, Sum<IBMPLocationInventory.qtyHand>>
        //         .View.ReadOnly(this).Select(row.Partid);
    }
}
