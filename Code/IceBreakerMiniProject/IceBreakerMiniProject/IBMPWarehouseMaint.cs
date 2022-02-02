using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
  public class IBMPWarehouseMaint : PXGraph<IBMPWarehouseMaint,IBMPWarehouse>
  {

    public PXSave<MasterTable> Save;
    public PXCancel<MasterTable> Cancel;

        #region Data Views
        public SelectFrom<IBMPWarehouse>.View Warehouses;
        #endregion

        public PXFilter<MasterTable> MasterView;
    public PXFilter<DetailsTable> DetailsView;

    [Serializable]
    public class MasterTable : IBqlTable
    {

    }

    [Serializable]
    public class DetailsTable : IBqlTable
    {

    }


  }
}