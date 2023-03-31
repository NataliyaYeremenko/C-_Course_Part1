using System;

namespace Yeremenko_OOP_HW7
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly DoB { get; private set; }
        public string City { get; set; }
        public int Age { get; private set; }

        public virtual void Print()
        {
            Console.WriteLine(
                $"Name: {Name}\n" +
                $"Last Name: {LastName}\n" +
                $"Date of birth: {DoB}\n" +
                $"Age: {Age}\n" +
                $"City: {City}"

            );
        }

        public virtual void DescribeYourself()
        {
            Console.Write($"My name is {Name} {LastName}. I am {Age} years old. ");
            if (!String.Equals(City, "No information provided"))
            {
                Console.WriteLine($"I am from {City}.");
            }
            else Console.WriteLine();
        }
        public Person(string name, string lastName, DateOnly dob)
        {
            Name = name;
            LastName = lastName;
            DoB = dob;
            Age = (DateTime.Today).Year - DoB.Year;
            City = "No information provided";
        }
        public Person(string name, string lastName, DateOnly dob, string city) : this(name, lastName, dob)
        {
            City = city;
        }
    }
}
