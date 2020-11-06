using ExtendedCollections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections.TestOperations
{
    class TestExtendedArrayToProfile
    {
        public static int sizeX, sizeY, modX, modY;
        public static int sX1, sX2, sY1, sY2;
        public static bool showConsoleLog = false;

        public static void SetSizes(int x, int y, int mx, int my)
        {
            sizeX = x;
            sizeY = y;
            modX = mx;
            modY = my;
        }

        public static void SetSearchArea(int x1, int x2, int y1, int y2)
        {
            sX1 = x1;
            sX2 = x2;
            sY1 = y1;
            sY2 = y2;
        }

        public static ExtendedArray<List<int>> arr;
        public static ExtendedJaggedArray<List<int>> arrJag;

        public static void GenerateArray()
        {
            arr = new ExtendedArray<List<int>>(sizeX, sizeY);
            int total = 0;
            List<int> ls = new List<int> {
                new int(),
                new int(),
                new int(),
            };

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
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

        public static void GenerateJaggedArray()
        {
            arrJag = new ExtendedJaggedArray<List<int>>(sizeX, sizeY);
            int total = 0;
            List<int> ls = new List<int> {
                new int(),
                new int(),
                new int(),
            };

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
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

        public static void Execute_GetAll_Jagged_NotNull()
        {
            List<List<int>> res;
            List<int> first;
            res = arrJag.GetAllToListNotNull(true);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_FindAll_Jagged_NotNull()
        {
            List<List<int>> res;
            List<int> first;
            res = arrJag.FindAllToListNotNull();
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_GetAnyInArea_Jagged_NotNull()
        {
            List<List<int>> res;
            List<int> first;

            res = arrJag.GetAnyInAreaToListNotNull(sX1, sX2, sY1, sY2);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
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
