using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public class NestedDictionary<X,Y,T> : I2DCollection<X, Y, T>
    {
        //Attributes
        private Dictionary<X, Dictionary<Y, T>> nestedDictionary;

        //Constructors
        public NestedDictionary(){
            nestedDictionary = new Dictionary<X, Dictionary<Y, T>>();

            //Check if can be indexed with integers
            checkNumericViability();
        }

        public NestedDictionary(Dictionary<X, Dictionary<Y, T>> nestedDictionary)
        {
            this.nestedDictionary = nestedDictionary;
        }

        //Other Methods
        private void checkNumericViability()
        {
            if ((typeof(X) == typeof(int)) && (typeof(Y) == typeof(int)))
            {
                Console.WriteLine("TYPE INT");
            }
        }

        //Remove Methods
        public void Remove(X x, Y y)
        {
            Dictionary<Y, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                inner.Remove(y);
                if (inner.Count() == 0)
                    nestedDictionary.Remove(x);
            }
        }


        //Search Methods
        public T TryGet(X x, Y y)  
        {
            T value = default(T);
            Dictionary<Y, T> inner;
            if(nestedDictionary.TryGetValue(x, out inner))
            {
                if (inner.TryGetValue(y, out value))
                {
                    return value;
                }
            }
            return value;
        }

        public T Get(X x, Y y)
        {
            return nestedDictionary[x][y];
        }

        public NestedDictionary<X, Y, T> GetInXToNestedDictionary(X x)
        {
            NestedDictionary<X, Y, T> result = new NestedDictionary<X, Y, T>();
            Dictionary<Y, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                result.nestedDictionary[x] =  inner;
                return result;
            }
            return null;
        }

        public NestedDictionary<X, Y, T> GetInYToNestedDictionary(Y y)
        {
            NestedDictionary<X, Y, T> result = new NestedDictionary<X, Y, T>();
            //Búsqueda en X
            foreach (KeyValuePair<X, Dictionary<Y, T>> kv in nestedDictionary)
            {
                //Búsqueda en Y
                T innerValue;
                if (kv.Value.TryGetValue(y, out innerValue))
                {
                    Dictionary<Y, T> innerDict = new Dictionary<Y, T>();
                    innerDict[y] = innerValue;
                    result.nestedDictionary[kv.Key] = innerDict;
                }
            }
            return (result.nestedDictionary.Count() > 0 ) ? result : null;
        }

        public List<T> GetInXToList(X x)
        {
            List<T> result = new List<T>();
            Dictionary<Y, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                foreach (KeyValuePair<Y, T> kv in inner)
                {
                    result.Add(kv.Value);
                }
            }
            return (result.Count() > 0) ? result : null;
        }

        public List<T> GetInYToList(Y y)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<X, Dictionary<Y, T>> kv in nestedDictionary)
            {
                //Búsqueda en Y
                T innerValue;
                if (kv.Value.TryGetValue(y, out innerValue))
                {
                    result.Add(innerValue);
                }
            }
            return (result.Count() > 0) ? result : null;
        }

        public List<T> GetInAreaToList(int x1, int x2, int y1, int y2)
        {
            //Si las keys no son enteros devolver null
            if (nestedDictionary.Keys.First().GetType() != typeof(int))
            {
                return null;
            }

            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<X, Dictionary<Y, T>> outkv in nestedDictionary)
            {
                int x = (int)(object)outkv.Key;
                //Búsqueda en Y
                if (x >= x1 && x <= x2)
                {
                    foreach (KeyValuePair<Y, T> inkv in outkv.Value)
                    {
                        int y = (int)(object)inkv.Key;
                        //Búsqueda en Y
                        if (y >= y1 && y <= y2)
                        {
                            result.Add(inkv.Value);
                        }
                    }
                }
            }

            return (result.Count() > 0) ? result : null;
        }

        public List<T> GetAllToList()
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<X, Dictionary<Y, T>> outkv in nestedDictionary)
            {
                //Búsqueda en Y
                /*
                foreach (KeyValuePair<int, T> inkv in outkv.Value)
                {
                    result.Add(inkv.Value);
                }
                */
                result.AddRange(outkv.Value.Values.ToList());
            }

            //return (result.Count() > 0) ? result : null;
            return result;
        }

        //Insertion Methods
        public void Put(X x, Y y, T value)
        {
            Dictionary<Y, T> inner;
            if (!nestedDictionary.TryGetValue(x, out inner))
            {
                inner = new Dictionary<Y, T>();
                nestedDictionary[x] = inner;
            }
            inner[y] = value;
        }


        //Display Methods
        public List<T> GetListedValues()
        {
            var result = new List<T>();

            foreach (KeyValuePair<X, Dictionary<Y, T>> outerKV in nestedDictionary)
            {
                foreach (KeyValuePair<Y, T> innerKV in outerKV.Value)
                {
                    result.Add(innerKV.Value);
                }
            }
            return result;
        }

        public void PrintToConsole()
        {
            foreach (KeyValuePair<X, Dictionary<Y, T>> outerKV in nestedDictionary)
            {
                foreach (KeyValuePair<Y, T> innerKV in outerKV.Value)
                {
                    Console.WriteLine("("+outerKV.Key+","+ innerKV.Key+") --> " + innerKV.Value.ToString());
                }
            }
        }
    }

    public class NestedDictionary<T> : I2DCollection<T>
    {
        //Attributes
        private Dictionary<int, Dictionary<int, T>> nestedDictionary;
        private Dictionary<int, HashSet<int>> YtoXMap;


        //Constructors
        public NestedDictionary()
        {
            nestedDictionary = new Dictionary<int, Dictionary<int, T>>();
            YtoXMap = new Dictionary<int, HashSet<int>>();
        }

        //Insertion Methods
        public void Put(int x, int y, T value)
        {
            Dictionary<int, T> inner;
            if (!nestedDictionary.TryGetValue(x, out inner))
            {
                inner = new Dictionary<int, T>();
                nestedDictionary[x] = inner;
            }
            inner[y] = value;
            AddToYMap(y, x);
        }

        //Auxiliar Methods
        private void AddToYMap(int y, int x)
        {
            HashSet<int> inner;
            if (!YtoXMap.TryGetValue(y, out inner))
            {
                inner = new HashSet<int>();
                YtoXMap[y] = inner;
            }
            inner.Add(x);
        }


        /// <summary>
        /// Removes from auxiliarDictionary cheking keys
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void RemoveFromYMap(int y, int x)
        {
            HashSet<int> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                inner.Remove(x);
                if (YtoXMap[y].Count == 0)
                    YtoXMap.Remove(y);
            }
        }

        /// <summary>
        /// Removes from auxiliarDictionary without cheking keys
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void RemoveFromYMapUnchecked(int y, int x)
        {
            YtoXMap[y].Remove(x);
            if (YtoXMap[y].Count == 0)
                YtoXMap.Remove(y);
        }

        //Remove Methods       
        public void Remove(int x, int y)
        {
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                inner.Remove(y);
                if (inner.Count == 0)
                    nestedDictionary.Remove(x);
                RemoveFromYMap(y, x);
            }
        }

        /// <summary>
        /// Used by other Removal Mehtods. Removes from nestedDictionary and auxiliarDictionary without cheking keys
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void RemoveUnchecked(int x, int y)
        {
            Dictionary<int, T> inner = nestedDictionary[x];
            inner.Remove(y);
            if (inner.Count == 0)
                nestedDictionary.Remove(x);
            RemoveFromYMapUnchecked(y, x);
        }

        public void RemoveConstantY(int x1, int x2, int y)
        {
            HashSet<int> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                foreach (int x in new List<int>(inner))
                {
                    if (x >= x1 && x <= x2)
                        RemoveUnchecked(x, y);
                }
            }
        }

        public void RemoveAllConstantY(int y)
        {
            HashSet<int> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                foreach (int x in new List<int>(inner))
                {
                    RemoveUnchecked(x, y);
                }
            }
        }

        public void RemoveConstantX(int x, int y1, int y2)
        {
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                //Dictionary<int, T> innerCopy = new Dictionary<int, T>(inner);
                foreach (KeyValuePair<int, T> kv in
                    new Dictionary<int, T>(inner))
                {
                    if (kv.Key >= y1 && kv.Key <= y2)
                    {
                        RemoveUnchecked(x, kv.Key);
                    }
                }
            }
        }

        public void RemoveAllConstantX(int x)
        {
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                //Dictionary<int, T> innerCopy = new Dictionary<int, T>(inner);
                foreach (KeyValuePair<int, T> kv in new Dictionary<int, T>(inner))
                {
                    RemoveUnchecked(x, kv.Key);
                }
            }
        }

        public void RemoveInArea(int x1, int x2, int y1, int y2)
        {
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> outkv
                in new Dictionary<int, Dictionary<int, T>>(nestedDictionary))
            {
                //Búsqueda en Y
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<int, T> inkv in new Dictionary<int, T>(outkv.Value))
                    {
                        if (inkv.Key >= y1 && inkv.Key <= y2)
                        {
                            RemoveUnchecked(outkv.Key, inkv.Key);
                        }
                    }
                }
            }
        }


        //Search Methods
        public int CountExternalKeys()
        {
            return nestedDictionary.Count;
        }

        public int CountInternalYKeysInX(int x)
        {
            return (nestedDictionary.ContainsKey(x)) ? nestedDictionary[x].Count : 0;
        }

        public int CountInternalXKeysInY(int y)
        {
            return nestedDictionary[y].Count;
        }

        public int CountTotal()
        {
            return nestedDictionary.Count * YtoXMap.Count;
        }

        public bool CheckXContainsY(int x, int y)
        {
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                return inner.ContainsKey(y);
            }
            return false;
        }

        public bool CheckYContainsX(int x, int y)
        {
            HashSet<int> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                return inner.Contains(x);
            }
            return false;
        }

        //No lanza excepciones, devuelve default(T)
        public T TryGet(int x, int y)
        {
            T value = default(T);
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                if (inner.TryGetValue(y, out value))
                {
                    return value;
                }
            }
            return value;
        }

        public T Get(int x, int y)
        {
            return nestedDictionary[x][y];
        }

        public NestedDictionary<T> GetInXToNestedDictionary(int x)
        {
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                NestedDictionary<T> result = new NestedDictionary<T>();
                result.nestedDictionary[x] = inner;
                return result;
            }
            return null;
        }

        public Dictionary<int, T> GetInXToDictionary(int x)
        {
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                return inner;
            }
            return null;
        }

        public NestedDictionary<T> GetInYToNestedDictionary(int y)
        {
            NestedDictionary<T> result = new NestedDictionary<T>();
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> kv in nestedDictionary)
            {
                //Búsqueda en Y
                T innerValue;
                if (kv.Value.TryGetValue(y, out innerValue))
                {
                    Dictionary<int, T> innerDict = new Dictionary<int, T>();
                    innerDict[y] = innerValue;
                    result.nestedDictionary[kv.Key] = innerDict;
                }
            }
            return (result.nestedDictionary.Count > 0) ? result : null;
        }

        public List<T> GetInXToList(int x)
        {
            List<T> result = new List<T>();
            Dictionary<int, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                result = inner.Values.ToList();
            }
            return result;
        }

        public List<T> GetInYToList(int y)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> kv in nestedDictionary)
            {
                //Búsqueda en Y
                T innerValue;
                if (kv.Value.TryGetValue(y, out innerValue))
                {
                    result.Add(innerValue);
                }
            }
            return result;
        }

        //Más rápido que GetInYToList cuando hay pocos valores de X asociados a Y
        //Igual de rápido que GetInYToList cuando hay muchos valores de X asociados a un Y
        public List<T> GetInYToList_Auxiliar(int y)
        {
            List<T> result = new List<T>();

            HashSet<int> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                foreach (int x in inner)
                {
                    result.Add(nestedDictionary[x][y]);
                }
            }
            return result;
        }

        //Contains es lento si se hacen muchas iteraciones
        //Más rápido que GetAnyInArea en subáreas pequeñas 50x50 aprox
        public List<T> GetAnyInAreaToListContains(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();
            Dictionary<int, T> inner;
            //Búsqueda en X
            for (int i = x1; i <= x2; i++)
            {
                if (nestedDictionary.ContainsKey(i))
                {
                    //Búsqueda en Y
                    inner = nestedDictionary[i];
                    for (int j = y1; j <= y2; j++)
                    {
                        if (inner.ContainsKey(j))
                            result.Add(inner[j]);
                    }
                }
            }
            return result;
        }

        public List<T> GetAnyInAreaToList(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> outkv in nestedDictionary)
            {
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<int, T> inkv in outkv.Value)
                    {
                        //Búsqueda en Y
                        if (inkv.Key >= y1 && inkv.Key <= y2)
                        {
                            result.Add(inkv.Value);
                        }
                    }
                }
            }
            return result;
        }

        public List<T> GetAnyInAreaToListNotNull(int x1, int x2, int y1, int y2)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> outkv in nestedDictionary)
            {
                //Búsqueda en Y
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<int, T> inkv in outkv.Value)
                    {
                        //Búsqueda en Y
                        if (inkv.Key >= y1 && inkv.Key <= y2)
                        {
                            if (inkv.Value != null)
                            {
                                result.Add(inkv.Value);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public List<T> GetAllToList()
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> outkv in nestedDictionary)
            {
                result.AddRange(outkv.Value.Values.ToList());
            }
            return result;
        }

        public List<T> GetSearchedInAreaToList(int x1, int x2, int y1, int y2, T searched)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<int, Dictionary<int, T>> outkv in nestedDictionary)
            {
                //Búsqueda en Y
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<int, T> inkv in outkv.Value)
                    {
                        //Búsqueda en Y
                        if (inkv.Key >= y1 && inkv.Key <= y2)
                        {
                            if (inkv.Value.Equals(searched))
                            {
                                result.Add(inkv.Value);
                            }
                        }
                    }
                }
            }
            return result;
        }


        //Display Methods
        public List<T> GetListedValues()
        {
            var result = new List<T>();

            foreach (KeyValuePair<int, Dictionary<int, T>> outerKV in nestedDictionary)
            {
                foreach (KeyValuePair<int, T> innerKV in outerKV.Value)
                {
                    result.Add(innerKV.Value);
                }
            }
            return result;
        }

        public void PrintToConsole()
        {
            foreach (KeyValuePair<int, Dictionary<int, T>> outerKV in nestedDictionary)
            {
                foreach (KeyValuePair<int, T> innerKV in outerKV.Value)
                {
                    Console.WriteLine("(" + outerKV.Key + "," + innerKV.Key + ") --> " + innerKV.Value.ToString());
                }
            }
        }

        public string PrintXtoYKeysToConsole()
        {
            string print = "";
            foreach (KeyValuePair<int, Dictionary<int, T>> outerKV in nestedDictionary)
            {
                print += "(" + outerKV.Key + "): ";
                foreach (KeyValuePair<int, T> innerKV in outerKV.Value)
                {
                    print += innerKV.Key + " , ";
                }
                print += "\n";
            }
            return print;
        }

        public string PrintYtoXKeysToConsole()
        {
            string print = "";
            foreach (KeyValuePair<int, HashSet<int>> outerKV in YtoXMap)
            {
                print += "(" + outerKV.Key + "): ";
                foreach (int innerKV in outerKV.Value)
                {
                    print += innerKV + " , ";
                }
                print += "\n";
            }
            return print;
        }
    }
}
