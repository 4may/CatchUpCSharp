using System;
namespace CSharp8.nullableReferenceTypes
{
    /*
    nullableの仕組みを適用するためには、明示的にcontextを宣言しなければならない。
    以下のcontextにより、nullableを有効にする
    なお、デフォルトだとnullable=disable
    ちなみに、ソースごとに書くのが面倒な場合は.csprojに
    <Nullable>enable</Nullable>
    と書くことでnullableの仕組みをプロジェクト全体に適用することもできる。
    取りうる値は、
    ・enable
    ・warnings:警告出す
    ・annotations
    ・disable

    詳細は以下。
    https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts
    */

    /*
    C#の参照型は以下の4つの状態をとる。
   ・Nonnullable:nullになることはない。nullチェック不要。警告あり。
   ・Nullable:nullになることがある。nullチェック必要。警告あり。
   ・Oblivious:警告なし。nulllチェックは自己責任で。(デフォルト)
   ・Unknown:nullになるかどうかわからない。
    */
#nullable enable
    public class NullableReferenceTypes
    { 
        public static void BasicExample()
        {
            /*
            nullableな参照型の宣言「型名? 変数名 = ...」

            ※#nullable contextがないと、以下の警告が出る。
            '#nullable' 注釈コンテキスト内のコードでのみ、Null 許容参照型の注釈を使用する必要があります。
             */
            //
            string? nullableString = null;
            Console.WriteLine(nullableString);

            /*
            nonNullableにnullを代入すると以下の警告が出る。
            Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。
             */
            string nonNullableString = null;
            /*
            !:null許容演算子
            変数名の後につける事で、以下の警告を無視できる。
            ここでは、'nonNullableString' は null である可能性があります。
             */
            try
            {
                var cannotAccessLength = nonNullableString!.Length;
            }
            catch (Exception err)
            {
                /*
                System.NullReferenceException: Object reference not set to an instance of an object.
                at CSharp8.nullableReferenceTypes.NullableReferenceTypes.BasicExample() in /Users/naokihanzawa/Develop/CatchUpCSharp/CSharp8/CSharp8/nullableReferenceTypes/NullableReferenceTypes.cs:line 36
                 */
                Console.WriteLine(err);
            }
        }
    }
}
