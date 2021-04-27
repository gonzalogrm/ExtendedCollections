using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedCollections
{
    public class DelayedSet<T>  where T : class
    {
        public Random rng {get;set;}
        public HashSet<T> hashset {get;set;} = new HashSet<T>();
        private HashSet<T> delayedAdd = new HashSet<T>();
        private HashSet<T> delayedRemove = new HashSet<T>();

        public DelayedSet(int seed){
            rng = new Random(seed);
        }

        public bool Add(T input){
            bool res = false;
            return res;
        }

        public bool Remove(T input){
            bool res = false;
            return res;
        }

        public void ExecuteDelayedAdd(){
            hashset.DumpAndClearElements(delayedAdd);
        }

        public void ExecuteDelayedRemove(){
            hashset.RemoveAndClearElements(delayedRemove);
        }

        public bool InsertDelayedAdd(T input){
            return delayedAdd.Add(input);
        }

        public bool InsertDelayedRemove(T input){
            return delayedRemove.Add(input);
        }

    }

    public class DelayedSmartSet<T>  where T : class
    {
        public Random rng {get;set;}
        public HashSet<T> hashset {get;set;} = new HashSet<T>();
        private List<T> list = new List<T>();
        private HashSet<T> delayedAdd = new HashSet<T>();
        private HashSet<T> delayedRemove = new HashSet<T>();

        public DelayedSmartSet(int seed){
            rng = new Random(seed);
        }

        public bool Add(T input){
            bool res = false;

            if(hashset.Add(input)){
                res = true;
                list.Add(input);
            }

            return res;
        }

        public bool Remove(T input){
            bool res = false;

            if(hashset.Remove(input)){
                res = true;
                list.Remove(input);
            }

            return res;
        }

        public void ExecuteDelayedAdd(){
            list.DumpElements(delayedAdd);
            hashset.DumpAndClearElements(delayedAdd);
        }

        public void ExecuteDelayedRemove(){
            list.RemoveElements(delayedRemove);
            hashset.RemoveAndClearElements(delayedRemove);
        }

        public bool InsertDelayedAdd(T input){
            return delayedAdd.Add(input);
        }

        public bool InsertDelayedRemove(T input){
            return delayedRemove.Add(input);
        }

        public T GetRandomElementNotThis(T notThis){
            T found = default(T);
            int iter = 0;

            found = ListGetRandomElement();
            while(found == notThis){
                found = ListGetRandomElement();

                //Backstop
                iter++;
                if(iter == 10){
                    found = default(T);
                    break;
                }
            }

            return found;
        }

        private T ListGetRandomElement(){
            return list[rng.Next(0,list.Count)];
        }

    }

}