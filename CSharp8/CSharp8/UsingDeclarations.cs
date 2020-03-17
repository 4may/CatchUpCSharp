using System;
using System.Collections.Generic;

namespace CSharp8
{
    public class UsingDeclarations
    {
        public static int WriteLinesToFile(IEnumerable<string> lines)
        {
            /*
                usingにネストがいらなくなった！
                変数が宣言されているスコープを抜けたタイミングでオブジェクトが破棄される。
             */
            using var file = new System.IO.StreamWriter("WriteLines2.txt");

            int skippedLines = 0;
            foreach (string line in lines)
            {
                if(!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            
            return skippedLines;
            //fileはここでdisposedされる
        }
    }
}
