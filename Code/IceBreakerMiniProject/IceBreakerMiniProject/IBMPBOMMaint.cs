using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPBOMMaint : PXGraph<IBMPBOMMaint, IBMPManufacturedItems>
    {
        #region Data Views
        public SelectFrom<IBMPManufacturedItems>.View ManufacturedProducts;
        public SelectFrom<IBMPBOM>.Where<IBMPBOM.manufacPartID.IsEqual<IBMPManufacturedItems.inventoryID.FromCurrent>>.View Components;

        #endregion

    }
}