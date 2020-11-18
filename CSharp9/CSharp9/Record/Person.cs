namespace CSharp9.Record
{
    //record type
    public record Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        //constructor
        public Person(string first, string last) => (FirstName, LastName) = (first, last);
    }
}