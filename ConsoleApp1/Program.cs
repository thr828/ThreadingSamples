using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //前台线程
           Thread thread=new Thread(()=>Console.ReadLine());
           if (args.Length > 0)
           {
               thread.IsBackground = true;
           }
           thread.Start();
        }
    }
}