namespace TypeCompare
{
    using System;

    class TypeCompare
    {
        /// <summary>
        /// Operation add for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Add(string type)
        {
            switch (type)
            {
                case "int":
                    int resultInt = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        resultInt += i;
                    }
                    break;
                case "long":
                    long resultLong = 0;
                    for (long i = 0; i < 1000000; i++)
                    {
                        resultLong += i;
                    }
                    break;
                case "float":
                    float resultFloat = 0;
                    for (float i = 0; i < 1000000; i++)
                    {
                        resultFloat += i;
                    }
                    break;
                case "double":
                    double resultDouble = 0;
                    for (double i = 0; i < 1000000; i++)
                    {
                        resultDouble += i;
                    }
                    break;
                case "decimal":
                    decimal resultDecimal = 0;
                    for (decimal i = 0; i < 1000000; i++)
                    {
                        resultDecimal += i;
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }

        /// <summary>
        /// Operation increment for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Increment(string type)
        {
            switch (type)
            {
                case "int":
                    int resultInt = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        resultInt++;
                    }
                    break;
                case "long":
                    long resultLong = 0;
                    for (long i = 0; i < 1000000; i++)
                    {
                        resultLong++;
                    }
                    break;
                case "float":
                    float resultFloat = 0;
                    for (float i = 0; i < 1000000; i++)
                    {
                        resultFloat++;
                    }
                    break;
                case "double":
                    double resultDouble = 0;
                    for (double i = 0; i < 1000000; i++)
                    {
                        resultDouble++;
                    }
                    break;
                case "decimal":
                    decimal resultDecimal = 0;
                    for (decimal i = 0; i < 1000000; i++)
                    {
                        resultDecimal++;
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }

        /// <summary>
        /// Operation subtract for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Subtract(string type)
        {
            switch (type)
            {
                case "int":
                    int resultInt = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        resultInt -= i;
                    }
                    break;
                case "long":
                    long resultLong = 0;
                    for (long i = 0; i < 1000000; i++)
                    {
                        resultLong -= i;
                    }
                    break;
                case "float":
                    float resultFloat = 0;
                    for (float i = 0; i < 1000000; i++)
                    {
                        resultFloat -= i;
                    }
                    break;
                case "double":
                    double resultDouble = 0;
                    for (double i = 0; i < 1000000; i++)
                    {
                        resultDouble -= i;
                    }
                    break;
                case "decimal":
                    decimal resultDecimal = 0;
                    for (decimal i = 0; i < 1000000; i++)
                    {
                        resultDecimal -= i;
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }

        /// <summary>
        /// Operation multiply for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Multiply(string type)
        {
            switch (type)
            {
                case "int":
                    int resultInt = 1;
                    for (int i = 1; i < 1000000; i++)
                    {
                        resultInt *= i;
                        resultInt = 10;
                    }
                    break;
                case "long":
                    long resultLong = 1;
                    for (long i = 1; i < 1000000; i++)
                    {
                        resultLong *= i;
                        resultLong = 10;
                    }
                    break;
                case "float":
                    float resultFloat = 1;
                    for (float i = 1; i < 1000000; i++)
                    {
                        resultFloat *= i;
                        resultFloat = 10;
                    }
                    break;
                case "double":
                    double resultDouble = 1;
                    for (double i = 1; i < 1000000; i++)
                    {
                        resultDouble *= i;
                        resultDouble = 10;
                    }
                    break;
                case "decimal":
                    decimal resultDecimal = 1;
                    for (decimal i = 1; i < 1000000; i++)
                    {
                        resultDecimal *= i;
                        resultDecimal = 10;
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }

        /// <summary>
        /// Operation divide for some value type.
        /// </summary>
        /// <param name="type">The value type.</param>
        public static void Divide(string type)
        {
            switch (type)
            {
                case "int":
                    int resultInt = 1000000;
                    for (int i = 1; i < 1000000; i++)
                    {
                        resultInt /= i;
                        resultInt = 1000000;
                    }
                    break;
                case "long":
                    long resultLong = 1000000;
                    for (long i = 1; i < 1000000; i++)
                    {
                        resultLong /= i;
                        resultLong = 1000000;
                    }
                    break;
                case "float":
                    float resultFloat = 1000000;
                    for (float i = 1; i < 1000000; i++)
                    {
                        resultFloat /= i;
                        resultFloat = 1000000;
                    }
                    break;
                case "double":
                    double resultDouble = 1000000;
                    for (double i = 1; i < 1000000; i++)
                    {
                        resultDouble /= i;
                        resultDouble = 1000000;
                    }
                    break;
                case "decimal":
                    decimal resultDecimal = 1000000;
                    for (decimal i = 1; i < 1000000; i++)
                    {
                        resultDecimal /= i;
                        resultDecimal = 1000000;
                    }
                    break;
                default:
                    throw new ArgumentException("Wrong input type!");
            }
        }
    }
}