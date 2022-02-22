using System;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;

namespace IceBreakerMiniProject
{
    [PXCacheName("Inventory")]
    public class IBMPInventory : IBqlTable
    {
        #region Keys
        public class PK : PrimaryKeyOf<IBMPInventory>.By<inventoryID>
        {
            public static IBMPInventory Find(PXGraph graph, int? inventoryID) => FindBy(graph, inventoryID);
        }
        #endregion

        #region InventoryID
        [PXDBIdentity]
        [PXUIField(DisplayName ="Inventory ID")]
        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region InventoryCD
        [PXDBString(15, IsUnicode = true, InputMask = "", IsKey =true)]
        [PXDefault]
        [PXUIField(DisplayName = "Inventory CD")]
        public virtual string InventoryCD { get; set; }
        public abstract class inventoryCD : PX.Data.BQL.BqlString.Field<inventoryCD> { }
        #endregion

        #region Description
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region Price
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Price")]
        public virtual Decimal? Price { get; set; }
        public abstract class price : PX.Data.BQL.BqlDecimal.Field<price> { }
        #endregion

        #region PartType
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Part Type")]
        public virtual string PartType { get; set; }
        public abstract class partType : PX.Data.BQL.BqlString.Field<partType> { }
        #endregion

        #region InventoryType
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Inventory Type")]
        public virtual string InventoryType { get; set; }
        public abstract class inventoryType : PX.Data.BQL.BqlString.Field<inventoryType> { }
        #endregion

        #region LineCntr
        [PXDefault(0)]
        [PXDBInt()]
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