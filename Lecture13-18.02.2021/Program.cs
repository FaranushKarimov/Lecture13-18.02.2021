using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Lecture13_18._02._2021.usageExample;

namespace Lecture13_18._02._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;

            bool working = true;
            while (working)
            {
                System.Console.Write("Choose what you want to see: \n1.Matrix\n2.Threads\n3.Async\n4.Parallel\nExit\nChoose: ");
                int choice;
                int seconds = 1000;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {

                        case 1:
                            {
                                //! shows matrix
                                showMatrix(token);
                                seconds = 7000;
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                //! Inserts data to array 
                                MultiThreads.insertID(100);
                                seconds = 1000;
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                //! Does calculations async
                                showCalculationAsync(5);
                                seconds = 1000;
                            }
                            break;
                        case 4:
                            {
                                System.Console.WriteLine("Parallel");
                                Parallel1.executeNumberCounter();
                                seconds = 2000;
                            }
                            break;
                        case 5:
                            {
                                working = false;
                            }
                            break;
                    }
                }

                if (choice == 3)
                {
                    Console.CursorTop = 10;
                }
                if (choice != 3)
                {
                    Thread.Sleep(seconds);
                    Console.Clear();
                }
            }

            Console.ReadKey();
        }
        static void showCalculationAsync(int n)
        {
            System.Console.WriteLine("Main Thread");
            Thread.Sleep(1000);
            AsynsTask.CalculateAsync(n);
            Console.CursorTop = Console.CursorTop + 3;
            Console.CursorLeft = 0;
            System.Console.WriteLine("Main Thread End");
        }
        static void showMatrix(CancellationToken token)
        {

            System.Console.Write($"Matrix show starts in 3");
            for (int i = 3; i >= 0; i--)
            {
                Console.CursorLeft = 22;
                System.Console.Write(i);
                Thread.Sleep(1000);
            }
            Console.Clear();
            Matrix.StartAsyncMartix();
        }














        /*
        static string stringGenerator(){
            string text = "1234567890qwertyuiop"; 
            Random rand = new Random();
            int size = rand.Next(1,10);
            string tempString = ""; 
            for ( int i = 0; i < size; i++ ){
                int index = rand.Next(0,text.Length);
                tempString += text[index];
            }
            return tempString; 
        }
        
        static async void multipleAsyncTasks(){
            Task<string> t1 = Task.Run(()=>stringGenerator());
            Task<string> t2 = Task.Run(()=>stringGenerator());
            Task<string> t3 = Task.Run(()=>stringGenerator());
            string[] tRes = await Task.WhenAll(new []{t1, t2, t3}); 
            foreach( string res in tRes ){
                Thread.Sleep(2000); 
                await Task.Run(()=>ShowTaskResults(res)); 
            }
        }

        private static void ShowTaskResults(string t1)
        {
            System.Console.WriteLine(t1);
        }

        static async void ReadWriteAsync(){
            string s = "1"; 
            using ( StreamWriter writer = new StreamWriter("input.txt", true) ){
                await writer.WriteLineAsync(s); 
            }
            using ( StreamReader reader = new StreamReader("input.txt")){
                string result = await reader.ReadToEndAsync(); 
                Console.WriteLine(result);
            }
        }

        static void Factorial(){
            int result = 1; 
            for ( int i = 1; i <= 6; i++ ){
                result *= i; 
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Factorial of {6} equals {result}"); 
        }
        static async void FactorialAsync(){
            Console.WriteLine("Start of Async Task");
            await Task.Run(()=> Factorial());
            Console.WriteLine("End of Async Task");  
        }*/

    }
}
