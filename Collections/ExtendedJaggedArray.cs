using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public class ExtendedJaggedArray<T>
    {
        private T[][] array;

        public ExtendedJaggedArray(int x, int y){
            array = new T[x][];
            for (int i = 0; i < x; i++)
            {
                array[i] = new T[y];
            }
        }

        public ExtendedJaggedArray(T[][] array)
        {
            this.array = array;
        }

        public T Get(int i, int j)
        {
            return array[i][j];
        }

        public void Put(int i, int j, T value)
        {
            array[i][j] = value;
        }

        public List<T> GetAllToListNotNull(bool isConstantSize)
        {
            List<T> result = new List<T>();

            if (isConstantSize)
            {
                int outSize = array.Length;
                int innerSize = array[0].Length;
                //Búsqueda en X
                for (int x = 0; x < outSize; x++)
                {
                    //Búsqueda en Y
                    for (int y = 0; y < innerSize; y++)
                    {
                        if (array[x][y] != null)
                        {
                            result.Add(array[x][y]);
                        }
                    }
                }
            }
            else
            {
                //Búsqueda en X
                for (int x = 0; x < array.Length; x++)
                {
                    //Búsqueda en Y
                    for (int y = 0; y < array[x].Length; y++)
                    {
                        if (array[x][y] != null)
                        {
                            result.Add(array[x][y]);
                        }
                    }
                }
            }

            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> FindAllToListNotNull()
        {
            List<T> result = new List<T>();
            T[] partialFind;

            foreach (T[] i in array)
            {
                partialFind = Array.FindAll(i, x => x != null);
                result.AddRange(partialFind);
            }

            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAnyInAreaToListNotNull(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();

            //Búsqueda en X
            for (int x = x1; x <= x2; x++)
            {
                //Búsqueda en Y
                for (int y = y1; y <= y2; y++)
                {
                    if(array[x][y] != null)
                    {
                        result.Add(array[x][y]);
                    }                    
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAnyInAreaToList(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();

            //Búsqueda en X
            for (int x = x1; x <= x2; x++)
            {
                //Búsqueda en Y
                for (int y = y1; y <= y2; y++)
                {
                    result.Add(array[x][y]);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetSearchedInAreaToList(int x1, int x2, int y1, int y2, T searched)
        {
            List<T> result = new List<T>();

            //Búsqueda en X
            for (int x = x1; x <= x2; x++)
            {
                //Búsqueda en Y
                for (int y = y1; y < y2; y++)
                {
                    if (array[x][y].Equals(searched))
                    {
                        result.Add(array[x][y]);
                    }
                }
            }
            return (result.Count() > 0) ? result : null;
        }
    }
}
