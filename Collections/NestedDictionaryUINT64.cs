using System;
using System.Collections.Generic;


namespace ByblosCore.DataStructures
{
    public class NestedDictionaryUINT64<T> : I2DCollectionUINT64<T>
    {
        //Attributes
        private Dictionary<ulong, Dictionary<ulong, T>> nestedDictionary;
        private Dictionary<ulong, HashSet<ulong>> YtoXMap;

        //Constructors
        public NestedDictionaryUINT64()
        {
            nestedDictionary = new Dictionary<ulong, Dictionary<ulong, T>>();
            YtoXMap = new Dictionary<ulong, HashSet<ulong>>();
        }


        //Insertion Methods
        public void Put(ulong x, ulong y, T value)
        {
            Dictionary<ulong, T> inner;
            if (!nestedDictionary.TryGetValue(x, out inner))
            {
                inner = new Dictionary<ulong, T>();
                nestedDictionary[x] = inner;
            }
            inner[y] = value;
            AddToYMap(y, x);
        }

        //Auxiliar Methods
        private void AddToYMap(ulong y, ulong x)
        {
            HashSet<ulong> inner;
            if (!YtoXMap.TryGetValue(y, out inner))
            {
                inner = new HashSet<ulong>();
                YtoXMap[y] = inner;
            }
            inner.Add(x);
        }

        /// <summary>
        /// Removes from auxiliarDictionary cheking keys
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void RemoveFromYMap(ulong y, ulong x)
        {
            HashSet<ulong> inner;
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
        private void RemoveFromYMapUnchecked(ulong y, ulong x)
        {
            YtoXMap[y].Remove(x);
            if (YtoXMap[y].Count == 0)
                YtoXMap.Remove(y);
        }

        //Remove Methods
        public void Remove(ulong x, ulong y)
        {
            Dictionary<ulong, T> inner;
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
        private void RemoveUnchecked(ulong x, ulong y)
        {
            Dictionary<ulong, T> inner = nestedDictionary[x];
            inner.Remove(y);
            if (inner.Count == 0)
                nestedDictionary.Remove(x);
            RemoveFromYMapUnchecked(y, x);
        }

        public void RemoveConstantY(ulong x1, ulong x2, ulong y)
        {
            HashSet<ulong> xvalues;
            if (YtoXMap.TryGetValue(y, out xvalues))
            {
                foreach (ulong x in new List<ulong>(xvalues))
                {
                    if (x >= x1 && x <= x2)
                        RemoveUnchecked(x, y);
                }
            }
        }

        public void RemoveConstantYOld(ulong x1, ulong x2, ulong y)
        {
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv 
                in nestedDictionary)
            {
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    //Búsqueda en Y
                    if (outkv.Value.ContainsKey(y))
                        RemoveUnchecked(outkv.Key, y);
                }
            }
        }

        public void RemoveAllConstantY(ulong y)
        {
            HashSet<ulong> xvalues;
            if (YtoXMap.TryGetValue(y, out xvalues))
            {
                foreach (ulong x in new List<ulong>(xvalues))
                {
                    RemoveUnchecked(x, y);
                }
            }
        }

        public void RemoveConstantX(ulong x, ulong y1, ulong y2)
        {
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                //Dictionary<int, T> innerCopy = new Dictionary<int, T>(inner);
                foreach (KeyValuePair<ulong, T> kv in 
                    new Dictionary<ulong, T>(inner))
                {
                    if (kv.Key >= y1 && kv.Key <= y2)
                    {
                        RemoveUnchecked(x, kv.Key);
                    }
                }
            }
        }

        public void RemoveConstantXOld(ulong x, ulong y1, ulong y2)
        {
            //Búsqueda en Y
            foreach (KeyValuePair<ulong, HashSet<ulong>> outkv in YtoXMap)
            {
                if (outkv.Key >= y1 && outkv.Key <= y2)
                {
                    //Búsqueda en X
                    if (outkv.Value.Contains(x))
                    {
                        RemoveUnchecked(x, outkv.Key);
                    }
                }
            }
        }

