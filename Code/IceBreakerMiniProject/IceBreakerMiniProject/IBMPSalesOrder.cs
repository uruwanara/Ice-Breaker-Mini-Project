using System;
using PX.Data;
using PX.Data.BQL.Fluent;
namespace IceBreakerMiniProject
{
    [PXCacheName("SalesOrder")]
    [PXPrimaryGraph(typeof(IBMPSalesOrderMaint))]
    public class IBMPSalesOrder : IBqlTable
    {
        #region SalesOrderID
        [PXDBIdentity]
        public virtual int? SalesOrderID { get; set; }
        public abstract class salesOrderID : PX.Data.BQL.BqlInt.Field<salesOrderID> { }
        #endregion

        #region SalesOrderCD
        [PXDefault]
        [PXDBString(15, IsUnicode = true, IsKey = true, InputMask = "aaaaaaa")]
        [PXUIField(DisplayName = "Sales Order")]
        [PXSelector(typeof(Search<IBMPSalesOrder.salesOrderCD>),
            typeof(IBMPSalesOrder.salesOrderCD),
            typeof(IBMPSalesOrder.status))]
        public virtual string SalesOrderCD { get; set; }
        public abstract class salesOrderCD : PX.Data.BQL.BqlString.Field<salesOrderCD> { }
        #endregion

        #region CustomerID
        [PXDBInt]
        [PXDefault(typeof(IBMPCustomer.customerID))]
        [PXUIField(DisplayName = "Customer")]
      //  [PXParent(typeof(SelectFrom<IBMPCustomer>.Where<IBMPCustomer.customerID.IsEqual<IBMPSalesOrder.customerID.FromCurrent>>))]
        [PXSelector(typeof(Search<IBMPCustomer.customerID>),
            typeof(IBMPCustomer.customerCD),
            typeof(IBMPCustomer.name),
            SubstituteKey = typeof(IBMPCustomer.customerCD),
        DescriptionField = typeof(IBMPCustomer.name))]
        public virtual int? CustomerID { get; set; }
        public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
        #endregion

        #region OrderDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Order Date")]
        public virtual DateTime? OrderDate { get; set; }
        public abstract class orderDate : PX.Data.BQL.BqlDateTime.Field<orderDate> { }
        #endregion

        #region RequiredDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Required Date")]
        public virtual DateTime? RequiredDate { get; set; }
        public abstract class requiredDate : PX.Data.BQL.BqlDateTime.Field<requiredDate> { }
        #endregion

        #region DeliveryAddress
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Delivery Address")]
        public virtual string DeliveryAddress { get; set; }
        public abstract class deliveryAddress : PX.Data.BQL.BqlString.Field<deliveryAddress> { }
        #endregion

        #region Status
        [PXDBString(15)]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region LineCntr
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = "Line Cntr")]
        public virtual int? LineCntr { get; set; }
        public abstract class lineCntr : PX.Data.BQL.BqlInt.Field<lineCntr> { }
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