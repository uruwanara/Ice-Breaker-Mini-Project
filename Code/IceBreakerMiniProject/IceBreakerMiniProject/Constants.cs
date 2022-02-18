﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBreakerMiniProject
{
    public static class Constant
    {
        public static class InventoryType
        {
            public const string Stock = "STOCK";
            public const string NonStock = "NONSTOCK";
        }

        public class stockItem : PX.Data.BQL.BqlString.Constant<stockItem>
        {
            public stockItem()
            : base(InventoryType.Stock)
            {
            }
        }

        public const string nonStockItemConstant = "NONSTOCK";
        public class nonStockItem : PX.Data.BQL.BqlString.Constant<nonStockItem>
        {
            public nonStockItem()
            : base(InventoryType.NonStock)
            {
            }
        }


        public static class PartType
        {
            public const string Manufactured = "MANUFACTURED";
            public const string Purchased = "PURCHASED";
            public const string NoPart = "NOPART";
        }

        public class manufacturedItem : PX.Data.BQL.BqlString.Constant<manufacturedItem>
        {
            public manufacturedItem()
            : base(PartType.Manufactured)
            {
            }
        }

        public class purchasedItem : PX.Data.BQL.BqlString.Constant<purchasedItem>
        {
            public purchasedItem()
            : base(PartType.Purchased)
            {
            }
        }

    }

}
