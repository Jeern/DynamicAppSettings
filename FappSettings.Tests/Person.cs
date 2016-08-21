using System;

namespace FappSettings.Tests
{
    public class Person : FappConfiguration
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override void Populate(string configuration)
        {
            var splitted = configuration.Split(',');
            Name = splitted[0];
            Age = Convert.ToInt32(splitted[1]);
        }

        public override bool Equals(object obj)
        {
            var p = obj as Person;
            if (p == null)
                return false;

            return Name == p.Name && Age == p.Age;
        }
    }
}
