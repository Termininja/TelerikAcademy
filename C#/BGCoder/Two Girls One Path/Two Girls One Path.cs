using System;
using System.Numerics;

class TwoGirlsOnePath
{
    static string[] input = Console.ReadLine().Split(' ');
    static int allCells = input.Length;

    static void Main()
    {
        int MollyCell = 1;
        int DollyCell = input.Length;
        BigInteger MollyF = 0;
        BigInteger DollyF = 0;
        bool isM = false;
        bool isD = false;
        while (true)
        {
            BigInteger MF = BigInteger.Parse(input[MollyCell - 1]);
            BigInteger DF = BigInteger.Parse(input[DollyCell - 1]);
            if (MollyCell == DollyCell)
            {
                BigInteger F = MF;
                BigInteger move = F;
                F = (F % 2 == 0) ? F = F / 2 : (F - 1) / 2;
                Term(ref MollyCell, ref MollyF, ref isM, F, true, move);
                Term(ref DollyCell, ref DollyF, ref isD, F, false, move);
            }
            else
            {
                Term(ref MollyCell, ref MollyF, ref isM, MF, true);
                Term(ref DollyCell, ref DollyF, ref isD, DF, false);
            }
            if (isM || isD)
            {
                Console.WriteLine("{0}\n{1} {2}", (isM && isD) ? "Draw" : ((isM) ? "Dolly" : "Molly"), MollyF, DollyF);
                break;
            }
        }
    }

    static void Term(ref int cell, ref BigInteger allF, ref bool end, BigInteger flowers, bool who, BigInteger? move = null)
    {
        if (flowers != 0)
        {
            allF += flowers;
            input[cell - 1] = ((move == null ? 0 : flowers) % 2 == 0) ? "0" : "1";
            BigInteger check = (BigInteger)(move == null ? flowers : move);
            cell = (who) ? (int)((cell + check) % allCells) : (cell - check <= 0) ?
                (int)(allCells + ((cell - check) % allCells)) : (int)(cell - check);
        }
        else end = true;
    }
}