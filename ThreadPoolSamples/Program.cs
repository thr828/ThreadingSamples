using System;
using System.Threading;

namespace Wrox.ProCSharp.Threading
{


    class Program
    {
        static void Main()
        {
            int nWorkerThreads;  //最大工作线程
            int nCompletionPortThreads;//最大I/O线程数
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Max worker threads: {0}, I/O completion threads: {1}", nWorkerThreads, nCompletionPortThreads);
            ThreadPool.SetMaxThreads(2,2);
            ThreadPool.SetMinThreads(1, 1);

            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(JobForAThread);

            }

            Thread.Sleep(3000);

            Console.ReadKey();
        }


        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("loop {0}, running inside pooled thread {1}", i,
                   Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }

        }
    }
}
