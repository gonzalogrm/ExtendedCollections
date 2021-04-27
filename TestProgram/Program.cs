using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedCollections.TestOperations;

namespace ExtendedCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("BUILD: 07-11-2020");
            Console.WriteLine(".NET 4.8.04084");
            Console.WriteLine("TEST: - Dictionary comparison");
            Console.WriteLine("Waiting Input to Start MAIN.");
            Console.ReadLine();

            ProfileTest4A();

            long memory = GC.GetTotalMemory(true);
            Console.WriteLine("Waiting Input to End MAIN.");
            Console.WriteLine("MEMORY B: " + memory);
            Console.WriteLine("MEMORY KB: " + memory / 1000);
            Console.WriteLine("MEMORY MB: " + memory / 1000000);
            Console.ReadLine();
        }

        /// <summary>
        /// Comparison between ExtendedJaggedArray and NestedDictionary. Get All. Constant Size, variable density.
        /// </summary>
        static void ProfileTest1()
        {
            string statistics;
            int numIterations = 10000;
            int sizeX = 1000, sizeY = 1000;
            Console.WriteLine("\n ########## 1000 1-1 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 1, 1);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 1, 1);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n ########## 1000 2-1 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 2, 1);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 2, 1);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n ########## 1000 2-2 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 2, 2);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n ########## 1000 3-1 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 3, 1);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 3, 1);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n ########## 1000 3-2 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 3, 2);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 3, 2);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n ########## 1000 3-3 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 3, 3);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 3, 3);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n ########## 1000 4-4 ########## \n");

            TestExtendedArrayToProfile.SetSizes(sizeX, sizeY, 4, 4);
            TestNestedDictionaryToProfile.SetSizes(sizeX, sizeY, 4, 4);

            Console.WriteLine("Execute_GetAll");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("Execute_GetAll_Jagged");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAll_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);
        }

        /// <summary>
        /// Comparison between ExtendedJaggedArray and NestedDictionary. Get Any in Area. Constant Size, variable Density.
        /// </summary>
        static void ProfileTest2()
        {
            string statistics;
            int numIterations = 10000;

            TestExtendedArrayToProfile.SetSizes(500, 500, 1, 1);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 1, 1);

            Console.WriteLine("\n ########## 500 1-1 ########## \n");
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);



            Console.WriteLine("\n ########## 500 2-1 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 1);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 1);
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);



            Console.WriteLine("\n ########## 500 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);



            Console.WriteLine("\n ########## 500 3-1 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 3, 1);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 3, 1);
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);




            Console.WriteLine("\n ########## 500 3-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 3, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 3, 2);
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);




            Console.WriteLine("\n ########## 500 3-3 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 3, 3);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 3, 3);
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("\n ########## 500 3-3 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 4, 4);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 4, 4);
            TestExtendedArrayToProfile.SetSearchArea(200, 249, 200, 249);
            TestNestedDictionaryToProfile.SetSearchArea(200, 249, 200, 249);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);
        }

        /// <summary>
        /// Comparison between ExtendedJaggedArray and NestedDictionary. Get Any in Area. Constant Density, variable Search Area.
        /// </summary>
        static void ProfileTest3()
        {
            string statistics;
            int numIterations = 10000;

            Console.WriteLine("\n ########## 500 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 499, 0, 499);
            TestNestedDictionaryToProfile.SetSearchArea(0, 499, 0, 499);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);





            Console.WriteLine("\n ########## 450 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 449, 0, 449);
            TestNestedDictionaryToProfile.SetSearchArea(0, 449, 0, 449);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);



            Console.WriteLine("\n ########## 400 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 399, 0, 399);
            TestNestedDictionaryToProfile.SetSearchArea(0, 399, 0, 399);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);




            Console.WriteLine("\n ########## 300 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 299, 0, 299);
            TestNestedDictionaryToProfile.SetSearchArea(0, 299, 0, 299);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);



            Console.WriteLine("\n ########## 200 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 199, 0, 199);
            TestNestedDictionaryToProfile.SetSearchArea(0, 199, 0, 199);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);




            Console.WriteLine("\n ########## 100 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 99, 0, 99);
            TestNestedDictionaryToProfile.SetSearchArea(0, 99, 0, 99);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);




            Console.WriteLine("\n ########## 50 2-2 ########## \n");
            TestExtendedArrayToProfile.SetSizes(500, 500, 2, 2);
            TestNestedDictionaryToProfile.SetSizes(500, 500, 2, 2);
            TestExtendedArrayToProfile.SetSearchArea(0, 49, 0, 49);
            TestNestedDictionaryToProfile.SetSearchArea(0, 49, 0, 49);

            Console.WriteLine("Execute JAGGED Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestExtendedArrayToProfile.GenerateJaggedArray,
                        TestExtendedArrayToProfile.Execute_GetAnyInArea_Jagged_NotNull
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("ExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);
        }

        /// <summary>
        /// Comparison between NestedDictionary and CoordinatedDictionary.
        /// </summary>
        static void ProfileTest4()
        {
            string statistics;
            int numIterations = 1000;

            TestNestedDictionaryToProfile.SetSearchXY(0, 0);
            TestNestedDictionaryToProfile.SetSizes(1000, 1000, 2, 2);
            TestNestedDictionaryToProfile.SetSearchArea(200, 299, 200, 299);

            Console.WriteLine("\n ########## 1000 2-2 ########## \n");
            Console.WriteLine("\n################# NESTED DICTIONARY \n");

            Console.WriteLine("\nExecuteGet All");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All X");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll_X
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All Y");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll_Y
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("\nExecute Get All Y AUX");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll_Y_Auxiliar
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Put");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_Put
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_Get
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n################# COORDINATED DICTIONARY \n");

            Console.WriteLine("\nExecuteGet All");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAll
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All X");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAll_X
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All Y");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAll_Y
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Put");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_Put
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_Get
                        )
                    );
            Console.WriteLine(statistics);
        }

        /// <summary>
        /// Comparison between NestedDictionary and CoordinatedDictionary. Lighter Test.
        /// </summary>
        static void ProfileTest4A()
        {
            string statistics;
            int numIterations = 1000;

            TestNestedDictionaryToProfile.SetSearchXY(0, 0);
            TestNestedDictionaryToProfile.SetSizes(1000, 1000, 2, 2);
            TestNestedDictionaryToProfile.SetSearchArea(200, 299, 200, 299);

            Console.WriteLine("\n ########## 1000 2-2 ########## \n");
            Console.WriteLine("\n################# NESTED DICTIONARY \n");

            Console.WriteLine("\nExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All X");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll_X
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All Y");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll_Y
                        )
                    );
            Console.WriteLine(statistics);

            Console.WriteLine("\nExecute Get All Y AUX");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateDictionary,
                        TestNestedDictionaryToProfile.Execute_GetAll_Y_Auxiliar
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\n################# COORDINATED DICTIONARY \n");

            Console.WriteLine("\nExecuteGet Any In Area");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAnyInArea
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecuteGet Any In Area Contains");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAnyInArea_Contains
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All X");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAll_X
                        )
                    );
            Console.WriteLine(statistics);


            Console.WriteLine("\nExecute Get All Y");
            statistics =
                MathExtensions.StatisticsToString(
                    ProfilerTools.ProfileTicksSetup(
                        numIterations,
                        TestNestedDictionaryToProfile.GenerateCoordinatedDictionary,
                        TestNestedDictionaryToProfile.Execute_Coordinated_GetAll_Y
                        )
                    );
            Console.WriteLine(statistics);
        }
    }
}

