using PX.Data;
using PX.Data.BQL.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBreakerMiniProject
{
    [PXCacheName("POBOM")]
    public class IBMPPOBOM : IBMPBOM
    {
        #region ManufacPartID
        [PXDBInt(IsKey = true)]
        [PXDefault(typeof(IBMPProductionOrder.partid))]
        [PXParent(typeof(
            SelectFrom<IBMPPOBOM>
                .Where<IBMPProductionOrder.partid
                    .IsEqual<IBMPBOM.manufacPartID.FromCurrent>>
        ))]
        public new virtual int? ManufacPartID { get; set; }
        public new abstract class manufacPartID : PX.Data.BQL.BqlInt.Field<manufacPartID> { }
        #endregion

        #region Total Qty
        [PXInt]
        [PXUIField(DisplayName = "Total Qty", Enabled = false)]
        [PXFormula(typeof(Default<IBMPProductionOrder.qty>))]
        public virtual int? TotalQty { get; set; }
        public abstract class totalqty : PX.Data.BQL.BqlInt.Field<totalqty> { }
        #endregion

        #region Available
        [PXBool]
        [PXUIField(DisplayName = "Availability")]
        public virtual bool? Available { get; set; }
        public abstract class available : PX.Data.BQL.BqlInt.Field<available> { }
        #endregion
    }
}
