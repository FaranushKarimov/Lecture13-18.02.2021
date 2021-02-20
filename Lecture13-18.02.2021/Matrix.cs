using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Lecture13_18._02._2021
{
    public static class Matrix
    {
        private static object locker = new object();
        public static async void StartAsyncMartix()
        {

            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;


            Task[] tasks = new Task[1000];
            for (int i = 0; i < 60; i++)
            {
                int curSec = DateTime.Now.Second;
                if (i == 59)
                {
                    return;
                }
                int left = new Random().Next(0, 50);
                tasks[i] = Task.Run(() => showMatrix(left));
            }
            await Task.WhenAll(tasks);
        }

        static void checkTile(int size, int curPos, int left)
        {
            lock (locker)
            {
                for (int i = 0; i < curPos - size; i++)
                {
                    Console.CursorLeft = left;
                    Console.CursorTop = i;
                    Console.ResetColor();
                    Console.WriteLine(" ");
                }
            }
        }

        static void showMatrix(int left)
        {

            string txt = GenerateString();
            int t = 0;
            while (true)
            {
                lock (locker)
                {
                    for (int i = 0; i < txt.Length; i++)
                    {
                        Console.CursorVisible = false;
                        Console.CursorLeft = left;
                        Console.CursorTop = t++;
                        if (i == txt.Length - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(txt[i]);

                        }
                        else if (i == txt.Length - 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(txt[i]);

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(txt[i]);
                        }

                        if (txt.Length <= t)
                            checkTile(txt.Length, t, left);
                        Console.ResetColor();
                    }
                }
            }
        }
        static string GenerateString()
        {
            const string PERMANENT_STRING = "qwertyuiopasdfghjklzxcvbnm1234567890!@#$%^&*()";
            Random rand = new Random();
            int size = rand.Next(5, 10);
            int index = rand.Next(0, PERMANENT_STRING.Length);

            // tempString
            string tempRandomString = "";
            while (size > 0)
            {
                tempRandomString += PERMANENT_STRING[index];

                index = rand.Next(0, PERMANENT_STRING.Length);
                size--;
            }
            return tempRandomString;
        }
    }
}
