using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp8.defaultInterfaceMethods
{
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }

        public static void SetLoyaltyThreshholds(
            TimeSpan ago,
            int minimumOrders = 10,
            decimal percentDiscount = 0.10m)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentDiscount;
        }
        private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0); //2 years
        private static int orderCount = 10;
        private static decimal discountPercent = 0.10m;

        public decimal ComputeLoyaltyDiscount() => DefaultLoyaltyDiscount(this);

        //デフォルト実装付きの関数！
        protected static decimal DefaultLoyaltyDiscount(ICustomer c)
        {
            DateTime start = DateTime.Now - length;

            if((c.DateJoined < start) && (c.PreviousOrders.Count() > orderCount))
            {
                return discountPercent;
            }

            return 0;
        }
    }
}
