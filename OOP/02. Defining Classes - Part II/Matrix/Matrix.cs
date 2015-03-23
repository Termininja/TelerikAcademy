namespace Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class Matrix<T>
    {
        private int rows, columns;
        private T[,] matrix;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new T[rows, columns];
        }

        // Indexer
        public T this[int r, int c]
        {
            get
            {
                if (r >= this.rows || c >= this.columns)
                {
                    throw new IndexOutOfRangeException("The index is not in the range of the matrix!");
                }

                return this.matrix[r, c];
            }
            set
            {
                if (r >= this.rows || c >= this.columns)
                {
                    throw new IndexOutOfRangeException("The index is not in the range of the matrix!");
                }

                this.matrix[r, c] = value;
            }
        }

        // Addition of matrices of the same size
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            return Operation(m1, m2, true);
        }

        // Subtraction of matrices of the same size
        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            return Operation(m1, m2, false);
        }

        // Multiplication of matrices of the same size
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.rows != m2.columns || m1.columns != m2.rows)
            {
                throw new ArgumentException("The size of the matrices is wrong!");
            }

            var m = new Matrix<T>(m1.rows, m1.columns);
            for (int r = 0; r < m.rows; r++)
            {
                for (int c = 0; c < m.columns; c++)
                {
                    for (int k = 0; k < m.columns; k++)
                    {
                        m[r, c] += (dynamic)m1[r, k] * m2[k, c];
                    }
                }
            }

            return m;
        }

        // Implement the 'true' operator
        public static bool operator true(Matrix<T> m)
        {
            foreach (var item in m.matrix)
            {
                if (!item.Equals(default(T))) return true;
            }

            return false;
        }

        // Implement the 'false' operator
        public static bool operator false(Matrix<T> m)
        {
            foreach (var item in m.matrix)
            {
                if (!item.Equals(default(T))) return false;
            }

            return true;
        }

        // Implement the '!' operator
        public static bool operator !(Matrix<T> m)
        {
            return m ? false : true;
        }

        private static Matrix<T> Operation(Matrix<T> m1, Matrix<T> m2, bool addition)
        {
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new ArgumentException("The size of the matrices is not the same!");
            }

            var m = new Matrix<T>(m1.rows, m1.columns);
            for (int r = 0; r < m.rows; r++)
            {
                for (int c = 0; c < m.columns; c++)
                {
                    m[r, c] = m1[r, c] + (addition ? (dynamic)m2[r, c] : -(dynamic)m2[r, c]);
                }
            }

            return m;
        }

        // Clears all cells in the matrix
        public void Clear()
        {
            this.matrix = new T[this.rows, this.columns];
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    result.Append(String.Format("{0,11:F2}", this.matrix[i, j]));
                }

                result.Append("\n");
            }

            return result.ToString();
        }
    }
}