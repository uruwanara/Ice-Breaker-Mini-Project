using System;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.CS;

namespace IceBreakerMiniProject
{
    [PXCacheName("Customer")]
    [PXPrimaryGraph(typeof(IBMPCustomerMaint))]
    public class IBMPCustomer : IBqlTable
    {
        #region Keys
        public class PK : PrimaryKeyOf<IBMPCustomer>.By<customerID>
        {
            public static IBMPCustomer Find(PXGraph graph, int? customerID) => FindBy(graph, customerID);
        }
        #endregion

        #region CustomerID
        [PXDBIdentity]
        public virtual int? CustomerID { get; set; }
        public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
        #endregion

        #region CustomerCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, IsKey = true, InputMask = ">aaaaaaaa")]
        [PXUIField(DisplayName = "Customer", Required = true)]
       // [AutoNumber(typeof(IBMPSetup.numberingID),typeof(IBMPCustomer.createdDateTime))]
        [PXSelector(typeof(Search<IBMPCustomer.customerCD>),
            typeof(IBMPCustomer.customerCD),
            typeof(IBMPCustomer.name))]
        public virtual string CustomerCD { get; set; }
        public abstract class customerCD : PX.Data.BQL.BqlString.Field<customerCD> { }
        #endregion

        #region Name
        [PXDBString(20, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region Address
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Address")]
        public virtual string Address { get; set; }
        public abstract class address : PX.Data.BQL.BqlString.Field<address> { }
        #endregion

        #region Contact
        [PXDBString(10, IsUnicode = true, InputMask = "000 0000000")]
        [PXUIField(DisplayName = "Contact")]
        public virtual string Contact { get; set; }
        public abstract class contact : PX.Data.BQL.BqlString.Field<contact> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion
    }
}