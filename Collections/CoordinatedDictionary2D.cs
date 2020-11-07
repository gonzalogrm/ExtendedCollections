using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public class CoordinatedDictionary2D<T> : I2DCollection<T>
    {
        private Dictionary<Point2D, T> dictionary;
        public Dictionary<Point2D, T>  getDictionary()
        {
            return dictionary;
        }

        public CoordinatedDictionary2D()
        {
            dictionary = new Dictionary<Point2D, T>();
        }

        //Insertion Methods
        public void Put(int x, int y, T value)
        {
            Point2D point = new Point2D(x, y);
            dictionary[point] = value;            
        }

        public void Put(Point2D point, T value)
        {
            dictionary[point] = value;
        }

        //Delete Methods
        public void Remove(int x, int y)
        {
            Point2D point = new Point2D(x, y);
            dictionary.Remove(point);
        }

        //Search Methods
        //Devuelve default(T) si no encuentra la key
        public T TryGet(int x, int y)
        {
            Point2D point = new Point2D(x, y);
            T value = default(T);            
            if (dictionary.TryGetValue(point, out value))
            {
                return value;
            }
            return value;
        }

        public T TryGet(Point2D point)
        {
            T value = default(T);
            if (dictionary.TryGetValue(point, out value))
            {
                return value;
            }
            return value;
        }

        public T Get(int x, int y)
        {
            Point2D point = new Point2D(x, y);
            return dictionary[point];
        }

        public List<T> GetInXToList(int x)
        {
            List<T> result = new List<T>();
            foreach (KeyValuePair<Point2D, T> pair in dictionary)
            {
                if (pair.Key.i == x)
                {
                    result.Add(pair.Value);
                }                
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetInYToList(int y)
        {
            List<T> result = new List<T>();
            foreach (KeyValuePair<Point2D, T> pair in dictionary)
            {
                if (pair.Key.j == y)
                {
                    result.Add(pair.Value);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAnyInAreaToList(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();
            Point2D point;
            foreach (KeyValuePair<Point2D, T> pair in dictionary)
            {
                point = pair.Key;
                if (point.i >= x1 && point.i <= x2)
                {
                    if (point.j >= y1 && point.j <= y2)
                    {
                        result.Add(pair.Value);
                    }
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAnyInAreaToListContains(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();
            Point2D point = new Point2D();
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    point.i = i;
                    point.j = j;
                    //point = new Point2D(i,j);
                    if (dictionary.ContainsKey(point))
                        result.Add(dictionary[point]);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }
        
        //Es rápido comparable con NestedDictionary
        public List<T> GetAllToList()
        {
            List<T> result = new List<T>();
            /*
            foreach (KeyValuePair<Point2D, T> pair in dictionary)
            {
                result.Add(pair.Value);
            }
            */
            
            result = dictionary.Values.ToList();

            //return (result.Count() > 0) ? result : null;
            return result;
        }

    }

    public class CoordinatedDictionary2D<X,Y,T> : I2DCollection<X,Y,T>
    {
        private Dictionary<Point2D<X, Y>, T> dictionary;
        public Dictionary<Point2D<X, Y>, T> getDictionary()
        {
            return dictionary;
        }

        public CoordinatedDictionary2D()
        {
            dictionary = new Dictionary<Point2D<X, Y>, T>();
        }

        //Insertion Methods
        public void Put(X x, Y y, T value)
        {
            Point2D<X, Y> point = new Point2D<X, Y>(x, y);
            dictionary[point] = value;
        }

        public void Put(Point2D<X, Y> point, T value)
        {
            dictionary[point] = value;
        }

        //Remove Methods
        public void Remove(X x, Y y)
        {
            Point2D<X, Y> point = new Point2D<X, Y>(x, y);
            dictionary.Remove(point);
        }


        //Search Methods
        //Devuelve default(T) si no encuentra la key
        public T TryGet(X x, Y y)
        {
            Point2D<X, Y> point = new Point2D<X, Y>(x, y);
            T value = default(T);
            if (dictionary.TryGetValue(point, out value))
            {
                return value;
            }
            return value;
        }

        public T TryGet(Point2D<X, Y> point)
        {
            T value = default(T);
            if (dictionary.TryGetValue(point, out value))
            {
                return value;
            }
            return value;
        }

        public T Get(X x, Y y)
        {
            Point2D<X, Y> point = new Point2D<X, Y>(x, y);
            return dictionary[point];
        }

        public List<T> GetInXToList(X x)
        {
            List<T> result = new List<T>();
            foreach (KeyValuePair<Point2D<X, Y>, T> pair in dictionary)
            {
                if (pair.Key.i.Equals(x))
                {
                    result.Add(pair.Value);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetInYToList(Y y)
        {
            List<T> result = new List<T>();
            foreach (KeyValuePair<Point2D<X, Y>, T> pair in dictionary)
            {
                if (pair.Key.j.Equals(y))
                {
                    result.Add(pair.Value);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }


        //Es rápido comparable con NestedDictionary
        public List<T> GetAllToList()
        {
            List<T> result = new List<T>();
            /*
            foreach (KeyValuePair<Point2D, T> pair in dictionary)
            {
                result.Add(pair.Value);
            }
            */

            result = dictionary.Values.ToList();

            //return (result.Count() > 0) ? result : null;
            return result;
        }

    }

}
