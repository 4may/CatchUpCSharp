using System;
using System.Linq;
using CSharp8.defaultInterfaceMethods;

namespace CSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallReadOnlyMembers();

            CallDefaultInterfaceMethods();
        }

        private static void CallReadOnlyMembers()
        {
            var point = new Point()
            {
                X = 20.5,
                Y = 30.2
            };

            Console.WriteLine(point.ToString());
        }

        private static void CallDefaultInterfaceMethods()
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
            {
                Reminders =
                {
                    { new DateTime(2010, 08, 12), "childs's birthday" },
                    { new DateTime(1012, 11, 15), "anniversary" }
                }
            };

            SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
            c.AddOrder(o);

            /*
                実装先のクラス(SampleCustomer)で関数をオーバーライドしていない限り、
                インターフェースへのキャストが必須である事に注意！

             */
            ICustomer theCustomer = c;
            ICustomer.SetLoyaltyThreshholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
            Console.WriteLine($"Current Discount: {theCustomer.ComputeLoyaltyDiscount()}");

            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");
            foreach (var item in c.Reminders)
            {
                Console.WriteLine($"\t{item.Value} on {item.Key}");
            }
            foreach (IOrder order in c.PreviousOrders)
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");
        }
    }
}
