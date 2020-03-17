﻿using System;
namespace CSharp8
{
    public class SeveralExpressions
    {
        public enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        //switchをexpressionでかけちゃう
        public static RGBColor FromRainbow(Rainbow colorBand) =>
            colorBand switch
            {
                Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
                Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
                Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
                Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
                Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
                Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
                Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(colorBand)),
            };

        //switch expressionのなかで、プロパティアクセス
        public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
            location switch
            {
                { State: "WA" } => salePrice * 0.06M,
                { State: "MN" } => salePrice * 0.06M,
                { State: "MI" } => salePrice * 0.06M,
                _ => 0M
            };

        //switch expressionのなかで、タプルを使用
        public static string RockPaperScissors(string first, string second) =>
        (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scisors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins",
            //...
            (_, _) => "tie"
        };

        public enum Quadrant
        {
            Unknown,
            Origin,
            One,
            Two,
            Three,
            Four,
            OnBorder
        }

        public static Quadrant GetQuadrant(Point point) =>
            point switch
            {
                (0, 0) => Quadrant.Origin,
                var (x, y) when x > 0 && y > 0 => Quadrant.One,
                var (x, y) when x < 0 && y > 0 => Quadrant.One,
                var (x, y) when x < 0 && y < 0 => Quadrant.One,
                var (x, y) when x > 0 && y < 0 => Quadrant.One,
                var (_, _) => Quadrant.OnBorder,
                _ => Quadrant.Unknown
            };
    }

    
}
