using System;
using System.Text;

namespace Matrix
{
    class Matrix<T>
    {
        // Fields
        int rows, columns;
        int[,] matrix;

        // Constructor
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new T[rows, columns];
        }

        // Indexer
        public T this[int r, int c]                                     // accessing the inner matrix cells
        {
            get
            {
                if (r < rows && c < columns) return matrix[r, c];
                else throw new IndexOutOfRangeException("The index is not in the range of the matrix!");
            }
            set
            {
                if (r < rows && c < columns) matrix[r, c] = value;
                else throw new IndexOutOfRangeException("The index is not in the range of the matrix!");
            }
        }

        // Operators
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)  // addition of matrices of the same size
        {
            return Operation(m1, m2, 1);
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)  // subtraction of matrices of the same size
        {
            return Operation(m1, m2, 2);
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)  // multiplication of matrices of the same size
        {
            // Throw an exception when the operation cannot be performed
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new ArgumentException("The size of the matrices is not the same!");
            }
            else
            {
                Matrix<T> m = new Matrix<T>(m1.rows, m1.columns);
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
        }

        public static bool operator true(Matrix<T> m)                   // implement the 'true' operator
        {
            foreach (var item in m.matrix)
            {
                if (!item.Equals(default(T)))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> m)                  // implement the 'false' operator
        {
            foreach (var item in m.matrix)
            {
                if (!item.Equals(default(T)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !(Matrix<T> m)                      // implement the '!' operator
        {
            if (m) { return false; }
            else { return true; }
        }

        // Methods
        private static Matrix<T> Operation(Matrix<T> m1, Matrix<T> m2, byte Operator)
        {
            // Throw an exception when the operation cannot be performed
            if (m1.rows != m2.rows || m1.columns != m2.columns)
            {
                throw new ArgumentException("The size of the matrices is not the same!");
            }
            else
            {
                Matrix<T> m = new Matrix<T>(m1.rows, m1.columns);
                for (int r = 0; r < m.rows; r++)
                {
                    for (int c = 0; c < m.columns; c++)
                    {
                        switch (Operator)
                        {
                            case 1: m[r, c] = (dynamic)m1[r, c] + m2[r, c]; break;      // addition
                            case 2: m[r, c] = (dynamic)m1[r, c] - m2[r, c]; break;      // subtraction
                            default: break;
                        }
                    }
                }
                return m;
            }
        }

        public void Clear()                     // clears all cells in the matrix
        {
            matrix = new T[rows, columns];
        }

        // String output for this class
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.Append(String.Format("{0,11:F2}", matrix[i, j]));
                }
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}