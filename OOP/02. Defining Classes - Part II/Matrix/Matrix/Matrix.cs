using System;
using System.Text;

namespace Matrix
{
    class Matrix<T>
    {
        // Fields
        int rows, columns;
        T[,] matrix;

        // Constructor
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new T[rows, columns];
        }

        // Indexer
        public T this[int r, int c]
        {
            get
            {
                if (r < rows && c < columns) return matrix[r, c];
                else
                {
                    throw new IndexOutOfRangeException("The index is not in the range of the matrix!");
                }
            }
            set
            {
                if (r < rows && c < columns) matrix[r, c] = value;
                else
                {
                    throw new IndexOutOfRangeException("The index is not in the range of the matrix!");
                }
            }
        }

        // Addition of matrices of the same size
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            return Operation(m1, m2, 1);
        }

        // Subtraction of matrices of the same size
        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            return Operation(m1, m2, 2);
        }

        // Multiplication of matrices of the same size
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            // Throw an exception when the operation cannot be performed
            if (m1.rows != m2.columns || m1.columns != m2.rows)
            {
                throw new ArgumentException("The size of the matrices is wrong!");
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
                            // Addition
                            case 1:
                                m[r, c] = (dynamic)m1[r, c] + m2[r, c];
                                break;

                            // Subtraction
                            case 2:
                                m[r, c] = (dynamic)m1[r, c] - m2[r, c];
                                break;
                            default: break;
                        }
                    }
                }
                return m;
            }
        }

        // Clears all cells in the matrix
        public void Clear()
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