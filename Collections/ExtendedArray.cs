using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public class ExtendedArray<T>
    {
        private T[,] array;

        public ExtendedArray(int x, int y){
            array = new T[x,y];
        }

        public ExtendedArray(T[,] array)
        {
            this.array = array;
        }

        public T Get(int i, int j)
        {
            return array[i, j];
        }

        public void Put(int i, int j, T value)
        {
            array[i, j] = value;
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
                    if(array[x, y] != null)
                    {
                        result.Add(array[x, y]);
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
                    result.Add(array[x, y]);
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
                    if (array[x, y].Equals(searched))
                    {
                        result.Add(array[x, y]);
                    }
                }
            }
            return (result.Count() > 0) ? result : null;
        }
    }
}
