using System;
namespace CSharp8.defaultInterfaceMethods
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}
