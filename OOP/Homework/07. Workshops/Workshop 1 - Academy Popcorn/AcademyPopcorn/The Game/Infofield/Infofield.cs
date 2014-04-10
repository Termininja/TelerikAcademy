using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class Infofield
    {
        public void Print(List<dynamic> infoBar, MatrixCoords topLeft)
        {
            for (int line = 0; line < infoBar.Count; line++)
            {
                Console.SetCursorPosition(topLeft.Col, topLeft.Row + line);
                Console.WriteLine(infoBar[line]);
            }
        }
    }
}