using System;
namespace CSharp9.Record
{
    //records support inheritance
    public record Teacher : Person
    {
        public string Subject { get; }

        public Teacher(string first, string last, string sub) : base(first, last) => Subject = sub;
    }
}
