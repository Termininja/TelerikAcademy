//Task 1: Refactor the following class using best practices for organizing straight-line code.

using System;

public class Chef
{
    public void Cook()
    {
        Bowl bowl = GetBowl();

        Potato potato = GetPotato();
        Cut(potato);
        Peel(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);
    }

    private Potato GetPotato()
    {
        //...
    }

    private Carrot GetCarrot()
    {
        //...
    }

    private Bowl GetBowl()
    {
        //... 
    }

    private void Cut(Vegetable potato)
    {
        //...
    }
}
