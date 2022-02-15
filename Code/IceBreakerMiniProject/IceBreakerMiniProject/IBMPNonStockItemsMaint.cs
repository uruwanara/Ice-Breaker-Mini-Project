using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPNonStockItemsMaint : PXGraph<IBMPNonStockItemsMaint, IBMPNonStockItems>
    {

        new public PXSave<IBMPNonStockItems> Save;
        new public PXCancel<IBMPNonStockItems> Cancel;

        #region Data Views
        public SelectFrom<IBMPNonStockItems>.View NonStockItems;
        #endregion

    }
}