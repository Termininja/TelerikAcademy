using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLTable : HTMLElement, ITable
    {
        // Constructor
        public HTMLTable(int rows, int cols, string textContent = null)
            : base("table", textContent)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Cell = new IElement[this.Rows, this.Cols];
        }

        // Properties
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public IElement[,] Cell { get; set; }

        // Indexer
        public IElement this[int row, int col]
        {
            get
            {
                return this.Cell[row, col];
            }
            set
            {
                this.Cell[row, col] = value;
            }
        }

        // Methods
        public override void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int r = 0; r < this.Rows; r++)
            {
                output.Append("<tr>");
                for (int c = 0; c < this.Cols; c++)
                {
                    output.Append("<td>" + this.Cell[r, c] + "</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
