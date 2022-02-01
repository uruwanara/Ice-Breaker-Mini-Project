using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
  public class IBWarehouseMaint : PXGraph<IBWarehouseMaint>
  {

    public PXSave<MasterTable> Save;
    public PXCancel<MasterTable> Cancel;


    public PXFilter<MasterTable> MasterView;
    public PXFilter<DetailsTable> DetailsView;

        #region Data Views
        public SelectFrom<IBWarehouse>.View Warehouses;
        #endregion

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