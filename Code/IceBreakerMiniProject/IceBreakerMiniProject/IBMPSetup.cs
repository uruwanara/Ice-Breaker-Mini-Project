﻿//using PX.Data;
//using PX.Objects.CS;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IceBreakerMiniProject
//{
//    [PXCacheName("Customer Setup")]
//    [PXPrimaryGraph(typeof(IBMPCustomerMaint))]
//    public class IBMPSetup : IBqlTable
//    {
//        #region NumberingID
//        [PXDBString(10, IsUnicode = true)]
//        [PXDefault("CUSTOMER")]
//        [PXUIField(DisplayName = "Numbering Sequence")]
//        [PXSelector(typeof(Numbering.numberingID),
//                    DescriptionField = typeof(Numbering.descr))]
//        public virtual string NumberingID { get; set; }
//        public abstract class numberingID : PX.Data.BQL.BqlString.Field<numberingID> { }
//        #endregion

//        #region CreatedByID
//        [PXDBCreatedByID()]
//		public virtual Guid? CreatedByID { get; set; }
//		public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
//		#endregion

//		#region CreatedByScreenID
//		[PXDBCreatedByScreenID()]
//		public virtual string CreatedByScreenID { get; set; }
//		public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
//		#endregion

//		#region CreatedDateTime
//		[PXDBCreatedDateTime()]
//		public virtual DateTime? CreatedDateTime { get; set; }
//		public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
//		#endregion

//		#region LastModifiedByID
//		[PXDBLastModifiedByID()]
//		public virtual Guid? LastModifiedByID { get; set; }
//		public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
//		#endregion

//		#region LastModifiedByScreenID
//		[PXDBLastModifiedByScreenID()]
//		public virtual string LastModifiedByScreenID { get; set; }
//		public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
//		#endregion

//		#region LastModifiedDateTime
//		[PXDBLastModifiedDateTime()]
//		public virtual DateTime? LastModifiedDateTime { get; set; }
//		public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
//		#endregion

//		#region Tstamp
//		[PXDBTimestamp()]
//		public virtual byte[] Tstamp { get; set; }
//		public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
//		#endregion

//		#region NoteID
//		[PXNote()]
//		public virtual Guid? NoteID { get; set; }
//		public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }
//		#endregion


//	}
//}
