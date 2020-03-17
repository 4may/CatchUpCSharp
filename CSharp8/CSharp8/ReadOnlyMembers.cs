using System;

/*
    structのメンバー変数にもreadonlyプロパティが適用できるようになった。

*/
public struct DoublePoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public readonly double Distance => Math.Sqrt(X * X + Y * Y);

    /*
    readonlyプロパティからreadonlyでないプロパティを参照すると警告が出る。
    ここでは、Distanceにreadonlyをつけることで解消
        */
    public readonly override string ToString() => $"({X}, {Y}) is {Distance} from the origin";
}