using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBreakerMiniProject
{
  public  class IBMPPOBOM : IBMPBOM
     {

        #region Total Qty
        [PXInt]
        [PXUIField(DisplayName = "Total Quantity")]
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
