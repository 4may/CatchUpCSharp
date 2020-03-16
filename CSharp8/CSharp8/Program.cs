using System;

namespace CSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point()
            {
                X = 20.5,
                Y = 30.2
            };
                       
            Console.WriteLine(point.ToString());
        }
    }
}
