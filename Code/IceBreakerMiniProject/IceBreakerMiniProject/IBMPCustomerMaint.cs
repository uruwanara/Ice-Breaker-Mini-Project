using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{

    public class IBMPCustomerMaint : PXGraph<IBMPCustomerMaint, IBMPCustomer>
    {

        #region View
        public SelectFrom<IBMPCustomer>.View Customers;
        #endregion

        //The view for the auto-numbering of records
        public PXSetup<IBMPSetup> AutoNumSetup;
        //The graph constructor
        public IBMPCustomerMaint()
        {
            IBMPSetup setup = AutoNumSetup.Current;
        }

    }
}