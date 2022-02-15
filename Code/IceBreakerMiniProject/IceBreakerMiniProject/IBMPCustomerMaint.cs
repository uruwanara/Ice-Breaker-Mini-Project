using System;
using PX.Data;
using PX.Data.BQL.Fluent;
namespace IceBreakerMiniProject
{
    public class IBMPCustomerMaint : PXGraph<IBMPCustomerMaint, IBMPCustomer>
    {

        new public PXSave<IBMPCustomer> Save;
        new public PXCancel<IBMPCustomer> Cancel;

        #region View
        public SelectFrom<IBMPCustomer>.View Customers;
        #endregion

        //Testing

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