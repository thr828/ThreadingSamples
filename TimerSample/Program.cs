using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wrox.ProCSharp.Threading
{
    /// <summary>
    /// thread 默认是前台线程，threadpool是后台线程，task默认是后台线程，应用程序的主线程都默认为前台线程 
    /// 后台线程不会阻止进程的终止。属于某个进程的所有前台线程都终止后，该进程就会被终止。所有剩余的后台线程都会停止且不会完成。
    /// </summary>
    class Program
    {
        private static void ThreadingTimer()
        {
            var t1 = new System.Threading.Timer(
               TimeAction, null, TimeSpan.FromSeconds(2),
               TimeSpan.FromSeconds(3));

            Thread.Sleep(15000);

            t1.Dispose();
        }

        static void TimeAction(object o)
        {
            Console.WriteLine("System.Threading.Timer {0:T}", DateTime.Now);
        }

        private static void TimersTimer()
        {
            var t1 = new System.Timers.Timer(1000);
            t1.AutoReset = true;
            t1.Elapsed += TimeAction;
            t1.Start();
            Thread.Sleep(7000);
            Console.WriteLine("结束");
            t1.Stop();

            t1.Dispose();
            Console.ReadKey();
        }

        static void TimeAction(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("System.Timers.Timer {0:T}", e.SignalTime);
        }


        static void Main(string[] args)
        {
             ThreadingTimer();
             //  TimersTimer();
        }
    }
}
