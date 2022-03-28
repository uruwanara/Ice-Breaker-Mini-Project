using PX.Data;
using PX.Data.BQL.Fluent;

namespace IceBreakerMiniProject
{
    public class IBMPSalesOrderInq : PXGraph<IBMPSalesOrderInq>
    {
        public SelectFrom<IBMPSalesOrder>.View.ReadOnly SalesOrderView;
    }
}