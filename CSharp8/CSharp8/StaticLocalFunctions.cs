using System;
namespace CSharp8
{
    public class StaticLocalFunctions
    {
        /*
            staticな内部関数を宣言できるようになった。
            ただし、条件として、static関数を内包するスコープ内の変数を直接参照してはいけない。
             */
        public int M()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            //以下のようにはかけない。x,yはstaticではないので。
            //static int Add() => x + y;
            static int Add(int left, int right) => left + right;
        }
    }
}
