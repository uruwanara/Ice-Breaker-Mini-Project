using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{

    public class IBMPCustomerMaint : PXGraph<IBMPCustomerMaint, IBMPCustomer>
    {

        #region View
        public SelectFrom<IBMPCustomer>.View Customers;
        #endregion

    }
}