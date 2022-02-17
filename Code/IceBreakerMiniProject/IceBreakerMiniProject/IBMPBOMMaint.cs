using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPBOMMaint : PXGraph<IBMPBOMMaint, IBMPManufacturedItems>
    {

        public PXSave<IBMPBOM> Save;
        public PXCancel<IBMPBOM> Cancel;

        #region Data Views
        public SelectFrom<IBMPManufacturedItems>.View ManufacturedProducts;

        public SelectFrom<IBMPBOM>
            .InnerJoin<IBMPInventory>
            .On<IBMPBOM.manufacPartID.IsEqual<IBMPInventory.inventoryID>>
            .Where<IBMPInventory.inventoryID.IsEqual<IBMPManufacturedItems.inventoryID.FromCurrent>>
            .View Components;
        #endregion

    }
}