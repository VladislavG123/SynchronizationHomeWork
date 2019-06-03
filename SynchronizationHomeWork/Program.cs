using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            object lockObject = new object();
            var threads = new Thread[20];
            var user = new User { Money = 0 };

            for (int i = 0; i < threads.Length; i++)
            {
                var thread = new Thread(nullArgument =>
               {
                   lock (lockObject)
                   {
                       Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работать со значением {(user as User).Money}\n");
                       Thread.Sleep(5 * new Random().Next(500));
                       int randomNumber = new Random().Next(1000) - 500;
                       user.Money += randomNumber;
                       Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} прибавил к значению {randomNumber}\n");
                       Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} закончил работать со знaчением {(user as User).Money}\n");
                   }
               });
                threads[i] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.Read();
        }
    }
}
