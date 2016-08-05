using System;

namespace FappSettings.Tests
{
    public class Person : IFappConfiguration<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }

        public string Key => Name;
        
        public Person Parse(string configuration)
        {
            var splitted = configuration.Split(',');
            return new Person(splitted[0], Convert.ToInt32(splitted[1]));
        }
        
    }
}
