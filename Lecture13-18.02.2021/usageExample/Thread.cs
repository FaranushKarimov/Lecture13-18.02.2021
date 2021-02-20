using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture13_18._02._2021.usageExample
{
    //! Uses CPU in maximum to fill large size of array
    //! For example if array size of 1e6 it will divide to multiple threads to fill array with values
    public static class MultiThreads
    {
        public static int arraySize { get; set; }
        public static int[] largeArray = new int[arraySize];
        public static void insertID(int size)
        {
            largeArray = new int[size];
            int partSize = size / 10;
            int lengthOfArray = 10;
            int left = size % 10;
            if (size < 10)
            {
                partSize = size;
                lengthOfArray = size;
            }
            Thread[] threads = new Thread[partSize];
            int start = 0, end = lengthOfArray, value = 1;
            for (int i = 0; i < partSize; i++)
            {

                if (start > size || end > size)
                {
                    break;
                }
                arrayHelper array = new arrayHelper(start, end, value);
                threads[i] = new Thread(new ParameterizedThreadStart(fillArrayFast));
                threads[i].Start(array);
                Thread.Sleep(1000);

                start += lengthOfArray;
                end += lengthOfArray;
            }
            if (left > 0)
            {
                if (partSize > 10)
                {
                    arrayHelper array = new arrayHelper(start + lengthOfArray, end + left, value);
                    Thread thread = new Thread(new ParameterizedThreadStart(fillArrayFast));
                    thread.Start(array);
                }
                else
                {
                    arrayHelper array = new arrayHelper(start, left, value);
                    Thread thread = new Thread(new ParameterizedThreadStart(fillArrayFast));
                    thread.Start(array);
                }
            }
        }
        static void fillArrayFast(object obj)
        {
            arrayHelper array = (arrayHelper)obj;
            int start = array.start;
            int end = array.end;
            int value = array.value;
            System.Console.WriteLine($"Starting from {start} to {end} with value = {value}");
            for (int i = start; i < end; i++)
            {
                largeArray[i] = value;
            }
        }
    }
    class arrayHelper
    {
        internal int start { get; set; }
        internal int end { get; set; }
        internal int value { get; set; }
        internal arrayHelper(int start, int end, int value)
        {
            this.start = start;
            this.end = end;
            this.value = value;
        }
    }
}
