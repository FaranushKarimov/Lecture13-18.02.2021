using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture13_18._02._2021.usageExample
{
    public static class Parallel1
    {
        public static void executeNumberCounter()
        {
            System.Console.WriteLine("Counting Started");
            Parallel.For(1, 10, Counter);
            System.Console.WriteLine("Countring Ended");
        }

        private static void Counter(int arg1, ParallelLoopState arg2)
        {
            Thread.Sleep(100);
            System.Console.WriteLine(arg1);
        }
    }
}
