using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8
{
    public class AsyncStream
    {
        public AsyncStream()
        {
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for(int i = 0; i < 20; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
