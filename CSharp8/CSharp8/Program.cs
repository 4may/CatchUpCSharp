using System;
using System.Collections.Generic;
using System.Linq;
using CSharp8.defaultInterfaceMethods;
using CSharp8.nullableReferenceTypes;

namespace CSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallReadOnlyMembers();

            //CallDefaultInterfaceMethods();

            //CallSeveralExpressions();

            //CallUsingDeclarations();

            //CallStaticLocalFunctions();

            //CallNullableReferenceTypes();

            //CallAsyncStream();

            CallIndicesAndRange();
        }

        private static void CallReadOnlyMembers()
        {
            var point = new DoublePoint()
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

        private static void CallSeveralExpressions()
        {
            RGBColor color = SeveralExpressions.FromRainbow(SeveralExpressions.Rainbow.Blue);
            Console.WriteLine($"{color.R},{color.G},{color.B}");

            decimal tax = SeveralExpressions.ComputeSalesTax(new Address("WA"), 100);
            Console.WriteLine($"tax:{tax}");

            string result = SeveralExpressions.RockPaperScissors("rock", "paper");
            Console.WriteLine(result);

            SeveralExpressions.Quadrant quadrant = SeveralExpressions.GetQuadrant(new Point(10, 10));
            Console.WriteLine($"quadrant:{quadrant}");
        }

        private static void CallUsingDeclarations()
        {
            IEnumerable<string> lines = new List<string>()
            {
                "Second",
                "Skipped",
                "Skipped",
                "Second",
                "Skipped"
            };
            int skippedLines = UsingDeclarations.WriteLinesToFile(lines);
            Console.WriteLine($"skippedLines:{skippedLines}");
        }

        private static void CallStaticLocalFunctions()
        {
            int result = new StaticLocalFunctions().M();
            Console.WriteLine($"result:{result}");
        }

        private static void CallNullableReferenceTypes()
        {
            NullableReferenceTypes.BasicExample();
        }

        private static async void CallAsyncStream()
        {
            await foreach(var number in AsyncStream.GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }

        private static void CallIndicesAndRange()
        {
            Console.WriteLine($"The last word is {IndicesAndRange.words[^1]}");
            var subwords = IndicesAndRange.words[1..4];
            foreach (var word in subwords)
            {
                Console.WriteLine($"word:{word}");
            }

            //start..end のstart,endはともに省略可能
            var allWords = IndicesAndRange.words[..];
            var firstPhrase = IndicesAndRange.words[..4];
            var lastPhrase = IndicesAndRange.words[6..];

            //Rangeオブジェクトとして宣言することも可能
            Range range = 1..4;
            var text = IndicesAndRange.words[range];
        }
    }
}
