using System;
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

        public const string stockItemConstant = "STOCK";
        public class stockItem : PX.Data.BQL.BqlString.Constant<stockItem>
        {
            public stockItem()
            : base(stockItemConstant)
            {
            }
        }

        public static class PartType
        {
            public const string Manufactured = "MANUFACTURED";
            public const string Purchased = "PURCHASED";
        }


    }

}
