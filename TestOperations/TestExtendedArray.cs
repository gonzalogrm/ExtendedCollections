using ExtendedCollections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections.TestOperations
{
    class TestExtendedArray
    {
        public static ExtendedArray<List<int>> arr;
        public static ExtendedJaggedArray<List<int>> arrJag;

        public static void GenerateArray(int x, int y, int modX, int modY)
        {
            arr = new ExtendedArray<List<int>>(x, y);
            int total = 0;
            List<int> ls = new List<int> {
                new int(),
                new int(),
                new int(),
            };

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i % modX == 0 && j % modY == 0)
                    {
                        total++;
                        arr.Put(i, j, ls);
                    }
                }
            }
            Console.WriteLine("GENERATION ARRAY TOTAL: " + total);
        }

        public static void GenerateJaggedArray(int x, int y, int modX, int modY)
        {
            arrJag = new ExtendedJaggedArray<List<int>>(x, y);
            int total = 0;
            List<int> ls = new List<int> {
                new int(),
                new int(),
                new int(),
            };

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i % modX == 0 && j % modY == 0)
                    {
                        total++;
                        arrJag.Put(i, j, ls);
                    }
                }
            }
            Console.WriteLine("GENERATION ARRAY TOTAL: " + total);
        }

        public static void ExecuteTest()
        {
            Stopwatch sw = new Stopwatch();
            ExtendedArray<int> arr = new ExtendedArray<int>(500,500);
            List<int> res;

            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        arr.Put(i, j, 1);
                    }
                    else
                    {
                        arr.Put(i, j, -1);
                    }
                }
            }

            //Console.WriteLine("PRINT NESTED DICTIONARY");
            //numDict.PrintToConsole();

            Console.WriteLine("SEARCH IN AREA (ARRAY)");
            sw.Start();
            res = arr.GetAnyInAreaToList(0, 499, 0, 499);
            sw.Stop();
            Console.WriteLine("ARRAY SEARCH TIME: " + sw.ElapsedMilliseconds);

            /*
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            */


            //Console.WriteLine("Waiting Input to End test.");
            //Console.ReadLine();

        }

        public static void ExecuteTest2()
        {
            //Warming
            arr.GetAnyInAreaToListNotNull(0, 119, 0, 59);
            GC.Collect();

            Stopwatch sw = new Stopwatch();           
            List<List<int>> res;            

            Console.WriteLine("SEARCH IN AREA (ARRAY)");
            sw.Start();
            arr.GetAnyInAreaToList(0, 119, 0, 59);
            
            //Console.WriteLine("Found: " + res.Count);
            sw.Stop();
            Console.WriteLine("ARRAY SEARCH TICKS: " + sw.ElapsedTicks);
        }

        public static void ExecuteTest2_NotNull(int x, int y)
        {
            Stopwatch sw = new Stopwatch();
            //List<List<int>> res;
            //List<int> first;

            Console.WriteLine("SEARCH IN AREA Not Null(ARRAY)");
            sw.Start();
            arr.GetAnyInAreaToListNotNull(0, x, 0, y);
            //first = res.First();

            //Console.WriteLine("Found: " + res.Count);
            sw.Stop();
            Console.WriteLine("ARRAY SEARCH TICKS: " + sw.ElapsedTicks);
        }

        public static void Execute_GetAll_Jagged_NotNull(bool isConstantSize)
        {
            //Warming
            arrJag.GetAllToListNotNull(isConstantSize);
            GC.Collect();

            Stopwatch sw = new Stopwatch();
            List<List<int>> res;
            List<int> first;

            sw.Start();
            res = arrJag.GetAllToListNotNull(isConstantSize);
            sw.Stop();
            first = res.First();

            //Console.WriteLine("Found: " + res.Count);            
            Console.WriteLine(sw.ElapsedTicks);
        }

        public static void Execute_FindAll_Jagged_NotNull()
        {
            //Warming
            arrJag.FindAllToListNotNull();
            GC.Collect();

            Stopwatch sw = new Stopwatch();
            List<List<int>> res;
            List<int> first;

            sw.Start();
            res = arrJag.FindAllToListNotNull();
            sw.Stop();
            first = res.First();

            //Console.WriteLine("Found: " + res.Count);            
            Console.WriteLine(sw.ElapsedTicks);
        }

        public static void Execute_GetAnyInArea_Jagged_NotNull(int x0, int x1, int y0, int y1)
        {
            //Warming
            arrJag.GetAnyInAreaToListNotNull(x0, x1, y0, y1);
            GC.Collect();

            Stopwatch sw = new Stopwatch();
            List<List<int>> res;
            List<int> first;

            sw.Start();
            res = arrJag.GetAnyInAreaToListNotNull(x0, x1, y0, y1);
            sw.Stop();
            first = res.First();

            //Console.WriteLine("Found: " + res.Count);            
            Console.WriteLine(sw.ElapsedTicks);
        }

        public static void Execute_GetAnyInArea_Jagged_NotNull_FIXED()
        {
            List<List<int>> res;
            List<int> first;
            res = arrJag.GetAnyInAreaToListNotNull(200, 249, 200, 249);
            first = res.First();
        }

        public static void ExecuteTest2_NotNull_NOSW()
        {
            List<List<int>> res;
            res = arr.GetAnyInAreaToListNotNull(0, 119, 0, 59);
            //Console.WriteLine("Found: " + res.Count);
            //arr.GetAnyInAreaToListNotNull(0, 119, 0, 59);
        }

        public static void ExecuteTestGet()
        {
            for (int i = 0; i < 20; i++)
            {
                List<int> res = arr.Get(i, i);
            }
        }
    }
}
