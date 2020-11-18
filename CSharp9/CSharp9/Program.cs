using System;
using CSharp9.Record;

namespace CSharp9
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------Record----------------------
            var person1 = new Person("Naoki", "Hanzawa");
            var person2 = new Person("Naoki", "Hanzawa");

            //record type equality
            Console.WriteLine("person1.Equals(person2):" + person1.Equals(person2));
            Console.WriteLine("person1 == person2:" + (person1 == person2));

            var teacher1 = new Teacher("Naoki", "Hanzawa", "Bank");
            var teacher2 = new Teacher("Naoki", "Hanzawa", "Bank");
            Console.WriteLine("teacher1.Equals(teacher2):" + teacher1.Equals(teacher2));
            Console.WriteLine("teacher1.Equals(person1):" + teacher1.Equals(person1));

            //update a property by using "with" statement
            Person anotherPerson = person1 with { LastName = "Sato" };
            Console.WriteLine("First:" + anotherPerson.FirstName);
            Console.WriteLine("Last:" + anotherPerson.LastName);

            //positional record
            var student = new Student("Naoki", "Hanzawa", 1);
            //positional record supports deconstruct method
            var (first, last, level) = student;
            Console.WriteLine($"{first},{last},{level}");

            //-------------Init only setters-----------------
            var now = new WeatherObservation
            {
                RecordedAt = DateTime.Now,
                TemperatureInCelsius = 20,
                PressureInMillibars = 998.0m
            };
            //CS8852: Init-only property or indexer 'WeatherObservation.RecordedAt' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
            //now.RecordedAt = 18;
        }
    }
}
