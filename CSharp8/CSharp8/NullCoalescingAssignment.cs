using System;
using System.Collections.Generic;

namespace CSharp8
{
    public class NullCoalescingAssignment
    {
        /*
        左辺 ??= 右辺　: 左辺がnullなら右辺を代入する。そうでなければ何もしない
        */
        public static void Example()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers)); //17 17
            Console.WriteLine(i); //17
        }
    }
}
