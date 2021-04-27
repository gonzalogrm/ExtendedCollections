using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedCollections
{
    public static class ExtensionMethods
    {
        public static bool CheckIsAsignable(Type derived, Type super)
        {
            return super.IsAssignableFrom(derived);
        }        

        public static bool CheckIsSubclass(Type derived, Type super)
        {
            return derived.GetType().IsSubclassOf(super.GetType());
        }

        public static bool CheckIsSubclass(object derived, object super)
        {
            return derived.GetType().IsSubclassOf(super.GetType());
        }

        public static char[] punctuationSigns =
            new char[] { '.', ',', ';', ')', ']', '}', '?', '!', '"' };

        //GENERIC
        /// <summary>
        /// Tries to cast object to the generic type T. Returns null if fails.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T GetAsT<T>(object o) where T : class
        {
            return o as T;
        }

        /*
        private static Target CopyProperties<Source, Target>(Source source, Target target)
        {
            foreach (var sProp in source.GetType().GetProperties())
            {
                bool isMatched = target.GetType().GetProperties().Any(tProp => tProp.Name == sProp.Name && tProp.GetType() == sProp.GetType() && tProp.CanWrite);
                if (isMatched)
                {
                    var value = sProp.GetValue(source);
                    PropertyInfo propertyInfo = target.GetType().GetProperty(sProp.Name);
                    propertyInfo.SetValue(target, value);
                }
            }
            return target;
        }
        */


        //STRING
        public static string GetSimplifiedWord(this string input)
        {
            string result = input.ToLower();

            foreach (var item in punctuationSigns)
            {
                if (result[result.Length-1]==item)
                {
                    return result.Remove(result.Length - 1, 1);
                }
            }

            return result;
        }


        //INT
        public static void LimitedIncrement(this int number, int limit){
            number = (number < limit) ? ++number : number;
        }

        public static void LimitedSum(this int number, int increment, int limit){
            number = ((number+increment) <= limit) ? number+increment : number;
        }

        //BYTE
        public static byte LimitedIncrement(this byte number, int limit){
            return number = (number < limit) ? number++ : number;
        }

        public static void LimitedSum(this byte number, byte increment, byte limit){
            number = ((number+increment) <= limit) ? (byte)(number+increment) : number;
        }

        //FLOAT
        public static float LimitedSum(this float number, float increment, byte limit){
            return number = ((number+increment) <= limit) ? number+increment : number;
        }

        //HASHSET
        public static bool AddRange<T>(this HashSet<T> source, IEnumerable<T> items)
        {
            bool allAdded = true;
            foreach (T item in items)
            {
                allAdded &= source.Add(item);
            }
            return allAdded;
        }

        public static List<T> HashToList<T>(this HashSet<T> source){
            List<T> result = new List<T>();
            foreach(T e in source){
                result.Add(e);
            }
            return result;
        }

        public static T GetRandomElement<T>(this HashSet<T> source){
            T result = default(T);
            Random randomizer = new Random();
            T[] asArray = source.ToArray();
            result = asArray[randomizer.Next(asArray.Length)];
            return result;
        }

        public static T GetRandomElement<T>(this HashSet<T> source, Random rng)
        {
            T result = default(T);
            T[] asArray = source.ToArray();
            result = asArray[rng.Next(asArray.Length)];
            return result;
        }

        public static void DumpElements<T>(this ICollection<T> target, ICollection<T> source){
            foreach(T element in source){
                target.Add(element);
            }
        }

        public static void DumpAndClearElements<T>(this ICollection<T> target, ICollection<T> source){
            foreach(T element in source){
                target.Add(element);
            }
            source.Clear();
        }

        public static void RemoveElements<T>(this ICollection<T> target, ICollection<T> source){
            foreach(T element in source){
                target.Remove(element);
            }
        }

        public static void RemoveAndClearElements<T>(this ICollection<T> target, ICollection<T> source){
            foreach(T element in source){
                target.Remove(element);
            }
            source.Clear();
        }


        //LIST
        public static bool AreAllElementsEqualInOrder<U>(this List<U> source, List<U> other) 
        {
            if (source.Count == other.Count)
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (!(source[i].Equals(other[i])))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static void Shuffle<T>(this IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<T> DeepCopy<T>(this List<T> source)
        {
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                result.Add(item);
            }
            return result;
        }

        public static string ListToString<U>(this List<U> source)
        {   
            return string.Join(",", source);
        }

        public static List<U> KeysToList<U,V>(this Dictionary<U,V> source){
            return new List<U>(source.Keys);
        }
        
        public static String DictionaryToString<U,V>(this Dictionary<U,V> source)
        {   
            string data = "";
            foreach(var e in source){
                data += $"{e.Key} | {e.Value}\n";
            }
            return data;
        }

        public static V GetFirst<U,V>(this Dictionary<U,V> source)
        {   
            return source.First().Value;
        }

        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof (T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if(p.CanWrite) { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }

            }
        }

        public static string ToMatrixString<T>(this T[,] matrix, string delimiter = "\t")
        {
            var s = new StringBuilder();

            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    s.Append(matrix[i, j]).Append(delimiter);
                }

                s.AppendLine();
            }

            return s.ToString();
        }

        //QUEUE
        public static T GetElementNotThis<T>(this Queue<T> source, T notThis) where T: class{
            int tries = 0;
            T result = source.Dequeue();

            while(result == notThis){
                tries++;
                if(tries == 10){
                    source.Enqueue(result);
                    return null;
                }

                source.Enqueue(result);
                result = source.Dequeue();                
            }

            return result;
        }
    }
}