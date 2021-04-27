using ExtendedCollections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections.TestOperations
{
    class TestNestedDictionaryToProfile
    {
        public static int sizeX, sizeY, modX, modY;
        public static int sX1, sX2, sY1, sY2;
        public static int sHor, sVer;
        public static bool showConsoleLog = false;

        public static NestedDictionary<List<int>> numDict;
        public static CoordinatedDictionary2D<List<int>> coordDict;

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

        public static void SetSearchXY(int X, int Y)
        {
            sVer = X;
            sHor = Y;
        }

        public static void GenerateDictionary()
        {
            numDict = new NestedDictionary<List<int>>();
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
                        numDict.Put(i, j, ls);
                    }
                }
            }
            Console.WriteLine("GENERATION DICTIONARY TOTAL: " + total);
        }

        public static void GenerateCoordinatedDictionary()
        {
            coordDict = new CoordinatedDictionary2D<List<int>>();
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
                        coordDict.Put(i, j, ls);
                    }
                }
            }
            Console.WriteLine("GENERATION DICTIONARY TOTAL: " + total);
        }

        //TEST Nested Dictionary
        public static void ExecuteTest()
        {
            List<string> res;
            NestedDictionary<int, int, List<String>> nd;
            nd = new NestedDictionary<int, int, List<string>>();

            try {
                Console.WriteLine("\nPUT METHODS");
                res = nd.TryGet(0, 0);
                nd.Put(0, 0, new List<string>());
                res = nd.TryGet(0, 0);
                res.Add("0,0 -> A");

                Console.WriteLine("\nReading:");
                foreach (String s in nd.TryGet(0, 0))
                {
                    Console.WriteLine(s);
                }

                res.Add("0,0 -> B");

                Console.WriteLine("\nReading:");
                foreach (String s in nd.TryGet(0, 0))
                {
                    Console.WriteLine(s);
                }

                nd.Put(0, 0, new List<string>());
                res = nd.TryGet(0, 0);
                res.Add("0,0 -> C");

                Console.WriteLine("\nReading:");
                foreach (String s in nd.TryGet(0, 0))
                {
                    Console.WriteLine(s);
                }


                Console.WriteLine("\n######");

                nd.Put(1, 1, new List<string> { "1,1" });
                nd.Put(1, 2, new List<string> { "1,2" });
                nd.Put(1, 3, new List<string> { "1,3" });
                nd.Put(2, 1, new List<string> { "2,1" });
                nd.Put(2, 2, new List<string> { "2,2" });

                var resX1 = nd.GetInXToNestedDictionary(1);                
                var resX2 = nd.GetInXToNestedDictionary(2);                
                var resY1 = nd.GetInYToNestedDictionary(1);                
                var resY2 = nd.GetInYToNestedDictionary(2);

                Console.WriteLine("\nPRINT DICTIONARY METHODS");
                resX1.PrintToConsole();
                resX2.PrintToConsole();
                resY1.PrintToConsole();
                resY2.PrintToConsole();

                var resListX1 = nd.GetInXToList(1);
                var resListX2 = nd.GetInXToList(2);
                var resListY1 = nd.GetInYToList(1);
                var resListY2 = nd.GetInYToList(2);

                Console.WriteLine("\nNESTED DICTIONARY SEARCH METHODS");
                Console.WriteLine("\n######");
                foreach (List<string> i in resX1.GetListedValues())
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }
                Console.WriteLine("\n######");
                foreach (List<string> i in resX2.GetListedValues())
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }
                Console.WriteLine("\n######");
                foreach (List<string> i in resY1.GetListedValues())
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }
                Console.WriteLine("\n######");
                foreach (List<string> i in resY2.GetListedValues())
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }


                Console.WriteLine("\nNESTED DICTIONARY LIST METHODS");
                Console.WriteLine("\n######");
                foreach (List<string> i in resListX1)
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }
                Console.WriteLine("\n######");
                foreach (List<string> i in resListX2)
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }
                Console.WriteLine("\n######");
                foreach (List<string> i in resListY1)
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }
                Console.WriteLine("\n######");
                foreach (List<string> i in resListY2)
                {
                    foreach (string j in i)
                    {
                        Console.WriteLine(j);
                    }
                }


                //Console.WriteLine(res.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION");
            }

            Console.WriteLine("Waiting Input to End test.");
            Console.ReadLine();
        }

        public static void Execute_GetAnyInArea()
        {
            List<List<int>> res;
            List<int> first;
            res = numDict.GetAnyInAreaToList(sX1, sX2, sY1, sY2);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_GetAnyInArea_Contains()
        {
            List<List<int>> res;
            List<int> first;
            res = numDict.GetAnyInAreaToListContains(sX1, sX2, sY1, sY2);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_GetAll()
        {
            List<List<int>> res;
            List<int> first;

            res = numDict.GetAllToList();
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_GetAll_X()
        {

            List<List<int>> res;
            List<int> first;

            res = numDict.GetInXToList(sVer);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_GetAll_Y()
        {
            List<List<int>> res;
            List<int> first;

            res = numDict.GetInYToList(sHor);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_GetAll_Y_Auxiliar()
        {
            List<List<int>> res;
            List<int> first;

            res = numDict.GetInYToList_Auxiliar(sHor);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_Put()
        {
            List<int> ls = new List<int> {
                new int(),
                new int(),
                new int(),
            };

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    numDict.Put(i, j, ls);
                }
            }
            if (showConsoleLog)
                Console.WriteLine("Found: " + numDict.CountTotal());            
        }

        public static void Execute_Get()
        {
            List<int> res=null;
            for (int i = 0; i < 100; i++)
            {
                res = numDict.TryGet(i, i);
            }
            //Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_InsertionRemovalText()
        {
            NestedDictionary<int> numDict;
            numDict = new NestedDictionary<int>();

            numDict.Put(0, 0, 1);
            numDict.Put(0, 2, 1);
            numDict.Put(1, 0, 1);
            numDict.Put(1, 4, 1);
            numDict.Put(5, 6, 1);

            Console.WriteLine("\nPRINT DICT");
            Console.WriteLine(numDict.PrintXtoYKeysToConsole());
            Console.WriteLine("\nPRINT AUX");
            Console.WriteLine(numDict.PrintYtoXKeysToConsole());

            List<int> res = numDict.GetAnyInAreaToList(0, 10, 0, 10);
            Console.WriteLine(res.Count());

            numDict.Remove(2, 2);
            Console.WriteLine("EXTERNAL KEYS: " + numDict.CountExternalKeys());
            numDict.Remove(0, 0);
            numDict.Remove(0, 2);
            numDict.Remove(1, 0);
            Console.WriteLine("EXTERNAL KEYS: " + numDict.CountExternalKeys());
            numDict.Remove(1, 4);
            numDict.Put(0, 0, 1);
            Console.WriteLine("EXTERNAL KEYS: " + numDict.CountExternalKeys());

            Console.WriteLine("\nPRINT DICT");
            Console.WriteLine(numDict.PrintXtoYKeysToConsole());
            Console.WriteLine("\nPRINT AUX");
            Console.WriteLine(numDict.PrintYtoXKeysToConsole());

            res = numDict.GetAnyInAreaToList(0, 10, 0, 10);
            Console.WriteLine(res.Count());
        }

        public static void Execute_InsertionRemovalHorizontal()
        {
            Stopwatch sw = new Stopwatch();
            NestedDictionary<int> numDict;
            numDict = new NestedDictionary<int>();

            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    if ((i + j) % 4 == 0)
                    {
                        numDict.Put(i, j, 9);
                    }
                }
            }

            List<int> res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("BEFORE REMOVAL: " + res.Count());

            sw.Start();
            numDict.RemoveHorizontal(0, 300, 50);
            sw.Stop();
            Console.WriteLine("REMOVE ALL HORIZONTAL (WITH AUXILIAR) TICKS: " + sw.ElapsedTicks);
                        
            res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("AFTER REMOVAL: " + res.Count());

            //////////////////////////////////////////////////////////////////////

            numDict = new NestedDictionary<int>();

            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    if ((i + j) % 4 == 0)
                    {
                        numDict.Put(i, j, 9);
                    }
                }
            }

            res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("BEFORE REMOVAL: " + res.Count());

            sw.Reset();
            sw.Start();
            numDict.RemoveHorizontalOld(0,300,50);
            sw.Stop();
            Console.WriteLine("REMOVE ALL HORIZONTAL 1 TICKS: " + sw.ElapsedTicks);


            res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("AFTER REMOVAL: " + res.Count());
        }

        public static void Execute_InsertionRemovalVertical()
        {
            Stopwatch sw = new Stopwatch();
            NestedDictionary<int> numDict;
            numDict = new NestedDictionary<int>();

            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    if ((i + j) % 4 == 0)
                    {
                        numDict.Put(i, j, 9);
                    }
                }
            }

            List<int> res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("BEFORE REMOVAL: " + res.Count());

            sw.Reset();
            sw.Start();
            numDict.RemoveVertical(50, 0, 300);
            sw.Stop();
            Console.WriteLine("REMOVE VERTICAL TICKS: " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            numDict.RemoveInArea(0, 400, 0, 400);
            sw.Stop();
            Console.WriteLine("REMOVE IN AREA MS: " + sw.ElapsedMilliseconds);

            res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("AFTER REMOVAL: " + res.Count());

            //////////////////////////////////////////////////////////////////////

            numDict = new NestedDictionary<int>();

            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    if ((i + j) % 4 == 0)
                    {
                        numDict.Put(i, j, 9);
                    }
                }
            }

            res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("BEFORE REMOVAL: " + res.Count());

            sw.Reset();
            sw.Start();
            numDict.RemoveVerticalOld(50, 0, 300);
            sw.Stop();
            Console.WriteLine("REMOVE VERTICAL OLD TICKS: " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            numDict.RemoveInArea(0, 400, 0, 400);
            sw.Stop();
            Console.WriteLine("REMOVE IN AREA MS: " + sw.ElapsedMilliseconds);

            res = numDict.GetAnyInAreaToList(0, 499, 0, 499);
            Console.WriteLine("AFTER REMOVAL: " + res.Count());
        }

        public static void Execute_MovementSimulation()
        {
            Stopwatch sw = new Stopwatch();
            NestedDictionary<int> numDict;
            numDict = new NestedDictionary<int>();

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    numDict.Put(i, j, 9);
                }
            }

            List<int> res = numDict.GetAnyInAreaToList(0, 500, 0, 500);
            Console.WriteLine("Conservation of elements: " + res.Count());

            sw.Reset();
            sw.Start();
            numDict.RemoveHorizontal(0, 59, 0);
            sw.Stop();
            Console.WriteLine("REMOVE HORIZONTAL TICKS: " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 60; i++)
            {
                numDict.Put(i, 30, 9);
            }
            sw.Stop();
            Console.WriteLine("INSERT HORIZONTAL TICKS: " + sw.ElapsedTicks);

            res = numDict.GetAnyInAreaToList(0, 500, 0, 500);
            Console.WriteLine("Conservation of elements: " + res.Count());

            ////////////////////////////

            sw.Reset();
            sw.Start();
            numDict.RemoveVertical(0, 1, 30);
            sw.Stop();
            Console.WriteLine("REMOVE VERTICAL TICKS: " + sw.ElapsedTicks);

            sw.Reset();
            sw.Start();
            for (int j = 1; j < 31; j++)
            {
                numDict.Put(60, j, 9);
            }
            sw.Stop();
            Console.WriteLine("INSERT VERTICAL TICKS: " + sw.ElapsedTicks);

            res = numDict.GetAnyInAreaToList(0, 500, 0, 500);
            Console.WriteLine("Conservation of elements: " + res.Count());

            //////////////////////////////////////////////////////////////////////

            sw.Reset();
            sw.Start();
            numDict.RemoveInArea(0, 400, 0, 400);
            sw.Stop();
            Console.WriteLine("REMOVE IN AREA MS: " + sw.ElapsedTicks);

            res = numDict.GetAnyInAreaToList(0, 500, 0, 500);
            if (res!= null)
                Console.WriteLine("Conservation of elements: " + res.Count());
        }

        //TEST Coordinated Dictionary
        public static void Execute_Coordinated_Put()
        {
            List<int> ls = new List<int> {
                new int(),
                new int(),
                new int(),
            };

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    coordDict.Put(i, j, ls);
                }
            }

            if (showConsoleLog)
                Console.WriteLine("Found: " + coordDict.getDictionary().Count);
        }

        public static void Execute_Coordinated_Get()
        {
            List<int> res = null; ;
            for (int i = 0; i < 100; i++)
            {
                res = coordDict.TryGet(i, i);
            }
            //Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_Coordinated_GetAll_X()
        {
            List<List<int>> res;
            List<int> first;
            res = coordDict.GetInXToList(sVer);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_Coordinated_GetAll_Y()
        {
            List<List<int>> res;
            List<int> first;
            res = coordDict.GetInYToList(sHor);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);
        }

        public static void Execute_Coordinated_GetAnyInArea()
        {
            List<List<int>> res;
            List<int> first;
            res = coordDict.GetAnyInAreaToList(sX1, sX2, sY1, sY2);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_Coordinated_GetAnyInArea_Contains()
        {
            List<List<int>> res;
            List<int> first;
            res = coordDict.GetAnyInAreaToListContains(sX1, sX2, sY1, sY2);
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);            
        }

        public static void Execute_Coordinated_GetAll()
        {
            List<List<int>> res;
            List<int> first;
            res = coordDict.GetAllToList();
            first = res.First();

            if (showConsoleLog)
                Console.WriteLine("Found: " + res.Count);            
        }
    }
}
