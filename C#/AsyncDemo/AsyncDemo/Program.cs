using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Task<String> result = Process();

            AnotherProcess();

            String value = await result;

            Console.WriteLine(value);

            Console.ReadLine();
        }

        static async Task<String> Process()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread 1 started");

                await Task.Delay(500);

                Console.WriteLine("Thread 1 finished");
            }
            

            return "Process completed";
        }

        static void AnotherProcess()
        {
            Console.WriteLine("Thread 2 started");
            

            Console.WriteLine("Thread 2 finished");
        }

    }
}
