using System;

class Neurons
{
    static void Main()
    {
        while (true)
        {
            string str = Console.ReadLine();
            if (str == "-1") break;
            bool neuron = false;
            uint n = uint.Parse(str);
            uint result = 0;
            for (int col = 0; col < 32; col++)
            {
                if (((n >> 31 - col) & 1) == 1)
                {
                    bool start = false;
                    for (int col2 = col + 1; col2 < 32; col2++)
                    {
                        if (((n >> 31 - (col2 - 1)) & 1) == 1 && ((n >> 31 - col2) & 1) == 0)
                        {
                            start = true;
                        }
                        else if (((n >> 31 - (col2 - 1)) & 1) == 0 && ((n >> 31 - col2) & 1) == 1)
                        {
                            neuron = true;
                            start = false;
                            break;
                        }
                        else neuron = false;
                        if (start) result += (uint)Math.Pow(2, 31 - col2);
                    }
                    break;
                }
            }
            if (!neuron) result = 0;
            Console.WriteLine(result);
        }
    }
}