        public void RemoveAllConstantX(ulong x)
        {
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                //Dictionary<int, T> innerCopy = new Dictionary<int, T>(inner);
                foreach (KeyValuePair<ulong, T> kv in new Dictionary<ulong, T>(inner))
                {
                    RemoveUnchecked(x, kv.Key);
                }
            }
        }

        public void RemoveInArea(ulong x1, ulong x2, ulong y1, ulong y2)
        {
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv in 
                new Dictionary<ulong, Dictionary<ulong, T>>(nestedDictionary))
            {
                //Búsqueda en Y
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<ulong, T> inkv in new Dictionary<ulong, T>(outkv.Value))
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

        public int CountInternalYKeysInX(ulong x)
        {
            return (nestedDictionary.ContainsKey(x)) ? nestedDictionary[x].Count : 0;
        }

        public int CountInternalXKeysInY(ulong y)
        {
            return nestedDictionary[y].Count;
        }

        public int CountTotal()
        {
            return nestedDictionary.Count * YtoXMap.Count;
        }

        public int CountTotalOLD()
        {
            int result = 0;
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv in nestedDictionary)
            {
                result += CountInternalYKeysInX(outkv.Key);
            }
            return result;
        }

        public bool CheckXContainsY(ulong x, ulong y)
        {
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                return inner.ContainsKey(y);
            }
            return false;
        }

        public bool CheckYContainsX(ulong x, ulong y)
        {
            HashSet<ulong> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                return inner.Contains(x);
            }
            return false;
        }

        //No lanza excepciones, devuelve default(T)
        public T TryGet(ulong x, ulong y)
        {
            T value = default(T);
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                if (inner.TryGetValue(y, out value))
                {
                    return value;
                }
            }
            return value;
        }

        public T Get(ulong x, ulong y)
        {
            return nestedDictionary[x][y];
        }

        public NestedDictionaryUINT64<T> GetInXToNestedDictionary(ulong x)
        {            
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                NestedDictionaryUINT64<T> result = new NestedDictionaryUINT64<T>();
                result.nestedDictionary[x] = inner;
                return result;
            }
            return null;
        }

        public Dictionary<ulong, T> GetInXToDictionary(ulong x)
        {
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                return inner;
            }
            return null;
        }

        public NestedDictionaryUINT64<T> GetInYToNestedDictionary(ulong y)
        {
            NestedDictionaryUINT64<T> result = new NestedDictionaryUINT64<T>();
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> kv in nestedDictionary)
            {
                //Búsqueda en Y
                T innerValue;
                if (kv.Value.TryGetValue(y, out innerValue))
                {
                    Dictionary<ulong, T> innerDict = new Dictionary<ulong, T>();
                    innerDict[y] = innerValue;
                    result.nestedDictionary[kv.Key] = innerDict;
                }
            }
            return (result.nestedDictionary.Count > 0) ? result : null;
        }

        public List<T> GetInXToList(ulong x)
        {
            List<T> result = new List<T>();
            Dictionary<ulong, T> inner;
            if (nestedDictionary.TryGetValue(x, out inner))
            {
                foreach (KeyValuePair<ulong, T> kv in inner)
                {
                    result.Add(kv.Value);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetInYToList(ulong y)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> kv in nestedDictionary)
            {
                //Búsqueda en Y
                T innerValue;
                if (kv.Value.TryGetValue(y, out innerValue))
                {
                    result.Add(innerValue);
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        //Más rápido que GetInYToList cuando hay pocos valores de X asociados a Y
        //Igual de rápido que GetInYToList cuando hay muchos valores de X asociados a un Y
        public List<T> GetInYToList_Auxiliar(ulong y)
        {
            List<T> result = new List<T>();

            HashSet<ulong> inner;
            if (YtoXMap.TryGetValue(y, out inner))
            {
                foreach (ulong x in inner)
                {
                    result.Add(nestedDictionary[x][y]);
                }
            }
            return result;
        }

        //Contains es lento si se hacen muchas iteraciones
        //Más rápido que GetAnyInArea en subáreas pequeñas 50x50 aprox
        public List<T> GetAnyInAreaToListContains(ulong x1, ulong x2, ulong y1, ulong y2)
        {
            List<T> result = new List<T>();
            Dictionary<ulong, T> inner;
            //Búsqueda en X
            for (ulong i = x1; i <= x2; i++)
            {
                if (nestedDictionary.ContainsKey(i))
                {
                    //Búsqueda en Y
                    inner = nestedDictionary[i];
                    for (ulong j = y1; j <= y2; j++)
                    {
                        if (inner.ContainsKey(j))
                            result.Add(inner[j]);
                    }
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAnyInAreaToList(ulong x1, ulong x2, ulong y1, ulong y2)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv in nestedDictionary)
            {
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<ulong, T> inkv in outkv.Value)
                    {
                        //Búsqueda en Y
                        if (inkv.Key >= y1 && inkv.Key <= y2)
                        {
                            result.Add(inkv.Value);
                        }
                    }
                }
            }
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAnyInAreaToListNotNull(ulong x1, ulong x2, ulong y1, ulong y2)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv in nestedDictionary)
            {
                //Búsqueda en Y
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<ulong, T> inkv in outkv.Value)
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
            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetAllToList()
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv in nestedDictionary)
            {
                //Búsqueda en Y
                foreach (KeyValuePair<ulong, T> inkv in outkv.Value)
                {
                    result.Add(inkv.Value);
                }
            }

            //return (result.Count() > 0) ? result : null;
            return result;
        }

        public List<T> GetSearchedInAreaToList(ulong x1, ulong x2, ulong y1, ulong y2, T searched)
        {
            List<T> result = new List<T>();
            //Búsqueda en X
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outkv in nestedDictionary)
            {
                //Búsqueda en Y
                if (outkv.Key >= x1 && outkv.Key <= x2)
                {
                    foreach (KeyValuePair<ulong, T> inkv in outkv.Value)
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
            //return (result.Count() > 0) ? result : null;
            return result;
        }


        //Display Methods
        public List<T> GetListedValues()
        {
            var result = new List<T>();

            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outerKV in nestedDictionary)
            {
                foreach (KeyValuePair<ulong, T> innerKV in outerKV.Value)
                {
                    result.Add(innerKV.Value);
                }
            }
            return result;
        }

        public void PrintToConsole()
        {
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outerKV in nestedDictionary)
            {
                foreach (KeyValuePair<ulong, T> innerKV in outerKV.Value)
                {
                    Console.WriteLine("(" + outerKV.Key + "," + innerKV.Key + ") --> " + innerKV.Value.ToString());
                }
            }
        }

        public string PrintXtoYKeysToConsole()
        {
            string print = "";
            foreach (KeyValuePair<ulong, Dictionary<ulong, T>> outerKV in nestedDictionary)
            {
                print += "(" + outerKV.Key + "): ";
                foreach (KeyValuePair<ulong, T> innerKV in outerKV.Value)
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
            foreach (KeyValuePair<ulong, HashSet<ulong>> outerKV in YtoXMap)
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
