﻿namespace Company.DataGenerator.RandomDataGenerators
{
    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);
    }
}
