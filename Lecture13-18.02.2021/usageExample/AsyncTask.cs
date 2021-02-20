using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture13_18._02._2021.usageExample
{
    public static class AsynsTask
    {
        //! Uses Async Programming to Calculate in the Background without interfering to user interface
        private static object locker = new object();
        public static async void CalculateAsync(int n)
        {
            Task<int> t1 = new Task<int>(() => Fibonacci(n));
            t1.Start();
            Task<int> t2 = new Task<int>(() => Factorial(n));
            t2.Start();
            await Task.WhenAll(new[] { t1, t2 });
            if (t1.IsCompleted && t2.IsCompleted)
            {
                Console.CursorTop = 15;
                Console.CursorLeft = 8;
            }

        }
        static int Fibonacci(int n)
        {

            lock (locker)
            {
                Thread.Sleep(1500);
                Console.CursorTop = 3;
                Console.CursorLeft = 0;
                System.Console.Write($"Calculating Finonacci of {n}");
                int first = 1;
                int second = 1;
                int left = 27;
                for (int i = 1; i <= n; i++)
                {
                    Console.CursorTop = 3;
                    Console.CursorLeft = left++;
                    System.Console.Write(".");
                    Thread.Sleep(500);
                    int temp = second;
                    second += first;
                    first = temp;
                }
                Console.Write(second);
                Console.WriteLine();
                return second;
            }
        }
        static int Factorial(int n)
        {
            lock (locker)
            {
                int result = 1;
                Thread.Sleep(1500);
                Console.CursorLeft = 0;
                Console.CursorTop = 1;
                System.Console.Write($"Calculating Factorial of {n}");
                int left = 27;
                for (int i = 1; i <= n; i++)
                {
                    Console.CursorTop = 1;
                    Console.CursorLeft = left++;
                    System.Console.Write(".");
                    Thread.Sleep(500);
                    result *= i;
                }
                Console.Write(result);
                Console.WriteLine();
                return result;
            }
        }
    }
}
