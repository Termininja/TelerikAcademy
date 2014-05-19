//Task 2. Refactor the following examples to produce code with well-named identifiers in C#:

using System;

class Program
{
    enum Sex { Man, Woman };

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
    }

    private static Person CreatePerson(int age)
    {
        Person person = new Person();
        person.Age = age;
        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.Man;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.Woman;
        }

        return person;
    }

    static void Main()
    {
        Person newPerson = CreatePerson(22);
    }
}