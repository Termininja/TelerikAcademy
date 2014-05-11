//Task 2. Refactor the following examples to produce code with well-named identifiers in C#:

class HumanTempMain
{
    enum Sex { Man, Woman };

    class Human
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void CreateHuman(int magicNumber)
    {
        Human newHuman = new Human();
        newHuman.Age = magicNumber;
        if (magicNumber % 2 == 0)
        {
            newHuman.Name = "Man";
            newHuman.Sex = Sex.Man;
        }
        else
        {
            newHuman.Name = "Woman";
            newHuman.Sex = Sex.Woman;
        }
    }

    static void Main()
    {
        //delete me
    }
}