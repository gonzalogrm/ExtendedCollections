using System;

namespace ExtendedCollections
{
    public class Matrix<T>
    {
        //Properties
        public int Rows { get; set; }
        public int Columns { get; set; }
        public T[,] InternalArray { get; set; }


        //Index
        public T this[int i, int j]
        {
            get => InternalArray [i, j];
            set => InternalArray[i, j] = value;
        }

        //Needed for serialization
        public Matrix() { }

        //Constructors
        public Matrix(int rows, int colums)
        {
            InternalArray = CreateArray(rows, colums);
            Rows = rows;
            Columns = colums;
        }

        public Matrix(T[] array)
        {
            InternalArray = CreateArray(array.GetLength(0), 1);
            Rows = array.GetLength(0);
            Columns = 1;

            //Copy
            CopyValues(InternalArray, array);
        }

        public Matrix(T[,] array)
        {
            InternalArray = CreateArray(array.GetLength(0), array.GetLength(1));
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);

            //Copy
            CopyValues(InternalArray, array);
        }


        //Methods
        private T[,] CreateArray(int rows, int colums)
        {
            return new T[rows, colums];
        }

        public void CopyValues(Array Target, Array CopyFrom)
        {
            T[,] arr = Target as T[,];

            //El parámetro de entrada podría ser un T[]
            T[,] copy = null;
            if (CopyFrom.Rank == 1)
            {
                copy = VectorToMatrix(CopyFrom);
            }
            else{
                copy = CopyFrom as T[,];
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = copy[i, j];
                }
            }
        }

        public T[,] VectorToMatrix(Array arr)
        {
            T[,] res = null;
            if (arr.Rank == 1)
            {
                T[] vector = arr as T[];
                res = new T[arr.GetLength(0), 1];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    res[i, 0] = vector[i];
                }
            }
            return res;
        }

        public static Matrix<T> Sum(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = null;
            
            if (m1.InternalArray.Rank == m2.InternalArray.Rank)
            {
                result = new Matrix<T>(m1.Rows, m1.Columns);
                for (int i = 0; i < m1.InternalArray.GetLength(0); i++)
                {
                    for (int j = 0; j < m1.InternalArray.GetLength(1); j++)
                    {
                        dynamic a = m1.InternalArray[i, j];
                        dynamic b = m2.InternalArray[i, j];
                        result.InternalArray[i, j] = a + b;
                    }
                }
            }

            return result;
        }

        public static Matrix<T> Substract(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = null;

            if (m1.InternalArray.Rank == m2.InternalArray.Rank)
            {
                result = new Matrix<T>(m1.Rows, m1.Columns);
                for (int i = 0; i < m1.InternalArray.GetLength(0); i++)
                {
                    for (int j = 0; j < m1.InternalArray.GetLength(1); j++)
                    {
                        dynamic a = m1.InternalArray[i, j];
                        dynamic b = m2.InternalArray[i, j];
                        result.InternalArray[i, j] = a - b;
                    }
                }
            }

            return result;
        }

        public static Matrix<T> Multiply(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = null;

            int rA = m1.InternalArray.GetLength(0);
            int cA = m1.InternalArray.GetLength(1);
            int rB = m2.InternalArray.GetLength(0);
            int cB = m2.InternalArray.GetLength(1);

            dynamic temp = 0;
            if (cA != rB)
            {
                return null;
            }
            else
            {
                result = new Matrix<T>(rA,cB);
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            dynamic a = m1.InternalArray[i, k];
                            dynamic b = m2.InternalArray[k, j];
                            temp += a * b;
                        }
                        result.InternalArray[i, j] = temp;
                    }
                }
            }
            return result;
        }

        public bool HasSameSize(Matrix<T> other)
        {
            if (this.InternalArray.Rank != other.InternalArray.Rank)
            {
                return false;
            }

            if (this.Rows == other.Rows)
            {
                if (this.Columns == other.Columns)
                {
                    return true;
                }
            }

            return false;
        }

        public static Matrix<double> UnitDoubleVector(int size)
        {
            Matrix<double> result = new Matrix<double>(size,1);
            for (int i = 0; i < size; i++)
            {
                result[i, 0] = 1;
            }
            return result;
        }

        public static void RenormalizeMatrix<U>(Matrix<U> input, U factor)
        {
            for (int i = 0; i < input.Rows; i++)
            {
                for (int j = 0; j < input.Columns; j++)
                {
                    dynamic inputVal = input[i, j];
                    dynamic factorVal = factor;
                    input[i, j] = inputVal/factorVal;
                }
            }
        }

        public string Print()
        {
            string res = "";
            for (int i = 0; i < Rows; i++)
            {
                res += "{ ";
                for (int j = 0; j < Columns; j++)
                {
                    res += InternalArray[i, j] + " ";
                }
                res += "}\n";
            }
            return res;
        }
    }
}
