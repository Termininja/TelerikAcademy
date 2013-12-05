using System;
using System.Collections.Generic;

class BasicBASIC
{
    static void Main()
    {
        string[] Lists = new string[10005];
        int V = 0;
        int W = 0;
        int X = 0;
        int Y = 0;
        int Z = 0;
        string line = String.Empty;
        List<int> Results = new List<int>();

        int index = 0;
        while (line != "RUN")
        {
            line = Console.ReadLine().Trim();
            if (line != "RUN")
            {
                int space = line.IndexOf(' ');
                index = int.Parse(line.Substring(0, space));
                Lists[index] = line.Substring(space + 1).Replace(" ", "").Trim();
            }
            else Lists[index + 1] = "RUN";
        }

        for (int l = 0; l <= index + 1; l++)
        {
            if (Lists[l] == "RUN") break;
            if (Lists[l] != null)
            {
                switch (Lists[l][0])
                {
                    case 'V': V = Calc(Lists, V, W, X, Y, Z, l); break;
                    case 'W': W = Calc(Lists, V, W, X, Y, Z, l); break;
                    case 'X': X = Calc(Lists, V, W, X, Y, Z, l); break;
                    case 'Y': Y = Calc(Lists, V, W, X, Y, Z, l); break;
                    case 'Z': Z = Calc(Lists, V, W, X, Y, Z, l); break;
                    case 'I':
                        int then = Lists[l].IndexOf("THEN");
                        int equalTo = Lists[l].IndexOf("=");
                        int moreThan = Lists[l].IndexOf(">");
                        int lessThan = Lists[l].IndexOf("<");

                        if (equalTo > then) equalTo = -1;
                        if (moreThan > then) moreThan = -1;
                        if (lessThan > then) lessThan = -1;

                        if (equalTo > 0) IF(Lists, ref V, ref W, ref X, ref Y, ref Z, Results, ref l, then, equalTo, '=');
                        else if (moreThan > 0) IF(Lists, ref V, ref W, ref X, ref Y, ref Z, Results, ref l, then, moreThan, '>');
                        else if (lessThan > 0) IF(Lists, ref V, ref W, ref X, ref Y, ref Z, Results, ref l, then, lessThan, '<');

                        break;
                    case 'G': l = int.Parse(Lists[l].Substring(4)) - 1; break;
                    case 'C': Results.Clear(); break;
                    case 'P':
                        switch (Lists[l].Substring(5))
                        {
                            case "V": Results.Add(V); break;
                            case "W": Results.Add(W); break;
                            case "X": Results.Add(X); break;
                            case "Y": Results.Add(Y); break;
                            case "Z": Results.Add(Z); break;
                            default: break;
                        };
                        break;
                    case 'S': l = 10002; break;
                    default: break;
                }
            }
        }
        foreach (var item in Results) Console.WriteLine(item);
    }

    static void IF(string[] Lists, ref int V, ref int W, ref int X, ref int Y, ref int Z, List<int> Results, ref int l, int then, int what, char sym)
    {
        int left = 0;
        int right = 0;
        int n;
        if (int.TryParse(Lists[l].Substring(2, what - 2), out n)) left = n;
        else
        {
            switch (Lists[l][2])
            {
                case 'V': left = V; break;
                case 'W': left = W; break;
                case 'X': left = X; break;
                case 'Y': left = Y; break;
                case 'Z': left = Z; break;
                default: break;
            }
        }
        if (int.TryParse(Lists[l].Substring(what + 1, then - what - 1), out n)) right = n;
        else
        {
            switch (Lists[l][what + 1])
            {
                case 'V': right = V; break;
                case 'W': right = W; break;
                case 'X': right = X; break;
                case 'Y': right = Y; break;
                case 'Z': right = Z; break;
                default: break;
            }
        }

        bool temp = false;
        switch (sym)
        {
            case '=': if (left == right) temp = true; break;
            case '>': if (left > right) temp = true; break;
            case '<': if (left < right) temp = true; break;
            default: break;
        }

        if (temp)
        {
            string[] th = new string[1];
            th[0] = Lists[l].Substring(then + 4);

            switch (th[0][0])
            {
                case 'V': V = Calc(th, V, W, X, Y, Z, 0); break;
                case 'W': W = Calc(th, V, W, X, Y, Z, 0); break;
                case 'X': X = Calc(th, V, W, X, Y, Z, 0); break;
                case 'Y': Y = Calc(th, V, W, X, Y, Z, 0); break;
                case 'Z': Z = Calc(th, V, W, X, Y, Z, 0); break;
                case 'G': l = int.Parse(th[0].Substring(4)) - 1; break;
                case 'C': Results.Clear(); break;
                case 'P':
                    switch (th[0].Substring(5))
                    {
                        case "V": Results.Add(V); break;
                        case "W": Results.Add(W); break;
                        case "X": Results.Add(X); break;
                        case "Y": Results.Add(Y); break;
                        case "Z": Results.Add(Z); break;
                        default: break;
                    };
                    break;
                case 'S': l = 10002; break;
                default: break;
            }
        }
    }

    static int Calc(string[] Lists, int V, int W, int X, int Y, int Z, int l)
    {
        int minus = Lists[l].LastIndexOf('-');
        int plus = Lists[l].LastIndexOf('+');
        if (minus > 0) X = Operation(Lists, V, W, X, Y, Z, l, minus, '-');
        else if (plus > 0) X = Operation(Lists, V, W, X, Y, Z, l, plus, '+');
        else
        {
            int j;
            if (int.TryParse(Lists[l].Substring(2), out j)) X = j;
            else
            {
                switch (Lists[l][2])
                {
                    case 'V': X = V; break;
                    case 'W': X = W; break;
                    case 'Y': X = Y; break;
                    case 'Z': X = Z; break;
                    default: break;
                }
            }
        }
        return X;
    }

    static int Operation(string[] Lists, int V, int W, int X, int Y, int Z, int l, int minus, char ch)
    {
        int first = 0;
        int second = 0;
        int number;
        if (int.TryParse(Lists[l].Substring(2, minus - 2), out number)) first = number;
        else
        {
            switch (Lists[l][2])
            {
                case 'V': first = V; break;
                case 'W': first = W; break;
                case 'X': first = X; break;
                case 'Y': first = Y; break;
                case 'Z': first = Z; break;
                default: break;
            }
        }
        if (int.TryParse(Lists[l].Substring(minus + 1), out number)) second = number;
        else
        {
            switch (Lists[l][Lists[l].Length - 1])
            {
                case 'V': second = V; break;
                case 'W': second = W; break;
                case 'X': second = X; break;
                case 'Y': second = Y; break;
                case 'Z': second = Z; break;
                default: break;
            }
        }
        if (ch == '-') X = first - second;
        if (ch == '+') X = first + second;
        return X;
    }
}