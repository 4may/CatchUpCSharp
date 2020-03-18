using System;
namespace CSharp8
{
    public class IndicesAndRange
    {
        /*
        ^:end operator(sequenceの末尾sequence[sequence.length]を指す)
        ..:range operator ex)n..m:n番目からm-1番目までの要素を取得する。(m番目は含まれない)
        */
        public static readonly string[] words = new string[]
        {                 //index from end
            "The",        //^9
            "quick",      //^8
            "brown",      //^7
            "fox",        //^6
            "jumped",     //^5
            "over",       //^4
            "the",        //^3
            "lazy",       //^2
            "dog"         //^1
                          //^0
        };
    }
}
