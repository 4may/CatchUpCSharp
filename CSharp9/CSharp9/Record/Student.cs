namespace CSharp9.Record
{
    //positional record
    public record Student(string FirstName, string LastName, int Level) : Person(FirstName, LastName);
}
