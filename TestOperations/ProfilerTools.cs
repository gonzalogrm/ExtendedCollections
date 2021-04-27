using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public class ProfilerTools
    {
        public static void ProfileMilliseconds(string description, int iterations, Action func)
        {
            // warm up 
            func();
            // clean up
            GC.Collect();

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.WriteLine(description);
            Console.WriteLine("Profiler Tools: Time Elapsed {0} ms", watch.ElapsedMilliseconds);
        }

        public static void ProfileTicks(int iterations, Action func)
        {
            // warm up 
            func();
            // clean up
            GC.Collect();

            var watch = new Stopwatch();
            
            for (int i = 0; i < iterations; i++)
            {
                watch.Start();
                func();
                watch.Stop();
                Console.WriteLine(watch.ElapsedTicks);
                watch.Reset();
            }
        }

        public static List<double> ProfileTicksSetup(int iterations, Action setup, Action func)
        {
            //prevent the JIT Compiler from optimizing Fkt calls away
            long seed = Environment.TickCount;

            //use the second Core/Processor for the test
            //Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);

            //prevent "Normal" Processes from interrupting Threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            //prevent "Normal" Threads from interrupting this thread
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // warm up 
            setup();
            func();            

            var watch = new Stopwatch();
            long ticks = 0;
            List<double> result = new List<double>();
            for (int i = 0; i < iterations; i++)
            {
                watch.Start();
                func();
                watch.Stop();

                ticks = watch.ElapsedTicks;
                result.Add(ticks);
                //Console.WriteLine(ticks);

                watch.Reset();
            }
            return result;
        }
    }
}
