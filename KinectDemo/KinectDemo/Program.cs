using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KinectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(DiffucultComputation)); // specify which method to run in a different thread
            t.Start(); // start the thread

            while (t.IsAlive) // while this thread is running, the main thread is able to do some other things
            {
                Thread.Sleep(1000); // pause all computations on the main thread
                Console.WriteLine("Still doing some difficult stuff"); // print something in the main thread
            }

            Console.WriteLine("Computation done");
        }

        /// <summary>
        /// This method will take some time to run.
        /// </summary>
        static void DiffucultComputation()
        {
            Console.WriteLine("Starting some difficult computation");
            long result = 0;
            for (int x = 0; x < 100000; x++)
            {
                for(int y = 0; y < 20000; y++)
                {
                    result++;
                }
            }
            Console.WriteLine("Computation done, result: " + result);
        }
    }
}
