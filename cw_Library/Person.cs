using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    public class Person
    {
        public string Name { get; }
        public int Age { get; }


        public Person(string name, int age)
        {
            if (age >= 18)
            {
                Age = age;
                Name = name;
            }
            else
            {
                throw new HotelException("Person has to be older than 18 y.o.");
            }
        }

    }
}
