namespace MathCompare
{
    using System;

    class MathCompare
    {
        /// <summary>
        /// Operation square root for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Sqrt(string type)
        {
            switch (type)
            {
                case "float":
                    for (float i = 0; i < 1000000; i++)
                    {
                        Math.Sqrt(i);
                    }
                    break;
                case "double":
                    for (double i = 0; i < 1000000; i++)
                    {
                        Math.Sqrt(i);
                    }
                    break;
                case "decimal":
                    for (decimal i = 0; i < 1000000; i++)
                    {
                        Math.Sqrt((double)i);
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }

        /// <summary>
        /// Operation natural logarithm for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Log(string type)
        {
            switch (type)
            {
                case "float":
                    for (float i = 0; i < 1000000; i++)
                    {
                        Math.Log(i);
                    }
                    break;
                case "double":
                    for (double i = 0; i < 1000000; i++)
                    {
                        Math.Log(i);
                    }
                    break;
                case "decimal":
                    for (decimal i = 0; i < 1000000; i++)
                    {
                        Math.Log((double)i);
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }

        /// <summary>
        /// Operation sinus for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Sin(string type)
        {
            switch (type)
            {
                case "float":
                    for (float i = 0; i < 1000000; i++)
                    {
                        Math.Log(i);
                    }
                    break;
                case "double":
                    for (double i = 0; i < 1000000; i++)
                    {
                        Math.Log(i);
                    }
                    break;
                case "decimal":
                    for (decimal i = 0; i < 1000000; i++)
                    {
                        Math.Log((double)i);
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }
    }
}