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

        //デフォルト実装付きの関数！
        public decimal ComputeLoyaltyDiscount()
        {
            DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
            if((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
            {
                return 0.10m;
            }

            return 0;
        }
    }
}
