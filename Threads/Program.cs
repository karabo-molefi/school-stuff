using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;

            mainThread.Name = "Main Thread";

            Thread thread1 = new Thread(CountUp);
            Thread thread2 = new Thread(CountDown);

            thread1.Start();
            thread2.Start();
            // count 
           

             
        }
        public static void CountDown()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine("Timer 1:" + i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Timer 1 is complete");


        }
        public static void CountUp()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Timer 1:" + i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Timer 2 is complete");


        }
    }
}
